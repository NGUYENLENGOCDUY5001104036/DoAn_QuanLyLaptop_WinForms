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
    public partial class frmUpdateStatus : Form
    {
        // Public property (thuộc tính) để form cha (frmDeviceUnits)
        // lấy được giá trị người dùng đã chọn
        public string SelectedStatus { get; private set; }

        // Hàm khởi tạo, nhận vào trạng thái HIỆN TẠI
        public frmUpdateStatus(string currentStatus)
        {
            InitializeComponent();

            // Tải các trạng thái hợp lệ vào ComboBox
            var statusList = new List<string> { "IN_STOCK", "REPAIR", "RESERVED" };
            cboNewStatus.DataSource = statusList;

            // Tự động chọn trạng thái mới khác với trạng thái cũ
            if (currentStatus == "IN_STOCK")
            {
                cboNewStatus.SelectedItem = "REPAIR"; // Gợi ý
            }
            else
            {
                cboNewStatus.SelectedItem = "IN_STOCK"; // Gợi ý
            }
        }

        // Sự kiện Click cho nút OK
        // (Vào [Design] nhấp đúp vào nút "OK")
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Gán giá trị đã chọn vào public property
            this.SelectedStatus = cboNewStatus.SelectedItem.ToString();
            // Không cần làm gì thêm, vì 'DialogResult = OK' sẽ tự đóng form
        }

        private void frmUpdateStatus_Load(object sender, EventArgs e)
        {

        }

        // (Không cần code cho nút Hủy, vì 'DialogResult = Cancel' tự xử lý)
    }
}