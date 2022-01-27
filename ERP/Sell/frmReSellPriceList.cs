using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmReSellPriceList : Common.frmBillList
    {
        public frmReSellPriceList()
        {
            InitializeComponent();
            btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        /// <summary>
        /// ����
        /// </summary>
        protected override void New()
        {
            Sell.frmReSellPrice myReSellPrice = new Sell.frmReSellPrice();
            myReSellPrice.ShowDialog();
            myReSellPrice.Dispose();
            base.New();
             
        }

        /// <summary>
        /// �༭����
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);

            Sell.frmReSellPrice myReSellPrice = new Sell.frmReSellPrice();
            myReSellPrice.strBillID = dr["F_BillID"].ToString();
            myReSellPrice.ShowDialog();
            myReSellPrice.Dispose();
            base.Edit();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        protected override void Del()
        {
            base.Del();
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "����ɾ������˵ĵ��ݣ���", "��ʾ");
                return;
            }
            if (MessageBox.Show(this, "���Ҫɾ��ѡ��������?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_SellPrice where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

