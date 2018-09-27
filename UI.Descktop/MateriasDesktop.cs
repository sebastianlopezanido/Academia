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
    public partial class MateriasDesktop : ApplicationForm
    {
        public MateriasDesktop()
        {
            InitializeComponent();
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            cbxPlanes.DataSource = planes;
            cbxPlanes.ValueMember = "ID";
            cbxPlanes.DisplayMember = "Descripcion";
        }

        public MateriasDesktop(ModoForm modo) : this()
        {
            Modo = modo;

        }
        public MateriasDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic ml = new MateriaLogic(); //controlador :)
            MateriaActual = ml.GetOne(id);
            this.MapearDeDatos();
        }

        private BusinessEntities.Materia _MateriaActual;
        public BusinessEntities.Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cbxPlanes.SelectedValue = this.MateriaActual.IDPlan;

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
                case ModoForm.Alta: MateriaActual = new Materia();
                                    this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                                    this.MateriaActual.HSSemanales = int.Parse(this.txtHSemanales.Text);
                                    this.MateriaActual.HSTotales = int.Parse(this.txtHTotales.Text);
                                    this.MateriaActual.State = Materia.States.New;                                    
                                    this.MateriaActual.IDPlan = (int)this.cbxPlanes.SelectedValue;
                    break;
                case ModoForm.Modificacion: this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                                            this.MateriaActual.HSSemanales = int.Parse(this.txtHSemanales.Text);
                                            this.MateriaActual.HSTotales = int.Parse(this.txtHTotales.Text);
                                            this.MateriaActual.State = Materia.States.Modified;                    
                                            this.MateriaActual.IDPlan = (int)this.cbxPlanes.SelectedValue;
                    break;
                case ModoForm.Baja:
                    this.MateriaActual.State = Materia.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.MateriaActual.State = Materia.States.Unmodified;
                    break;
            }
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text) || string.IsNullOrEmpty(this.lable4.Text) || string.IsNullOrEmpty(this.txtHTotales.Text)
                || string.IsNullOrEmpty(this.txtHTotales.Text) || this.cbxPlanes.SelectedValue == null)
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(MateriaActual);
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
