using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanLaptop_BUS; // Thêm BUS
using QuanLyBanLaptop_DAL; // Thêm DAL

namespace QuanLyBanLaptop_GUI
{
    public partial class frmUnitHistory : Form
    {
        private int currentUnitID;
        private DeviceUnitBUS unitBUS;

        public frmUnitHistory(int unitID)
        {
            InitializeComponent();

            // ▼▼▼ QUAN TRỌNG: Tắt tự động tạo cột ▼▼▼
            dgvWarrantyClaims.AutoGenerateColumns = false;

            this.currentUnitID = unitID;
            this.unitBUS = new DeviceUnitBUS();
        }

        // Sự kiện Form_Load (Đảm bảo đã nối dây!)
        private void frmUnitHistory_Load(object sender, EventArgs e)
        {
            // 1. Gọi BUS lấy dữ liệu lịch sử
            var history = unitBUS.GetUnitHistory(currentUnitID);

            if (history == null)
            {
                MessageBox.Show("Không thể tải lịch sử của thiết bị này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 2. Đổ dữ liệu vào các Label (Thông tin chung)
            // (Lưu ý: Các Label này bạn đã đặt tên ở bước trước)
            if (history.ProductInfo != null)
                lblProductName.Text = history.ProductInfo.Name;

            if (history.UnitInfo != null)
            {
                lblSerialNumber.Text = history.UnitInfo.SerialNumber;
                lblStatus.Text = history.UnitInfo.Status;
                lblPurchaseDate.Text = history.UnitInfo.PurchaseDate?.ToString("dd/MM/yyyy") ?? "N/A";
                lblSoldDate.Text = history.UnitInfo.SoldDate?.ToString("dd/MM/yyyy") ?? "Chưa bán";
            }

            if (history.CustomerInfo != null)
                lblCustomerName.Text = history.CustomerInfo.Name;
            else
                lblCustomerName.Text = "Chưa có chủ sở hữu";

            // 3. Đổ dữ liệu vào DataGridView (Lịch sử bảo hành)
            // Vì chúng ta đã thiết kế cột trong Design, chỉ cần gán DataSource là xong!
            dgvWarrantyClaims.DataSource = history.Claims;
        }

        // Nút Đóng (Đảm bảo đã nối dây!)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}