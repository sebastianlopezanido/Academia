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
    public partial class Especialidades : ApplicationForm
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
            
            try
            {
                dgvEspecialidades.DataSource = el.GetAll();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
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

        private void btnActualizar_Click(object sender, EventArgs e)
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

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop ed = new EspecialidadesDesktop(ModoForm.Alta);
            ed.ShowDialog();

            try
            {
                Listar();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows != null && dgvEspecialidades.MultiSelect == false && dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadesDesktop ud = new EspecialidadesDesktop(ID, ModoForm.Modificacion);
                ud.ShowDialog();

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
            if (dgvEspecialidades.SelectedRows != null && dgvEspecialidades.MultiSelect == false && dgvEspecialidades.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadLogic el = new EspecialidadLogic(); //controlador :)

                try
                {
                    EspecialidadActual = el.GetOne(ID);
                }
                catch (Exception Ex)
                {
                    Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar la especialidad?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {                    
                    try
                    {                        
                        el.Delete(EspecialidadActual.ID);
                        EspecialidadActual.State = BusinessEntity.States.Deleted;
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
    }
}
