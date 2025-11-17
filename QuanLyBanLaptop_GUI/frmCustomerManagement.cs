using QuanLyBanLaptop_BUS; // Thêm BUS
using QuanLyBanLaptop_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmCustomerManagement : Form
    {
        // Khai báo lớp BUS
        private CustomerBUS customerBUS;

        public frmCustomerManagement()
        {
            InitializeComponent();
            customerBUS = new CustomerBUS();

            dgvCustomers.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // Sự kiện Form_Load
        // (Cách tạo: Mở [Design], chọn Form, vào Properties -> Events (sấm sét) -> nhấp đúp vào 'Load')
        private void frmCustomerManagement_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        // Hàm tải dữ liệu chính vào DataGridView
        private void LoadCustomerList()
        {
            dgvCustomers.DataSource = null; // Xóa dữ liệu cũ
            var allCustomers = customerBUS.GetAllCustomers();
            dgvCustomers.DataSource = allCustomers;

            ConfigureDataGridView(); // Gọi hàm cấu hình
        }

        // Hàm cấu hình cột (cho đẹp)
        private void ConfigureDataGridView()
        {
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //// Đặt lại tên tiêu đề
            //dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
            //dgvCustomers.Columns["Name"].HeaderText = "Tên Khách hàng";
            //dgvCustomers.Columns["Phone"].HeaderText = "Số Điện thoại";
            //dgvCustomers.Columns["Email"].HeaderText = "Email";
            //dgvCustomers.Columns["Address"].HeaderText = "Địa chỉ";

            //// Ưu tiên độ rộng
            //dgvCustomers.Columns["Name"].FillWeight = 150;
            //dgvCustomers.Columns["Address"].FillWeight = 200;

            //// Ẩn các cột quan hệ không cần thiết
            ////dgvCustomers.Columns["DeviceUnits"].Visible = false;
            ////dgvCustomers.Columns["Orders"].Visible = false;
            ////dgvCustomers.Columns["WarrantyClaims"].Visible = false;
        }

        // Logic nút "Đóng"
        // (Cách tạo: Mở [Design], nhấp đúp vào nút "Đóng")
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ... (Bạn đã có hàm btnClose_Click ở trên) ...

        // Logic nút "Làm mới"
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Xóa rỗng các ô tìm kiếm
            txtSearchName.Text = "";
            txtSearchPhone.Text = "";

            // Tải lại toàn bộ danh sách
            LoadCustomerList();
        }

        // Logic nút "Tìm kiếm"
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 1. Lấy giá trị từ các ô lọc
            string name = txtSearchName.Text.Trim();
            string phone = txtSearchPhone.Text.Trim();

            // 2. Gọi BUS để lấy kết quả
            var result = customerBUS.SearchCustomers(name, phone);

            // 3. Hiển thị kết quả lên DataGridView
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = result;

            // 4. Cấu hình lại cột (quan trọng)
            ConfigureDataGridView();
        }

        // ... (Bạn đã có hàm btnSearch_Click ở trên) ...

        // Logic nút "Thêm mới" (Đổi tên nút của bạn thành btnAddNew)
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // 1. Mở form 'Thêm mới' (dùng constructor rỗng)
            frmCustomerEdit formThem = new frmCustomerEdit();

            // 2. Chỉ tải lại nếu người dùng nhấn "Lưu" (OK)
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerList(); // Tải lại danh sách
            }
        }

        // Logic nút "Xem / Sửa" (Đổi tên nút của bạn thành btnEdit)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn hàng chưa
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.", "Thông báo");
                return;
            }

            // 2. Lấy ID
            int customerID = (int)dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value;

            // 3. Mở form 'Sửa' (dùng constructor có ID)
            frmCustomerEdit formSua = new frmCustomerEdit(customerID);

            // 4. Chỉ tải lại nếu người dùng nhấn "Cập nhật" (OK)
            if (formSua.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerList(); // Tải lại danh sách
            }
        }
        // ... (Bạn đã có hàm btnEdit_Click ở trên) ...

        // Logic nút "Xóa"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ----- BƯỚC 1: KIỂM TRA CHỌN HÀNG -----
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ----- BƯỚC 2: LẤY ID VÀ TÊN -----
            DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
            int customerID = (int)selectedRow.Cells["CustomerID"].Value;
            string customerName = selectedRow.Cells["Name"].Value.ToString();

            // ----- BƯỚC 3: HỎI XÁC NHẬN -----
            DialogResult result = MessageBox.Show(
                $"Bạn có thật sự muốn xóa khách hàng '{customerName}' không?" +
                $"\n\nLƯU Ý: Bạn không thể xóa khách hàng nếu họ đã từng mua hàng.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return; // Người dùng nhấn "No"
            }

            // ----- BƯỚC 4: THỰC THI XÓA VÀ BẮT LỖI -----
            try
            {
                // Gọi BUS để xóa
                customerBUS.DeleteCustomer(customerID);

                // Nếu thành công:
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại lưới
                LoadCustomerList();
            }
            catch (Exception ex)
            {
                // BẮT LỖI FOREIGN KEY
                MessageBox.Show(
                    $"Không thể xóa khách hàng này. Khách hàng đã có đơn hàng trong hệ thống." +
                    $"\n\nChi tiết lỗi: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ... (Bạn đã có hàm btnDelete_Click ở trên) ...

        // Logic nút "Xem Lịch sử mua hàng"
        // Logic nút "Xem Lịch sử mua hàng"
        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xem lịch sử.", "Thông báo");
                return;
            }

            // --- SỬA ĐOẠN NÀY (Dùng DataBoundItem an toàn hơn) ---

            // 1. Lấy dòng đang chọn
            DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];

            // 2. Lấy nguyên đối tượng 'Customer' từ dòng đó
            // (Vì chúng ta đã gán List<Customer> vào DataSource)
            Customer selectedCustomer = (Customer)selectedRow.DataBoundItem;

            // 3. Lấy thông tin từ đối tượng (Không cần quan tâm tên cột là gì)
            int customerID = selectedCustomer.CustomerID;
            string customerName = selectedCustomer.Name;

            // -----------------------------------------------------

            // Mở form Lịch sử và TRUYỀN cả ID và Tên
            frmCustomerHistory formHistory = new frmCustomerHistory(customerID, customerName);
            formHistory.ShowDialog();
        }
    }
}
