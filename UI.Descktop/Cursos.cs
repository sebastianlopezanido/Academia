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

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
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
                    CursoActual.State = BusinessEntity.States.Deleted;
                    cl.Save(CursoActual);
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
        
    }
}
