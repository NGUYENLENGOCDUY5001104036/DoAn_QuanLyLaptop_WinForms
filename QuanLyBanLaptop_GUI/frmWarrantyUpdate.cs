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

namespace QuanLyBanLaptop_GUI
{
    public partial class frmWarrantyUpdate : Form
    {
        private WarrantyBUS warrantyBUS;
        private int currentClaimID;

        // Constructor nhận ClaimID
        public frmWarrantyUpdate(int claimID)
        {
            InitializeComponent();
            warrantyBUS = new WarrantyBUS();
            this.currentClaimID = claimID;
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY SỰ KIỆN!)
        private void frmWarrantyUpdate_Load(object sender, EventArgs e)
        {
            // Tải ComboBox Status
            var statusList = new List<string> { "PENDING", "IN_PROGRESS", "COMPLETED" };
            cboStatus.DataSource = statusList;

            // Tải dữ liệu cũ của phiếu
            LoadClaimData();
        }

        // Hàm tải dữ liệu cũ
        private void LoadClaimData()
        {
            // Gọi BUS lấy ViewModel
            WarrantyClaimViewModel claim = warrantyBUS.GetClaimViewModelById(currentClaimID);
            if (claim == null)
            {
                MessageBox.Show("Không tìm thấy phiếu bảo hành!", "Lỗi");
                this.Close();
                return;
            }

            // Đổ dữ liệu vào các Labels (bạn phải đặt tên Label đúng)
            lblProductName.Text = claim.ProductName;
            lblCustomerName.Text = claim.CustomerName;
            lblSerialNumber.Text = claim.SerialNumber;
            lblIssue.Text = claim.IssueDescription;

            // Đổ dữ liệu vào các control (để sửa)
            cboStatus.SelectedItem = claim.Status;
            txtResolution.Text = claim.Resolution; // Tự động là "" nếu resolution là null
        }

        // Nút "Hủy" (NHỚ NỐI DÂY SỰ KIỆN!)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Nút "Lưu" (NHỚ NỐI DÂY SỰ KIỆN!)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu mới
            string newStatus = cboStatus.SelectedItem.ToString();
            string resolution = txtResolution.Text.Trim();

            // 2. Validation
            if (newStatus == "COMPLETED" && string.IsNullOrWhiteSpace(resolution))
            {
                MessageBox.Show("Vui lòng nhập 'Giải pháp' trước khi hoàn thành phiếu.", "Lỗi");
                txtResolution.Focus();
                return;
            }

            // 3. Gọi BUS để lưu
            try
            {
                warrantyBUS.UpdateClaim(currentClaimID, newStatus, resolution);
                MessageBox.Show("Cập nhật phiếu bảo hành thành công!", "Thông báo");

                this.DialogResult = DialogResult.OK; // Báo thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi CSDL");
            }
        }
    }
}