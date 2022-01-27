using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;

namespace JXC
{
    public partial class frmBack : BaseClass.frmBase
    {
        public JXC.frmMain myApp;

        public frmBack()
        {  
            InitializeComponent();
            ListWake.ItemHeight = 16;
            ListWake.DrawMode = DrawMode.OwnerDrawFixed;
            try
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                lbFindBill.Parent = pcTop;
                //lbFindBill.Location = new Point(lbFindBill.Left, 55);
                FillReport(1);

                if (DataLib.SysVar.GetParmValue("F_N12") == true)
                {
                    timer1.Interval = (int)DataLib.SysVar.GetDecParmValue("F_C4") * 60 * 1000;
                    timer1.Enabled = true;
                    timer1_Tick(null, null);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message,"�����ڴ���");
            }
        }

        /// <summary>
        /// ������ʾ
        /// </summary>
        private void ListenTel()
        {
            Phone.Modem modem = new Phone.Modem();
            modem.Ring += new EventHandler<Phone.RingEventArgs>(modem_Ring);
            try
            {
                modem.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������ʾ����");
            }
        }

        private void modem_Ring(object sender, Phone.RingEventArgs e)
        {
            edtTel.txtEdit.Text = e.PhoneNumber;
            string sSQL = string.Format("insert into t_DispTel(F_Date,F_Tel) values('{0}','{1}')", DateTime.Now, e.PhoneNumber);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (myHelper.ExecuteSQL(sSQL) == 0)
            {
                edtTel.txtEdit.Text = e.PhoneNumber;

                sSQL = "select top 1 F_ID from t_Client where F_Tel = '"+e.PhoneNumber+"'";
                DataTable dt = myHelper.GetDs(sSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Base.frmEditClient myEditClient = new Base.frmEditClient();
                    myEditClient.Edit(dt.Rows[0]["F_ID"].ToString());
                    myEditClient.ShowDialog();
                    myEditClient.Dispose();
                }
            }
        }

        /// <summary>
        /// �򱨱��б������Ŀ
        /// </summary>
        /// <param name="objItem"></param>
        private void AddItem(object objItem)
        {
            ImageListBoxItem Litem = new ImageListBoxItem();
            Litem.ImageIndex = 0;
            Litem.Value = objItem;
            ReportList.Items.Add(Litem);
        }

        /// <summary>
        /// �����û���Ȩ��
        /// </summary>
        /// <param name="strModule"></param>
        /// <returns></returns>
        private bool TestUse(string strModule)
        {
            if (DataLib.SysVar.strUGroup == "�����û�") return true;
            string strSQL = @"select F_Enable from t_RightDetail
                            where F_Class = '" + strModule + @"'
                            and F_Name = '����'
                            and F_Group = '"+DataLib.SysVar.strUGroup+"'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0) return false;

