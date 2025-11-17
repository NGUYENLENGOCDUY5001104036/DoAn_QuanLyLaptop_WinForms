using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanLaptop_DAL
{
    // Lớp này dùng để chứa tất cả thông tin
    // liên quan đến lịch sử của 1 Unit
    public class UnitHistoryViewModel
    {
        // Thông tin chính của máy
        public DeviceUnit UnitInfo { get; set; }
        public Product ProductInfo { get; set; }
        public Customer CustomerInfo { get; set; } // Khách hàng đang sở hữu

        // Lịch sử bảo hành
        public List<WarrantyClaim> Claims { get; set; }
    }
}
