using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; // <-- THÊM DÒNG NÀY

namespace QuanLyBanLaptop_DAL
{
    public class PurchaseCartItemViewModel
    {
        [Browsable(false)] // Ẩn cột này khỏi DataGridView
        public int ProductID { get; set; }

        [DisplayName("Tên Sản Phẩm")] // Đặt tên cho cột
        public string ProductName { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Giá nhập")]
        [DefaultValue(0)] // (Nếu dùng C# 6.0+)
        public decimal CostPrice { get; set; }

        [DisplayName("Thành tiền")]
        [DefaultValue(0)] // (Nếu dùng C# 6.0+)
        public decimal TotalPrice { get { return Quantity * CostPrice; } }

        [Browsable(false)] // Ẩn cột này
        public List<string> Serials { get; set; }

        [Browsable(false)] // Ẩn cột này
        public int UnitID { get; set; } // (Bạn đã thêm ở bước trước)

        public PurchaseCartItemViewModel()
        {
            Serials = new List<string>();
        }
    }
}