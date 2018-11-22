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
    public partial class Comisiones : ApplicationForm
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
                PlanLogic pl = new PlanLogic();
                cbxPlan.DataSource = pl.GetAll();
                cbxPlan.DataValueField = "ID";
                cbxPlan.DataTextField = "Descripcion";
                cbxPlan.DataBind();
            }
        }

        ComisionLogic _logic;
        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        private Comision _Entity;
        public Comision Entity
        {
            set { _Entity = value; }
            get { return _Entity; }
        }

        private void LoadGrid()
        {
            gridComisiones.DataSource = Logic.GetAll();
            gridComisiones.DataBind();
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtID.Text = Entity.ID.ToString();
            txtDescripcion.Text = Entity.Descripcion;
            txtAño.Text = Entity.AnioEspecialidad.ToString();
            cbxPlan.SelectedValue = Entity.IDPlan.ToString();
        }

        private void LoadEntity()
        {
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Comision();
                    Entity.State = BusinessEntity.States.New;
                    Entity.Descripcion = txtDescripcion.Text;
                    Entity.AnioEspecialidad = int.Parse(txtAño.Text);
                    Entity.IDPlan = int.Parse(cbxPlan.SelectedValue);                    
                    break;
                case FormModes.Modificacion:
                    Entity = new Comision();
                    Entity.ID = int.Parse(txtID.Text);
                    Entity.State = BusinessEntity.States.Modified;
                    Entity.Descripcion = txtDescripcion.Text;
                    Entity.AnioEspecialidad = int.Parse(txtAño.Text);
                    Entity.IDPlan = int.Parse(cbxPlan.SelectedValue);                    
                    break;                
                default:
                    break;
            }            
        }

        private void SaveEntity(Comision comision)
        {
            try
            {
                Logic.Save(comision);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void EnableForm(bool enable)
        {
            txtID.Enabled = enable;
            txtDescripcion.Enabled = enable;
            txtAño.Enabled = enable;
            cbxPlan.Enabled = enable;
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
            txtID.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtAño.Text = string.Empty;
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

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtAño.Text) || cbxPlan.SelectedValue == null || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtAño.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Debe llenar todos los campos";
                return false;
            }

            if (txtAño.Text.Length != 4)
            {
                lblError.Visible = true;
                lblError.Text = "Ingrese correctamente el año";
                return false;
            }

            return true;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridComisiones.SelectedValue;
        }        

        protected void gridComisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text != null)
                {
                    PlanLogic pl = new PlanLogic();
                    PlanActual = pl.GetOne(int.Parse(e.Row.Cells[2].Text));
                    e.Row.Cells[2].Text = PlanActual.Descripcion;
                }
            }
        }
    }
}