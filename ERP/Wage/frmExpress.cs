using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Wage
{
    public partial class frmExpress : BaseClass.frmBase
    {
        public DataTable dtField = null;
        public string strExpress = "";

        public frmExpress()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOk_Click(object sender, EventArgs e)
        {
            if (meFormula.Text != "")
                strExpress = Explained();
            else
                strExpress = "";
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            this.meFormula.Text =  this.meFormula.Text + (sender as SimpleButton).Text;
        }

        private void FillField()
        {
            foreach (DataRow dr in dtField.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                TreeNode Node = new TreeNode();
                Node.Text = dr["F_WageItem"].ToString();
                Node.Tag = dr["F_HideItem"].ToString();
                tvField.Nodes.Add(Node);
            }
        }

        private string Explained()
        {
            string sExp = this.meFormula.Text;

            foreach (TreeNode Node in tvField.Nodes)
            {
                if (sExp.IndexOf(Node.Text) >= 0)
                {
                    sExp = sExp.Replace(Node.Text, Node.Tag.ToString());
                }
            }

            if (sExp.IndexOf("�����") >= 0)
            {
                sExp = sExp.Replace("�����", "end");
            }

            if (sExp.IndexOf("���") >= 0)
            {
                sExp = sExp.Replace("���", "case when");
            }

            if (sExp.IndexOf("��") >= 0)
            {
                sExp = sExp.Replace("��", "then");
            }

            if (sExp.IndexOf("����") >= 0)
            {
                sExp = sExp.Replace("����", "else");
            }

            if (sExp.IndexOf("��ֵ��") >= 0)
            {
                sExp = sExp.Replace("��ֵ��", ")");
            }

            if (sExp.IndexOf("��ֵ") >= 0)
            {
                sExp = sExp.Replace("��ֵ", "isnull(");
            }

            if (sExp.IndexOf("��") >= 0)
            {
                sExp = sExp.Replace("��", ",");
            }

            if (sExp.IndexOf("��") >= 0)
            {
                sExp = sExp.Replace("��", "and");
            }

            if (sExp.IndexOf("��") >= 0)
            {
                sExp = sExp.Replace("��", "or");
            }

            if (sExp.IndexOf("��") >= 0)
            {
                sExp = sExp.Replace("��", "not");
            }

            return sExp;
        }

        private void frmExpress_Load(object sender, EventArgs e)
        {
            FillField();
        }


        private void tvField_DoubleClick(object sender, EventArgs e)
        {
            if (tvField.SelectedNode == null) return;
            Clipboard.SetText(tvField.SelectedNode.Text);
            this.meFormula.Paste();
            Clipboard.Clear();
        }

    }
}

