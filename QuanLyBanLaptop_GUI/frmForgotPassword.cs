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
    public partial class frmForgotPassword : Form
    {
        private UserBUS userBUS;
        public frmForgotPassword()
        {
            InitializeComponent();
            userBUS = new UserBUS();
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Email.");
                return;
            }

            try
            {
                User user = userBUS.GetUserByUsernameAndEmail(username, email);
                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc Email không đúng.", "Lỗi");
                    return;
                }

                // Gửi OTP
                bool sent = userBUS.SendPasswordResetOTP(user);
                if (sent)
                {
                    MessageBox.Show($"Một mã OTP đã được gửi đến email {user.Email}. Vui lòng kiểm tra.");

                    // Mở form Xác minh
                    frmVerifyOTP formVerify = new frmVerifyOTP(user);
                    this.Hide();
                    formVerify.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Gửi Email");
            }
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {

        }
    }
}