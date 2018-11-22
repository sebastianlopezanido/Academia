﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntities;
using BusinessLogic;

namespace UI.Web
{
    public partial class Usuarios : ApplicationForm
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

        private Persona _PersonaActual;
        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        private Usuario _Entity;
        public Usuario Entity
        {
            set { _Entity = value; }
            get { return _Entity; }
        }

        private void LoadGrid()
        {
            gridUsuarios.DataSource = Logic.GetAll();
            gridUsuarios.DataBind();
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtUsuario.Text = Entity.NombreUsuario;            
            txtIdPersona.Text = Entity.IDPersona.ToString();
            txtClave.Text = Entity.Clave;
            txtConfirmarClave.Text = Entity.Clave;
            txtId.Text = Entity.ID.ToString();
            ddlTipo.SelectedIndex = (int)Entity.Tipo ;
            ddlPlan.SelectedValue = Entity.IDPlan.ToString();
        }

        private void LoadEntity()
        {
            switch (FormMode)
            {
                case FormModes.Alta:
                    Entity = new Usuario();
                    Entity.State = BusinessEntity.States.New;
                    Entity.IDPersona = int.Parse(txtIdPersona.Text);
                    Entity.NombreUsuario = txtUsuario.Text;
                    Entity.Clave = txtClave.Text;
                    Entity.IDPlan = int.Parse(ddlPlan.SelectedValue);
                    Entity.Tipo = (Usuario.TiposUsuario)int.Parse(ddlTipo.SelectedValue);
                    Entity.Habilitado = ckbHabilitado.Checked;
                    break;
                case FormModes.Modificacion:
                    Entity = new Usuario();
                    Entity.State = BusinessEntity.States.Modified;
                    Entity.ID = int.Parse(txtId.Text);
                    Entity.IDPersona = int.Parse(txtIdPersona.Text);
                    Entity.NombreUsuario = txtUsuario.Text;
                    Entity.Clave = txtClave.Text;
                    Entity.IDPlan = int.Parse(ddlPlan.SelectedValue);
                    Entity.Tipo = (Usuario.TiposUsuario)int.Parse(ddlTipo.SelectedValue);
                    Entity.Habilitado = ckbHabilitado.Checked;
                    break;
                default:
                    break;
            }
        }

        private void SaveEntity(Usuario usuario)
        {
            try
            {
                Logic.Save(usuario);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void EnableForm(bool enable)
        {
            txtClave.Enabled = enable;
            txtConfirmarClave.Enabled = enable;
            txtId.Enabled = enable;
            txtIdPersona.Enabled = enable;            
            txtUsuario.Enabled = enable;
            ckbHabilitado.Enabled = enable;
            ddlTipo.Enabled = enable;
            ddlPlan.Enabled = enable;
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
            txtClave.Text = string.Empty;
            txtConfirmarClave.Text = string.Empty;
            txtId.Text = string.Empty;
            txtIdPersona.Text = string.Empty;            
            txtUsuario.Text = string.Empty;
            ckbHabilitado.Checked = false;
            ddlPlan.ClearSelection();
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
            if (string.IsNullOrEmpty(txtClave.Text) ||
                string.IsNullOrEmpty(txtConfirmarClave.Text) ||
                string.IsNullOrEmpty(txtIdPersona.Text) ||
                string.IsNullOrEmpty(txtUsuario.Text))
            {
                lblError.Text = "Debe llenar todos los campos";
                return false;
            }

            if (txtClave.Text != txtConfirmarClave.Text)
            {
                lblError.Text = "Las claves deben coincidir";
                return false;
            }

            if (txtClave.Text.Length < 8)
            {
                lblError.Text = "La clave debe ser mayor a 8 caracteres";
                return false;
            }

            return true;
        }
        
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridUsuarios.SelectedValue;
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text != null)
                {
                    PersonaLogic pl = new PersonaLogic();
                    PersonaActual = pl.GetOne(int.Parse(e.Row.Cells[3].Text));
                    e.Row.Cells[3].Text = PersonaActual.Legajo.ToString();
                }
            }
        }
    }
}