            return Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// û����˵ĵ���
        /// </summary>
        private void BillNoCheck()
        {
            DataSet ds = null;
            if (ListWake.Items.Count > 0)
               ListWake.Items.Clear();

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (TestUse("frmApplyStockList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_ApplyStock where isnull(F_Check,0) = 0 and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "���깺��δ���!");
            }

            if (TestUse("frmStockOrderList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_StockOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�Ųɹ�����δ���!");
            }

            //if (TestUse("frmStockInList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_StockIn where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�Ųɹ�������δ���!");
            //}

            if (TestUse("frmStockPayList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_Pay where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�Ųɹ����δ���!");
            }

            //if (TestUse("frmStockBackList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_StockBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�Ųɹ��˻���δ���!");
            //}

            if (TestUse("frmSellOrderList") == true)
            {
                if (DataLib.SysVar.strUGroup == "�����û�")
                    ds = myHelper.GetDs("select F_BillID from t_SellOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0"); 
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                    //ds = myHelper.GetDs("select F_BillID from t_SellOrder where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '�����û�')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�ſͻ�����δ���!");
            }

            if (TestUse("frmSellPreList") == true)
            {
                if (DataLib.SysVar.strUGroup == "�����û�")
                    ds = myHelper.GetDs("select F_BillID from t_SellPre where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 ");
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellPre where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 ");
                    //ds = myHelper.GetDs("select F_BillID from t_SellPre where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '�����û�')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�ŷ���֪ͨ��δ���!");
            }

            //if (TestUse("frmSellOutList") == true)
            //{
                if (DataLib.SysVar.strUGroup == "�����û�")
                    ds = myHelper.GetDs("select F_BillID from t_SellOut where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellOut where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0"); 
                   //ds = myHelper.GetDs("select F_BillID from t_SellOut where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '�����û�')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�ŷ�����δ���!");
            //}

            if (TestUse("frmSellAcceptList") == true)
            {
                if (DataLib.SysVar.strUGroup == "�����û�")
                    ds = myHelper.GetDs("select F_BillID from t_Accept where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                else
                    ds = myHelper.GetDs("select F_BillID from t_Accept where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0"); 
                    //ds = myHelper.GetDs("select F_BillID from t_Accept where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '�����û�')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�������տδ���!");
            }

            //if (TestUse("frmSellBackList") == true)
            //{
                if (DataLib.SysVar.strUGroup == "�����û�")
                    ds = myHelper.GetDs("select F_BillID from t_SellBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                else
                    ds = myHelper.GetDs("select F_BillID from t_SellBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                    //ds = myHelper.GetDs("select F_BillID from t_SellBack where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0 and (F_BillMan = '" + DataLib.SysVar.strUName + "' or F_BillMan = '�����û�')");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�������˻���δ���!");
            //}

            //if (TestUse("frmCheckList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Check where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "���̵㵥δ���!");
            //}

            //if (TestUse("frmExchangeList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Exchange where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "���ε�δ���!");
            //}

            //if (TestUse("frmInstallList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Install where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "��װ��δ���!");
            //}

            //if (TestUse("frmOtherInList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Other where isnull(F_Check,0) = 0 and isnull(F_Flag,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�������ֵ�δ���!");
            //}

            //if (TestUse("frmOtherOutList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_Other where isnull(F_Check,0) = 0 and isnull(F_Flag,0) = 1  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�������ֵ�δ���!");
            //}

            if (TestUse("frmProductPlanList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_ProductPlan where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�����ƻ���δ���!");
            }

            if (TestUse("frmTaskList") == true)
            {
                ds = myHelper.GetDs("select F_BillID from t_Task where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "��������δ���!");
            }

            //if (TestUse("frmDrawGoodsList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_DrawGoods where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "���ϵ�δ���!");
            //}

            //if (TestUse("frmBackGoodsList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_BackGoods where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "���ϵ�δ���!");
            //}

            //if (TestUse("frmProductInList") == true)
            //{
                ds = myHelper.GetDs("select F_BillID from t_ProductIn where isnull(F_Check,0) = 0  and isnull(F_Invalid,0) = 0");
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "��Ʒ���ֵ�δ���!");
            //}

            decimal decDay1 = DataLib.SysVar.GetDecParmValue("F_C5");
            decimal decDay2 = DataLib.SysVar.GetDecParmValue("F_C6");

            string strSQL = "";

            if (decDay1 > 0)
            {
                strSQL = @"select F_BillID from t_SellOrder
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0 and datediff(day,getdate(),F_SendDate) <= " + decDay1.ToString() + @"
                      and datediff(day,getdate(),F_SendDate) >= 0 ";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                   ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�ͻ�����׼������!");
            }


            if (decDay2 > 0)
            {
                strSQL = @"select F_BillID from t_StockOrder
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0 and datediff(day,getdate(),F_StockTime) <= " + decDay2.ToString() + @"
                      and datediff(day,getdate(),F_StockTime) >= 0 ";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�ɹ�����׼��׷��!");
            }

            //if (TestUse("frmStockInList") == true)
            //{
                strSQL = @"select F_BillID from t_StockIn
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "�ɹ����ֵ�׼���������!");
           // }
            
            //if (TestUse("frmSellOutList") == true)
            //{
                strSQL = @"select F_BillID from t_SellOut
                      where isnull(F_Check,0) =  1 and isnull(F_Finish,0) = 0 and isnull(F_CutOff,0) = 0";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("����" + ds.Tables[0].Rows.Count.ToString() + "���۵�׼���������!");
            //}

                strSQL = @"select b.F_ItemID as F_count
                            from t_Cast a,t_CastDetail b
                            where a.F_ID = b.F_ID
                            and DATEDIFF(day,getdate(),a.F_End) <= "+DataLib.SysVar.GetIntParmValue("F_C7").ToString()+@"
                            and DATEDIFF(day,getdate(),a.F_End) > 0";
                
                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("��" + ds.Tables[0].Rows.Count.ToString() + "�ֲ�Ʒ֤��׼������!");

                strSQL = @"select b.F_ItemID as F_count
                            from t_Cast a,t_CastDetail b
                            where a.F_ID = b.F_ID
                            and DATEDIFF(day,getdate(),a.F_End) < 0";

                ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                    ListWake.Items.Add("��" + ds.Tables[0].Rows.Count.ToString() + "�ֲ�Ʒ֤���ѹ���!");
        }

