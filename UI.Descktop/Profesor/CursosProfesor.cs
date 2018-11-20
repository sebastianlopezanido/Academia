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

namespace UI.Desktop.Profesor
{
    public partial class CursosProfesor : Form
    {
        public CursosProfesor()
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

        public void Listar()
        {
            try
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                dgvCursos.DataSource = dcl.GetAll(LoginSession.ID);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows != null && dgvCursos.MultiSelect == false && dgvCursos.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                CursoAlumnos ca = new CursoAlumnos(((DocenteCurso)dgvCursos.SelectedRows[0].DataBoundItem).IDCurso);
                ca.ShowDialog();
            }
        }

        private void dgvCursos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne((int)e.Value);

            if (dgvCursos.Columns[e.ColumnIndex].Name == "materia")
            {
                if (e.Value != null)
                {
                    MateriaLogic ml = new MateriaLogic();
                    MateriaActual = ml.GetOne(CursoActual.IDMateria);
                    e.Value = MateriaActual.Descripcion;
                }
            }            

            if (dgvCursos.Columns[e.ColumnIndex].Name == "comision")
            {
                if (e.Value != null)
                {
                    ComisionLogic ml = new ComisionLogic();
                    ComisionActual = ml.GetOne(CursoActual.IDComision);
                    e.Value = ComisionActual.Descripcion;
                }
            }

            if (dgvCursos.Columns[e.ColumnIndex].Name == "año")
            {
                if (e.Value != null)
                {
                    e.Value = CursoActual.AnioCalendario;
                }
            }
        }

        private void CursosProfesor_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
