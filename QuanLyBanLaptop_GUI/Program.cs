using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanLaptop_DAL; // <-- THÊM DÒNG NÀY
using System.IO; // <-- THÊM DÒNG NÀY

namespace QuanLyBanLaptop_GUI
{
    static class Program
    {
        // =======================================================
        // BIẾN TOÀN CỤC: Lưu thông tin người dùng đang đăng nhập
        public static User CurrentUser = null;
        // =======================================================

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // =======================================================
            // THÊM 2 DÒNG NÀY VÀO:
            // 1. Xác định đường dẫn thư mục "Avatars"
            string avatarFolderPath = Path.Combine(Application.StartupPath, "Avatars");
            // 2. Tạo thư mục nếu nó chưa tồn tại
            Directory.CreateDirectory(avatarFolderPath);
            // =======================================================

            bool keepRunning = true;
            while (keepRunning)
            {
                // 1. Luôn mở frmLogin trước
                frmLogin loginForm = new frmLogin();
                DialogResult loginResult = loginForm.ShowDialog();

                // 2. Kiểm tra kết quả
                // Nếu đăng nhập thành công (DialogResult.OK)
                if (loginResult == DialogResult.OK)
                {
                    // 3. Mới chạy form Main
                    // frmMain sẽ chạy cho đến khi nó bị đóng (do Đăng xuất hoặc Thoát)
                    Application.Run(new frmMain());

                    // Sau khi frmMain đóng, chúng ta reset CurrentUser
                    CurrentUser = null;

                    // Vòng lặp 'while' sẽ quay lại và mở frmLogin
                }
                else
                {
                    // Nếu frmLogin bị đóng (nhấn "Thoát" hoặc nút X)
                    keepRunning = false; // Dừng vòng lặp
                }
            }
            // Ứng dụng kết thúc
        }
    }
}