        /// <summary>
        /// ��ģ���򱨱��б������Ŀ
        /// </summary>
        /// <param name="intFlag"></param>
        private void FillReport(int intFlag)
        {
            TabControl.SelectedTabPageIndex = intFlag - 1;
            ReportList.Items.Clear();

            if (intFlag == 12) intFlag = 13;

            switch (intFlag)
            {
                case 1:
                    AddItem("�ɹ�����ִ�������");
                    AddItem("��Ӧ�̹�������");
                    AddItem("��Ʒ�ɹ�����");
                    AddItem("�ɹ��걨��");
                    AddItem("Ӧ�����");
                    AddItem("Ӧ�����ʱ�");
                    AddItem("Ӧ���������");
                    break;
                case 2:
                    AddItem("�ͻ�����ִ�������");
                    AddItem("�ͻ����۱���");
                    AddItem("ҵ��Ա���۱���");
                    AddItem("��Ʒ���۱���");
                    AddItem("��Ʒ���������");
                    AddItem("�����걨��");
                    AddItem("�������۱���");
                    AddItem("Ӧ�տ��");
                    AddItem("Ӧ�տ��ʱ�");
                    AddItem("Ӧ���������");
                    break;
                case 3:
                    AddItem("ʵʱ���");
                    AddItem("ҵ����");
                    AddItem("��汨������");
                    AddItem("���Ͻ�������ܱ�");
                    AddItem("���Ͻ�������ϸ��");
                    AddItem("�������ݲ�ѯ");
                    AddItem("�ֿ���ˮ��");
                    break;
                case 4:
                    AddItem("����ִ�������");
                    AddItem("�������������");
                    AddItem("�������ٱ�");
                    AddItem("�����ɱ�����");
                    AddItem("�����ձ���");
                    break;
                case 5:
                    AddItem("��ӹ���ִ�������");
                    AddItem("��ӹ����ñ���");
                    AddItem("��ӹ����������");
                    break;
                case 6://���ʹ���
                    break;
                case 7://ϵͳ����
                    break;
                case 8://��������
                    break;
                case 9:
                    AddItem("�ܷ�����");
                    AddItem("��ϸ������");
                    AddItem("�ռ���");
                    AddItem("����ʽ��ϸ��");
                    AddItem("��Ŀ���ܱ�");
                    AddItem("����ƽ���");
                    AddItem("�����");
                    AddItem("�ʲ���ծ��");
                    AddItem("�����");
                    //AddItem("�Զ�����񱨱�");
                    AddItem("�̶��ʲ��嵥");
                    AddItem("�̶��ʲ��۾ɱ�");
                    break;
                case 10:
                    AddItem("���ɽ��ʱ���");
                    break;
                case 11:
                    AddItem("�̶��ʲ��嵥");
                    AddItem("�̶��ʲ��۾ɱ�");
                    AddItem("�̶��ʲ��ۼ��۾ɱ�");
                    AddItem("�ۼƹ�������ѯ");
                    break;
                case 12:
                    AddItem("ʵʱ���");
                    AddItem("ҵ����");
                    AddItem("��汨������");
                    AddItem("���Ͻ�������ܱ�");
                    AddItem("���Ͻ�������ϸ��");
                    AddItem("�������ݲ�ѯ");
                    AddItem("�ֿ���ˮ��");
                    break;
                case 13:
                    AddItem("ˢ����¼");
                    AddItem("��ٵǼ�");
                    AddItem("����Ǽ�");
                    AddItem("�ֹ�����");
                    AddItem("���ݲ���");
                    AddItem("�����ձ���");
                    AddItem("���ڻ��ܱ�");
                    AddItem("δˢ����Ա����");
                    break;
                case 14:   //�豸����
                    AddItem("�豸ά������");
                    break;
            }

        }


