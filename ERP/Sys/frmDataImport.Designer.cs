namespace Sys
{
    partial class frmDataImport
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
            this.sbImport = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbFlag = new System.Windows.Forms.Label();
            this.FileDlg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbImport
            // 
            this.sbImport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbImport.Appearance.Options.UseFont = true;
            this.sbImport.Location = new System.Drawing.Point(231, 153);
            this.sbImport.Name = "sbImport";
            this.sbImport.Size = new System.Drawing.Size(64, 23);
            this.sbImport.TabIndex = 0;
            this.sbImport.Text = "����(&I)";
            this.sbImport.Click += new System.EventHandler(this.sbImport_Click);
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Location = new System.Drawing.Point(301, 153);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(64, 23);
            this.sbClose.TabIndex = 1;
            this.sbClose.Text = "�ر�(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(25, 50);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(314, 21);
            this.txtFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "�������ļ�:";
            // 
            // sbSelect
            // 
            this.sbSelect.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbSelect.Appearance.Options.UseFont = true;
            this.sbSelect.Location = new System.Drawing.Point(340, 50);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(24, 23);
            this.sbSelect.TabIndex = 4;
            this.sbSelect.Text = "...";
            this.sbSelect.Click += new System.EventHandler(this.sbSelect_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(25, 112);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(340, 12);
            this.progressBar.TabIndex = 5;
            // 
            // lbFlag
            // 
            this.lbFlag.AutoSize = true;
            this.lbFlag.Location = new System.Drawing.Point(161, 97);
            this.lbFlag.Name = "lbFlag";
            this.lbFlag.Size = new System.Drawing.Size(0, 12);
            this.lbFlag.TabIndex = 6;
            // 
            // FileDlg
            // 
            this.FileDlg.DefaultExt = "Rar";
            this.FileDlg.Filter = "ѹ���ļ�|*.Rar";
            // 
            // frmDataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(388, 196);
            this.Controls.Add(this.lbFlag);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.sbSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataImport";
            this.Text = "��������";
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbImport;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbFlag;
        private System.Windows.Forms.OpenFileDialog FileDlg;
    }
}
