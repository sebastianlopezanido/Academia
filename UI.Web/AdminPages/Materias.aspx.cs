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
    public partial class Materias : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Administrador")
            {
                Response.Redirect("http://localhost:57900/Home.aspx");
            }

            PlanLogic pl = new PlanLogic();
            ddlPlan.DataSource = pl.GetAll();
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataBind();
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

        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private Materia Entity
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
            ddlPlan.SelectedValue = Entity.IDPlan.ToString();
            txtHsTotales.Text = Entity.HSTotales.ToString();
            txtHsSemanales.Text = Entity.HSSemanales.ToString();          
            
        }

        private void LoadEntity(Materia materia)
        {
            if (FormMode == FormModes.Modificacion) materia.ID = int.Parse(txtId.Text);
            materia.HSSemanales = int.Parse(txtHsSemanales.Text);
            materia.HSTotales = int.Parse(txtHsTotales.Text);
            materia.IDPlan = int.Parse(ddlPlan.SelectedValue);
            materia.Descripcion = (string)txtDescripcion.Text;
        }

        private void SaveEntity(Materia materia)
        {
            Logic.Save(materia);
        }

        private void EnableForm(bool enable)
        {
            txtId.Enabled = enable;
            txtDescripcion.Enabled = enable;
            txtHsSemanales.Enabled = enable;
            txtHsTotales.Enabled = enable;
            lblError.Text = "";


        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        private void ClearForm()
        {
            txtDescripcion.Text = string.Empty;
            txtId.Text = string.Empty;
            ddlPlan.ClearSelection();
            txtHsTotales.Text = string.Empty;
            txtHsSemanales.Text = string.Empty;
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
            if (string.IsNullOrEmpty(txtDescripcion.Text) || 
                string.IsNullOrEmpty(txtHsSemanales.Text) ||
                string.IsNullOrEmpty(txtHsTotales.Text))
            {
                lblError.Text = "*Campos incompletos";
                return false;
            }
            int num;
            if (!(int.TryParse(txtHsSemanales.Text,out num)) || !(int.TryParse(txtHsTotales.Text, out num)))
            {
                lblError.Text = "*Horas debe ser un numero entero";
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
                        Entity = new Materia();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        break;
                    case FormModes.Modificacion:
                        Entity = new Materia();
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