using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanLaptop_BUS; 
using QuanLyBanLaptop_DAL; 
using Microsoft.Reporting.WinForms;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmOrderList : Form
    {
        private OrderBUS orderBUS;
        private CustomerBUS customerBUS;

        public frmOrderList()
        {
            InitializeComponent();
            orderBUS = new OrderBUS();
            customerBUS = new CustomerBUS();
            dgvOrders.AutoGenerateColumns = false; 
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            LoadCustomerFilter();
            SetDefaultDates();
            LoadOrderGrid(); 
        }


        private void SetDefaultDates()
        {
            // Từ ngày: 1 tây của tháng này
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // Đến ngày: Hôm nay
            dtpToDate.Value = DateTime.Now;
        }

        // Hàm tải bộ lọc Khách hàng

        private void LoadCustomerFilter()
        {
            var customers = customerBUS.GetAllCustomers();
            customers.Insert(0, new Customer { CustomerID = 0, Name = "[ Tất cả Khách hàng ]" });
            cboCustomers.DataSource = customers;
            cboCustomers.DisplayMember = "Name";
            cboCustomers.ValueMember = "CustomerID";
            cboCustomers.SelectedIndex = 0; 
        }

        // Hàm tải dữ liệu chính 
        private void LoadOrderGrid()
        {
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;
            int customerID = (int)cboCustomers.SelectedValue;

            var orderList = orderBUS.SearchOrders(fromDate, toDate, customerID);

            dgvOrders.DataSource = null;
            dgvOrders.DataSource = orderList;
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadOrderGrid();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetDefaultDates();
            cboCustomers.SelectedIndex = 0;
            LoadOrderGrid();
        }

        // Nút "Xem Chi tiết" 
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết.", "Thông báo");
                return;
            }

            int orderID = (int)dgvOrders.SelectedRows[0].Cells["OrderID"].Value;
            string custName = dgvOrders.SelectedRows[0].Cells["CustomerName"].Value.ToString();
            MessageBox.Show($"Bạn đã chọn xem chi tiết cho Đơn hàng ID: {orderID}.\nChúng ta sẽ làm form này sau.", "Thông báo");
        }

        // Nút "Xuất Báo cáo"
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;
            int customerID = (int)cboCustomers.SelectedValue;
            var data = orderBUS.SearchOrders(fromDate, toDate, customerID);

            // 2. Chuẩn bị thông tin 
            string dataSetName = "DataSet_DoanhThu";
            string reportPath = "QuanLyBanLaptop_GUI.Reports.BaoCaoDoanhThu.rdlc";

            // 3. Tạo danh sách Tham số
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("pFromDate", fromDate.ToString("dd/MM/yyyy")));
            parameters.Add(new ReportParameter("pToDate", toDate.ToString("dd/MM/yyyy")));

            // 4. Mở form Report và TRUYỀN THAM SỐ VÀO
            frmReportViewer reportForm = new frmReportViewer(reportPath, dataSetName, data, parameters);
            reportForm.ShowDialog();
        }
    }
}