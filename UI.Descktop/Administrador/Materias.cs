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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            CenterToScreen();
        }

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public void Listar()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                dgvMaterias.DataSource = ml.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dgvMaterias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMaterias.Columns[e.ColumnIndex].Name == "idplan")
            {
                if (e.Value != null)
                {
                    PlanLogic pl = new PlanLogic();
                    PlanActual = pl.GetOne((int)e.Value);
                    e.Value = PlanActual.Descripcion;
                }
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriasDesktop md = new MateriasDesktop(ApplicationForm.ModoForm.Alta);
            md.ShowDialog();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriasDesktop md = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                md.ShowDialog();
                Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaLogic ml = new MateriaLogic(); //controlador :)
                MateriaActual = ml.GetOne(ID);
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar la materia?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        MateriaActual.State = BusinessEntity.States.Deleted;
                        ml.Save(MateriaActual);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
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

        private void dgvMaterias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriasDesktop md = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                md.ShowDialog();
                Listar();
            }
        }
    }
}
