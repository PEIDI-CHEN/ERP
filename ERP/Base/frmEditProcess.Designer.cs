namespace Base
{
    partial class frmEditProcess
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
            this.ckOption = new DevExpress.XtraEditors.CheckEdit();
            this.spinControl1 = new myControl.SpinControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.spinControl1);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Margin = new System.Windows.Forms.Padding(5);
            this.gbox.Padding = new System.Windows.Forms.Padding(5);
            this.gbox.Size = new System.Drawing.Size(385, 208);
            // 
            // ckCopy
            // 
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(223, 245);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(5);
            this.BtnOK.Size = new System.Drawing.Size(88, 29);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(319, 245);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(84, 29);
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
            this.editControl2.Size = new System.Drawing.Size(301, 34);
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
            this.lupControl1.Location = new System.Drawing.Point(9, 155);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 200;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(272, 28);
            this.lupControl1.TabIndex = 3;
            // 
            // ckOption
            // 
            this.ckOption.EditValue = true;
            this.ckOption.Location = new System.Drawing.Point(24, 250);
            this.ckOption.Margin = new System.Windows.Forms.Padding(4);
            this.ckOption.Name = "ckOption";
            this.ckOption.Properties.Caption = "���������";
            this.ckOption.Size = new System.Drawing.Size(135, 22);
            this.ckOption.TabIndex = 5;
            this.ckOption.CheckedChanged += new System.EventHandler(this.ckOption_CheckedChanged);
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Price";
            this.spinControl1.DataSource = null;
            this.spinControl1.EditLabel = "����:";
            this.spinControl1.Location = new System.Drawing.Point(10, 112);
            this.spinControl1.Margin = new System.Windows.Forms.Padding(5);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(271, 26);
            this.spinControl1.TabIndex = 2;
            // 
            // frmEditProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(419, 289);
            this.Controls.Add(this.ckOption);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmEditProcess";
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
        public DevExpress.XtraEditors.CheckEdit ckOption;
        private myControl.SpinControl spinControl1;


    }
}
