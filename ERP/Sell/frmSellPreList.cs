using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Sell
{
    public partial class frmSellPreList : Common.frmBillList
    {
        public frmSellPreList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ȡ��ѯ����
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm5()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Check", cbCheck.SelectedIndex);
            parm.Add("@CutOff", cbCutOff.SelectedIndex);
            parm.Add("@Finish", cbFinish.SelectedIndex);
            if (DataLib.SysVar.strUGroup == "�����û�" && DataLib.SysVar.blnSaleMan == false)
                parm.Add("@BillMan", "");
            else
                parm.Add("@BillMan", DataLib.SysVar.strUID);

            return parm;
        }

        /// <summary>
        /// ����
        /// </summary>
        protected override void New()
        {

            Sell.frmSellPre mySellPre = new Sell.frmSellPre();
            mySellPre.ShowDialog();
            mySellPre.Dispose();
            base.New();
              
        }

        /// <summary>
        /// �༭����
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);

            Sell.frmSellPre mySellPre = new Sell.frmSellPre();
            mySellPre.strBillID = dr["F_BillID"].ToString();
            mySellPre.ShowDialog();
            mySellPre.Dispose();
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
            if (myHelper.ExecuteSQL("delete from t_SellPre where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

