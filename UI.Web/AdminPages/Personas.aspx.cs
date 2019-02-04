using BusinessEntities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static UI.Web.Usuarios;

namespace UI.Web.AdminPages
{
    public partial class Personas : ApplicationForm
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Administrador")
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();                
            }
        }        

        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }
       
        public Persona _Entity;
        private Persona Entity
        {
            set { _Entity = value; }
            get { return _Entity; }
        }

        private void LoadGrid()
        {
            gridPersonas.DataSource = Logic.GetAll();
            gridPersonas.DataBind();
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtNombre.Text = Entity.Nombre;
            txtApellido.Text = Entity.Apellido;
            txtDireccion.Text = Entity.Direccion;
            txtTelefono.Text = Entity.Telefono;
            txtFechaNac.Text = Entity.FechaNacimiento.ToString("dd/MM/yyyy");
            txtLegajo.Text = Entity.Legajo.ToString();
            txtId.Text = Entity.ID.ToString();
            txtEmail.Text = Entity.Email;
        }

        private void LoadEntity()
        {
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Persona();
                    Entity.State = BusinessEntity.States.New;
                    Entity.Apellido = txtApellido.Text;
                    Entity.Nombre = txtNombre.Text;
                    Entity.Direccion = txtDireccion.Text;
                    Entity.Telefono = txtTelefono.Text;
                    Entity.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                    Entity.Legajo = int.Parse(txtLegajo.Text);
                    Entity.Email = txtEmail.Text;
                    break;
                case FormModes.Modificacion:
                    Entity = new Persona();
                    Entity.State = BusinessEntity.States.Modified;
                    Entity.ID = int.Parse(txtId.Text);
                    Entity.Apellido = txtApellido.Text;
                    Entity.Nombre = txtNombre.Text;
                    Entity.Direccion = txtDireccion.Text;
                    Entity.Telefono = txtTelefono.Text;
                    Entity.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                    Entity.Legajo = int.Parse(txtLegajo.Text);
                    Entity.Email = txtEmail.Text;
                    break;               
                default:
                    break;
            }                        
        }

        private void SaveEntity(Persona persona)
        {
            try
            {
                Logic.Save(persona);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }           
        }

        private void EnableForm(bool enable)
        {
            txtId.Enabled = enable;
            txtNombre.Enabled = enable;
            txtApellido.Enabled = enable;
            txtDireccion.Enabled = enable;
            txtTelefono.Enabled = enable;
            txtFechaNac.Enabled = enable;
            txtLegajo.Enabled = enable;
            txtId.Enabled = enable;
            txtEmail.Enabled = enable;
            lblError.Text = "";
        }

        private void DeleteEntity(int id)
        {
            try
            {
                Logic.Delete(id);
            }
            catch(Exception ex)
            {
                lblError1.Text = ex.Message;
                lblError1.Visible = true;
            }            
        }

        private void ClearForm()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtFechaNac.Text = string.Empty;
            txtLegajo.Text = string.Empty;
            txtId.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }       

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                EnableForm(true);
                LoadForm(SelectedID);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                try
                {
                    DeleteEntity(SelectedID);
                }
                catch(Exception ex)
                {
                    lblError1.Text = ex.Message;
                    lblError1.Visible = true;
                }
                LoadGrid();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                LoadEntity();
                SaveEntity(Entity);
                LoadGrid();
                formPanel.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LoadGrid();
            formPanel.Visible = false;
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) ||
                string.IsNullOrEmpty(txtFechaNac.Text) ||
                string.IsNullOrEmpty(txtLegajo.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text))
            {
                lblError.Text = "Debe llenar todos los campos";
                return false;
            }

            int num;

            if (!(int.TryParse(txtLegajo.Text, out num)) )
            {
                lblError.Text = "Legajo debe ser un numero entero";
                return false;
            }
            try
            {
                new MailAddress(txtEmail.Text);
            }
            catch (FormatException)
            {
                lblError.Text = "Ingrese un mail valido";

                return false;
            }

            return true;
        }        

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridPersonas.SelectedValue;
            lblError1.Visible = false;
        }      
    }
}