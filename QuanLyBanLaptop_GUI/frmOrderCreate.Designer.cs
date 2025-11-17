namespace QuanLyBanLaptop_GUI
{
    partial class frmOrderCreate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.txtPhoneSearch = new System.Windows.Forms.TextBox();
            this.btnSearchPhone = new System.Windows.Forms.Button();
            this.cboCustomers = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpThemHang = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cboSerials = new System.Windows.Forms.ComboBox();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpGioHang = new System.Windows.Forms.GroupBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.pnlThanhToan = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpKhachHang.SuspendLayout();
            this.grpThemHang.SuspendLayout();
            this.grpGioHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpKhachHang
            // 
            this.grpKhachHang.Controls.Add(this.txtPhoneSearch);
            this.grpKhachHang.Controls.Add(this.btnSearchPhone);
            this.grpKhachHang.Controls.Add(this.cboCustomers);
            this.grpKhachHang.Controls.Add(this.lblAddress);
            this.grpKhachHang.Controls.Add(this.lblPhone);
            this.grpKhachHang.Controls.Add(this.label3);
            this.grpKhachHang.Controls.Add(this.label2);
            this.grpKhachHang.Controls.Add(this.label1);
            this.grpKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpKhachHang.Location = new System.Drawing.Point(0, 0);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Size = new System.Drawing.Size(978, 200);
            this.grpKhachHang.TabIndex = 0;
            this.grpKhachHang.TabStop = false;
            this.grpKhachHang.Text = "1. Thông tin Khách hàng";
            this.grpKhachHang.Enter += new System.EventHandler(this.grpKhachHang_Enter);
            // 
            // txtPhoneSearch
            // 
            this.txtPhoneSearch.Location = new System.Drawing.Point(148, 30);
            this.txtPhoneSearch.Name = "txtPhoneSearch";
            this.txtPhoneSearch.Size = new System.Drawing.Size(270, 26);
            this.txtPhoneSearch.TabIndex = 6;
            // 
            // btnSearchPhone
            // 
            this.btnSearchPhone.Location = new System.Drawing.Point(461, 31);
            this.btnSearchPhone.Name = "btnSearchPhone";
            this.btnSearchPhone.Size = new System.Drawing.Size(137, 33);
            this.btnSearchPhone.TabIndex = 7;
            this.btnSearchPhone.Text = "Tìm kiếm";
            this.btnSearchPhone.UseVisualStyleBackColor = true;
            this.btnSearchPhone.Click += new System.EventHandler(this.btnSearchPhone_Click);
            // 
            // cboCustomers
            // 
            this.cboCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomers.FormattingEnabled = true;
            this.cboCustomers.Location = new System.Drawing.Point(148, 78);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Size = new System.Drawing.Size(270, 28);
            this.cboCustomers.TabIndex = 5;
            this.cboCustomers.SelectedIndexChanged += new System.EventHandler(this.cboCustomers_SelectedIndexChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(148, 128);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(21, 20);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "...";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(160, 33);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(21, 20);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Điện thoại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Khách hàng:";
            // 
            // grpThemHang
            // 
            this.grpThemHang.Controls.Add(this.btnAddItem);
            this.grpThemHang.Controls.Add(this.cboSerials);
            this.grpThemHang.Controls.Add(this.cboProducts);
            this.grpThemHang.Controls.Add(this.lblUnitPrice);
            this.grpThemHang.Controls.Add(this.label8);
            this.grpThemHang.Controls.Add(this.label7);
            this.grpThemHang.Controls.Add(this.label6);
            this.grpThemHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThemHang.Location = new System.Drawing.Point(0, 200);
            this.grpThemHang.Name = "grpThemHang";
            this.grpThemHang.Size = new System.Drawing.Size(978, 200);
            this.grpThemHang.TabIndex = 1;
            this.grpThemHang.TabStop = false;
            this.grpThemHang.Text = "2. Thêm hàng vào giỏ";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(686, 64);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(175, 60);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "Thêm vào giỏ hàng";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cboSerials
            // 
            this.cboSerials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSerials.FormattingEnabled = true;
            this.cboSerials.Location = new System.Drawing.Point(240, 81);
            this.cboSerials.Name = "cboSerials";
            this.cboSerials.Size = new System.Drawing.Size(292, 28);
            this.cboSerials.TabIndex = 5;
            // 
            // cboProducts
            // 
            this.cboProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(240, 32);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(292, 28);
            this.cboProducts.TabIndex = 4;
            this.cboProducts.SelectedIndexChanged += new System.EventHandler(this.cboProducts_SelectedIndexChanged);
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPrice.Location = new System.Drawing.Point(240, 130);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(19, 20);
            this.lblUnitPrice.TabIndex = 3;
            this.lblUnitPrice.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Giá bán:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Chọn Serial (máy):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chọn Sản phẩm (Model):";
            // 
            // grpGioHang
            // 
            this.grpGioHang.Controls.Add(this.btnRemoveItem);
            this.grpGioHang.Controls.Add(this.dgvCart);
            this.grpGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGioHang.Location = new System.Drawing.Point(0, 400);
            this.grpGioHang.Name = "grpGioHang";
            this.grpGioHang.Size = new System.Drawing.Size(978, 394);
            this.grpGioHang.TabIndex = 2;
            this.grpGioHang.TabStop = false;
            this.grpGioHang.Text = "3. Giỏ hàng";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemoveItem.Location = new System.Drawing.Point(3, 331);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(972, 60);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.Text = "Xóa khỏi giỏ";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colSerialNumber,
            this.colQuantity,
            this.colUnitPrice,
            this.colTotalPrice});
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(3, 22);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersWidth = 62;
            this.dgvCart.RowTemplate.Height = 28;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(972, 369);
            this.dgvCart.TabIndex = 5;
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Controls.Add(this.btnCancel);
            this.pnlThanhToan.Controls.Add(this.btnSaveOrder);
            this.pnlThanhToan.Controls.Add(this.lblTotalAmount);
            this.pnlThanhToan.Controls.Add(this.label10);
            this.pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToan.Location = new System.Drawing.Point(0, 794);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(978, 150);
            this.pnlThanhToan.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(806, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(173, 55);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveOrder.Location = new System.Drawing.Point(600, 95);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(173, 55);
            this.btnSaveOrder.TabIndex = 2;
            this.btnSaveOrder.Text = "Lưu Đơn Hàng";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(148, 20);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "TỔNG TIỀN:";
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Tên sản phẩm";
            this.colProductName.MinimumWidth = 8;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 150;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "Serial";
            this.colSerialNumber.MinimumWidth = 8;
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 150;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Số lượng";
            this.colQuantity.MinimumWidth = 8;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 150;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "Đơn giá";
            this.colUnitPrice.MinimumWidth = 8;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 150;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.DataPropertyName = "TotalPrice";
            this.colTotalPrice.HeaderText = "Thành tiền";
            this.colTotalPrice.MinimumWidth = 8;
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.ReadOnly = true;
            this.colTotalPrice.Width = 150;
            // 
            // frmOrderCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 944);
            this.Controls.Add(this.grpGioHang);
            this.Controls.Add(this.pnlThanhToan);
            this.Controls.Add(this.grpThemHang);
            this.Controls.Add(this.grpKhachHang);
            this.Name = "frmOrderCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Đơn Bán Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOrderCreate_Load);
            this.grpKhachHang.ResumeLayout(false);
            this.grpKhachHang.PerformLayout();
            this.grpThemHang.ResumeLayout(false);
            this.grpThemHang.PerformLayout();
            this.grpGioHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpKhachHang;
        private System.Windows.Forms.GroupBox grpThemHang;
        private System.Windows.Forms.GroupBox grpGioHang;
        private System.Windows.Forms.Panel pnlThanhToan;
        private System.Windows.Forms.ComboBox cboCustomers;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cboSerials;
        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnSearchPhone;
        private System.Windows.Forms.TextBox txtPhoneSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
    }
}