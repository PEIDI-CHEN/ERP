namespace Product
{
    partial class frmBackGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackGoods));
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.editControl5 = new myControl.EditControl();
            this.lupControl2 = new myControl.lupControl();
            this.lupControl3 = new myControl.lupControl();
            this.cbControl1 = new myControl.cbControl();
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTitle.Size = new System.Drawing.Size(117, 27);
            this.lbTitle.Text = "frmBase";
            // 
            // btnOther
            // 
            this.btnOther.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOther.ImageOptions.Image")));
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cbControl1);
            this.panelControl1.Controls.Add(this.lupControl3);
            this.panelControl1.Controls.Add(this.lupControl2);
            this.panelControl1.Controls.Add(this.editControl5);
            this.panelControl1.Location = new System.Drawing.Point(0, 37);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelControl1.Size = new System.Drawing.Size(1065, 168);
            this.panelControl1.Controls.SetChildIndex(this.lbTitle, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.dateControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.editControl5, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.lupControl3, 0);
            this.panelControl1.Controls.SetChildIndex(this.cbControl1, 0);
            // 
            // editControl4
            // 
            this.editControl4.Location = new System.Drawing.Point(823, 8);
            // 
            // editControl3
            // 
            this.editControl3.Location = new System.Drawing.Point(373, 8);
            // 
            // dateControl1
            // 
            this.dateControl1.Location = new System.Drawing.Point(383, 37);
            this.dateControl1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            // 
            // editControl1
            // 
            this.editControl1.Location = new System.Drawing.Point(383, 0);
            this.editControl1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            // 
            // editControl5
            // 
            this.editControl5.BackColor = System.Drawing.Color.Transparent;
            this.editControl5.DataField = "F_Remark";
            this.editControl5.DataSource = null;
            this.editControl5.EditLabel = "��ע:";
            this.editControl5.Location = new System.Drawing.Point(32, 91);
            this.editControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editControl5.Name = "editControl5";
            this.editControl5.Request = false;
            this.editControl5.Size = new System.Drawing.Size(490, 27);
            this.editControl5.TabIndex = 4;
            // 
            // lupControl2
            // 
            this.lupControl2.BackColor = System.Drawing.Color.Transparent;
            this.lupControl2.DataField = "F_DeptID";
            this.lupControl2.DataSource = null;
            this.lupControl2.DisplayCaption = "";
            this.lupControl2.DropSQL = "";
            this.lupControl2.EditLabel = "����:";
            this.lupControl2.InvokeClass = "";
            this.lupControl2.LinkFields = null;
            this.lupControl2.Location = new System.Drawing.Point(49, 84);
            this.lupControl2.LookUpDataSource = null;
            this.lupControl2.LookUpDisplayField = null;
            this.lupControl2.LookUpKeyField = null;
            this.lupControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl2.Name = "lupControl2";
            this.lupControl2.PopWidth = 0;
            this.lupControl2.Request = true;
            this.lupControl2.Size = new System.Drawing.Size(220, 29);
            this.lupControl2.TabIndex = 7;
            // 
            // lupControl3
            // 
            this.lupControl3.BackColor = System.Drawing.Color.Transparent;
            this.lupControl3.DataField = "F_BackMan";
            this.lupControl3.DataSource = null;
            this.lupControl3.DisplayCaption = "";
            this.lupControl3.DropSQL = "";
            this.lupControl3.EditLabel = "������:";
            this.lupControl3.InvokeClass = "";
            this.lupControl3.LinkFields = null;
            this.lupControl3.Location = new System.Drawing.Point(301, 84);
            this.lupControl3.LookUpDataSource = null;
            this.lupControl3.LookUpDisplayField = null;
            this.lupControl3.LookUpKeyField = null;
            this.lupControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl3.Name = "lupControl3";
            this.lupControl3.PopWidth = 0;
            this.lupControl3.Request = false;
            this.lupControl3.Size = new System.Drawing.Size(220, 29);
            this.lupControl3.TabIndex = 8;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "��������";
            comboBoxItem2.Value = "��ӹ�����";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2};
            this.cbControl1.DataField = "F_Kind";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "�������:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(365, 59);
            this.cbControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(158, 26);
            this.cbControl1.TabIndex = 9;
            // 
            // frmBackGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1065, 716);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "frmBackGoods";
            this.Text = "���ϵ�";
            this.Load += new System.EventHandler(this.frmStockOrder_Load);
            this.Shown += new System.EventHandler(this.frmBackGoods_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.binMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSlaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private myControl.EditControl editControl5;
        private myControl.lupControl lupControl3;
        private myControl.lupControl lupControl2;
        private myControl.cbControl cbControl1;
    }
}
