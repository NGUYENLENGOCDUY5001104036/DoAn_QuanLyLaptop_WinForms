using System;

namespace QuanLyBanLaptop_DAL
{
    // Lớp này không phải là bảng CSDL, nó là một "Phom" (ViewModel)
    // để chứa dữ liệu tổng hợp cho DataGridView
    public class DeviceUnitViewModel
    {
        // Từ bảng DeviceUnits
        public int UnitID { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? SoldDate { get; set; }

        // Từ bảng Products (Join)
        public string ProductName { get; set; }

        // Từ bảng Customers (Join)
        public string CustomerName { get; set; }
    }
}