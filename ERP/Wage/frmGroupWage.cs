using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization; 

namespace Wage
{
    public partial class frmGroupWage : BaseClass.frmBase
    {
        public frmGroupWage()
        {
            InitializeComponent();
            //Common.XtraChinese p = new Common.XtraChinese();
            //p.chineseXtraGrid(this.gcList);
        }

        /// <summary>
        /// ȡ����·�
        /// </summary>
        /// <returns></returns>
        private string GetDate()
        {
            string strMonth = "0"+Convert.ToString(cbMonth.SelectedIndex + 1);
            if (strMonth.Length > 2)
                strMonth = strMonth.Substring(1);
            return spYear.Text+strMonth;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPrint_Click(object sender, EventArgs e)
        {
            //PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, this.printingSystem);
        }

        /// <summary>
        /// ��ӡԤ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPreview_Click(object sender, EventArgs e)
        {
            //PreviewLocalizer plZer = new Common.XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, this.printingSystem);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbExport_Click(object sender, EventArgs e)
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel �ļ�", "Excel �ļ�|*.Xls");
            if (strFile != "")
                gvList.ExportToXlsx(strFile);
        }

        /// <summary>
        /// ���ݰ�
        /// </summary>
        private void DataBind()
        {
            string strSQL = "";
            
            strSQL = @"select a.*,b.F_Name,c.F_Name as F_Dept from t_GenGroupWage a 
                       left join t_WorkGroup b on a.F_GroupID = b.F_ID
                       left join (select F_ID,F_Name from t_Class) c 
                       on b.F_DeptID = c.F_ID 
                       where a.F_Month = '" + GetDate()+@"'
                       order by c.F_Name";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            this.gcList.DataSource = ds.Tables[0].DefaultView;
        }


        private void frmWageInput_Load(object sender, EventArgs e)
        {
            spYear.Value = DateTime.Today.Year;
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;
        }

        private void frmMonthWage_Shown(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// ���ɵ��¹���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbGen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"���Ҫ���ɱ��¹�����,�⽫ˢ�µ�ǰ���,����!!","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                string strSQL = "";
                strSQL = "sp_GenGroupWage '" + GetDate() + "'";
                if (myHelper.ExecuteSQL(strSQL) == 0)
                    DataBind();
            }
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

    }
}

