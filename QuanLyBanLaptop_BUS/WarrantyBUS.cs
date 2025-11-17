using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL; // Thêm using

namespace QuanLyBanLaptop_BUS
{
    public class WarrantyBUS
    {
        private WarrantyRepository repo;
        public WarrantyBUS()
        {
            repo = new WarrantyRepository();
        }

        // Hàm cho GUI gọi để lọc
        public List<WarrantyClaimViewModel> SearchClaims(string status, string serial)
        {
            return repo.SearchClaims(status, serial);
        }

        // ... (Bạn đã có hàm SearchClaims() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để tạo phiếu
        public void CreateNewClaim(int unitID, int customerID, string issueDescription)
        {
            // Tạo đối tượng
            WarrantyClaim newClaim = new WarrantyClaim
            {
                UnitID = unitID,
                CustomerID = customerID,
                IssueDescription = issueDescription,
                ReportDate = DateTime.Now,
                Status = "PENDING" // Trạng thái ban đầu
            };

            // Gọi DAL (DAL sẽ lo cả 2 việc: tạo Claim và cập nhật Unit)
            repo.CreateNewClaim(newClaim);
        }

        // ... (Bạn đã có hàm CreateNewClaim() ở trên) ...

        // HÀM MỚI 1: Cho GUI gọi để lấy chi tiết
        public WarrantyClaimViewModel GetClaimViewModelById(int claimID)
        {
            return repo.GetClaimViewModelById(claimID);
        }

        // HÀM MỚI 2: Cho GUI gọi để cập nhật
        public void UpdateClaim(int claimID, string newStatus, string resolution)
        {
            repo.UpdateClaim(claimID, newStatus, resolution);
        }
    }
}