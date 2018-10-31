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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                dgvMaterias.DataSource = ml.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriasDesktop md = new MateriasDesktop(ApplicationForm.ModoForm.Alta);
            md.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriasDesktop md = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                md.ShowDialog();
                Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriasDesktop md = new MateriasDesktop(ID, ApplicationForm.ModoForm.Baja);
                md.ShowDialog();
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
