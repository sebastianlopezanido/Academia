using BusinessLogic;
using BusinessEntities;
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
    public partial class FindMateria : Form
    {
        public FindMateria()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            CenterToScreen();
        }

        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public delegate void pasar(Materia materia);
        public event pasar pasado;

        public void Listar()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();

                switch(LoginSession.Tipo)
                {
                    case Usuario.TiposUsuario.Alumno:
                        dgvMaterias.DataSource = ml.GetAllByPlan(LoginSession.IDPlan);
                        break;
                    case Usuario.TiposUsuario.Administrador:
                        dgvMaterias.DataSource = ml.GetAll();
                        break;
                }              

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void FindMateria_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            switch(LoginSession.Tipo)
            {
                case Usuario.TiposUsuario.Alumno:
                    InscripcionLogic il = new InscripcionLogic();
                    if (il.EstaInscripto(LoginSession.ID,((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID) == false)
                    {
                        if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                        {
                            pasado((Materia)dgvMaterias.SelectedRows[0].DataBoundItem);
                        }

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya esta inscripto a la materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case Usuario.TiposUsuario.Administrador:
                    if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                    {
                        pasado((Materia)dgvMaterias.SelectedRows[0].DataBoundItem);
                    }
                    Close();

                    break;
            }
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
