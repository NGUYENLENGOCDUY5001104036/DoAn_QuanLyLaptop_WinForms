namespace QuanLyBanLaptop_GUI
{
    partial class frmWarrantyCreate
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
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtIssueDescription = new System.Windows.Forms.TextBox();
            this.lblWarrantyStatus = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.llbViewProof = new System.Windows.Forms.LinkLabel();
            this.grpTimKiem.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.llbViewProof);
            this.grpTimKiem.Controls.Add(this.btnSearch);
            this.grpTimKiem.Controls.Add(this.txtSearchSerial);
            this.grpTimKiem.Controls.Add(this.label1);
            this.grpTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTimKiem.Location = new System.Drawing.Point(0, 0);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(808, 87);
            this.grpTimKiem.TabIndex = 0;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "1. Tìm kiếm Thiết bị";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(434, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 37);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchSerial
            // 
            this.txtSearchSerial.Location = new System.Drawing.Point(175, 32);
            this.txtSearchSerial.Name = "txtSearchSerial";
            this.txtSearchSerial.Size = new System.Drawing.Size(223, 26);
            this.txtSearchSerial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Serial Number:";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.txtIssueDescription);
            this.grpThongTin.Controls.Add(this.lblWarrantyStatus);
            this.grpThongTin.Controls.Add(this.lblCustomerName);
            this.grpThongTin.Controls.Add(this.lblProductName);
            this.grpThongTin.Controls.Add(this.label5);
            this.grpThongTin.Controls.Add(this.label4);
            this.grpThongTin.Controls.Add(this.label3);
            this.grpThongTin.Controls.Add(this.label2);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Enabled = false;
            this.grpThongTin.Location = new System.Drawing.Point(0, 87);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(808, 283);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "2. Thông tin Phiếu";
            // 
            // txtIssueDescription
            // 
            this.txtIssueDescription.Location = new System.Drawing.Point(175, 172);
            this.txtIssueDescription.Multiline = true;
            this.txtIssueDescription.Name = "txtIssueDescription";
            this.txtIssueDescription.Size = new System.Drawing.Size(223, 95);
            this.txtIssueDescription.TabIndex = 7;
            // 
            // lblWarrantyStatus
            // 
            this.lblWarrantyStatus.AutoSize = true;
            this.lblWarrantyStatus.Location = new System.Drawing.Point(175, 120);
            this.lblWarrantyStatus.Name = "lblWarrantyStatus";
            this.lblWarrantyStatus.Size = new System.Drawing.Size(21, 20);
            this.lblWarrantyStatus.TabIndex = 6;
            this.lblWarrantyStatus.Text = "...";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(175, 76);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(21, 20);
            this.lblCustomerName.TabIndex = 5;
            this.lblCustomerName.Text = "...";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(175, 32);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(21, 20);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mô tả lỗi (*):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hạn Bảo hành:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sản phẩm:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 74);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(140, 21);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 41);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(16, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 41);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // llbViewProof
            // 
            this.llbViewProof.AutoSize = true;
            this.llbViewProof.Location = new System.Drawing.Point(570, 37);
            this.llbViewProof.Name = "llbViewProof";
            this.llbViewProof.Size = new System.Drawing.Size(212, 20);
            this.llbViewProof.TabIndex = 3;
            this.llbViewProof.TabStop = true;
            this.llbViewProof.Text = "Xem Hóa đơn gốc / Xác thực";
            this.llbViewProof.Visible = false;
            this.llbViewProof.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbViewProof_LinkClicked);
            // 
            // frmWarrantyCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 444);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpTimKiem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmWarrantyCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo Phiếu Bảo hành";
            this.Load += new System.EventHandler(this.frmWarrantyCreate_Load);
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchSerial;
        private System.Windows.Forms.TextBox txtIssueDescription;
        private System.Windows.Forms.Label lblWarrantyStatus;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel llbViewProof;
    }
}