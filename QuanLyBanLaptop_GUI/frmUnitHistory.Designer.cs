namespace QuanLyBanLaptop_GUI
{
    partial class frmUnitHistory
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
            this.grpThongTinChung = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpLichSuBan = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblSoldDate = new System.Windows.Forms.Label();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpLichSuBaoHanh = new System.Windows.Forms.GroupBox();
            this.dgvWarrantyClaims = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.colClaimID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpThongTinChung.SuspendLayout();
            this.grpLichSuBan.SuspendLayout();
            this.grpLichSuBaoHanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarrantyClaims)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTinChung
            // 
            this.grpThongTinChung.Controls.Add(this.lblStatus);
            this.grpThongTinChung.Controls.Add(this.lblSerialNumber);
            this.grpThongTinChung.Controls.Add(this.lblProductName);
            this.grpThongTinChung.Controls.Add(this.label3);
            this.grpThongTinChung.Controls.Add(this.label2);
            this.grpThongTinChung.Controls.Add(this.label1);
            this.grpThongTinChung.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinChung.Location = new System.Drawing.Point(0, 0);
            this.grpThongTinChung.Name = "grpThongTinChung";
            this.grpThongTinChung.Size = new System.Drawing.Size(978, 150);
            this.grpThongTinChung.TabIndex = 0;
            this.grpThongTinChung.TabStop = false;
            this.grpThongTinChung.Text = "Thông tin chung";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(168, 99);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "lblStatus";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(168, 66);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(120, 20);
            this.lblSerialNumber.TabIndex = 4;
            this.lblSerialNumber.Text = "lblSerialNumber";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(168, 35);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(121, 20);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = "lblProductName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trạng thái:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial Number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Sản Phẩm:";
            // 
            // grpLichSuBan
            // 
            this.grpLichSuBan.Controls.Add(this.lblCustomerName);
            this.grpLichSuBan.Controls.Add(this.lblSoldDate);
            this.grpLichSuBan.Controls.Add(this.lblPurchaseDate);
            this.grpLichSuBan.Controls.Add(this.label6);
            this.grpLichSuBan.Controls.Add(this.label5);
            this.grpLichSuBan.Controls.Add(this.label4);
            this.grpLichSuBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLichSuBan.Location = new System.Drawing.Point(0, 150);
            this.grpLichSuBan.Name = "grpLichSuBan";
            this.grpLichSuBan.Size = new System.Drawing.Size(978, 144);
            this.grpLichSuBan.TabIndex = 1;
            this.grpLichSuBan.TabStop = false;
            this.grpLichSuBan.Text = "Lịch sử Nhập / Bán";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(168, 104);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(135, 20);
            this.lblCustomerName.TabIndex = 5;
            this.lblCustomerName.Text = "lblCustomerName";
            // 
            // lblSoldDate
            // 
            this.lblSoldDate.AutoSize = true;
            this.lblSoldDate.Location = new System.Drawing.Point(168, 70);
            this.lblSoldDate.Name = "lblSoldDate";
            this.lblSoldDate.Size = new System.Drawing.Size(91, 20);
            this.lblSoldDate.TabIndex = 4;
            this.lblSoldDate.Text = "lblSoldDate";
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(168, 39);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(126, 20);
            this.lblPurchaseDate.TabIndex = 3;
            this.lblPurchaseDate.Text = "lblPurchaseDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Khách hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ngày bán:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày nhập kho:";
            // 
            // grpLichSuBaoHanh
            // 
            this.grpLichSuBaoHanh.Controls.Add(this.dgvWarrantyClaims);
            this.grpLichSuBaoHanh.Controls.Add(this.panel1);
            this.grpLichSuBaoHanh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpLichSuBaoHanh.Location = new System.Drawing.Point(0, 294);
            this.grpLichSuBaoHanh.Name = "grpLichSuBaoHanh";
            this.grpLichSuBaoHanh.Size = new System.Drawing.Size(978, 350);
            this.grpLichSuBaoHanh.TabIndex = 2;
            this.grpLichSuBaoHanh.TabStop = false;
            this.grpLichSuBaoHanh.Text = "Lịch sử Bảo hành";
            // 
            // dgvWarrantyClaims
            // 
            this.dgvWarrantyClaims.AllowUserToAddRows = false;
            this.dgvWarrantyClaims.AllowUserToDeleteRows = false;
            this.dgvWarrantyClaims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarrantyClaims.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClaimID,
            this.colReportDate,
            this.colIssueDescription,
            this.colStatus,
            this.colResolution});
            this.dgvWarrantyClaims.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarrantyClaims.Location = new System.Drawing.Point(3, 22);
            this.dgvWarrantyClaims.Name = "dgvWarrantyClaims";
            this.dgvWarrantyClaims.ReadOnly = true;
            this.dgvWarrantyClaims.RowHeadersWidth = 62;
            this.dgvWarrantyClaims.RowTemplate.Height = 28;
            this.dgvWarrantyClaims.Size = new System.Drawing.Size(972, 275);
            this.dgvWarrantyClaims.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(864, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // colClaimID
            // 
            this.colClaimID.DataPropertyName = "ClaimID";
            this.colClaimID.HeaderText = "Mã phiếu";
            this.colClaimID.MinimumWidth = 8;
            this.colClaimID.Name = "colClaimID";
            this.colClaimID.ReadOnly = true;
            this.colClaimID.Width = 150;
            // 
            // colReportDate
            // 
            this.colReportDate.DataPropertyName = "ReportDate";
            this.colReportDate.HeaderText = "Ngày báo cáo";
            this.colReportDate.MinimumWidth = 8;
            this.colReportDate.Name = "colReportDate";
            this.colReportDate.ReadOnly = true;
            this.colReportDate.Width = 150;
            // 
            // colIssueDescription
            // 
            this.colIssueDescription.DataPropertyName = "IssueDescription";
            this.colIssueDescription.HeaderText = "Mô tả lỗi";
            this.colIssueDescription.MinimumWidth = 8;
            this.colIssueDescription.Name = "colIssueDescription";
            this.colIssueDescription.ReadOnly = true;
            this.colIssueDescription.Width = 150;
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
            // colResolution
            // 
            this.colResolution.DataPropertyName = "Resolution";
            this.colResolution.HeaderText = "Giải pháp";
            this.colResolution.MinimumWidth = 8;
            this.colResolution.Name = "colResolution";
            this.colResolution.ReadOnly = true;
            this.colResolution.Width = 150;
            // 
            // frmUnitHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.grpLichSuBan);
            this.Controls.Add(this.grpLichSuBaoHanh);
            this.Controls.Add(this.grpThongTinChung);
            this.Name = "frmUnitHistory";
            this.Text = "Lịch sử thiết bị";
            this.Load += new System.EventHandler(this.frmUnitHistory_Load);
            this.grpThongTinChung.ResumeLayout(false);
            this.grpThongTinChung.PerformLayout();
            this.grpLichSuBan.ResumeLayout(false);
            this.grpLichSuBan.PerformLayout();
            this.grpLichSuBaoHanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarrantyClaims)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTinChung;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox grpLichSuBan;
        private System.Windows.Forms.GroupBox grpLichSuBaoHanh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvWarrantyClaims;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblSoldDate;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClaimID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResolution;
    }
}