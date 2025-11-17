using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QuanLyBanLaptop_DAL
{
    public class WarrantyRepository
    {
        private string connectionString;
        public WarrantyRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanLaptop_DAL.Properties.Settings.QuanLyBanLaptopConnectionString"].ConnectionString;
        }

        // HÀM MỚI: Lọc danh sách Phiếu Bảo hành
        public List<WarrantyClaimViewModel> SearchClaims(string status, string serial)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Join 4 bảng: Claim -> Unit -> Customer và Unit -> Product
                var query = from claim in context.WarrantyClaims
                            join unit in context.DeviceUnits on claim.UnitID equals unit.UnitID
                            join customer in context.Customers on claim.CustomerID equals customer.CustomerID
                            join product in context.Products on unit.ProductID equals product.ProductID
                            select new WarrantyClaimViewModel
                            {
                                ClaimID = claim.ClaimID,
                                ReportDate = claim.ReportDate,
                                Status = claim.Status,
                                IssueDescription = claim.IssueDescription,
                                CustomerName = customer.Name,
                                ProductName = product.Name,
                                SerialNumber = unit.SerialNumber
                            };

                // 2. Lọc theo Trạng thái (nếu có chọn)
                if (!string.IsNullOrEmpty(status) && status != "[ Tất cả ]")
                {
                    query = query.Where(c => c.Status == status);
                }

                // 3. Lọc theo Serial (nếu có nhập)
                if (!string.IsNullOrEmpty(serial))
                {
                    query = query.Where(c => c.SerialNumber.Contains(serial));
                }

                return query.OrderByDescending(c => c.ReportDate).ToList();
            }
        }

        // ... (Bạn đã có hàm SearchClaims() ở trên) ...

        // HÀM MỚI: Tạo phiếu bảo hành mới VÀ cập nhật kho
        public void CreateNewClaim(WarrantyClaim newClaim)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Thêm phiếu bảo hành mới
                context.WarrantyClaims.InsertOnSubmit(newClaim);

                // 2. Cập nhật trạng thái của máy trong kho
                DeviceUnit unitToUpdate = context.DeviceUnits.FirstOrDefault(du => du.UnitID == newClaim.UnitID);
                if (unitToUpdate != null)
                {
                    unitToUpdate.Status = "IN_PROGRESS"; // Hoặc "REPAIR" tùy bạn
                }

                // 3. Thực thi cả 2 lệnh (INSERT và UPDATE) trong 1 transaction
                context.SubmitChanges();
            }
        }

        // ... (Bạn đã có hàm CreateNewClaim() ở trên) ...

        // HÀM MỚI 1: Lấy chi tiết 1 phiếu bảo hành (dùng ViewModel)
        public WarrantyClaimViewModel GetClaimViewModelById(int claimID)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // Dùng lại LINQ Join 4 bảng
                var query = from claim in context.WarrantyClaims
                            join unit in context.DeviceUnits on claim.UnitID equals unit.UnitID
                            join customer in context.Customers on claim.CustomerID equals customer.CustomerID
                            join product in context.Products on unit.ProductID equals product.ProductID
                            // Lọc theo ClaimID
                            where claim.ClaimID == claimID
                            select new WarrantyClaimViewModel
                            {
                                ClaimID = claim.ClaimID,
                                ReportDate = claim.ReportDate,
                                Status = claim.Status,
                                IssueDescription = claim.IssueDescription,

                                // THÊM DÒNG NÀY VÀO
                                Resolution = claim.Resolution,

                                CustomerName = customer.Name,
                                ProductName = product.Name,
                                SerialNumber = unit.SerialNumber
                            };

                // Lấy bản ghi đầu tiên (hoặc null)
                return query.FirstOrDefault();
            }
        }

        // HÀM MỚI 2: Cập nhật phiếu bảo hành VÀ trạng thái kho
        public void UpdateClaim(int claimID, string newStatus, string resolution)
        {
            using (DatabaseDataContext context = new DatabaseDataContext(connectionString))
            {
                // 1. Tìm phiếu bảo hành
                WarrantyClaim claimToUpdate = context.WarrantyClaims.FirstOrDefault(c => c.ClaimID == claimID);
                if (claimToUpdate == null) return;

                // 2. Cập nhật thông tin phiếu
                claimToUpdate.Status = newStatus;
                claimToUpdate.Resolution = resolution;

                // 3. (Nghiệp vụ) Cập nhật kho (DeviceUnit)
                // Nếu sửa xong (COMPLETED)
                if (newStatus == "COMPLETED")
                {
                    // Tìm máy
                    DeviceUnit unit = context.DeviceUnits.FirstOrDefault(du => du.UnitID == claimToUpdate.UnitID);
                    if (unit != null)
                    {
                        // Trả trạng thái về "SOLD" (vì máy này vẫn thuộc về khách)
                        unit.Status = "SOLD";
                    }
                }

                // 4. Lưu tất cả thay đổi
                context.SubmitChanges();
            }
        }
    }
}
