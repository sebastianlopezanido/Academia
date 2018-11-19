using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Profesor
{
    public partial class CursosProfesor : Form
    {
        public CursosProfesor()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
            CenterToScreen();
        }

        private void tsCursos_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
