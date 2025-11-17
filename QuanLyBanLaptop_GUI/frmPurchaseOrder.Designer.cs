namespace QuanLyBanLaptop_GUI
{
    partial class frmPurchaseOrder
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
            this.grpNhaCungCap = new System.Windows.Forms.GroupBox();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpThemHang = new System.Windows.Forms.GroupBox();
            this.numCostPrice = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSerials = new System.Windows.Forms.GroupBox();
            this.txtSerialList = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblSerialCount = new System.Windows.Forms.Label();
            this.grpPhieuNhap = new System.Windows.Forms.GroupBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.dgvPurchaseCart = new System.Windows.Forms.DataGridView();
            this.pnlThanhToan = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSavePurchase = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpNhaCungCap.SuspendLayout();
            this.grpThemHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpSerials.SuspendLayout();
            this.grpPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseCart)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNhaCungCap
            // 
            this.grpNhaCungCap.Controls.Add(this.dtpPurchaseDate);
            this.grpNhaCungCap.Controls.Add(this.cboSuppliers);
            this.grpNhaCungCap.Controls.Add(this.label2);
            this.grpNhaCungCap.Controls.Add(this.label1);
            this.grpNhaCungCap.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNhaCungCap.Location = new System.Drawing.Point(0, 0);
            this.grpNhaCungCap.Name = "grpNhaCungCap";
            this.grpNhaCungCap.Size = new System.Drawing.Size(978, 130);
            this.grpNhaCungCap.TabIndex = 0;
            this.grpNhaCungCap.TabStop = false;
            this.grpNhaCungCap.Text = "1. Thông tin Phiếu nhập";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(205, 85);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(281, 26);
            this.dtpPurchaseDate.TabIndex = 3;
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSuppliers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(205, 43);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(281, 28);
            this.cboSuppliers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn nhà cung cấp:";
            // 
            // grpThemHang
            // 
            this.grpThemHang.Controls.Add(this.numCostPrice);
            this.grpThemHang.Controls.Add(this.numQuantity);
            this.grpThemHang.Controls.Add(this.cboProducts);
            this.grpThemHang.Controls.Add(this.label5);
            this.grpThemHang.Controls.Add(this.label4);
            this.grpThemHang.Controls.Add(this.label3);
            this.grpThemHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThemHang.Location = new System.Drawing.Point(0, 130);
            this.grpThemHang.Name = "grpThemHang";
            this.grpThemHang.Size = new System.Drawing.Size(978, 180);
            this.grpThemHang.TabIndex = 1;
            this.grpThemHang.TabStop = false;
            this.grpThemHang.Text = "2. Thêm Sản phẩm vào phiếu";
            // 
            // numCostPrice
            // 
            this.numCostPrice.Location = new System.Drawing.Point(205, 118);
            this.numCostPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numCostPrice.Name = "numCostPrice";
            this.numCostPrice.Size = new System.Drawing.Size(281, 26);
            this.numCostPrice.TabIndex = 5;
            this.numCostPrice.ThousandsSeparator = true;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(205, 78);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(281, 26);
            this.numQuantity.TabIndex = 4;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboProducts
            // 
            this.cboProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(205, 36);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(282, 28);
            this.cboProducts.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Giá nhập / đơn vị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sản phẩm (Model):";
            // 
            // grpSerials
            // 
            this.grpSerials.Controls.Add(this.txtSerialList);
            this.grpSerials.Controls.Add(this.btnAddItem);
            this.grpSerials.Controls.Add(this.lblSerialCount);
            this.grpSerials.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSerials.Location = new System.Drawing.Point(0, 310);
            this.grpSerials.Name = "grpSerials";
            this.grpSerials.Size = new System.Drawing.Size(978, 200);
            this.grpSerials.TabIndex = 2;
            this.grpSerials.TabStop = false;
            this.grpSerials.Text = "3. Nhập Serial (1 serial / 1 dòng)";
            // 
            // txtSerialList
            // 
            this.txtSerialList.Location = new System.Drawing.Point(33, 38);
            this.txtSerialList.Multiline = true;
            this.txtSerialList.Name = "txtSerialList";
            this.txtSerialList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialList.Size = new System.Drawing.Size(453, 138);
            this.txtSerialList.TabIndex = 3;
            this.txtSerialList.TextChanged += new System.EventHandler(this.txtSerialList_TextChanged);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(556, 109);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(145, 46);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Thêm vào Phiếu";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblSerialCount
            // 
            this.lblSerialCount.AutoSize = true;
            this.lblSerialCount.Location = new System.Drawing.Point(552, 63);
            this.lblSerialCount.Name = "lblSerialCount";
            this.lblSerialCount.Size = new System.Drawing.Size(149, 20);
            this.lblSerialCount.TabIndex = 0;
            this.lblSerialCount.Text = "Số serial đã nhập: 0";
            // 
            // grpPhieuNhap
            // 
            this.grpPhieuNhap.Controls.Add(this.btnRemoveItem);
            this.grpPhieuNhap.Controls.Add(this.dgvPurchaseCart);
            this.grpPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPhieuNhap.Location = new System.Drawing.Point(0, 510);
            this.grpPhieuNhap.Name = "grpPhieuNhap";
            this.grpPhieuNhap.Size = new System.Drawing.Size(978, 510);
            this.grpPhieuNhap.TabIndex = 3;
            this.grpPhieuNhap.TabStop = false;
            this.grpPhieuNhap.Text = "4. Chi tiết Phiếu nhập";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRemoveItem.Location = new System.Drawing.Point(3, 453);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(972, 54);
            this.btnRemoveItem.TabIndex = 0;
            this.btnRemoveItem.Text = "Xóa";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // dgvPurchaseCart
            // 
            this.dgvPurchaseCart.AllowUserToAddRows = false;
            this.dgvPurchaseCart.AllowUserToDeleteRows = false;
            this.dgvPurchaseCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colSerialNumber,
            this.colQuantity,
            this.colCostPrice,
            this.colTotalPrice});
            this.dgvPurchaseCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseCart.Location = new System.Drawing.Point(3, 22);
            this.dgvPurchaseCart.Name = "dgvPurchaseCart";
            this.dgvPurchaseCart.ReadOnly = true;
            this.dgvPurchaseCart.RowHeadersWidth = 62;
            this.dgvPurchaseCart.RowTemplate.Height = 28;
            this.dgvPurchaseCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseCart.Size = new System.Drawing.Size(972, 485);
            this.dgvPurchaseCart.TabIndex = 1;
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Controls.Add(this.btnCancel);
            this.pnlThanhToan.Controls.Add(this.btnSavePurchase);
            this.pnlThanhToan.Controls.Add(this.lblTotalAmount);
            this.pnlThanhToan.Controls.Add(this.label8);
            this.pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToan.Location = new System.Drawing.Point(0, 1020);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(978, 124);
            this.pnlThanhToan.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(225, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 43);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSavePurchase
            // 
            this.btnSavePurchase.Location = new System.Drawing.Point(33, 68);
            this.btnSavePurchase.Name = "btnSavePurchase";
            this.btnSavePurchase.Size = new System.Drawing.Size(170, 43);
            this.btnSavePurchase.TabIndex = 2;
            this.btnSavePurchase.Text = "Lưu Phiếu Nhập";
            this.btnSavePurchase.UseVisualStyleBackColor = true;
            this.btnSavePurchase.Click += new System.EventHandler(this.btnSavePurchase_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(258, 24);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(27, 29);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "TỔNG TIỀN NHẬP:";
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
            // colCostPrice
            // 
            this.colCostPrice.DataPropertyName = "CostPrice";
            this.colCostPrice.HeaderText = "Đơn giá";
            this.colCostPrice.MinimumWidth = 8;
            this.colCostPrice.Name = "colCostPrice";
            this.colCostPrice.ReadOnly = true;
            this.colCostPrice.Width = 150;
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
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 1144);
            this.Controls.Add(this.grpPhieuNhap);
            this.Controls.Add(this.pnlThanhToan);
            this.Controls.Add(this.grpSerials);
            this.Controls.Add(this.grpThemHang);
            this.Controls.Add(this.grpNhaCungCap);
            this.Name = "frmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Phiếu Nhập Kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.grpNhaCungCap.ResumeLayout(false);
            this.grpNhaCungCap.PerformLayout();
            this.grpThemHang.ResumeLayout(false);
            this.grpThemHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpSerials.ResumeLayout(false);
            this.grpSerials.PerformLayout();
            this.grpPhieuNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseCart)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNhaCungCap;
        private System.Windows.Forms.GroupBox grpThemHang;
        private System.Windows.Forms.GroupBox grpSerials;
        private System.Windows.Forms.GroupBox grpPhieuNhap;
        private System.Windows.Forms.Panel pnlThanhToan;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCostPrice;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblSerialCount;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSavePurchase;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSerialList;
        private System.Windows.Forms.DataGridView dgvPurchaseCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
    }
}