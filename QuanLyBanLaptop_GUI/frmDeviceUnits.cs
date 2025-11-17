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
using QuanLyBanLaptop_DAL; // Thêm DAL (để load filter)

namespace QuanLyBanLaptop_GUI
{
    public partial class frmDeviceUnits : Form
    {
        // Khai báo 2 lớp BUS chúng ta sẽ cần
        private DeviceUnitBUS deviceUnitBUS;
        private ProductBUS productBUS; // Dùng để load filter

        public frmDeviceUnits()
        {
            InitializeComponent();
            deviceUnitBUS = new DeviceUnitBUS();
            productBUS = new ProductBUS(); // Khởi tạo

            dgvDeviceUnits.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // Sự kiện Form_Load
        // (Cách tạo: Mở [Design], chọn Form, vào Properties -> Events (sấm sét) -> nhấp đúp vào 'Load')
        private void frmDeviceUnits_Load(object sender, EventArgs e)
        {
            LoadAllDeviceUnits(); // Tải dữ liệu vào bảng
            LoadFilters();        // Tải dữ liệu cho các ComboBox
        }

        // Hàm tải dữ liệu chính vào DataGridView
        private void LoadAllDeviceUnits()
        {
            dgvDeviceUnits.DataSource = null; // Xóa dữ liệu cũ
            var allUnits = deviceUnitBUS.GetAllDeviceUnits();
            dgvDeviceUnits.DataSource = allUnits;

            ConfigureDataGridView(); // Gọi hàm cấu hình
        }

        // Hàm tải dữ liệu cho 2 ComboBox
        private void LoadFilters()
        {
            // 1. Load Filter Sản phẩm (từ ProductBUS)
            var productList = productBUS.GetAllProducts();
            // Tạo một mục "Tất cả"
            productList.Insert(0, new Product { ProductID = 0, Name = "[ Tất cả Sản phẩm ]" });
            cboProductFilter.DataSource = productList;
            cboProductFilter.DisplayMember = "Name";
            cboProductFilter.ValueMember = "ProductID";

            // 2. Load Filter Trạng thái (hard-code)
            var statusList = new List<string> { "[ Tất cả Trạng thái ]", "IN_STOCK", "SOLD", "REPAIR", "RESERVED" };
            cboStatusFilter.DataSource = statusList;
        }

        // Hàm cấu hình cột (cho đẹp)
        private void ConfigureDataGridView()
        {
            // Set chế độ co giãn
            dgvDeviceUnits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //// Đặt lại tên tiêu đề
            //dgvDeviceUnits.Columns["UnitID"].HeaderText = "ID Kho";
            //dgvDeviceUnits.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            //dgvDeviceUnits.Columns["SerialNumber"].HeaderText = "Serial Number";
            //dgvDeviceUnits.Columns["Status"].HeaderText = "Trạng thái";
            //dgvDeviceUnits.Columns["PurchaseDate"].HeaderText = "Ngày nhập";
            //dgvDeviceUnits.Columns["SoldDate"].HeaderText = "Ngày bán";
            //dgvDeviceUnits.Columns["CustomerName"].HeaderText = "Khách hàng";

            //// Ưu tiên độ rộng
            //dgvDeviceUnits.Columns["ProductName"].FillWeight = 200;
            //dgvDeviceUnits.Columns["SerialNumber"].FillWeight = 150;
        }

        // Logic nút "Đóng"
        // (Cách tạo: Mở [Design], nhấp đúp vào nút "Đóng")
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Logic nút "Làm mới"
        // (Cách tạo: Mở [Design], nhấp đúp vào nút "Làm mới")
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllDeviceUnits(); // Tải lại bảng
            cboProductFilter.SelectedIndex = 0; // Reset filter
            cboStatusFilter.SelectedIndex = 0;  // Reset filter
            txtSerialFilter.Text = "";          // Reset filter
        }

        // ... (Bạn đã có hàm btnRefresh_Click ở trên) ...

        // Logic nút "Lọc"
        private void btnFilter_Click(object sender, EventArgs e)
        {
            // 1. Lấy giá trị từ các bộ lọc
            // Chúng ta lấy 'SelectedValue' vì nó đã được gán 'ProductID'
            int productID = (int)cboProductFilter.SelectedValue;

            // Lấy chuỗi text từ 'SelectedItem'
            string status = cboStatusFilter.SelectedItem.ToString();

            // Lấy text từ TextBox
            string serial = txtSerialFilter.Text.Trim();

            // 2. Gọi BUS để lấy kết quả lọc
            var filteredList = deviceUnitBUS.SearchDeviceUnits(productID, status, serial);

            // 3. Hiển thị kết quả lên DataGridView
            dgvDeviceUnits.DataSource = null;
            dgvDeviceUnits.DataSource = filteredList;

            // 4. Cấu hình lại cột (quan trọng)
            ConfigureDataGridView();
        }

        // ... (Bạn đã có hàm btnFilter_Click ở trên) ...

        // Logic nút "Cập nhật Trạng thái"
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn hàng nào chưa
            if (dgvDeviceUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một serial để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy UnitID và Trạng thái HIỆN TẠI
            DataGridViewRow selectedRow = dgvDeviceUnits.SelectedRows[0];
            int unitID = (int)selectedRow.Cells["UnitID"].Value;
            string currentStatus = selectedRow.Cells["Status"].Value.ToString();

            // 3. Mở form mini (frmUpdateStatus) và truyền trạng thái hiện tại vào
            frmUpdateStatus formChon = new frmUpdateStatus(currentStatus);

            // 4. Hiển thị form mini và chờ người dùng (nhấn OK hoặc Cancel)
            DialogResult result = formChon.ShowDialog();

            // 5. Nếu người dùng nhấn "OK"
            if (result == DialogResult.OK)
            {
                // Lấy trạng thái mới từ property của form mini
                string newStatus = formChon.SelectedStatus;

                // 6. Kiểm tra xem có khác trạng thái cũ không
                if (newStatus == currentStatus)
                {
                    return; // Giống thì không làm gì cả
                }

                // 7. Gọi BUS/DAL để cập nhật CSDL
                try
                {
                    deviceUnitBUS.UpdateDeviceStatus(unitID, newStatus);
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 8. Tải lại lưới để thấy thay đổi
                    // (Cách nhanh nhất là gọi lại hàm 'Lọc'
                    //  để nó tải lại đúng theo filter đang chọn)
                    btnFilter_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ... (Bạn đã có hàm btnUpdateStatus_Click ở trên) ...

        // Logic nút "Xem Lịch sử"
        // Logic nút "Xem Lịch sử"
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn hàng nào chưa
            if (dgvDeviceUnits.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một serial để xem lịch sử.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- CÁCH SỬA: Dùng DataBoundItem (An toàn tuyệt đối) ---

            // 2. Lấy dòng đang chọn
            DataGridViewRow selectedRow = dgvDeviceUnits.SelectedRows[0];

            // 3. Lấy đối tượng 'DeviceUnitViewModel' từ dòng đó
            // (Vì chúng ta đã gán List<DeviceUnitViewModel> vào DataSource)
            var selectedItem = (QuanLyBanLaptop_DAL.DeviceUnitViewModel)selectedRow.DataBoundItem;

            // 4. Lấy UnitID từ đối tượng
            int unitID = selectedItem.UnitID;

            // --------------------------------------------------------

            // 5. Mở form Lịch sử và truyền UnitID vào
            frmUnitHistory formHistory = new frmUnitHistory(unitID);
            formHistory.ShowDialog();
        }
    }
}
