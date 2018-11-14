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
        
        public Inscripciones(int id) : this()
        {
            IDMateria = id;
        }

        private int _IDMateria;
        public int IDMateria
        {
            set { _IDMateria = value; }
            get { return _IDMateria; }
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
            InscripcionActual.IDAlumno = 7;
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
                    il.Save(InscripcionActual);
                    Close();
                }
            }            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
