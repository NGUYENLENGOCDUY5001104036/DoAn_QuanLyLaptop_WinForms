using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL; // Thêm 'using' này

namespace QuanLyBanLaptop_BUS
{
    public class CustomerBUS
    {
        private CustomerRepository repo;

        public CustomerBUS()
        {
            repo = new CustomerRepository();
        }

        // Hàm cho GUI gọi
        public List<Customer> GetAllCustomers()
        {
            return repo.GetAllCustomers();
        }

        // ... (Bạn đã có hàm GetAllCustomers() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để tìm kiếm
        public List<Customer> SearchCustomers(string name, string phone)
        {
            return repo.SearchCustomers(name, phone);
        }

        // ... (Bạn đã có hàm SearchCustomers() ở trên) ...

        // HÀM MỚI 1: Cho GUI gọi để lấy chi tiết
        public Customer GetCustomerById(int customerID)
        {
            return repo.GetCustomerById(customerID);
        }

        // HÀM MỚI 2: Cho GUI gọi để thêm
        public void AddCustomer(Customer customer)
        {
            // (Bạn có thể thêm logic kiểm tra SĐT, Email ở đây)
            repo.AddCustomer(customer);
        }

        // HÀM MỚI 3: Cho GUI gọi để cập nhật
        public void UpdateCustomer(Customer customer)
        {
            repo.UpdateCustomer(customer);
        }

        // ... (Bạn đã có hàm UpdateCustomer() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để xóa
        public void DeleteCustomer(int customerID)
        {
            // Tầng BUS chỉ cần gọi DAL
            // Mọi lỗi (như lỗi khóa ngoại) sẽ được ném lên cho GUI xử lý
            repo.DeleteCustomer(customerID);
        }

        // ... (Bạn đã có hàm DeleteCustomer() ở trên) ...

        public Customer GetCustomerByExactPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return null;
            return repo.GetCustomerByExactPhone(phone);
        }
    }
}
