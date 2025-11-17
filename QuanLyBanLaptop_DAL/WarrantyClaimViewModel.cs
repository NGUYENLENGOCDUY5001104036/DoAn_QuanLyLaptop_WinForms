using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyBanLaptop_DAL
{
    // THÊM "public" VÀO ĐÂY
    public class WarrantyClaimViewModel
    {
        public int ClaimID { get; set; }
        public DateTime? ReportDate { get; set; }
        public string Status { get; set; }
        public string IssueDescription { get; set; }

        // THÊM DÒNG NÀY VÀO
        public string Resolution { get; set; }

        // Dữ liệu Join
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
    }
}