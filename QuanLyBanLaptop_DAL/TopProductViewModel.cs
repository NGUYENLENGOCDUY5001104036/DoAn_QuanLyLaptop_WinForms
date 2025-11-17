using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyBanLaptop_DAL
{
    // THÊM "public" VÀO ĐÂY
    public class TopProductViewModel
    {
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }

        // Dữ liệu tính toán
        public int TotalSold { get; set; } // Tổng số lượng đã bán
    }
}