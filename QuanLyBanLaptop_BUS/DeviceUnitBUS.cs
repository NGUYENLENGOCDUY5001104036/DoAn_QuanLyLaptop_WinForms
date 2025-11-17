using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanLaptop_DAL; // Thêm 'using' này

namespace QuanLyBanLaptop_BUS
{
    public class DeviceUnitBUS
    {
        private DeviceUnitRepository repo;

        public DeviceUnitBUS()
        {
            repo = new DeviceUnitRepository();
        }

        // Hàm cho GUI gọi
        public List<DeviceUnitViewModel> GetAllDeviceUnits()
        {
            return repo.GetAllDeviceUnits();
        }

        // ... (Bạn đã có hàm GetAllDeviceUnits() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để lọc
        public List<DeviceUnitViewModel> SearchDeviceUnits(int productID, string status, string serialNumber)
        {
            return repo.SearchDeviceUnits(productID, status, serialNumber);
        }

        // ... (Bạn đã có hàm SearchDeviceUnits() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để cập nhật status
        public void UpdateDeviceStatus(int unitID, string newStatus)
        {
            // (Bạn có thể thêm logic nghiệp vụ ở đây,
            // ví dụ: không cho đổi "SOLD" thành "IN_STOCK" nếu không có quyền admin)
            repo.UpdateDeviceStatus(unitID, newStatus);
        }

        // ... (Bạn đã có hàm UpdateDeviceStatus() ở trên) ...

        // HÀM MỚI: Cho GUI gọi để lấy lịch sử
        public UnitHistoryViewModel GetUnitHistory(int unitID)
        {
            return repo.GetUnitHistory(unitID);
        }

        // ... (Bạn đã có các hàm UpdateDeviceStatus, GetUnitHistory...) ...

        // HÀM MỚI: Cho GUI gọi để lấy serial còn trong kho
        public List<DeviceUnit> GetAvailableSerialsByProduct(int productID)
        {
            return repo.GetAvailableSerialsByProduct(productID);
        }

        // ... (Bạn đã có hàm GetAvailableSerialsByProduct() ở trên) ...

        // HÀM MỚI: Cho GUI gọi
        public DeviceUnit GetSoldUnitBySerial(string serialNumber)
        {
            return repo.GetSoldUnitBySerial(serialNumber);
        }
    }
}
