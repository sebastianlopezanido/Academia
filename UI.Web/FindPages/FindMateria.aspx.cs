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
    public partial class FindMateria : Page
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
            switch(Session["tipo"])
            {
                case Usuario.TiposUsuario.Alumno:
                    gridMaterias.DataSource = Logic.GetAllByPlan((int)Session["IDPlan"]);
                    break;
                case Usuario.TiposUsuario.Administrador:
                    gridMaterias.DataSource = Logic.GetAll();
                    break;
            }
            
            gridMaterias.DataBind();

            if (gridMaterias.Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "No hay materias para mostrar";
            }
        }

        protected void gridMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(Session["tipo"])
            {
                case Usuario.TiposUsuario.Alumno:
                    InscripcionLogic il = new InscripcionLogic();
                    if (il.EstaInscripto((int)Session["ID"],int.Parse(gridMaterias.SelectedRow.Cells[0].Text)) == false)
                    {
                        Response.Redirect("~/AlumnoPages/Inscripciones.aspx?IDMateria="+ gridMaterias.SelectedRow.Cells[0].Text);
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Ya esta inscripto a la materia";
                    }
                    break;
                case Usuario.TiposUsuario.Administrador:
                    Response.Redirect("http://localhost:57900/AdminPages/Cursos.aspx?IDMateria=" + gridMaterias.SelectedRow.Cells[0].Text + "&IDCurso=" 
                        + Request.QueryString["IDCurso"] + "&Cupo=" + Request.QueryString["Cupo"] + "&Año=" + Request.QueryString["Año"] + "&IDComision="
                        + Request.QueryString["IDComision"] + "&IDProfesor=" + Request.QueryString["IDProfesor"]);
                    break;

            }
        }

        protected void gridMaterias_RowDataBound(object sender, GridViewRowEventArgs e)
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