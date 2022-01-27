namespace Sell
{
    partial class frmSellOrder
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private new System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSellOrder));
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem4 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.lupControl1 = new myControl.lupControl();
            this.editControl5 = new myControl.EditControl();
            this.dateControl2 = new myControl.DateControl();
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.editControl6 = new myControl.EditControl();
            this.lupControl4 = new myControl.lupControl();
            this.editControl7 = new myControl.EditControl();
            this.editControl8 = new myControl.EditControl();
            this.sbLoad = new DevExpress.XtraEditors.SimpleButton();
            this.cbControl1 = new myControl.cbControl();
            this.lupControl5 = new myControl.lupControl();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTitle.Size = new System.Drawing.Size(117, 27);
            this.lbTitle.Text = "frmBase";
            // 
            // btnOther
            // 
            this.btnOther.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOther.ImageOptions.Image")));
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.lupControl5);
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.sbLoad);
            this.panelControl1.Controls.Add(this.editControl8);
            this.panelControl1.Controls.Add(this.editControl7);
            this.panelControl1.Controls.Add(this.lupControl4);
            this.panelControl1.Controls.Add(this.editControl6);
            this.panelControl1.Controls.Add(this.lupControl3);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.dateControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 37);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelControl1.Size = new System.Drawing.Size(1067, 225);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl3, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl6, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl4, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl7, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl8, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbLoad, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl5, 0);
            // 
            // editControl4
            // 
            this.editControl4.Location = new System.Drawing.Point(763, 8);
            this.editControl4.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            // 
            // editControl3
            // 
            this.editControl3.Location = new System.Drawing.Point(345, 8);
            this.editControl3.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(388, 45);
            this.dateControl1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(391, 11);
            this.editControl1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_ClientID";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "客户:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(33, 83);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 200;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(360, 29);
            this.lupControl1.TabIndex = 3;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(205, 142);
            this.editControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(463, 21);
            this.editControl5.TabIndex = 11;
            // 
            // dateControl2
            // 
            this.dateControl2.BackColor = System.Drawing.Color.Transparent;
            this.dateControl2.DataField = "F_SendDate";
            this.dateControl2.DataSource = null;
            this.dateControl2.DisplayFormat = "d";
            this.dateControl2.EditLabel = "发货日期:";
            this.dateControl2.EditMask = "d";
            this.dateControl2.Location = new System.Drawing.Point(219, 51);
            this.dateControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateControl2.Name = "dateControl2";
            this.dateControl2.Request = true;
            this.dateControl2.Size = new System.Drawing.Size(158, 24);
            this.dateControl2.TabIndex = 4;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_DeptID";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.DropSQL = "";
            this.lupControl2.EditLabel = "部门:";
            this.lupControl2.InvokeClass = "";
            this.lupControl2.LinkFields = null;
            this.lupControl2.Location = new System.Drawing.Point(33, 121);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 200;
            this.lupControl2.Request = false;
            this.lupControl2.Size = new System.Drawing.Size(220, 29);
            this.lupControl2.TabIndex = 5;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_Opertor";
            this.lupControl3.DataSource = null;
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.DropSQL = "";
            this.lupControl3.EditLabel = "业务员:";
            this.lupControl3.InvokeClass = "";
            this.lupControl3.LinkFields = null;
            this.lupControl3.Location = new System.Drawing.Point(301, 120);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.PopWidth = 200;
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(239, 29);
            this.lupControl3.TabIndex = 6;
            // 
            // editControl6
            // 
            this.editControl6.BackColor = System.Drawing.Color.Transparent;
            this.editControl6.DataField = "F_ContractID";
            this.editControl6.DataSource = null;
            this.editControl6.EditLabel = "合同号:";
            this.editControl6.Location = new System.Drawing.Point(394, 90);
            this.editControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editControl6.Name = "editControl6";
            this.editControl6.Request = false;
            this.editControl6.Size = new System.Drawing.Size(191, 21);
            this.editControl6.TabIndex = 7;
            // 
            // lupControl4
            // 
            this.lupControl4.BackColor = System.Drawing.Color.Transparent;
            this.lupControl4.DataField = "F_CarryCompany";
            this.lupControl4.DataSource = null;
            this.lupControl4.DisplayCaption = "";
            this.lupControl4.DropSQL = "";
            this.lupControl4.EditLabel = "货运公司:";
            this.lupControl4.InvokeClass = "";
            this.lupControl4.LinkFields = null;
            this.lupControl4.Location = new System.Drawing.Point(583, 152);
            this.lupControl4.LookUpDataSource = null;
            this.lupControl4.LookUpDisplayField = null;
            this.lupControl4.LookUpKeyField = null;
            this.lupControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl4.Name = "lupControl4";
            this.lupControl4.PopWidth = 200;
            this.lupControl4.Request = false;
            this.lupControl4.Size = new System.Drawing.Size(336, 29);
            this.lupControl4.TabIndex = 10;
            // 
            // editControl7
            // 
            this.editControl7.BackColor = System.Drawing.Color.Transparent;
            this.editControl7.DataField = "F_LinkTel";
            this.editControl7.DataSource = null;
            this.editControl7.EditLabel = "联系电话:";
            this.editControl7.Location = new System.Drawing.Point(1, 118);
            this.editControl7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editControl7.Name = "editControl7";
            this.editControl7.Request = false;
            this.editControl7.Size = new System.Drawing.Size(157, 21);
            this.editControl7.TabIndex = 8;
            // 
            // editControl8
            // 
            this.editControl8.BackColor = System.Drawing.Color.Transparent;
            this.editControl8.DataField = "F_LinkMan";
            this.editControl8.DataSource = null;
            this.editControl8.EditLabel = "联系人:";
            this.editControl8.Location = new System.Drawing.Point(198, 118);
            this.editControl8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editControl8.Name = "editControl8";
            this.editControl8.Request = false;
            this.editControl8.Size = new System.Drawing.Size(157, 21);
            this.editControl8.TabIndex = 9;
            // 
            // sbLoad
            // 
            this.sbLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbLoad.Appearance.Options.UseFont = true;
            this.sbLoad.Location = new System.Drawing.Point(940, 151);
            this.sbLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sbLoad.Name = "sbLoad";
            this.sbLoad.Size = new System.Drawing.Size(77, 31);
            this.sbLoad.TabIndex = 13;
            this.sbLoad.Text = "附件";
            this.sbLoad.Click += new System.EventHandler(this.sbLoad_Click);
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "销售发货出库";
            comboBoxItem2.Value = "零售出库";
            comboBoxItem3.Value = "业务出库";
            comboBoxItem4.Value = "代理商出库";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3,
        comboBoxItem4};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "出库类型:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(1, 142);
            this.cbControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = true;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(199, 21);
            this.cbControl1.TabIndex = 14;
            // 
            // lupControl5
            // 
            this.lupControl5.BackColor = System.Drawing.Color.Transparent;
            this.lupControl5.DataField = "F_BalanceType";
            this.lupControl5.DataSource = null;
            this.lupControl5.DisplayCaption = "";
            this.lupControl5.DropSQL = "";
            this.lupControl5.EditLabel = "结算方式:";
            this.lupControl5.InvokeClass = "";
            this.lupControl5.LinkFields = null;
            this.lupControl5.Location = new System.Drawing.Point(649, 80);
            this.lupControl5.LookUpDataSource = null;
            this.lupControl5.LookUpDisplayField = null;
            this.lupControl5.LookUpKeyField = null;
            this.lupControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl5.Name = "lupControl5";
            this.lupControl5.PopWidth = 200;
            this.lupControl5.Request = true;
            this.lupControl5.Size = new System.Drawing.Size(269, 29);
            this.lupControl5.TabIndex = 15;
            // 
            // frmSellOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1067, 703);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "frmSellOrder";
            this.Text = "客户订单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmSellOrder_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSellOrder_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl5;
        public myControl.DateControl dateControl2;
        public myControl.EditControl editControl6;
        public myControl.lupControl lupControl3;
        public myControl.lupControl lupControl2;
        public myControl.lupControl lupControl4;
        public myControl.EditControl editControl8;
        public myControl.EditControl editControl7;
        public DevExpress.XtraEditors.SimpleButton sbLoad;
        public myControl.cbControl cbControl1;
        public myControl.lupControl lupControl5;

    }
}
