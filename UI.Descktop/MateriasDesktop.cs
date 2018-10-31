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
            Text = CambiarTextos(btnAceptar);
        }
        public MateriasDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic ml = new MateriaLogic(); //controlador :)
            MateriaActual = ml.GetOne(id);
            Text = CambiarTextos(btnAceptar);
            MapearDeDatos();
        }

        private BusinessEntities.Materia _MateriaActual;
        public BusinessEntities.Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = MateriaActual.ID.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion.ToString();
            txtHSemanales.Text = MateriaActual.HSSemanales.ToString();
            txtHTotales.Text = MateriaActual.HSTotales.ToString();
            cbxPlanes.SelectedValue = MateriaActual.IDPlan;
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    MateriaActual = new Materia();
                    MateriaActual.Descripcion = txtDescripcion.Text;
                    MateriaActual.HSSemanales = int.Parse(txtHSemanales.Text);
                    MateriaActual.HSTotales = int.Parse(txtHTotales.Text);
                    MateriaActual.State = BusinessEntity.States.New;                                    
                    MateriaActual.IDPlan = (int)cbxPlanes.SelectedValue;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.Descripcion = txtDescripcion.Text;
                    MateriaActual.HSSemanales = int.Parse(txtHSemanales.Text);
                    MateriaActual.HSTotales = int.Parse(txtHTotales.Text);
                    MateriaActual.State = BusinessEntity.States.Modified;                    
                    MateriaActual.IDPlan = (int)cbxPlanes.SelectedValue;
                    break;
                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    MateriaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(lable4.Text) || string.IsNullOrEmpty(txtHTotales.Text)
                || string.IsNullOrEmpty(txtHTotales.Text) || cbxPlanes.SelectedValue == null)
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(MateriaActual);
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
