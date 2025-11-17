using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace QuanLyBanLaptop_DAL
{
    public class CustomerRepository
    {
        // Lấy chuỗi kết nối (Giống các Repository khác)
        private string connectionString;

        public CustomerRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // HÀM MỚI: Lấy tất cả khách hàng
        public List<Customer> GetAllCustomers()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // Dùng LINQ to SQL
                return context.Customers.ToList();
            }
        }
        // ... (Bạn đã có hàm GetAllCustomers() ở trên) ...

        // HÀM MỚI: Tìm kiếm khách hàng
        public List<Customer> SearchCustomers(string name, string phone)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Lấy tất cả khách hàng làm truy vấn gốc
                var query = context.Customers.AsQueryable();

                // 2. Lọc theo Tên (nếu người dùng có nhập tên)
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(c => c.Name.Contains(name));
                }

                // 3. Lọc theo Số điện thoại (nếu người dùng có nhập)
                if (!string.IsNullOrEmpty(phone))
                {
                    // .Contains() cho phép tìm SĐT gần đúng
                    query = query.Where(c => c.Phone.Contains(phone));
                }

                // 4. Thực thi truy vấn
                return query.ToList();
            }
        }

        // ... (Bạn đã có hàm SearchCustomers() ở trên) ...

        // HÀM MỚI 1: Lấy 1 khách hàng bằng ID
        public Customer GetCustomerById(int customerID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Customers.FirstOrDefault(c => c.CustomerID == customerID);
            }
        }

        // HÀM MỚI 2: Thêm khách hàng mới
        public void AddCustomer(Customer customer)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                context.Customers.InsertOnSubmit(customer);
                context.SubmitChanges();
            }
        }

        // HÀM MỚI 3: Cập nhật khách hàng
        public void UpdateCustomer(Customer customerToUpdate)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // Tìm bản ghi gốc
                Customer existingCustomer = context.Customers.FirstOrDefault(c => c.CustomerID == customerToUpdate.CustomerID);
                if (existingCustomer != null)
                {
                    // Cập nhật thuộc tính
                    existingCustomer.Name = customerToUpdate.Name;
                    existingCustomer.Phone = customerToUpdate.Phone;
                    existingCustomer.Email = customerToUpdate.Email;
                    existingCustomer.Address = customerToUpdate.Address;

                    // Lưu thay đổi
                    context.SubmitChanges();
                }
            }
        }

        // ... (Bạn đã có hàm UpdateCustomer() ở trên) ...

        // HÀM MỚI: Xóa một khách hàng
        public void DeleteCustomer(int customerID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Tìm khách hàng cần xóa
                Customer customerToDelete = context.Customers.FirstOrDefault(c => c.CustomerID == customerID);

                if (customerToDelete != null)
                {
                    // 2. Đánh dấu để xóa
                    context.Customers.DeleteOnSubmit(customerToDelete);

                    // 3. Thực thi lệnh DELETE
                    // LƯU Ý: Nếu khách hàng này đã có 'Orders' (đơn hàng),
                    // CSDL sẽ ném lỗi FOREIGN KEY.
                    context.SubmitChanges();
                }
            }
        }

        // ... (Bạn đã có hàm DeleteCustomer() ở trên) ...

        // Tìm khách hàng chính xác theo SĐT
        public Customer GetCustomerByExactPhone(string phone)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Customers.FirstOrDefault(c => c.Phone == phone);
            }
        }


        // (Chúng ta sẽ thêm hàm Search, Add, Update, Delete vào đây sau)
    }
}