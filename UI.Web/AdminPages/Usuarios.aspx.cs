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
    public partial class Usuarios : Page
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

        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private Usuario Entity
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
            txtUsuario.Text = Entity.NombreUsuario;
            txtIdPlan.Text = Entity.IDPlan.ToString();
            txtIdPersona.Text = Entity.IDPersona.ToString();
            txtClave.Text = Entity.Clave;
            txtConfirmarClave.Text = Entity.Clave;
            txtId.Text = Entity.ID.ToString();
            ddlTipo.SelectedIndex = (int) Entity.Tipo ;
        }

        private void LoadEntity(Usuario usuario)
        {
            if (FormMode == FormModes.Modificacion) usuario.ID = int.Parse(txtId.Text);
            usuario.IDPersona = int.Parse(txtIdPersona.Text);
            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Clave = txtClave.Text;
            usuario.IDPlan = int.Parse(txtIdPlan.Text);
            usuario.Tipo = (Usuario.TiposUsuario)int.Parse(ddlTipo.SelectedValue); // corregir
            usuario.Habilitado = ckbHabilitado.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        private void EnableForm(bool enable)
        {
            txtClave.Enabled = enable;
            txtConfirmarClave.Enabled = enable;
            txtId.Enabled = enable;
            txtIdPersona.Enabled = enable;
            txtIdPlan.Enabled = enable;
            txtUsuario.Enabled = enable;
            ckbHabilitado.Enabled = enable;
            ddlTipo.Enabled = enable;

        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        private void ClearForm()
        {
            txtClave.Text = string.Empty;
            txtConfirmarClave.Text = string.Empty;
            txtId.Text = string.Empty;
            txtIdPersona.Text = string.Empty;
            txtIdPlan.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            ckbHabilitado.Checked = false;
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
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                lblError.Text = "*Campos incompletos";
                return false;
            }
            return true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Usuario();
                    Entity.State = BusinessEntity.States.New;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Modificacion:
                    Entity = new Usuario();
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