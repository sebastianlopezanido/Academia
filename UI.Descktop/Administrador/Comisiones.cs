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
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
            CenterToScreen();
        }

        private Comision _ComisionActual;
        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
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
                ComisionLogic cl = new ComisionLogic();
                dgvComisiones.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvComisiones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvComisiones.Columns[e.ColumnIndex].Name == "idplan")
            {
                if (e.Value != null)
                {
                    try
                    {
                        PlanLogic pl = new PlanLogic();
                        PlanActual = pl.GetOne((int)e.Value);
                        e.Value = PlanActual.Descripcion;
                    }
                    catch (Exception Ex)
                    {
                        Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            try
            {
                Listar();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop cd = new ComisionesDesktop(ModoForm.Alta);
            cd.ShowDialog();

            try
            {
                Listar();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows != null && dgvComisiones.MultiSelect == false && dgvComisiones.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionesDesktop pd = new ComisionesDesktop(ID, ModoForm.Modificacion);
                pd.ShowDialog();

                try
                {
                    Listar();
                }
                catch (Exception Ex)
                {
                    Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows != null && dgvComisiones.MultiSelect == false && dgvComisiones.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Comision)dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionLogic cl = new ComisionLogic(); //controlador :)

                try
                {
                    ComisionActual = cl.GetOne(ID);
                }
                catch (Exception Ex)
                {
                    Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar la comisión?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    try
                    {
                        cl.Save(ComisionActual);
                    }
                    catch (Exception Ex)
                    {
                        Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }

                try
                {
                    Listar();
                }
                catch (Exception Ex)
                {
                    Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Listar();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }        
    }
}
