namespace Base
{
    partial class frmEditWorkGroup
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.lupControl1 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Margin = new System.Windows.Forms.Padding(5);
            this.gbox.Padding = new System.Windows.Forms.Padding(5);
            this.gbox.Size = new System.Drawing.Size(321, 191);
            // 
            // ckCopy
            // 
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(160, 231);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(5);
            this.BtnOK.Size = new System.Drawing.Size(85, 29);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(253, 231);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(85, 29);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_ID";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "�������:";
            this.editControl1.Location = new System.Drawing.Point(9, 26);
            this.editControl1.Margin = new System.Windows.Forms.Padding(5);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = true;
            this.editControl1.Size = new System.Drawing.Size(272, 34);
            this.editControl1.TabIndex = 0;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "��������:";
            this.editControl2.Location = new System.Drawing.Point(9, 68);
            this.editControl2.Margin = new System.Windows.Forms.Padding(5);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = true;
            this.editControl2.Size = new System.Drawing.Size(272, 30);
            this.editControl2.TabIndex = 1;
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_DeptID";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "����:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(9, 107);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 200;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(272, 28);
            this.lupControl1.TabIndex = 2;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "�������";
            comboBoxItem2.Value = "��������";
            comboBoxItem3.Value = "��Ʒ����";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3};
            this.cbControl1.DataField = "F_WageType";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "���ʼ��㷽ʽ:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(9, 144);
            this.cbControl1.Margin = new System.Windows.Forms.Padding(5);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = true;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(272, 26);
            this.cbControl1.TabIndex = 3;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(16, 231);
            this.ckOption.Margin = new System.Windows.Forms.Padding(4);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "���������";
            this.ckOption.Size = new System.Drawing.Size(119, 22);
            this.ckOption.TabIndex = 5;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
            // 
            // frmEditWorkGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(363, 275);
            this.Controls.Add(this.ckOption);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmEditWorkGroup";
            this.Text = "��������--�༭";
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
        public myControl.cbControl cbControl1;
        public DevExpress.XtraEditors.CheckEdit ckOption;


    }
}
