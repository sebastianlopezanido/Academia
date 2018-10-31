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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
            }

            cbxTipo.Items.Add("Alumno");
            cbxTipo.Items.Add("Profesor");
            cbxTipo.Items.Add("Administrador");
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void LoadForm (int id)
        {
            Entity = Logic.GetOne(id);
            txtUsuario.Text = Entity.NombreUsuario;
            txtIdPlan.Text = Entity.IDPlan.ToString();
            txtIdPersona.Text = Entity.IDPersona.ToString();
            txtClave.Text = Entity.Clave;
            txtConfirmarClave.Text = Entity.Clave;
            txtId.Text = Entity.ID.ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.ID = int.Parse(txtId.Text);
            usuario.IDPersona = int.Parse(txtIdPersona.Text);
            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Clave = txtClave.Text;
            usuario.IDPlan = int.Parse(txtIdPlan.Text);
            usuario.Tipo = Usuario.TiposUsuario.Alumno; // corregir
        }

        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Entity = new Usuario();
            Entity.ID = SelectedID;
            Entity.State = BusinessEntity.States.Modified;
            LoadEntity(Entity);
            SaveEntity(Entity);
            LoadGrid();
            formPanel.Visible = false;
        }
    }
}