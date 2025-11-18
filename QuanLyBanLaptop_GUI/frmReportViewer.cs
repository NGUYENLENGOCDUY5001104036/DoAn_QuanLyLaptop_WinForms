using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmReportViewer : Form
    {
        private string _reportPath;
        private object _dataSource;
        private string _dataSetName;
        private List<ReportParameter> _parameters;


        public frmReportViewer(string reportPath, string dataSetName, object dataSource, List<ReportParameter> parameters = null)
        {
            InitializeComponent();
            _reportPath = reportPath;
            _dataSource = dataSource;
            _dataSetName = dataSetName;
            _parameters = parameters; 
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = _reportPath;
                ReportDataSource rds = new ReportDataSource(_dataSetName, _dataSource);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                if (_parameters != null && _parameters.Count > 0)
                {
                    this.reportViewer1.LocalReport.SetParameters(_parameters);
                }

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}");
            }
        }
    }
}