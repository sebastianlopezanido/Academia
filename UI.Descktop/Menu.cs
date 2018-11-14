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
using UI.Desktop.Alumno;

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
            switch(UsuarioActual.Tipo)
            {
                case Usuario.TiposUsuario.Alumno:
                    btn1.Text = "Inscripcion";
                    btn2.Text = "Cursado y Notas";
                    btnAdmCom.Hide();
                    btnAdmPla.Hide();
                    btnAdmCur.Hide();
                    btnAdmEsp.Hide();
                    btnAdmMat.Hide();
                    break;
                case Usuario.TiposUsuario.Profesor:
                    btn1.Text = "Cursos";
                    btn2.Hide();
                    btnAdmCom.Hide();
                    btnAdmPla.Hide();
                    btnAdmCur.Hide();
                    btnAdmEsp.Hide();
                    btnAdmMat.Hide();
                    break;
                case Usuario.TiposUsuario.Administrador:
                    btn1.Text = "Usuarios";
                    btn2.Text = "Personas";
                    break;
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
            Login log = Program.login;
            log.Show();            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            switch (UsuarioActual.Tipo)
            {
                case Usuario.TiposUsuario.Alumno:
                    FindMateria findMateriaForm = new FindMateria();
                    findMateriaForm.pasado += new FindMateria.pasar(Ejecutar);
                    findMateriaForm.ShowDialog();                    
                    break;
                //case Usuario.TiposUsuario.Profesor:
                //    CursosProfesor cpForm = new CursosProfesor();
                //    cpForm.ShowDialog();
                //    break;
                case Usuario.TiposUsuario.Administrador:
                    Usuarios userForm = new Usuarios();
                    userForm.ShowDialog();
                    break;
            }
        }

        public void Ejecutar(int dato)
        {

            Inscripciones insForm = new Inscripciones(dato);
            insForm.ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {           
            switch (UsuarioActual.Tipo)
            {
                //case Usuario.TiposUsuario.Alumno:
                //    Cursado curForm = new Cursado();
                //    curForm.ShowDialog();
                //    break;
                case Usuario.TiposUsuario.Administrador:
                    Personas prsForm = new Personas();
                    prsForm.ShowDialog();
                    break;
            }
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
