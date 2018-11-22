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
            }
        }

        private void LoadGrid()
        {
            gridCursos.DataSource = Logic.GetAll();
            gridCursos.DataBind();
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

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtID.Text = Entity.ID.ToString();
            cbxComision.SelectedValue = Entity.IDComision.ToString();
            txtAño.Text = Entity.AnioCalendario.ToString();
            txtCupo.Text = Entity.Cupo.ToString();
            txtMateria.Text = Entity.IDMateria.ToString();
        }

        private void LoadEntity()
        {
            switch (FormMode)
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
            txtMateria.Enabled = enable;
            txtAño.Enabled = enable;
            cbxComision.Enabled = enable;
            txtCupo.Enabled = enable;
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
            txtMateria.Text = string.Empty;
            txtAño.Text = string.Empty;
            txtCupo.Text = string.Empty;
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

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtMateria.Text) || cbxComision.SelectedValue == null || string.IsNullOrEmpty(txtCupo.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Debe llenar todos los campos";
                return false;
            }

            if (txtAño.Text.Length != 4)
            {
                lblError.Visible = true;
                lblError.Text = "Ingrese correctamente el año";
                return false;
            }            

            if (Logic.EstaAgregado(int.Parse(txtMateria.Text), int.Parse(cbxComision.SelectedValue), int.Parse(txtAño.Text)))
            {
                lblError.Visible = true;
                lblError.Text = "Ya existe ese curso en esa comision";
                return false;
            }

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
    }
}