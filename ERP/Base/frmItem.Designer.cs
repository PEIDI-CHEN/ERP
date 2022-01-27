namespace Base
{
    partial class frmItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItem));
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcBase
            // 
            this.gcBase.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcBase.Size = new System.Drawing.Size(887, 396);
            this.gcBase.Click += new System.EventHandler(this.gcBase_Click);
            // 
            // gvBase
            // 
            this.gvBase.DetailHeight = 437;
            this.gvBase.OptionsBehavior.Editable = false;
            this.gvBase.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvBase.OptionsLayout.Columns.StoreAppearance = true;
            this.gvBase.OptionsLayout.StoreDataSettings = false;
            this.gvBase.OptionsLayout.StoreVisualOptions = false;
            this.gvBase.OptionsPrint.AutoWidth = false;
            this.gvBase.OptionsView.ColumnAutoWidth = false;
            this.gvBase.OptionsView.ShowAutoFilterRow = true;
            this.gvBase.OptionsView.ShowFooter = true;
            this.gvBase.OptionsView.ShowGroupPanel = false;
            // 
            // tvType
            // 
            this.tvType.LineColor = System.Drawing.Color.Black;
            this.tvType.Margin = new System.Windows.Forms.Padding(5);
            this.tvType.Size = new System.Drawing.Size(181, 396);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            // 
            // btnDel
            // 
            this.btnDel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.ImageOptions.Image")));
            // 
            // btnCopy
            // 
            this.btnCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.ImageOptions.Image")));
            // 
            // btnImport
            // 
            this.btnImport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.ImageOptions.Image")));
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 94);
            this.splitContainer1.Size = new System.Drawing.Size(1073, 396);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Size = new System.Drawing.Size(1073, 57);
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1073, 521);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "frmItem";
            this.Text = "物料资料";
            this.Load += new System.EventHandler(this.frmEditItem_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBase)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
