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
    public partial class Materias : ApplicationForm
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
                LoadGrid();
                PlanLogic pl = new PlanLogic();
                ddlPlan.DataSource = pl.GetAll();
                ddlPlan.DataValueField = "ID";
                ddlPlan.DataTextField = "Descripcion";
                ddlPlan.DataBind();
            }
        }

        public Materia _Entity;
        private Materia Entity
        {
            set { _Entity = value; }
            get { return _Entity; }
        }

        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
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
            gridMaterias.DataSource = Logic.GetAll();
            gridMaterias.DataBind();
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

        private void LoadEntity()
        {
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Materia();
                    Entity.State = BusinessEntity.States.New;
                    Entity.HSSemanales = int.Parse(txtHsSemanales.Text);
                    Entity.HSTotales = int.Parse(txtHsTotales.Text);
                    Entity.IDPlan = int.Parse(ddlPlan.SelectedValue);
                    Entity.Descripcion = txtDescripcion.Text;
                    break;
                case FormModes.Modificacion:
                    Entity = new Materia();
                    Entity.State = BusinessEntity.States.Modified;
                    Entity.ID = int.Parse(txtId.Text);
                    Entity.HSSemanales = int.Parse(txtHsSemanales.Text);
                    Entity.HSTotales = int.Parse(txtHsTotales.Text);
                    Entity.IDPlan = int.Parse(ddlPlan.SelectedValue);
                    Entity.Descripcion = txtDescripcion.Text;
                    break;                
                default:
                    break;
            }            
        }

        private void SaveEntity(Materia materia)
        {
            try
            {
                Logic.Save(materia);
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
            txtHsSemanales.Enabled = enable;
            txtHsTotales.Enabled = enable;
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
            txtDescripcion.Text = string.Empty;
            txtId.Text = string.Empty;
            ddlPlan.ClearSelection();
            txtHsTotales.Text = string.Empty;
            txtHsSemanales.Text = string.Empty;
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
                DeleteEntity(SelectedID);
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
            if (string.IsNullOrEmpty(txtDescripcion.Text) || 
                string.IsNullOrEmpty(txtHsSemanales.Text) ||
                string.IsNullOrEmpty(txtHsTotales.Text))
            {
                lblError.Text = "Debe llenar todos los campos";
                return false;
            }

            int num;

            if (!(int.TryParse(txtHsSemanales.Text,out num)) || !(int.TryParse(txtHsTotales.Text, out num)))
            {
                lblError.Text = "Horas debe ser un numero entero";
                return false;
            }

            return true;
        }        

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridMaterias.SelectedValue;
        }        

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text != null)
                {
                    PlanLogic pl = new PlanLogic();
                    PlanActual = pl.GetOne(int.Parse(e.Row.Cells[4].Text));
                    e.Row.Cells[4].Text = PlanActual.Descripcion;
                }
            }
        }
    }
}