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
using BusinessLogic;

namespace UI.Desktop
{
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                PersonasLogic pl = new PersonasLogic();
                this.dgvPersonas.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            PersonasDesktop ud = new PersonasDesktop(ApplicationForm.ModoForm.Alta);

            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows != null && this.dgvPersonas.MultiSelect == false && this.dgvPersonas.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Personas)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonasDesktop ud = new PersonasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows != null && this.dgvPersonas.MultiSelect == false && this.dgvPersonas.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Personas)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonasDesktop ud = new PersonasDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
                this.Listar();
            }
        }
        
    }
}