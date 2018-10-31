using BusinessLogic;
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

namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            dgvEspecialidades.DataSource = el.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
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
            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            ed.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows != null && dgvEspecialidades.MultiSelect == false && dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ud = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                Listar();
            }            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows != null && dgvEspecialidades.MultiSelect == false && dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ud = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
                Listar();
            }
        }
    }
}
