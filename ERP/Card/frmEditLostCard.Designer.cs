namespace Card
{
    partial class frmEditLostCard
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
            this.editControl1 = new myControl.EditControl();
            this.lupEmp = new myControl.lupControl();
            this.editControl2 = new myControl.EditControl();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.editControl2);
            this.gbox.Controls.Add(this.lupEmp);
            this.gbox.Controls.Add(this.editControl1);
            this.gbox.Margin = new System.Windows.Forms.Padding(5);
            this.gbox.Padding = new System.Windows.Forms.Padding(5);
            this.gbox.Size = new System.Drawing.Size(481, 230);
            // 
            // ckCopy
            // 
            this.ckCopy.Location = new System.Drawing.Point(49, 266);
            this.ckCopy.Margin = new System.Windows.Forms.Padding(5);
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Location = new System.Drawing.Point(287, 269);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(5);
            this.BtnOK.Text = "挂失(&L)";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(399, 269);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            // 
            // editControl1
            // 
            this.editControl1.BackColor = System.Drawing.Color.Transparent;
            this.editControl1.DataField = "F_CardNo";
            this.editControl1.DataSource = null;
            this.editControl1.EditLabel = "卡号:";
            this.editControl1.Enabled = false;
            this.editControl1.Location = new System.Drawing.Point(89, 102);
            this.editControl1.Margin = new System.Windows.Forms.Padding(5);
            this.editControl1.Name = "editControl1";
            this.editControl1.Request = false;
            this.editControl1.Size = new System.Drawing.Size(248, 26);
            this.editControl1.TabIndex = 3;
            // 
            // lupEmp
            // 
            this.lupEmp.BackColor = System.Drawing.Color.Transparent;
            this.lupEmp.DataField = "F_ID";
            this.lupEmp.DataSource = null;
            this.lupEmp.DisplayCaption = "";
            this.lupEmp.DropSQL = "";
            this.lupEmp.EditLabel = "员工:";
            this.lupEmp.InvokeClass = "";
            this.lupEmp.LinkFields = null;
            this.lupEmp.Location = new System.Drawing.Point(89, 49);
            this.lupEmp.LookUpDataSource = null;
            this.lupEmp.LookUpDisplayField = null;
            this.lupEmp.LookUpKeyField = null;
            this.lupEmp.Margin = new System.Windows.Forms.Padding(4);
            this.lupEmp.Name = "lupEmp";
            this.lupEmp.PopWidth = 200;
            this.lupEmp.Request = false;
            this.lupEmp.Size = new System.Drawing.Size(272, 28);
            this.lupEmp.TabIndex = 6;
            // 
            // editControl2
            // 
            this.editControl2.BackColor = System.Drawing.Color.Transparent;
            this.editControl2.DataField = "F_Remark";
            this.editControl2.DataSource = null;
            this.editControl2.EditLabel = "备注:";
            this.editControl2.Location = new System.Drawing.Point(89, 166);
            this.editControl2.Margin = new System.Windows.Forms.Padding(5);
            this.editControl2.Name = "editControl2";
            this.editControl2.Request = false;
            this.editControl2.Size = new System.Drawing.Size(337, 26);
            this.editControl2.TabIndex = 7;
            // 
            // frmEditLostCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(515, 316);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmEditLostCard";
            this.Text = "IC卡挂失登记";
            this.gbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCopy.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private myControl.EditControl editControl1;
        private myControl.EditControl editControl2;
        private myControl.lupControl lupEmp;

    }
}
