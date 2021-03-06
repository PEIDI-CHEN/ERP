namespace Common
{
    partial class frmBillImport
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
            this.ucDate = new myControl.ucDate();
            this.gcMaster = new DevExpress.XtraGrid.GridControl();
            this.gvMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSlaver = new DevExpress.XtraGrid.GridControl();
            this.gvSlaver = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sbOK = new DevExpress.XtraEditors.SimpleButton();
            this.spClose = new DevExpress.XtraEditors.SimpleButton();
            this.ckAll = new DevExpress.XtraEditors.CheckEdit();
            this.cbBill = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ckAddImport = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAddImport.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDate
            // 
            this.ucDate.DateTag = myControl.DateFlag.当天;
            this.ucDate.Location = new System.Drawing.Point(1, 4);
            this.ucDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucDate.Name = "ucDate";
            this.ucDate.Size = new System.Drawing.Size(529, 37);
            this.ucDate.TabIndex = 0;
            this.ucDate.RefreshDateChanged += new myControl.RefreshDateEventHandler(this.ucDate_RefreshDateChanged);
            // 
            // gcMaster
            // 
            this.gcMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcMaster.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcMaster.Location = new System.Drawing.Point(17, 51);
            this.gcMaster.MainView = this.gvMaster;
            this.gcMaster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcMaster.Name = "gcMaster";
            this.gcMaster.Size = new System.Drawing.Size(843, 208);
            this.gcMaster.TabIndex = 1;
            this.gcMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaster,
            this.gridView2});
            // 
            // gvMaster
            // 
            this.gvMaster.DetailHeight = 467;
            this.gvMaster.FixedLineWidth = 3;
            this.gvMaster.GridControl = this.gcMaster;
            this.gvMaster.Name = "gvMaster";
            this.gvMaster.OptionsBehavior.Editable = false;
            this.gvMaster.OptionsCustomization.AllowFilter = false;
            this.gvMaster.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvMaster.OptionsLayout.Columns.StoreAppearance = true;
            this.gvMaster.OptionsLayout.StoreDataSettings = false;
            this.gvMaster.OptionsLayout.StoreVisualOptions = false;
            this.gvMaster.OptionsView.ColumnAutoWidth = false;
            this.gvMaster.OptionsView.ShowFooter = true;
            this.gvMaster.OptionsView.ShowGroupPanel = false;
            this.gvMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMaster_FocusedRowChanged);
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 467;
            this.gridView2.FixedLineWidth = 3;
            this.gridView2.GridControl = this.gcMaster;
            this.gridView2.Name = "gridView2";
            // 
            // gcSlaver
            // 
            this.gcSlaver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSlaver.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcSlaver.Location = new System.Drawing.Point(16, 267);
            this.gcSlaver.MainView = this.gvSlaver;
            this.gcSlaver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcSlaver.Name = "gcSlaver";
            this.gcSlaver.Size = new System.Drawing.Size(843, 251);
            this.gcSlaver.TabIndex = 2;
            this.gcSlaver.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSlaver,
            this.gridView4});
            // 
            // gvSlaver
            // 
            this.gvSlaver.DetailHeight = 467;
            this.gvSlaver.FixedLineWidth = 3;
            this.gvSlaver.GridControl = this.gcSlaver;
            this.gvSlaver.Name = "gvSlaver";
            this.gvSlaver.OptionsCustomization.AllowFilter = false;
            this.gvSlaver.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvSlaver.OptionsLayout.Columns.StoreAppearance = true;
            this.gvSlaver.OptionsLayout.StoreDataSettings = false;
            this.gvSlaver.OptionsLayout.StoreVisualOptions = false;
            this.gvSlaver.OptionsView.ColumnAutoWidth = false;
            this.gvSlaver.OptionsView.ShowFooter = true;
            this.gvSlaver.OptionsView.ShowGroupPanel = false;
            // 
            // gridView4
            // 
            this.gridView4.DetailHeight = 467;
            this.gridView4.FixedLineWidth = 3;
            this.gridView4.GridControl = this.gcSlaver;
            this.gridView4.Name = "gridView4";
            // 
            // sbOK
            // 
            this.sbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbOK.Appearance.Options.UseFont = true;
            this.sbOK.Location = new System.Drawing.Point(651, 527);
            this.sbOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(100, 31);
            this.sbOK.TabIndex = 3;
            this.sbOK.Text = "导入到单据";
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // spClose
            // 
            this.spClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spClose.Appearance.Options.UseFont = true;
            this.spClose.Location = new System.Drawing.Point(759, 527);
            this.spClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spClose.Name = "spClose";
            this.spClose.Size = new System.Drawing.Size(100, 31);
            this.spClose.TabIndex = 4;
            this.spClose.Text = "关闭(&C)";
            this.spClose.Click += new System.EventHandler(this.spClose_Click);
            // 
            // ckAll
            // 
            this.ckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckAll.EditValue = true;
            this.ckAll.Location = new System.Drawing.Point(16, 525);
            this.ckAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckAll.Name = "ckAll";
            this.ckAll.Properties.Caption = "全选";
            this.ckAll.Size = new System.Drawing.Size(100, 21);
            this.ckAll.TabIndex = 5;
            this.ckAll.CheckedChanged += new System.EventHandler(this.ckAll_CheckedChanged);
            // 
            // cbBill
            // 
            this.cbBill.Location = new System.Drawing.Point(661, 11);
            this.cbBill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBill.Name = "cbBill";
            this.cbBill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBill.Size = new System.Drawing.Size(197, 22);
            this.cbBill.TabIndex = 6;
            this.cbBill.SelectedIndexChanged += new System.EventHandler(this.cbBill_SelectedIndexChanged);
            // 
            // ckAddImport
            // 
            this.ckAddImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckAddImport.Location = new System.Drawing.Point(231, 527);
            this.ckAddImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckAddImport.Name = "ckAddImport";
            this.ckAddImport.Properties.Caption = "合并导入";
            this.ckAddImport.Size = new System.Drawing.Size(100, 21);
            this.ckAddImport.TabIndex = 7;
            // 
            // frmBillImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(876, 568);
            this.Controls.Add(this.ckAddImport);
            this.Controls.Add(this.cbBill);
            this.Controls.Add(this.ckAll);
            this.Controls.Add(this.spClose);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.gcSlaver);
            this.Controls.Add(this.gcMaster);
            this.Controls.Add(this.ucDate);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmBillImport";
            this.Text = "单据导入";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBillImport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gcMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAddImport.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.ucDate ucDate;
        private DevExpress.XtraGrid.GridControl gcMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gcSlaver;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSlaver;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.SimpleButton sbOK;
        private DevExpress.XtraEditors.SimpleButton spClose;
        private DevExpress.XtraEditors.CheckEdit ckAll;
        private DevExpress.XtraEditors.ComboBoxEdit cbBill;
        private DevExpress.XtraEditors.CheckEdit ckAddImport;
    }
}
