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

namespace UI.Desktop
{
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                this.dgvMaterias.DataSource = ml.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriasDesktop md = new MateriasDesktop(ApplicationForm.ModoForm.Alta);

            md.ShowDialog();
            this.Listar();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows != null && this.dgvMaterias.MultiSelect == false && this.dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriasDesktop md = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                md.ShowDialog();
                this.Listar();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows != null && this.dgvMaterias.MultiSelect == false && this.dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriasDesktop md = new MateriasDesktop(ID, ApplicationForm.ModoForm.Baja);
                md.ShowDialog();
                this.Listar();
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
