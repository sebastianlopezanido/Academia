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

namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
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
            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);

            ed.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if (this.dgvEspecialidades.SelectedRows != null && this.dgvEspecialidades.MultiSelect == false && this.dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ud = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                this.Listar();

            }


        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows != null && this.dgvEspecialidades.MultiSelect == false && this.dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((BusinessEntities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ud = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
                this.Listar();

            }
        }
    }
}
