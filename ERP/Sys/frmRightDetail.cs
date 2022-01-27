using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmRightDetail : BaseClass.frmBase
    {
        public frmRightDetail()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                BindBigModule();
                BindUser();
            }
        }

        /// <summary>
        /// ��ģ�����ݰ�
        /// </summary>
        private void BindBigModule()
        {
            string strSQL = "select F_ID,F_Name from t_Right where F_PID = ''";
            DataLib.DataHelper myHelp = new DataLib.DataHelper();
            DataSet ds = myHelp.GetDs(strSQL);
            lookUpEdit1.Properties.DataSource = ds.Tables[0].DefaultView;
            lookUpEdit1.Properties.ValueMember = "F_ID";
            lookUpEdit1.Properties.DisplayMember = "F_Name";

        }

        /// <summary>
        /// ���ݴ�ģ��ȡ��ӦСģ��
        /// </summary>
        /// <param name="strBigID"></param>
        private void BindModule(string strBigID)
        {
            string strSQL = "select * from t_Right where F_PID = '" + strBigID + "'";
            DataLib.DataHelper myHelp = new DataLib.DataHelper();
            DataSet ds = myHelp.GetDs(strSQL);
            GridModule.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// ���û�
        /// </summary>
        private void BindUser()
        {
            string strSQL = "select F_ID,F_Name,F_Group from t_User";
            DataLib.DataHelper myHelp = new DataLib.DataHelper();
            DataSet ds = myHelp.GetDs(strSQL);
            GridUser.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// ����ϸȨ��
        /// </summary>
        private void BindDetailRight()
        {
            if (gvModule.FocusedRowHandle < 0) return;
            if (gvUser.FocusedRowHandle < 0) return;
            DataRow drModule = gvModule.GetDataRow(gvModule.FocusedRowHandle);
            DataRow drUser = gvUser.GetDataRow(gvUser.FocusedRowHandle);
            string strSQL = "select * from t_DetailRight where F_UID = '" + drUser["F_ID"].ToString() + "' and F_Module = '"+drModule["F_ID"].ToString()+"'";
            DataLib.DataHelper myHelp = new DataLib.DataHelper();
            DataSet ds = myHelp.GetDs(strSQL);
            GridRight.DataSource = ds.Tables[0].DefaultView;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            BindModule(lookUpEdit1.Properties.GetKeyValueByDisplayText(lookUpEdit1.Text).ToString());
        }

        private void gvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindDetailRight();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ������ӦȨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (gvModule.FocusedRowHandle < 0) return;
            DataRow drModule = gvModule.GetDataRow(gvModule.FocusedRowHandle);
            if (gvUser.FocusedRowHandle < 0) return;
            DataRow dr = gvUser.GetDataRow(gvUser.FocusedRowHandle);
            frmEditDetailRight myDetailRight = new frmEditDetailRight();
            myDetailRight.gvGrid = gvUser;
            myDetailRight.strUser = dr["F_ID"].ToString();
            myDetailRight.strModule = drModule["F_ID"].ToString();
            myDetailRight.ShowDialog();
            myDetailRight.Dispose();
            BindDetailRight();
        }

        /// <summary>
        /// �༭��ӦȨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvRight.FocusedRowHandle < 0) return;
            DataRow dr = gvRight.GetDataRow(gvRight.FocusedRowHandle);
            frmEditDetailRight myDetailRight = new frmEditDetailRight();
            myDetailRight.strUser = dr["F_UID"].ToString();
            myDetailRight.strField = dr["F_Field"].ToString();
            myDetailRight.strModule = dr["F_Module"].ToString();
            myDetailRight.Edit(dr["F_FieldZH"].ToString(),dr["F_Field"].ToString());
            myDetailRight.ShowDialog();
            myDetailRight.Dispose();
        }

        /// <summary>
        /// ɾ�������ϸȨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (gvRight.FocusedRowHandle < 0) return;
            DataRow dr = gvRight.GetDataRow(gvRight.FocusedRowHandle);
            if (MessageBox.Show(this, "���ɾ��ѡ���û�Ȩ����?", "ѯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_DetailRight where F_UID = '" + dr["F_UID"].ToString() + "' and F_Field = '" + dr["F_Field"].ToString() + "' and F_Module = '"+dr["F_Module"].ToString()+"'") == 0)
                gvRight.DeleteRow(gvRight.FocusedRowHandle);
        }

        private void gvModule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindDetailRight();
        }

        private void gvRight_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = gvRight.GetDataRow(e.RowHandle);
            if (e.Column.FieldName == "F_Visible")
            {
                int iVisible = 0;
                bool bValue = Convert.ToBoolean(gvRight.GetRowCellValue(e.RowHandle, e.Column));
                if (bValue == true)
                    iVisible = 1;
                else
                    iVisible = 0;
                string strSQL = "update t_DetailRight set F_Visible = " + iVisible.ToString() + " where F_UID = '" + dr["F_UID"].ToString() + "' and F_Module = '"+dr["F_Module"].ToString()+"' and F_Field = '"+dr["F_Field"].ToString()+"'";
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                myHelper.ExecuteSQL(strSQL);
            }
        }
    }
}

