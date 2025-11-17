using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanLaptop_BUS;
using QuanLyBanLaptop_DAL;

namespace QuanLyBanLaptop_GUI
{
    public partial class frmSupplierEdit : Form
    {
        private SupplierBUS supplierBUS;
        private int? currentSupplierID = null;

        // Constructor 1: Thêm mới
        public frmSupplierEdit()
        {
            InitializeComponent();
            supplierBUS = new SupplierBUS();
            this.Text = "Thêm mới Nhà cung cấp";
        }

        // Constructor 2: Sửa
        public frmSupplierEdit(int supplierID)
        {
            InitializeComponent();
            supplierBUS = new SupplierBUS();
            this.currentSupplierID = supplierID;
            this.Text = "Sửa thông tin Nhà cung cấp";
            btnSave.Text = "Cập nhật";
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmSupplierEdit_Load(object sender, EventArgs e)
        {
            if (currentSupplierID != null)
            {
                LoadSupplierData();
            }
        }

        // Tải dữ liệu khi Sửa
        private void LoadSupplierData()
        {
            Supplier supplier = supplierBUS.GetSupplierById(currentSupplierID.Value);
            if (supplier != null)
            {
                txtName.Text = supplier.Name;
                txtContact.Text = supplier.Contact;
                txtPhone.Text = supplier.Phone;
                txtEmail.Text = supplier.Email;
                txtAddress.Text = supplier.Address;
            }
        }

        // Nút Hủy (NHỚ NỐI DÂY!)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Nút Lưu (NHỚ NỐI DÂY!)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSupplierID == null) // Chế độ THÊM MỚI
                {
                    Supplier newSupplier = new Supplier
                    {
                        Name = txtName.Text.Trim(),
                        Contact = txtContact.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Address = txtAddress.Text.Trim()
                    };
                    supplierBUS.AddSupplier(newSupplier);
                    MessageBox.Show("Thêm Nhà cung cấp mới thành công!");
                }
                else // Chế độ CẬP NHẬT
                {
                    Supplier updatedSupplier = new Supplier
                    {
                        SupplierID = currentSupplierID.Value,
                        Name = txtName.Text.Trim(),
                        Contact = txtContact.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Address = txtAddress.Text.Trim()
                    };
                    supplierBUS.UpdateSupplier(updatedSupplier);
                    MessageBox.Show("Cập nhật thông tin thành công!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}