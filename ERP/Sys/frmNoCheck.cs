using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmNoCheck : BaseClass.frmBase
    {
        public DateTime dtValue;
        public frmNoCheck()
        {
            InitializeComponent();
        }

        private void DataBind()
        {
            string strSQL = "sp_noCheck '" + dtValue.ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNoCheck_Shown(object sender, EventArgs e)
        {
            DataBind();
        }

        private void ShowBill()
        {
            if (gvMain.FocusedRowHandle < 0) return;

            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            string strTag = dr["F_Tag"].ToString();
            switch (strTag)
            {
                case "�ɹ�������":           
                    Stock.frmStockIn myStockIn = new Stock.frmStockIn();
                    myStockIn.strBillID = dr["F_BillID"].ToString();
                    myStockIn.ShowDialog();
                    myStockIn.Dispose();
                    break;
                case "�ɹ��˻���":
                    Stock.frmStockBack myStockBack = new Stock.frmStockBack();
                    myStockBack.strBillID = dr["F_BillID"].ToString();
                    myStockBack.ShowDialog();
                    myStockBack.Dispose();
                    break;
                case "���۳��ֵ�":
                    Sell.frmSellOut mySellOut = new Sell.frmSellOut();
                    mySellOut.strBillID = dr["F_BillID"].ToString();
                    mySellOut.ShowDialog();
                    mySellOut.Dispose();
                    break;
                case "�����˻���":
                    Sell.frmSellBack mySellBack = new Sell.frmSellBack();
                    mySellBack.strBillID = dr["F_BillID"].ToString();
                    mySellBack.ShowDialog();
                    mySellBack.Dispose();
                    break;
                case "�̵㵥":
                    Storage.frmCheck myCheck = new Storage.frmCheck();
                    myCheck.strBillID = dr["F_BillID"].ToString();
                    myCheck.ShowDialog();
                    myCheck.Dispose();
                    break;
                case "��װ��":
                    Storage.frmInstall myInstall = new Storage.frmInstall();
                    myInstall.strBillID = dr["F_BillID"].ToString();
                    myInstall.ShowDialog();
                    myInstall.Dispose();
                    break;
                case "���ε�":
                    Storage.frmExchange myExchange = new Storage.frmExchange();
                    myExchange.strBillID = dr["F_BillID"].ToString();
                    myExchange.ShowDialog();
                    myExchange.Dispose();
                    break;
                case "���ϵ�":
                    Product.frmDrawGoods myDrawGoods = new Product.frmDrawGoods();
                    myDrawGoods.strBillID = dr["F_BillID"].ToString();
                    myDrawGoods.ShowDialog();
                    myDrawGoods.Dispose();
                    break;
                case "���ϵ�":
                    Product.frmPatchGoods myPatchGoods = new Product.frmPatchGoods();
                    myPatchGoods.strBillID = dr["F_BillID"].ToString();
                    myPatchGoods.ShowDialog();
                    myPatchGoods.Dispose();
                    break;
                case "���ϵ�":
                    Product.frmBackGoods myBackGoods = new Product.frmBackGoods();
                    myBackGoods.strBillID = dr["F_BillID"].ToString();
                    myBackGoods.ShowDialog();
                    myBackGoods.Dispose();
                    break;
                case "��Ʒ���ֵ�":
                    Product.frmProductIn myProductIn = new Product.frmProductIn();
                    myProductIn.strBillID = dr["F_BillID"].ToString();
                    myProductIn.ShowDialog();
                    myProductIn.Dispose();
                    break;
                case "�������ֵ�":
                    Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                    myOtherIn.strBillID = dr["F_BillID"].ToString();
                    myOtherIn.ShowDialog();
                    myOtherIn.Dispose();
                    break;
                case "�������ֵ�":
                    Storage.frmOtherOut myOtherOut = new Storage.frmOtherOut();
                    myOtherOut.strBillID = dr["F_BillID"].ToString();
                    myOtherOut.ShowDialog();
                    myOtherOut.Dispose();
                    break;
            }
            DataBind();

        }

        private void sbOpen_Click(object sender, EventArgs e)
        {
            ShowBill();
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            ShowBill();
        }
    }
}

