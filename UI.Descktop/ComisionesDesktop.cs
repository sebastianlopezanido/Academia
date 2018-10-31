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
            Text = CambiarTextos(btnAceptar);
        }

        public ComisionesDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cu = new ComisionLogic(); //controlador :)
            ComisionActual = cu.GetOne(id);
            Text = CambiarTextos(btnAceptar);
            if (modo == ModoForm.Baja) DisableBoxes(true); 
            MapearDeDatos();
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
            txtIDPlan.Text = ComisionActual.IDPlan.ToString();

        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    ComisionActual = new Comision();
                    ComisionActual.AnioEspecialidad = int.Parse(txtAño.Text);
                    ComisionActual.IDPlan = int.Parse(txtIDPlan.Text);
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    ComisionActual.ID = int.Parse(txtID.Text);
                    ComisionActual.AnioEspecialidad = int.Parse(txtAño.Text);
                    ComisionActual.IDPlan = int.Parse(txtIDPlan.Text);
                    ComisionActual.Descripcion = txtDescripcion.Text;

                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    ComisionActual.State = BusinessEntity.States.Deleted;
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
            cl.Save(ComisionActual);
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtIDPlan.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtAño.Text.Length != 4)
            {
                Notificar("Ingrese correctamente el año", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void DisableBoxes(bool enable)
        {
            txtDescripcion.ReadOnly = enable;
            txtAño.ReadOnly = enable;
            txtIDPlan.ReadOnly = enable;
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
