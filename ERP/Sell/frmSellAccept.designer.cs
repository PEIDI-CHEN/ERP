namespace Sell
{
    partial class frmSellAccept
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem4 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.lupControl1 = new myControl.lupControl();
            this.editControl5 = new myControl.EditControl();
            this.cbControl1 = new myControl.cbControl();
            this.spinControl1 = new myControl.SpinControl();
            this.cbControl2 = new myControl.cbControl();
            this.sbAuto = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Size = new System.Drawing.Size(94, 21);
            this.lbTitle.Text = "frmBase";
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(559, 34);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(559, 8);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.sbAuto);
            this.panelControl1.Controls.Add(this.cbControl2);
            this.panelControl1.Controls.Add(this.spinControl1);
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(798, 126);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.spinControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbAuto, 0);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_ClientID";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "�ͻ�:";
            this.lupControl1.Location = new System.Drawing.Point(25, 61);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(270, 22);
            this.lupControl1.TabIndex = 5;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.EditLabel = "��ע:";
            this.editControl5.Location = new System.Drawing.Point(25, 91);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(572, 27);
            this.editControl5.TabIndex = 7;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "Ӧ�տ�";
            comboBoxItem2.Value = "Ԥ�տ�";
            comboBoxItem3.Value = "Ԥ�ճ�Ӧ��";
            comboBoxItem4.Value = "Ӧ��תԤ��";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3,
        comboBoxItem4};
            this.cbControl1.DataField = "F_Kind";
            this.cbControl1.EditLabel = "�տ�����:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(12, 34);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.Size = new System.Drawing.Size(175, 21);
            this.cbControl1.TabIndex = 3;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Money";
            this.spinControl1.EditLabel = "�տ���:";
            this.spinControl1.Location = new System.Drawing.Point(341, 61);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(162, 21);
            this.spinControl1.TabIndex = 6;
            // 
            // cbControl2
            // 
            this.cbControl2.BackColor = System.Drawing.Color.Transparent;
            this.cbControl2.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[0];
            this.cbControl2.DataField = "F_AcceptType";
            this.cbControl2.EditLabel = "�տʽ:";
            this.cbControl2.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl2.Location = new System.Drawing.Point(341, 34);
            this.cbControl2.Name = "cbControl2";
            this.cbControl2.Request = false;
            this.cbControl2.Size = new System.Drawing.Size(162, 21);
            this.cbControl2.TabIndex = 4;
            // 
            // sbAuto
            // 
            this.sbAuto.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAuto.Appearance.Options.UseFont = true;
            this.sbAuto.Location = new System.Drawing.Point(716, 91);
            this.sbAuto.Name = "sbAuto";
            this.sbAuto.Size = new System.Drawing.Size(68, 23);
            this.sbAuto.TabIndex = 10;
            this.sbAuto.Text = "�Զ�����";
            this.sbAuto.Click += new System.EventHandler(this.sbAuto_Click);
            // 
            // frmSellAccept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(798, 520);
            this.Name = "frmSellAccept";
            this.Text = "�����տ";
            this.Load += new System.EventHandler(this.frmSellAccept_Load);
            this.Shown += new System.EventHandler(this.frmSellAccept_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbAuto;
        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl5;
        public myControl.cbControl cbControl1;
        public myControl.SpinControl spinControl1;
        public myControl.cbControl cbControl2;
    }
}
