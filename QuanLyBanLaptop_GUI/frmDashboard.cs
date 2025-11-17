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
using System.Windows.Forms.DataVisualization.Charting; // Thêm thư viện Chart

namespace QuanLyBanLaptop_GUI
{
    public partial class frmDashboard : Form
    {
        private ReportBUS reportBUS;

        public frmDashboard()
        {
            InitializeComponent();
            reportBUS = new ReportBUS();

            // ▼▼▼ THÊM DÒNG NÀY ▼▼▼
            dgvInventoryDetails.AutoGenerateColumns = false;
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY BẰNG TAY!)
        // Sự kiện Form_Load (NHỚ NỐI DÂY BẰNG TAY!)
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // =======================================================
            // ▼▼▼ THÊM KHỐI PHÂN QUYỀN NÀY VÀO ▼▼▼
            // =======================================================
            if (Program.CurrentUser.Role == "Staff")
            {
                // Nếu là Nhân viên (Staff)
                // Ẩn cả 2 biểu đồ (hoặc 1 trong 2)
                splitContainer1.Panel1.Visible = false; // Ẩn Panel chứa biểu đồ Doanh thu
                splitContainer1.Panel2.Visible = false; // Ẩn Panel chứa biểu đồ Tồn kho

                // (Bạn có thể thêm 1 Label "Chào mừng..." vào giữa form)
            }
            else
            {
                // Nếu là Admin (hoặc vai trò khác)
                // Tải cả 2 biểu đồ
                LoadSalesChart();
                LoadInventoryChart();
            }
        }

        private void LoadSalesChart()
        {
            try
            {
                // 1. Lấy dữ liệu (30 ngày qua)
                DateTime endDate = DateTime.Now;
                DateTime startDate = endDate.AddDays(-30);
                var salesData = reportBUS.GetSalesByDate(startDate, endDate);

                // 2. Cấu hình biểu đồ
                chartSales.Series.Clear(); // Xóa series "Series1" mặc định
                chartSales.ChartAreas[0].AxisX.Title = "Ngày";
                chartSales.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                chartSales.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM"; // Format ngày
                chartSales.Titles.Add("Doanh thu 30 ngày qua"); // Thêm tiêu đề

                // ▼▼▼ THÊM DÒNG NÀY VÀO ▼▼▼
                chartSales.ChartAreas[0].AxisY.LabelStyle.Format = "N0"; // Format số thành "150,000,000"

                // 3. Tạo một Series (dòng dữ liệu) mới
                Series series = new Series("Doanh thu")
                {
                    ChartType = SeriesChartType.Spline, // <-- ĐỔI THÀNH "Spline"
                    MarkerStyle = MarkerStyle.Circle, // Thêm dòng này để thấy rõ các điểm
                    MarkerSize = 8,                 // Thêm dòng này
                    XValueMember = "Date",
                    YValueMembers = "TotalSales",
                    IsValueShownAsLabel = true
                };
                series.LabelFormat = "N0";

                // 4. Gán dữ liệu vào biểu đồ
                chartSales.DataSource = salesData;
                chartSales.Series.Add(series);
                chartSales.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ: {ex.Message}");
            }
        }

        // ... (Hàm LoadSalesChart() của bạn ở trên) ...
        // HÀM MỚI: Tải biểu đồ Tồn kho (Đã nâng cấp)
        private void LoadInventoryChart()
        {
            try
            {
                // 1. Lấy dữ liệu (như cũ)
                var stockData = reportBUS.GetStockByBrand();

                // 2. Cấu hình
                chartInventory.Series.Clear();

                // ▼▼▼ SỬA TIÊU ĐỀ Ở ĐÂY ▼▼▼
                string homNay = DateTime.Now.ToString("dd/MM/yyyy");
                chartInventory.Titles.Add($"Tỷ lệ Tồn kho (Tính đến {homNay})");

                // ▼▼▼ THÊM 2 DÒNG NÀY ĐỂ BẬT BẢNG CHÚ THÍCH (LEGEND) ▼▼▼
                chartInventory.Legends[0].Enabled = true;
                chartInventory.Legends[0].Docking = Docking.Right; // Đặt nó ở bên phải

                // 3. Tạo Series
                Series series = new Series("Tồn kho")
                {
                    ChartType = SeriesChartType.Pie,
                    XValueMember = "Brand",
                    YValueMembers = "StockCount",
                    IsValueShownAsLabel = true, // Hiển thị nhãn trên biểu đồ

                    // ▼▼▼ SỬA DÒNG NÀY ĐỂ HIỆN % ▼▼▼
                    Label = "#VALX (#PERCENT{P0})", // Hiển thị: "Dell (18%)"

                    // ▼▼▼ THÊM DÒNG NÀY ĐỂ LIÊN KẾT VỚI BẢNG CHÚ THÍCH ▼▼▼
                    LegendText = "#VALX (#VALY chiếc)" // Hiển thị trong chú thích: "Dell (20 chiếc)"
                };

                // 4. Gán dữ liệu (như cũ)
                chartInventory.DataSource = stockData;
                chartInventory.Series.Add(series);
                chartInventory.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ Tồn kho: {ex.Message}");
            }
            // Cho phép click vào biểu đồ
            chartInventory.Series[0]["PieLabelStyle"] = "Inside";
            chartInventory.Series[0].BorderWidth = 1;
            chartInventory.Series[0].BorderColor = System.Drawing.Color.White;
        }
        private void chartInventory_MouseClick(object sender, MouseEventArgs e)
        {
            // 1. Xác định điểm được click (Hit Test)
            var hit = chartInventory.HitTest(e.X, e.Y);

            // 2. Kiểm tra nếu click vào một miếng bánh (DataPoint)
            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                // 3. Lấy tên Hãng từ điểm đó
                // (Lấy từ AxisLabel hoặc LegendText mà ta đã gán)
                var dataPoint = chartInventory.Series[0].Points[hit.PointIndex];
                string brandName = dataPoint.AxisLabel; // Lấy tên Hãng (VD: "Dell")

                // 4. Gọi BUS để lấy chi tiết
                LoadStockDetails(brandName);
            }
        }

        // Hàm tải bảng chi tiết
        // Hàm tải bảng chi tiết
        private void LoadStockDetails(string brand)
        {
            // 1. Lấy dữ liệu
            var details = reportBUS.GetStockDetailsByBrand(brand);

            // 2. Gán DataSource
            dgvInventoryDetails.DataSource = details;

            // (XÓA HẾT CÁC DÒNG dgvInventoryDetails.Columns["..."].HeaderText = ... Ở ĐÂY)
        }
    }
}