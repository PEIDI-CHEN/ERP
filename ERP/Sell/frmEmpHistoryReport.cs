using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sell
{
    public partial class frmEmpHistoryReport : Common.frmReport
    {
        public string strEmpID = "";
        public frmEmpHistoryReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm()
        {

            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@EmpID", strEmpID);
            return parm;
        }
    }
}

