using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmRight : BaseClass.frmBase
    {
        public frmRight()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���ݰ�
        /// </summary>
        private void DataBind()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_UserGroup");
            gcGroup.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// ��Ȩ����ϸ
        /// </summary>
        /// <param name="sGroup"></param>
        private void BindDetail(string sGroup)
        {
            string strSQL = "";
            strSQL = "select b.*,a.F_Name as F_Modal,a.F_PID from t_Right a,t_RightDetail b " +
                     "where a.F_ID = b.F_Class " +
                     "and b.F_Group = '" + sGroup + "' order by a.F_Name";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcRight.DataSource = ds.Tables[0].DefaultView;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEditUGroup myUGroup = new frmEditUGroup();
            myUGroup.strGroup = "";
            if (myUGroup.ShowDialog() == DialogResult.OK)
                DataBind();
            myUGroup.Dispose();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (gvGroup.FocusedRowHandle < 0) return;
            DataRow dr = gvGroup.GetDataRow(gvGroup.FocusedRowHandle);
            if (dr["F_Group"].ToString() == "�����û�")
            {
                MessageBox.Show("����ɾ�������û�");
                return;
            }
            if (MessageBox.Show(this, "ɾ��ѡ���û���,���Ӧ���û�Ҳ����ɾ��,ȷ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_UserGroup where F_Group = '" + dr["F_Group"].ToString() + "'") == 0)
                DataBind();
        }

        private void frmRight_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {            
                DataBind();
                cbType.SelectedIndex = 9;
            }
        }

        private void gvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            DataRow dr = gvGroup.GetDataRow(e.FocusedRowHandle);
            checkBox1.Checked = Convert.ToBoolean(dr["F_View"]);
            checkBox2.Checked = Convert.ToBoolean(dr["F_Export"]);
            if (dr["F_Print"] != DBNull.Value)
               checkBox3.Checked = Convert.ToBoolean(dr["F_Print"]);
            if (dr["F_ModiPrice"] != DBNull.Value)
                checkBox4.Checked = Convert.ToBoolean(dr["F_ModiPrice"]);
            if (dr["F_Group"].ToString() == "�����û�")
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
            BindDetail(dr["F_Group"].ToString());
            Filter();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        private void Filter()
        {
            DataView dv = (DataView)gcRight.DataSource;
            switch (cbType.Text)
            {
                case "ϵͳ����":
                    dv.RowFilter = "F_PID = '0'";
                    break;
                case "��������":
                    dv.RowFilter = "F_PID = '1'";
                    break;
                case "�ɹ�����":
                    dv.RowFilter = "F_PID = '2'";
                    break;
                case "���۹���":
                    dv.RowFilter = "F_PID = '3'";
                    break;
                case "�ֿ����":
                    dv.RowFilter = "F_PID = '4'";
                    break;
                case "��������":
                    dv.RowFilter = "F_PID = '5'";
                    break;
                case "ί��ӹ�":
                    dv.RowFilter = "F_PID = '6'";
                    break;
                case "���ʹ���":
                    dv.RowFilter = "F_PID = '7'";
                    break;
                case "�������":
                    dv.RowFilter = "F_PID = '8'";
                    break;
                case "���ɹ���":
                    dv.RowFilter = "F_PID = '9'";
                    break;
                case "�̶��ʲ�":
                    dv.RowFilter = "F_PID = '10'";
                    break;
                case "ͳ�Ʊ���":
                    dv.RowFilter = "F_PID = '11'";
                    break;
                case "ȫ��":
                    dv.RowFilter = "";
                    break;
            }
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            int intCnt = gvRight.RowCount;

            for(int i = 0;i < intCnt; i++)
            {
                gvRight.SetRowCellValue(i,"F_Enable",ckAll.Checked);
            }
        }

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        /// <returns></returns>
        private bool SaveRight()
        {
            if (gvGroup.FocusedRowHandle < 0) return false;
            DataRow dr = gvGroup.GetDataRow(gvGroup.FocusedRowHandle);
            gvRight.PostEditor();
            gvRight.UpdateCurrentRow();
            DataSet ds = ((DataView)gcRight.DataSource).Table.DataSet;
            
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, "select * from t_RightDetail where F_Group = '"+dr["F_Group"].ToString()+"'") == 0)
            {
                ds.AcceptChanges();
                int intFlag = 0,intFlag1 = 0,intFlag2 = 0,intFlag3 = 0;
                if (checkBox1.Checked == true) intFlag = 1;
                if (checkBox2.Checked == true) intFlag1 = 1;
                if (checkBox3.Checked == true) intFlag2 = 1;
                if (checkBox4.Checked == true) intFlag3 = 1;

                myHelper.ExecuteSQL("update t_UserGroup set F_View = " + intFlag.ToString() + ",F_Export = " + intFlag1.ToString() + ",F_Print = " + intFlag2.ToString() + ",F_ModiPrice = " + intFlag3.ToString()+ " where F_Group = '" + dr["F_Group"].ToString() + "'");
                MessageBox.Show(this, "���ݱ���ɹ�!", "��ʾ");
                DataBind();
                return true;
            }
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRight();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvGroup.FocusedRowHandle < 0) return;
            DataRow dr = gvGroup.GetDataRow(gvGroup.FocusedRowHandle);
            if (dr["F_Group"].ToString() == "�����û�")
            {
                MessageBox.Show("���ܱ༭�����û�");
                return;
            }
            frmEditUGroup myUGroup = new frmEditUGroup();
            myUGroup.strGroup = dr["F_Group"].ToString();
            myUGroup.textEdit1.Text = dr["F_Group"].ToString();
            bool bFlag = false;
            if (dr["F_Salesman"] != DBNull.Value) bFlag = Convert.ToBoolean(dr["F_Salesman"]);
            myUGroup.checkEdit1.Checked = bFlag;
            if (myUGroup.ShowDialog() == DialogResult.OK)
                DataBind();
            myUGroup.Dispose();
        }
    }
}

