using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanLaptop_DAL
{
    public class WarrantyProofViewModel
    {
        // Thông tin khách
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }

        // Thông tin đơn hàng gốc
        public int OrderID { get; set; }
        public DateTime BuyDate { get; set; }

        // Thông tin máy
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime WarrantyEndDate { get; set; }

        // Tính toán
        public string Status { get; set; } // "CÒN HẠN" hoặc "HẾT HẠN"
    }
}