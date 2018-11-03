using BusinessEntities;
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
    public partial class Menu : ApplicationForm
    {
        public Menu(Usuario user)
        {
            UsuarioActual = user;
            InitializeComponent();
            CenterToScreen();
            Ocultar();        

        }

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public void Ocultar()
        {
            if (UsuarioActual.Tipo == Usuario.TiposUsuario.Profesor || UsuarioActual.Tipo == Usuario.TiposUsuario.Alumno)
            {
                //aca se oculta lo del admin
                btnAdmCom.Hide();
                btnAdmPla.Hide();
                btnAdmCur.Hide();
                btnAdmEsp.Hide();
                btnAdmMat.Hide();
                btnAdmPrs.Hide();
                btnAdmUsr.Hide();
            }
            if (UsuarioActual.Tipo == Usuario.TiposUsuario.Alumno || UsuarioActual.Tipo == Usuario.TiposUsuario.Administrador)
            {
                //aca se oculta lo del profesor (lo que ve el profesor va acá)                
            }
            if (UsuarioActual.Tipo == Usuario.TiposUsuario.Administrador || UsuarioActual.Tipo == Usuario.TiposUsuario.Profesor)
            {
                //aca se oculta lo del alumno                
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
            Login log = Program.login;
            log.Show();            
        }

        private void btnAdmUsr_Click(object sender, EventArgs e)
        {
            Usuarios userForm = new Usuarios();
            userForm.ShowDialog();
            //Hide();
        }

        private void btnAdmPrs_Click(object sender, EventArgs e)
        {
            Personas prsForm = new Personas();
            prsForm.ShowDialog();
        }

        private void btnAdmEsp_Click(object sender, EventArgs e)
        {
            Especialidades espForm = new Especialidades();
            espForm.ShowDialog();
        }

        private void btnAdmPla_Click(object sender, EventArgs e)
        {
            Planes planesForm = new Planes();
            planesForm.ShowDialog();
        }

        private void btnAdmMat_Click(object sender, EventArgs e)
        {
            Materias materiasForm = new Materias();
            materiasForm.ShowDialog();
        }

        private void btnAdmCom_Click(object sender, EventArgs e)
        {
            Comisiones comisionesForm = new Comisiones();
            comisionesForm.ShowDialog();
        }

        private void btnAdmCur_Click(object sender, EventArgs e)
        {
            Cursos cursosForm = new Cursos();
            cursosForm.ShowDialog();
        }
    }
}
