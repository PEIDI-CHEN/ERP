using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEditSupplier : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        public frmEditSupplier()
        {
            InitializeComponent();
            gbox.Parent = this;//////////////
            gbox.Dock = DockStyle.Fill;////////////////
            blnNew = true;
            strNoCopyField = "F_ID";
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Class where left(F_ID,3) = '01.'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Supplier where F_ID = ''";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_ID"] = GetMaxCode("供应商资料", "t_Supplier");
            dr["F_Type"] = strType;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
            base.New();
        }

        public override void Edit(string strID)
        {
            ckOption.Checked = false;
            //this .TopLevel = false;//////////////////////////////jia
            base.Edit(strID);
            strSQL = "select * from t_Supplier where F_ID = '" + strID + "'";
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            SetDropSource();
            base.BindData();
        }

        private void ckOption_CheckedChanged(object sender, EventArgs e)
        {
            blnNew = ckOption.Checked;
        }

        private void frmEditSupplier_Shown(object sender, EventArgs e)
        {
            //12月13日更改代码
            //BtnOK.Focus();
            editControl1.Focus();

        }
        private void frmEditSupplier_Load(object sender, EventArgs e)
        {
            //12月13日更新代码
            //BtnOK.Focus();
            editControl1.Focus();
            //BtnOK.Location = new Point(168, 471);
            //btnCancel.Location = new Point(324, 471);
            BtnOK.Parent = panel1;
            BtnOK.Dock = DockStyle.Fill;
            btnCancel.Parent = panel2;
            btnCancel.Dock = DockStyle.Fill;
            //this.radioButton3.Checked = true;
            /*
            string[] strKind;
            DataLib.sysClass myClass = new DataLib.sysClass();
            strKind = myClass.GetItemKind();

            for (int i = 0; i < strKind.Length; i++)
            {
                cbControl1.AddItem(strKind[i]);
            }
             */
            //12月13日点睛之笔，把控件单独放在panel里面，防止发生错位
            editControl1.Parent = panel3;
            editControl1.Dock = DockStyle.Fill;
            editControl2.Parent = panel4;
            editControl2.Dock = DockStyle.Fill;
            lupControl1.Parent = panel5;
            lupControl1.Dock = DockStyle.Fill;
            editControl3.Parent = panel6;
            editControl3.Dock = DockStyle.Fill;
            editControl4.Parent = panel7;
            editControl4.Dock = DockStyle.Fill;
            editControl11.Parent = panel8;
            editControl11.Dock = DockStyle.Fill;
            editControl12.Parent = panel9;
            editControl12.Dock = DockStyle.Fill;
            editControl6.Parent = panel10;
            editControl6.Dock = DockStyle.Fill;
            editControl5.Parent = panel11;
            editControl5.Dock = DockStyle.Fill;
            editControl13.Parent = panel12;
            editControl13.Dock = DockStyle.Fill;
            editControl10.Parent = panel13;
            editControl10.Dock = DockStyle.Fill;
            editControl7.Parent = panel14;
            editControl7.Dock = DockStyle.Fill;
            editControl8.Parent = panel15;
            editControl8.Dock = DockStyle.Fill;
            editControl16.Parent = panel16;
            editControl16.Dock = DockStyle.Fill;
            editControl9.Parent = panel17;
            editControl9.Dock = DockStyle.Fill;
            editControl15.Parent = panel18;
            editControl15.Dock = DockStyle.Fill;
            editControl14.Parent = panel19;
            editControl14.Dock = DockStyle.Fill;

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }
    }
}

