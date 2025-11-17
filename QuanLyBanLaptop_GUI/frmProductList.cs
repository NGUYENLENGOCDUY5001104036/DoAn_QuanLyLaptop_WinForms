using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 1. Thêm 'using' để "thấy" BUS và DAL (để dùng class 'Product')
using QuanLyBanLaptop_BUS;
using QuanLyBanLaptop_DAL;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmProductList : Form
    {
        // 2. Khai báo lớp BUS
        private ProductBUS productBUS;

        public frmProductList()
        {
            InitializeComponent();

            // ▼▼▼ THÊM DÒNG NÀY VÀO ▼▼▼
            dgvProducts.AutoGenerateColumns = false;
            // 3. Khởi tạo lớp BUS
            productBUS = new ProductBUS();
        }

        // 4. Sự kiện khi Form được tải (Form_Load)
        // (Để tạo sự kiện này, bạn vào [Design], nhấp đúp vào thanh tiêu đề form)
        private void frmProductList_Load(object sender, EventArgs e)
        {
            // Tải danh sách sản phẩm
            LoadProductList();

            // Tải danh sách Hãng vào ComboBox
            LoadBrandComboBox();
        }

        // 5. Hàm tải (hoặc làm mới) DataGridView
        private void LoadProductList()
        {
            // Gọi lớp BUS để lấy dữ liệu
            var danhSach = productBUS.GetAllProducts();

            // Gán dữ liệu cho DataGridView
            dgvProducts.DataSource = danhSach;

            // 6. Cấu hình lại cột (cho đẹp)
            ConfigureDataGridView();
        }

        // 7. Hàm cấu hình cột (tách ra cho sạch)
        private void ConfigureDataGridView()
        {
            //// --- THÊM DÒNG NÀY ĐỂ ĐẢM BẢO TIÊU ĐỀ LUÔN HIỆN ---
            //dgvProducts.ColumnHeadersVisible = true;
            //// --- BƯỚC 1: SET CHẾ ĐỘ TỰ ĐỘNG CO GIÃN ---
            //// Đây là dòng quan trọng nhất giúp hết bị khuất
            //// 'Fill' sẽ ép tất cả các cột 'Visible = true' lấp đầy chiều ngang của bảng
            //dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //// --- BƯỚC 2: ĐẶT LẠI TÊN TIÊU ĐỀ (CHO CÁC CỘT BẠN MUỐN HIỂN THỊ) ---
            //dgvProducts.Columns["ProductID"].HeaderText = "ID";// ID
            //dgvProducts.Columns["Name"].HeaderText = "Tên Sản Phẩm";
            //dgvProducts.Columns["Brand"].HeaderText = "Hãng";
            //dgvProducts.Columns["UnitPrice"].HeaderText = "Giá Bán";
            //dgvProducts.Columns["SKU"].HeaderText = "SKU";
            //dgvProducts.Columns["WarrantyMonths"].HeaderText = "Bảo hành (tháng)";

            //// --- BƯỚC 3: ẨN TẤT CẢ CÁC CỘT KHÔNG CẦN THIẾT (CHO FORM LIST) ---
            //dgvProducts.Columns["Model"].Visible = false;
            //dgvProducts.Columns["CPU"].Visible = false;
            //dgvProducts.Columns["RAM"].Visible = false;
            //dgvProducts.Columns["Storage"].Visible = false;
            //dgvProducts.Columns["GPU"].Visible = false;
            //dgvProducts.Columns["ScreenSize"].Visible = false;
            //dgvProducts.Columns["OS"].Visible = false;
            //dgvProducts.Columns["CostPrice"].Visible = false; // Giá vốn, nên ẩn
            //dgvProducts.Columns["ReorderLevel"].Visible = false;
            //dgvProducts.Columns["CreatedAt"].Visible = false; // Ngày tạo, không cần thiết

            //// (3 dòng này bạn đã comment out từ trước, cứ để nguyên)
            //// dgvProducts.Columns["PurchaseDetails"].Visible = false;
            //// dgvProducts.Columns["DeviceUnits"].Visible = false;
            //// dgvProducts.Columns["OrderDetails"].Visible = false;

            //// --- BƯỚC 4: (TÙY CHỈNH) SET ĐỘ RỘNG ƯU TIÊN ---
            //// Sau khi set 'Fill', bạn có thể 'ưu tiên' độ rộng cho các cột
            //// Cột 'Name' (Tên SP) nên rộng nhất
            //dgvProducts.Columns["Name"].FillWeight = 200; // Ưu tiên 200%
            //dgvProducts.Columns["SKU"].FillWeight = 120;  // 120%
            //dgvProducts.Columns["Brand"].FillWeight = 100; // 100%
        }

        // 8. Hàm tải danh sách Hãng vào ComboBox
        private void LoadBrandComboBox()
        {
            var brandList = productBUS.GetUniqueBrands();

            // Thêm một mục "Tất cả" vào đầu danh sách
            brandList.Insert(0, "Tất cả");

            cboSearchBrand.DataSource = brandList;
            cboSearchBrand.SelectedIndex = 0; // Chọn "Tất cả" làm mặc định
        }

        // 9. Logic cho nút "Làm mới" (btnRefresh)
        // (Để tạo, vào [Design], nhấp đúp vào nút "Làm mới")
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Xóa rỗng các ô tìm kiếm
            txtSearchName.Text = "";
            cboSearchBrand.SelectedIndex = 0; // Đặt về "Tất cả"

            // Tải lại toàn bộ danh sách
            LoadProductList();
        }

        // 10. Logic cho nút "Đóng"
        // (Để tạo, vào [Design], nhấp đúp vào nút "Đóng")
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form này
        }

        // 11. Logic cho nút "Tìm kiếm" (btnSearch)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 1. Lấy giá trị từ các ô tìm kiếm
            // .Trim() để xóa khoảng trắng thừa
            string searchName = txtSearchName.Text.Trim();
            string searchBrand = cboSearchBrand.SelectedItem.ToString();

            // 2. Gọi BUS để lấy kết quả tìm kiếm
            var searchResult = productBUS.SearchProducts(searchName, searchBrand);

            // 3. Hiển thị kết quả lên DataGridView
            dgvProducts.DataSource = searchResult;

            // 4. (RẤT QUAN TRỌNG) Gọi lại hàm cấu hình cột
            // Vì khi gán DataSource mới, các cột có thể bị reset
            ConfigureDataGridView();
        }
        // 12. Logic cho nút "Thêm mới" (btnAddNew)
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // 1. Tạo một đối tượng của form frmProductEdit
            frmProductEdit formChiTiet = new frmProductEdit();

            // 2. Mở form đó dưới dạng Dialog
            // .ShowDialog() sẽ "đóng băng" form frmProductList
            // cho đến khi formChiTiet được đóng lại.
            formChiTiet.ShowDialog();

            // 3. (RẤT QUAN TRỌNG)
            // Sau khi formChiTiet đóng, chúng ta tải lại danh sách
            // để cập nhật sản phẩm mới (nếu có)
            LoadProductList();
        }
        // ... (Bạn đã có hàm btnAddNew_Click ở trên) ...

        // 13. Logic cho nút "Xóa" (btnDelete)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // ----- BƯỚC 1: KIỂM TRA XEM ĐÃ CHỌN HÀNG NÀO CHƯA -----
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại
            }

            // ----- BƯỚC 2: LẤY ID VÀ TÊN SẢN PHẨM TỪ HÀNG ĐÃ CHỌN -----
            // Lấy ra hàng đang được chọn (chúng ta đã set MultiSelect = False)
            DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];

            // Lấy ID (dù cột ProductID bị ẩn, dữ liệu vẫn ở đó)
            int productID = (int)selectedRow.Cells["ProductID"].Value;
            // Lấy tên để hiển thị trong thông báo
            string productName = selectedRow.Cells["Name"].Value.ToString();


            // ----- BƯỚC 3: HỎI XÁC NHẬN (QUAN TRỌNG NHẤT) -----
            DialogResult result = MessageBox.Show(
                $"Bạn có thật sự muốn xóa sản phẩm '{productName}' (ID: {productID}) không?" +
                $"\n\nLƯU Ý: Nếu sản phẩm đã có trong đơn hàng, bạn sẽ không thể xóa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Nếu người dùng KHÔNG chọn "Yes"
            if (result != DialogResult.Yes)
            {
                return; // Dừng lại
            }

            // ----- BƯỚC 4: THỰC THI XÓA VÀ BẮT LỖI -----
            try
            {
                // Gọi BUS để xóa
                productBUS.DeleteProduct(productID);

                // Nếu xóa thành công:
                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại lưới để làm mới
                LoadProductList();
            }
            catch (Exception ex)
            {
                // BẮT LỖI: Thường là lỗi FOREIGN KEY (khóa ngoại)
                MessageBox.Show(
                    $"Không thể xóa sản phẩm này. Sản phẩm có thể đã tồn tại trong kho (DeviceUnits) hoặc trong một đơn hàng đã bán (OrderDetails)." +
                    $"\n\nChi tiết lỗi: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // 14. Logic cho nút "Xem / Sửa" (btnEdit)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productID = (int)dgvProducts.SelectedRows[0].Cells["ProductID"].Value;

            // Quan trọng: Gọi hàm khởi tạo MỚI, truyền 'productID' vào
            frmProductEdit formSua = new frmProductEdit(productID);

            formSua.ShowDialog();
            LoadProductList();
        }

        //Quản lý Serial
        private void btnManageSerials_Click(object sender, EventArgs e)
        {
            frmDeviceUnits formKho = new frmDeviceUnits();
            formKho.Show(); // Dùng .Show() để có thể mở song song 2 form
        }

        //Quản lý Khách Hàng
        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            frmCustomerManagement formKH = new frmCustomerManagement();
            formKH.ShowDialog(); // Dùng .ShowDialog()
        }

        //Tạo Đơn Hàng
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            frmOrderCreate formTaoDon = new frmOrderCreate();
            formTaoDon.ShowDialog();
        }


    }
}