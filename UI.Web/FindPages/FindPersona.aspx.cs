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
    public partial class FindPersona : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() == "Profesor")
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
        }

        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            switch(Session["tipo"])
            {
             
                case Usuario.TiposUsuario.Administrador:
                    gridPersonas.DataSource = Logic.GetAll();
                   
                    break;
            }
            
            gridPersonas.DataBind();

            if (gridPersonas.Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "No hay personas para mostrar";
            }
        }

        protected void gridPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Session["tipo"])
            {
                case Usuario.TiposUsuario.Administrador:
                    Response.Redirect("~/AdminPages/Usuarios.aspx?IDPersona=" + gridPersonas.SelectedRow.Cells[0].Text + "&IDUsuario="
                        + Request.QueryString["IDUsuario"] + "&Usuario=" + Request.QueryString["Usuario"] + "&IDPlan=" + Request.QueryString["IDPlan"] + "&Clave=" + Request.QueryString["Clave"] + "&Habilitado="
                        + Request.QueryString["Habilitado"] + "&TipoUsuario=" + Request.QueryString["TipoUsuario"]);
                    break;

            }

           
        }

    }
}