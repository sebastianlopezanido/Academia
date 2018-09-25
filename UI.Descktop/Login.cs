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
    public partial class Login : Form
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
                BusinessEntities.Usuario usr = new BusinessEntities.Usuario();
                string nombreUsuario = this.txtUsuario.Text;
                string clave = this.txtPw.Text;
                usr = ll.ValidarDatos(nombreUsuario, clave);

                
                Menu menu = new Menu(usr);
               
                menu.Show();
                this.Hide();
                
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkOlvidePw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Por favor dirijase hacia alumnado");
        }
    }
}
