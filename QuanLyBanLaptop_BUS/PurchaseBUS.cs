using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL; // Thêm 'using'

namespace QuanLyBanLaptop_BUS
{
    // THÊM "public"
    public class PurchaseBUS
    {
        private PurchaseRepository repo;
        public PurchaseBUS()
        {
            repo = new PurchaseRepository();
        }

        // Hàm cho GUI gọi
        public int CreateNewPurchase(int supplierID, DateTime purchaseDate, decimal totalAmount, List<PurchaseCartItemViewModel> cartItems)
        {
            // 1. Tạo đối tượng Phiếu (cha)
            PurchaseOrder newPO = new PurchaseOrder
            {
                SupplierID = supplierID,
                Date = purchaseDate,
                TotalAmount = totalAmount
            };

            // 2. Gọi DAL để lưu (DAL sẽ lo phần Transaction)
            return repo.CreateNewPurchase(newPO, cartItems);
        }
    }
}