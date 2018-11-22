using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntities;
using BusinessLogic;
using System.Net.Mail;

namespace UI.Desktop
{
    public partial class UsuariosDesktop : ApplicationForm
    {
        public UsuariosDesktop()
        {
            InitializeComponent();
            cbxTipo.DataSource = Enum.GetValues(typeof(Usuario.TiposUsuario));
            PlanLogic pl = new PlanLogic();
            cbxIDPlan.DataSource = pl.GetAll();
            cbxIDPlan.ValueMember = "ID";
            cbxIDPlan.DisplayMember = "Descripcion";
        }

        public UsuariosDesktop(ModoForm modo):this() //aca entra el Nuevo
        {
            Modo = modo;
            Text = CambiarTextos(btnAceptar);
        }

        public UsuariosDesktop(int id,ModoForm modo) : this() //aca entra el Editar
        {
            Modo = modo;
            UsuarioLogic cu = new UsuarioLogic(); //controlador :)
            UsuarioActual = cu.GetOne(id);
            Text = CambiarTextos(btnAceptar);
            MapearDeDatos();
            OcultarFind();
        }
        
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = UsuarioActual.ID.ToString();
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            txtIdPersona.Text = UsuarioActual.IDPersona.ToString();
            cbxTipo.SelectedItem = UsuarioActual.Tipo;
            cbxIDPlan.SelectedValue = UsuarioActual.IDPlan.ToString();
            txtClave.Text = UsuarioActual.Clave;
            txtUsuario.Text = UsuarioActual.NombreUsuario;            
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual = new Usuario();
                    UsuarioActual.Habilitado = chkHabilitado.Checked;
                    UsuarioActual.IDPersona = int.Parse(txtIdPersona.Text);
                    UsuarioActual.IDPlan = (int)cbxIDPlan.SelectedValue;
                    UsuarioActual.Tipo = (Usuario.TiposUsuario)cbxTipo.SelectedItem;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;              
                case ModoForm.Modificacion:
                    UsuarioActual.ID = int.Parse(txtID.Text);
                    UsuarioActual.Habilitado = chkHabilitado.Checked;
                    UsuarioActual.IDPersona = int.Parse(txtIdPersona.Text);
                    UsuarioActual.IDPlan = (int)cbxIDPlan.SelectedValue;
                    UsuarioActual.Tipo = (Usuario.TiposUsuario)cbxTipo.SelectedItem;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public void EsAdmin()
        {
            if((Usuario.TiposUsuario)cbxTipo.SelectedValue == Usuario.TiposUsuario.Administrador)
            {
                UsuarioActual.IDPlan = null;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            EsAdmin();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        public override bool Validar()
        {
            if(string.IsNullOrEmpty(txtIdPersona.Text) || cbxIDPlan.SelectedValue == null || string.IsNullOrEmpty(txtClave.Text)
                || string.IsNullOrEmpty(txtConfirmarClave.Text) || string.IsNullOrEmpty(txtUsuario.Text) || cbxTipo.SelectedValue == null)
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if(txtClave.Text != txtConfirmarClave.Text )
            {
                Notificar("Claves no coinciden", "Las claves deben ser iguales", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (txtClave.Text.Length < 8)
            {
                Notificar("Clave no segura", "La clave debe ser mayor a 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            
            return true;
        }

        public void OcultarFind()
        {
            if (Modo != ModoForm.Alta ) btnBuscarPersona.Hide();          
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }            
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            FindPersona findPersonaForm = new FindPersona();
            findPersonaForm.pasado += new FindPersona.pasar(Ejecutar);
            findPersonaForm.ShowDialog();
        }

        public void Ejecutar(int dato)
        {
            txtIdPersona.Text = dato.ToString();
        }
    }
}
