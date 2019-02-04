using BusinessEntities;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Alumno
{
    public partial class Inscripciones : Form
    {
        public Inscripciones()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
            CenterToScreen();
        }
        
        public Inscripciones(int idMat) : this()
        {
            IDMateria = idMat;
        }

        private int _IDMateria;
        public int IDMateria
        {
            set { _IDMateria = value; }
            get { return _IDMateria; }
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

        private AlumnoInscripcion _InscripcionActual;
        public AlumnoInscripcion InscripcionActual
        {
            set { _InscripcionActual = value; }
            get { return _InscripcionActual; }
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            try
            {
                CursoLogic cl = new CursoLogic();
                dgvCursos.DataSource = cl.GetByMateria(IDMateria);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void MapearADatos()
        {
            InscripcionActual = new AlumnoInscripcion();
            InscripcionActual.IDAlumno = LoginSession.ID;
            InscripcionActual.IDCurso = ((Curso)dgvCursos.SelectedRows[0].DataBoundItem).ID;
            InscripcionActual.State = BusinessEntity.States.New;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Seguro que quiere inscribirse a este curso?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (dgvCursos.SelectedRows != null && dgvCursos.MultiSelect == false && dgvCursos.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                {
                    MapearADatos();
                    InscripcionLogic il = new InscripcionLogic();
                    try
                    {
                        il.Save(InscripcionActual);
                        MessageBox.Show("La inscripcion fue exitosa", "Inscripcion a cursado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }                    
                }
            }            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
