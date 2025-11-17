using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // <-- THÊM DÒNG NÀY
using System.IO;            // <-- THÊM CẢ DÒNG NÀY (cho chắc)

namespace QuanLyBanLaptop_GUI
{
    public partial class frmSettings : Form
    {
        // Biến tạm để lưu đường dẫn logo mới (nếu có)
        private string _newLogoPath = null;

        public frmSettings()
        {
            InitializeComponent();
        }

        // Sự kiện Form_Load (NHỚ NỐI DÂY!)
        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadCurrentSettings();
        }

        // Hàm đọc cài đặt từ App.config và tải lên
        private void LoadCurrentSettings()
        {
            txtStoreName.Text = ConfigurationManager.AppSettings.Get("StoreName");
            txtStorePhone.Text = ConfigurationManager.AppSettings.Get("StorePhone");
            txtStoreAddress.Text = ConfigurationManager.AppSettings.Get("StoreAddress");

            string logoPath = ConfigurationManager.AppSettings.Get("StoreLogoPath");
            if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
            {
                picLogo.ImageLocation = logoPath;
            }
        }

        // Nút "Hủy" (NHỚ NỐI DÂY!)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút "Chọn Logo..." (NHỚ NỐI DÂY!)
        private void btnChangeLogo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Chọn file Logo";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Thay vì copy, lần này chúng ta chỉ lưu đường dẫn tuyệt đối
                // (Vì file logo không nên nằm trong thư mục 'bin')
                _newLogoPath = openFileDialog1.FileName;
                picLogo.ImageLocation = _newLogoPath;
            }
        }

        // Nút "Lưu Cấu hình" (NHỚ NỐI DÂY!)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Mở file App.config
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // 2. Cập nhật các giá trị
                config.AppSettings.Settings["StoreName"].Value = txtStoreName.Text;
                config.AppSettings.Settings["StorePhone"].Value = txtStorePhone.Text;
                config.AppSettings.Settings["StoreAddress"].Value = txtStoreAddress.Text;

                // 3. Chỉ cập nhật logo nếu người dùng đã chọn ảnh mới
                if (_newLogoPath != null)
                {
                    config.AppSettings.Settings["StoreLogoPath"].Value = _newLogoPath;
                }

                // 4. Lưu file
                config.Save(ConfigurationSaveMode.Modified);

                // 5. Tải lại cấu hình
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Lưu cấu hình thành công!", "Thông báo");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}", "Lỗi");
            }
        }
    }
}