namespace QuanLyBanLaptop_GUI
{
    partial class frmWarrantyService
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
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtSearchSerial = new System.Windows.Forms.TextBox();
            this.cboStatusFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClaims = new System.Windows.Forms.DataGridView();
            this.pnlChucNang = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateClaim = new System.Windows.Forms.Button();
            this.btnCreateClaim = new System.Windows.Forms.Button();
            this.colClaimID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaims)).BeginInit();
            this.pnlChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.btnRefresh);
            this.grpBoLoc.Controls.Add(this.btnFilter);
            this.grpBoLoc.Controls.Add(this.txtSearchSerial);
            this.grpBoLoc.Controls.Add(this.cboStatusFilter);
            this.grpBoLoc.Controls.Add(this.label2);
            this.grpBoLoc.Controls.Add(this.label1);
            this.grpBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLoc.Location = new System.Drawing.Point(0, 0);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(978, 200);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ lọc";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(253, 136);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 33);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(135, 136);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(98, 33);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // txtSearchSerial
            // 
            this.txtSearchSerial.Location = new System.Drawing.Point(135, 85);
            this.txtSearchSerial.Name = "txtSearchSerial";
            this.txtSearchSerial.Size = new System.Drawing.Size(260, 26);
            this.txtSearchSerial.TabIndex = 3;
            // 
            // cboStatusFilter
            // 
            this.cboStatusFilter.FormattingEnabled = true;
            this.cboStatusFilter.Location = new System.Drawing.Point(135, 39);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new System.Drawing.Size(260, 28);
            this.cboStatusFilter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial #:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trạng thái:";
            // 
            // dgvClaims
            // 
            this.dgvClaims.AllowUserToAddRows = false;
            this.dgvClaims.AllowUserToDeleteRows = false;
            this.dgvClaims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClaims.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClaimID,
            this.colCustomerName,
            this.colProductName,
            this.colSerialNumber,
            this.colReportDate,
            this.colStatus,
            this.colIssueDescription});
            this.dgvClaims.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClaims.Location = new System.Drawing.Point(0, 200);
            this.dgvClaims.MultiSelect = false;
            this.dgvClaims.Name = "dgvClaims";
            this.dgvClaims.ReadOnly = true;
            this.dgvClaims.RowHeadersWidth = 62;
            this.dgvClaims.RowTemplate.Height = 28;
            this.dgvClaims.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClaims.Size = new System.Drawing.Size(978, 444);
            this.dgvClaims.TabIndex = 1;
            // 
            // pnlChucNang
            // 
            this.pnlChucNang.Controls.Add(this.btnClose);
            this.pnlChucNang.Controls.Add(this.btnUpdateClaim);
            this.pnlChucNang.Controls.Add(this.btnCreateClaim);
            this.pnlChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChucNang.Location = new System.Drawing.Point(0, 576);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new System.Drawing.Size(978, 68);
            this.pnlChucNang.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(881, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 39);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnUpdateClaim
            // 
            this.btnUpdateClaim.Location = new System.Drawing.Point(188, 15);
            this.btnUpdateClaim.Name = "btnUpdateClaim";
            this.btnUpdateClaim.Size = new System.Drawing.Size(151, 41);
            this.btnUpdateClaim.TabIndex = 1;
            this.btnUpdateClaim.Text = "Cập nhật phiếu";
            this.btnUpdateClaim.UseVisualStyleBackColor = true;
            this.btnUpdateClaim.Click += new System.EventHandler(this.btnUpdateClaim_Click);
            // 
            // btnCreateClaim
            // 
            this.btnCreateClaim.Location = new System.Drawing.Point(50, 15);
            this.btnCreateClaim.Name = "btnCreateClaim";
            this.btnCreateClaim.Size = new System.Drawing.Size(125, 41);
            this.btnCreateClaim.TabIndex = 0;
            this.btnCreateClaim.Text = "In phiếu";
            this.btnCreateClaim.UseVisualStyleBackColor = true;
            this.btnCreateClaim.Click += new System.EventHandler(this.btnCreateClaim_Click);
            // 
            // colClaimID
            // 
            this.colClaimID.DataPropertyName = "ClaimID";
            this.colClaimID.HeaderText = "ClaimID";
            this.colClaimID.MinimumWidth = 8;
            this.colClaimID.Name = "colClaimID";
            this.colClaimID.ReadOnly = true;
            this.colClaimID.Width = 150;
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
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Sản Phẩm";
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
            // colReportDate
            // 
            this.colReportDate.DataPropertyName = "ReportDate";
            this.colReportDate.HeaderText = "Ngày nhận";
            this.colReportDate.MinimumWidth = 8;
            this.colReportDate.Name = "colReportDate";
            this.colReportDate.ReadOnly = true;
            this.colReportDate.Width = 150;
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
            // colIssueDescription
            // 
            this.colIssueDescription.DataPropertyName = "IssueDescription";
            this.colIssueDescription.HeaderText = "Mô tả lỗi";
            this.colIssueDescription.MinimumWidth = 8;
            this.colIssueDescription.Name = "colIssueDescription";
            this.colIssueDescription.ReadOnly = true;
            this.colIssueDescription.Width = 150;
            // 
            // frmWarrantyService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.pnlChucNang);
            this.Controls.Add(this.dgvClaims);
            this.Controls.Add(this.grpBoLoc);
            this.Name = "frmWarrantyService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Bảo hành";
            this.Load += new System.EventHandler(this.frmWarrantyService_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaims)).EndInit();
            this.pnlChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.DataGridView dgvClaims;
        private System.Windows.Forms.Panel pnlChucNang;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtSearchSerial;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdateClaim;
        private System.Windows.Forms.Button btnCreateClaim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClaimID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDescription;
    }
}