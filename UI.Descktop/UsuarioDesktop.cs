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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
            
            cbxTipo.Items.Add(BusinessEntities.Usuario.TiposUsuario.Administrador);
            cbxTipo.Items.Add(BusinessEntities.Usuario.TiposUsuario.Alumno);
            cbxTipo.Items.Add(BusinessEntities.Usuario.TiposUsuario.Profesor);            
        }

        public UsuarioDesktop(ModoForm modo):this()
        {
            Modo = modo;
            Text = CambiarTextos(btnAceptar);
        }

        public UsuarioDesktop(int id,ModoForm modo) : this()
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
            txtIdPlan.Text = UsuarioActual.IDPlan.ToString();
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
                    UsuarioActual.IDPlan = int.Parse(txtIdPlan.Text);
                    UsuarioActual.Tipo = (Usuario.TiposUsuario)cbxTipo.SelectedItem;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;              
                case ModoForm.Modificacion:
                    UsuarioActual.ID = int.Parse(txtID.Text);
                    UsuarioActual.Habilitado = chkHabilitado.Checked;
                    UsuarioActual.IDPersona = int.Parse(txtIdPersona.Text);
                    UsuarioActual.IDPlan = int.Parse(txtIdPlan.Text);
                    UsuarioActual.Tipo = (Usuario.TiposUsuario)cbxTipo.SelectedItem;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        public override bool Validar()
        {
            if(string.IsNullOrEmpty(txtIdPersona.Text) || string.IsNullOrEmpty(txtIdPlan.Text) || string.IsNullOrEmpty(txtClave.Text)
                || string.IsNullOrEmpty(txtConfirmarClave.Text) || string.IsNullOrEmpty(txtUsuario.Text))
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

            /*try
            {
                new MailAddress(txtIdPlan.Text);               
            }
            catch (FormatException)
            {
                Notificar("Email no valido", "Ingrese un Email valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            return true;
        }

        public void OcultarFind()
        {
            if (Modo != ModoForm.Alta )
            {               
                btnBuscarPersona.Hide();
            }            
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
