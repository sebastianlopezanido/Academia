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
        }

        public PersonasDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            
        }

        public PersonasDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
      
            PersonasLogic cp = new PersonasLogic(); //controlador :)
            PersonaActual = cp.GetOne(id);
            
            this.MapearDeDatos();
        }

        


        private BusinessEntities.Personas _PersonaActual;
        public BusinessEntities.Personas PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtFecha.Text = this.PersonaActual.FechaNacimiento.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();            
            

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }

        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PersonaActual = new BusinessEntities.Personas();
                    
                    this.PersonaActual.Nombre = this.txtNombre.Text;
                    this.PersonaActual.Apellido = this.txtApellido.Text;
                    this.PersonaActual.Email = this.txtEmail.Text;
                    this.PersonaActual.Direccion = this.txtDireccion.Text;
                    this.PersonaActual.Telefono = this.txtTelefono.Text;
                    this.PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFecha.Text);
                    this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);                    
                    

                    
                    this.PersonaActual.State = BusinessEntities.Personas.States.New;

                    break;
                case ModoForm.Modificacion:
                    
                    this.PersonaActual.Nombre = this.txtNombre.Text;
                    this.PersonaActual.Apellido = this.txtApellido.Text;
                    this.PersonaActual.Email = this.txtEmail.Text;
                    this.PersonaActual.Direccion = this.txtDireccion.Text;
                    this.PersonaActual.Telefono = this.txtTelefono.Text;
                    this.PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFecha.Text);
                    this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);                    
                    


                    this.PersonaActual.State = BusinessEntities.Personas.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.PersonaActual.State = BusinessEntities.Personas.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.PersonaActual.State = BusinessEntities.Personas.States.Unmodified;
                    break;
            }

        }
        
        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonasLogic pl = new PersonasLogic();
            pl.Save(PersonaActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text)
                || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtDireccion.Text)
                || string.IsNullOrEmpty(this.txtTelefono.Text) || string.IsNullOrEmpty(this.txtFecha.Text) 
                || (string.IsNullOrEmpty(this.txtLegajo.Text)) || (string.IsNullOrEmpty(this.txtIDPlan.Text)))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
