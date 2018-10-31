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
            Text = CambiarTextos(btnAceptar);

        }

        public PlanesDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic pl = new PlanLogic(); //controlador :)
            PlanActual = pl.GetOne(id);
            Text = CambiarTextos(btnAceptar);
            MapearDeDatos();
        }

        private BusinessEntities.Plan _PlanActual;
        public BusinessEntities.Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = PlanActual.ID.ToString();
            txtDescripcion.Text = PlanActual.Descripcion.ToString();
            cbxEsp.SelectedValue = PlanActual.IDEspecialidad;
        }

        public override void MapearADatos()
        {
            
            switch (Modo)
            {
                case ModoForm.Alta:
                    PlanActual = new Plan();                    
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.State = BusinessEntity.States.New;
                    //////esp = (Especialidad)cbxEsp.SelectedItem;
                    PlanActual.IDEspecialidad = (int)cbxEsp.SelectedValue;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.State = BusinessEntity.States.Modified;
                    //esp = (Especialidad)cbxEsp.SelectedItem;
                    PlanActual.IDEspecialidad = (int)cbxEsp.SelectedValue;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text) || cbxEsp.SelectedValue == null)
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public override void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PlanLogic el = new PlanLogic();
                el.Save(PlanActual);

            }
            catch(Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
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

        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
