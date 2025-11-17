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
    public partial class frmUserEdit : Form
    {
        private UserBUS userBUS;
        private int? currentUserID = null;

        // Constructor 1: Thêm mới
        public frmUserEdit()
        {
            InitializeComponent();
            userBUS = new UserBUS();
            this.Text = "Thêm Người dùng mới";
        }

        // Constructor 2: Sửa
        public frmUserEdit(int userID)
        {
            InitializeComponent();
            userBUS = new UserBUS();
            this.currentUserID = userID;
            this.Text = "Sửa thông tin Người dùng";
            btnSave.Text = "Cập nhật";
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            LoadRoleComboBox();

            if (currentUserID != null)
            {
                LoadUserData();
            }
        }

        // Tải các Quyền (Role)
        private void LoadRoleComboBox()
        {
            cboRole.Items.Add("Admin");
            cboRole.Items.Add("Staff");
            cboRole.Items.Add("Technician");
            cboRole.SelectedIndex = 1; // Mặc định là Staff
        }

        // Tải dữ liệu khi Sửa
        private void LoadUserData()
        {
            User user = userBUS.GetUserById(currentUserID.Value);
            if (user != null)
            {
                txtFullName.Text = user.FullName;
                txtUsername.Text = user.Username;
                cboRole.SelectedItem = user.Role;

                // SỬA LỖI: Dùng hàm txtPassword_Leave để gán placeholder
                txtPassword_Leave(null, null);
            }
        }

        // Nút Hủy (NHỚ NỐI DÂY!)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Nút Lưu (NHỚ NỐI DÂY!)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || cboRole.SelectedItem == null)
            {
                MessageBox.Show("Tên đăng nhập và Quyền không được để trống.", "Lỗi");
                return;
            }

            try
            {
                if (currentUserID == null) // Chế độ THÊM MỚI
                {

                    User newUser = new User
                    {
                        FullName = txtFullName.Text.Trim(),
                        Username = txtUsername.Text.Trim(),
                        Role = cboRole.SelectedItem.ToString()
                    };
                    userBUS.AddUser(newUser);
                    MessageBox.Show("Thêm người dùng mới thành công!");
                }
                else // Chế độ CẬP NHẬT
                {
                    User updatedUser = new User
                    {
                        UserID = currentUserID.Value,
                        FullName = txtFullName.Text.Trim(),
                        Username = txtUsername.Text.Trim(),
                        // SỬA LỖI: Gửi chuỗi rỗng nếu là placeholder
                        Role = cboRole.SelectedItem.ToString()
                    };
                    userBUS.UpdateUser(updatedUser);
                    MessageBox.Show("Cập nhật thông tin thành công!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================================================
        // ▼▼▼ THÊM 2 HÀM SỰ KIỆN MỚI NÀY VÀO ▼▼▼
        // =======================================================

        // Sự kiện khi BẤM VÀO ô Mật khẩu
        private void txtPassword_Enter(object sender, EventArgs e)
        {

        }

        // Sự kiện khi BẤM RA NGOÀI ô Mật khẩu
        private void txtPassword_Leave(object sender, EventArgs e)
        {

        }
    }
}