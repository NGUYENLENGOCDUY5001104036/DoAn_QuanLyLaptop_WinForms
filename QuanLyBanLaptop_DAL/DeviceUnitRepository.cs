using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Linq; // <-- THÊM DÒNG NÀY

namespace QuanLyBanLaptop_DAL
{
    public class DeviceUnitRepository
    {
        // Lấy chuỗi kết nối (Giống hệt ProductRepository)
        private string connectionString;

        public DeviceUnitRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // HÀM MỚI: Lấy tất cả serial và join với tên sản phẩm
        public List<DeviceUnitViewModel> GetAllDeviceUnits()
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // Đây là sức mạnh của LINQ to SQL (tự động JOIN)
                var query = from du in context.DeviceUnits
                            select new DeviceUnitViewModel
                            {
                                UnitID = du.UnitID,
                                // Truy cập bảng Products thông qua 'du.Product'
                                ProductName = du.Product.Name,
                                SerialNumber = du.SerialNumber,
                                Status = du.Status,
                                PurchaseDate = du.PurchaseDate,
                                SoldDate = du.SoldDate,
                                // Xử lý nếu khách hàng là null
                                CustomerName = (du.Customer != null) ? du.Customer.Name : ""
                            };

                return query.ToList();
            }
        }

        // ... (Bạn đã có hàm GetAllDeviceUnits() ở trên) ...

        // HÀM MỚI: Lọc danh sách Device Units
        public List<DeviceUnitViewModel> SearchDeviceUnits(int productID, string status, string serialNumber)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Bắt đầu với bảng gốc
                var query = context.DeviceUnits.AsQueryable();

                // 2. Xây dựng mệnh đề WHERE động

                // Lọc theo ProductID (nếu > 0, vì 0 là "[Tất cả]")
                if (productID > 0)
                {
                    query = query.Where(du => du.ProductID == productID);
                }

                // Lọc theo Trạng thái (nếu người dùng chọn khác "[Tất cả...]")
                if (!string.IsNullOrEmpty(status) && status != "[ Tất cả Trạng thái ]")
                {
                    query = query.Where(du => du.Status == status);
                }

                // Lọc theo Serial Number (dùng Contains giống SQL LIKE)
                if (!string.IsNullOrEmpty(serialNumber))
                {
                    query = query.Where(du => du.SerialNumber.Contains(serialNumber));
                }

                // 3. SAU KHI LỌC XONG, mới thực hiện JOIN để lấy ViewModel
                var result = from du in query
                             select new DeviceUnitViewModel
                             {
                                 UnitID = du.UnitID,
                                 ProductName = du.Product.Name,
                                 SerialNumber = du.SerialNumber,
                                 Status = du.Status,
                                 PurchaseDate = du.PurchaseDate,
                                 SoldDate = du.SoldDate,
                                 CustomerName = (du.Customer != null) ? du.Customer.Name : ""
                             };

                return result.ToList();
            }
        }

        // ... (Bạn đã có hàm SearchDeviceUnits() ở trên) ...

        // HÀM MỚI: Cập nhật trạng thái cho 1 serial
        public void UpdateDeviceStatus(int unitID, string newStatus)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Tìm bản ghi gốc
                DeviceUnit unit = context.DeviceUnits.FirstOrDefault(du => du.UnitID == unitID);
                if (unit != null)
                {
                    // 2. Chỉ cập nhật cột Status
                    unit.Status = newStatus;

                    // 3. (Nghiệp vụ bổ sung): Nếu chuyển về "IN_STOCK"
                    // thì xóa thông tin khách hàng/ngày bán cũ (nếu có)
                    if (newStatus == "IN_STOCK")
                    {
                        unit.SoldDate = null;
                        unit.CurrentCustomerID = null;
                        unit.WarrantyStartDate = null;
                        unit.WarrantyEndDate = null;
                    }

                    // 4. Lưu thay đổi
                    context.SubmitChanges();
                }
            }
        }

        // ... (Bạn đã có hàm UpdateDeviceStatus() ở trên) ...

        // HÀM MỚI: Lấy toàn bộ lịch sử của 1 serial
        public UnitHistoryViewModel GetUnitHistory(int unitID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Lấy thông tin chính của Unit
                DeviceUnit unit = context.DeviceUnits.FirstOrDefault(du => du.UnitID == unitID);
                if (unit == null) return null; // Không tìm thấy

                // 2. Tạo đối tượng ViewModel để chứa
                UnitHistoryViewModel history = new UnitHistoryViewModel();
                history.UnitInfo = unit;

                // 3. Lấy thông tin Sản phẩm (dùng quan hệ LINQ)
                history.ProductInfo = unit.Product;

                // 4. Lấy thông tin Khách hàng (dùng quan hệ LINQ)
                history.CustomerInfo = unit.Customer; // Sẽ là null nếu chưa bán

                // 5. Lấy danh sách Lịch sử Bảo hành
                history.Claims = context.WarrantyClaims
                                        .Where(wc => wc.UnitID == unitID)
                                        .OrderByDescending(wc => wc.ReportDate)
                                        .ToList();

                return history;
            }
        }

        // ... (Bạn đã có các hàm UpdateDeviceStatus, GetUnitHistory...) ...

        // HÀM MỚI: Lấy các serial CÒN TRONG KHO của 1 sản phẩm
        public List<DeviceUnit> GetAvailableSerialsByProduct(int productID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                return context.DeviceUnits
                              .Where(du => du.ProductID == productID && du.Status == "IN_STOCK")
                              .ToList();
            }
        }

        // HÀM MỚI: Tìm một máy ĐÃ BÁN bằng Serial (đã sửa lỗi Lazy Loading)
        public DeviceUnit GetSoldUnitBySerial(string serialNumber)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // ----- BƯỚC 1: CẤU HÌNH EAGER LOAD -----
                // Bảo LINQ: "Khi tải DeviceUnit, hãy tải KÈM Product và Customer luôn"
                DataLoadOptions options = new DataLoadOptions();
                options.LoadWith<DeviceUnit>(du => du.Product);
                options.LoadWith<DeviceUnit>(du => du.Customer);
                context.LoadOptions = options;

                // ----- BƯỚC 2: CHẠY TRUY VẤN (NHƯ CŨ) -----
                // Chỉ tìm máy có Status = "SOLD" (hoặc "REPAIR" nếu bảo hành lại)
                return context.DeviceUnits.FirstOrDefault(du =>
                    du.SerialNumber == serialNumber &&
                    (du.Status == "SOLD" || du.Status == "REPAIR")
                );
            }
            // DataContext đóng ở đây, nhưng Product và Customer đã được tải rồi.
        }
    }
}