namespace Sys
{
    partial class frmItemKind
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
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbKind = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sbOK
            // 
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(159, 12);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(64, 23);
            this.sbOK.TabIndex = 1;
            this.sbOK.Text = "ȷ��(&O)";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Location = new System.Drawing.Point(159, 41);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(64, 23);
            this.sbCancel.TabIndex = 2;
            this.sbCancel.Text = "ȡ��(&C)";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // lbKind
            // 
            this.lbKind.FormattingEnabled = true;
            this.lbKind.ItemHeight = 12;
            this.lbKind.Items.AddRange(new object[] {
            "ԭ����",
            "����Ʒ",
            "���Ʒ",
            "����"});
            this.lbKind.Location = new System.Drawing.Point(12, 12);
            this.lbKind.Name = "lbKind";
            this.lbKind.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbKind.Size = new System.Drawing.Size(120, 112);
            this.lbKind.TabIndex = 3;
            // 
            // frmItemKind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(244, 139);
            this.Controls.Add(this.lbKind);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemKind";
            this.Text = "ѡ����������";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        public System.Windows.Forms.ListBox lbKind;
    }
}
