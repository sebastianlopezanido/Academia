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

namespace UI.Desktop
{
    public partial class FindMateria : Form
    {
        public FindMateria()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
        }

        private int _IDMateria;
        public int IDMateria
        {
            set { _IDMateria = value; }
            get { return _IDMateria; }
        }

        public delegate void pasar(int dato);
        public event pasar pasado;

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

        private void FindMateria_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows != null && dgvMaterias.MultiSelect == false && dgvMaterias.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                pasado(((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID);
            }

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
