using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmOtherOut : Common.frmBill
    {
        public string strSelectValue = "��������";

        public frmOtherOut()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N30")) bMultCheck = true;
            strBillText = strSelectValue;
        }

        private void BindSupplier()
        {
            string strSQL = "select F_ID,F_Name from t_Supplier";
            if (strSelectValue == "ί�����ϳ���" || strSelectValue == "ί���˻�����")
                strSQL = "select F_ID,F_Name from t_OutSupplier";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
        }

        private void BindClient()
        {
            string strSQL = "select F_ID,F_Name from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
        }

        private void SetDropSource()
        {
            string strSQL = "";
            strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();

            if (strSelectValue == "���۷�������")
                BindClient();
            else
                BindSupplier();

        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
            if (strSelectValue == "�������ϳ���" || strSelectValue == "�������ϳ���")
            {
                lupControl1.Visible = false;
                lupControl1.Request = false;
            }
            this.Text = strSelectValue;
            //dateControl1.Parent = panel1;
            //dateControl1.Dock = DockStyle.Fill;
        }

        protected override void LoadBill()
        {
            if (DataLib.SysVar.GetParmValue("F_N44"))
            {
                //if (strSelectValue == "���۷�������")
                if (lupControl1.Visible == true)
                {
                    if (lupControl1.GetValue() == DBNull.Value)
                    {
                        MessageBox.Show("��ѡ��" + lupControl1.EditLabel + "!!", "��ʾ");
                        lupControl1.Focus();
                        return;
                    }

                    if (lupControl1.GetValue() != DBNull.Value)
                        this.strValue = lupControl1.GetValue().ToString();
                    else
                        this.strValue = "";

                }
            }
            base.LoadBill();
        }


        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Flag"] = 1;
            dr["F_Type"] = strSelectValue;
            binMaster.EndEdit();
        }

        private void cbControl1_SelectIndexChange(object sender, EventArgs e)
        {
            this.sPrintTag = cbControl1.GetValue().ToString();
            this.Text = this.sPrintTag;
            strSelectValue = this.sPrintTag;
            lupControl1.Request = true;
            if (strSelectValue == "���۷�������" || strSelectValue == "ҵ�����" || strSelectValue == "���۳���" || strSelectValue == "�����̳���")
            {
                BindClient();
                lupControl1.EditLabel = "�ͻ�:";
                //lupControl1.Visible = true;
            }
            else
            {
                BindSupplier();
                lupControl1.EditLabel = "��Ӧ��:";
                //lupControl1.Visible = false;
            }

            if (strSelectValue == "�������ϳ���" || strSelectValue == "�������ϳ���" || strSelectValue == "��������")
            {
                lupControl1.Request = false;
                lupControl1.Visible = false;
            }
            else
            {
                lupControl1.Visible = true;
                lupControl1.Request = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmImportBom myImportBom = new frmImportBom();
            myImportBom.dtBill = ((DataView)binSlaver.DataSource).Table;
            myImportBom.ShowDialog();
            myImportBom.Dispose();
        }

        private void frmOtherOut_Shown(object sender, EventArgs e)
        {
            lbTitle.Text = this.Text;
            strBillFlag = "OO";
            strMTable = "t_Other";
            strMasterSQL = "select * from t_Other where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_OtherDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_OtherDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }
    }
}

