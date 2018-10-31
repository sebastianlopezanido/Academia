﻿using BusinessLogic;
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
    public partial class FindPersona : Form
    {
        public FindPersona()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
        }

        private int _IdPersona;
        public int IdPersona
        {
            set { _IdPersona = value; }
            get { return _IdPersona; }
        }

        public delegate void pasar(int dato);
        public event pasar pasado;

        public void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                dgvPersonas.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void FindPersona_Load(object sender, EventArgs e)
        {
            Listar();
        }              

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows != null && dgvPersonas.MultiSelect == false && dgvPersonas.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                pasado(((BusinessEntities.Persona)dgvPersonas.SelectedRows[0].DataBoundItem).ID);  
            }

            Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {            
            Close();
        }
    }
}
