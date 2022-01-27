namespace Storage
{
    partial class frmCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheck));
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.lupControl1 = new myControl.lupControl();
            this.editControl5 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.sbImport = new DevExpress.XtraEditors.SimpleButton();
            this.sbImportExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            // 
            // btnLoadBill
            // 
            this.btnLoadBill.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadBill.ImageOptions.Image")));
            // 
            // btnAddRow
            // 
            this.btnAddRow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.ImageOptions.Image")));
            // 
            // btnDelRow
            // 
            this.btnDelRow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRow.ImageOptions.Image")));
            // 
            // btnCutOff
            // 
            this.btnCutOff.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCutOff.ImageOptions.Image")));
            // 
            // btnUnCutOff
            // 
            this.btnUnCutOff.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUnCutOff.ImageOptions.Image")));
            // 
            // btnNew
            // 
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            // 
            // btnCopy
            // 
            this.btnCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.ImageOptions.Image")));
            // 
            // lbTitle
            // 
            this.lbTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTitle.Size = new System.Drawing.Size(117, 27);
            this.lbTitle.Text = "frmBase";
            // 
            // btnBalance
            // 
            this.btnBalance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBalance.ImageOptions.Image")));
            // 
            // btnOther
            // 
            this.btnOther.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOther.ImageOptions.Image")));
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.sbImportExcel);
            this.panelControl1.Controls.Add(this.sbImport);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Controls.Add(this.lupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 37);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(1089, 142);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbImport, 0);
            this.panelControl1.Controls.SetChildIndex(this.sbImportExcel, 0);
            // 
            // editControl4
            // 
            this.editControl4.Location = new System.Drawing.Point(823, 8);
            this.editControl4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // editControl3
            // 
            this.editControl3.Location = new System.Drawing.Point(373, 8);
            this.editControl3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // gcBill
            // 
            this.gcBill.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcBill.Location = new System.Drawing.Point(0, 179);
            repositoryItemButtonEdit2.AutoHeight = false;
            repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit1";
            this.gcBill.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            repositoryItemButtonEdit2,
            this.repositoryItemButtonEdit1});
            this.gcBill.Size = new System.Drawing.Size(1089, 418);
            // 
            // gvList
            // 
            this.gvList.OptionsCustomization.AllowFilter = false;
            this.gvList.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvList.OptionsLayout.Columns.StoreAppearance = true;
            this.gvList.OptionsLayout.StoreDataSettings = false;
            this.gvList.OptionsLayout.StoreVisualOptions = false;
            this.gvList.OptionsNavigation.AutoFocusNewRow = true;
            this.gvList.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvList.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvList.OptionsView.ColumnAutoWidth = false;
            this.gvList.OptionsView.ShowAutoFilterRow = true;
            this.gvList.OptionsView.ShowFooter = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            this.gvList.OptionsView.ShowIndicator = false;
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(726, 56);
            this.dateControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dateControl1.Size = new System.Drawing.Size(286, 30);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(412, 98);
            this.editControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.editControl1.Size = new System.Drawing.Size(308, 29);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_StorageID";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "仓库:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(49, 62);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 200;
            this.lupControl1.Request = true;
            this.lupControl1.Size = new System.Drawing.Size(274, 28);
            this.lupControl1.TabIndex = 3;
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "备注:";
            this.editControl5.Location = new System.Drawing.Point(49, 98);
            this.editControl5.Margin = new System.Windows.Forms.Padding(5);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(323, 34);
            this.editControl5.TabIndex = 4;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_StoreMan";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.DropSQL = "";
            this.lupControl2.EditLabel = "仓管员:";
            this.lupControl2.InvokeClass = "";
            this.lupControl2.LinkFields = null;
            this.lupControl2.Location = new System.Drawing.Point(399, 58);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Margin = new System.Windows.Forms.Padding(4);
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 200;
            this.lupControl2.Request = true;
            this.lupControl2.Size = new System.Drawing.Size(274, 28);
            this.lupControl2.TabIndex = 6;
            // 
            // sbImport
            // 
            this.sbImport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbImport.Appearance.Options.UseFont = true;
            this.sbImport.Location = new System.Drawing.Point(817, 98);
            this.sbImport.Margin = new System.Windows.Forms.Padding(4);
            this.sbImport.Name = "sbImport";
            this.sbImport.Size = new System.Drawing.Size(100, 29);
            this.sbImport.TabIndex = 7;
            this.sbImport.Text = "导入库存数";
            this.sbImport.Click += new System.EventHandler(this.sbImport_Click);
            // 
            // sbImportExcel
            // 
            this.sbImportExcel.Location = new System.Drawing.Point(953, 98);
            this.sbImportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.sbImportExcel.Name = "sbImportExcel";
            this.sbImportExcel.Size = new System.Drawing.Size(109, 29);
            this.sbImportExcel.TabIndex = 8;
            this.sbImportExcel.Text = "从EXCEL导入";
            this.sbImportExcel.Click += new System.EventHandler(this.sbImportExcel_Click);
            // 
            // frmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1089, 670);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmCheck";
            this.Text = "盘点单";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmCheck_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbImportExcel;
        public myControl.lupControl lupControl1;
        public myControl.EditControl editControl5;
        public myControl.lupControl lupControl2;
        public DevExpress.XtraEditors.SimpleButton sbImport;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}
