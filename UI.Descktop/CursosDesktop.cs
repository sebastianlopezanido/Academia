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
    public partial class CursosDesktop : ApplicationForm
    {
        public CursosDesktop()
        {
            InitializeComponent();
        }

        public CursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public CursosDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic cu = new CursoLogic(); //controlador :)
            CursoActual = cu.GetOne(id);
            this.MapearDeDatos();
        }

        private Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtIDMateria.Text = this.CursoActual.IDMateria.ToString();
            this.txtIDComision.Text = this.CursoActual.IDComision.ToString();
            this.txtAño.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }

        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    this.CursoActual.IDComision = int.Parse(this.txtIDComision.Text);
                    this.CursoActual.IDMateria = int.Parse(this.txtIDMateria.Text);
                    this.CursoActual.AnioCalendario = int.Parse(this.txtAño.Text);
                    this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                    this.CursoActual.State = Comision.States.New;
                    break;
                case ModoForm.Modificacion:
                    this.CursoActual.IDComision = int.Parse(this.txtIDComision.Text);
                    this.CursoActual.IDMateria = int.Parse(this.txtIDMateria.Text);
                    this.CursoActual.AnioCalendario = int.Parse(this.txtAño.Text);
                    this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                    this.CursoActual.State = Curso.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.CursoActual.State = Curso.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.CursoActual.State = Curso.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtAño.Text) || string.IsNullOrEmpty(this.txtIDMateria.Text) || string.IsNullOrEmpty(this.txtIDComision.Text) || string.IsNullOrEmpty(this.txtCupo.Text))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtAño.Text.Length != 4)
            {
                Notificar("Ingrese correctamente el año", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
