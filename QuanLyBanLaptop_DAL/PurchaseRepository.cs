using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq; // <-- THÊM DÒNG NÀY

namespace QuanLyBanLaptop_DAL
{
    // THÊM "public"
    public class PurchaseRepository
    {
        private string connectionString;

        public PurchaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // HÀM MỚI: Lưu toàn bộ Phiếu Nhập
        public int CreateNewPurchase(PurchaseOrder newPO, List<PurchaseCartItemViewModel> cartItems)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Thêm Phiếu Nhập (cha)
                context.PurchaseOrders.InsertOnSubmit(newPO);

                // 2. Lặp qua giỏ hàng (cartItems)
                foreach (var item in cartItems)
                {
                    // 2a. Tạo Chi Tiết Phiếu (PurchaseDetail)
                    PurchaseDetail pd = new PurchaseDetail
                    {
                        PurchaseOrder = newPO, // Tự động gán PurchaseID
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        UnitPrice = item.CostPrice
                    };
                    context.PurchaseDetails.InsertOnSubmit(pd);

                    // 2b. Lặp qua danh sách Serial của món hàng
                    foreach (string serial in item.Serials)
                    {
                        // Tạo máy mới (DeviceUnit)
                        DeviceUnit du = new DeviceUnit
                        {
                            ProductID = item.ProductID,
                            SerialNumber = serial,
                            Status = "IN_STOCK", // Trạng thái mới nhập
                            PurchaseDate = newPO.Date
                        };
                        context.DeviceUnits.InsertOnSubmit(du);
                    }
                }

                // 3. Thực thi toàn bộ Giao dịch
                // (INSERT vào PurchaseOrders, PurchaseDetails, VÀ DeviceUnits)
                context.SubmitChanges();

                // 4. Trả về ID của phiếu vừa tạo
                return newPO.PurchaseID;
            }
        }
    }
}