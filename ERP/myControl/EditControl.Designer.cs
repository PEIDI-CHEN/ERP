namespace myControl
{
    partial class EditControl
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
            this.lbLabel = new System.Windows.Forms.Label();
            this.txtEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.AutoSize = true;
            this.lbLabel.Location = new System.Drawing.Point(4, 7);
            this.lbLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(55, 15);
            this.lbLabel.TabIndex = 0;
            this.lbLabel.Text = "label1";
            // 
            // txtEdit
            // 
            this.txtEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEdit.EnterMoveNextControl = true;
            this.txtEdit.Location = new System.Drawing.Point(65, 0);
            this.txtEdit.Margin = new System.Windows.Forms.Padding(4);
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(163, 24);
            this.txtEdit.TabIndex = 1;
            // 
            // EditControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtEdit);
            this.Controls.Add(this.lbLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditControl";
            this.Size = new System.Drawing.Size(178, 27);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLabel;
        public DevExpress.XtraEditors.TextEdit txtEdit;
    }
}
