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
    public partial class FindProfesor : Page
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
        }

        private Persona _PersonaActual;
        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        private void LoadGrid()
        {
            UsuarioLogic ul = new UsuarioLogic();
            gridProfesores.DataSource = ul.GetAllDocentes();
            gridProfesores.DataBind();

            if (gridProfesores.Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "No hay profesores para mostrar";
            }
        }

        protected void gridProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/Cursos.aspx?IDProfesor=" + gridProfesores.SelectedRow.Cells[0].Text + "&IDCurso="
                        + Request.QueryString["IDCurso"] + "&Cupo=" + Request.QueryString["Cupo"] + "&Año=" + Request.QueryString["Año"] + "&IDComision="
                        + Request.QueryString["IDComision"] + "&IDMateria=" + Request.QueryString["IDMateria"]);
        }

        protected void gridProfesores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PersonaLogic pl = new PersonaLogic();

                if (e.Row.Cells[1].Text != null)
                {
                    PersonaActual = pl.GetOne(int.Parse(e.Row.Cells[1].Text));
                    e.Row.Cells[1].Text = PersonaActual.Apellido;
                }

                if (e.Row.Cells[2].Text != null)
                {
                    PersonaActual = pl.GetOne(int.Parse(e.Row.Cells[2].Text));
                    e.Row.Cells[2].Text = PersonaActual.Nombre;
                }

                if (e.Row.Cells[3].Text != null)
                {
                    PersonaActual = pl.GetOne(int.Parse(e.Row.Cells[3].Text));
                    e.Row.Cells[3].Text = PersonaActual.Legajo.ToString();
                }
            }
        }
    }
}