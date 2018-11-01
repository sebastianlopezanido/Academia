using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
           InitializeComponent();
        }

        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        private ModoForm _Modo;
        public ModoForm Modo
        {
            get { return _Modo; }
            set { _Modo = value; }
        }

        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            Notificar(Text, mensaje, botones, icono);
        }

        public string CambiarTextos(Button b)
        { switch (Modo)
            {
                case ModoForm.Alta:
                    b.Text = "Guardar";
                    return "Agregar";
                case ModoForm.Modificacion:
                    b.Text = "Guardar";
                    return "Editar";                    
                //case ModoForm.Baja:
                //    b.Text = "Eliminar";
                //    return "Eliminar";                   
                case ModoForm.Consulta:
                    b.Text = "Aceptar";
                    return "Consulta";
                default:
                    return "";
                    
            }
        }

    }
}