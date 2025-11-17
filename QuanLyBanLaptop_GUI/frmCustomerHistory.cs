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
    public partial class frmCustomerHistory : Form
    {
        private OrderBUS orderBUS;
        private int currentCustomerID;
        private string currentCustomerName;

        // Constructor (Hàm khởi tạo) nhận ID và Tên
        public frmCustomerHistory(int customerID, string customerName)
        {
            InitializeComponent();
            orderBUS = new OrderBUS();
            this.currentCustomerID = customerID;
            this.currentCustomerName = customerName;

            // ▼▼▼ THÊM 2 DÒNG NÀY ▼▼▼
            dgvOrders.AutoGenerateColumns = false;
            dgvOrderDetails.AutoGenerateColumns = false;
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY SỰ KIỆN NÀY!)
        private void frmCustomerHistory_Load(object sender, EventArgs e)
        {
            lblCustomerName.Text = this.currentCustomerName; // Gán tên
            LoadOrdersList(); // Tải danh sách đơn hàng

            // Nối dây sự kiện 'SelectionChanged' cho bảng Orders
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
        }

        // Tải danh sách Đơn hàng (bảng trên)
        private void LoadOrdersList()
        {
            dgvOrders.DataSource = null;
            var orderList = orderBUS.GetOrdersByCustomer(currentCustomerID);
            dgvOrders.DataSource = orderList;

            // ===============================================
            // THÊM BƯỚC KIỂM TRA "BẢO VỆ" NÀY
            // ===============================================
            // Nếu danh sách rỗng (không có đơn hàng), 
            // DataGridView sẽ không có cột nào. Dừng lại luôn.
            if (orderList.Count == 0)
            {
                return; // Dừng, không làm gì nữa
            }

            // Cấu hình cột (Code này chỉ chạy nếu CÓ đơn hàng)
            //dgvOrders.Columns["OrderID"].HeaderText = "Mã ĐH";
            //dgvOrders.Columns["OrderDate"].HeaderText = "Ngày mua";
            //dgvOrders.Columns["TotalAmount"].HeaderText = "Tổng tiền";
            //dgvOrders.Columns["Status"].HeaderText = "Trạng thái";

            //// Ẩn các cột không cần thiết (BỎ COMMENT TẤT CẢ)
            //dgvOrders.Columns["CustomerID"].Visible = false;
            //dgvOrders.Columns["CreatedBy"].Visible = false;
            //dgvOrders.Columns["Customer"].Visible = false;
            //dgvOrders.Columns["User"].Visible = false;
            //dgvOrders.Columns["OrderDetails"].Visible = false; // Dòng này cũng bỏ comment
        }

        // Sự kiện khi nhấp vào một dòng trong bảng Đơn hàng
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào đang được chọn không
            if (dgvOrders.SelectedRows.Count > 0)
            {
                // --- CÁCH SỬA: Dùng DataBoundItem (An toàn tuyệt đối) ---

                // 1. Lấy dòng đang được chọn
                DataGridViewRow selectedRow = dgvOrders.SelectedRows[0];

                // 2. Lấy đối tượng gốc (Order) từ dòng đó
                // (Vì DataSource của bảng này là List<Order>)
                QuanLyBanLaptop_DAL.Order selectedOrder = (QuanLyBanLaptop_DAL.Order)selectedRow.DataBoundItem;

                // 3. Lấy ID từ đối tượng (Không cần quan tâm tên cột trên giao diện là gì)
                int orderID = selectedOrder.OrderID;

                // -------------------------------------------------------

                // Tải chi tiết cho đơn hàng đó
                LoadOrderDetails(orderID);
            }
        }
        // Tải Chi tiết Đơn hàng (bảng dưới)
        private void LoadOrderDetails(int orderID)
        {
            dgvOrderDetails.DataSource = null;
            var detailList = orderBUS.GetOrderDetails(orderID);
            dgvOrderDetails.DataSource = detailList;

            //// Cấu hình cột
            //dgvOrderDetails.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
            //dgvOrderDetails.Columns["SerialNumber"].HeaderText = "Serial Number";
            //dgvOrderDetails.Columns["Quantity"].HeaderText = "Số lượng";
            //dgvOrderDetails.Columns["UnitPrice"].HeaderText = "Đơn giá";
            //dgvOrderDetails.Columns["TotalPrice"].HeaderText = "Thành tiền";
        }

        // Nút Đóng (NHỚ NỐI DÂY SỰ KIỆN NÀY!)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}