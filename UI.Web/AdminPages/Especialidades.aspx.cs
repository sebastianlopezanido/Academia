using BusinessEntities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static UI.Web.Usuarios;

namespace UI.Web
{
    public partial class WebForm1 : System.Web.UI.Page
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

        EspecialidadLogic _logic;
        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private Especialidad Entity
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
            txtDescripcion.Text = Entity.Descripcion;
            txtId.Text = Entity.ID.ToString();
            
        }

        private void LoadEntity(Especialidad especialidad)
        {
            if (FormMode == FormModes.Modificacion) especialidad.ID = int.Parse(txtId.Text);
            especialidad.Descripcion = txtDescripcion.Text;
        }

        private void SaveEntity(Especialidad especialidad)
        {
            try
            {
                Logic.Save(especialidad);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            
        }

        private void EnableForm(bool enable)
        {
            txtId.Enabled = enable;
            txtDescripcion.Enabled = enable;
            lblError.Text = "";
        }

        private void DeleteEntity(int id)
        {
            try
            {
                Logic.Delete(id);
            }
            catch (Exception ex)
            {
                lblError1.Text = ex.Message;
            }
            
        }

        private void ClearForm()
        {
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;           
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
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblError.Text = "*Campos incompletos";
                return false;
            }
            return true;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()) { 
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Especialidad();
                    Entity.State = BusinessEntity.States.New;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Modificacion:
                    Entity = new Especialidad();
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