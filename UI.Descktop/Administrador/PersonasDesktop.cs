using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Windows.Forms;
using BusinessLogic;
using System.Net.Mail;

namespace UI.Desktop
{
    public partial class PersonasDesktop : ApplicationForm
    {
        public PersonasDesktop()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public PersonasDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            Text = CambiarTextos(btnAceptar);
        }

        public PersonasDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;      
            PersonaLogic cp = new PersonaLogic(); //controlador :)
            PersonaActual = cp.GetOne(id);
            Text = CambiarTextos(btnAceptar);
            MapearDeDatos();
        }      

        private Persona _PersonaActual;
        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = PersonaActual.ID.ToString();
            txtNombre.Text = PersonaActual.Nombre;
            txtApellido.Text = PersonaActual.Apellido;
            txtEmail.Text = PersonaActual.Email;
            txtDireccion.Text = PersonaActual.Direccion;
            txtTelefono.Text = PersonaActual.Telefono;
            txtFecha.Text = PersonaActual.FechaNacimiento.ToString("dd/MM/yyyy");
            txtLegajo.Text = PersonaActual.Legajo.ToString();
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    PersonaActual = new BusinessEntities.Persona();                    
                    PersonaActual.Nombre = txtNombre.Text;
                    PersonaActual.Apellido = txtApellido.Text;
                    PersonaActual.Email = txtEmail.Text;
                    PersonaActual.Direccion = txtDireccion.Text;
                    PersonaActual.Telefono = txtTelefono.Text;
                    PersonaActual.FechaNacimiento = DateTime.Parse(txtFecha.Text);
                    PersonaActual.Legajo = int.Parse(txtLegajo.Text);
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:                    
                    PersonaActual.Nombre = txtNombre.Text;
                    PersonaActual.Apellido = txtApellido.Text;
                    PersonaActual.Email = txtEmail.Text;
                    PersonaActual.Direccion = txtDireccion.Text;
                    PersonaActual.Telefono = txtTelefono.Text;
                    PersonaActual.FechaNacimiento = DateTime.Parse(txtFecha.Text);
                    PersonaActual.Legajo = int.Parse(txtLegajo.Text);
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }
        
        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual); 
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text)
                || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtDireccion.Text)
                || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtFecha.Text) 
                || (string.IsNullOrEmpty(txtLegajo.Text)))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
                   
            try
            {
                new MailAddress(txtEmail.Text);
            }
            catch (FormatException)
            {
                Notificar("Email no valido", "Ingrese un Email valido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            DateTime t;
            if (!DateTime.TryParse(txtFecha.Text ,out t))
            {
                Notificar("Fecha no valida", "Ingrese una Fecha válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            int i;
            if (!int.TryParse(txtLegajo.Text, out i))
            {
                Notificar("Legajo no valido", "Ingrese un legajo numerico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtTelefono.Text, out i))
            {
                Notificar("Telefono no válido", "Ingrese un telefono numerico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;



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
    }
}
