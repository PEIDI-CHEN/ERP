namespace Base
{
    partial class frmFactory
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvType
            // 
            this.tvType.LineColor = System.Drawing.Color.Black;
            this.tvType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tvType.Size = new System.Drawing.Size(181, 427);
            this.tvType.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 98);
            this.splitContainer1.Size = new System.Drawing.Size(878, 427);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Size = new System.Drawing.Size(878, 61);
            // 
            // frmFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(878, 556);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "frmFactory";
            this.Text = "��������";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
