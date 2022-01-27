using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Localization;
using Common; 

namespace Wage
{
    public partial class frmGiffWage : BaseClass.frmBase
    {
        public frmGiffWage()
        {
            InitializeComponent();
            //Common.XtraChinese p = new Common.XtraChinese();
            //p.chineseXtraGrid(this.gcList);
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// �������ݰ�
        /// </summary>
        private void SetDropSource()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Class where F_ID like '03.%'");
            lupDept.DataSource = ds.Tables[0].DefaultView;
            lupDept.DisplayMember = "F_Name";
            lupDept.ValueMember = "F_ID";
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
            myClass.DoPrint(this.Text,this.printingSystem);
        }

        /// <summary>
        /// Ԥ��
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
        /// ȡ������·�
        /// </summary>
        /// <returns></returns>
        private string GetDate()
        {
            string strMonth = "0"+Convert.ToString(cbMonth.SelectedIndex + 1);
            if (strMonth.Length > 2)
                strMonth = strMonth.Substring(1);
            return spYear.Text+strMonth;
        }

        /// <summary>
        /// ���ݰ�
        /// </summary>
        private void DataBind()///////����
        {
            string strSQL = "";
            strSQL = "sp_GiffWage '"+GetDate()+"'";//�洢������д

            /*strSQL = @"select a.*,b.F_Name,b.F_Type,c.F_Name as F_TypeName from t_GenWage a
                       left join t_Emp b 
                       on a.F_EmpID = b.F_ID 
                       left join t_Class c
                       on b.F_Type = c.F_ID
                       where a.F_Month = '" + GetDate() + @"'
                       order by b.F_Type,a.F_EmpID";*/

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds == null) return; 
            this.gcList.DataSource = ds.Tables[0].DefaultView;
        }

        private void frmWageInput_Load(object sender, EventArgs e)
        {
            spYear.Value = DateTime.Today.Year;
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// ���ÿɼ�������
        /// </summary>
        /*/ private void SetVisibleColumn()
         {
             DataLib.DataHelper myHelper = new DataLib.DataHelper();
             DataSet ds = myHelper.GetDs("select * from t_WageItem");   
             foreach(DataRow dr in ds.Tables[0].Rows)
             {
                 GridColumn gc = this.gvList.Columns.ColumnByFieldName(dr["F_HideItem"].ToString());
                 gc.Visible = Convert.ToBoolean(dr["F_Visible"]);
                 gc.Caption = dr["F_WageItem"].ToString();
                 gc.Width = 52;
             }
         }*/

        private void SetVisibleColumn()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_WageItem");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GridColumn gc = this.gvList.Columns.ColumnByFieldName(dr["F_HideItem"].ToString());
                if (dr["F_Formula"].ToString() != "" || Convert.ToBoolean(dr["F_Visible"]) == true)//false
                    gc.Visible = true;//false
                else
                    gc.Visible = false;//true

                gc.Caption = dr["F_WageItem"].ToString();
                gc.Width = 52;
            }
        }

        private void frmGiffWage_Shown(object sender, EventArgs e)
        {
            DataBind();
            SetVisibleColumn();
            DataLib.sysClass.LoadFormatFromDB(gvList, this.Name, 0);
            SetDropSource();
           
        }

        private void gcList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "�����û�")
            {
                frmSetGrid myGrid = new frmSetGrid();
                myGrid.gvSource = gvList;
                myGrid.ShowDialog();
                myGrid.Dispose();
            }

            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "�����û�")
            {
                DataLib.sysClass.SaveGridToDB(gvList, this.Name, 0);
            }
        }

    }
}

