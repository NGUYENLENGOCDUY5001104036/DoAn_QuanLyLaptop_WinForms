using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq; 

namespace QuanLyBanLaptop_DAL
{
    public class ReportRepository 
    {
        private string connectionString;
        public ReportRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // Hàm 1: Lấy doanh thu 
        public List<SalesDataPoint> GetSalesByDate(DateTime startDate, DateTime endDate)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                var query = from order in context.Orders
                            where order.OrderDate >= startDate && order.OrderDate <= endDate
                                  && order.Status == "COMPLETED"
                            group order by order.OrderDate.Value.Date into g
                            orderby g.Key
                            select new SalesDataPoint
                            {
                                Date = g.Key,
                                TotalSales = g.Sum(o => o.TotalAmount.GetValueOrDefault(0))
                            };
                return query.ToList();
            }
        }

        // Hàm 2: Lấy tồn kho 
        public List<InventoryDataPoint> GetStockByBrand()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                var query = from unit in context.DeviceUnits
                            where unit.Status == "IN_STOCK"
                            group unit by unit.Product.Brand into g
                            select new InventoryDataPoint
                            {
                                Brand = g.Key,
                                StockCount = g.Count()
                            };
                return query.ToList();
            }
        }

        // HÀM MỚI 3: Lấy Báo cáo Tồn kho 1
        public List<InventoryViewModel> GetInventoryReport()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // LINQ 
                // 1. Bắt đầu từ Products
                // 2. Đếm số lượng 'IN_STOCK' trong DeviceUnits bằng 1 truy vấn con (subquery)
                var query = from p in context.Products
                            select new InventoryViewModel
                            {
                                ProductID = p.ProductID,
                                ProductName = p.Name,
                                Brand = p.Brand,
                                SKU = p.SKU,
                                ReorderLevel = p.ReorderLevel.GetValueOrDefault(0),
                                StockCount = context.DeviceUnits.Count(du => du.ProductID == p.ProductID && du.Status == "IN_STOCK")
                            };

                // 3. Tính toán Trạng thái 
                List<InventoryViewModel> report = query.ToList();
                foreach (var item in report)
                {
                    if (item.StockCount <= item.ReorderLevel)
                        item.Status = "Cần nhập hàng";
                    else
                        item.Status = "OK";
                }

                return report;
            }
        }

        // HÀM MỚI 4: Lấy Top (N) Sản phẩm Bán chạy nhất
        public List<TopProductViewModel> GetTopSellingProducts(int topN)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // LINQ:
                // 1. Vào bảng OrderDetails
                var query = from od in context.OrderDetails
                                // 2. Gom nhóm theo ProductID
                            group od by od.ProductID into g
                            // 3. Tính tổng Số lượng (Quantity) cho mỗi nhóm
                            select new
                            {
                                ProductID = g.Key,
                                Total = g.Sum(item => item.Quantity.GetValueOrDefault(0))
                            } into productSum
                            // 4. Sắp xếp Giảm dần
                            orderby productSum.Total descending
                            // 5. Lấy (topN) hàng đầu tiên
                            select productSum;

                // 6. Join với bảng Products để lấy Tên, SKU, Brand
                var finalResult = from topProduct in query.Take(topN)
                                  join p in context.Products on topProduct.ProductID equals p.ProductID
                                  select new TopProductViewModel
                                  {
                                      ProductName = p.Name,
                                      SKU = p.SKU,
                                      Brand = p.Brand,
                                      TotalSold = topProduct.Total
                                  };

                return finalResult.ToList();
            }
        }

        // HÀM MỚI 5: Lấy thông tin xác thực bảo hành (Hóa đơn gốc)
        public List<WarrantyProofViewModel> GetWarrantyProof(string serialNumber)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // Tìm máy dựa trên Serial
                // Join bảng: DeviceUnits -> Orders -> Customers
                // Join bảng: DeviceUnits -> Products

                var query = from unit in context.DeviceUnits
                            join p in context.Products on unit.ProductID equals p.ProductID
                            join c in context.Customers on unit.CurrentCustomerID equals c.CustomerID
                            // Join với OrderDetails để tìm Order cha
                            join od in context.OrderDetails on unit.UnitID equals od.UnitID
                            join o in context.Orders on od.OrderID equals o.OrderID

                            where unit.SerialNumber == serialNumber
                                  && (unit.Status == "SOLD" || unit.Status == "REPAIR" || unit.Status == "IN_PROGRESS")

                            select new WarrantyProofViewModel
                            {
                                CustomerName = c.Name,
                                PhoneNumber = c.Phone,
                                OrderID = o.OrderID,
                                BuyDate = o.OrderDate.GetValueOrDefault(DateTime.Now),
                                ProductName = p.Name,
                                SerialNumber = unit.SerialNumber,
                                WarrantyEndDate = unit.WarrantyEndDate.GetValueOrDefault(DateTime.Now),
                                // Tự tính trạng thái
                                Status = (unit.WarrantyEndDate >= DateTime.Now) ? "CÒN HẠN BẢO HÀNH" : "HẾT HẠN BẢO HÀNH"
                            };

                return query.ToList();
            }
        }
        // HÀM MỚI 5: Lấy chi tiết tồn kho theo Hãng
        public List<InventoryDetailViewModel> GetStockDetailsByBrand(string brand)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                var query = from unit in context.DeviceUnits
                            where unit.Status == "IN_STOCK" && unit.Product.Brand == brand
                            select new InventoryDetailViewModel
                            {
                                SerialNumber = unit.SerialNumber,
                                ProductName = unit.Product.Name,
                                Brand = unit.Product.Brand,
                                PurchaseDate = unit.PurchaseDate,
                                WarrantyMonths = unit.Product.WarrantyMonths.GetValueOrDefault(12)
                            };
                return query.ToList();
            }
        }
    }
}