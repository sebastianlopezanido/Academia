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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                this.dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop pd = new PlanesDesktop(ApplicationForm.ModoForm.Alta);

            pd.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows != null && this.dgvPlanes.MultiSelect == false && this.dgvPlanes.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop pd = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                this.Listar();
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows != null && this.dgvPlanes.MultiSelect == false && this.dgvPlanes.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanesDesktop ud = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
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

        private void asdToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}
