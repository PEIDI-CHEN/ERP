using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JXC
{
    public partial class frmFindBill : BaseClass.frmBase
    {
        private string strTable;
        public frmFindBill()
        {
            InitializeComponent();
        }

        private void FillType(int intIndex)
        {
            cbType.Properties.Items.Clear();
            switch (intIndex)
            {
                case 0:
                    cbType.Properties.Items.Add("�깺��");
                    cbType.Properties.Items.Add("�ɹ�����");
                    cbType.Properties.Items.Add("�ɹ�������");
                    cbType.Properties.Items.Add("�ɹ����");
                    cbType.Properties.Items.Add("�ɹ��˻���");
                    cbType.Properties.Items.Add("ѯ�۵�");
                    cbType.Properties.Items.Add("���۵�");
                    cbType.Properties.Items.Add("�ͻ�����");
                    cbType.Properties.Items.Add("����֪ͨ��");
                    cbType.Properties.Items.Add("������");
                    cbType.Properties.Items.Add("�տ");
                    cbType.Properties.Items.Add("�����˻���");
                    cbType.Properties.Items.Add("�̵㵥");
                    cbType.Properties.Items.Add("���ε�");
                    cbType.Properties.Items.Add("�������ֵ�");
                    cbType.Properties.Items.Add("�������ֵ�");
                    cbType.Properties.Items.Add("��װ��");
                    cbType.Properties.Items.Add("�����ƻ���");
                    cbType.Properties.Items.Add("��������");
                    cbType.Properties.Items.Add("����״����");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("��Ʒ���ֵ�");
                    cbType.Properties.Items.Add("ί��ӹ���");
                    cbType.Properties.Items.Add("ί�����ϵ�");
                    cbType.Properties.Items.Add("ί�����ϵ�");
                    cbType.Properties.Items.Add("ί����ֵ�");
                    cbType.Properties.Items.Add("ί���˻���");
                    cbType.Properties.Items.Add("ί�⸶�");
                    break;
                case 1:
                    cbType.Properties.Items.Add("�깺��");
                    cbType.Properties.Items.Add("�ɹ�����");
                    cbType.Properties.Items.Add("�ɹ�������");
                    cbType.Properties.Items.Add("�ɹ����");
                    cbType.Properties.Items.Add("�ɹ��˻���");
                    break;
                case 2:
                    cbType.Properties.Items.Add("ѯ�۵�");
                    cbType.Properties.Items.Add("���۵�");
                    cbType.Properties.Items.Add("�ͻ�����");
                    cbType.Properties.Items.Add("����֪ͨ��");
                    cbType.Properties.Items.Add("������");
                    cbType.Properties.Items.Add("�տ");
                    cbType.Properties.Items.Add("�����˻���");
                    break;
                case 3:
                    cbType.Properties.Items.Add("�̵㵥");
                    cbType.Properties.Items.Add("���ε�");
                    cbType.Properties.Items.Add("�������ֵ�");
                    cbType.Properties.Items.Add("�������ֵ�");
                    cbType.Properties.Items.Add("��װ��");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("��Ʒ���ֵ�");
                    break;
                case 4:
                    cbType.Properties.Items.Add("�����ƻ���");
                    cbType.Properties.Items.Add("��������");
                    cbType.Properties.Items.Add("����״����");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("���ϵ�");
                    cbType.Properties.Items.Add("��Ʒ���ֵ�");
                    break;
                case 5:
                    cbType.Properties.Items.Add("ί��ӹ���");
                    cbType.Properties.Items.Add("ί�����ϵ�");
                    cbType.Properties.Items.Add("ί�����ϵ�");
                    cbType.Properties.Items.Add("ί����ֵ�");
                    cbType.Properties.Items.Add("ί���˻���");
                    cbType.Properties.Items.Add("ί�⸶�");
                    break;
            }
            cbType.SelectedIndex = 0;
        }

        private void frmFindBill_Load(object sender, EventArgs e)
        {
            FillType(0);
            BindCon();
        }

        private void BindCon()
        {
            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "F_ConText";
            dc.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "F_Con";
            dc1.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(dc1);

            gcCon.DataSource = dt.DefaultView;
        }

        private void GetField(string strClass)
        {
            string strSQL = "select F_Field,F_Caption,F_FieldType from t_ReportField where F_Class = '" + strClass + "' and F_Visible = 1 and F_Tag = 0 order by F_Order";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcField.DataSource = ds.Tables[0].DefaultView;
        }

        private void rgOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillType(rgOption.SelectedIndex);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strType = "";
            switch (cbType.Text)
            {
                case "�깺��":
                    strType = "frmApplyStockList";
                    strTable = "t_ApplyStock";
                    break;
                case "�ɹ�����":
                    strType = "frmStockOrderList";
                    strTable = "t_StockOrder";
                    break;
                case "�ɹ�������":
                    strType = "frmStockInList";
                    strTable = "t_StockIn";
                    break;
                case "�ɹ����":
                    strType = "frmStockPayList";
                    strTable = "t_Pay";
                    break;
                case "�ɹ��˻���":
                    strType = "frmStockBackList";
                    strTable = "t_StockBack";
                    break;
                case "ѯ�۵�":
                    strType = "frmAskPriceList";
                    strTable = "t_AskPrice";
                    break;
                case "���۵�":
                    strType = "frmSellPriceList";
                    strTable = "t_SellPrice";
                    break;
                case "�ͻ�����":
                    strType = "frmSellOrderList";
                    strTable = "t_SellOrder";
                    break;
                case "����֪ͨ��":
                    strType = "frmSellPreList";
                    strTable = "t_SellPre";
                    break;
                case "������":
                    strType = "frmSellOutList";
                    strTable = "t_SellOut";
                    break;
                case "�տ":
                    strType = "frmSellAcceptList";
                    strTable = "t_Accept";
                    break;
                case "�����˻���":
                    strType = "frmSellBackList";
                    strTable = "t_SellBack";
                    break;
                case "�̵㵥":
                    strType = "frmCheckList";
                    strTable = "t_Check";
                    break;
                case "���ε�":
                    strType = "frmExchangeList";
                    strTable = "t_Exchange";
                    break;
                case "�������ֵ�":
                    strType = "frmOtherInList";
                    strTable = "t_Other";
                    break;
                case "�������ֵ�":
                    strType = "frmOtherOutList";
                    strTable = "t_Other";
                    break;
                case "��װ��":
                    strType = "frmInStallList";
                    strTable = "t_InStall";
                    break;
                case "�����ƻ���":
                    strType = "frmProductPlanList";
                    strTable = "t_ProductPlan";
                    break;
                case "��������":
                    strType = "frmTaskList";
                    strTable = "t_Task";
                    break;
                case "����״����":
                    strType = "frmProductStatusList";
                    strTable = "t_ProductStatus";
                    break;
                case "���ϵ�":
                    strType = "frmDrawGoodsList";
                    strTable = "t_DrawGoods";
                    break;
                case "���ϵ�":
                    strType = "frmPatchGoodsList";
                    strTable = "t_PatchGoods";
                    break;
                case "���ϵ�":
                    strType = "frmBackGoodsList";
                    strTable = "t_BackGoods";
                    break;
                case "��Ʒ���ֵ�":
                    strType = "frmProductInList";
                    strTable = "t_ProductIn";
                    break;
                case "ί��ӹ���":
                    strType = "frmOutBillList";
                    strTable = "t_OutBill";
                    break;
                case "ί�����ϵ�":
                    strType = "frmOutDrawGoodsList";
                    strTable = "t_OutDrawGoods";
                    break;
                case "ί�����ϵ�":
                    strType = "frmOutBackGoodsList";
                    strTable = "t_OutBackGoods";
                    break;
                case "ί����ֵ�":
                    strType = "frmOutInStoreList";
                    strTable = "t_OutInStore";
                    break;
                case "ί���˻���":
                    strType = "frmOutBackStoreList";
                    strTable = "t_OutBackStore";
                    break;
                case "ί�⸶�":
                    strType = "frmOutPayList";
                    strTable = "t_OutPay";
                    break;
            }

            GetField(strType);
            if (gcCon.DataSource != null)
               ((DataView)gcCon.DataSource).Table.Clear();

            if (gcMain.DataSource != null)
               ((DataView)gcMain.DataSource).Table.Clear();
        }

        private void gvField_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string strFieldType = "System.String";
            DataRow dr = gvField.GetDataRow(e.FocusedRowHandle);
            lbField.Text = dr["F_Caption"].ToString();
            if (dr["F_FieldType"] != DBNull.Value)
                strFieldType = dr["F_FieldType"].ToString();

            cbEqule.Properties.Items.Clear();

            switch (strFieldType)
            {
                case "System.String":
                    cbEqule.Properties.Items.Add("����");
                    cbEqule.Properties.Items.Add("����");
                    cbEqule.Properties.Items.Add("������");
                    txtValue.Text = "";
                    TabControl.SelectedTabPageIndex = 0;
                    break;
                case "System.Boolean":
                    cbEqule.Properties.Items.Add("����");
                    TabControl.SelectedTabPageIndex = 3;
                    break;
                case "System.DateTime":
                    cbEqule.Properties.Items.Add("����");
                    cbEqule.Properties.Items.Add("����");
                    cbEqule.Properties.Items.Add("���ڵ���");
                    cbEqule.Properties.Items.Add("С��");
                    cbEqule.Properties.Items.Add("С�ڵ���");
                    TabControl.SelectedTabPageIndex = 2;
                    dtValue.EditValue = DBNull.Value;
                    break;
                case "System.Decimal":
                    cbEqule.Properties.Items.Add("����");
                    cbEqule.Properties.Items.Add("����");
                    cbEqule.Properties.Items.Add("���ڵ���");
                    cbEqule.Properties.Items.Add("С��");
                    cbEqule.Properties.Items.Add("С�ڵ���");
                    spValue.Value = 0;
                    TabControl.SelectedTabPageIndex = 1;
                    break;
            }

        }

        private void sbReset_Click(object sender, EventArgs e)
        {
            ((DataView)gvCon.DataSource).Table.Clear();
        }

        private string GetEqual(string strFlag)
        {
            string strEqual = "=";
            switch (strFlag)
            {
                case "����":
                    strEqual = " = ";
                    break;
                case "������":
                    strEqual = " <> ";
                    break;
                case "����":
                    strEqual = " > ";
                    break;
                case "���ڵ���":
                    strEqual = " >= ";
                    break;
                case "С��":
                    strEqual = " < ";
                    break;
                case "С�ڵ���":
                    strEqual = " <= ";
                    break;
                case "����":
                    strEqual = " like ";
                    break;
                case "������":
                    strEqual = " not like ";
                    break;
            }
            return strEqual;
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            string strText = "";
            string strValue = "";
            string sField = "";
            DataRow dr = gvField.GetDataRow(gvField.FocusedRowHandle);
            DataTable dt = ((DataView)gvCon.DataSource).Table;
            DataRow drNew = dt.NewRow();

            if (dr["F_Field"].ToString() == "F_ClientName" || dr["F_Field"].ToString() == "F_DeptName" || 
                dr["F_Field"].ToString() == "F_SupplierName" || dr["F_Field"].ToString() == "F_OutStorageName"||
                dr["F_Field"].ToString() == "F_InStorageName")
                sField = "b.F_Name";
            else
                sField = "a." + dr["F_Field"].ToString();

            switch(TabControl.SelectedTabPageIndex)
            {
                case 0:
                    strText = dr["F_Caption"].ToString() + cbEqule.Text + txtValue.Text;
                    if (GetEqual(cbEqule.Text) == " like " || GetEqual(cbEqule.Text) == " not like ")
                        strValue = sField + GetEqual(cbEqule.Text) + "'%" + txtValue.Text + "%'";
                    else
                        strValue = sField + GetEqual(cbEqule.Text) + "'" + txtValue.Text + "'";
                    break;
                case 1:
                    strText = dr["F_Caption"].ToString() + cbEqule.Text + spValue.Value.ToString();
                    strValue = sField + GetEqual(cbEqule.Text) + spValue.Value.ToString();
                    break;
                case 2:
                    strText = dr["F_Caption"].ToString() + cbEqule.Text + dtValue.EditValue.ToString();
                    strValue = sField + GetEqual(cbEqule.Text) + "'" + dtValue.EditValue.ToString() + "'";
                    break;
                case 3:
                    strText = dr["F_Caption"].ToString() + cbEqule.Text + rgBoon.SelectedIndex.ToString();
                    strValue = sField + GetEqual(cbEqule.Text) + rgBoon.SelectedIndex.ToString();
                    break;
            }

            drNew["F_ConText"] = strText;
            drNew["F_Con"] = strValue;
            dt.Rows.Add(drNew);
        }

        private void sbFind_Click(object sender, EventArgs e)
        {
            string strCon = "",strSQL = "";
            //if (gvCon.RowCount == 0) return;
            for (int i = 0; i < gvCon.RowCount; i++)
            {
                DataRow dr = gvCon.GetDataRow(i);
                strCon = strCon + dr["F_Con"].ToString() + " and ";                
            }

            if (strCon.Length > 0)
               strCon = strCon.Substring(0,strCon.Length - 5);

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet dsSQL = myHelper.GetDs("select F_SQL from t_FindSQL where F_Table = '" + strTable + "'");

            strSQL = dsSQL.Tables[0].Rows[0]["F_SQL"].ToString();

            if (strCon.Length > 0)
               strSQL = strSQL + " where " + strCon;

            DataSet ds = myHelper.GetDs(strSQL);
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void ShowBill()
        {
            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            switch (strTable)
            {
                case "t_ApplyStock":       
                    Stock.frmApplyStock myApplyStock = new Stock.frmApplyStock();
                    myApplyStock.strBillID = dr["F_BillID"].ToString();
                    myApplyStock.ShowDialog();
                    myApplyStock.Dispose();
                    break;
                case "t_StockOrder":
                    Stock.frmStockOrder myStockOrder = new Stock.frmStockOrder();
                    myStockOrder.strBillID = dr["F_BillID"].ToString();
                    myStockOrder.ShowDialog();
                    myStockOrder.Dispose();
                    break;
                case "t_StockIn":
                    Stock.frmStockIn myStockIn = new Stock.frmStockIn();
                    myStockIn.strBillID = dr["F_BillID"].ToString();
                    myStockIn.ShowDialog();
                    myStockIn.Dispose();
                    break;
                case "t_Pay":
                    Stock.frmStockPay myStockPay = new Stock.frmStockPay();
                    myStockPay.strBillID = dr["F_BillID"].ToString();
                    myStockPay.ShowDialog();
                    myStockPay.Dispose();
                    break;
                case "t_StockBack":
                    Stock.frmStockBack myStockBack = new Stock.frmStockBack();
                    myStockBack.strBillID = dr["F_BillID"].ToString();
                    myStockBack.ShowDialog();
                    myStockBack.Dispose();
                    break;
                case "t_AskPrice":
                    Sell.frmAskPrice myAskPrice = new Sell.frmAskPrice();
                    myAskPrice.strBillID = dr["F_BillID"].ToString();
                    myAskPrice.ShowDialog();
                    myAskPrice.Dispose();
                    break;
                case "t_SellPrice":
                    Sell.frmSellPrice mySellPrice = new Sell.frmSellPrice();
                    mySellPrice.strBillID = dr["F_BillID"].ToString();
                    mySellPrice.ShowDialog();
                    mySellPrice.Dispose();
                    break;
                case "t_SellOrder":
                    Sell.frmSellOrder mySellOrder = new Sell.frmSellOrder();
                    mySellOrder.strBillID = dr["F_BillID"].ToString();
                    mySellOrder.ShowDialog();
                    mySellOrder.Dispose();
                    break;
                case "t_SellPre":
                    Sell.frmSellPre mySellPre = new Sell.frmSellPre();
                    mySellPre.strBillID = dr["F_BillID"].ToString();
                    mySellPre.ShowDialog();
                    mySellPre.Dispose();
                    break;
                case "t_SellOut":
                    Sell.frmSellOut mySellOut = new Sell.frmSellOut();
                    mySellOut.strBillID = dr["F_BillID"].ToString();
                    mySellOut.ShowDialog();
                    mySellOut.Dispose();
                    break;
                case "t_Accept":
                    Sell.frmSellAccept mySellAccept = new Sell.frmSellAccept();
                    mySellAccept.strBillID = dr["F_BillID"].ToString();
                    mySellAccept.ShowDialog();
                    mySellAccept.Dispose();
                    break;
                case "t_SellBack":
                    Sell.frmSellBack mySellBack = new Sell.frmSellBack();
                    mySellBack.strBillID = dr["F_BillID"].ToString();
                    mySellBack.ShowDialog();
                    mySellBack.Dispose();
                    break;
                case "t_Check":
                    Storage.frmCheck myCheck = new Storage.frmCheck();
                    myCheck.strBillID = dr["F_BillID"].ToString();
                    myCheck.ShowDialog();
                    myCheck.Dispose();
                    break;
                case "t_Exchange":
                    Storage.frmExchange myExchange = new Storage.frmExchange();
                    myExchange.strBillID = dr["F_BillID"].ToString();
                    myExchange.ShowDialog();
                    myExchange.Dispose();
                    break;
                case "t_InStall":
                    Storage.frmInstall myInstall = new Storage.frmInstall();
                    myInstall.strBillID = dr["F_BillID"].ToString();
                    myInstall.ShowDialog();
                    myInstall.Dispose();
                    break;
                case "t_Other":
                    Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                    myOtherIn.strBillID = dr["F_BillID"].ToString();
                    myOtherIn.ShowDialog();
                    myOtherIn.Dispose();
                    break;
                case "t_Task":
                    Product.frmTask myTask = new Product.frmTask();
                    myTask.strBillID = dr["F_BillID"].ToString();
                    myTask.ShowDialog();
                    myTask.Dispose();
                    break;
                case "t_ProductPlan":
                    Product.frmProductPlan myProductPlan = new Product.frmProductPlan();
                    myProductPlan.strBillID = dr["F_BillID"].ToString();
                    myProductPlan.ShowDialog();
                    myProductPlan.Dispose();
                    break;
                case "t_ProductStatus":
                    Product.frmProductStatus myProductStatus = new Product.frmProductStatus();
                    myProductStatus.strBillID = dr["F_BillID"].ToString();
                    myProductStatus.ShowDialog();
                    myProductStatus.Dispose();
                    break;
                case "t_DrawGoods":
                    Product.frmDrawGoods myDrawGoods = new Product.frmDrawGoods();
                    myDrawGoods.strBillID = dr["F_BillID"].ToString();
                    myDrawGoods.ShowDialog();
                    myDrawGoods.Dispose();
                    break;
                case "t_BackGoods":
                    Product.frmBackGoods myBackGoods = new Product.frmBackGoods();
                    myBackGoods.strBillID = dr["F_BillID"].ToString();
                    myBackGoods.ShowDialog();
                    myBackGoods.Dispose();
                    break;
                case "t_PatchGoods":
                    Product.frmPatchGoods myPatchGoods = new Product.frmPatchGoods();
                    myPatchGoods.strBillID = dr["F_BillID"].ToString();
                    myPatchGoods.ShowDialog();
                    myPatchGoods.Dispose();
                    break;
                case "t_ProductIn":
                    Product.frmProductIn myProductIn = new Product.frmProductIn();
                    myProductIn.strBillID = dr["F_BillID"].ToString();
                    myProductIn.ShowDialog();
                    myProductIn.Dispose();
                    break;
                case "t_OutBill":
                    OutProduct.frmOutBill myOutBill = new OutProduct.frmOutBill();
                    myOutBill.strBillID = dr["F_BillID"].ToString();
                    myOutBill.ShowDialog();
                    myOutBill.Dispose();
                    break;
                case "t_OutDrawGoods":
                    OutProduct.frmOutDrawGoods myOutDrawGoods = new OutProduct.frmOutDrawGoods();
                    myOutDrawGoods.strBillID = dr["F_BillID"].ToString();
                    myOutDrawGoods.ShowDialog();
                    myOutDrawGoods.Dispose();
                    break;
                case "t_OutBackGoods":
                    OutProduct.frmOutBackGoods myOutBackGoods = new OutProduct.frmOutBackGoods();
                    myOutBackGoods.strBillID = dr["F_BillID"].ToString();
                    myOutBackGoods.ShowDialog();
                    myOutBackGoods.Dispose();
                    break;
                case "t_OutInStore":
                    OutProduct.frmOutInStore myOutInStore = new OutProduct.frmOutInStore();
                    myOutInStore.strBillID = dr["F_BillID"].ToString();
                    myOutInStore.ShowDialog();
                    myOutInStore.Dispose();
                    break;
                case "t_OutBackStore":
                    OutProduct.frmOutBackStore myOutBackStore = new OutProduct.frmOutBackStore();
                    myOutBackStore.strBillID = dr["F_BillID"].ToString();
                    myOutBackStore.ShowDialog();
                    myOutBackStore.Dispose();
                    break;
                case "t_OutPay":
                    OutProduct.frmOutPay myOutPay = new OutProduct.frmOutPay();
                    myOutPay.strBillID = dr["F_BillID"].ToString();
                    myOutPay.ShowDialog();
                    myOutPay.Dispose();
                    break;
            }
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0) return;
            ShowBill();
        }
    }
}

