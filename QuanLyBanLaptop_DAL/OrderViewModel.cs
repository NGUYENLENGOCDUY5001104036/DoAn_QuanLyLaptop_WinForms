using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyBanLaptop_DAL
{
    // THÊM "public" VÀO ĐÂY
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }

        // Dữ liệu Join
        public string CustomerName { get; set; }
        public string UserName { get; set; } // Tên nhân viên
    }
}