        private void navBar_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            switch (e.Group.Caption)
            {
                case "�ɹ�����":
                    FillReport(1);
                    break;
                case "���۹���":
                    FillReport(2);
                    break;
                case "�ֿ����":
                    if (DataLib.SysVar.blnStorageFlag == true)
                        FillReport(3);
                    else
                        FillReport(11);
                    break;
                case "��������":
                    FillReport(4);
                    break;
                case "ί��ӹ�":
                    FillReport(5);
                    break;
                case "���ʹ���":
                    FillReport(6);
                    break;
                case "ϵͳ����":
                    FillReport(7);
                    break;
                case "��������":
                    FillReport(8);
                    break;
                case "�������":
                    FillReport(9);
                    break;
                case "���ɹ���":
                    FillReport(10);
                    break;
                case "�̶��ʲ�":
                    FillReport(11);
                    break;
                case "���¹���":
                    FillReport(12);
                    break;
                case "�豸����":
                    FillReport(14);
                    break;
                case "OAϵͳ":
                    /*Process.Start(@"C:\Program Files\Internet Explorer\IEXPLORE.EXE",DataLib.SysVar.GetObjParmValue("F_OAAdr").ToString());
                    //NaviOA();
                    string argument1 = "\"" + argv1 + "\"";
                    string argument2 = "\"" + argv2 + "\"";
                    Process process = new Process();
                    process.StartInfo.FileName = System.Environment.CurrentDirectory + "//test.exe";
                    process.StartInfo.Arguments = argument1 + " " + argument2;
                    process.StartInfo.UseShellExecute = true; ;
                    process.Start();//���� */
                    break;
            }
        }

        private void NaviOA()
        {
            //TabControl.SelectedTabPageIndex = 14;
            //Uri u = new Uri(DataLib.SysVar.GetObjParmValue("F_OAAdr").ToString());
            //wbBrowse.Url = u;
            //wbBrowse.Refresh(WebBrowserRefreshOption.Completely);
        }

        private void btnApplyStock_Click(object sender, EventArgs e)
        {
            myApp.ShowForm((sender as Button).Text);
        }

        private void navBar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            myApp.ShowForm(e.Link.Caption);     
        }

        private void ReportList_Click(object sender, EventArgs e)
        {
            if (ReportList.SelectedIndex == -1) return;
            myApp.ShowForm(ReportList.SelectedValue.ToString());
        }

        private void lbStore_Click(object sender, EventArgs e)
        {
            myApp.ShowForm(lbStore.Text);
        }

        private void lbFindBill_Click(object sender, EventArgs e)
        {
            myApp.ShowForm("ҵ�����");
        }

        private void frmBack_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            if (DataLib.SysVar.GetParmValue("F_N13") == true)
            {
                ListenTel();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread ThreadWake = new Thread(new ThreadStart(BillNoCheck));

            ThreadWake.Start();
        }

        private void ListWake_DoubleClick(object sender, EventArgs e)
        {

            string strItem = ListWake.SelectedItem.ToString();

            Sys.frmWakeCenter myWakeCenter = new Sys.frmWakeCenter();

            bool bFlag = false;

            if (strItem.Contains("�깺��") == true && TestUse("frmApplyStockList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 0;
                bFlag = true;
            }

            if (strItem.Contains("�ɹ�����׼��׷��") == true && TestUse("frmStockOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 5;
                bFlag = true;
            }

            if (strItem.Contains("�ɹ�����δ���") == true && TestUse("frmStockOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 1;
                bFlag = true;
            }

            if (strItem.Contains("�ɹ�������") == true && TestUse("frmStockInList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 2;
                bFlag = true;
            }

            if (strItem.Contains("�ɹ�����") == true && TestUse("frmStockPayList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("�ɹ��˻���") == true && TestUse("frmStockBackList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 0;
                myWakeCenter.xtraTabControl2.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("ѯ�۵�") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 0;
                bFlag = true;
            }

            if (strItem.Contains("���۵�") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 1;
                bFlag = true;
            }


            if (strItem.Contains("�ͻ�����׼������") == true && TestUse("frmSellOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 7;
                bFlag = true;
            }

            if (strItem.Contains("�ͻ�����δ���") == true && TestUse("frmSellOrderList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 2;
                bFlag = true;
            }


            if (strItem.Contains("����֪ͨ��") == true && TestUse("frmSellPreList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("������") == true && TestUse("frmSellOutList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("�����տ") == true && TestUse("frmSellAcceptList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 5;
                bFlag = true;
            }

            if (strItem.Contains("�����˻���") == true && TestUse("frmSellBackList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 1;
                myWakeCenter.xtraTabControl3.SelectedTabPageIndex = 6;
                bFlag = true;
            }

            if (strItem.Contains("�̵㵥") == true && TestUse("frmCheckList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 0;
                bFlag = true;
            }

            if (strItem.Contains("���ε�") == true && TestUse("frmExchangeList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 1;
                bFlag = true;
            }

            if (strItem.Contains("��װ��") == true && TestUse("frmInstallList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 2;
                bFlag = true;
            }

            if (strItem.Contains("�������ֵ�") == true && TestUse("frmOtherInList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("�������ֵ�") == true && TestUse("frmOtherOutList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl4.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("�����ƻ�") == true && TestUse("frmProductPlanList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 0;
                bFlag = true;
            }


            if (strItem.Contains("��������") == true && TestUse("frmTaskList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 1;
                bFlag = true;
            }

            if (strItem.Contains("����״��") == true && TestUse("frmProductStatusList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 2;
                bFlag = true;
            }

            if (strItem.Contains("���ϵ�") == true && TestUse("frmDrawGoodsList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 3;
                bFlag = true;
            }

            if (strItem.Contains("���ϵ�") == true && TestUse("frmPatchGoodsList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 4;
                bFlag = true;
            }

            if (strItem.Contains("���ϵ�") == true && TestUse("frmBackGoodsList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 5;
                bFlag = true;
            }

            if (strItem.Contains("��Ʒ���ֵ�") == true && TestUse("frmProductInList") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 2;
                myWakeCenter.xtraTabControl5.SelectedTabPageIndex = 6;
                bFlag = true;
            }

            if (strItem.Contains("֤��׼������") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 6;
                bFlag = true;
            }

            if (strItem.Contains("֤���ѹ���") == true)
            {
                myWakeCenter.xtraTabControl1.SelectedTabPageIndex = 7;
                bFlag = true;
            }


            if (bFlag == false)
                myWakeCenter.Dispose();
            else
            {
                myWakeCenter.ShowDialog();
                myWakeCenter.Dispose();
            }
        }

        private void lbMessage_Click(object sender, EventArgs e)
        {
            myApp.ShowForm(lbMessage.Text);
        }

        private void lbOper_Click(object sender, EventArgs e)
        {
            myApp.ShowForm(lbOper.Text);
        }

        private void ListWake_DrawItem(object sender, DrawItemEventArgs e)
        {
         
        }

        private void ListWake_MouseDown(object sender, MouseEventArgs e)
        {

           
        }

    }
}

