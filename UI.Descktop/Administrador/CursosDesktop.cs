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
            DocenteCursoLogic dc = new DocenteCursoLogic();
            CursoActual = cu.GetOne(id);
            DocenteCursoActual = dc.GetOneByCurso(CursoActual.ID);
            Text = CambiarTextos(btnAceptar);
            MapearDeDatos();
        }


        private DocenteCurso _DocenteCursoActual;
        public DocenteCurso DocenteCursoActual
        {
            get { return _DocenteCursoActual; }
            set { _DocenteCursoActual = value; }
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
            txtIDDocente.Text = DocenteCursoActual.IDDocente.ToString();
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    DocenteCursoActual = new DocenteCurso();
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
            GuardarCambiosDocenteCurso();
        }

        public void MapearADatosDocenteCurso(int id_curso)
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.IDDocente = int.Parse(txtIDDocente.Text);
                    DocenteCursoActual.IDCurso = id_curso;
                    DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)1;

                    DocenteCursoActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    CursoActual.IDComision = (int)cbxIDComision.SelectedValue;
                    CursoActual.IDMateria = int.Parse(txtIDMateria.Text);
                    CursoActual.AnioCalendario = int.Parse(txtAño.Text);
                    CursoActual.Cupo = int.Parse(txtCupo.Text);
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    DocenteCursoActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public void GuardarCambiosDocenteCurso()
        {
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOneByMatComAnio(CursoActual.IDMateria, CursoActual.IDComision,CursoActual.AnioCalendario);

            MapearADatosDocenteCurso(CursoActual.ID);
            DocenteCursoLogic dc = new DocenteCursoLogic();
            dc.Save(DocenteCursoActual);
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
                Notificar("Error","Ingrese correctamente el año", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public void Ejecutar(int id)
        {
            txtIDMateria.Text = id.ToString();
        }

       
    }
}

