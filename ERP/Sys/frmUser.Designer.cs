namespace Sys
{
    partial class frmUser
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
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sbEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbPsw = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.EmbeddedNavigator.Name = "";
            this.gcMain.Location = new System.Drawing.Point(12, 12);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(338, 260);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsCustomization.AllowFilter = false;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "�û�����";
            this.gridColumn1.FieldName = "F_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 71;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "�û�����";
            this.gridColumn2.FieldName = "F_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 81;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "�û���";
            this.gridColumn3.FieldName = "F_Group";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 81;
            // 
            // sbAdd
            // 
            this.sbAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbAdd.Appearance.Options.UseFont = true;
            this.sbAdd.Location = new System.Drawing.Point(374, 12);
            this.sbAdd.Name = "sbAdd";
            this.sbAdd.Size = new System.Drawing.Size(75, 23);
            this.sbAdd.TabIndex = 1;
            this.sbAdd.Text = "����(&N)";
            this.sbAdd.Click += new System.EventHandler(this.sbAdd_Click);
            // 
            // sbEdit
            // 
            this.sbEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbEdit.Appearance.Options.UseFont = true;
            this.sbEdit.Location = new System.Drawing.Point(374, 41);
            this.sbEdit.Name = "sbEdit";
            this.sbEdit.Size = new System.Drawing.Size(75, 23);
            this.sbEdit.TabIndex = 2;
            this.sbEdit.Text = "�༭(&E)";
            this.sbEdit.Click += new System.EventHandler(this.sbEdit_Click);
            // 
            // sbDel
            // 
            this.sbDel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbDel.Appearance.Options.UseFont = true;
            this.sbDel.Location = new System.Drawing.Point(374, 70);
            this.sbDel.Name = "sbDel";
            this.sbDel.Size = new System.Drawing.Size(75, 23);
            this.sbDel.TabIndex = 3;
            this.sbDel.Text = "ɾ��(&D)";
            this.sbDel.Click += new System.EventHandler(this.sbDel_Click);
            // 
            // sbPsw
            // 
            this.sbPsw.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbPsw.Appearance.Options.UseFont = true;
            this.sbPsw.Location = new System.Drawing.Point(374, 140);
            this.sbPsw.Name = "sbPsw";
            this.sbPsw.Size = new System.Drawing.Size(75, 23);
            this.sbPsw.TabIndex = 4;
            this.sbPsw.Text = "����(&P)";
            this.sbPsw.Click += new System.EventHandler(this.sbPsw_Click);
            // 
            // sbClose
            // 
            this.sbClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Location = new System.Drawing.Point(374, 236);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(75, 23);
            this.sbClose.TabIndex = 5;
            this.sbClose.Text = "�ر�(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "״̬";
            this.gridColumn4.FieldName = "F_Flag";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 84;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(474, 283);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbPsw);
            this.Controls.Add(this.sbDel);
            this.Controls.Add(this.sbEdit);
            this.Controls.Add(this.sbAdd);
            this.Controls.Add(this.gcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmUser";
            this.Text = "�û�����";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraEditors.SimpleButton sbAdd;
        private DevExpress.XtraEditors.SimpleButton sbEdit;
        private DevExpress.XtraEditors.SimpleButton sbDel;
        private DevExpress.XtraEditors.SimpleButton sbPsw;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
