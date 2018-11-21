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

namespace UI.Desktop.Alumno
{
    public partial class Cursado : Form
    {
        public Cursado()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
            CenterToScreen();
        }

        public Cursado(int idAlu) : this()
        {
            IDAlumno = idAlu;
        }

        private int _IDAlumno;
        public int IDAlumno
        {
            set { _IDAlumno = value; }
            get { return _IDAlumno; }
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

        private void Cursado_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            try
            {
                InscripcionLogic cl = new InscripcionLogic();
                dgvCursos.DataSource = cl.GetAll(IDAlumno);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCursos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CursoLogic cl = new CursoLogic();            

            if (dgvCursos.Columns[e.ColumnIndex].Name == "id_curso1")
            {
                if (e.Value != null)
                {
                    CursoActual = cl.GetOne((int)e.Value);
                    MateriaLogic ml = new MateriaLogic();
                    MateriaActual = ml.GetOne(CursoActual.IDMateria);
                    e.Value = MateriaActual.Descripcion;
                }
            }

            if (dgvCursos.Columns[e.ColumnIndex].Name == "id_curso2")
            {
                if (e.Value != null)
                {
                    CursoActual = cl.GetOne((int)e.Value);
                    ComisionLogic cml = new ComisionLogic();
                    ComisionActual = cml.GetOne(CursoActual.IDComision);
                    e.Value = ComisionActual.Descripcion;
                }
            }
        }
    }
}
