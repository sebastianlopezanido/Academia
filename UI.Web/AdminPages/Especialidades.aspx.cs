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
    public partial class Especialidades : ApplicationForm
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

            lblError1.Visible = false;
            lblError.Visible = false;
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

        private Especialidad _Entity;
        public Especialidad Entity
        {
            set { _Entity = value; }
            get { return _Entity; }
        }        

        private void LoadGrid()
        {
            try
            {
                gridEspecialidades.DataSource = Logic.GetAll();
                gridEspecialidades.DataBind();
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
                txtDescripcion.Text = Entity.Descripcion;
                txtId.Text = Entity.ID.ToString();
            }
            catch (Exception ex)
            {
                lblError1.Text = ex.Message;
                lblError1.Visible = true;
            }
        }

        private void LoadEntity()
        {
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Especialidad();
                    Entity.State = BusinessEntity.States.New;
                    Entity.Descripcion = txtDescripcion.Text;
                    break;
                case FormModes.Modificacion:
                    Entity = new Especialidad();
                    Entity.ID = int.Parse(txtId.Text);
                    Entity.Descripcion = txtDescripcion.Text;
                    Entity.State = BusinessEntity.States.Modified;                 
                    break;
                default:
                    break;
            }                
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
            txtId.Text = string.Empty;
            txtDescripcion.Text = string.Empty;           
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;

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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
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
            SelectedID = (int)gridEspecialidades.SelectedValue;
            formPanel.Visible = false;
        }      
    }
}