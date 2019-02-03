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

namespace UI.Desktop.Profesor
{
    public partial class CursoAlumnoDesktop : ApplicationForm
    {
        public CursoAlumnoDesktop()
        {
            InitializeComponent();
            cbxCondicion.DataSource = Enum.GetValues(typeof(AlumnoInscripcion.TiposCondiciones));
            CenterToScreen();
        }

        public CursoAlumnoDesktop(int idAlu, int idInsc) : this()
        {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(idAlu);
            InscripcionLogic il = new InscripcionLogic();
            AlumnoInscripcionActual = il.GetOne(idInsc);
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(UsuarioActual.IDPersona);
            MapearDeDatos();
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

        private AlumnoInscripcion _AlumnoInscripcionActual;
        public AlumnoInscripcion AlumnoInscripcionActual
        {
            get { return _AlumnoInscripcionActual; }
            set { _AlumnoInscripcionActual = value; }
        }

        public override void MapearDeDatos()
        {
            txtNombre.Text = PersonaActual.Nombre;
            txtApellido.Text = PersonaActual.Apellido;
            txtNota.Text = AlumnoInscripcionActual.Nota.ToString();
            cbxCondicion.SelectedItem = AlumnoInscripcionActual.Condicion;
        }

        public override void MapearADatos()
        {
            AlumnoInscripcionActual.Nota = int.Parse(txtNota.Text);
            AlumnoInscripcionActual.Condicion = (AlumnoInscripcion.TiposCondiciones)cbxCondicion.SelectedValue;
            AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
        }
    
        public override bool Validar()
        {

            int t;
            if ( !int.TryParse(txtNota.Text, out t) ||
                string.IsNullOrEmpty(txtNota.Text) == false && (int.Parse(txtNota.Text) > 10 ||
                int.Parse(txtNota.Text) < 1))
            {
                Notificar("Error", "Ingrese Nota valida (del 1 al 10)", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (((AlumnoInscripcion.TiposCondiciones)cbxCondicion.SelectedValue == AlumnoInscripcion.TiposCondiciones.Regular  ||
                (AlumnoInscripcion.TiposCondiciones)cbxCondicion.SelectedValue == AlumnoInscripcion.TiposCondiciones.Promovido) &&
                int.Parse(txtNota.Text) < 6)
            {
                Notificar("Error", "Para tener condición regular o promovido, debe tener nota mayor o igual a 6", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            InscripcionLogic ml = new InscripcionLogic();
            ml.Save(AlumnoInscripcionActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
