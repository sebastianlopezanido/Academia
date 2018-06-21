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

namespace UI.Descktop
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

            switch(this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion: this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja: this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta: this.btnAceptar.Text = "Aceptar";
                    break;
            }
            
        }
        public void MapearADatos() { }
        public void GuardarCambios() { }
        public bool Validar() { return false; }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
