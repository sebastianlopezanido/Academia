using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessEntities;

namespace UI.Web
{
    public partial class CursosProfesor : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() != "Profesor")
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
        
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }

        protected int SelectedID
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

        protected int SelectedIDInscripcion
        {
            get
            {
                if (ViewState["SelectedIDInscripcion"] != null)
                {
                    return (int)ViewState["SelectedIDInscripcion"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedIDInscripcion"] = value;
            }
        }

        protected int SelectedIDAlumno
        {
            get
            {
                if (ViewState["SelectedIDAlumno"] != null)
                {
                    return (int)ViewState["SelectedIDAlumno"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedIDAlumno"] = value;
            }
        }


        private Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
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

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        private Persona _PersonaActual;
        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        private AlumnoInscripcion _AlumnoInscripcion;
        public AlumnoInscripcion AlumnoInscripcionActual
        {
            get { return _AlumnoInscripcion; }
            set { _AlumnoInscripcion = value; }
        }

        protected bool IsEntitySelected
        {
            get
            {
                return SelectedID != 0;
            }
        }
    

        private void LoadGrid()
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                gridCursos.DataSource = dcl.GetAll((int)Session["id"]);
                gridCursos.DataBind();


            }

        private void LoadGridAlumnos()
                {
                    InscripcionLogic il = new InscripcionLogic();
                    GridAlumnos.DataSource = il.GetAllByCurso(SelectedID);
                    GridAlumnos.DataBind();
                }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                gridCursos.Visible = false;
                GridAlumnos.Visible= true;                
                btnSalir.Visible = true;
                LoadGridAlumnos();
            }
        }



        

        private void LoadForm(int id)
        {
            PersonaLogic pl = new PersonaLogic();
            UsuarioLogic ul = new UsuarioLogic();
            InscripcionLogic il = new InscripcionLogic();
            UsuarioActual = ul.GetOne(id);
            PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
            AlumnoInscripcionActual = il.GetOne(SelectedIDInscripcion);

            txtApellido.Text = PersonaActual.Apellido;
            txtNombre.Text = PersonaActual.Nombre;
            txtNota.Text = AlumnoInscripcionActual.Nota.ToString();
            ddlCondicion.SelectedIndex = (int)AlumnoInscripcionActual.Condicion;
            
        }

        private void LoadEntity()
        {            
            AlumnoInscripcionActual = new AlumnoInscripcion();
            AlumnoInscripcionActual.Nota = int.Parse(txtNota.Text);
            AlumnoInscripcionActual.Condicion = (AlumnoInscripcion.TiposCondiciones)ddlCondicion.SelectedIndex;
            AlumnoInscripcionActual.ID = SelectedIDInscripcion;
            AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
        }

        private void SaveEntity(AlumnoInscripcion alumnoInscripcion )
        {
            InscripcionLogic il = new InscripcionLogic();
            il.Save(alumnoInscripcion);
        }
                       

        //private void ClearForm()
        //{
        //    txtID.Text = string.Empty;
        //    txtMateria.Text = string.Empty;
        //    txtAño.Text = string.Empty;
        //    txtCupo.Text = string.Empty;
        //}   



        

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (Validar())
            //{
                LoadEntity();
                SaveEntity(AlumnoInscripcionActual);
                LoadGridAlumnos();
                formPanel.Visible = false;
            //}
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LoadGridAlumnos();
            formPanel.Visible = false;
        }

        protected void gridCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridCursos.SelectedValue;

            if (IsEntitySelected)
            {
                gridCursos.Visible = false;
                GridAlumnos.Visible = true;
                btnSalir.Visible = true;
                LoadGridAlumnos();
            }
        }

        protected void gridAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            InscripcionLogic il = new InscripcionLogic();
            int aux = (int)GridAlumnos.SelectedValue;
            AlumnoInscripcionActual = il.GetOne(aux);
            SelectedIDAlumno = AlumnoInscripcionActual.IDAlumno;
            SelectedIDInscripcion = (int)GridAlumnos.SelectedValue;

            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedIDAlumno);

            }
        }

        

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            gridCursos.Visible = true;
            GridAlumnos.Visible = false;
            btnSalir.Visible = false;
            formPanel.Visible = false;
            LoadGrid();
        }

     
        

        protected void gridCursos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CursoLogic cl = new CursoLogic();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text != null)
                {
                    int id = int.Parse(e.Row.Cells[1].Text);
                    CursoActual = cl.GetOne(id);
                    MateriaLogic ml = new MateriaLogic();
                    MateriaActual = ml.GetOne(CursoActual.IDMateria);
                    e.Row.Cells[1].Text = MateriaActual.Descripcion;
                }

                if (e.Row.Cells[2].Text != null)
                {
                    int id = int.Parse(e.Row.Cells[2].Text);
                    CursoActual = cl.GetOne(id);
                    ComisionLogic cml = new ComisionLogic();
                    ComisionActual = cml.GetOne(CursoActual.IDComision);
                    e.Row.Cells[2].Text = ComisionActual.Descripcion;
                }

                if (e.Row.Cells[3].Text != null)
                {
                    int id = int.Parse(e.Row.Cells[3].Text);
                    e.Row.Cells[3].Text = CursoActual.AnioCalendario.ToString();
                }
            }
        }

        protected void GridAlumnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            PersonaLogic pl = new PersonaLogic();
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text != null)
                {
                    int id = int.Parse(e.Row.Cells[1].Text);
                    UsuarioActual = ul.GetOne(id);
                    PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
                    e.Row.Cells[1].Text = PersonaActual.Legajo.ToString();
                    e.Row.Cells[2].Text = PersonaActual.Nombre.ToString();
                    e.Row.Cells[3].Text = PersonaActual.Apellido.ToString();
                }
                
            }


        }

        

        //public bool Validar()
        //{
        //    if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtMateria.Text) || cbxComision.SelectedValue == null || string.IsNullOrEmpty(txtCupo.Text))
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = "Debe llenar todos los campos";
        //        return false;
        //    }

        //    if (txtAño.Text.Length != 4)
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = "Ingrese correctamente el año";
        //        return false;
        //    }

        //    if (Logic.EstaAgregado(int.Parse(txtMateria.Text), int.Parse(cbxComision.SelectedValue), int.Parse(txtAño.Text)))
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = "Ya existe ese curso en esa comision";
        //        return false;
        //    }

        //    return true;
        //}
    }
}