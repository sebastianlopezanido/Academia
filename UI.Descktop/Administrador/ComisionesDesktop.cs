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

            try
            {
                PlanLogic pl = new PlanLogic();
                cbxIDPlan.DataSource = pl.GetAll();
                cbxIDPlan.ValueMember = "ID";
                cbxIDPlan.DisplayMember = "Descripcion";
                CenterToScreen();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public ComisionesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            Text = CambiarTextos(btnAceptar);
        }

        public ComisionesDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cu = new ComisionLogic();

            try
            {
                ComisionActual = cu.GetOne(id);
                Text = CambiarTextos(btnAceptar);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private Comision _ComisionActual;
        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = ComisionActual.ID.ToString();
            txtAño.Text = ComisionActual.AnioEspecialidad.ToString();
            txtDescripcion.Text = ComisionActual.Descripcion;
            cbxIDPlan.SelectedValue = ComisionActual.IDPlan;
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    ComisionActual = new Comision();
                    ComisionActual.AnioEspecialidad = int.Parse(txtAño.Text);
                    ComisionActual.IDPlan = (int)cbxIDPlan.SelectedValue;
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.ID = int.Parse(txtID.Text);
                    ComisionActual.AnioEspecialidad = int.Parse(txtAño.Text);
                    ComisionActual.IDPlan = (int)cbxIDPlan.SelectedValue;
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            try
            {
                cl.Save(ComisionActual);
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtAño.Text) || cbxIDPlan.SelectedValue == null || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            int i;
            if (!int.TryParse(txtAño.Text, out i))
            {
                Notificar("Error", "Ingrese año correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
