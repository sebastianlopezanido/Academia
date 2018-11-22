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
    public partial class Inscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IDMateria = int.Parse(Request.QueryString["IDMateria"]);

            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private int _IDMateria;
        public int IDMateria
        {
            set { _IDMateria = value; }
            get { return _IDMateria; }
        }

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        private Comision _ComisionActual;
        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        private AlumnoInscripcion _InscripcionActual;
        public AlumnoInscripcion InscripcionActual
        {
            set { _InscripcionActual = value; }
            get { return _InscripcionActual; }
        }

        private void LoadGrid()
        {
            try
            {
                CursoLogic cl = new CursoLogic();
                gridCursos.DataSource = cl.GetByMateria(IDMateria);
                gridCursos.DataBind();

                if (gridCursos.Rows.Count == 0)
                {
                    lblInfo.Visible = true;
                    lblInfo.Text = "No hay cursos para mostrar";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void MapearADatos()
        {
            InscripcionActual = new AlumnoInscripcion();
            InscripcionActual.IDAlumno = (int)Session["ID"];
            InscripcionActual.IDCurso = int.Parse(gridCursos.SelectedRow.Cells[0].Text);
            InscripcionActual.State = BusinessEntity.States.New;
        }

        protected void gridCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MapearADatos();
            InscripcionLogic il = new InscripcionLogic();            
            gridCursos.Visible = false;
            lblInfo.Visible = true;
            btnSalir.Visible = true;

            try
            {
                il.Save(InscripcionActual);
            }
            catch (Exception ex)
            {
                btnSalir.Visible = false;
                gridCursos.Visible = true;
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void gridCursos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text != null)
                {
                    MateriaLogic ml = new MateriaLogic();
                    MateriaActual = ml.GetOne(int.Parse(e.Row.Cells[1].Text));
                    e.Row.Cells[1].Text = MateriaActual.Descripcion;
                }
                if (e.Row.Cells[2].Text != null)
                {
                    ComisionLogic cl = new ComisionLogic();
                    ComisionActual = cl.GetOne(int.Parse(e.Row.Cells[2].Text));
                    e.Row.Cells[2].Text = ComisionActual.Descripcion;
                }
            }
        }
    }
}