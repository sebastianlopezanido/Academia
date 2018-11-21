using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BusinessLogic;

namespace UI.Web
{
    public partial class Planes : System.Web.UI.Page
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

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private Plan Entity
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
            txtId.Text = Entity.ID.ToString();
            txtDescripcion.Text = Entity.Descripcion.ToString();
            txtEspecialidad.Text = Entity.IDEspecialidad.ToString();            
        }

        private void LoadEntity(Plan plan)
        {
            if (FormMode == FormModes.Modificacion) plan.ID = int.Parse(txtId.Text);
            plan.IDEspecialidad = int.Parse(txtEspecialidad.Text);
            plan.Descripcion = txtDescripcion.Text;            
        }

        private void SaveEntity(Plan plan)
        {
            Logic.Save(plan);
        }

        private void EnableForm(bool enable)
        {
            txtId.Enabled = enable;
            txtDescripcion.Enabled = enable;
            txtEspecialidad.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        private void ClearForm()
        {
            txtDescripcion.Text = string.Empty;            
            txtId.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;            
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Plan();
                    Entity.State = BusinessEntity.States.New;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Modificacion:
                    Entity = new Plan();
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