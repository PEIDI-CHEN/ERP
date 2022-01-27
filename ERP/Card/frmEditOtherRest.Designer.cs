namespace Card
{
    partial class frmEditOtherRest
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
            this.lupControl1 = new myControl.lupControl();
            this.dateControl1 = new myControl.DateControl();
            this.dateControl2 = new myControl.DateControl();
            this.dateControl3 = new myControl.DateControl();
            this.dateControl4 = new myControl.DateControl();
            this.dateControl5 = new myControl.DateControl();
            this.cbControl1 = new myControl.cbControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.cbControl1);
            this.gbox.Controls.Add(this.dateControl4);
            this.gbox.Controls.Add(this.dateControl5);
            this.gbox.Controls.Add(this.dateControl3);
            this.gbox.Controls.Add(this.dateControl2);
            this.gbox.Controls.Add(this.dateControl1);
            this.gbox.Controls.Add(this.lupControl1);
            this.gbox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbox.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbox.Size = new System.Drawing.Size(611, 339);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(16, 362);
            this.ckCopy.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(420, 362);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(528, 362);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // lupControl1
            // 
            this.lupControl1.BackColor = System.Drawing.Color.Transparent;
            this.lupControl1.DataField = "F_ID";
            this.lupControl1.DataSource = null;
            this.lupControl1.DisplayCaption = "";
            this.lupControl1.DropSQL = "";
            this.lupControl1.EditLabel = "员工:";
            this.lupControl1.InvokeClass = "";
            this.lupControl1.LinkFields = null;
            this.lupControl1.Location = new System.Drawing.Point(72, 63);
            this.lupControl1.LookUpDataSource = null;
            this.lupControl1.LookUpDisplayField = null;
            this.lupControl1.LookUpKeyField = null;
            this.lupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lupControl1.Name = "lupControl1";
            this.lupControl1.PopWidth = 200;
            this.lupControl1.Request = false;
            this.lupControl1.Size = new System.Drawing.Size(358, 26);
            this.lupControl1.TabIndex = 0;
            // 
            // dateControl1
            // 
            this.dateControl1.BackColor = System.Drawing.Color.Transparent;
            this.dateControl1.DataField = "F_OrgBegin";
            this.dateControl1.DataSource = null;
            this.dateControl1.DisplayFormat = "g";
            this.dateControl1.EditLabel = "原休息开始时间:";
            this.dateControl1.EditMask = "g";
            this.dateControl1.Location = new System.Drawing.Point(61, 151);
            this.dateControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateControl1.Name = "dateControl1";
            this.dateControl1.Request = false;
            this.dateControl1.Size = new System.Drawing.Size(272, 26);
            this.dateControl1.TabIndex = 2;
            // 
            // dateControl2
            // 
            this.dateControl2.BackColor = System.Drawing.Color.Transparent;
            this.dateControl2.DataField = "F_OrgEnd";
            this.dateControl2.DataSource = null;
            this.dateControl2.DisplayFormat = "g";
            this.dateControl2.EditLabel = "原休息结束时间:";
            this.dateControl2.EditMask = "g";
            this.dateControl2.Location = new System.Drawing.Point(61, 185);
            this.dateControl2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateControl2.Name = "dateControl2";
            this.dateControl2.Request = false;
            this.dateControl2.Size = new System.Drawing.Size(272, 26);
            this.dateControl2.TabIndex = 3;
            // 
            // dateControl3
            // 
            this.dateControl3.BackColor = System.Drawing.Color.Transparent;
            this.dateControl3.DataField = "F_Date";
            this.dateControl3.DataSource = null;
            this.dateControl3.DisplayFormat = "d";
            this.dateControl3.EditLabel = "登记日期:";
            this.dateControl3.EditMask = "d";
            this.dateControl3.Location = new System.Drawing.Point(72, 28);
            this.dateControl3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateControl3.Name = "dateControl3";
            this.dateControl3.Request = false;
            this.dateControl3.Size = new System.Drawing.Size(284, 26);
            this.dateControl3.TabIndex = 6;
            // 
            // dateControl4
            // 
            this.dateControl4.BackColor = System.Drawing.Color.Transparent;
            this.dateControl4.DataField = "F_NewEnd";
            this.dateControl4.DataSource = null;
            this.dateControl4.DisplayFormat = "g";
            this.dateControl4.EditLabel = "现休息结束时间:";
            this.dateControl4.EditMask = "g";
            this.dateControl4.Location = new System.Drawing.Point(61, 280);
            this.dateControl4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateControl4.Name = "dateControl4";
            this.dateControl4.Request = false;
            this.dateControl4.Size = new System.Drawing.Size(272, 26);
            this.dateControl4.TabIndex = 8;
            // 
            // dateControl5
            // 
            this.dateControl5.BackColor = System.Drawing.Color.Transparent;
            this.dateControl5.DataField = "F_NewBegin";
            this.dateControl5.DataSource = null;
            this.dateControl5.DisplayFormat = "g";
            this.dateControl5.EditLabel = "现休息开始时间:";
            this.dateControl5.EditMask = "g";
            this.dateControl5.Location = new System.Drawing.Point(61, 246);
            this.dateControl5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateControl5.Name = "dateControl5";
            this.dateControl5.Request = false;
            this.dateControl5.Size = new System.Drawing.Size(272, 26);
            this.dateControl5.TabIndex = 7;
            // 
            // cbControl1
            // 
            this.cbControl1.BackColor = System.Drawing.Color.Transparent;
            comboBoxItem1.Value = "节假日";
            comboBoxItem2.Value = "周休日";
            this.cbControl1.cbItem = new DevExpress.XtraEditors.Controls.ComboBoxItem[] {
        comboBoxItem1,
        comboBoxItem2};
            this.cbControl1.DataField = "F_Type";
            this.cbControl1.DataSource = null;
            this.cbControl1.EditLabel = "调休后休息类型:";
            this.cbControl1.EditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbControl1.Location = new System.Drawing.Point(61, 115);
            this.cbControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbControl1.Name = "cbControl1";
            this.cbControl1.Request = false;
            this.cbControl1.SelectedIndex = -1;
            this.cbControl1.Size = new System.Drawing.Size(272, 26);
            this.cbControl1.TabIndex = 9;
            // 
            // frmEditOtherRest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(644, 409);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmEditOtherRest";
            this.Text = "调休补班登记";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.lupControl lupControl1;
        private myControl.DateControl dateControl2;
        private myControl.DateControl dateControl1;
        private myControl.DateControl dateControl3;
        private myControl.DateControl dateControl4;
        private myControl.DateControl dateControl5;
        private myControl.cbControl cbControl1;

    }
}
