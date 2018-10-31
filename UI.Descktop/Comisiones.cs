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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();

                dgvComisiones.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop cd = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);

            cd.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows != null && dgvComisiones.MultiSelect == false && dgvComisiones.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionesDesktop pd = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                Listar();
            }
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows != null && dgvComisiones.MultiSelect == false && dgvComisiones.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionesDesktop ud = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);
                //MessageBox.Show("¿Seguro que quiere eliminar?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);                
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
