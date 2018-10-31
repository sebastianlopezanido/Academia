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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {               
                MessageBox.Show(Ex.Message);
            }            
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop ud = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);            
            ud.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if(dgvUsuarios.SelectedRows != null && dgvUsuarios.MultiSelect == false && dgvUsuarios.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                Listar();
            }           
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows != null && dgvUsuarios.MultiSelect == false && dgvUsuarios.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
                Listar();
            }
        }        
    }
}
