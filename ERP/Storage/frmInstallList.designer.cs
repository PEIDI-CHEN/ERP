namespace Storage
{
    partial class frmInstallList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstallList));
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCutOff.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcList
            // 
            this.gcList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcList.Location = new System.Drawing.Point(0, 95);
            this.gcList.Size = new System.Drawing.Size(1185, 532);
            // 
            // gvList
            // 
            this.gvList.DetailHeight = 437;
            this.gvList.OptionsBehavior.Editable = false;
            this.gvList.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvList.OptionsLayout.Columns.StoreAppearance = true;
            this.gvList.OptionsLayout.StoreDataSettings = false;
            this.gvList.OptionsLayout.StoreVisualOptions = false;
            this.gvList.OptionsPrint.AutoWidth = false;
            this.gvList.OptionsView.ColumnAutoWidth = false;
            this.gvList.OptionsView.ShowAutoFilterRow = true;
            this.gvList.OptionsView.ShowFooter = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(1101, 16);
            this.cbType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // cbCheck
            // 
            this.cbCheck.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // cbFinish
            // 
            this.cbFinish.Location = new System.Drawing.Point(943, 16);
            this.cbFinish.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbFinish.Visible = false;
            // 
            // cbCutOff
            // 
            this.cbCutOff.Location = new System.Drawing.Point(786, 16);
            this.cbCutOff.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbCutOff.Visible = false;
            // 
            // lbType
            // 
            this.lbType.Location = new System.Drawing.Point(1054, 22);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(889, 22);
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(731, 22);
            this.label3.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            // 
            // btnDel
            // 
            this.btnDel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.ImageOptions.Image")));
            // 
            // frmInstallList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1185, 658);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmInstallList";
            this.Text = "��װ���б�";
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCutOff.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
