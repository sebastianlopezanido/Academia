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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;

        }

        public EspecialidadDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            EspecialidadLogic el = new EspecialidadLogic(); //controlador :)
            EspecialidadActual = el.GetOne(id);
            this.MapearDeDatos();
        }

        private BusinessEntities.Especialidad _EspecialidadActual;
        public BusinessEntities.Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();      

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
                case ModoForm.Alta: EspecialidadActual = new Especialidad();
                                    this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;                    
                                    this.EspecialidadActual.State = Especialidad.States.New;

                    break;
                case ModoForm.Modificacion: this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                                            this.EspecialidadActual.State = Especialidad.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.EspecialidadActual.State = Especialidad.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.EspecialidadActual.State = Especialidad.States.Unmodified;
                    break;
            }

        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
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

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
