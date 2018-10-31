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

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                LoginLogic ll = new LoginLogic();               
                string nombreUsuario = txtUsuario.Text;
                string clave = txtPw.Text;                
                BusinessEntities.Usuario usr = ll.ValidarDatos(nombreUsuario, clave);
                Menu menu = new Menu(usr);               
                menu.Show();
                Hide();  
            }
            catch (Exception Ex)
            {
                Notificar("Error",Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkOlvidePw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Por favor dirijase hacia alumnado");
        }
    }
}
