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
            ComisionLogic cl = new ComisionLogic();
            cbxIDComision.DataSource = cl.GetAll();
            cbxIDComision.ValueMember = "ID";
            cbxIDComision.DisplayMember = "Descripcion";
            CenterToScreen();
        }    

        public CursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            Text = CambiarTextos(btnAceptar);
        }

        public CursosDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic cu = new CursoLogic(); //controlador :)
            CursoActual = cu.GetOne(id);
            Text = CambiarTextos(btnAceptar);
            MapearDeDatos();
        }

        private Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = CursoActual.ID.ToString();
            txtIDMateria.Text = CursoActual.IDMateria.ToString();
            cbxIDComision.SelectedValue = CursoActual.IDComision;
            txtAño.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    CursoActual.IDComision = (int)cbxIDComision.SelectedValue;
                    CursoActual.IDMateria = int.Parse(txtIDMateria.Text);
                    CursoActual.AnioCalendario = int.Parse(txtAño.Text);
                    CursoActual.Cupo = int.Parse(txtCupo.Text);
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.IDComision = (int)cbxIDComision.SelectedValue;
                    CursoActual.IDMateria = int.Parse(txtIDMateria.Text);
                    CursoActual.AnioCalendario = int.Parse(txtAño.Text);
                    CursoActual.Cupo = int.Parse(txtCupo.Text);
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                //case ModoForm.Baja:
                //    CursoActual.State = BusinessEntity.States.Deleted;
                //    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtIDMateria.Text) || cbxIDComision.SelectedValue == null || string.IsNullOrEmpty(txtCupo.Text))
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

        private void btnFindMateria_Click(object sender, EventArgs e)
        {
            FindMateria findMateriaForm = new FindMateria();
            findMateriaForm.pasado += new FindMateria.pasar(Ejecutar);
            findMateriaForm.ShowDialog();
        }

        public void Ejecutar(int dato)
        {
            txtIDMateria.Text = dato.ToString();
        }
    }
}

