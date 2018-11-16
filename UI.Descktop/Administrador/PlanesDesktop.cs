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
            cbxEsp.DataSource = el.GetAll();
            cbxEsp.ValueMember = "ID";
            cbxEsp.DisplayMember = "Descripcion";
            CenterToScreen();
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

        private Plan _PlanActual;
        public Plan PlanActual
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
                    PlanActual.IDEspecialidad = (int)cbxEsp.SelectedValue;
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.IDEspecialidad = (int)cbxEsp.SelectedValue;
                    PlanActual.State = BusinessEntity.States.Modified;
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
            MapearADatos();
            PlanLogic el = new PlanLogic();
            el.Save(PlanActual);    
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
