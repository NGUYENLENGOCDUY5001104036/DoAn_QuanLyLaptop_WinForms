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
    public partial class frmCustomerEdit : Form
    {
        private CustomerBUS customerBUS;

        // Biến để lưu ID khi ở chế độ "Sửa"
        private int? currentCustomerID = null;

        // Constructor 1: Dùng cho "Thêm mới"
        public frmCustomerEdit()
        {
            InitializeComponent();
            customerBUS = new CustomerBUS();
            this.Text = "Thêm mới Khách hàng";
        }

        // Constructor 2: Dùng cho "Sửa"
        public frmCustomerEdit(int customerID)
        {
            InitializeComponent();
            customerBUS = new CustomerBUS();
            this.currentCustomerID = customerID;
            this.Text = "Sửa thông tin Khách hàng";
            btnSave.Text = "Cập nhật";
        }

        // Sự kiện Form_Load (Nối dây sự kiện này!)
        private void frmCustomerEdit_Load(object sender, EventArgs e)
        {
            // Nếu là chế độ "Sửa" (ID có giá trị)
            if (currentCustomerID != null)
            {
                // Tải dữ liệu cũ lên
                LoadCustomerDataForEdit();
            }
        }

        // Hàm tải dữ liệu cũ (chế độ Sửa)
        private void LoadCustomerDataForEdit()
        {
            Customer customer = customerBUS.GetCustomerById(currentCustomerID.Value);
            if (customer != null)
            {
                txtName.Text = customer.Name;
                txtPhone.Text = customer.Phone;
                txtEmail.Text = customer.Email;
                txtAddress.Text = customer.Address;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng!", "Lỗi");
                this.Close();
            }
        }

        // Sự kiện nút "Hủy" (Nối dây sự kiện này!)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện nút "Lưu" (Nối dây sự kiện này!)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validation (Kiểm tra dữ liệu)
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // 2. Quyết định Thêm hay Sửa
            try
            {
                if (currentCustomerID == null)
                {
                    // Chế độ THÊM MỚI
                    Customer newCustomer = new Customer
                    {
                        Name = txtName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Address = txtAddress.Text.Trim()
                    };
                    customerBUS.AddCustomer(newCustomer);
                    MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo");
                }
                else
                {
                    // Chế độ CẬP NHẬT
                    Customer updatedCustomer = new Customer
                    {
                        CustomerID = currentCustomerID.Value, // Lấy ID
                        Name = txtName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Address = txtAddress.Text.Trim()
                    };
                    customerBUS.UpdateCustomer(updatedCustomer);
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                }

                this.DialogResult = DialogResult.OK; // Báo cho form cha biết là đã thành công
                this.Close(); // Đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
