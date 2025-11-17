using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QuanLyBanLaptop_DAL
{
    public class OrderRepository
    {
        private string connectionString;

        public OrderRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // HÀM 1: Lấy danh sách đơn hàng của 1 khách
        public List<Order> GetOrdersByCustomer(int customerID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.Orders
                              .Where(o => o.CustomerID == customerID)
                              .OrderByDescending(o => o.OrderDate)
                              .ToList();
            }
        }

        // HÀM 2: Lấy chi tiết của 1 đơn hàng (dùng ViewModel)
        public List<OrderDetailViewModel> GetOrderDetails(int orderID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                var query = from od in context.OrderDetails
                            where od.OrderID == orderID
                            select new OrderDetailViewModel
                            {
                                ProductName = od.Product.Name,
                                // Xử lý nếu serial là null
                                SerialNumber = (od.DeviceUnit != null) ? od.DeviceUnit.SerialNumber : "N/A",
                                Quantity = od.Quantity.GetValueOrDefault(0),
                                UnitPrice = od.UnitPrice.GetValueOrDefault(0)
                            };
                return query.ToList();
            }
        }

        // ... (Bạn đã có hàm GetOrderDetails() ở trên) ...

        // HÀM MỚI: Lưu đơn hàng mới (Rất quan trọng)
        public int CreateNewOrder(Order newOrder, List<OrderDetailViewModel> cartItems)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Thêm bản ghi "Order" (cha) vào
                context.Orders.InsertOnSubmit(newOrder);

                // 2. Lặp qua giỏ hàng và thêm "OrderDetail" (con)
                foreach (var item in cartItems)
                {
                    OrderDetail dbDetail = new OrderDetail
                    {
                        // Quan trọng: Gán 'newOrder' vào đây,
                        // LINQ sẽ tự hiểu và gán OrderID sau khi Insert
                        Order = newOrder,
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        // Xử lý nếu bán theo Model (UnitID = 0)
                        UnitID = (item.UnitID == 0) ? (int?)null : item.UnitID
                    };
                    context.OrderDetails.InsertOnSubmit(dbDetail);

                    // 3. (RẤT QUAN TRỌNG) Cập nhật kho DeviceUnits
                    if (item.UnitID > 0) // Chỉ cập nhật nếu bán theo Serial
                    {
                        // Tìm serial tương ứng trong CSDL
                        DeviceUnit unitToUpdate = context.DeviceUnits.FirstOrDefault(du => du.UnitID == item.UnitID);
                        if (unitToUpdate != null)
                        {
                            // Lấy thông tin bảo hành từ sản phẩm
                            int warrantyMonths = unitToUpdate.Product.WarrantyMonths.GetValueOrDefault(12);

                            // Cập nhật trạng thái
                            unitToUpdate.Status = "SOLD";
                            unitToUpdate.SoldDate = newOrder.OrderDate;
                            unitToUpdate.CurrentCustomerID = newOrder.CustomerID;
                            unitToUpdate.WarrantyStartDate = newOrder.OrderDate;
                            unitToUpdate.WarrantyEndDate = newOrder.OrderDate.Value.AddMonths(warrantyMonths);
                        }
                    }
                }

                // 4. THỰC THI TOÀN BỘ GIAO DỊCH
                // (INSERT vào Orders, INSERT vào OrderDetails, UPDATE DeviceUnits)
                // Nếu một trong 3 bước lỗi, tất cả sẽ bị hủy.
                context.SubmitChanges();

                // 5. Trả về ID của đơn hàng vừa tạo
                return newOrder.OrderID;
            }
        }

        // ... (Bạn đã có hàm CreateNewOrder() ở trên) ...

        // HÀM MỚI: Lấy danh sách đơn hàng để báo cáo (dùng ViewModel)
        public List<OrderViewModel> SearchOrders(DateTime fromDate, DateTime toDate, int customerID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Lấy bảng gốc
                var query = context.Orders.AsQueryable();

                // 2. Lọc theo ngày (phải xử lý phần 'Date' và 'Time')
                // Lấy đến cuối ngày
                DateTime inclusiveToDate = toDate.Date.AddDays(1).AddTicks(-1);
                query = query.Where(o => o.OrderDate >= fromDate.Date && o.OrderDate <= inclusiveToDate);

                // 3. Lọc theo Khách hàng (nếu có chọn)
                if (customerID > 0)
                {
                    query = query.Where(o => o.CustomerID == customerID);
                }

                // 4. Join với Khách hàng và User để lấy Tên
                var result = from order in query
                             orderby order.OrderDate descending
                             select new OrderViewModel
                             {
                                 OrderID = order.OrderID,
                                 OrderDate = order.OrderDate,
                                 TotalAmount = order.TotalAmount,
                                 Status = order.Status,
                                 CustomerName = order.Customer.Name,
                                 UserName = order.User.FullName // Lấy tên nhân viên
                             };

                return result.ToList();
            }
        }
    }
}
