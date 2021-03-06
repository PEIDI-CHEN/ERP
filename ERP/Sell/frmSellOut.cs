using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmSellOut : Common.frmBill
    {
        public frmSellOut()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N24")) bMultCheck = true;
            lupControl1.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl1.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            lupControl3.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupControl3.LookUpControl.Properties.SortColumnIndex = 2;
            lupControl3.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            btnBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        protected override void LoadBill()
        {
            if (DataLib.SysVar.GetParmValue("F_N44"))
            {
                if (lupControl1.GetValue() == DBNull.Value)
                {
                    MessageBox.Show("请选择客户!!", "提示");
                    lupControl1.Focus();
                    return;
                }
                this.strValue = lupControl1.GetValue().ToString();
            }
            base.LoadBill();
        }

        /// <summary>
        /// 调用记帐凭证
        /// </summary>
        /// <returns></returns>
        protected override bool GenBalance()
        {
            if (base.GenBalance() == false) return false;
            Finance.frmCertificate myCertificate = new Finance.frmCertificate();
            myCertificate.dtDes = ((DataView)binMaster.DataSource).Table;
            myCertificate.DataBind();
            myCertificate.GenCertificate(4);
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            return true;
        }

        /// <summary>
        /// 绑定下拉数据源
        /// </summary>
        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name,dbo.fn_GetPy(F_Name) as F_Spell from t_Client";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_BalanceType";
            ds = myHelper.GetDs(strSQL);
            lupControl4.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl4.LookUpDisplayField = "F_Name";
            lupControl4.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name,dbo.fn_GetPy(F_Name) as F_Spell from t_Emp where isnull(F_Opertor,0) = 1";
            ds = myHelper.GetDs(strSQL);
            lupControl3.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_CarryCompany";
            ds = myHelper.GetDs(strSQL);
            lupControl5.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl5.LookUpDisplayField = "F_Name";
            lupControl5.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        /// <summary>
        /// 重写新增方法
        /// </summary>
        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_AcceptDate"] = DateTime.Today;
            dr["F_Type"] = "销售发货出库";
            binMaster.EndEdit();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {

        }

        protected override void ColumnChanged(object Sender, DataColumnChangeEventArgs e)
        {
            base.ColumnChanged(Sender, e);
            if (e.Column.ColumnName == "F_ItemID")
            {
                if (DataLib.SysVar.GetParmValue("F_N14") == true)
                {
                    SetOnePrice(e.ProposedValue.ToString());
                }
            }
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanged(sender, e);
            if (e.Column.FieldName == "F_ItemID")
            {
                if (DataLib.SysVar.GetParmValue("F_N14") == true)
                {
                    SetOnePrice(e.Value.ToString());
                }
            }
        }



        /// <summary>
        /// 是否一次性出库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool TestOneOut(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["F_LinkBill"] == DBNull.Value) return true;
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select F_OneOut from t_Item where F_ID = '" + dr["F_ItemID"] + "'");
                if (ds.Tables[0].Rows[0][0] == DBNull.Value) return true;
                if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == true)
                {
                    DataSet dsOrder = myHelper.GetDs("select top 1 F_Qty from t_SellOrderDetail where F_BillID = '" + dr["F_LinkBill"].ToString() + "' and Aid = " + dr["PAid"].ToString());
                    if (dsOrder.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(dsOrder.Tables[0].Rows[0][0]) > Convert.ToDecimal(dr["F_Qty"]))
                        {
                            MessageBox.Show(this, "物料[" + dr["F_ItemID"].ToString() + "]设置了一次性出库,出库数量不能小于订单数量,订单数为" + dsOrder.Tables[0].Rows[0][0].ToString(), "提示");
                            return false;
                        }
                        return true;
                    }
                    return true;
                }
                return true;
            }
            return true;

        }

        private void SetOnePrice(string sItemID)
        {
            binMaster.EndEdit();
            if (binMaster.Current == null) return;
            DataRow drMaster = ((DataRowView)binMaster.Current).Row;
            if (binSlaver.Current == null) return;
            DataRow drSlaver = ((DataRowView)binSlaver.Current).Row;
           
            drSlaver.BeginEdit();
            drSlaver["F_Price"] = DataLib.sysClass.GetSellPrice(drMaster["F_ClientID"].ToString(), sItemID);
            drSlaver.EndEdit();
            binSlaver.EndEdit();
        }

        private void SetAllPrice(string sClientID)
        {
            DataTable dt = ((DataView)binSlaver.DataSource).Table;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["F_ItemID"] == DBNull.Value) continue;
                dr.BeginEdit();
                dr["F_Price"] = DataLib.sysClass.GetSellPrice(sClientID, dr["F_ItemID"].ToString());
                dr.EndEdit();
            }
        }

        /// <summary>
        /// 保存前检查
        /// </summary>
        /// <returns></returns>
        protected override bool SavePre()
        {
            if (base.SavePre() == false) return false;

            DataTable dt = ((DataView)binSlaver.DataSource).Table;

            return TestOneOut(dt);
          
        }

        protected override void MasterColumnChanged(object Sender, DataColumnChangeEventArgs e)
        {
            base.MasterColumnChanged(Sender, e);
            if (e.Column.ColumnName == "F_ClientID")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select * from t_Client where F_ID = '" + e.ProposedValue.ToString() + "'");
                e.Row.BeginEdit();
                //e.Row["F_LinkMan"] = ds.Tables[0].Rows[0]["F_LinkMan"].ToString();
                //e.Row["F_LinkTel"] = ds.Tables[0].Rows[0]["F_Tel"].ToString();
                e.Row["F_Opertor"] = ds.Tables[0].Rows[0]["F_Opertor"].ToString();
                e.Row["F_CarryCompany"] = ds.Tables[0].Rows[0]["F_CarryCompany"].ToString();
                e.Row.EndEdit();

                if (DataLib.SysVar.GetParmValue("F_N14") == true)
                {
                    SetAllPrice(e.ProposedValue.ToString());
                }
            }
        }

        private void frmSellOut_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "SF";
            strMTable = "t_SellOut";
            strMasterSQL = "select * from t_SellOut where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_SellOutDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_SellOutDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

