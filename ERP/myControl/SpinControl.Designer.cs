namespace myControl
{
    partial class SpinControl
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
            this.spinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.lbLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEdit
            // 
            this.spinEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.spinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit.EnterMoveNextControl = true;
            this.spinEdit.Location = new System.Drawing.Point(67, 0);
            this.spinEdit.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit.Name = "spinEdit";
            this.spinEdit.Size = new System.Drawing.Size(123, 24);
            this.spinEdit.TabIndex = 0;
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLabel.AutoSize = true;
            this.lbLabel.Location = new System.Drawing.Point(4, 5);
            this.lbLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(55, 15);
            this.lbLabel.TabIndex = 1;
            this.lbLabel.Text = "label1";
            // 
            // SpinControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbLabel);
            this.Controls.Add(this.spinEdit);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpinControl";
            this.Size = new System.Drawing.Size(172, 26);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEdit;
        private System.Windows.Forms.Label lbLabel;
    }
}
