namespace Card
{
    partial class frmEditSendCard
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
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem1 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem2 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            DevExpress.XtraEditors.Controls.ComboBoxItem comboBoxItem3 = new DevExpress.XtraEditors.Controls.ComboBoxItem();
            this.cbControl1 = new myControl.cbControl();
            this.editControl1 = new myControl.EditControl();
            this.editControl2 = new myControl.EditControl();
            this.spinControl1 = new myControl.SpinControl();
            this.spinControl2 = new myControl.SpinControl();
            this.editControl3 = new myControl.EditControl();
            this.lupEmp = new myControl.lupControl();
            this.btnRead = new DevExpress.XtraEditors.SimpleButton();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.btnRead);
            this.gbox.Controls.Add(this.lupEmp);
            this.gbox.Controls.Add(this.editControl3);
            this.gbox.Controls.Add(this.spinControl2);
            this.gbox.Controls.Add(this.spinControl1);
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Margin = new System.Windows.Forms.Padding(5);
            this.gbox.Padding = new System.Windows.Forms.Padding(5);
            this.gbox.Size = new System.Drawing.Size(481, 351);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(144, 380);
            this.ckCopy.Margin = new System.Windows.Forms.Padding(5);
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(287, 375);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(5);
            this.BtnOK.Text = "发卡(&O)";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(399, 375);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "标准IC卡格式";
            comboBoxItem2.Value = "长IC卡格式";
            comboBoxItem3.Value = "新消费机IC卡格式";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2,
        comboBoxItem3};
            this.cbControl1.DataField = "F_Format";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "卡号格式:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(107, 28);
            this.cbControl1.Margin = new System.Windows.Forms.Padding(5);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(319, 26);
            this.cbControl1.TabIndex = 0;
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_CardNo";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "卡号:";
            this.editControl1.Location = new System.Drawing.Point(107, 170);
            this.editControl1.Margin = new System.Windows.Forms.Padding(5);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(232, 26);
            this.editControl1.TabIndex = 3;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Name";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "姓名:";
            this.editControl2.Location = new System.Drawing.Point(107, 126);
            this.editControl2.Margin = new System.Windows.Forms.Padding(5);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(232, 26);
            this.editControl2.TabIndex = 2;
            // 
            // spinControl1
            // 
            this.spinControl1.BackColor = System.Drawing.Color.Transparent;
            this.spinControl1.DataField = "F_Money";
            this.spinControl1.DataSource = null;
            this.spinControl1.EditLabel = "金额:";
            this.spinControl1.Location = new System.Drawing.Point(107, 214);
            this.spinControl1.Margin = new System.Windows.Forms.Padding(5);
            this.spinControl1.Name = "spinControl1";
            this.spinControl1.Size = new System.Drawing.Size(232, 26);
            this.spinControl1.TabIndex = 4;
            // 
            // spinControl2
            // 
            this.spinControl2.BackColor = System.Drawing.Color.Transparent;
            this.spinControl2.DataField = "F_Time";
            this.spinControl2.DataSource = null;
            this.spinControl2.EditLabel = "充值次数:";
            this.spinControl2.Location = new System.Drawing.Point(73, 258);
            this.spinControl2.Margin = new System.Windows.Forms.Padding(5);
            this.spinControl2.Name = "spinControl2";
            this.spinControl2.Size = new System.Drawing.Size(265, 26);
            this.spinControl2.TabIndex = 5;
            // 
            // editControl3
            // 
            this.editControl3.BackColor = System.Drawing.Color.Transparent;
            this.editControl3.DataField = "F_Psw";
            this.editControl3.DataSource = null;
            this.editControl3.EditLabel = "新IC卡密码:";
            this.editControl3.Location = new System.Drawing.Point(57, 301);
            this.editControl3.Margin = new System.Windows.Forms.Padding(5);
            this.editControl3.Name = "editControl3";
            this.editControl3.Request = false;
            this.editControl3.Size = new System.Drawing.Size(281, 26);
            this.editControl3.TabIndex = 6;
            // 
            // lupEmp
            // 
            this.lupEmp.BackColor = System.Drawing.Color.Transparent;
            this.lupEmp.DataField = "F_ID";
            this.lupEmp.DataSource = null;
            this.lupEmp.DisplayCaption = "";
            this.lupEmp.DropSQL = "";
            this.lupEmp.EditLabel = "工号:";
            this.lupEmp.InvokeClass = "";
            this.lupEmp.LinkFields = null;
            this.lupEmp.Location = new System.Drawing.Point(107, 81);
            this.lupEmp.LookUpDataSource = null;
            this.lupEmp.LookUpDisplayField = null;
            this.lupEmp.LookUpKeyField = null;
            this.lupEmp.Margin = new System.Windows.Forms.Padding(4);
            this.lupEmp.Name = "lupEmp";
            this.lupEmp.PopWidth = 200;
            this.lupEmp.Request = false;
            this.lupEmp.Size = new System.Drawing.Size(271, 28);
            this.lupEmp.TabIndex = 1;
            this.lupEmp.ValueChanged += new myControl.SelectChangeEventHandler(this.lupEmp_ValueChanged);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(371, 167);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(55, 29);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "读取";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // frmEditSendCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(515, 419);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmEditSendCard";
            this.Text = "发卡";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.cbControl cbControl1;
        private myControl.SpinControl spinControl1;
        private myControl.EditControl editControl2;
        private myControl.EditControl editControl1;
        private myControl.SpinControl spinControl2;
        private myControl.EditControl editControl3;
        private myControl.lupControl lupEmp;
        private DevExpress.XtraEditors.SimpleButton btnRead;

    }
}
