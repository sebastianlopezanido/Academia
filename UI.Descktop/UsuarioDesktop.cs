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
        }

        public UsuarioDesktop(ModoForm modo):this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int id,ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic cu = new UsuarioLogic(); //controlador :)
            UsuarioActual = cu.GetOne(id);
            this.MapearDeDatos();
        }
        
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

         public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            switch(this.Modo)
            {
                case ModoForm.Alta:
                    break;
                case ModoForm.Modificacion: this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja: this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta: this.btnAceptar.Text = "Aceptar";
                    break;
            }
            
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta: UsuarioActual = new Usuario();
                                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                                    this.UsuarioActual.Nombre = this.txtNombre.Text;
                                    this.UsuarioActual.Apellido = this.txtApellido.Text;
                                    this.UsuarioActual.Email = this.txtEmail.Text;
                                    this.UsuarioActual.Clave = this.txtClave.Text;
                                    this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                                    this.UsuarioActual.State = Usuario.States.New;

                    break;              
                case ModoForm.Modificacion: this.UsuarioActual.ID = int.Parse(this.txtID.Text);
                                            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                                            this.UsuarioActual.Nombre = this.txtNombre.Text;
                                            this.UsuarioActual.Apellido = this.txtApellido.Text;
                                            this.UsuarioActual.Email = this.txtEmail.Text;
                                            this.UsuarioActual.Clave = this.txtClave.Text;
                                            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                                            this.UsuarioActual.State = Usuario.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.UsuarioActual.State = Usuario.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.UsuarioActual.State = Usuario.States.Unmodified;
                    break;
            }

        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }
        public override bool Validar()
        {
            if(string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) 
                || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtClave.Text)
                || string.IsNullOrEmpty(this.txtConfirmarClave.Text) || string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(this.txtClave.Text != this.txtConfirmarClave.Text )
            {
                Notificar("Claves no coinciden", "Las claves deben ser iguales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtClave.Text.Length < 8)
            {
                Notificar("Clave no segura", "La clave debe ser mayor a 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                new MailAddress(this.txtEmail.Text);               
            }
            catch (FormatException)
            {
                Notificar("Email no valido", "Ingrese un Email valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
            
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
