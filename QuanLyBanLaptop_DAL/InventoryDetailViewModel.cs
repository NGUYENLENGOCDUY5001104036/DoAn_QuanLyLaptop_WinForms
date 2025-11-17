using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyBanLaptop_DAL
{
    public class InventoryDetailViewModel
    {
        public string SerialNumber { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int WarrantyMonths { get; set; }
    }
}