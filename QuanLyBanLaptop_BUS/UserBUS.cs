using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL;
using System.Net.Mail; // Thư viện gửi mail
using System.Net;       // Thư viện mạng

namespace QuanLyBanLaptop_BUS
{
    public class UserBUS
    {
        private UserRepository repo;
        // BIẾN TẠM ĐỂ LƯU OTP (Username, OTP)
        private static Dictionary<string, string> otpStore = new Dictionary<string, string>();

        public UserBUS()
        {
            repo = new UserRepository();
        }

        // --- HÀM 1: LOGIN (Bạn đã có) ---
        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            // MÃ HÓA Ở ĐÂY (Tầng BUS)
            string hashedPassword = SecurityHelper.HashPassword(password);

            // Gửi chuỗi ĐÃ MÃ HÓA xuống DAL
            return repo.Login(username, hashedPassword);
        }

        // --- HÀM 2: LẤY TẤT CẢ ---
        public List<User> GetAllUsers()
        {
            return repo.GetAllUsers();
        }

        // --- HÀM 3: LẤY 1 USER ---
        public User GetUserById(int userID)
        {
            return repo.GetUserById(userID);
        }

        // --- HÀM 4: THÊM MỚI (VỚI VALIDATION) ---
        // 2. Sửa hàm THÊM USER
        public bool AddUser(User user)
        {
            if (repo.IsUsernameTaken(user.Username))
                throw new System.Exception("Tên đăng nhập này đã tồn tại.");

            // MÃ HÓA MẬT KHẨU
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                user.PasswordHash = SecurityHelper.HashPassword(user.PasswordHash);
            }

            repo.AddUser(user);
            return true;
        }

        // --- HÀM 5: CẬP NHẬT (VỚI VALIDATION) ---
        // 3. Sửa hàm CẬP NHẬT USER
        public bool UpdateUser(User user)
        {
            // Nếu có nhập mật khẩu mới thì mã hóa, không thì thôi
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                user.PasswordHash = SecurityHelper.HashPassword(user.PasswordHash);
            }

            repo.UpdateUser(user);
            return true;
        }

        // --- HÀM 6: XÓA (VỚI VALIDATION) ---
        public bool DeleteUser(int userID, int currentAdminID)
        {
            // 1. Kiểm tra: Không được tự xóa
            if (userID == currentAdminID)
                throw new System.Exception("Không thể tự xóa chính mình.");

            // 2. PHÂN QUYỀN SÂU (MỚI)
            // Lấy thông tin người đang thực hiện hành động này (Admin)
            User currentUser = repo.GetUserById(currentAdminID);
            if (currentUser.Role != "Admin")
            {
                throw new System.Exception("BẢO MẬT: Bạn không có quyền thực hiện chức năng này!");
            }

            repo.DeleteUser(userID);
            return true;
        }

        // ... (Bạn đã có hàm DeleteUser() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để đổi mật khẩu
        public bool ChangePassword(int userID, string oldPass, string newPass, string confirmPass)
        {
            if (string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass))
                throw new System.Exception("Vui lòng nhập đầy đủ.");
            if (newPass != confirmPass)
                throw new System.Exception("Mật khẩu xác nhận không khớp.");

            // Mã hóa cả cũ và mới
            string hashedOldPass = SecurityHelper.HashPassword(oldPass);
            string hashedNewPass = SecurityHelper.HashPassword(newPass);

            return repo.ChangePassword(userID, hashedOldPass, hashedNewPass);
        }
        // ... (Bạn đã có hàm ChangePassword() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để cập nhật thông tin
        public bool UpdateProfileInfo(int userID, string newFullName, string newAvatarPath)
        {
            if (string.IsNullOrWhiteSpace(newFullName))
            {
                throw new System.Exception("Tên đầy đủ không được để trống.");
            }

            // Chỉ cần gọi DAL và trả về
            repo.UpdateProfileInfo(userID, newFullName, newAvatarPath);
            return true;
        }

        // ... (Bạn đã có hàm ChangePassword() ở trên) ...

        // HÀM MỚI 1: Tìm User (gọi DAL)
        public User GetUserByUsernameAndEmail(string username, string email)
        {
            return repo.GetUserByUsernameAndEmail(username, email);
        }

        // HÀM MỚI 2: GỬI EMAIL OTP (Hàm chính)
        public bool SendPasswordResetOTP(User user)
        {
            try
            {
                // 1. Tạo OTP
                Random rand = new Random();
                string otp = rand.Next(100000, 999999).ToString(); // 6 số

                // 2. Cấu hình SMTP (Dùng Gmail)
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;

                // (!!! THAY THÔNG TIN CỦA BẠN VÀO ĐÂY !!!)
                string gmailEmail = "nguyenlengocduy0312@gmail.com";
                string appPassword = "tofkkmkqopimtmph"; //13 số 
                // (!!! KHÔNG PHẢI MẬT KHẨU GMAIL CỦA BẠN !!!)

                client.Credentials = new NetworkCredential(gmailEmail, appPassword);

                // 3. Tạo Nội dung Email
                MailMessage message = new MailMessage();
                message.From = new MailAddress(gmailEmail, "Hệ thống Quản lý Laptop");
                message.To.Add(user.Email);
                message.Subject = "Yêu cầu Đặt lại Mật khẩu";
                message.Body = $"Xin chào {user.FullName},\n\n" +
                               $"Mã OTP để đặt lại mật khẩu của bạn là: {otp}\n\n" +
                               $"Mã này sẽ hết hạn sau 5 phút.\n\n" +
                               $"Trân trọng,\n" +
                               $"Đội ngũ 404 Brain Not Found.";

                // 4. Gửi mail
                client.Send(message);

                // 5. Lưu OTP (tạm thời)
                otpStore[user.Username] = otp;
                return true;
            }
            catch (Exception ex)
            {
                // Ném lỗi ra để GUI bắt
                throw new Exception($"Lỗi khi gửi email: {ex.Message}");
            }
        }

        // HÀM MỚI 3: Xác minh OTP
        public bool VerifyOTP(string username, string otp)
        {
            if (otpStore.ContainsKey(username) && otpStore[username] == otp)
            {
                otpStore.Remove(username); // Xóa OTP sau khi dùng
                return true;
            }
            return false;
        }

        // HÀM MỚI 4: Đặt lại Mật khẩu (gọi DAL)
        public void ResetPassword(int userID, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword) throw new Exception("Không khớp.");

            string hashedNew = SecurityHelper.HashPassword(newPassword);
            repo.ResetPassword(userID, hashedNew);
        }
    }
}