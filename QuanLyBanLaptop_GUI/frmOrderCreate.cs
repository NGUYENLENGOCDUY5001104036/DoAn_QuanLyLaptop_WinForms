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
    public partial class frmOrderCreate : Form
    {
        // Khai báo 3 lớp BUS chúng ta cần
        private CustomerBUS customerBUS;
        private ProductBUS productBUS;
        private DeviceUnitBUS deviceUnitBUS;
        private OrderBUS orderBUS; // <-- THÊM DÒNG NÀY

        // Đây là "Giỏ hàng" (Cart)
        // Chúng ta dùng ViewModel của OrderDetail để lưu các món hàng
        private List<OrderDetailViewModel> cart;

        public frmOrderCreate()
        {
            InitializeComponent();

            // Khởi tạo các lớp BUS
            customerBUS = new CustomerBUS();
            productBUS = new ProductBUS();
            deviceUnitBUS = new DeviceUnitBUS();
            orderBUS = new OrderBUS(); // <-- THÊM DÒNG NÀY
            // Khởi tạo giỏ hàng rỗng
            cart = new List<OrderDetailViewModel>();

            dgvCart.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // --- SỰ KIỆN FORM_LOAD ---
        // (Cách tạo: Mở [Design], chọn Form, vào Properties -> Events (sấm sét) -> nhấp đúp vào 'Load')
        private void frmOrderCreate_Load(object sender, EventArgs e)
        {
            LoadCustomerComboBox();
            LoadProductComboBox();

            // Cấu hình bảng Giỏ hàng (dgvCart)
            //dgvCart.DataSource = null;
            //dgvCart.DataSource = cart; // Gán giỏ hàng rỗng vào

            ConfigureCartGridView();
        }

        // Hàm tải ComboBox Khách hàng
        private void LoadCustomerComboBox()
        {
            var customers = customerBUS.GetAllCustomers();
            customers.Insert(0, new Customer { CustomerID = 0, Name = "[ Chọn khách hàng... ]" });

            cboCustomers.DataSource = customers;
            cboCustomers.DisplayMember = "Name";
            cboCustomers.ValueMember = "CustomerID";
            // ▼▼▼ THÊM DÒNG NÀY VÀO CUỐI HÀM ▼▼▼
            cboCustomers.SelectedIndex = 0;
        }

        // Hàm tải ComboBox Sản phẩm
        private void LoadProductComboBox()
        {
            var products = productBUS.GetAllProducts();
            products.Insert(0, new Product { ProductID = 0, Name = "[ Chọn sản phẩm... ]" });

            cboProducts.DataSource = products;
            cboProducts.DisplayMember = "Name";
            cboProducts.ValueMember = "ProductID";
            // ▼▼▼ THÊM DÒNG NÀY VÀO CUỐI HÀM ▼▼▼
            cboProducts.SelectedIndex = 0;
        }

        // Hàm cấu hình bảng Giỏ hàng
        private void ConfigureCartGridView()
        {
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //if (dgvCart.Columns.Count > 0)
            //{
            //    dgvCart.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            //    dgvCart.Columns["SerialNumber"].HeaderText = "Serial Number";
            //    dgvCart.Columns["Quantity"].HeaderText = "Số lượng";
            //    dgvCart.Columns["UnitPrice"].HeaderText = "Đơn giá";
            //    dgvCart.Columns["TotalPrice"].HeaderText = "Thành tiền";
            //}
        }

        // --- SỰ KIỆN KHI CHỌN KHÁCH HÀNG ---
        // (Cách tạo: Mở [Design], nhấp đúp vào 'cboCustomers')
        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có phải đã chọn một khách hàng hợp lệ
            if (cboCustomers.SelectedIndex > 0)
            {
                // Lấy đối tượng Customer từ ComboBox
                Customer selectedCustomer = (Customer)cboCustomers.SelectedItem;

                // Cập nhật SĐT và Địa chỉ
                lblPhone.Text = selectedCustomer.Phone ?? "N/A";
                lblAddress.Text = selectedCustomer.Address ?? "N/A";
            }
            else
            {
                // Nếu chọn "[ Chọn khách hàng... ]"
                lblPhone.Text = "...";
                lblAddress.Text = "...";
            }
        }

        // --- SỰ KIỆN KHI CHỌN SẢN PHẨM ---
        // (Cách tạo: Mở [Design], nhấp đúp vào 'cboProducts')
        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSerials.DataSource = null; // Xóa danh sách serial cũ
            lblUnitPrice.Text = "0";

            if (cboProducts.SelectedIndex > 0)
            {
                // Lấy sản phẩm đã chọn
                Product selectedProduct = (Product)cboProducts.SelectedItem;

                // Cập nhật giá bán
                lblUnitPrice.Text = selectedProduct.UnitPrice.GetValueOrDefault(0).ToString("N0"); // Format "N0" -> 32,000,000

                // Tải danh sách serial CÒN TRONG KHO
                var serials = deviceUnitBUS.GetAvailableSerialsByProduct(selectedProduct.ProductID);

                // Thêm 2 lựa chọn quan trọng
                // Mục [Bán không serial] CHỈ xuất hiện nếu sản phẩm này được phép bán (ví dụ Lenovo)
                // (Tạm thời chúng ta cho phép tất cả)
                serials.Insert(0, new DeviceUnit { UnitID = 0, SerialNumber = "[ Bán theo Model (Không Serial) ]" });
                // Mục [Chọn serial]
                serials.Insert(0, new DeviceUnit { UnitID = -1, SerialNumber = "[ Vui lòng chọn Serial... ]" });

                cboSerials.DataSource = serials;
                cboSerials.DisplayMember = "SerialNumber";
                cboSerials.ValueMember = "UnitID";
            }
        }

        // --- NÚT HỦY ---
        // (Cách tạo: Mở [Design], nhấp đúp vào 'btnCancel')
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ... (Bạn đã có hàm btnCancel_Click ở trên) ...

        // --- HÀM 1: LOGIC NÚT "THÊM VÀO GIỎ" ---
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // ----- BƯỚC 1: VALIDATION (KIỂM TRA DỮ LIỆU) -----

            // 1.1. Kiểm tra đã chọn Sản phẩm chưa
            if (cboProducts.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn một Sản phẩm (Model).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1.2. Kiểm tra đã chọn Serial chưa
            if (cboSerials.SelectedIndex <= 0) // Index 0 là "[ Vui lòng chọn Serial... ]"
            {
                MessageBox.Show("Vui lòng chọn một Serial (hoặc 'Bán theo Model').", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy các đối tượng đã chọn
            Product selectedProduct = (Product)cboProducts.SelectedItem;
            DeviceUnit selectedSerial = (DeviceUnit)cboSerials.SelectedItem;

            // ----- BƯỚC 2: KIỂM TRA TRÙNG LẶP TRONG GIỎ HÀNG -----

            // 2.1. Nếu chọn bán theo Serial (UnitID > 0)
            if (selectedSerial.UnitID > 0)
            {
                // Kiểm tra xem serial này đã có trong giỏ chưa
                if (cart.Any(item => item.UnitID == selectedSerial.UnitID))
                {
                    MessageBox.Show("Serial này đã có trong giỏ hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2.2. Nếu chọn bán theo Model (UnitID = 0)
            if (selectedSerial.UnitID == 0)
            {
                // Kiểm tra xem Model này đã có trong giỏ (ở dạng 'Không Serial') chưa
                if (cart.Any(item => item.ProductID == selectedProduct.ProductID && item.UnitID == 0))
                {
                    MessageBox.Show("Sản phẩm (bán theo Model) này đã có trong giỏ. Vui lòng xóa đi nếu muốn thay đổi số lượng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            // ----- BƯỚC 3: TẠO DÒNG HÀNG VÀ THÊM VÀO GIỎ -----
            OrderDetailViewModel newItem = new OrderDetailViewModel
            {
                ProductID = selectedProduct.ProductID,
                ProductName = selectedProduct.Name,
                UnitPrice = selectedProduct.UnitPrice.GetValueOrDefault(0),
                Quantity = 1 // Mặc định là 1
            };

            // Gán thông tin Serial (nếu có)
            if (selectedSerial.UnitID > 0) // Bán theo Serial
            {
                newItem.UnitID = selectedSerial.UnitID;
                newItem.SerialNumber = selectedSerial.SerialNumber;
            }
            else // Bán theo Model (UnitID = 0)
            {
                newItem.UnitID = 0;
                newItem.SerialNumber = "N/A (Bán theo Model)";
            }

            // Thêm vào giỏ hàng (List<T>)
            cart.Add(newItem);

            // ----- BƯỚC 4: CẬP NHẬT GIAO DIỆN -----
            RefreshCartDisplay();
            UpdateTotalAmount();

            // ----- BƯỚC 5: RESET BỘ LỌC ĐỂ THÊM MÓN MỚI -----
            cboProducts.SelectedIndex = 0;
            cboSerials.DataSource = null;
            lblUnitPrice.Text = "0";
        }

        // --- HÀM 2: CẬP NHẬT LẠI BẢNG GIỎ HÀNG ---
        private void RefreshCartDisplay()
        {
            // Gán lại DataSource. Do 'cart' là List<T>, nó sẽ tự động cập nhật
            dgvCart.DataSource = null;
            dgvCart.DataSource = cart;
            ConfigureCartGridView(); // Cấu hình lại cột
        }

        // --- HÀM 3: TÍNH VÀ CẬP NHẬT TỔNG TIỀN ---
        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in cart)
            {
                total += item.TotalPrice; // TotalPrice là cột tự tính (Quantity * UnitPrice)
            }

            lblTotalAmount.Text = total.ToString("N0") + " VNĐ"; // Format "N0" -> 100,000,000
        }

        // ... (Bạn đã có hàm UpdateTotalAmount() ở trên) ...

        // --- HÀM 4: LOGIC NÚT "XÓA KHỎI GIỎ" ---
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có chọn hàng nào trong giỏ không
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món hàng cần xóa khỏi giỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy đối tượng (OrderDetailViewModel) từ hàng đã chọn
            OrderDetailViewModel selectedItem = (OrderDetailViewModel)dgvCart.SelectedRows[0].DataBoundItem;

            // 3. Xóa đối tượng này khỏi giỏ hàng (List<T>)
            cart.Remove(selectedItem);

            // 4. Cập nhật lại DataGridView và Tổng tiền
            RefreshCartDisplay();
            UpdateTotalAmount();
        }

        // ... (Bạn đã có hàm btnRemoveItem_Click() ở trên) ...

        // --- HÀM 5: LOGIC NÚT "LƯU ĐƠN HÀNG" ---
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            // ----- BƯỚC 1: VALIDATION (KIỂM TRA DỮ LIỆU) -----

            // 1.1. Kiểm tra đã chọn Khách hàng chưa
            if (cboCustomers.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCustomers.Focus();
                return;
            }

            // 1.2. Kiểm tra Giỏ hàng có trống không
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống, không thể lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ----- BƯỚC 2: HỎI XÁC NHẬN -----
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn lưu đơn hàng này với tổng tiền là {lblTotalAmount.Text} không?",
                "Xác nhận Lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            // ----- BƯỚC 3: THỰC THI LƯU VÀ BẮT LỖI -----
            try
            {
                // 3.1. Thu thập thông tin
                int customerID = (int)cboCustomers.SelectedValue;

                // (TẠM THỜI) Hard-code UserID là 2 (Nhân viên)
                // Sau này khi có form Đăng nhập, bạn sẽ lấy ID của user đang đăng nhập
                int userID = 2;

                // Tính lại tổng tiền cho chính xác
                decimal totalAmount = cart.Sum(item => item.TotalPrice);

                // 3.2. Gọi BUS để thực thi
                int newOrderID = orderBUS.CreateNewOrder(customerID, userID, totalAmount, cart);

                // 3.3. Xử lý thành công
                MessageBox.Show($"Lưu đơn hàng MỚI thành công!\n\nMã Đơn Hàng của bạn là: {newOrderID}",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // Báo thành công
                this.Close(); // Đóng form
            }
            catch (Exception ex)
            {
                // 3.4. Xử lý thất bại (CSDL tự rollback)
                MessageBox.Show($"LỖI NGHIÊM TRỌNG KHI LƯU ĐƠN HÀNG:\n\n{ex.Message}\n\nĐơn hàng đã được tự động hủy.",
                                "Lỗi CSDL",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        // ... (Bạn đã có hàm btnCancel_Click ở trên) ...

        private void btnSearchPhone_Click(object sender, EventArgs e)
        {
            string phone = txtPhoneSearch.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập SĐT cần tìm.");
                return;
            }

            // Gọi BUS để tìm
            Customer foundCustomer = customerBUS.GetCustomerByExactPhone(phone);

            if (foundCustomer != null)
            {
                // NẾU TÌM THẤY:
                // Tự động chọn khách hàng này trong ComboBox
                cboCustomers.SelectedValue = foundCustomer.CustomerID;

                // (Lưu ý: Sự kiện SelectedIndexChanged của ComboBox sẽ tự động chạy
                // và điền các thông tin còn lại như Địa chỉ, Tên...)

                MessageBox.Show($"Đã tìm thấy khách hàng: {foundCustomer.Name}");
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào có số điện thoại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Reset ComboBox về mặc định
                cboCustomers.SelectedIndex = 0;
            }
        }

        private void grpKhachHang_Enter(object sender, EventArgs e)
        {

        }
    }
}
