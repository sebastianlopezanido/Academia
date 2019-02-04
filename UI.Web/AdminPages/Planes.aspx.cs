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
    public partial class Planes : ApplicationForm
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
                EspecialidadLogic el = new EspecialidadLogic();
                try
                {
                    ddlEsp.DataSource = el.GetAll();
                    ddlEsp.DataValueField = "ID";
                    ddlEsp.DataTextField = "Descripcion";
                    ddlEsp.DataBind();
                }
                catch (Exception ex)
                {
                    lblError1.Visible = true;
                    lblError1.Text = ex.Message;
                }
            }

            lblError1.Visible = false;
            lblError.Visible = false;
        }        

        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
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

        private Plan _Entity;
        public Plan Entity
        {
            set { _Entity = value; }
            get { return _Entity; }
        }

        private void LoadGrid()
        {
            try
            {
                gridPlanes.DataSource = Logic.GetAll();
                gridPlanes.DataBind();
            }
            catch (Exception ex)
            {
                lblError1.Text = ex.Message;
                lblError1.Visible = true;
            }            
        }

        private void LoadForm(int id)
        {
            try
            {
                Entity = Logic.GetOne(id);
                txtId.Text = Entity.ID.ToString();
                txtDescripcion.Text = Entity.Descripcion.ToString();
                ddlEsp.SelectedValue = Entity.IDEspecialidad.ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }                                
        }

        private void LoadEntity()
        {
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Plan();
                    Entity.State = BusinessEntity.States.New;
                    Entity.IDEspecialidad = int.Parse(ddlEsp.SelectedValue);
                    Entity.Descripcion = txtDescripcion.Text;
                    break;
                case FormModes.Modificacion:
                    Entity = new Plan();
                    Entity.State = BusinessEntity.States.Modified;
                    Entity.ID = int.Parse(txtId.Text);
                    Entity.IDEspecialidad = int.Parse(ddlEsp.SelectedValue);
                    Entity.Descripcion = txtDescripcion.Text;
                    break;
                default:
                    break;
            }        
        }

        private void SaveEntity(Plan plan)
        {
            try
            {
                Logic.Save(plan);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
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
                lblError1.Visible = true;
            }
        }

        private void ClearForm()
        {
            txtDescripcion.Text = string.Empty;            
            txtId.Text = string.Empty;            
            ddlEsp.ClearSelection();
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
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    lblError1.Text = ex.Message;
                    lblError1.Visible = true;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                try
                {
                    LoadEntity();
                    SaveEntity(Entity);
                    LoadGrid();
                    formPanel.Visible = false;
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    lblError.Visible = true;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
                formPanel.Visible = false;
            }
            catch (Exception ex)
            {
                lblError1.Text = ex.Message;
                lblError1.Visible = true;
            }
        }
    

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblError.Text = "Debe llenar todos los campos";
                lblError.Visible = true;
                return false;
            }

            return true;
        }        

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridPlanes.SelectedValue;
            formPanel.Visible = false;
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text != null)
                {
                    EspecialidadLogic pl = new EspecialidadLogic();
                    try
                    {
                        EspecialidadActual = pl.GetOne(int.Parse(e.Row.Cells[2].Text));
                        e.Row.Cells[2].Text = EspecialidadActual.Descripcion;
                    }
                    catch (Exception ex)
                    {
                        lblError1.Text = ex.Message;
                        lblError1.Visible = true;
                    }                    
                }
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = false;
            formPanel.Visible = false;
            List<Plan_Reporte> Datos = new List<Plan_Reporte>();

            for (int i = 0; i < gridPlanes.Rows.Count; i++)
            {
                Plan_Reporte linea = new Plan_Reporte();

                linea.ID = gridPlanes.Rows[i].Cells[0].Text;
                linea.Descripcion = gridPlanes.Rows[i].Cells[1].Text;
                linea.Especialidad = gridPlanes.Rows[i].Cells[2].Text;                

                Datos.Add(linea);
            }

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", Datos));
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.DataBind();
            reportPanel.Visible = true;
            ReportViewer1.ShowReportBody = true;
            //btnVolver_Reporte.Visible = true;
        }

        protected void btnVolver_Reporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/Planes.aspx");
        }
    }
}