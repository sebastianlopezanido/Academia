﻿using System;
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
    public partial class Menu : ApplicationForm
    {
        public Menu(BusinessEntities.Usuario user)
        {
            InitializeComponent();
        }

        private void salir_Click(object sender, EventArgs e)
        {

            Application.Exit();
            
        }
    }
}
