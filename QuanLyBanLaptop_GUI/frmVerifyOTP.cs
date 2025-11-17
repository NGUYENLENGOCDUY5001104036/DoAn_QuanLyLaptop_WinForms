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
    public partial class frmVerifyOTP : Form
    {
        private UserBUS userBUS;
        private User userToReset; // Biến lưu User

        // Constructor (Hàm khởi tạo) nhận User
        public frmVerifyOTP(User user)
        {
            InitializeComponent();
            userBUS = new UserBUS();
            this.userToReset = user;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string otp = txtOTP.Text.Trim();
            bool isValid = userBUS.VerifyOTP(userToReset.Username, otp);

            if (isValid)
            {
                MessageBox.Show("Xác minh OTP thành công!");

                // Mở form Đặt lại Mật khẩu
                frmResetPassword formReset = new frmResetPassword(userToReset);
                this.Hide();
                formReset.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng hoặc đã hết hạn.", "Lỗi");
            }
        }

        private void frmVerifyOTP_Load(object sender, EventArgs e)
        {

        }
    }
}