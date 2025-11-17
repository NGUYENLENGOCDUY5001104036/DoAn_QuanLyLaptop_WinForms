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
    public partial class frmPurchaseOrder : Form
    {
        // Khai báo các lớp BUS cần thiết
        private SupplierBUS supplierBUS;
        private ProductBUS productBUS;
        private PurchaseBUS purchaseBUS; // <-- THÊM DÒNG NÀY

        // Đây là "Giỏ hàng Nhập" (Cart)
        private BindingList<PurchaseCartItemViewModel> purchaseCart;
        public frmPurchaseOrder()
        {
            InitializeComponent();

            // Khởi tạo các lớp BUS
            supplierBUS = new SupplierBUS();
            productBUS = new ProductBUS();
            purchaseBUS = new PurchaseBUS(); // <-- THÊM DÒNG NÀY
            // Khởi tạo giỏ hàng rỗng
            purchaseCart = new BindingList<PurchaseCartItemViewModel>();

            dgvPurchaseCart.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // --- SỰ KIỆN FORM_LOAD ---
        // (Cách tạo: Mở [Design], chọn Form, vào Properties -> Events (sấm sét) -> nhấp đúp vào 'Load')
        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            LoadSupplierComboBox();
            LoadProductComboBox();

            // Cài đặt ngày mặc định
            dtpPurchaseDate.Value = DateTime.Now;

            // Dòng này sẽ TỰ ĐỘNG tạo các cột (dựa trên ViewModel) ngay cả khi rỗng
            dgvPurchaseCart.DataSource = purchaseCart;

            ConfigureCartGridView(); // Bây giờ gọi hàm này sẽ an toàn
        }

        // Hàm tải ComboBox Nhà cung cấp
        private void LoadSupplierComboBox()
        {
            var suppliers = supplierBUS.GetAllSuppliers();
            suppliers.Insert(0, new Supplier { SupplierID = 0, Name = "[ Chọn Nhà cung cấp... ]" });

            cboSuppliers.DataSource = suppliers;
            cboSuppliers.DisplayMember = "Name";
            cboSuppliers.ValueMember = "SupplierID";
            // ▼▼▼ THÊM DÒNG NÀY VÀO CUỐI HÀM ▼▼▼
            cboSuppliers.SelectedIndex = 0;
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

        // --- HÀM 2: CẬP NHẬT LẠI BẢNG GIỎ HÀNG ---
        // THAY ĐỔI 4: HÀM NÀY KHÔNG CÒN CẦN NỮA (BindingList tự cập nhật)
        //private void RefreshCartDisplay()
        //{
        //    dgvPurchaseCart.DataSource = null;
        //    dgvPurchaseCart.DataSource = purchaseCart;
        //    ConfigureCartGridView(); 
        //}

        // THAY ĐỔI 5: SỬA LẠI HÀM CẤU HÌNH (Đơn giản hơn)
        private void ConfigureCartGridView()
        {
            dgvPurchaseCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Câu lệnh "bảo vệ"
            //if (dgvPurchaseCart.Columns.Count == 0) return;

            // Các cột đã được đặt tên bằng [DisplayName]
            // Chúng ta chỉ cần format tiền
            //dgvPurchaseCart.Columns["Giá nhập"].DefaultCellStyle.Format = "N0";
            //dgvPurchaseCart.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // ... (Validation y như cũ) ...
            #region Validation (Giữ nguyên)
            if (cboProducts.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn một Sản phẩm (Model).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int quantity = (int)numQuantity.Value;
            decimal costPrice = numCostPrice.Value;
            if (costPrice == 0)
            {
                MessageBox.Show("Vui lòng nhập Giá nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> serials = txtSerialList.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(s => s.Trim())
                                                      .Where(s => !string.IsNullOrEmpty(s))
                                                      .Distinct()
                                                      .ToList();
            if (serials.Count != quantity)
            {
                MessageBox.Show(
                    $"Số lượng Serial không khớp! \n\n" +
                    $"Số lượng hàng: {quantity}\n" +
                    $"Số serial đã nhập: {serials.Count}\n\n" +
                    $"Vui lòng nhập chính xác {quantity} serial.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Product selectedProduct = (Product)cboProducts.SelectedItem;
            if (purchaseCart.Any(item => item.ProductID == selectedProduct.ProductID))
            {
                MessageBox.Show("Sản phẩm này đã có trong phiếu nhập. Vui lòng xóa đi nếu muốn thêm lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            // ----- BƯỚC 2: TẠO DÒNG HÀNG VÀ THÊM VÀO GIỎ -----
            PurchaseCartItemViewModel newItem = new PurchaseCartItemViewModel
            {
                ProductID = selectedProduct.ProductID,
                ProductName = selectedProduct.Name,
                Quantity = quantity,
                CostPrice = costPrice,
                Serials = serials
            };

            // THAY ĐỔI 6: Chỉ cần Add. BindingList sẽ TỰ ĐỘNG cập nhật DataGridView
            purchaseCart.Add(newItem);

            // ----- BƯỚC 3: CẬP NHẬT GIAO DIỆN -----
            // RefreshCartDisplay(); // KHÔNG CẦN DÒNG NÀY NỮA
            UpdateTotalAmount();

            // ----- BƯỚC 4: RESET BỘ LỌC -----
            cboProducts.SelectedIndex = 0;
            numQuantity.Value = 1;
            numCostPrice.Value = 0;
            txtSerialList.Text = "";
            lblSerialCount.Text = "Số serial đã nhập: 0";
        }

        // --- HÀM 4: HÀM TIỆN ÍCH ĐẾM SERIAL ---
        // (Cách tạo: Mở [Design], nhấp đúp vào 'txtSerialList')
        private void txtSerialList_TextChanged(object sender, EventArgs e)
        {
            // Đếm số dòng không rỗng
            int count = txtSerialList.Lines.Count(line => !string.IsNullOrWhiteSpace(line));

            // Hiển thị (ví dụ: 5 / 10)
            lblSerialCount.Text = $"Số serial đã nhập: {count} / {numQuantity.Value}";
        }

        // --- HÀM 5: TÍNH VÀ CẬP NHẬT TỔNG TIỀN ---
        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in purchaseCart)
            {
                total += item.TotalPrice; // TotalPrice là cột tự tính
            }

            lblTotalAmount.Text = total.ToString("N0") + " VNĐ"; // Format "N0"
        }

        // ... (Bạn đã có hàm UpdateTotalAmount() ở trên) ...

        // --- HÀM 6: LOGIC NÚT "XÓA KHỎI GIỎ" ---
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món hàng cần xóa khỏi phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // THAY ĐỔI 7: Lấy đối tượng từ BindingList
            PurchaseCartItemViewModel selectedItem = (PurchaseCartItemViewModel)dgvPurchaseCart.SelectedRows[0].DataBoundItem;

            // Xóa (BindingList sẽ tự cập nhật DataGridView)
            purchaseCart.Remove(selectedItem);

            // Cập nhật lại Tổng tiền
            UpdateTotalAmount();
        }

        // ... (Bạn đã có hàm btnRemoveItem_Click() ở trên) ...

        // --- HÀM 7: LOGIC NÚT "LƯU PHIẾU NHẬP" ---
        private void btnSavePurchase_Click(object sender, EventArgs e)
        {
            // ----- BƯỚC 1: VALIDATION (KIỂM TRA DỮ LIỆU) -----

            // 1.1. Kiểm tra đã chọn Nhà cung cấp
            if (cboSuppliers.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSuppliers.Focus();
                return;
            }

            // 1.2. Kiểm tra Giỏ hàng có trống không
            if (purchaseCart.Count == 0)
            {
                MessageBox.Show("Phiếu nhập đang trống, không thể lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ----- BƯỚC 2: HỎI XÁC NHẬN -----
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn lưu phiếu nhập này với tổng tiền là {lblTotalAmount.Text} không?",
                "Xác nhận Lưu Phiếu Nhập",
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
                int supplierID = (int)cboSuppliers.SelectedValue;
                DateTime purchaseDate = dtpPurchaseDate.Value;
                decimal totalAmount = purchaseCart.Sum(item => item.TotalPrice);

                // 3.2. Gọi BUS để thực thi (Transaction)
                int newPurchaseID = purchaseBUS.CreateNewPurchase(supplierID, purchaseDate, totalAmount, purchaseCart.ToList());

                // 3.3. Xử lý thành công
                MessageBox.Show($"Lưu Phiếu Nhập Mới thành công!\n\nMã Phiếu Nhập: {newPurchaseID}\n" +
                                $"Đã thêm {purchaseCart.Sum(item => item.Quantity)} máy mới vào kho.",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close(); // Đóng form
            }
            catch (Exception ex)
            {
                // 3.4. Xử lý thất bại (CSDL tự rollback)
                // Lỗi phổ biến nhất là 'Trùng Serial Number'
                MessageBox.Show($"LỖI KHI LƯU PHIẾU NHẬP:\n\n{ex.Message}\n\n" +
                                $"Gợi ý: Rất có thể Serial Number bạn nhập đã tồn tại trong kho.",
                                "Lỗi CSDL",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}