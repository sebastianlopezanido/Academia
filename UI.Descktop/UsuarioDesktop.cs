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

namespace UI.Desktop
{
    public partial class UsuarioDesktop : Form
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

        public enum ModoForm //deberia heredarse
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        private ModoForm _Modo;
        public ModoForm Modo
        {
            get { return Modo; }
            set { _Modo = value; }
        }





        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }





        public void MapearDeDatos()
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
        public void MapearADatos()
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
        public void GuardarCambios() { }
        public bool Validar()
        {
            return false;

        }

    }
}
