using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wage
{
    public partial class frmWageCheckOut : BaseClass.frmBase
    {
        public frmWageCheckOut()
        {
            InitializeComponent();
        }

        private void frmWageCheckOut_Load(object sender, EventArgs e)
        {
            dtMonth.EditValue = DateTime.Today;
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// ������״�����ת���Ƽ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbChange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "���Ҫ��ת���·ݹ�����?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DateTime dtValue = Convert.ToDateTime(dtMonth.EditValue);
            string strYear = dtValue.Year.ToString();
            string strMonth = dtValue.Month.ToString().PadLeft(2, '0');
            string strValue = strYear + strMonth;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("sp_ConvertToWage '" + strValue + "',"+strYear+","+strMonth) == 0)
            {
               MessageBox.Show(this, "��ʱ��ת�ɹ�!!", "��ʾ");
            }    
        }
    }
}

