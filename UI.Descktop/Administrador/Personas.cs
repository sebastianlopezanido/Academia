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
            dgvPersonas.AutoGenerateColumns = false;
            CenterToScreen();
        }

        private Persona _PersonaActual;
        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        public void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                dgvPersonas.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Personas_Load(object sender, EventArgs e)
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
            PersonasDesktop ud = new PersonasDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows != null && dgvPersonas.MultiSelect == false && dgvPersonas.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Persona)dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonasDesktop ud = new PersonasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows != null && dgvPersonas.MultiSelect == false && dgvPersonas.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Persona)dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaLogic pl = new PersonaLogic(); //controlador :)
                PersonaActual = pl.GetOne(ID);
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar la persona?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    pl.Save(PersonaActual);
                }

                Listar();
            }
        }        
    }
}