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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();

                this.dgvComisiones.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop cd = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);

            cd.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows != null && this.dgvComisiones.MultiSelect == false && this.dgvComisiones.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionesDesktop pd = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                this.Listar();
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows != null && this.dgvComisiones.MultiSelect == false && this.dgvComisiones.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                //ComisionesDesktop ud = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);
                MessageBox.Show("Seguro que quiere eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);                
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
