namespace Wage
{
    partial class frmWageCheckOut
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private new System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtMonth = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sbChange = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtMonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtMonth
            // 
            this.dtMonth.EditValue = null;
            this.dtMonth.Location = new System.Drawing.Point(107, 77);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.dtMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtMonth.Properties.Mask.EditMask = "yyyy-MM";
            this.dtMonth.Size = new System.Drawing.Size(71, 21);
            this.dtMonth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "    ������ת���ʾ��ǽ�����״�������������ת\r\n��Ϊ���¹��ʡ�";
            // 
            // sbChange
            // 
            this.sbChange.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbChange.Appearance.Options.UseFont = true;
            this.sbChange.Location = new System.Drawing.Point(79, 159);
            this.sbChange.Name = "sbChange";
            this.sbChange.Size = new System.Drawing.Size(75, 23);
            this.sbChange.TabIndex = 1;
            this.sbChange.Text = "��ת(&O)";
            this.sbChange.Click += new System.EventHandler(this.sbChange_Click);
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Location = new System.Drawing.Point(198, 159);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(75, 23);
            this.sbClose.TabIndex = 2;
            this.sbClose.Text = "�ر�(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // frmWageCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(335, 203);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbChange);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWageCheckOut";
            this.Text = "������ת����";
            this.Load += new System.EventHandler(this.frmWageCheckOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtMonth;
        private DevExpress.XtraEditors.SimpleButton sbChange;
        private DevExpress.XtraEditors.SimpleButton sbClose;
    }
}
