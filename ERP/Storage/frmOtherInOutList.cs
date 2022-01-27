using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmOtherInOutList : Common.frmBillList
    {
        public int intTag = 0;
        public string strSelectValue = "��ʼ������";
        public frmOtherInOutList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        protected override Hashtable GetParm3()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Value", strSelectValue);
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Check", cbCheck.SelectedIndex);
            return parm;
        }

        protected override bool TestNew()
        {
            string sTag = "";
            if (intTag == 0)
                sTag = "frmOtherInList";
            else
                sTag = "frmOtherOutList";

            if (TestRight("����", sTag) == false) return false;
            return true;
        }

        protected override bool TestEdit()
        {
            string sTag = "";
            if (intTag == 0)
                sTag = "frmOtherInList";
            else
                sTag = "frmOtherOutList";

            if (TestRight("�༭", sTag) == false) return false;
            return true;
        }

        protected override bool TestDel()
        {
            string sTag = "";
            if (intTag == 0)
                sTag = "frmOtherInList";
            else
                sTag = "frmOtherOutList";


            if (TestRight("ɾ��", sTag) == false) return false;
            return true;
        }

        protected override int BindData()
        {
            if (base.BindData() == 0)
            {
                string sTag = "";
                if (intTag == 0)
                    sTag = "frmOtherInList";
                else
                    sTag = "frmOtherOutList";

                DataLib.SysVar.TestColumnRight(gvList, sTag);
                return 0;
            }
            else
                return -1;
            
        }

        /// <summary>
        /// ����
        /// </summary>
        protected override void New()
        {

            if (intTag == 0)
            {
                Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                myOtherIn.strSelectValue = this.strSelectValue;
                myOtherIn.ShowDialog();
                myOtherIn.Dispose();
            }
            else
            {
                Storage.frmOtherOut myOtherOut = new Storage.frmOtherOut();
                myOtherOut.strSelectValue = this.strSelectValue;
                myOtherOut.ShowDialog();
                myOtherOut.Dispose();
            }
            base.New();
              
        }

        /// <summary>
        /// �༭����
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);

            if (intTag == 0)
            {
                Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                myOtherIn.strBillID = dr["F_BillID"].ToString();
                myOtherIn.strSelectValue = this.strSelectValue;
                myOtherIn.ShowDialog();
                myOtherIn.Dispose();
            }
            else
            {
                Storage.frmOtherOut myOtherOut = new Storage.frmOtherOut();
                myOtherOut.strBillID = dr["F_BillID"].ToString();
                myOtherOut.strSelectValue = this.strSelectValue;
                myOtherOut.ShowDialog();
                myOtherOut.Dispose();
            }
            base.Edit();
             
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        protected override void Del()
        {
            base.Del();
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "����ɾ������˵ĵ��ݣ���", "��ʾ");
                return;
            }
            if (MessageBox.Show(this, "���Ҫɾ��ѡ��������?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Other where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }

        private void frmOtherInOutList_Load(object sender, EventArgs e)
        {
            cbControl1.Location=new Point(527,2);//12��13�ո���
            if (intTag == 0)
            {
                //this.Text = "���������б�";
                this.BillTag = "frmOtherInList";

                cbControl1.EditLabel = "�������";
                cbControl1.AddItem("�ɹ��������");
                cbControl1.AddItem("�����˻����");
                cbControl1.AddItem("�����������");
                cbControl1.AddItem("�����깤���");
                cbControl1.AddItem("ί���������");
                cbControl1.AddItem("ί���깤���");
                cbControl1.AddItem("�������");
            }
            else
            {
                //this.Text = "���������б�";
                this.BillTag = "frmOtherOutList";

                cbControl1.EditLabel = "��������";
                cbControl1.AddItem("�ɹ��˻�����");
                cbControl1.AddItem("���۷�������");
                cbControl1.AddItem("�������ϳ���");
                cbControl1.AddItem("�������ϳ���");
                cbControl1.AddItem("ί�����ϳ���");
                cbControl1.AddItem("ί���˻�����");
                cbControl1.AddItem("���۳���");
                cbControl1.AddItem("ҵ�����");
                cbControl1.AddItem("�����̳���");
                cbControl1.AddItem("��������");
                
            }
            cbControl1.SetValue(strSelectValue);
            this.Text = this.strSelectValue;
        }

        private void cbControl1_SelectIndexChange(object sender, EventArgs e)
        {
            this.strSelectValue = cbControl1.GetValue().ToString();
            BindData();
        }
    }
}

