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
            CenterToScreen();
        }

        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
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

        private void dgvPlanes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPlanes.Columns[e.ColumnIndex].Name == "idespecialidad")
            {
                if (e.Value != null)
                {
                    EspecialidadLogic pl = new EspecialidadLogic();
                    EspecialidadActual = pl.GetOne((int)e.Value);
                    e.Value = EspecialidadActual.Descripcion;
                }
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
                PlanLogic pl = new PlanLogic(); //controlador :)
                PlanActual = pl.GetOne(ID);
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar el plan?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    PlanActual.State = BusinessEntity.States.Deleted;
                    pl.Save(PlanActual);
                }

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
