using BusinessEntities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static UI.Web.Usuarios;

namespace UI.Web.AdminPages
{
    public partial class Personas : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Administrador")
            {
                Response.Redirect("http://localhost:57900/Home.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
                
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
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

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private Persona Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return SelectedID != 0;
            }
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

        private void LoadEntity(Persona persona)
        {
            if (FormMode == FormModes.Modificacion) persona.ID = int.Parse(txtId.Text);
            persona.Apellido = txtApellido.Text;
            persona.Nombre = txtNombre.Text;
            persona.Direccion = txtDireccion.Text;
            persona.Telefono = txtTelefono.Text;
            persona.FechaNacimiento = DateTime.Parse(txtFechaNac.Text); 
            persona.Legajo = int.Parse(txtLegajo.Text);
            persona.Email = txtEmail.Text;

        }

        private void SaveEntity(Persona persona)
        {
            try
            {
                Logic.Save(persona);
            }
            catch (Exception ex)
            {
                lblError1.Text = ex.Message;
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
            }
            
        }

        private void ClearForm()
        {
            txtId.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtFechaNac.Text = String.Empty;
            txtLegajo.Text = String.Empty;
            txtId.Text = String.Empty;
            txtEmail.Text = String.Empty;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
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
                lblError.Text = "*Campos incompletos";
                return false;
            }
            int num;
            if (!(int.TryParse(txtLegajo.Text, out num)) )
            {
                lblError.Text = "*Legajo debe ser un numero entero";
                return false;
            }

            return true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {

            
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Persona();
                    Entity.State = BusinessEntity.States.New;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Modificacion:
                    Entity = new Persona();
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    break;
                default:
                    break;
            }
            
            LoadGrid();
            formPanel.Visible = false;
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LoadGrid();
            formPanel.Visible = false;
        }
    }
}