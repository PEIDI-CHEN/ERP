using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys
{
    public partial class frmDataExport : BaseClass.frmBase
    {
        private string strPath = Application.StartupPath + "\\Data\\";
        public frmDataExport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ѹ������
        /// </summary>
        private void Compress()
        {
            System.Diagnostics.Process ProData = new System.Diagnostics.Process();
            ProData.StartInfo.FileName = "Winrar.exe";
            ProData.StartInfo.CreateNoWindow = true;
            string strFile = '"' + txtFile.Text + '"';
            ProData.StartInfo.Arguments = " m -ep " + strFile + " " + strPath + "*.*";

            ProData.Start();
            if (ProData.HasExited)
            {
                int iExitCode = ProData.ExitCode;
                if (iExitCode != 0)
                {
                    MessageBox.Show("ѹ���ļ����󣬴����:" + iExitCode.ToString(), "����");
                }
            }

        }

        /// <summary>
        /// ���������ӷ���
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strFile"></param>
        private void Export(string strSQL,string strFile)
        {
            DataSet dsTmp = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            dsTmp = myHelper.GetDs(strSQL);
            dsTmp.Tables[0].WriteXml(strPath + strFile + ".xml", XmlWriteMode.WriteSchema);
            dsTmp.Dispose();
        }

        /// <summary>
        /// �ж�ָ�����Ƿ�ѡ��
        /// </summary>
        /// <param name="strItem"></param>
        /// <returns></returns>
        private bool TestItemImport(string strItem)
        {
            return checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(strItem));
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        private void DataExport(DateTime dtStart,DateTime dtEnd)
        {
            string strSQL = "";

            progressBar.Maximum = checkedListBox1.CheckedItems.Count + 1;
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            ckBase.Enabled = false;
            ckOperation.Enabled = false;
            sbExport.Enabled = false;
            sbSelect.Enabled = false;

            if (Directory.Exists(strPath) == true)
            {
                Directory.Delete(strPath, true);
            }

            Directory.CreateDirectory(strPath);
            StreamWriter sw = File.CreateText(strPath + "t_SQL.txt");



            try
            {

                if (TestItemImport("��������") == true) sw.WriteLine("delete from t_Assist");
                if (TestItemImport("��˾��Ϣ") == true) sw.WriteLine("delete from t_CompanyInfo");
                if (TestItemImport("�û�������") == true) sw.WriteLine("delete from t_UserGroup");
                if (TestItemImport("�û�����") == true) sw.WriteLine("delete from t_User");
                if (TestItemImport("Ȩ������") == true)
                {
                    sw.WriteLine("delete from t_Right");
                    sw.WriteLine("delete from t_RightDetail");
                    sw.WriteLine("delete from t_DetailRight");
                }
                if (TestItemImport("��Ӧ������") == true) sw.WriteLine("delete from t_Supplier");
                if (TestItemImport("�ͻ�����") == true) sw.WriteLine("delete from t_Client");
                if (TestItemImport("ְԱ����") == true) sw.WriteLine("delete from t_Emp");
                if (TestItemImport("��������") == true)
                {
                    sw.WriteLine("delete from t_Item");
                    sw.WriteLine("delete from t_Unit");
                }
                if (TestItemImport("�ֿ�����") == true) sw.WriteLine("delete from t_Storage");
                if (TestItemImport("��������") == true) sw.WriteLine("delete from t_Process");
                if (TestItemImport("��������") == true) sw.WriteLine("delete from t_WorkGroup");
                if (TestItemImport("������������") == true) sw.WriteLine("delete from t_Craftwork");
                if (TestItemImport("��Ʒ����滮����") == true) sw.WriteLine("delete from t_ProductProcess");
                if (TestItemImport("BOM����") == true) sw.WriteLine("delete from t_Bom");
                if (TestItemImport("���˹�˾����") == true) sw.WriteLine("delete from t_CarryCompany");
                if (TestItemImport("��ӹ���������") == true) sw.WriteLine("delete from t_OutSupplier");
                if (TestItemImport("ϵͳ�������") == true) sw.WriteLine("delete from t_Class");
                //sw.WriteLine("delete from t_ReportField");
                sw.WriteLine("delete from t_Report");

                if (TestItemImport("��������") == true)
                {
                    lbFlag.Text = "����������������......";
                    lbFlag.Update();
                    strSQL = "select * from t_Assist";
                    Export(strSQL, "t_Assist");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��˾��Ϣ") == true)
                {
                    lbFlag.Text = "����������˾��Ϣ......";
                    lbFlag.Update();
                    strSQL = "select * from t_CompanyInfo";
                    Export(strSQL, "t_CompanyInfo");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�û�������") == true)
                {
                    lbFlag.Text = "���������û�������......";
                    lbFlag.Update();
                    strSQL = "select * from t_UserGroup";
                    Export(strSQL, "t_UserGroup");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�û�����") == true)
                {
                    lbFlag.Text = "���������û�����......";
                    lbFlag.Update();
                    strSQL = "select * from t_User";
                    Export(strSQL, "t_User");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("Ȩ������") == true)
                {
                    lbFlag.Text = "��������Ȩ������......";
                    lbFlag.Update();
                    strSQL = "select * from t_Right";
                    Export(strSQL, "t_Right");

                    strSQL = "select * from t_RightDetail";
                    Export(strSQL, "t_RightDetail");

                    strSQL = "select * from t_DetailRight";
                    Export(strSQL, "t_DetailRight");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��Ӧ������") == true)
                {
                    lbFlag.Text = "����������Ӧ������......";
                    lbFlag.Update();
                    strSQL = "select * from t_Supplier";
                    Export(strSQL, "t_Supplier");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�ͻ�����") == true)
                {
                    lbFlag.Text = "���������ͻ�����......";
                    lbFlag.Update();
                    strSQL = "select * from t_Client";
                    Export(strSQL, "t_Client");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ְԱ����") == true)
                {
                    lbFlag.Text = "��������ְԱ����......";
                    lbFlag.Update();
                    strSQL = "select * from t_Emp";
                    Export(strSQL, "t_Emp");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��������") == true)
                {
                    lbFlag.Text = "����������������......";
                    lbFlag.Update();
                    strSQL = "select * from t_Item";
                    Export(strSQL, "t_Item");

                    strSQL = "select * from t_Unit";
                    Export(strSQL, "t_Unit");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�ֿ�����") == true)
                {
                    lbFlag.Text = "���������ֿ�����......";
                    lbFlag.Update();
                    strSQL = "select * from t_Storage";
                    Export(strSQL, "t_Storage");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��������") == true)
                {
                    lbFlag.Text = "����������������......";
                    lbFlag.Update();
                    strSQL = "select * from t_WorkGroup";
                    Export(strSQL, "t_WorkGroup");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��������") == true)
                {
                    lbFlag.Text = "����������������......";
                    lbFlag.Update();
                    strSQL = "select * from t_Process";
                    Export(strSQL, "t_Process");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("������������") == true)
                {
                    lbFlag.Text = "��������������������......";
                    lbFlag.Update();
                    strSQL = "select * from t_Craftwork";
                    Export(strSQL, "t_Craftwork");

                    strSQL = "select * from t_CraftworkDetail";
                    Export(strSQL, "t_CraftworkDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��Ʒ����滮����") == true)
                {
                    lbFlag.Text = "����������Ʒ����滮����......";
                    lbFlag.Update();
                    strSQL = "select * from t_ProductProcess";
                    Export(strSQL, "t_ProductProcess");

                    strSQL = "select * from t_ProductProcessDetail";
                    Export(strSQL, "t_ProductProcessDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��ӹ���������") == true)
                {
                    lbFlag.Text = "����������ӹ���������......";
                    lbFlag.Update();
                    strSQL = "select * from t_OutSupplier";
                    Export(strSQL, "t_OutSupplier");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("BOM����") == true)
                {
                    lbFlag.Text = "��������BOM����......";
                    lbFlag.Update();
                    strSQL = "select * from t_Bom";
                    Export(strSQL, "t_Bom");

                    strSQL = "select * from t_BomDetail";
                    Export(strSQL, "t_BomDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("���˹�˾����") == true)
                {
                    lbFlag.Text = "�����������˹�˾����......";
                    lbFlag.Update();
                    strSQL = "select * from t_CarryCompany";
                    Export(strSQL, "t_CarryCompany");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ϵͳ�������") == true)
                {
                    lbFlag.Text = "��������ϵͳ�������......";
                    lbFlag.Update();
                    strSQL = "select * from t_Class";
                    Export(strSQL, "t_Class");
                    progressBar.Value = progressBar.Value + 1;
                }


                if (TestItemImport("�깺��") == true) sw.WriteLine("delete from t_ApplyStock where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�ɹ�����") == true) sw.WriteLine("delete from t_StockOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�ɹ�������") == true) sw.WriteLine("delete from t_StockIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�ɹ����") == true) sw.WriteLine("delete from t_Pay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�ɹ��˻���") == true) sw.WriteLine("delete from t_StockBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("ѯ�۵�") == true) sw.WriteLine("delete from t_AskPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("���۵�") == true) sw.WriteLine("delete from t_SellPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�ͻ�����") == true) sw.WriteLine("delete from t_SellOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("����֪ͨ��") == true) sw.WriteLine("delete from t_SellPre where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("������") == true) sw.WriteLine("delete from t_SellOut where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�տ") == true) sw.WriteLine("delete from t_Accept where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�����˻���") == true) sw.WriteLine("delete from t_SellBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�̵㵥") == true) sw.WriteLine("delete from t_Check where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("���ε�") == true) sw.WriteLine("delete from t_Exchange where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("��װ��") == true) sw.WriteLine("delete from t_Install where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("���������ֵ�") == true) sw.WriteLine("delete from t_Other where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("�����ƻ���") == true) sw.WriteLine("delete from t_ProductPlan where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("��������") == true) sw.WriteLine("delete from t_Task where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("����״����") == true) sw.WriteLine("delete from t_ProductStatus where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("���ϵ�") == true) sw.WriteLine("delete from t_DrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("���ϵ�") == true) sw.WriteLine("delete from t_PatchGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("���ϵ�") == true) sw.WriteLine("delete from t_BackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("��Ʒ���ֵ�") == true) sw.WriteLine("delete from t_ProductIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("ί��ӹ���") == true) sw.WriteLine("delete from t_OutBill where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("ί�����ϵ�") == true) sw.WriteLine("delete from t_OutDrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("ί�����ϵ�") == true) sw.WriteLine("delete from t_OutBackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("ί����ֵ�") == true) sw.WriteLine("delete from t_OutInStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("ί���˻���") == true) sw.WriteLine("delete from t_OutBackStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");
                if (TestItemImport("ί�⸶�") == true) sw.WriteLine("delete from t_OutPay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'");

                if (TestItemImport("�깺��") == true)
                {
                    lbFlag.Text = "���������깺��......";
                    lbFlag.Update();
                    //�깺��
                    strSQL = "select * from t_ApplyStock where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ApplyStock");

                    strSQL = "select b.* from t_ApplyStock a,t_ApplyStockDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ApplyStockDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�ɹ�����") == true)
                {
                    lbFlag.Text = "���������ɹ�����......";
                    lbFlag.Update();

                    //�ɹ�����
                    strSQL = "select * from t_StockOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockOrder");

                    strSQL = "select b.* from t_StockOrder a,t_StockOrderDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockOrderDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�ɹ�������") == true)
                {
                    lbFlag.Text = "���������ɹ�������......";
                    lbFlag.Update();

                    //�ɹ�������
                    strSQL = "select * from t_StockIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockIn");

                    strSQL = "select b.* from t_StockIn a,t_StockInDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockInDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�ɹ����") == true)
                {
                    lbFlag.Text = "���������ɹ����......";
                    lbFlag.Update();

                    //�ɹ����
                    strSQL = "select * from t_Pay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Pay");

                    strSQL = "select b.* from t_Pay a,t_PayDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_PayDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�ɹ��˻���") == true)
                {
                    lbFlag.Text = "���������ɹ��˻���......";
                    lbFlag.Update();

                    //�ɹ��˻�
                    strSQL = "select * from t_StockBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockBack");

                    strSQL = "select b.* from t_StockBack a,t_StockBackDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_StockBackDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ѯ�۵�") == true)
                {
                    lbFlag.Text = "��������ѯ�۵�......";
                    lbFlag.Update();

                    //ѯ�۵�
                    strSQL = "select * from t_AskPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_AskPrice");

                    strSQL = "select b.* from t_AskPrice a,t_AskPriceDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_AskPriceDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("���۵�") == true)
                {
                    lbFlag.Text = "�����������۵�......";
                    lbFlag.Update();

                    //���۵�
                    strSQL = "select * from t_SellPrice where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPrice");

                    strSQL = "select b.* from t_SellPrice a,t_SellPriceDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPriceDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�ͻ�����") == true)
                {
                    lbFlag.Text = "���������ͻ�����......";
                    lbFlag.Update();

                    //�ͻ�����
                    strSQL = "select * from t_SellOrder where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOrder");

                    strSQL = "select b.* from t_SellOrder a,t_SellOrderDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOrderDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("����֪ͨ��") == true)
                {
                    lbFlag.Text = "������������֪ͨ��......";
                    lbFlag.Update();

                    //����֪ͨ��
                    strSQL = "select * from t_SellPre where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPre");

                    strSQL = "select b.* from t_SellPre a,t_SellPreDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellPreDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("������") == true)
                {
                    lbFlag.Text = "��������������......";
                    lbFlag.Update();

                    //������
                    strSQL = "select * from t_SellOut where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOut");

                    strSQL = "select b.* from t_SellOut a,t_SellOutDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellOutDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�տ") == true)
                {
                    lbFlag.Text = "���������տ......";
                    lbFlag.Update();

                    //�տ
                    strSQL = "select * from t_Accept where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Accept");

                    strSQL = "select b.* from t_Accept a,t_AcceptDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_AcceptDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�����˻���") == true)
                {
                    lbFlag.Text = "�������������˻�......";
                    lbFlag.Update();

                    //�����˻�
                    strSQL = "select * from t_SellBack where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellBack");

                    strSQL = "select b.* from t_SellBack a,t_SellBackDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_SellBackDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�̵㵥") == true)
                {
                    lbFlag.Text = "���������̵㵥......";
                    lbFlag.Update();

                    //�̵㵥
                    strSQL = "select * from t_Check where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Check");

                    strSQL = "select b.* from t_Check a,t_CheckDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_CheckDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("���ε�") == true)
                {
                    lbFlag.Text = "�����������ε�......";
                    lbFlag.Update();

                    //���ε�
                    strSQL = "select * from t_Exchange where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Exchange");

                    strSQL = "select b.* from t_Exchange a,t_ExchangeDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ExchangeDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��װ��") == true)
                {
                    lbFlag.Text = "����������װ��......";
                    lbFlag.Update();

                    //��װ��
                    strSQL = "select * from t_Install where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Install");

                    strSQL = "select b.* from t_Install a,t_InstallDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_InstallDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("���������ֵ�") == true)
                {
                    lbFlag.Text = "�����������������ֵ�......";
                    lbFlag.Update();

                    //���������ֵ�
                    strSQL = "select * from t_Other where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Other");

                    strSQL = "select b.* from t_Other a,t_OtherDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OtherDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("�����ƻ���") == true)
                {
                    lbFlag.Text = "�������������ƻ���......";
                    lbFlag.Update();

                    //�����ƻ���
                    strSQL = "select * from t_ProductPlan where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductPlan");

                    strSQL = "select b.* from t_ProductPlan a,t_ProductPlanDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductPlanDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��������") == true)
                {
                    lbFlag.Text = "����������������......";
                    lbFlag.Update();

                    //��������
                    strSQL = "select * from t_Task where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_Task");

                    strSQL = "select b.* from t_Task a,t_TaskGoods b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskGoods");

                    strSQL = "select b.* from t_Task a,t_TaskHalf b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskHalf");

                    strSQL = "select b.* from t_Task a,t_TaskItem b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskItem");

                    strSQL = "select b.* from t_Task a,t_TaskDept b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_TaskDept");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("����״����") == true)
                {
                    lbFlag.Text = "������������״����......";
                    lbFlag.Update();

                    //����״����
                    strSQL = "select * from t_ProductStatus where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductStatus");

                    strSQL = "select b.* from t_ProductStatus a,t_ProductStatusDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductStatusDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("���ϵ�") == true)
                {
                    lbFlag.Text = "�����������ϵ�......";
                    lbFlag.Update();

                    //���ϵ�
                    strSQL = "select * from t_DrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_DrawGoods");

                    strSQL = "select b.* from t_DrawGoods a,t_DrawGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_DrawGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("���ϵ�") == true)
                {
                    lbFlag.Text = "�����������ϵ�......";
                    lbFlag.Update();

                    //���ϵ�
                    strSQL = "select * from t_PatchGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_PatchGoods");

                    strSQL = "select b.* from t_PatchGoods a,t_PatchGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_PatchGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("���ϵ�") == true)
                {
                    lbFlag.Text = "�����������ϵ�......";
                    lbFlag.Update();

                    //���ϵ�
                    strSQL = "select * from t_BackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_BackGoods");

                    strSQL = "select b.* from t_BackGoods a,t_BackGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_BackGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("��Ʒ���ֵ�") == true)
                {
                    lbFlag.Text = "����������Ʒ���ֵ�......";
                    lbFlag.Update();

                    //��Ʒ���ֵ�
                    strSQL = "select * from t_ProductIn where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductIn");

                    strSQL = "select b.* from t_ProductIn a,t_ProductInDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_ProductInDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ί��ӹ���") == true)
                {
                    lbFlag.Text = "��������ί��ӹ���......";
                    lbFlag.Update();

                    //ί��ӹ���
                    strSQL = "select * from t_OutBill where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBill");

                    strSQL = "select b.* from t_OutBill a,t_OutBillDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBillDetail");

                    strSQL = "select b.* from t_OutBill a,t_OutBillItem b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBillItem");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ί�����ϵ�") == true)
                {
                    lbFlag.Text = "��������ί�����ϵ�......";
                    lbFlag.Update();

                    //ί�����ϵ�
                    strSQL = "select * from t_OutDrawGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutDrawGoods");

                    strSQL = "select b.* from t_OutDrawGoods a,t_OutDrawGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutDrawGoodsDetail");

                    lbFlag.Text = "��������ί�����ϵ�......";
                    lbFlag.Update();
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ί�����ϵ�") == true)
                {
                    //ί�����ϵ�
                    strSQL = "select * from t_OutBackGoods where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackGoods");

                    strSQL = "select b.* from t_OutBackGoods a,t_OutBackGoodsDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackGoodsDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ί����ֵ�") == true)
                {
                    lbFlag.Text = "��������ί����ֵ�......";
                    lbFlag.Update();

                    //ί����ֵ�
                    strSQL = "select * from t_OutInStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutInStore");

                    strSQL = "select b.* from t_OutInStore a,t_OutInStoreDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutInStoreDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ί���˻���") == true)
                {
                    lbFlag.Text = "��������ί���˻���......";
                    lbFlag.Update();

                    //ί���˻���
                    strSQL = "select * from t_OutBackStore where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackStore");

                    strSQL = "select b.* from t_OutBackStore a,t_OutBackStoreDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutBackStoreDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                if (TestItemImport("ί�⸶�") == true)
                {
                    //ί�⸶�
                    strSQL = "select * from t_OutPay where F_Date >= '" + dtStart.ToString() + "' and F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutPay");

                    strSQL = "select b.* from t_OutPay a,t_OutPayDetail b where a.F_BillID = b.F_BillID and a.F_Date >= '" + dtStart.ToString() + "' and a.F_Date <= '" + dtEnd.ToString() + "'";
                    Export(strSQL, "t_OutPayDetail");
                    progressBar.Value = progressBar.Value + 1;
                }

                ////�����ֶθ�ʽ
                //strSQL = "select * from t_ReportField";
                //Export(strSQL, "t_ReportField");

                //�����ʽ
                strSQL = "select * from t_Report";
                Export(strSQL, "t_Report");

                progressBar.Value = progressBar.Value + 1;

                sw.Dispose();
                Compress();

                lbFlag.Text = "���������ɹ�!!";
                lbFlag.Update();
                MessageBox.Show("���������ɹ�!!", "��ʾ");
            }
            finally
            {
                //sw.Dispose();
                sbExport.Enabled = true;
                ckBase.Enabled = true;
                ckOperation.Enabled = true;
                sbSelect.Enabled = true;
            }
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbExport_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("������ѡ��һ�ֵ�������(�������ϻ�ҵ������)!!", "��ʾ");
                return;
            }

            if (txtFile.Text.Length == 0)
            {
                MessageBox.Show("��ѡ�����ļ�����", "��ʾ");
                sbSelect.Focus();
                return;
            }

            if (MessageBox.Show(this, "�����������ܽ��бȽϳ���һ��ʱ�䣬��ȷ��Ҫ���д˲�����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DataExport(ucDate.dtStart,ucDate.dtEnd);
        }

        private void sbSelect_Click(object sender, EventArgs e)
        {
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = FileDlg.FileName;
            }
        }

        private void ckBase_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��˾��Ϣ"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�û�������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�û�����"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("Ȩ������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��Ӧ������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�ͻ�����"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ְԱ����"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�ֿ�����"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("������������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��Ʒ����滮����"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��ӹ���������"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("BOM����"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("���˹�˾����"), ckBase.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ϵͳ�������"), ckBase.Checked);

        }

        private void ckOperation_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�깺��"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�ɹ�����"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�ɹ�������"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�ɹ����"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�ɹ��˻���"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ѯ�۵�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("���۵�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�ͻ�����"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("����֪ͨ��"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("������"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�տ"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�����˻���"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�̵㵥"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("���ε�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��װ��"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("���������ֵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�깺��"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("�����ƻ���"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��������"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("����״����"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("���ϵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("���ϵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("���ϵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("��Ʒ���ֵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ί��ӹ���"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ί�����ϵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ί�����ϵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ί����ֵ�"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ί���˻���"), ckOperation.Checked);
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf("ί�⸶�"), ckOperation.Checked);
        }

        private void frmDataExport_Shown(object sender, EventArgs e)
        {
            ckBase_CheckedChanged(null,null);
            ckOperation_CheckedChanged(null, null);
        }
        
    }
}

