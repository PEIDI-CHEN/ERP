namespace Sell
{
    partial class frmSellPre
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
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.editControl6 = new myControl.EditControl();
            this.lupControl5 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
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
            this.dateControl1.Location = new System.Drawing.Point(543, 34);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(545, 5);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.lupControl5);
            this.panelControl1.Controls.Add(this.editControl6);
            this.panelControl1.Controls.Add(this.lupControl3);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 26);
            this.panelControl1.Size = new System.Drawing.Size(799, 151);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl3, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl6, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_ClientID";
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.EditLabel = "�ͻ�:";
            this.lupControl1.Location = new System.Drawing.Point(25, 39);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 150;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(270, 22);
            this.lupControl1.TabIndex = 3;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.EditLabel = "��ע:";
            this.editControl5.Location = new System.Drawing.Point(25, 124);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(658, 27);
            this.editControl5.TabIndex = 7;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_DeptID";
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.EditLabel = "����:";
            this.lupControl2.Location = new System.Drawing.Point(25, 67);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 150;
            this.lupControl2.Request = false;
            this.lupControl2.Size = new System.Drawing.Size(165, 22);
            this.lupControl2.TabIndex = 4;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_Opertor";
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.EditLabel = "ҵ��Ա:";
            this.lupControl3.Location = new System.Drawing.Point(231, 67);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.PopWidth = 150;
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(165, 22);
            this.lupControl3.TabIndex = 5;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_ContractID";
            this.editControl6.EditLabel = "��ͬ��:";
            this.editControl6.Location = new System.Drawing.Point(468, 67);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(179, 22);
            this.editControl6.TabIndex = 6;
            // 
            // lupControl5
            // 
            this.lupControl5.BackColor = System.Drawing.Color.Transparent;
            this.lupControl5.DataField = "F_CarryCompany";
            this.lupControl5.DisplayCaption = "";
            this.lupControl5.EditLabel = "���˹�˾:";
            this.lupControl5.Location = new System.Drawing.Point(0, 93);
            this.lupControl5.LookUpDataSource = null;
            this.lupControl5.LookUpDisplayField = null;
            this.lupControl5.LookUpKeyField = null;
            this.lupControl5.Name = "lupControl5";
            this.lupControl5.PopWidth = 150;
            this.lupControl5.Request = false;
            this.lupControl5.Size = new System.Drawing.Size(225, 22);
            this.lupControl5.TabIndex = 12;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "���۷�������";
            comboBoxItem2.Value = "���۳���";
            comboBoxItem3.Value = "ҵ�����";
            comboBoxItem4.Value = "�����̳���";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3,
        comboBoxItem4};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.EditLabel = "��������:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(245, 97);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = true;
            this.cbControl1.Size = new System.Drawing.Size(227, 21);
            this.cbControl1.TabIndex = 13;
            // 
            // frmSellPre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(799, 524);
            this.Name = "frmSellPre";
            this.Text = "����֪ͨ��";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmSellPre_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl5;
        public myControl.EditControl editControl6;
        public myControl.lupControl lupControl3;
        public myControl.lupControl lupControl2;
        public myControl.lupControl lupControl5;
        public myControl.cbControl cbControl1;

    }
}
