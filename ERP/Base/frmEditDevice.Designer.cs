namespace Base
{
    partial class frmEditDevice
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
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.lupControl1 = new myControl.lupControl();
            this.editControl3 = new myControl.EditControl();
            this.editControl9 = new myControl.EditControl();
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.dateControl1 = new myControl.DateControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.editControl9);
            this.gbox.Controls.Add(this.editControl3);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Margin = new System.Windows.Forms.Padding(5);
            this.gbox.Padding = new System.Windows.Forms.Padding(5);
            this.gbox.Size = new System.Drawing.Size(688, 429);
            // 
            // ckCopy
            // 
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(497, 470);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(5);
            this.BtnOK.Text = "����(&S)";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(605, 470);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "�豸����:";
            this.editControl1.Location = new System.Drawing.Point(24, 26);
            this.editControl1.Margin = new System.Windows.Forms.Padding(5);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(271, 34);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "�豸����:";
            this.editControl2.Location = new System.Drawing.Point(332, 28);
            this.editControl2.Margin = new System.Windows.Forms.Padding(5);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(324, 34);
            this.editControl2.TabIndex = 1;
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_Type";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "��    ��:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(24, 68);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 200;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(271, 28);
            this.lupControl1.TabIndex = 2;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_UseInfo";
            this.editControl3.DataSource = null;
            this.editControl3.EditLabel = "��;:";
            this.editControl3.Location = new System.Drawing.Point(332, 68);
            this.editControl3.Margin = new System.Windows.Forms.Padding(5);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(293, 34);
            this.editControl3.TabIndex = 3;
            // 
            // editControl9
            // 
            this.editControl9.BackColor = System.Drawing.Color.Transparent;
            this.editControl9.DataField = "F_Remark";
            this.editControl9.DataSource = null;
            this.editControl9.EditLabel = "��ע:";
            this.editControl9.Location = new System.Drawing.Point(24, 141);
            this.editControl9.Margin = new System.Windows.Forms.Padding(5);
            this.editControl9.Name = "editControl9";
            this.editControl9.Request = false;
            this.editControl9.Size = new System.Drawing.Size(627, 34);
            this.editControl9.TabIndex = 12;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(24, 468);
            this.ckOption.Margin = new System.Windows.Forms.Padding(4);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "���������";
            this.ckOption.Size = new System.Drawing.Size(135, 22);
            this.ckOption.TabIndex = 3;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_UseDate";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "d";
            this.dateControl1.EditLabel = "ʹ������:";
            this.dateControl1.EditMask = "d";
            this.dateControl1.Location = new System.Drawing.Point(24, 105);
            this.dateControl1.Margin = new System.Windows.Forms.Padding(5);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(235, 26);
            this.dateControl1.TabIndex = 13;
            // 
            // frmEditDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(719, 514);
            this.Controls.Add(this.ckOption);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmEditDevice";
            this.Text = "�豸����--�༭";
            this.Shown += new System.EventHandler(this.frmEditSupplier_Shown);
            this.Controls.SetChildIndex(this.ckCopy, 0);
            this.Controls.SetChildIndex(this.BtnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbox, 0);
            this.Controls.SetChildIndex(this.ckOption, 0);
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public myControl.EditControl editControl1;
        public myControl.EditControl editControl2;
        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl3;
        public myControl.EditControl editControl9;
        public DevExpress.XtraEditors.CheckEdit ckOption;
        private myControl.DateControl dateControl1;


    }
}
