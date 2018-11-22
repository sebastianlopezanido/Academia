using BusinessEntities;
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
    public partial class Planes_Reporte : Form
    {
        public List<Plan_Reporte> Datos = new List<Plan_Reporte>();
        public Planes_Reporte()
        {
            InitializeComponent();
        }

        private void Planes_Reporte_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Datos));
            this.reportViewer1.RefreshReport();
        }
    }
}
