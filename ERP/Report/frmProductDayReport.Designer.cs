namespace Report
{
    partial class frmProductDayReport
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
            this.deMonth = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sbRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDate
            // 
            this.ucDate.Location = new System.Drawing.Point(391, 34);
            this.ucDate.Visible = false;
            // 
            // rgOption
            // 
            this.rgOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgOption.Properties.Appearance.Options.UseBackColor = true;
            this.rgOption.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(101, 24);
            this.lbTitle.Text = "frmBase";
            // 
            // deMonth
            // 
            this.deMonth.EditValue = null;
            this.deMonth.Location = new System.Drawing.Point(344, 38);
            this.deMonth.Name = "deMonth";
            this.deMonth.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.deMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deMonth.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.deMonth.Size = new System.Drawing.Size(81, 21);
            this.deMonth.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "����:";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbRefresh.Appearance.Options.UseFont = true;
            this.sbRefresh.Location = new System.Drawing.Point(431, 36);
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(61, 23);
            this.sbRefresh.TabIndex = 19;
            this.sbRefresh.Text = "ˢ��(&R)";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // frmProductDayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(748, 501);
            this.Controls.Add(this.sbRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deMonth);
            this.Name = "frmProductDayReport";
            this.Text = "�����ձ���";
            this.Load += new System.EventHandler(this.frmStorageSum_Load);
            this.Controls.SetChildIndex(this.deMonth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.sbRefresh, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deMonth;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton sbRefresh;

    }
}
