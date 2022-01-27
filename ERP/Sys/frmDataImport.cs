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
    public partial class frmDataImport : BaseClass.frmBase
    {
        private string strPath = Application.StartupPath + "\\Data\\";
        public frmDataImport()
        {
            InitializeComponent();
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ��ѹ������
        /// </summary>
        /// <returns></returns>
        private int UnCompress()
        {
            if (Directory.Exists(strPath) == true)
            {
                Directory.Delete(strPath,true);
            }

            Directory.CreateDirectory(strPath);

            System.Diagnostics.Process ProData = new System.Diagnostics.Process();
            ProData.StartInfo.FileName = "Winrar.exe";
            ProData.StartInfo.CreateNoWindow = true;
            string strFile = '"' + txtFile.Text + '"';
            ProData.StartInfo.Arguments = " x " + strFile + " " + strPath;

            ProData.Start();
            ProData.WaitForExit();
            ProData.Close();
            /*
            if (ProData.HasExited)
            {
                int iExitCode = ProData.ExitCode;
                if (iExitCode != 0)
                {
                    MessageBox.Show("��ѹ���ļ����󣬴����:" + iExitCode.ToString(), "����");
                    return 0;
                }
            }
             */ 

            ImportData();
            return 1;

        }

        /// <summary>
        /// ɾ��ԭ����
        /// </summary>
        /// <returns></returns>
        private int DelData()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            StreamReader sr = File.OpenText(strPath + "t_SQL.txt");
            string strSQL = sr.ReadToEnd();
            sr.Dispose();
            return myHelper.ExecuteSQL(strSQL);
        }

        /// <summary>
        /// ��������������
        /// </summary>
        private void ImportData()
        {
            string strSQL;

            progressBar.Maximum = 91;
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            sbSelect.Enabled = false;
            sbImport.Enabled = false;
            sbClose.Enabled = false;
            try
            {
                
                lbFlag.Text = "�������������......";
                lbFlag.Update();
                if (DelData() != 0) return;

                lbFlag.Text = "�������븨������......";
                lbFlag.Update();
                strSQL = "select * from t_Assist";
                Import(strSQL, "t_Assist");

                lbFlag.Text = "�������빫˾��Ϣ......";
                lbFlag.Update();
                strSQL = "select * from t_CompanyInfo";
                Import(strSQL, "t_CompanyInfo");

                lbFlag.Text = "���������û�������......";
                lbFlag.Update();
                strSQL = "select * from t_UserGroup";
                Import(strSQL, "t_UserGroup");

                lbFlag.Text = "���������û�����......";
                lbFlag.Update();
                strSQL = "select * from t_User";
                Import(strSQL, "t_User");

                //lbFlag.Text = "��������Ȩ������0......";
                //lbFlag.Update();
                //strSQL = "select * from t_Right";
                //Import(strSQL, "t_Right");

                //lbFlag.Text = "��������Ȩ������1......";
                //lbFlag.Update();
                //strSQL = "select * from t_RightDetail";
                //Import(strSQL, "t_RightDetail");

                lbFlag.Text = "��������Ȩ������2......";
                lbFlag.Update();
                strSQL = "select * from t_DetailRight";
                Import(strSQL, "t_DetailRight");


                lbFlag.Text = "���������������......";
                lbFlag.Update();
                strSQL = "select * from t_Class";
                Import(strSQL, "t_Class");

                lbFlag.Text = "��������ֿ�����......";
                lbFlag.Update();
                strSQL = "select * from t_Storage";
                Import(strSQL, "t_Storage");

                lbFlag.Text = "�������빩Ӧ������......";
                lbFlag.Update();
                strSQL = "select * from t_Supplier";
                Import(strSQL, "t_Supplier");

                lbFlag.Text = "��������ͻ�����......";
                lbFlag.Update();
                strSQL = "select * from t_Client";
                Import(strSQL, "t_Client");

                lbFlag.Text = "��������ְԱ����......";
                lbFlag.Update();
                strSQL = "select * from t_Emp";
                Import(strSQL, "t_Emp");

                lbFlag.Text = "����������������......";
                lbFlag.Update();
                strSQL = "select * from t_Item";
                Import(strSQL, "t_Item");

                strSQL = "select * from t_Unit";
                Import(strSQL, "t_Unit");

                lbFlag.Text = "�������빤������......";
                lbFlag.Update();
                strSQL = "select * from t_WorkGroup";
                Import(strSQL, "t_WorkGroup");

                lbFlag.Text = "�������빤������......";
                lbFlag.Update();
                strSQL = "select * from t_Process";
                Import(strSQL, "t_Process");

                lbFlag.Text = "�������빤����������......";
                lbFlag.Update();
                strSQL = "select * from t_Craftwork";
                Import(strSQL, "t_Craftwork");

                strSQL = "select * from t_CraftworkDetail";
                Import(strSQL, "t_CraftworkDetail");

                lbFlag.Text = "���������Ʒ����滮����......";
                lbFlag.Update();
                strSQL = "select * from t_ProductProcess";
                Import(strSQL, "t_ProductProcess");

                strSQL = "select * from t_ProductProcessDetail";
                Import(strSQL, "t_ProductProcessDetail");

                lbFlag.Text = "����������ӹ���������......";
                lbFlag.Update();
                strSQL = "select * from t_OutSupplier";
                Import(strSQL, "t_OutSupplier");

                lbFlag.Text = "��������Bom������......";
                lbFlag.Update();
                strSQL = "select * from t_Bom";
                Import(strSQL, "t_Bom");

                strSQL = "select * from t_BomDetail";
                Import(strSQL, "t_BomDetail");

                lbFlag.Text = "����������˹�˾����......";
                lbFlag.Update();
                strSQL = "select * from t_CarryCompany";
                Import(strSQL, "t_CarryCompany");
                
                lbFlag.Text = "���������깺��......";
                lbFlag.Update();
                strSQL = "select * from t_ApplyStock where F_BillID = ''";
                Import(strSQL, "t_ApplyStock");

                strSQL = "select * from t_ApplyStockDetail where F_BillID = ''";
                Import(strSQL, "t_ApplyStockDetail");

                lbFlag.Text = "��������ɹ�����......";
                lbFlag.Update();
                strSQL = "select * from t_StockOrder where F_BillID = ''";
                Import(strSQL, "t_StockOrder");

                strSQL = "select * from t_StockOrderDetail where F_BillID = ''";
                Import(strSQL, "t_StockOrderDetail");

                lbFlag.Text = "��������ɹ�������......";
                lbFlag.Update();
                strSQL = "select * from t_StockIn where F_BillID = ''";
                Import(strSQL, "t_StockIn");

                strSQL = "select * from t_StockInDetail where F_BillID = ''";
                Import(strSQL, "t_StockInDetail");

                lbFlag.Text = "��������ɹ����......";
                lbFlag.Update();
                strSQL = "select * from t_Pay where F_BillID = ''";
                Import(strSQL, "t_Pay");

                strSQL = "select * from t_PayDetail where F_BillID = ''";
                Import(strSQL, "t_PayDetail");

                lbFlag.Text = "��������ɹ��˻���......";
                lbFlag.Update();
                strSQL = "select * from t_StockBack where F_BillID = ''";
                Import(strSQL, "t_StockBack");

                strSQL = "select * from t_StockBackDetail where F_BillID = ''";
                Import(strSQL, "t_StockBackDetail");  

                lbFlag.Text = "��������ѯ�۵�......";
                lbFlag.Update();
                strSQL = "select * from t_AskPrice where F_BillID = ''";
                Import(strSQL, "t_AskPrice");

                strSQL = "select * from t_AskPriceDetail where F_BillID = ''";
                Import(strSQL, "t_AskPriceDetail");

                lbFlag.Text = "�������뱨�۵�......";
                lbFlag.Update();
                strSQL = "select * from t_SellPrice where F_BillID = ''";
                Import(strSQL, "t_SellPrice");

                strSQL = "select * from t_SellPriceDetail where F_BillID = ''";
                Import(strSQL, "t_SellPriceDetail");

                lbFlag.Text = "��������ͻ�����......";
                lbFlag.Update();
                strSQL = "select * from t_SellOrder where F_BillID = ''";
                Import(strSQL, "t_SellOrder");

                strSQL = "select * from t_SellOrderDetail where F_BillID = ''";
                Import(strSQL, "t_SellOrderDetail");

                lbFlag.Text = "�������뷢��֪ͨ��......";
                lbFlag.Update();
                strSQL = "select * from t_SellPre where F_BillID = ''";
                Import(strSQL, "t_SellPre");

                strSQL = "select * from t_SellPreDetail where F_BillID = ''";
                Import(strSQL, "t_SellPreDetail");

                lbFlag.Text = "�������뷢����......";
                lbFlag.Update();
                strSQL = "select * from t_SellOut where F_BillID = ''";
                Import(strSQL, "t_SellOut");

                strSQL = "select * from t_SellOutDetail where F_BillID = ''";
                Import(strSQL, "t_SellOutDetail");

                lbFlag.Text = "���������տ......";
                lbFlag.Update();
                strSQL = "select * from t_Accept where F_BillID = ''";
                Import(strSQL, "t_Accept");

                strSQL = "select * from t_AcceptDetail where F_BillID = ''";
                Import(strSQL, "t_AcceptDetail");

                lbFlag.Text = "�������������˻���......";
                lbFlag.Update();
                strSQL = "select * from t_SellBack where F_BillID = ''";
                Import(strSQL, "t_SellBack");

                strSQL = "select * from t_SellBackDetail where F_BillID = ''";
                Import(strSQL, "t_SellBackDetail");

                lbFlag.Text = "���������̵㵥......";
                lbFlag.Update();
                strSQL = "select * from t_Check where F_BillID = ''";
                Import(strSQL, "t_Check");

                strSQL = "select * from t_CheckDetail where F_BillID = ''";
                Import(strSQL, "t_CheckDetail");

                lbFlag.Text = "����������ε�......";
                lbFlag.Update();
                strSQL = "select * from t_Exchange where F_BillID = ''";
                Import(strSQL, "t_Exchange");

                strSQL = "select * from t_ExchangeDetail where F_BillID = ''";
                Import(strSQL, "t_ExchangeDetail");

                lbFlag.Text = "����������װ��......";
                lbFlag.Update();
                strSQL = "select * from t_Install where F_BillID = ''";
                Import(strSQL, "t_Install");

                strSQL = "select * from t_InstallDetail where F_BillID = ''";
                Import(strSQL, "t_InstallDetail");

                lbFlag.Text = "�����������������ֵ�......";
                lbFlag.Update();
                strSQL = "select * from t_Other where F_BillID = ''";
                Import(strSQL, "t_Other");

                strSQL = "select * from t_OtherDetail where F_BillID = ''";
                Import(strSQL, "t_OtherDetail");

                lbFlag.Text = "�������������ƻ���......";
                lbFlag.Update();
                strSQL = "select * from t_ProductPlan where F_BillID = ''";
                Import(strSQL, "t_ProductPlan");

                strSQL = "select * from t_ProductPlanDetail where F_BillID = ''";
                Import(strSQL, "t_ProductPlanDetail");

                lbFlag.Text = "����������������......";
                lbFlag.Update();
                strSQL = "select * from t_Task where F_BillID = ''";
                Import(strSQL, "t_Task");

                strSQL = "select * from t_TaskGoods where F_BillID = ''";
                Import(strSQL, "t_TaskGoods");

                strSQL = "select * from t_TaskHalf where F_BillID = ''";
                Import(strSQL, "t_TaskHalf");

                strSQL = "select * from t_TaskItem where F_BillID = ''";
                Import(strSQL, "t_TaskItem");

                strSQL = "select * from t_TaskDept where F_BillID = ''";
                Import(strSQL, "t_TaskDept");

                lbFlag.Text = "������������״����......";
                lbFlag.Update();
                strSQL = "select * from t_ProductStatus where F_BillID = ''";
                Import(strSQL, "t_ProductStatus");

                strSQL = "select * from t_ProductStatusDetail where F_BillID = ''";
                Import(strSQL, "t_ProductStatusDetail");

                lbFlag.Text = "�����������ϵ�......";
                lbFlag.Update();
                strSQL = "select * from t_DrawGoods where F_BillID = ''";
                Import(strSQL, "t_DrawGoods");

                strSQL = "select * from t_DrawGoodsDetail where F_BillID = ''";
                Import(strSQL, "t_DrawGoodsDetail");

                lbFlag.Text = "�������벹�ϵ�......";
                lbFlag.Update();
                strSQL = "select * from t_PatchGoods where F_BillID = ''";
                Import(strSQL, "t_PatchGoods");

                strSQL = "select * from t_PatchGoodsDetail where F_BillID = ''";
                Import(strSQL, "t_PatchGoodsDetail");

                lbFlag.Text = "�����������ϵ�......";
                lbFlag.Update();
                strSQL = "select * from t_BackGoods where F_BillID = ''";
                Import(strSQL, "t_BackGoods");

                strSQL = "select * from t_BackGoodsDetail where F_BillID = ''";
                Import(strSQL, "t_BackGoodsDetail");

                lbFlag.Text = "���������Ʒ���ֵ�......";
                lbFlag.Update();
                strSQL = "select * from t_ProductIn where F_BillID = ''";
                Import(strSQL, "t_ProductIn");

                strSQL = "select * from t_ProductInDetail where F_BillID = ''";
                Import(strSQL, "t_ProductInDetail");

                lbFlag.Text = "��������ί��ӹ���......";
                lbFlag.Update();
                strSQL = "select * from t_OutBill where F_BillID = ''";
                Import(strSQL, "t_OutBill");

                strSQL = "select * from t_OutBillDetail where F_BillID = ''";
                Import(strSQL, "t_OutBillDetail");

                strSQL = "select * from t_OutBillItem where F_BillID = ''";
                Import(strSQL, "t_OutBillItem");

                lbFlag.Text = "��������ί�����ϵ�......";
                lbFlag.Update();
                strSQL = "select * from t_OutDrawGoods where F_BillID = ''";
                Import(strSQL, "t_OutDrawGoods");

                strSQL = "select * from t_OutDrawGoodsDetail where F_BillID = ''";
                Import(strSQL, "t_OutDrawGoodsDetail");

                lbFlag.Text = "��������ί�����ϵ�......";
                lbFlag.Update();
                strSQL = "select * from t_OutBackGoods where F_BillID = ''";
                Import(strSQL, "t_OutBackGoods");

                strSQL = "select * from t_OutBackGoodsDetail where F_BillID = ''";
                Import(strSQL, "t_OutBackGoodsDetail");

                lbFlag.Text = "��������ί����ֵ�......";
                lbFlag.Update();
                strSQL = "select * from t_OutInStore where F_BillID = ''";
                Import(strSQL, "t_OutInStore");

                strSQL = "select * from t_OutInStoreDetail where F_BillID = ''";
                Import(strSQL, "t_OutInStoreDetail");

                lbFlag.Text = "��������ί���˻���......";
                lbFlag.Update();
                strSQL = "select * from t_OutBackStore where F_BillID = ''";
                Import(strSQL, "t_OutBackStore");

                strSQL = "select * from t_OutBackStoreDetail where F_BillID = ''";
                Import(strSQL, "t_OutBackStoreDetail");

                lbFlag.Text = "��������ί�⸶�......";
                lbFlag.Update();
                strSQL = "select * from t_OutPay where F_BillID = ''";
                Import(strSQL, "t_OutPay");

                strSQL = "select * from t_OutPayDetail where F_BillID = ''";
                Import(strSQL, "t_OutPayDetail");

                lbFlag.Text = "�������뱨���ʽ......";
                lbFlag.Update();
                strSQL = "select * from t_Report ";
                Import(strSQL, "t_Report");

                lbFlag.Text = "��������ɹ�!!";
                lbFlag.Update();
            }
            finally
            {
                sbSelect.Enabled = true;
                sbImport.Enabled = true;
                sbClose.Enabled = true;
                //lbFlag.Text = "��������ɹ�!!";
                lbFlag.Update();
                MessageBox.Show("��������ɹ�!!", "��ʾ");
            }

        }

        /// <summary>
        /// ���������ӷ���
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="strFile"></param>
        /// <returns></returns>
        private int Import(string strSQL,string strFile)
        {
            DataSet dsTmp = new DataSet();
            dsTmp.ReadXml(strPath + strFile + ".xml");

            /*
            foreach (DataRow dr in dsTmp.Tables[0].Rows)
            {
                foreach (DataColumn dc in dsTmp.Tables[0].Columns)
                {
                    if (dc.DataType == System.Type.GetType("System.DateTime"))
                    {
                        if (dr[dc].ToString().Substring(0, 4) == "0001")
                        {
                            dr[dc] = Convert.ToDateTime("1900-1-1");
                        }
                    }
                }
            }
             */
            try
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();

                DataSet dsNew = myHelper.GetDs(strSQL);

                foreach (DataRow dr in dsTmp.Tables[0].Rows)
                {
                    DataRow drNew = dsNew.Tables[0].NewRow();
                    foreach (DataColumn dc in dsTmp.Tables[0].Columns)
                    {
                        if (dc.DataType == System.Type.GetType("System.DateTime"))
                        {
                            if (dr[dc].ToString().Substring(0, 4) == "0001")
                            {
                                //dr[dc] = Convert.ToDateTime("1900-1-1");
                                drNew[dc.ColumnName] = Convert.ToDateTime("1900-1-1");
                            }
                            else
                            {
                                drNew[dc.ColumnName] = dr[dc];
                            }
                        }
                        else
                        {
                            drNew[dc.ColumnName] = dr[dc];
                        }
                    }

                    dsNew.Tables[0].Rows.Add(drNew);
                }

                myHelper.SaveData(dsNew, strSQL);

                dsTmp.Dispose();
                progressBar.Value = progressBar.Value + 1;
                return 1;
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message, strFile);
                return -1;
            }
        }

        private void sbSelect_Click(object sender, EventArgs e)
        {
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = FileDlg.FileName;
            }
        }

        private void sbImport_Click(object sender, EventArgs e)
        {
            if (txtFile.Text.Length == 0)
            {
                MessageBox.Show("��ѡ��������ļ�����", "��ʾ");
                sbSelect.Focus();
                return;
            }

            if (MessageBox.Show(this, "����������ܽ��бȽϳ���һ��ʱ�䣬��ȷ��Ҫ���д˲�����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                UnCompress();
              
        }
    }
}

