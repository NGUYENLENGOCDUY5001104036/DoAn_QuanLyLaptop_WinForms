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
using QuanLyBanLaptop_DAL; // Thêm

namespace QuanLyBanLaptop_GUI
{
    public partial class frmUserManagement : Form
    {
        private UserBUS userBUS;

        public frmUserManagement()
        {
            InitializeComponent();
            userBUS = new UserBUS();
            dgvUsers.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            LoadUserGrid();
        }

        // Tải lưới
        private void LoadUserGrid()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = userBUS.GetAllUsers();
            ConfigureDataGridView();
        }

        // Cấu hình cột
        private void ConfigureDataGridView()
        {
            // ▼▼▼ THÊM DÒNG NÀY VÀO ĐÂY ▼▼▼
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //if (dgvUsers.Columns.Count == 0) return;
            //dgvUsers.Columns["PasswordHash"].Visible = false; // Ẩn mật khẩu
            ////dgvUsers.Columns["Orders"].Visible = false;
            ////dgvUsers.Columns["AuditLogs"].Visible = false;

            //dgvUsers.Columns["FullName"].HeaderText = "Tên đầy đủ";
            //dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
            //dgvUsers.Columns["Role"].HeaderText = "Quyền";
        }

        // Nút Đóng (NHỚ NỐI DÂY!)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút Thêm mới (NHỚ NỐI DÂY!)
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmUserEdit formThem = new frmUserEdit();
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadUserGrid(); // Tải lại
            }
        }

        // Nút Sửa (NHỚ NỐI DÂY!)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userID = (int)dgvUsers.SelectedRows[0].Cells["UserID"].Value;

            frmUserEdit formSua = new frmUserEdit(userID);
            if (formSua.ShowDialog() == DialogResult.OK)
            {
                LoadUserGrid(); // Tải lại
            }
        }

        // Nút Xóa (NHỚ NỐI DÂY!)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userID = (int)dgvUsers.SelectedRows[0].Cells["UserID"].Value;
            string userName = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa '{userName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                // Lấy ID của Admin đang đăng nhập
                int currentAdminID = Program.CurrentUser.UserID;

                // Gọi BUS (BUS sẽ kiểm tra logic không cho tự xóa)
                userBUS.DeleteUser(userID, currentAdminID);

                MessageBox.Show("Xóa thành công.");
                LoadUserGrid(); // Tải lại
            }
            catch (Exception ex)
            {
                // Bắt lỗi (VD: Tự xóa, hoặc xóa user đã tạo Đơn hàng)
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}