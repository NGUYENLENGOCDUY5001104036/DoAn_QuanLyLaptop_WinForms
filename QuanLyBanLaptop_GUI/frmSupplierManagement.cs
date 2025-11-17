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
    public partial class frmSupplierManagement : Form
    {
        private SupplierBUS supplierBUS;

        public frmSupplierManagement()
        {
            InitializeComponent();
            supplierBUS = new SupplierBUS();
            dgvSuppliers.AutoGenerateColumns = false; // Tắt tự động tạo cột
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmSupplierManagement_Load(object sender, EventArgs e)
        {
            LoadSupplierGrid();
        }

        // Tải lưới
        private void LoadSupplierGrid()
        {
            dgvSuppliers.DataSource = null;
            dgvSuppliers.DataSource = supplierBUS.GetAllSuppliers();
            ConfigureDataGridView();
        }

        // Cấu hình cột
        private void ConfigureDataGridView()
        {
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //if (dgvSuppliers.Columns.Count == 0) return;

            //dgvSuppliers.Columns["SupplierID"].HeaderText = "ID";
            //dgvSuppliers.Columns["Name"].HeaderText = "Tên Nhà cung cấp";
            //dgvSuppliers.Columns["Contact"].HeaderText = "Người liên hệ";
            //dgvSuppliers.Columns["Phone"].HeaderText = "SĐT";
            //dgvSuppliers.Columns["Address"].HeaderText = "Địa chỉ";

            //dgvSuppliers.Columns["Name"].FillWeight = 150;
            //dgvSuppliers.Columns["Address"].FillWeight = 200;
            //dgvSuppliers.Columns["PurchaseOrders"].Visible = false; // Ẩn cột quan hệ
        }

        // Nút Đóng (NHỚ NỐI DÂY!)
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút Thêm mới (NHỚ NỐI DÂY!)
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmSupplierEdit formThem = new frmSupplierEdit();
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadSupplierGrid(); // Tải lại
            }
        }

        // Nút Sửa (NHỚ NỐI DÂY!)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count == 0) return;
            int supplierID = (int)dgvSuppliers.SelectedRows[0].Cells["SupplierID"].Value;

            frmSupplierEdit formSua = new frmSupplierEdit(supplierID);
            if (formSua.ShowDialog() == DialogResult.OK)
            {
                LoadSupplierGrid(); // Tải lại
            }
        }

        // Nút Xóa (NHỚ NỐI DÂY!)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count == 0) return;
            int supplierID = (int)dgvSuppliers.SelectedRows[0].Cells["SupplierID"].Value;
            string supplierName = dgvSuppliers.SelectedRows[0].Cells["Name"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa '{supplierName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                supplierBUS.DeleteSupplier(supplierID);
                MessageBox.Show("Xóa thành công.");
                LoadSupplierGrid(); // Tải lại
            }
            catch
            {
                MessageBox.Show($"Lỗi khi xóa: Không thể xóa Nhà cung cấp đã có Phiếu nhập.", "Lỗi Khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}