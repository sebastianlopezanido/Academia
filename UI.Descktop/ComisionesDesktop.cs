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
    public partial class ComisionesDesktop : ApplicationForm
    {
        public ComisionesDesktop()
        {
            InitializeComponent();
        }

        public ComisionesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ComisionesDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cu = new ComisionLogic(); //controlador :)
            ComisionActual = cu.GetOne(id);
            this.MapearDeDatos();
        }

        private Comision _ComisionActual;
        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAño.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
            
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
                    ComisionActual = new Comision();
                    this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAño.Text);
                    this.ComisionActual.IDPlan = int.Parse(this.txtIDPlan.Text);
                    this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                    this.ComisionActual.State = Comision.States.New;

                    break;
                case ModoForm.Modificacion:
                    this.ComisionActual.ID = int.Parse(this.txtID.Text);
                    this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAño.Text);
                    this.ComisionActual.IDPlan = int.Parse(this.txtIDPlan.Text);
                    this.ComisionActual.Descripcion = this.txtDescripcion.Text;

                    this.ComisionActual.State = Comision.States.Modified;
                    break;
                case ModoForm.Baja:
                    this.ComisionActual.State = Comision.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.ComisionActual.State = Comision.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtAño.Text) || string.IsNullOrEmpty(this.txtIDPlan.Text) || string.IsNullOrEmpty(this.txtDescripcion.Text))
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
