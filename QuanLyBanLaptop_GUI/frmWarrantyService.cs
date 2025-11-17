using QuanLyBanLaptop_BUS;
using QuanLyBanLaptop_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmWarrantyService : Form
    {
        private WarrantyBUS warrantyBUS;

        public frmWarrantyService()
        {
            InitializeComponent();
            warrantyBUS = new WarrantyBUS();
            dgvClaims.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmWarrantyService_Load(object sender, EventArgs e)
        {
            LoadStatusFilter();
            LoadClaimsGrid(); // Tải lần đầu
        }

        // Tải ComboBox Trạng thái
        private void LoadStatusFilter()
        {
            var statusList = new List<string> { "[ Tất cả ]", "PENDING", "IN_PROGRESS", "COMPLETED" };
            cboStatusFilter.DataSource = statusList;
        }

        // Hàm tải dữ liệu chính (cho cả Form_Load và nút Lọc)
        private void LoadClaimsGrid()
        {
            string status = cboStatusFilter.SelectedItem.ToString();
            string serial = txtSearchSerial.Text.Trim();

            var claimList = warrantyBUS.SearchClaims(status, serial);

            dgvClaims.DataSource = null;
            dgvClaims.DataSource = claimList;
            ConfigureDataGridView();
        }

        // Cấu hình cột
        private void ConfigureDataGridView()
        {
            dgvClaims.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //if (dgvClaims.Columns.Count > 0)
            //{
            //    dgvClaims.Columns["ClaimID"].HeaderText = "Mã Phiếu";
            //    dgvClaims.Columns["CustomerName"].HeaderText = "Tên Khách hàng";
            //    dgvClaims.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            //    dgvClaims.Columns["SerialNumber"].HeaderText = "Serial #";
            //    dgvClaims.Columns["ReportDate"].HeaderText = "Ngày nhận";
            //    dgvClaims.Columns["Status"].HeaderText = "Trạng thái";
            //    dgvClaims.Columns["IssueDescription"].HeaderText = "Mô tả lỗi";

            //    dgvClaims.Columns["CustomerName"].FillWeight = 150;
            //    dgvClaims.Columns["IssueDescription"].FillWeight = 200;
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
            LoadClaimsGrid(); // Chỉ cần gọi lại hàm tải
        }

        // Nút "Làm mới" (NHỚ NỐI DÂY!)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboStatusFilter.SelectedIndex = 0;
            txtSearchSerial.Text = "";
            LoadClaimsGrid();
        }


        // ... (Bạn đã có hàm btnRefresh_Click ở trên) ...

        // Logic nút "Tạo Phiếu mới"
        private void btnCreateClaim_Click(object sender, EventArgs e)
        {
            frmWarrantyCreate formTao = new frmWarrantyCreate();

            // Nếu formTao đóng với kết quả "OK" (tức là đã Lưu)
            if (formTao.ShowDialog() == DialogResult.OK)
            {
                // Tải lại lưới để thấy phiếu mới
                LoadClaimsGrid();
            }
        }

        // ... (Bạn đã có hàm btnCreateClaim_Click ở trên) ...

        // Logic nút "Cập nhật Phiếu"
        private void btnUpdateClaim_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra chọn hàng
            if (dgvClaims.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu bảo hành cần cập nhật.", "Thông báo");
                return;
            }

            // 2. Lấy ClaimID từ ViewModel
            WarrantyClaimViewModel selectedClaim = (WarrantyClaimViewModel)dgvClaims.SelectedRows[0].DataBoundItem;
            int claimID = selectedClaim.ClaimID;

            // 3. Mở form Sửa và truyền ID vào
            frmWarrantyUpdate formUpdate = new frmWarrantyUpdate(claimID);

            // 4. Nếu form Sửa báo OK (đã Lưu)
            if (formUpdate.ShowDialog() == DialogResult.OK)
            {
                // Tải lại lưới để thấy thay đổi
                LoadClaimsGrid();
            }
        }
    }
}