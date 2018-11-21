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
    public partial class CursoAlumnos : Form
    {
        public CursoAlumnos()
        {
            InitializeComponent();
            dgvAlumnos.AutoGenerateColumns = false;
            CenterToScreen();
        }

        public CursoAlumnos(int idCur) : this()
        {
            IDCurso = idCur;
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

        private int _IDCurso;
        public int IDCurso
        {
            set { _IDCurso = value; }
            get { return _IDCurso; }
        }

        public void Listar()
        {
            try
            {
                InscripcionLogic il = new InscripcionLogic();
                dgvAlumnos.DataSource = il.GetAllByCurso(IDCurso);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows != null && dgvAlumnos.MultiSelect == false && dgvAlumnos.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                CursoAlumnoDesktop cad = new CursoAlumnoDesktop(((AlumnoInscripcion)dgvAlumnos.SelectedRows[0].DataBoundItem).IDAlumno, ((AlumnoInscripcion)dgvAlumnos.SelectedRows[0].DataBoundItem).ID);
                cad.ShowDialog();
            }

            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CursoAlumnos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dgvAlumnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            PersonaLogic pl = new PersonaLogic();

            if (dgvAlumnos.Columns[e.ColumnIndex].Name == "Nombre")
            {
                if (e.Value != null)
                {
                    UsuarioActual = ul.GetOne((int)e.Value);
                    PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
                    e.Value = PersonaActual.Nombre;
                }
            }

            if (dgvAlumnos.Columns[e.ColumnIndex].Name == "legajo")
            {
                if (e.Value != null)
                {
                    UsuarioActual = ul.GetOne((int)e.Value);
                    PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
                    e.Value = PersonaActual.Legajo;
                }
            }

            if (dgvAlumnos.Columns[e.ColumnIndex].Name == "apellido")
            {
                if (e.Value != null)
                {
                    UsuarioActual = ul.GetOne((int)e.Value);
                    PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
                    e.Value = PersonaActual.Apellido;
                }
            }
        }
    }
}
