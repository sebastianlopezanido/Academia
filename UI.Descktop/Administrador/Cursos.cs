using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessEntities;
using UI.Desktop.Administrador;

namespace UI.Desktop
{
    public partial class Cursos : ApplicationForm
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
            CenterToScreen();

        }

        private Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }

        private Comision _ComisionActual;
        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
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

        public void Listar()
        {
            try
            {
                CursoLogic cl = new CursoLogic();
                dgvCursos.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvCursos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCursos.Columns[e.ColumnIndex].Name == "id_materia")
            {
                if (e.Value != null)
                {
                    MateriaLogic ml = new MateriaLogic();
                    MateriaActual = ml.GetOne((int)e.Value);
                    e.Value = MateriaActual.Descripcion;
                }
            }

            if (dgvCursos.Columns[e.ColumnIndex].Name == "Profesor")
            {
                if (e.Value != null)
                {
                    DocenteCursoLogic ml = new DocenteCursoLogic();
                    DocenteCursoActual = ml.GetOneByCurso((int)e.Value);
                    UsuarioLogic ul = new UsuarioLogic();
                    UsuarioActual = ul.GetOne(DocenteCursoActual.IDDocente);
                    PersonaLogic pl = new PersonaLogic();
                    PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
                    e.Value = PersonaActual.Apellido;
                }
            }

            if (dgvCursos.Columns[e.ColumnIndex].Name == "id_comision")
            {
                if (e.Value != null)
                {
                    ComisionLogic ml = new ComisionLogic();
                    ComisionActual = ml.GetOne((int)e.Value);
                    e.Value = ComisionActual.Descripcion;
                }
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop cd = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            cd.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows != null && dgvCursos.MultiSelect == false && dgvCursos.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Curso)dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursosDesktop pd = new CursosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows != null && dgvCursos.MultiSelect == false && dgvCursos.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Curso)dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoLogic cl = new CursoLogic(); //controlador :)
                CursoActual = cl.GetOne(ID);
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar el curso?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        CursoActual.State = BusinessEntity.States.Deleted;
                        DocenteCursoLogic dc = new DocenteCursoLogic();
                        DocenteCursoActual = dc.GetOneByCurso(ID);
                        DocenteCursoActual.State = BusinessEntity.States.Deleted;
                        //dc.Save(DocenteCursoActual);
                        cl.Save(CursoActual);
                    }
                    catch (Exception Ex)
                    {
                        Notificar("Error", Ex.Message + ", posiblemente existan inscripciones a este curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                    
                }

                Listar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbReporte_Click(object sender, EventArgs e)
        {
            Cursos_Reporte rep = new Cursos_Reporte();
            for (int i = 0; i<dgvCursos.Rows.Count; i++ )
            {
                Curso_Reporte linea = new Curso_Reporte();

                MateriaLogic ml = new MateriaLogic();
                MateriaActual = ml.GetOne((int)dgvCursos.Rows[i].Cells[0].Value);
                linea.Materia = MateriaActual.Descripcion;

                
                ComisionLogic cl = new ComisionLogic();
                ComisionActual = cl.GetOne((int)dgvCursos.Rows[i].Cells[1].Value);
                linea.Comision = ComisionActual.Descripcion;
                
                linea.Año = dgvCursos.Rows[i].Cells[2].Value.ToString();
                linea.Cupo = dgvCursos.Rows[i].Cells[3].Value.ToString();

                DocenteCursoLogic dcl = new DocenteCursoLogic();
                DocenteCursoActual = dcl.GetOneByCurso((int)dgvCursos.Rows[i].Cells[4].Value);
                UsuarioLogic ul = new UsuarioLogic();
                UsuarioActual = ul.GetOne(DocenteCursoActual.IDDocente);
                PersonaLogic pl = new PersonaLogic();
                PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
                linea.Profesor = PersonaActual.Apellido;

                rep.Datos.Add(linea);
                
            }
            rep.ShowDialog();
        }
    }
}
