namespace Report
{
    partial class frmStorageSum
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStorageSum));
            this.cbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.seek = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rgOption
            // 
            this.rgOption.Location = new System.Drawing.Point(1085, 11);
            this.rgOption.Margin = new System.Windows.Forms.Padding(5);
            this.rgOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgOption.Properties.Appearance.Options.UseBackColor = true;
            // 
            // lbTitle
            // 
            this.lbTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTitle.Size = new System.Drawing.Size(125, 30);
            this.lbTitle.Text = "frmBase";
            // 
            // gcReport
            // 
            this.gcReport.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcReport.Location = new System.Drawing.Point(0, 93);
            this.gcReport.Size = new System.Drawing.Size(1924, 604);
            // 
            // gvReport
            // 
            this.gvReport.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvReport.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvReport.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvReport.OptionsBehavior.Editable = false;
            this.gvReport.OptionsLayout.Columns.StoreAllOptions = true;
            this.gvReport.OptionsLayout.Columns.StoreAppearance = true;
            this.gvReport.OptionsLayout.StoreDataSettings = false;
            this.gvReport.OptionsLayout.StoreVisualOptions = false;
            this.gvReport.OptionsPrint.AutoWidth = false;
            this.gvReport.OptionsView.ColumnAutoWidth = false;
            this.gvReport.OptionsView.ShowAutoFilterRow = true;
            this.gvReport.OptionsView.ShowFooter = true;
            this.gvReport.OptionsView.ShowIndicator = false;
            // 
            // btnFilter
            // 
            this.btnFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.ImageOptions.Image")));
            // 
            // btnDel
            // 
            this.btnDel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.ImageOptions.Image")));
            // 
            // ucDate
            // 
            this.ucDate.Location = new System.Drawing.Point(311, 12);
            this.ucDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ucDate.Size = new System.Drawing.Size(561, 35);
            // 
            // btnGraphi
            // 
            this.btnGraphi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGraphi.ImageOptions.Image")));
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.seek);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1924, 56);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.cbType, 0);
            this.panel1.Controls.SetChildIndex(this.ucDate, 0);
            this.panel1.Controls.SetChildIndex(this.rgOption, 0);
            this.panel1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panel1.Controls.SetChildIndex(this.seek, 0);
            this.panel1.Controls.SetChildIndex(this.textBox1, 0);
            this.panel1.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.Controls.SetChildIndex(this.panel4, 0);
            // 
            // cbType
            // 
            this.cbType.EditValue = "ȫ�� ";
            this.cbType.Location = new System.Drawing.Point(967, 16);
            this.cbType.Margin = new System.Windows.Forms.Padding(4);
            this.cbType.Name = "cbType";
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbType.Properties.Items.AddRange(new object[] {
            "ԭ����",
            "����Ʒ",
            "���Ʒ",
            "����",
            "ȫ�� "});
            this.cbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbType.Size = new System.Drawing.Size(111, 24);
            this.cbType.TabIndex = 20;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(880, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "��������:";
            // 
            // seek
            // 
            this.seek.Location = new System.Drawing.Point(1230, 12);
            this.seek.Name = "seek";
            this.seek.Size = new System.Drawing.Size(259, 28);
            this.seek.TabIndex = 22;
            this.seek.Text = "������ؼ���Ϣ���в���";
            this.seek.UseVisualStyleBackColor = true;
            this.seek.Click += new System.EventHandler(this.seek_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1509, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 25);
            this.textBox1.TabIndex = 23;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 481);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 216);
            this.panel2.TabIndex = 19;
            this.panel2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1657, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(159, 25);
            this.panel3.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(1822, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 29);
            this.panel4.TabIndex = 25;
            // 
            // frmStorageSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(1924, 728);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmStorageSum";
            this.Text = "���Ͻ�������ܱ�";
            this.Load += new System.EventHandler(this.frmStorageSum_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gcReport, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rgOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button seek;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel4;
    }
}
