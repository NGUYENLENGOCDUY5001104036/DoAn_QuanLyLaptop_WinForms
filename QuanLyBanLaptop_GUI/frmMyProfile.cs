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
using System.IO; // <-- THÊM THƯ VIỆN NÀY

namespace QuanLyBanLaptop_GUI
{
    public partial class frmMyProfile : Form
    {
        private UserBUS userBUS;

        // Biến tạm để lưu đường dẫn ảnh mới (sau khi copy)
        private string _newAvatarPath = null;

        public frmMyProfile()
        {
            InitializeComponent();
            userBUS = new UserBUS();
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmMyProfile_Load(object sender, EventArgs e)
        {
            if (Program.CurrentUser != null)
            {
                // Tải thông tin vào TextBox và Labels
                txtFullName.Text = Program.CurrentUser.FullName;
                lblUsername.Text = Program.CurrentUser.Username;
                lblRole.Text = Program.CurrentUser.Role;

                // Tải ảnh đại diện (nếu có)
                if (!string.IsNullOrEmpty(Program.CurrentUser.AvatarPath))
                {
                    // Lấy đường dẫn đầy đủ
                    string fullPath = Path.Combine(Application.StartupPath, Program.CurrentUser.AvatarPath);
                    if (File.Exists(fullPath))
                    {
                        picAvatar.ImageLocation = fullPath;
                    }
                }
            }
            else
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng.");
                this.Close();
            }
        }

        // Nút "Đóng" (NHỚ NỐI DÂY!)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút "Lưu Thông tin" (NHỚ NỐI DÂY!)
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                userBUS.UpdateProfileInfo(
                    Program.CurrentUser.UserID,
                    txtFullName.Text.Trim(),
                    _newAvatarPath // Sẽ là 'null' nếu không đổi ảnh
                );

                // THÊM LOGIC CẬP NHẬT VÀO ĐÂY:
                Program.CurrentUser.FullName = txtFullName.Text.Trim();
                if (_newAvatarPath != null)
                {
                    Program.CurrentUser.AvatarPath = _newAvatarPath;
                }

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                _newAvatarPath = null; // Reset
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút "Đổi Mật khẩu" (NHỚ NỐI DÂY!)
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // (Code này y như cũ)
            string oldPass = txtOldPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            try
            {
                int currentUserID = Program.CurrentUser.UserID;
                bool success = userBUS.ChangePassword(currentUserID, oldPass, newPass, confirmPass);

                if (success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công");
                    // Xóa trống các ô
                    txtOldPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút "Đổi ảnh..." (LinkLabel - NHỚ NỐI DÂY!)
        private void llbChangeAvatar_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Cấu hình hộp thoại chọn file
            openFileDialog1.Title = "Chọn ảnh đại diện";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            // 2. Mở hộp thoại
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Lấy file người dùng chọn
                    string sourceFilePath = openFileDialog1.FileName;

                    // 4. Tạo tên file mới (duy nhất) để tránh trùng
                    string extension = Path.GetExtension(sourceFilePath);
                    string newFileName = Guid.NewGuid().ToString() + extension;

                    // 5. Tạo đường dẫn đích (vào thư mục "Avatars" của bạn)
                    string destPath = Path.Combine(Application.StartupPath, "Avatars", newFileName);

                    // 6. Copy file
                    File.Copy(sourceFilePath, destPath);

                    // 7. Lưu đường dẫn (tương đối) và hiển thị
                    _newAvatarPath = "Avatars\\" + newFileName; // "Avatars\guid-1234.jpg"
                    picAvatar.ImageLocation = destPath; // Hiển thị ảnh mới
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}