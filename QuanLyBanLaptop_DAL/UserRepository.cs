using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq; // <-- Thêm thư viện này

namespace QuanLyBanLaptop_DAL
{
    public class UserRepository
    {
        private string connectionString;

        public UserRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // --- HÀM 1: LOGIN (Bạn đã có) ---
        public User Login(string username, string password)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
            }
        }

        // --- HÀM 2: LẤY TẤT CẢ USER ---
        public List<User> GetAllUsers()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Users.ToList();
            }
        }

        // --- HÀM 3: LẤY 1 USER BẰNG ID ---
        public User GetUserById(int userID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Users.FirstOrDefault(u => u.UserID == userID);
            }
        }

        // --- HÀM 4: KIỂM TRA TRÙNG USERNAME ---
        public bool IsUsernameTaken(string username)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        // --- HÀM 5: THÊM USER MỚI ---
        public void AddUser(User user)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
            }
        }

        // --- HÀM 6: CẬP NHẬT USER ---
        public void UpdateUser(User userToUpdate)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                User existingUser = context.Users.FirstOrDefault(u => u.UserID == userToUpdate.UserID);
                if (existingUser != null)
                {
                    existingUser.FullName = userToUpdate.FullName;
                    existingUser.Username = userToUpdate.Username;
                    existingUser.Role = userToUpdate.Role;

                    // Chỉ cập nhật mật khẩu nếu nó không rỗng
                    if (!string.IsNullOrEmpty(userToUpdate.PasswordHash))
                    {
                        existingUser.PasswordHash = userToUpdate.PasswordHash;
                    }
                    context.SubmitChanges();
                }
            }
        }

        // --- HÀM 7: XÓA USER ---
        public void DeleteUser(int userID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                User userToDelete = context.Users.FirstOrDefault(u => u.UserID == userID);
                if (userToDelete != null)
                {
                    context.Users.DeleteOnSubmit(userToDelete);
                    context.SubmitChanges();
                }
            }
        }

        // ... (Bạn đã có hàm DeleteUser() ở trên) ...

        // HÀM MỚI 8: Đổi mật khẩu
        public bool ChangePassword(int userID, string oldPassword, string newPassword)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Tìm user
                User user = context.Users.FirstOrDefault(u => u.UserID == userID);
                if (user == null) return false;

                // 2. Kiểm tra mật khẩu cũ
                // (Giả sử chúng ta đang lưu plain text, nên so sánh trực tiếp)
                if (user.PasswordHash != oldPassword)
                {
                    // Ném lỗi để BUS bắt
                    throw new System.Exception("Mật khẩu cũ không chính xác.");
                }

                // 3. Cập nhật mật khẩu mới
                user.PasswordHash = newPassword;
                context.SubmitChanges();
                return true;
            }
        }

        // ... (Bạn đã có hàm ChangePassword() ở trên) ...

        // HÀM MỚI 9: Cập nhật thông tin (Tên, Ảnh)
        public void UpdateProfileInfo(int userID, string newFullName, string newAvatarPath)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                User user = context.Users.FirstOrDefault(u => u.UserID == userID);
                if (user != null)
                {
                    user.FullName = newFullName;

                    // Chỉ cập nhật ảnh nếu có đường dẫn mới
                    if (!string.IsNullOrEmpty(newAvatarPath))
                    {
                        user.AvatarPath = newAvatarPath;
                    }
                    context.SubmitChanges();
                }
            }
        }

        // ... (Bạn đã có hàm ChangePassword() ở trên) ...

        // HÀM MỚI 10: Tìm user bằng Tên đăng nhập VÀ Email
        public User GetUserByUsernameAndEmail(string username, string email)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.Email == email);
            }
        }

        // HÀM MỚI 11: Đặt lại mật khẩu (không cần mật khẩu cũ)
        public void ResetPassword(int userID, string newPassword)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                User user = context.Users.FirstOrDefault(u => u.UserID == userID);
                if (user != null)
                {
                    user.PasswordHash = newPassword; // (Nên HASH mật khẩu)
                    context.SubmitChanges();
                }
            }
        }
    }
}