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
    public partial class frmResetPassword : Form
    {
        private UserBUS userBUS;
        private User userToReset; // Biến lưu User

        // Constructor (Hàm khởi tạo) nhận User
        public frmResetPassword(User user)
        {
            InitializeComponent();
            userBUS = new UserBUS();
            this.userToReset = user;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            try
            {
                userBUS.ResetPassword(userToReset.UserID, newPass, confirmPass);
                MessageBox.Show("Đặt lại mật khẩu thành công! Vui lòng đăng nhập.", "Thành công");
                this.Close(); // Đóng form này, quay lại frmLogin
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}