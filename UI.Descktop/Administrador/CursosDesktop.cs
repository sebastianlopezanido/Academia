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
using UI.Desktop.Profesor;

namespace UI.Desktop
{
    public partial class CursosDesktop : ApplicationForm
    {
        public CursosDesktop()
        {
            InitializeComponent();
            cbxCargo.DataSource = Enum.GetValues(typeof(DocenteCurso.TiposCargos));
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
            MateriaLogic ml = new MateriaLogic();
            UsuarioLogic ul = new UsuarioLogic();
            CursoActual = cu.GetOne(id);
            DocenteCursoActual = dc.GetOneByCurso(CursoActual.ID);
            MateriaActual = ml.GetOne(CursoActual.IDMateria);
            DocenteActual = ul.GetOne(DocenteCursoActual.IDDocente);
            Text = CambiarTextos(btnAceptar);

            //cbxIDComision.Enabled = false;
            //btnFindMateria.Enabled = false;
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

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        private Usuario _DocenteActual;
        public Usuario DocenteActual
        {
            get { return _DocenteActual; }
            set { _DocenteActual = value; }
        }

        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        public override void MapearDeDatos()
        {
            txtID.Text = CursoActual.ID.ToString();
            txtIDMateria.Text = MateriaActual.Descripcion;
            cbxIDComision.SelectedValue = CursoActual.IDComision;
            txtAño.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();
            PersonaLogic pl = new PersonaLogic();
            txtIDDocente.Text = pl.GetOne(DocenteActual.IDPersona).Apellido;            
            cbxCargo.SelectedItem = DocenteCursoActual.Cargo;
        }

        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    DocenteCursoActual = new DocenteCurso();
                    CursoActual.IDComision = (int)cbxIDComision.SelectedValue;
                    CursoActual.IDMateria = MateriaActual.ID;
                    CursoActual.AnioCalendario = int.Parse(txtAño.Text);
                    CursoActual.Cupo = int.Parse(txtCupo.Text);
                    CursoActual.State = BusinessEntity.States.New;                   
                    break;
                case ModoForm.Modificacion:
                    CursoActual.IDComision = (int)cbxIDComision.SelectedValue;
                    CursoActual.IDMateria = MateriaActual.ID;
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

            switch (Modo)
            {
                case ModoForm.Alta:
                    IDCurso = cl.Insert(CursoActual);
                    GuardarCambiosDocenteCurso();
                    break;
                case ModoForm.Modificacion:
                    cl.Save(CursoActual);
                    GuardarCambiosDocenteCurso();
                    break;                
            }          
            
        }

        public void MapearADatosDocenteCurso()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    DocenteCursoActual = new DocenteCurso();
                    DocenteCursoActual.IDDocente = DocenteActual.ID;
                    DocenteCursoActual.IDCurso = IDCurso;
                    DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)cbxCargo.SelectedItem;
                    DocenteCursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    DocenteCursoActual.IDDocente = DocenteActual.ID;
                    DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)cbxCargo.SelectedItem;
                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                    break;               
            }
        }

        public void GuardarCambiosDocenteCurso()
        {
            MapearADatosDocenteCurso();
            DocenteCursoLogic dc = new DocenteCursoLogic();
            dc.Save(DocenteCursoActual);
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(txtAño.Text) ||
                string.IsNullOrEmpty(txtIDMateria.Text) ||
                cbxIDComision.SelectedValue == null ||
                string.IsNullOrEmpty(txtCupo.Text))
            {
                Notificar("Campos incompletos", "Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            int num;
            if (txtAño.Text.Length != 4 ||
                !(int.TryParse(txtAño.Text, out num)) ||
                int.Parse(txtAño.Text) < 2000 ||
                int.Parse(txtAño.Text) > 2100)
            {
                Notificar("Error","Ingrese correctamente el año", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!(int.TryParse(txtCupo.Text, out num)) ||
                int.Parse(txtCupo.Text)>100)
            {
                Notificar("Error", "Ingrese correctamente el cupo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            CursoLogic cl = new CursoLogic();
            Curso curso = cl.GetOne(int.Parse(txtID.Text));

            if((( Modo == ModoForm.Modificacion && 
                (curso.AnioCalendario != int.Parse(txtAño.Text) ||
                curso.IDComision != (int)cbxIDComision.SelectedValue ||
                curso.IDMateria != MateriaActual.ID) ) || Modo == ModoForm.Alta ) &&
               cl.EstaAgregado(MateriaActual.ID, (int)cbxIDComision.SelectedValue, int.Parse(txtAño.Text)))
            {
                Notificar("Error", "Ya existe ese curso en esa comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void Ejecutar(Materia materia)
        {
            MateriaActual = materia;
            txtIDMateria.Text = materia.Descripcion;
        }

        private void btnFindProfesor_Click(object sender, EventArgs e)
        {
            FindProfesor findProfesorForm = new FindProfesor();
            findProfesorForm.pasado += new FindProfesor.pasar(Ejecutar2);
            findProfesorForm.ShowDialog();
        }
        public void Ejecutar2(Usuario docente)
        {
            DocenteActual = docente;
            PersonaLogic pl = new PersonaLogic();
            txtIDDocente.Text = pl.GetOne(docente.IDPersona).Apellido;

        }
    }
}

