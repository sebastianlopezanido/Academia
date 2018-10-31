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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop pd = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows != null && dgvPlanes.MultiSelect == false && dgvPlanes.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop pd = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                Listar();
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows != null && dgvPlanes.MultiSelect == false && dgvPlanes.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop ud = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
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
