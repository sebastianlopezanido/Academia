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
    public partial class Usuarios : ApplicationForm
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click_1(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                this.dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {               
                MessageBox.Show(Ex.Message);
            }
            
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            UsuarioDesktop ud = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            
            ud.ShowDialog();
            this.Listar();


        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if(this.dgvUsuarios.SelectedRows != null && this.dgvUsuarios.MultiSelect == false && this.dgvUsuarios.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                this.Listar();

            }           


        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows != null && this.dgvUsuarios.MultiSelect == false && this.dgvUsuarios.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
                this.Listar();

            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
