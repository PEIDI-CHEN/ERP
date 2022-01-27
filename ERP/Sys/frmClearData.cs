using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmClearData : BaseClass.frmBase
    {
        public frmClearData()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetNodeCheck(TreeNode Node)
        {
            //if (Node.Parent != null)
             //   Node.Parent.Checked = true;
        }

        private void SetCheckNodeCheck(TreeNode Node)
        {
            if (Node.Nodes.Count > 0)
            {
                foreach (TreeNode cNode in Node.Nodes)
                {
                    cNode.Checked = Node.Checked;
                }
            }
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            bool bCheck = false;
            foreach(TreeNode Node in tvForm.Nodes)
            {
                if (Node.Checked == true) 
                {
                    bCheck = true;
                    break;
                }

                if (Node.Nodes.Count > 0)
                {
                    foreach (TreeNode cNode in Node.Nodes)
                    {
                        if (cNode.Checked == true)
                        {
                            bCheck = true;
                            break;
                        }

                    }
                }
            }
            if (bCheck == false)
            {
                MessageBox.Show(this, "����Сѡ��һ��!!", "��ʾ");
                return;
            }

            if (MessageBox.Show(this, "��������󽫲��ɻָ������ǰ�����ñ���,��Ľ��б�������?", "ѯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;



            string SQL = "begin tran ";
            lbFlag.Visible = true;
            sbOK.Enabled = false;
            tvForm.Enabled = false;
            sbCancel.Enabled = false;
            this.Update();
            try
            {

                foreach (TreeNode Node in tvForm.Nodes)
                {
                    if (Node.Nodes.Count > 0)
                    {
                        foreach (TreeNode cNode in Node.Nodes)
                        {
                            if (cNode.Checked == true)
                            {
                                if (cNode.Tag != null)
                                {
                                    SQL = SQL + " delete from " + cNode.Tag.ToString();

                                    if (cNode.Text == "�ͻ�����")
                                        SQL = SQL + " delete from t_Class where F_ID like '02.%' ";

                                    if (cNode.Text == "��Ӧ������")
                                        SQL = SQL + " delete from t_Class where F_ID like '01.%' ";

                                    if (cNode.Text == "Ա������")
                                        SQL = SQL + " delete from t_Class where F_ID like '03.%' ";

                                    if (cNode.Text == "��������")
                                        SQL = SQL + " delete from t_Class where F_ID like '04.%' ";

                                    if (cNode.Text == "�ֿ�����")
                                        SQL = SQL + " delete from t_Class where F_ID like '05.%' ";

                                    if (cNode.Text == "��ӹ�����")
                                        SQL = SQL + " delete from t_Class where F_ID like '09.%' ";

                                    if (cNode.Text == "���˹�˾")
                                        SQL = SQL + " delete from t_Class where F_ID like '10.%' ";

                                    if (cNode.Text == "��Ʒ����")
                                        SQL = SQL + " delete from t_Class where F_ID like '11.%' ";
                                }
                            }

                        }
                    }

                    if (Node.Checked == true)
                    {
                        if (Node.Text == "��������")
                            SQL = SQL + @" delete from t_sPosition  delete from t_Grade truncate table t_UserLog 
                                            update t_CompanyInfo set F_Company = 'XXX��˾',
                                             F_CheckDate = '1900-1-1',
                                             F_UseDate = '1900-1-1',
                                             F_Use = 0,
                                             F_cwInit = 0

                                             update t_CashInit set F_CashIni = 0,
                                             F_BankIni = 0,
                                             F_Cash = 0,
                                             F_Bank = 0";

                        if (Node.Text == "���ʹ���")
                            SQL = SQL + " delete from t_WageInput  delete from t_GenWage";

                        if (Node.Text == "�������")
                            SQL = SQL + @" delete from t_Certificate
                                           delete from t_cwCheckOut
                                           update t_CashInit set F_CashIni = 0,F_BankIni = 0,F_Cash = 0,F_Bank = 0
                                           delete from t_CashRest";

                        if (Node.Text == "�̶��ʲ�")
                            SQL = SQL + @"  delete from t_AddType
                                            delete from t_Asset
                                            delete from t_AssetReduce
                                            delete from t_AssetType";
                    }

                }

                if (ckInit.Checked == true)
                    SQL = SQL + @" update t_CompanyInfo set F_Use = 0,F_cwInit = 0";

                SQL = SQL + @" if @@ERROR <> 0
                                   rollback tran
                                else
                                   commit tran";

                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                if (myHelper.ExecuteSQL(SQL) == 0)
                    MessageBox.Show(this, "������������!!", "��ʾ");
            }
            finally
            {
                lbFlag.Visible = false;
                sbOK.Enabled = true;
                sbCancel.Enabled = true;
                tvForm.Enabled = true;
            }
        }

        private void tvForm_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
               SetCheckNodeCheck(e.Node);
            else
               SetNodeCheck(e.Node);
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode Node in tvForm.Nodes)
            {
                Node.Checked = ckAll.Checked;
            }
        }

        private void frmClearData_Load(object sender, EventArgs e)
        {
            tvForm.ExpandAll();
        }
    }
}

