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

namespace QuanLyBanLaptop_GUI
{
    public partial class frmWarrantyCreate : Form
    {
        // Khai báo 2 BUS
        private DeviceUnitBUS unitBUS;
        private WarrantyBUS warrantyBUS;

        // Biến để lưu trữ máy tìm được
        private DeviceUnit foundUnit;

        public frmWarrantyCreate()
        {
            InitializeComponent();
            unitBUS = new DeviceUnitBUS();
            warrantyBUS = new WarrantyBUS();
        }

        // Nút "Hủy" (NHỚ NỐI DÂY SỰ KIỆN!)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút "Tìm" (NHỚ NỐI DÂY SỰ KIỆN!)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string serial = txtSearchSerial.Text.Trim();
            if (string.IsNullOrEmpty(serial))
            {
                MessageBox.Show("Vui lòng nhập Serial Number để tìm.", "Thông báo");
                return;
            }

            // Gọi BUS để tìm
            // Chúng ta cần lấy cả thông tin Product và Customer đi kèm
            foundUnit = unitBUS.GetSoldUnitBySerial(serial);

            if (foundUnit == null)
            {
                MessageBox.Show("Không tìm thấy Serial Number này, hoặc máy chưa được bán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpThongTin.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                // TÌM THẤY!
                grpThongTin.Enabled = true;
                btnSave.Enabled = true;

                // ▼▼▼ THÊM DÒNG NÀY ▼▼▼
                llbViewProof.Visible = true; // Hiện link xác thực
                // ▲▲▲

                // Tải dữ liệu vào các Label
                lblProductName.Text = foundUnit.Product.Name;
                lblCustomerName.Text = foundUnit.Customer.Name;

                // Kiểm tra Hạn bảo hành
                if (foundUnit.WarrantyEndDate != null && foundUnit.WarrantyEndDate >= DateTime.Now)
                {
                    lblWarrantyStatus.Text = $"Còn Hạn (đến {foundUnit.WarrantyEndDate.Value.ToString("dd/MM/yyyy")})";
                    lblWarrantyStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblWarrantyStatus.Text = $"Hết Hạn (từ {foundUnit.WarrantyEndDate.Value.ToString("dd/MM/yyyy")})";
                    lblWarrantyStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        // Nút "Lưu" (NHỚ NỐI DÂY SỰ KIỆN!)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra (Validation)
            if (foundUnit == null) // Kiểm tra lại
            {
                MessageBox.Show("Chưa tìm thấy thiết bị hợp lệ.", "Lỗi");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtIssueDescription.Text))
            {
                MessageBox.Show("Vui lòng nhập Mô tả lỗi của khách hàng.", "Lỗi");
                txtIssueDescription.Focus();
                return;
            }

            // 2. Lấy thông tin
            int unitID = foundUnit.UnitID;
            int customerID = foundUnit.CurrentCustomerID.Value; // Lấy ID khách hàng từ máy
            string issue = txtIssueDescription.Text.Trim();

            // 3. Gọi BUS để lưu
            try
            {
                warrantyBUS.CreateNewClaim(unitID, customerID, issue);
                MessageBox.Show("Tạo phiếu bảo hành mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // Báo thành công
                this.Close(); // Đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu bảo hành: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmWarrantyCreate_Load(object sender, EventArgs e)
        {

        }
        // Sự kiện nhấn link "Xem Hóa đơn gốc"
        private void llbViewProof_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Lấy serial đang hiển thị
            string serial = txtSearchSerial.Text.Trim();

            // 2. Gọi ReportBUS (Bạn cần khai báo ReportBUS ở đầu form nếu chưa có)
            // Khai báo tạm ở đây cũng được nếu bạn lười sửa constructor
            ReportBUS reportBUS = new ReportBUS();
            var data = reportBUS.GetWarrantyProof(serial);

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu hóa đơn gốc (Có thể máy này được nhập cũ mà không qua đơn hàng).");
                return;
            }

            // 3. Mở Report Viewer
            string dataSetName = "DataSet_ChungNhan";
            string reportPath = "QuanLyBanLaptop_GUI.Reports.BaoCaoChungNhan.rdlc";

            // Dùng form xem báo cáo chung
            frmReportViewer viewer = new frmReportViewer(reportPath, dataSetName, data);
            viewer.Text = "Xác thực Bảo hành"; // Đổi tên cửa sổ
            viewer.ShowDialog();
        }
    }
}