using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;
using Common; 

namespace Wage
{
    public partial class frmWageGroupInput : BaseClass.frmBase
    {
        public frmWageGroupInput()
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
        /// ȡ����Ӧ�·�
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
        /// ��������
        /// </summary>
        private void New()
        {
            frmEditGroupWage myEditGroupWage = new frmEditGroupWage();
            myEditGroupWage.strDate = GetDate();
            myEditGroupWage.New();
            if (myEditGroupWage.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditGroupWage.Dispose();
        }

        /// <summary>
        /// �༭����
        /// </summary>
        private void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditGroupWage myEditGroupWage = new frmEditGroupWage();
            myEditGroupWage.strDate = GetDate();
            myEditGroupWage.Edit(Convert.ToDecimal(dr["Aid"]));
            if (myEditGroupWage.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditGroupWage.Dispose();
        }

        /// <summary>
        /// ɾ����������
        /// </summary>
        private void Del()
        {
            if (gvList.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "���Ҫɾ������¼��?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_WageInput where Aid = " + dr["Aid"].ToString() + " and F_Date = '" + dr["F_Date"].ToString() + "' and F_Flag = 1") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

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
        /// ���ݰ�
        /// </summary>
        private void DataBind()
        {
            int intMonth = cbMonth.SelectedIndex + 1;
            string strMonth = "0" + intMonth.ToString();
            
            if (strMonth.Length == 3) strMonth = strMonth.Substring(1,2);
            
            string strSQL = "";
            strSQL = @"select a.AID,a.F_Date,Convert(varchar(10),a.F_Time,120) as F_Time,a.F_GroupID,b.F_Name as F_GroupName,
                        a.F_ItemID,c.F_Name as F_ItemName,a.F_DeptID,f.F_Name as F_DeptName,a.F_ProcID,
                        g.F_Name as F_ProcName,a.F_Qty,a.F_Price,a.F_Money,a.F_Remark 
                        from t_WageInput a
                        left join t_WorkGroup b
                        on a.F_GroupID = b.F_ID
                        left join t_Item c
                        on a.F_ItemID = c.F_ID
                        left join t_Class f
                        on a.F_DeptID = f.F_ID 
                        left join t_Process g 
                        on a.F_ProcID = g.F_ID 
                        where a.F_Flag = 1 and a.F_Date = '" + spYear.Text + strMonth + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            this.gcList.DataSource = ds.Tables[0].DefaultView;
            DataLib.sysClass.LoadFormatFromDB(gvList, this.Name, 0);
        }

        private void frmWageInput_Load(object sender, EventArgs e)
        {
            spYear.Value = DateTime.Today.Year;
            cbMonth.SelectedIndex = DateTime.Today.Month - 1;
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tbEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void tbDel_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void frmWageInput_Shown(object sender, EventArgs e)
        {
            DataBind();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            Edit();
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

