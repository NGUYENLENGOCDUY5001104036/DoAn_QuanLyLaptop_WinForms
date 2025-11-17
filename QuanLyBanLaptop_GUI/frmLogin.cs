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

namespace QuanLyBanLaptop_GUI
{
    public partial class frmLogin : Form
    {
        private UserBUS userBUS;
        public frmLogin()
        {
            InitializeComponent();
            userBUS = new UserBUS();
        }

        // Nút Thoát
        // (Cách tạo: Mở [Design], nhấp đúp vào nút "Thoát")
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát toàn bộ chương trình
        }

        // Nút Đăng nhập
        // (Cách tạo: Mở [Design], nhấp đúp vào nút "Đăng nhập")
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            User user = userBUS.Login(username, password);

            // Kiểm tra kết quả
            if (user != null)
            {
                // ĐĂNG NHẬP THÀNH CÔNG
                MessageBox.Show($"Đăng nhập thành công! Xin chào {user.FullName}.", "Thông báo");

                // =======================================================
                // LƯU USER VÀO BIẾN TOÀN CỤC
                Program.CurrentUser = user;
                // =======================================================

                // (Không cần MessageBox ở đây nữa, frmMain sẽ chào)
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // ĐĂNG NHẬP THẤT BẠI
                MessageBox.Show("Sai Tên đăng nhập hoặc Mật khẩu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        // LinkLabel Quên mật khẩu
        private void llbForgotPassword_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgotPassword formQuen = new frmForgotPassword();
            formQuen.ShowDialog();
        }
    }
}