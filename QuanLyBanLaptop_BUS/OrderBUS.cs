using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL; // Thêm using

namespace QuanLyBanLaptop_BUS
{
    public class OrderBUS
    {
        private OrderRepository repo;

        public OrderBUS()
        {
            repo = new OrderRepository();
        }

        // Hàm 1:
        public List<Order> GetOrdersByCustomer(int customerID)
        {
            return repo.GetOrdersByCustomer(customerID);
        }

        // Hàm 2:
        public List<OrderDetailViewModel> GetOrderDetails(int orderID)
        {
            return repo.GetOrderDetails(orderID);
        }

        // ... (Bạn đã có hàm GetOrderDetails() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để tạo đơn hàng
        public int CreateNewOrder(int customerID, int createdByUserID, decimal totalAmount, List<OrderDetailViewModel> cartItems)
        {
            // 1. Tạo đối tượng Order (cha)
            Order newOrder = new Order
            {
                CustomerID = customerID,
                CreatedBy = createdByUserID, // Lấy từ thông tin đăng nhập
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                Status = "COMPLETED" // Mặc định là Hoàn thành (hoặc "PENDING" nếu cần)
            };

            // 2. Gọi DAL để lưu (DAL sẽ lo phần Transaction)
            return repo.CreateNewOrder(newOrder, cartItems);
        }

        // ... (Bạn đã có hàm CreateNewOrder() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để lọc danh sách đơn hàng
        public List<OrderViewModel> SearchOrders(DateTime fromDate, DateTime toDate, int customerID)
        {
            return repo.SearchOrders(fromDate, toDate, customerID);
        }
    }
}
