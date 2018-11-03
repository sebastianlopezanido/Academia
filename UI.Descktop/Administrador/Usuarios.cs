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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            CenterToScreen();
        }

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
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
                UsuarioLogic ul = new UsuarioLogic();
                dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {               
                MessageBox.Show(Ex.Message);
            }            
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "idpersona")
            {
                if (e.Value != null)
                {
                    PersonaLogic pl = new PersonaLogic();
                    PersonaActual = pl.GetOne((int)e.Value);
                    e.Value = PersonaActual.Legajo;
                }
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            UsuariosDesktop ud = new UsuariosDesktop(ApplicationForm.ModoForm.Alta);            
            ud.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if(dgvUsuarios.SelectedRows != null && dgvUsuarios.MultiSelect == false && dgvUsuarios.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuariosDesktop ud = new UsuariosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                Listar();
            }           
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows != null && dgvUsuarios.MultiSelect == false && dgvUsuarios.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;                
                UsuarioLogic ul = new UsuarioLogic(); //controlador :)
                UsuarioActual = ul.GetOne(ID);
                DialogResult dr = MessageBox.Show("¿Seguro que quiere eliminar el usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);                
                
                if (dr == DialogResult.Yes)
                {
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    ul.Save(UsuarioActual);
                }
                                
                Listar();
            }
        }

    }
}
