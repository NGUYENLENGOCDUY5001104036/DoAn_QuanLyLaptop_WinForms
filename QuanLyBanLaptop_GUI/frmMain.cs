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
using Microsoft.Reporting.WinForms;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmMain : Form
    {
        private ReportBUS reportBUS; 
        public frmMain()
        {
            InitializeComponent();

            reportBUS = new ReportBUS(); 

            this.Load += new System.EventHandler(this.frmMain_Load);
        }

        // HÀM MỚI: Tự động mở Dashboard khi frmMain được tải
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Chào mừng người dùng
            this.Text = $"HỆ THỐNG QUẢN LÝ - Chào, {Program.CurrentUser.FullName} ({Program.CurrentUser.Role})";

            // Phân quyền
            if (Program.CurrentUser.Role == "Staff")
            {
                // Ẩn các chức năng của Admin
                mniTaoPhieuNhap.Visible = false;     // Nhập kho
                mniQuanLySanPham.Visible = false;  // Sửa giá
                báoCáoToolStripMenuItem.Visible = false; // Xem báo cáo
                mniQuanLyNhaCungCap.Visible = false;
                mniSettings.Visible = false;
            }


            // Phân quyền
            if (Program.CurrentUser.Role == "Staff")
            {
                mniTaoPhieuNhap.Visible = false;
                mniQuanLySanPham.Visible = false;
                báoCáoToolStripMenuItem.Visible = false;
                mniQuanLyNguoiDung.Visible = false;
            }
            OpenChildForm(new frmDashboard());
        }

        private void OpenChildForm(Form childForm)
        {

            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == childForm.GetType())
                {

                    form.Activate();
                    return;
                }
            }

            // 2. Nếu chưa tồn tại, tạo nó
            childForm.MdiParent = this; 
            childForm.Show(); 
        }

        // --- CÁC SỰ KIỆN CLICK MENU ---

        // "Tạo Đơn Bán Hàng"
        private void mniTaoDonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrderCreate());
        }

        // "Quản lý Sản phẩm"
        private void mniQuanLySanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProductList());
        }

        // "Quản lý Kho (Serial)"
        private void mniQuanLyKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDeviceUnits());
        }

        // "Quản lý Khách hàng"
        private void mniQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCustomerManagement());
        }

        // "Thoát"
        private void mniThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        // Danh sách đơn hàng
        private void mniOrderList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrderList());
        }

        // Quản lý bảo hành
        private void mniWarranty_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmWarrantyService());
        }

        // Tạo phiếu nhập kho
        private void mniTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            // THÊM DÒNG NÀY:
            OpenChildForm(new frmPurchaseOrder());
        }

        // Báo cáo - Dashboard
        private void darToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard());
        }

        // Nút Đăng xuất
        private void mniDangXuat_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Chỉ cần đóng frmMain
                // Vòng lặp trong Program.cs sẽ lo việc mở lại frmLogin
                this.Close();
            }
        }

        // Quản lý người dùng (Admin only)
        private void mniQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmUserManagement());
        }


        // Hồ sơ của tôi
        private void mniMyProfile_Click(object sender, EventArgs e)
        {
            // Dùng ShowDialog vì đây là form cài đặt
            frmMyProfile formProfile = new frmMyProfile();
            formProfile.ShowDialog();
        }

        // Quản lý Nhà cung cấp
        private void mniQuanLyNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSupplierManagement());
        }

        // Báo cáo - Tồn kho    
        private void mniBaoCaoTonKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInventory());
        }

        // Cài đặt hệ thống
        private void mniSettings_Click(object sender, EventArgs e)
        {
            frmSettings formSettings = new frmSettings();
            formSettings.ShowDialog();
        }

        // Nút "Top 5 Bán chạy"
        private void mniTopSelling_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Gọi BUS lấy dữ liệu
                var data = reportBUS.GetTopSellingProducts(5); // Lấy Top 5

                // 2. Chuẩn bị thông tin
                string dataSetName = "DataSet_TopSanPham";
                string reportPath = "QuanLyBanLaptop_GUI.Reports.BaoCaoTopSanPham.rdlc";

                // 3. Mở form ReportViewer
                frmReportViewer reportForm = new frmReportViewer(reportPath, dataSetName, data);
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}");
            }
        }
    }
}