using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyBanLaptop_DAL
{
    // THÊM "public"
    public class InventoryViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string SKU { get; set; }

        // Dữ liệu từ Product
        public int ReorderLevel { get; set; }

        // Dữ liệu tính toán
        public int StockCount { get; set; } // Số lượng đếm được

        // Dữ liệu hiển thị
        public string Status { get; set; } // "OK" hoặc "Cần nhập"
    }
}