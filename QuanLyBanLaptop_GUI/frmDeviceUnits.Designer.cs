namespace QuanLyBanLaptop_GUI
{
    partial class frmDeviceUnits
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtSerialFilter = new System.Windows.Forms.TextBox();
            this.cboStatusFilter = new System.Windows.Forms.ComboBox();
            this.cboProductFilter = new System.Windows.Forms.ComboBox();
            this.dgvDeviceUnits = new System.Windows.Forms.DataGridView();
            this.colUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoldDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlChucNang = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceUnits)).BeginInit();
            this.pnlChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.txtSerialFilter);
            this.groupBox1.Controls.Add(this.cboStatusFilter);
            this.groupBox1.Controls.Add(this.cboProductFilter);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bộ lọc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serial #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trạng thái:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sản phẩm";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(124, 115);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(21, 115);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(87, 35);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtSerialFilter
            // 
            this.txtSerialFilter.Location = new System.Drawing.Point(496, 72);
            this.txtSerialFilter.Name = "txtSerialFilter";
            this.txtSerialFilter.Size = new System.Drawing.Size(300, 26);
            this.txtSerialFilter.TabIndex = 2;
            // 
            // cboStatusFilter
            // 
            this.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusFilter.FormattingEnabled = true;
            this.cboStatusFilter.Location = new System.Drawing.Point(102, 69);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new System.Drawing.Size(300, 28);
            this.cboStatusFilter.TabIndex = 1;
            // 
            // cboProductFilter
            // 
            this.cboProductFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductFilter.FormattingEnabled = true;
            this.cboProductFilter.Location = new System.Drawing.Point(102, 25);
            this.cboProductFilter.Name = "cboProductFilter";
            this.cboProductFilter.Size = new System.Drawing.Size(300, 28);
            this.cboProductFilter.TabIndex = 0;
            // 
            // dgvDeviceUnits
            // 
            this.dgvDeviceUnits.AllowUserToAddRows = false;
            this.dgvDeviceUnits.AllowUserToDeleteRows = false;
            this.dgvDeviceUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUnitID,
            this.colStatus,
            this.colProductName,
            this.colSerialNumber,
            this.colPurchaseDate,
            this.colSoldDate,
            this.colCustomerName});
            this.dgvDeviceUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceUnits.Location = new System.Drawing.Point(0, 156);
            this.dgvDeviceUnits.MultiSelect = false;
            this.dgvDeviceUnits.Name = "dgvDeviceUnits";
            this.dgvDeviceUnits.ReadOnly = true;
            this.dgvDeviceUnits.RowHeadersWidth = 62;
            this.dgvDeviceUnits.RowTemplate.Height = 28;
            this.dgvDeviceUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceUnits.Size = new System.Drawing.Size(978, 426);
            this.dgvDeviceUnits.TabIndex = 1;
            // 
            // colUnitID
            // 
            this.colUnitID.DataPropertyName = "UnitID";
            this.colUnitID.HeaderText = "UnitID";
            this.colUnitID.MinimumWidth = 8;
            this.colUnitID.Name = "colUnitID";
            this.colUnitID.ReadOnly = true;
            this.colUnitID.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 150;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Tên Sản Phẩm";
            this.colProductName.MinimumWidth = 8;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 150;
            // 
            // colSerialNumber
            // 
            this.colSerialNumber.DataPropertyName = "SerialNumber";
            this.colSerialNumber.HeaderText = "SerialNumber";
            this.colSerialNumber.MinimumWidth = 8;
            this.colSerialNumber.Name = "colSerialNumber";
            this.colSerialNumber.ReadOnly = true;
            this.colSerialNumber.Width = 150;
            // 
            // colPurchaseDate
            // 
            this.colPurchaseDate.DataPropertyName = "PurchaseDate";
            this.colPurchaseDate.HeaderText = "Ngày nhập";
            this.colPurchaseDate.MinimumWidth = 8;
            this.colPurchaseDate.Name = "colPurchaseDate";
            this.colPurchaseDate.ReadOnly = true;
            this.colPurchaseDate.Width = 150;
            // 
            // colSoldDate
            // 
            this.colSoldDate.DataPropertyName = "SoldDate";
            this.colSoldDate.HeaderText = "Ngày bán";
            this.colSoldDate.MinimumWidth = 8;
            this.colSoldDate.Name = "colSoldDate";
            this.colSoldDate.ReadOnly = true;
            this.colSoldDate.Width = 150;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CustomerName";
            this.colCustomerName.HeaderText = "Khách hàng";
            this.colCustomerName.MinimumWidth = 8;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 150;
            // 
            // pnlChucNang
            // 
            this.pnlChucNang.Controls.Add(this.btnClose);
            this.pnlChucNang.Controls.Add(this.btnViewHistory);
            this.pnlChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChucNang.Location = new System.Drawing.Point(0, 582);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new System.Drawing.Size(978, 62);
            this.pnlChucNang.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(869, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(17, 8);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(139, 42);
            this.btnViewHistory.TabIndex = 1;
            this.btnViewHistory.Text = "Xem Lịch sử";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(43, 442);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(204, 40);
            this.btnUpdateStatus.TabIndex = 0;
            this.btnUpdateStatus.Text = "Cập nhật Trạng thái...";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // frmDeviceUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.dgvDeviceUnits);
            this.Controls.Add(this.pnlChucNang);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDeviceUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Kho / Serial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDeviceUnits_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceUnits)).EndInit();
            this.pnlChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtSerialFilter;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.ComboBox cboProductFilter;
        private System.Windows.Forms.DataGridView dgvDeviceUnits;
        private System.Windows.Forms.Panel pnlChucNang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoldDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.Button btnUpdateStatus;
    }
}