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
using BusinessEntities;

namespace UI.Desktop.Profesor
{
    public partial class FindProfesor : Form
    {
        public FindProfesor()
        {
            InitializeComponent();
            CenterToScreen();

            dgvProfesor.AutoGenerateColumns = false;

        }

        public delegate void pasar(Usuario docente);
        public event pasar pasado;

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
                UsuarioLogic ul = new UsuarioLogic();
                dgvProfesor.DataSource = ul.GetAllDocentes();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void FindProfesor_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProfesor.SelectedRows != null && dgvProfesor.MultiSelect == false && dgvProfesor.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                pasado((Usuario)dgvProfesor.SelectedRows[0].DataBoundItem);
            }

            Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvProfesor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();

            if (dgvProfesor.Columns[e.ColumnIndex].Name == "Apellido")
            {
                if (e.Value != null)
                {
                    PersonaActual = pl.GetOne((int)e.Value);
                    e.Value = PersonaActual.Apellido;
                }
            }
            if (dgvProfesor.Columns[e.ColumnIndex].Name == "Nombre")
            {
                if (e.Value != null)
                {
                    PersonaActual = pl.GetOne((int)e.Value);
                    e.Value = PersonaActual.Nombre;
                }
            }
            if (dgvProfesor.Columns[e.ColumnIndex].Name == "Legajo")
            {
                if (e.Value != null)
                {
                    PersonaActual = pl.GetOne((int)e.Value);
                    e.Value = PersonaActual.Legajo;
                }
            }
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (dgvProfesor.SelectedRows != null && dgvProfesor.MultiSelect == false && dgvProfesor.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                pasado(((Usuario)dgvProfesor.SelectedRows[0].DataBoundItem));
            }
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}

