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

    public partial class Cursos : ApplicationForm
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
                ComisionLogic cl = new ComisionLogic();
                cbxComision.DataSource = cl.GetAll();
                cbxComision.DataValueField = "ID";
                cbxComision.DataTextField = "Descripcion";
                cbxComision.DataBind();
                                
                if (!string.IsNullOrEmpty(Request.QueryString["IDCurso"]))
                {
                    SelectedID = int.Parse(Request.QueryString["IDCurso"]);
                    txtID.Text = Request.QueryString["IDCurso"];
                }

                if (!string.IsNullOrEmpty(Request.QueryString["IDMateria"]))
                {
                    MateriaLogic ml = new MateriaLogic();
                    FindMateriaActual = ml.GetOne(int.Parse(Request.QueryString["IDMateria"]));
                    txtMateria_Desc.Text = FindMateriaActual.Descripcion;
                    txtMateria.Text = Request.QueryString["IDMateria"];
                    formPanel.Visible = true;
                    EnableForm(true);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["IDProfesor"]))
                {
                    UsuarioLogic ul = new UsuarioLogic();
                    FindProfesorActual = ul.GetOne(int.Parse(Request.QueryString["IDProfesor"]));
                    PersonaLogic pl = new PersonaLogic();
                    ProfesorActual = pl.GetOne(FindProfesorActual.IDPersona);
                    txtProfesor_Desc.Text = ProfesorActual.Apellido;
                    txtProfesor.Text = Request.QueryString["IDProfesor"];
                    formPanel.Visible = true;
                    EnableForm(true);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Cupo"]))
                {
                    txtCupo.Text = Request.QueryString["Cupo"].ToString();
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Año"]))
                {
                    txtAño.Text = Request.QueryString["Año"].ToString();
                }

                if (!string.IsNullOrEmpty(Request.QueryString["IDComision"]))
                {
                    cbxComision.SelectedValue = Request.QueryString["IDComision"].ToString();
                }         
                                              
                ReportViewer1.ShowReportBody = false;
            }            
        }

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        private Usuario _FindProfesorActual;
        public Usuario FindProfesorActual
        {
            get { return _FindProfesorActual; }
            set { _FindProfesorActual = value; }
        }

        private Materia _FindMateriaActual;
        public Materia FindMateriaActual
        {
            get { return _FindMateriaActual; }
            set { _FindMateriaActual = value; }
        }

        private Comision _ComisionActual;
        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        private DocenteCurso _DocenteCursoActual;
        public DocenteCurso DocenteCursoActual
        {
            get { return _DocenteCursoActual; }
            set { _DocenteCursoActual = value; }
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

        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        private Curso _Entity;
        public Curso Entity
        {
            set { _Entity = value; }
            get { return _Entity; }
        }

        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        private Persona _ProfesorActual;
        public Persona ProfesorActual
        {
            get { return _ProfesorActual; }
            set { _ProfesorActual = value; }
        }

        private void LoadGrid()
        {
            gridCursos.DataSource = Logic.GetAll();
            gridCursos.DataBind();
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtID.Text = Entity.ID.ToString();
            cbxComision.SelectedValue = Entity.IDComision.ToString();
            txtAño.Text = Entity.AnioCalendario.ToString();
            txtCupo.Text = Entity.Cupo.ToString();

            MateriaLogic ml = new MateriaLogic();
            FindMateriaActual = ml.GetOne(Entity.IDMateria);
            txtMateria_Desc.Text = FindMateriaActual.Descripcion;
            txtMateria.Text = Entity.IDMateria.ToString();

            DocenteCursoLogic dc = new DocenteCursoLogic();
            DocenteCursoActual = dc.GetOneByCurso(SelectedID);
            txtProfesor.Text = DocenteCursoActual.IDDocente.ToString();
            UsuarioLogic ul = new UsuarioLogic();
            FindProfesorActual = ul.GetOne(DocenteCursoActual.IDDocente);
            PersonaLogic pl = new PersonaLogic();
            ProfesorActual = pl.GetOne(FindProfesorActual.IDPersona);
            txtProfesor_Desc.Text = ProfesorActual.Apellido;
        }

        private void LoadEntity()
        {
            switch (Session["FormMode"])
            {
                case FormModes.Alta:
                    Entity = new Curso();
                    Entity.State = BusinessEntity.States.New;
                    Entity.IDComision = int.Parse(cbxComision.SelectedValue);
                    Entity.AnioCalendario = int.Parse(txtAño.Text);
                    Entity.IDMateria = int.Parse(txtMateria.Text);
                    Entity.Cupo = int.Parse(txtCupo.Text);
                    break;
                case FormModes.Modificacion:
                    Entity = new Curso();
                    Entity.ID = int.Parse(txtID.Text);
                    Entity.State = BusinessEntity.States.Modified;
                    Entity.IDComision = int.Parse(cbxComision.SelectedValue);
                    Entity.AnioCalendario = int.Parse(txtAño.Text);
                    Entity.IDMateria = int.Parse(txtMateria.Text);
                    Entity.Cupo = int.Parse(txtCupo.Text);
                    break;
                default:
                    break;
            }
        }

        private void SaveEntity(Curso curso)
        {
            try
            {
                Logic.Save(curso);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void EnableForm(bool enable)
        {
            txtID.Enabled = enable;
            txtMateria_Desc.Enabled = enable;
            txtAño.Enabled = enable;
            txtCupo.Enabled = enable;
            txtProfesor_Desc.Enabled = enable;
            btnMateria.Enabled = enable;
            cbxComision.Enabled = enable;            
        }

        public void MapearADatosDocenteCurso()
        {
            switch (Session["FormMode"])
            {
                case FormModes.Alta:
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.IDDocente = int.Parse(txtProfesor.Text);
                    DocenteCursoActual.IDCurso = IDCurso;
                    //DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)cbxCargo.SelectedItem;
                    DocenteCursoActual.State = BusinessEntity.States.New;
                    break;
                case FormModes.Modificacion:
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.IDCurso = SelectedID;
                    DocenteCursoActual.IDDocente = int.Parse(txtProfesor.Text);
                    //DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)cbxCargo.SelectedItem;
                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public void GuardarCambiosDocenteCurso()
        {
            MapearADatosDocenteCurso();
            DocenteCursoLogic dc = new DocenteCursoLogic();
            dc.Save(DocenteCursoActual);
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
            txtID.Text = string.Empty;
            txtMateria_Desc.Text = string.Empty;
            txtAño.Text = string.Empty;
            txtCupo.Text = string.Empty;
            txtProfesor_Desc.Text = string.Empty;
            txtMateria.Text = string.Empty;
            txtProfesor.Text = string.Empty;
            cbxComision.SelectedValue = null;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            Session["FormMode"] = FormModes.Alta;
            ClearForm();            
            EnableForm(true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                Session["FormMode"] = FormModes.Modificacion;
                
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

                switch (Session["FormMode"])
                {
                    case FormModes.Alta:
                        IDCurso = Logic.Insert(Entity);
                        GuardarCambiosDocenteCurso();
                        break;
                    case FormModes.Modificacion:
                        Logic.Save(Entity);
                        GuardarCambiosDocenteCurso();
                        break;
                }
                
                LoadGrid();
                formPanel.Visible = false;
            }            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LoadGrid();
            formPanel.Visible = false;
        }        

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtAño.Text) ||
                string.IsNullOrEmpty(txtMateria.Text) ||
                cbxComision.SelectedValue == null ||
                string.IsNullOrEmpty(txtCupo.Text) ||
                string.IsNullOrEmpty(txtProfesor.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Debe llenar todos los campos";
                return false;
            }

            int num;
            if (txtAño.Text.Length != 4 ||
                !int.TryParse(txtAño.Text, out num ) ||
                int.Parse(txtAño.Text) < 2000 ||
                int.Parse(txtAño.Text) > 2100)
            {
                lblError.Visible = true;
                lblError.Text = "Ingrese correctamente el año";
                return false;
            }

            if (!(int.TryParse(txtCupo.Text, out num)) ||
                int.Parse(txtCupo.Text)<1 ||
                int.Parse(txtCupo.Text) >100)
            {
                lblError.Visible = true;
                lblError.Text = "Ingrese correctamente el cupo (1-100)";

                return false;
            }

            Curso curso = Logic.GetOne(SelectedID);

            if ((((FormModes)Session["FormMode"] == FormModes.Modificacion &&
                (curso.AnioCalendario != int.Parse(txtAño.Text) ||
                curso.IDComision != int.Parse(cbxComision.SelectedValue) ||
                curso.IDMateria != int.Parse(txtMateria.Text)) ) || (FormModes)Session["FormMode"] == FormModes.Alta) &&

                Logic.EstaAgregado(int.Parse(txtMateria.Text), int.Parse(cbxComision.SelectedValue), int.Parse(txtAño.Text)))
            {
                lblError.Visible = true;
                lblError.Text = "Ya existe ese curso en esa comision";
                return false;
            }
            lblError.Text = "";
            return true;
        }

        protected void gridCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridCursos.SelectedValue;            
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

                if (e.Row.Cells[5].Text != null)
                {
                    DocenteCursoLogic ml = new DocenteCursoLogic();
                    DocenteCursoActual = ml.GetOneByCurso(int.Parse(e.Row.Cells[5].Text));
                    UsuarioLogic ul = new UsuarioLogic();
                    UsuarioActual = ul.GetOne(DocenteCursoActual.IDDocente);
                    PersonaLogic pl = new PersonaLogic();
                    PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
                    e.Row.Cells[5].Text = PersonaActual.Apellido;
                }
            }
        }

        protected void btnMateria_Click(object sender, EventArgs e)
        {
            switch(Session["FormMode"])
            {
                case FormModes.Alta:                    
                    Response.Redirect("~/FindPages/FindMateria.aspx?Cupo=" + txtCupo.Text + "&Año=" +
                        txtAño.Text + "&IDComision=" + cbxComision.SelectedValue + "&IDProfesor=" + txtProfesor.Text + "&IDProfesor_Desc=" + txtProfesor_Desc.Text);
                    break;
                case FormModes.Modificacion:                    
                    Response.Redirect("~/FindPages/FindMateria.aspx?IDCurso=" + SelectedID.ToString()
                + "&Cupo=" + txtCupo.Text + "&Año=" + txtAño.Text + "&IDComision=" + cbxComision.SelectedValue + "&IDProfesor=" + txtProfesor.Text + "&IDProfesor_Desc=" + txtProfesor_Desc.Text);
                    break;
            }
            
        }

        protected void btnProfesor_Click(object sender, EventArgs e)
        {            
            switch (Session["FormMode"])
            {
                case FormModes.Alta:
                    Response.Redirect("~/FindPages/FindProfesor.aspx?Cupo=" + txtCupo.Text + "&Año=" +
                        txtAño.Text + "&IDComision=" + cbxComision.SelectedValue + "&IDMateria=" + txtMateria.Text + "&IDMateria_Desc=" + txtMateria_Desc.Text);
                    break;
                case FormModes.Modificacion:
                    Response.Redirect("~/FindPages/FindProfesor.aspx?IDCurso=" + SelectedID.ToString()
                + "&Cupo=" + txtCupo.Text + "&Año=" + txtAño.Text + "&IDComision=" + cbxComision.SelectedValue + "&IDMateria=" + txtMateria.Text + "&IDMateria_Desc=" + txtMateria_Desc.Text);
                    break;
            }
        }

        
        protected void btnReporte_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = false;

            List<BusinessEntities.Curso_Reporte> Datos = new List<BusinessEntities.Curso_Reporte>();
            for (int i = 0; i < gridCursos.Rows.Count; i++)
            {
                BusinessEntities.Curso_Reporte linea = new BusinessEntities.Curso_Reporte();

                linea.ID = gridCursos.Rows[i].Cells[0].Text;
                linea.Materia = gridCursos.Rows[i].Cells[1].Text;
                linea.Comision = gridCursos.Rows[i].Cells[2].Text;
                linea.Año = gridCursos.Rows[i].Cells[3].Text;
                linea.Cupo = gridCursos.Rows[i].Cells[4].Text;
                linea.Profesor = gridCursos.Rows[i].Cells[5].Text;

                Datos.Add(linea);
            }

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", Datos));
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.DataBind();
            ReportViewer1.Visible = true;
            ReportViewer1.ShowReportBody = true;
            btnVolver_Reporte.Visible = true;
        }

        protected void btnVolver_Reporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/Cursos.aspx");
        }
    }
}