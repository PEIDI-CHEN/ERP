using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wage
{
    public partial class frmWageItem : BaseClass.frmBase
    {
        public frmWageItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���ݰ�
        /// </summary>
        private void BindData()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_WageItem");
            this.gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmWageItem_Load(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// ��ʽ��༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbFormu_Click(object sender, EventArgs e)
        {
            frmExpress F = new frmExpress();
            F.dtField = ((DataView)gcMain.DataSource).Table;
            DataRow dr = this.gvMain.GetDataRow(gvMain.FocusedRowHandle);
            if (dr["F_Formula"] != DBNull.Value)
                F.meFormula.Text = dr["F_Formula"].ToString();

            if (F.ShowDialog() == DialogResult.OK)
            {
                //dr["F_FormulaText"] = F.meFormula.Text;
                dr["F_Formula"] = F.strExpress;
            }
            F.Dispose();

            //frmFormula myFormula = new frmFormula();
            //for (int i = 0; i < gvMain.RowCount; i++)
            //{
            //    DataRow drItem = gvMain.GetDataRow(i);
            //    myFormula.lbField.Items.Add(drItem["F_WageItem"]);
            //}
            //if (myFormula.ShowDialog() == DialogResult.OK)
            //{
            //    DataRow dr = this.gvMain.GetDataRow(gvMain.FocusedRowHandle);
            //    dr["F_Formula"] = myFormula.meFormula.Text;
            //    gvMain.UpdateCurrentRow();
            //}
            //myFormula.Dispose();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbOK_Click(object sender, EventArgs e)
        {
            gvMain.PostEditor();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = ((DataView)this.gcMain.DataSource).Table.DataSet;
            if (myHelper.SaveData(ds,"select * from t_WageItem") == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}

