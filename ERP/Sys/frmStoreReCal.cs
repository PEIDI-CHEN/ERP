using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmStoreReCal : BaseClass.frmBase
    {
        public frmStoreReCal()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            dtMonth.EditValue = DateTime.Today;
        }

        /// <summary>
        /// ��������������,��Ҫִ�д洢����sp_AdjustStorage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbOK_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            DateTime dtValue = Convert.ToDateTime(dtMonth.EditValue);
            string strYear = dtValue.Year.ToString();
            string strMonth = dtValue.Month.ToString().PadLeft(2, '0');
            string strValue = strYear + strMonth;

            strSQL = "select top 1 * from t_StorageCheck where F_Month = '" + strValue + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("�����ѽ����,���ܽ�������!!");
                return;
            }
            ds.Dispose();

            if (MessageBox.Show(this, "���Ҫ���п��������,����ʱ��ȡ��������������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            dtMonth.Enabled = false;
            sbOK.Enabled = false;
            lbFlag.Visible = true;
            this.Update();
            try
            {
                strSQL = "exec sp_AdjustStorage '" + dtMonth.EditValue.ToString() + "'";
                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    MessageBox.Show("�����������ɹ�!!");
                }
            }
            finally
            {
                dtMonth.Enabled = true;
                sbOK.Enabled = true;
                lbFlag.Visible = false;
            }
        }
    }
}

