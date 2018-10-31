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
                CursosDesktop ud = new CursosDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
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
