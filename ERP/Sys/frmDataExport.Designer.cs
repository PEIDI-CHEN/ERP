namespace Sys
{
    partial class frmDataExport
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
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ckOperation = new DevExpress.XtraEditors.CheckEdit();
            this.ucDate = new myControl.ucDate();
            this.ckBase = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFlag = new System.Windows.Forms.Label();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.FileDlg = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckOperation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbExport
            // 
            this.sbExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbExport.Appearance.Options.UseFont = true;
            this.sbExport.Location = new System.Drawing.Point(360, 374);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(64, 23);
            this.sbExport.TabIndex = 0;
            this.sbExport.Text = "����(&E)";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Location = new System.Drawing.Point(431, 374);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(64, 23);
            this.sbClose.TabIndex = 1;
            this.sbClose.Text = "�ر�(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 345);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(472, 13);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Controls.Add(this.ckOperation);
            this.groupBox1.Controls.Add(this.ucDate);
            this.groupBox1.Controls.Add(this.ckBase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "��������",
            "��˾��Ϣ",
            "�û�������",
            "�û�����",
            "Ȩ������",
            "��Ӧ������",
            "�ͻ�����",
            "ְԱ����",
            "��������",
            "�ֿ�����",
            "��������",
            "��������",
            "������������",
            "��Ʒ����滮����",
            "��ӹ���������",
            "BOM����",
            "���˹�˾����",
            "ϵͳ�������",
            "�깺��",
            "�ɹ�����",
            "�ɹ�������",
            "�ɹ����",
            "�ɹ��˻���",
            "ѯ�۵�",
            "���۵�",
            "�ͻ�����",
            "����֪ͨ��",
            "������",
            "�տ",
            "�����˻���",
            "�̵㵥",
            "���ε�",
            "��װ��",
            "���������ֵ�",
            "�����ƻ���",
            "��������",
            "����״����",
            "���ϵ�",
            "���ϵ�",
            "���ϵ�",
            "��Ʒ���ֵ�",
            "ί��ӹ���",
            "ί�����ϵ�",
            "ί�����ϵ�",
            "ί����ֵ�",
            "ί���˻���",
            "ί�⸶�"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 88);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(467, 132);
            this.checkedListBox1.TabIndex = 5;
            // 
            // ckOperation
            // 
            this.ckOperation.EditValue = true;
            this.ckOperation.Location = new System.Drawing.Point(213, 60);
            this.ckOperation.Name = "ckOperation";
            this.ckOperation.Properties.Caption = "����ҵ��";
            this.ckOperation.Size = new System.Drawing.Size(75, 19);
            this.ckOperation.TabIndex = 2;
            this.ckOperation.CheckedChanged += new System.EventHandler(this.ckOperation_CheckedChanged);
            // 
            // ucDate
            // 
            this.ucDate.DateTag = myControl.DateFlag.ȫ��;
            this.ucDate.Location = new System.Drawing.Point(6, 228);
            this.ucDate.Name = "ucDate";
            this.ucDate.Size = new System.Drawing.Size(336, 26);
            this.ucDate.TabIndex = 4;
            // 
            // ckBase
            // 
            this.ckBase.EditValue = true;
            this.ckBase.Location = new System.Drawing.Point(21, 60);
            this.ckBase.Name = "ckBase";
            this.ckBase.Properties.Caption = "��������";
            this.ckBase.Size = new System.Drawing.Size(75, 19);
            this.ckBase.TabIndex = 1;
            this.ckBase.CheckedChanged += new System.EventHandler(this.ckBase_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "���������ǽ��������ݵ�����һ���ݰ�,�����ݰ��������ݵ���\r\n���ܵ��롣\r\n\r\n";
            // 
            // lbFlag
            // 
            this.lbFlag.AutoSize = true;
            this.lbFlag.Location = new System.Drawing.Point(188, 324);
            this.lbFlag.Name = "lbFlag";
            this.lbFlag.Size = new System.Drawing.Size(0, 12);
            this.lbFlag.TabIndex = 5;
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(13, 300);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(454, 21);
            this.txtFile.TabIndex = 6;
            // 
            // sbSelect
            // 
            this.sbSelect.Location = new System.Drawing.Point(473, 298);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(22, 23);
            this.sbSelect.TabIndex = 7;
            this.sbSelect.Text = "...";
            this.sbSelect.Click += new System.EventHandler(this.sbSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "����ļ�:";
            // 
            // FileDlg
            // 
            this.FileDlg.DefaultExt = "Rar";
            this.FileDlg.Filter = "ѹ���ļ�|*.Rar";
            // 
            // frmDataExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(507, 409);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sbSelect);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lbFlag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataExport";
            this.Text = "���ݵ���";
            this.Shown += new System.EventHandler(this.frmDataExport_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckOperation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbExport;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private myControl.ucDate ucDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFlag;
        private DevExpress.XtraEditors.CheckEdit ckOperation;
        private DevExpress.XtraEditors.CheckEdit ckBase;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraEditors.SimpleButton sbSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog FileDlg;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
