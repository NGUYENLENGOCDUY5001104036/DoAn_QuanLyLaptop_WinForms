using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanLaptop_BUS; // Thêm BUS
using QuanLyBanLaptop_DAL; // Thêm DAL
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
            dgvOrders.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmOrderList_Load(object sender, EventArgs e)
        {
            LoadCustomerFilter();
            SetDefaultDates();
            LoadOrderGrid(); // Tải lần đầu
        }

        // Cài đặt ngày mặc định
        private void SetDefaultDates()
        {
            // Từ ngày: 1 tây của tháng này
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // Đến ngày: Hôm nay
            dtpToDate.Value = DateTime.Now;
        }

        // Tải ComboBox Khách hàng
        private void LoadCustomerFilter()
        {
            var customers = customerBUS.GetAllCustomers();
            customers.Insert(0, new Customer { CustomerID = 0, Name = "[ Tất cả Khách hàng ]" });
            cboCustomers.DataSource = customers;
            cboCustomers.DisplayMember = "Name";
            cboCustomers.ValueMember = "CustomerID";

            // ▼▼▼ THÊM DÒNG NÀY VÀO ▼▼▼
            cboCustomers.SelectedIndex = 0; // Chọn "[ Tất cả Khách hàng ]" làm mặc định
        }

        // Hàm tải dữ liệu chính (cho cả Form_Load và nút Lọc)
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

        // Cấu hình cột
        private void ConfigureDataGridView()
        {
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //if (dgvOrders.Columns.Count > 0)
            //{
            //    dgvOrders.Columns["OrderID"].HeaderText = "Mã ĐH";
            //    dgvOrders.Columns["CustomerName"].HeaderText = "Tên Khách hàng";
            //    dgvOrders.Columns["OrderDate"].HeaderText = "Ngày mua";
            //    dgvOrders.Columns["UserName"].HeaderText = "Nhân viên";
            //    dgvOrders.Columns["TotalAmount"].HeaderText = "Tổng tiền";
            //    dgvOrders.Columns["Status"].HeaderText = "Trạng thái";

            //    dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N0"; // Format 1,000,000
            //    dgvOrders.Columns["CustomerName"].FillWeight = 150;
            //}
        }

        // Nút "Đóng" (NHỚ NỐI DÂY!)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút "Lọc" (NHỚ NỐI DÂY!)
        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadOrderGrid(); // Chỉ cần gọi lại hàm tải
        }

        // Nút "Làm mới" (NHỚ NỐI DÂY!)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetDefaultDates();
            cboCustomers.SelectedIndex = 0;
            LoadOrderGrid();
        }

        // Nút "Xem Chi tiết" (NHỚ NỐI DÂY!)
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết.", "Thông báo");
                return;
            }

            // Lấy OrderID
            int orderID = (int)dgvOrders.SelectedRows[0].Cells["OrderID"].Value;

            // (Chúng ta sẽ làm form 'frmOrderDetails' sau)
            // Tạm thời, chúng ta MỞ LẠI form 'frmCustomerHistory'
            // vì nó đã có logic xem chi tiết đơn hàng

            // Lấy tên khách hàng từ dòng
            string custName = dgvOrders.SelectedRows[0].Cells["CustomerName"].Value.ToString();

            // (Hơi 'hack' một chút, nhưng nó hoạt động)
            // Lấy CustomerID (chúng ta chưa có, phải gọi CSDL)
            // Thôi, để đơn giản, chúng ta sẽ tạo một form mini

            MessageBox.Show($"Bạn đã chọn xem chi tiết cho Đơn hàng ID: {orderID}.\nChúng ta sẽ làm form này sau.", "Thông báo");
        }

        // Nút "Xuất Báo cáo"
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu (như cũ)
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;
            int customerID = (int)cboCustomers.SelectedValue;
            var data = orderBUS.SearchOrders(fromDate, toDate, customerID);

            // 2. Chuẩn bị thông tin (như cũ)
            string dataSetName = "DataSet_DoanhThu";
            string reportPath = "QuanLyBanLaptop_GUI.Reports.BaoCaoDoanhThu.rdlc";

            // 3. THÊM BƯỚC NÀY: Tạo danh sách Tham số
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("pFromDate", fromDate.ToString("dd/MM/yyyy")));
            parameters.Add(new ReportParameter("pToDate", toDate.ToString("dd/MM/yyyy")));

            // 4. Mở form Report và TRUYỀN THAM SỐ VÀO
            frmReportViewer reportForm = new frmReportViewer(reportPath, dataSetName, data, parameters);
            reportForm.ShowDialog();
        }
    }
}