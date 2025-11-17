using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanLaptop_DAL
{
    public class OrderDetailViewModel
    {

        public int ProductID { get; set; }
        public int UnitID { get; set; } // 0 = Bán theo Model, > 0 = Bán theo Serial

        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        // Thêm một cột tính toán
        public decimal TotalPrice { get { return Quantity * UnitPrice; } }
    }
}