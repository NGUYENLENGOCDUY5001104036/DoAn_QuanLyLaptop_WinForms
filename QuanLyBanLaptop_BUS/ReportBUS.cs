using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL; 

namespace QuanLyBanLaptop_BUS
{
    public class ReportBUS
    {
        private ReportRepository repo;
        public ReportBUS()
        {
            repo = new ReportRepository();
        }

        public List<SalesDataPoint> GetSalesByDate(DateTime startDate, DateTime endDate)
        {
            return repo.GetSalesByDate(startDate, endDate);
        }
        // HÀM MỚI 2: Cho GUI gọi để lấy tồn kho
        public List<InventoryDataPoint> GetStockByBrand()
        {
            return repo.GetStockByBrand();
        }


        // HÀM MỚI 3: Cho GUI gọi (có Filter)
        public List<InventoryViewModel> GetInventoryReport(string brand, bool reorderOnly)
        {
            // 1. Lấy dữ liệu thô
            List<InventoryViewModel> fullReport = repo.GetInventoryReport();

            // 2. Lọc (Filter) bằng LINQ to Objects

            // Lọc theo Hãng (nếu có chọn)
            if (!string.IsNullOrEmpty(brand) && brand != "[ Tất cả Hãng ]")
            {
                fullReport = fullReport.Where(r => r.Brand == brand).ToList();
            }

            // Lọc theo "Cần nhập" (nếu có check)
            if (reorderOnly)
            {
                fullReport = fullReport.Where(r => r.Status == "Cần nhập hàng").ToList();
            }

            return fullReport;
        }

        // HÀM MỚI 4: Cho GUI gọi
        public List<TopProductViewModel> GetTopSellingProducts(int topN)
        {
            return repo.GetTopSellingProducts(topN);
        }
        // HÀM MỚI 5: Cho GUI gọi
        public List<WarrantyProofViewModel> GetWarrantyProof(string serialNumber)
        {
            return repo.GetWarrantyProof(serialNumber);
        }
        // HÀM MỚI 6: Cho GUI gọi
        public List<InventoryDetailViewModel> GetStockDetailsByBrand(string brand)
        {
            return repo.GetStockDetailsByBrand(brand);
        }
    }
}