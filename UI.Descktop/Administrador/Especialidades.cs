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
            CenterToScreen();
        }

        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
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
            EspecialidadesDesktop ed = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            ed.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows != null && dgvEspecialidades.MultiSelect == false && dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadesDesktop ud = new EspecialidadesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                Listar();
            }            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows != null && dgvEspecialidades.MultiSelect == false && dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadLogic el = new EspecialidadLogic(); //controlador :)
                EspecialidadActual = el.GetOne(ID);
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar la especialidad?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    el.Save(EspecialidadActual);
                }

                Listar();
            }
        }
    }
}
