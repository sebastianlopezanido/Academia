using BusinessEntities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Cursado : ApplicationForm
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Alumno")
            {
                Response.Redirect("http://localhost:57900/Home.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private Curso _CursoActual;
        public Curso CursoActual
        {
            set { _CursoActual = value; }
            get { return _CursoActual; }
        }

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            set { _MateriaActual = value; }
            get { return _MateriaActual; }
        }

        private Comision _ComisionActual;
        public Comision ComisionActual
        {
            set { _ComisionActual = value; }
            get { return _ComisionActual; }
        }

        InscripcionLogic _logic;
        private InscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new InscripcionLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            gridInscripciones.DataSource = Logic.GetAll((int)Session["id"]);
            gridInscripciones.DataBind();

            if (gridInscripciones.Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "No esta inscripto a ningun curso";
            }
        }       

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CursoLogic cl = new CursoLogic();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text != null)
                {
                    int id = int.Parse(e.Row.Cells[0].Text);
                    CursoActual = cl.GetOne(id);
                    MateriaLogic ml = new MateriaLogic();
                    MateriaActual = ml.GetOne(CursoActual.IDMateria);
                    e.Row.Cells[0].Text = MateriaActual.Descripcion; 
                }
                if(e.Row.Cells[1].Text != null)
                {

                    int id = int.Parse(e.Row.Cells[1].Text);
                    CursoActual = cl.GetOne(id);
                    ComisionLogic cml = new ComisionLogic();
                    ComisionActual = cml.GetOne(CursoActual.IDComision);
                    e.Row.Cells[1].Text = ComisionActual.Descripcion;
                }
            }

        }
    }
}