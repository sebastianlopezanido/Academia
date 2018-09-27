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
    public partial class PlanesDesktop : ApplicationForm
    {
        public PlanesDesktop()
        {
            InitializeComponent();

            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            cbxEsp.DataSource = especialidades;
            cbxEsp.ValueMember = "ID";
            cbxEsp.DisplayMember = "Descripcion";                     
        }

        public PlanesDesktop(ModoForm modo) : this()
        {
            Modo = modo;

        }
        public PlanesDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic pl = new PlanLogic(); //controlador :)
            PlanActual = pl.GetOne(id);
            this.MapearDeDatos();
        }
        private BusinessEntities.Plan _PlanActual;
        public BusinessEntities.Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            this.cbxEsp.SelectedValue = this.PlanActual.IDEspecialidad;

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
                    PlanActual = new Plan();                    
                    this.PlanActual.Descripcion = this.txtDescripcion.Text;
                    this.PlanActual.State = Plan.States.New;
                    //////esp = (Especialidad)this.cbxEsp.SelectedItem;
                    this.PlanActual.IDEspecialidad = (int)this.cbxEsp.SelectedValue;
                    break;
                case ModoForm.Modificacion:
                    this.PlanActual.Descripcion = this.txtDescripcion.Text;
                    this.PlanActual.State = Plan.States.Modified;
                    //esp = (Especialidad)this.cbxEsp.SelectedItem;
                    this.PlanActual.IDEspecialidad = (int)this.cbxEsp.SelectedValue;
                    break;
                case ModoForm.Baja:
                    this.PlanActual.State = Plan.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.PlanActual.State = Plan.States.Unmodified;
                    break;
            }
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text) || this.cbxEsp.SelectedValue == null)
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic el = new PlanLogic();
            el.Save(PlanActual);
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
        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
