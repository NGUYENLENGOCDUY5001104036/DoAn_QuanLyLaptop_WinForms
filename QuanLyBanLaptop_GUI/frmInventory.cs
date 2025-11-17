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
using QuanLyBanLaptop_DAL; // Thêm DAL
using Microsoft.Reporting.WinForms;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmInventory : Form
    {
        private ReportBUS reportBUS;
        private ProductBUS productBUS; // Dùng để tải filter

        public frmInventory()
        {
            InitializeComponent();
            reportBUS = new ReportBUS();
            productBUS = new ProductBUS();

            dgvInventory.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmInventory_Load(object sender, EventArgs e)
        {
            LoadBrandFilter();
            LoadInventoryGrid(); // Tải lần đầu

            // (QUAN TRỌNG) Nối dây sự kiện để tô màu
            dgvInventory.DataBindingComplete += dgvInventory_DataBindingComplete;
        }

        // Tải ComboBox Hãng
        private void LoadBrandFilter()
        {
            var brandList = productBUS.GetUniqueBrands();
            brandList.Insert(0, "[ Tất cả Hãng ]");
            cboBrandFilter.DataSource = brandList;
        }

        // Hàm tải dữ liệu chính
        private void LoadInventoryGrid()
        {
            // 1. Lấy giá trị filter
            string brand = cboBrandFilter.SelectedItem.ToString();
            bool reorderOnly = chkReorderOnly.Checked;

            // 2. Gọi BUS
            var reportData = reportBUS.GetInventoryReport(brand, reorderOnly);

            // 3. Tải lên
            dgvInventory.DataSource = null;
            dgvInventory.DataSource = reportData;
            ConfigureDataGridView();
        }

        // Cấu hình cột
        private void ConfigureDataGridView()
        {
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //if (dgvInventory.Columns.Count > 0)
            //{
            //    dgvInventory.Columns["ProductID"].Visible = false; // Ẩn ID

            //    dgvInventory.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            //    dgvInventory.Columns["Brand"].HeaderText = "Hãng";
            //    dgvInventory.Columns["SKU"].HeaderText = "SKU";
            //    dgvInventory.Columns["StockCount"].HeaderText = "Tồn kho (chiếc)";
            //    dgvInventory.Columns["ReorderLevel"].HeaderText = "Mức Cảnh báo";
            //    dgvInventory.Columns["Status"].HeaderText = "Tình trạng";
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
            LoadInventoryGrid();
        }

        // Nút "Làm mới" (NHỚ NỐI DÂY!)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboBrandFilter.SelectedIndex = 0;
            chkReorderOnly.Checked = false;
            LoadInventoryGrid();
        }

        // SỰ KIỆN TÔ MÀU (RẤT QUAN TRỌNG)
        // Đây là sự kiện chạy SAU KHI dữ liệu đã tải xong
        private void dgvInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Lặp qua từng hàng (Row) trong DataGridView
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                // Lấy ra ViewModel của hàng đó
                InventoryViewModel item = row.DataBoundItem as InventoryViewModel;

                if (item != null)
                {
                    // Nếu Tình trạng là "Cần nhập hàng"
                    if (item.Status == "Cần nhập hàng")
                    {
                        // Tô màu TOÀN BỘ HÀNG đó sang màu đỏ nhạt
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }
        // Nút "Xuất Báo cáo PDF"
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu đã lọc (copy y hệt code của nút 'Lọc')
            string brand = cboBrandFilter.SelectedItem.ToString();
            bool reorderOnly = chkReorderOnly.Checked;

            // 2. Gọi BUS
            var data = reportBUS.GetInventoryReport(brand, reorderOnly);

            // 3. Chuẩn bị thông tin cho ReportViewer

            // Tên này PHẢI KHỚP với tên Dataset trong .rdlc (Bước 2)
            string dataSetName = "DataSet_TonKho";

            // Tên này PHẢI KHỚP với đường dẫn file .rdlc (đã Embed ở Bước 3)
            string reportPath = "QuanLyBanLaptop_GUI.Reports.BaoCaoTonKho.rdlc";

            // 4. (Mới) Tạo Tham số để hiển thị trên báo cáo
            List<ReportParameter> parameters = new List<ReportParameter>();
            string paramBrand = (cboBrandFilter.SelectedIndex == 0) ? "Tất cả" : brand;
            string paramStatus = (reorderOnly) ? "Chỉ hàng cần nhập" : "Tất cả";

            parameters.Add(new ReportParameter("pHangLoc", paramBrand));
            parameters.Add(new ReportParameter("pTinhTrang", paramStatus));

            // 5. Mở form Report
            // (Chúng ta dùng lại form 'frmReportViewer' vạn năng)
            frmReportViewer reportForm = new frmReportViewer(reportPath, dataSetName, data, parameters);
            reportForm.ShowDialog(); // Mở form xem báo cáo
        }
    }
}