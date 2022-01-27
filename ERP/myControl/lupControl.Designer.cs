namespace myControl
{
    partial class lupControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lupEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.lbLabel = new System.Windows.Forms.Label();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lupEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lupEdit
            // 
            this.lupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lupEdit.EnterMoveNextControl = true;
            this.lupEdit.Location = new System.Drawing.Point(119, 0);
            this.lupEdit.Name = "lupEdit";
            this.lupEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lupEdit.Properties.AutoSearchColumnIndex = 1;
            this.lupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupEdit.Properties.DropDownRows = 10;
            this.lupEdit.Properties.ImmediatePopup = true;
            this.lupEdit.Properties.NullText = "";
            this.lupEdit.Properties.ShowFooter = false;
            this.lupEdit.Properties.ShowHeader = false;
            this.lupEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lupEdit.Size = new System.Drawing.Size(120, 24);
            this.lupEdit.TabIndex = 0;
            this.lupEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lupEdit_KeyDown);
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.Location = new System.Drawing.Point(3, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(36, 24);
            this.lbLabel.TabIndex = 1;
            this.lbLabel.Text = "label1";
            // 
            // sbSelect
            // 
            this.sbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbSelect.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelect.Appearance.Options.UseFont = true;
            this.sbSelect.Location = new System.Drawing.Point(245, 2);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(20, 22);
            this.sbSelect.TabIndex = 2;
            this.sbSelect.TabStop = false;
            this.sbSelect.Text = "...";
            this.sbSelect.Click += new System.EventHandler(this.sbSelect_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(6, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 29);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(100, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 29);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(244, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(23, 29);
            this.panel3.TabIndex = 5;
            // 
            // lupControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sbSelect);
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.lupEdit);
            this.Name = "lupControl";
            this.Size = new System.Drawing.Size(268, 29);
            this.Load += new System.EventHandler(this.lupControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lupEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbLabel;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        public DevExpress.XtraEditors.LookUpEdit lupEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
