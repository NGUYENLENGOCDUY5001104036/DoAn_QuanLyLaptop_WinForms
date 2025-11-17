using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 1. Thêm 2 'using' quan trọng
using QuanLyBanLaptop_BUS; // Để gọi lớp BUS
using QuanLyBanLaptop_DAL; // Để sử dụng lớp 'Product' (được LINQ tạo ra)

namespace QuanLyBanLaptop_GUI
{
    public partial class frmProductEdit : Form
    {
        // 2. Khai báo lớp BUS
        private ProductBUS productBUS;

        // BIẾN MỚI: Dùng để lưu ID của sản phẩm cần SỬA
        // Nếu biến này là NULL, form sẽ ở chế độ THÊM MỚI
        // Nếu biến này có giá trị, form sẽ ở chế độ SỬA
        private int? currentProductID = null;

        // TẠO CONSTRUCTOR (Hàm khởi tạo) MỚI
        // Hàm này sẽ được gọi khi ta muốn SỬA
        public frmProductEdit(int productID)
        {
            InitializeComponent();
            productBUS = new ProductBUS();

            // Lưu ID được truyền vào
            this.currentProductID = productID;
        }
        public frmProductEdit()
        {
            InitializeComponent();
            // 3. Khởi tạo lớp BUS
            productBUS = new ProductBUS();
        }

        // 4. SỰ KIỆN KHI FORM ĐƯỢC TẢI (FORM_LOAD)
        // (Cách tạo: Mở [Design], chọn Form, vào Properties -> Events (sấm sét) -> nhấp đúp vào 'Load')
        private void frmProductEdit_Load(object sender, EventArgs e)
        {
            // Tải danh sách hãng có sẵn vào ComboBox để gợi ý
            LoadBrandSuggestions();

            // KIỂM TRA XEM ĐÂY LÀ CHẾ ĐỘ 'SỬA' HAY 'THÊM'
            if (currentProductID != null)
            {
                // Đây là chế độ SỬA
                this.Text = "Sửa thông tin Sản phẩm"; // Đổi tiêu đề form
                btnSave.Text = "Cập nhật"; // Đổi chữ trên nút

                // Tải dữ liệu cũ lên form
                LoadProductDataForEdit();
            }
            else
            {
                // Đây là chế độ THÊM MỚI (như cũ)
                this.Text = "Thêm Sản phẩm mới";
            }
        }

        // HÀM MỚI: Tải dữ liệu sản phẩm lên các ô
        private void LoadProductDataForEdit()
        {
            Product product = productBUS.GetProductById(currentProductID.Value);

            if (product == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Đổ dữ liệu vào các control
            txtName.Text = product.Name;
            txtSKU.Text = product.SKU;
            cboBrand.Text = product.Brand; // Dùng .Text để gán, dù nó không có trong list
            txtModel.Text = product.Model;

            txtCPU.Text = product.CPU;
            txtRAM.Text = product.RAM;
            txtStorage.Text = product.Storage;
            txtGPU.Text = product.GPU;
            txtScreen.Text = product.ScreenSize;
            txtOS.Text = product.OS;

            numCostPrice.Value = product.CostPrice.GetValueOrDefault(0);
            numUnitPrice.Value = product.UnitPrice.GetValueOrDefault(0);
            numWarranty.Value = product.WarrantyMonths.GetValueOrDefault(12);
        }

        // Hàm tải gợi ý Hãng
        private void LoadBrandSuggestions()
        {
            // 5. CHỈNH LẠI THUỘC TÍNH COMBOBOX (Rất quan trọng)
            // Cho phép người dùng gõ tên hãng mới, hoặc chọn hãng có sẵn
            cboBrand.DropDownStyle = ComboBoxStyle.DropDown;
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Lấy các hãng độc nhất từ CSDL
            cboBrand.DataSource = productBUS.GetUniqueBrands();
            cboBrand.SelectedIndex = -1; // Không chọn gì cả
        }

        // 6. LOGIC NÚT "HỦY" (btnCancel)
        // (Cách tạo: Mở [Design], nhấp đúp vào nút "Hủy")
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Chỉ cần đóng form
        }

        // 7. LOGIC NÚT "LƯU" (btnSave)
        // (Cách tạo: Mở [Design], nhấp đúp vào nút "Lưu")
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ----- BƯỚC 1: KIỂM TRA DỮ LIỆU (VALIDATION) -----
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Sản Phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); // Focus vào ô bị lỗi
                return; // Dừng lại, không làm gì nữa
            }
            if (string.IsNullOrWhiteSpace(cboBrand.Text))
            {
                MessageBox.Show("Vui lòng nhập Hãng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBrand.Focus();
                return;
            }
            if (numUnitPrice.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập Giá Bán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numUnitPrice.Focus();
                return;
            }
            // Bước 2: KIỂM TRA CHẾ ĐỘ (SỬA hay THÊM)
            if (currentProductID == null)
            {
                // CHẾ ĐỘ THÊM MỚI (Code cũ)
                AddNewProduct();
            }
            else
            {
                // CHẾ ĐỘ SỬA
                UpdateExistingProduct();
            }
        }

            // HÀM MỚI: Logic Thêm (Tách ra từ code cũ)
        private void AddNewProduct()
        {
            Product newProduct = new Product();
            // Lấy dữ liệu từ Form gán vào đối tượng
            newProduct.Name = txtName.Text.Trim();
            newProduct.SKU = txtSKU.Text.Trim();
            newProduct.Brand = cboBrand.Text.Trim();
            newProduct.Model = txtModel.Text.Trim();
            newProduct.CPU = txtCPU.Text.Trim();
            newProduct.RAM = txtRAM.Text.Trim();
            newProduct.Storage = txtStorage.Text.Trim();
            newProduct.GPU = txtGPU.Text.Trim();
            newProduct.ScreenSize = txtScreen.Text.Trim();
            newProduct.OS = txtOS.Text.Trim();
            newProduct.CostPrice = numCostPrice.Value;
            newProduct.UnitPrice = numUnitPrice.Value;
            newProduct.WarrantyMonths = (int)numWarranty.Value;
            newProduct.CreatedAt = DateTime.Now;

            try
            {
                productBUS.AddProduct(newProduct);
                MessageBox.Show("Thêm sản phẩm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀM MỚI: Logic Cập nhật
        private void UpdateExistingProduct()
        {
            // Tạo một đối tượng Product và gán dữ liệu từ form
            Product updatedProduct = new Product();

            // Lấy cả ID
            updatedProduct.ProductID = currentProductID.Value;

            updatedProduct.Name = txtName.Text.Trim();
            updatedProduct.SKU = txtSKU.Text.Trim();
            updatedProduct.Brand = cboBrand.Text.Trim();
            updatedProduct.Model = txtModel.Text.Trim();
            updatedProduct.CPU = txtCPU.Text.Trim();
            updatedProduct.RAM = txtRAM.Text.Trim();
            updatedProduct.Storage = txtStorage.Text.Trim();
            updatedProduct.GPU = txtGPU.Text.Trim();
            updatedProduct.ScreenSize = txtScreen.Text.Trim();
            updatedProduct.OS = txtOS.Text.Trim();
            updatedProduct.CostPrice = numCostPrice.Value;
            updatedProduct.UnitPrice = numUnitPrice.Value;
            updatedProduct.WarrantyMonths = (int)numWarranty.Value;

            try
            {
                productBUS.UpdateProduct(updatedProduct);
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}