using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace JXC
{
    public partial class frmMain : BaseClass.frmBase
    {
        public frmMain()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "DiamondBlue.ssk";//Ĭ�Ͻ���
            //if (DataLib.SysVar.bReg == false)
            //   this.Text = this.Text + "--���ð�";
            //else
                this.Text = this.Text + "--��ʽ��";
        }

        /// <summary>
        /// ���Բ���ϵͳ�Ƿ�����
        /// </summary>
        private bool TestcwInit()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_cwInit from t_CompanyInfo");
            if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == false)
            {
                MessageBox.Show("��ѡ���ò���ϵͳ��", "��ʾ");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        /// <returns></returns>
        private bool TestRight(string strClass)
        {
            if (DataLib.SysVar.strUGroup== "�����û�") return true;
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + strClass + "' and F_Name = '����' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("�Բ�������Ȩ��!!", "��ʾ");
                return false;
            }
            else
                return true;
        }

        private void SetStatus()
        {
            StatusBar.VisibleLinks[1].Caption = "�û�:" + DataLib.SysVar.strUName;
            StatusBar.VisibleLinks[2].Caption = "����:" + DataLib.SysVar.GetDate().ToShortDateString();
            barButtonItem95.Caption = "����:" + DataLib.SysVar.strAccount;
        }

        /// <summary>
        /// ���µ�¼��
        /// </summary>
        private void ReLogin()
        {
            frmLogin myLogin = new frmLogin();
            if (myLogin.ShowDialog() == DialogResult.OK)
                SetStatus();
            myLogin.Dispose();

            frmMain_Shown(null, null);


            foreach (Form myForm in this.MdiChildren)
            {
                if (myForm.Name == "frmBack")
                {
                    myForm.Dispose();
                }
            }

            ShowBack();

           
        }
        
        /// <summary>
        /// �򿪵���ͼ
        /// </summary>
        private void ShowBack()
        {

            foreach (Form myForm in this.MdiChildren)
            {
                if (myForm.Name == "frmBack")
                {
                    myForm.Activate();
                    return;
                }
            }


            frmBack myBack = new frmBack();
            myBack.myApp = this;
            myBack.MdiParent = this;
            myBack.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetLinkEvent();
                ShowBack();
                SetStatus();
                SetIniStatus();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "����");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "����˳���ϵͳ��?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
            else
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                myHelper.ExecuteSQL("update t_User set F_Login = 0 where F_ID = '" + DataLib.SysVar.strUID + "'");
            }
        }

        private void bExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        public void ShowForm(string strFlag)
        {
            switch (strFlag)
            {
                case "��˾��Ϣ":
                    if (IsOpenAs("frmCompanyInfo") == false)
                    {
                        Sys.frmCompanyInfo myCompany = new Sys.frmCompanyInfo();
                        myCompany.Edit("");
                        if (myCompany.ShowDialog() == DialogResult.OK)
                            SetIniStatus();
                        myCompany.Dispose();
                    }
                    break;
                case "ϵͳ����":
                    if (IsOpenAs("frmParm") == false)
                    {
                        Sys.frmParm myParm = new Sys.frmParm();
                        myParm.ShowDialog();
                        myParm.Dispose();
                        DataLib.SysVar.intIndex = DataLib.SysVar.GetIntParmValue("F_C1");
                    }
                    break;
                case "�Զ��屨��":
                    if (IsOpenAs("frmUserReport") == false)
                    {
                        UserReport.frmUserReport myUserReport = new UserReport.frmUserReport();
                        myUserReport.MdiParent = this;
                        myUserReport.Show();
                    }
                    break;
                case "�û������":
                    if (IsOpenAs("frmUGroup") == false)
                    {
                        Sys.frmRight myRight = new Sys.frmRight();
                        myRight.ShowDialog();
                        myRight.Dispose();
                    }
                    /*
                    if (IsOpenAs("frmUGroup") == false)
                    {
                        Sys.frmUGroup myUGroup = new Sys.frmUGroup();
                        myUGroup.MdiParent = this;
                        myUGroup.Show();
                    }
                     */ 
                    break;
                case "�û�����":
                    if (IsOpenAs("frmUser") == false)
                    {
                        Sys.frmUser myUser = new Sys.frmUser();
                        myUser.ShowDialog();
                        myUser.Dispose();
                    }
                    break;
                case "�û���ϸȨ��":
                    if (IsOpenAs("frmRightDetail") == false)
                    {
                        Sys.frmRightDetail myRightDetail = new Sys.frmRightDetail();
                        myRightDetail.ShowDialog();
                        myRightDetail.Dispose();
                    }
                    break;
                case "ϵͳ��־":
                    if (IsOpenAs("frmSysLog") == false)
                    {
                        Sys.frmSysLog mySysLog = new Sys.frmSysLog();
                        mySysLog.MdiParent = this;
                        mySysLog.Show();
                    }
                    break;
                case "�������":
                    if (IsOpenAs("frmNotice") == false)
                    {
                        Sys.frmNotice myNotice = new Sys.frmNotice();
                        myNotice.MdiParent = this;
                        myNotice.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmDataExport") == false)
                    {
                        Sys.frmDataExport myDataExport = new Sys.frmDataExport();
                        myDataExport.ShowDialog();
                        myDataExport.Dispose();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmDataImport") == false)
                    {
                        Sys.frmDataImport myDataImport = new Sys.frmDataImport();
                        myDataImport.ShowDialog();
                        myDataImport.Dispose();
                    }
                    break;
                case "�������":
                    if (IsOpenAs("frmClearData") == false)
                    {
                        Sys.frmClearData myClearData = new Sys.frmClearData();
                        myClearData.ShowDialog();
                        myClearData.Dispose();
                        SetIniStatus();
                    }
                    break;
                case "ϵͳ�������":
                    if (IsOpenAs("frmBillCode") == false)
                    {
                        Sys.frmBillCode myBillCode = new Sys.frmBillCode();
                        myBillCode.MdiParent = this;
                        myBillCode.Show();
                    }
                    break;
                case "���µ�¼":   
                    ReLogin();
                    break;
                case "�������":
                    if (IsOpenAs("frmStoreReCal") == false)
                    {
                        Sys.frmStoreReCal myStoreReCal = new Sys.frmStoreReCal();
                        myStoreReCal.ShowDialog();
                        myStoreReCal.Dispose();
                    }
                    break;
                case "ϵͳ����":
                    if (IsOpenAs("frmWakeCenter") == false)
                    {
                        Sys.frmWakeCenter myWakeCenter = new Sys.frmWakeCenter();
                        myWakeCenter.MdiParent = this;
                        myWakeCenter.Show();
                    }
                    break;

           ////////////��������/////////////////

                case "��Ӧ������":
                    if (IsOpenAs("frmSupplier") == false)
                    {
                        Base.frmSupplier mySupplier = new Base.frmSupplier();
                        mySupplier.MdiParent = this;
                        mySupplier.Show();
                    }
                    break;
                case "�ͻ�����":
                    if (IsOpenAs("frmClient") == false)
                    {
                        Base.frmClient myClient = new Base.frmClient();
                        myClient.MdiParent = this;
                        myClient.Show();
                    }
                    break;
                case "ְԱ����":
                    if (IsOpenAs("frmEmp") == false)
                    {
                        Base.frmEmp myEmp = new Base.frmEmp();
                        myEmp.MdiParent = this;
                        myEmp.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmItem") == false)
                    {
                        Base.frmItem myItem = new Base.frmItem();
                        myItem.MdiParent = this;
                        myItem.Show();
                    }
                    break;
                case "��Ʒ����":
                    if (IsOpenAs("frmProduct") == false)
                    {
                        Base.frmProduct myProduct = new Base.frmProduct();
                        myProduct.MdiParent = this;
                        myProduct.Show();
                    }
                    break;
                case "�ֿ�����":
                    if (IsOpenAs("frmStorage") == false)
                    {
                        Base.frmStorage myStorage = new Base.frmStorage();
                        myStorage.MdiParent = this;
                        myStorage.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmFactory") == false)
                    {
                        Base.frmFactory myFactory = new Base.frmFactory();
                        myFactory.MdiParent = this;
                        myFactory.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmWorkGroup") == false)
                    {
                        Base.frmWorkGroup myWorkGroup = new Base.frmWorkGroup();
                        myWorkGroup.MdiParent = this;
                        myWorkGroup.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmProcess") == false)
                    {
                        Base.frmProcess myProcess = new Base.frmProcess();
                        myProcess.MdiParent = this;
                        myProcess.Show();
                    }
                    break;
                case "���˹�˾����":
                    if (IsOpenAs("frmCarryCompany") == false)
                    {
                        Base.frmCarryCompany myCarryCompany = new Base.frmCarryCompany();
                        myCarryCompany.MdiParent = this;
                        myCarryCompany.Show();
                    }
                    break;
                case "��ӹ�����":
                    if (IsOpenAs("frmOutSupplier") == false)
                    {
                        Base.frmOutSupplier myOutSupplier = new Base.frmOutSupplier();
                        myOutSupplier.MdiParent = this;
                        myOutSupplier.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmCraftwork") == false)
                    {
                        Base.frmCraftwork myCraftwork = new Base.frmCraftwork();
                        myCraftwork.MdiParent = this;
                        myCraftwork.Show();
                    }
                    break;
                case "��Ʒ����滮":
                    if (IsOpenAs("frmProductProcess") == false)
                    {
                        Base.frmProductProcessList myProductProcessList = new Base.frmProductProcessList();
                        myProductProcessList.MdiParent = this;
                        myProductProcessList.Show();
                    }
                    break;
                case "���㷽ʽ":
                    if (IsOpenAs("frmBalanceType") == false)
                    {
                        Sys.frmBalanceType myBalanceType = new Sys.frmBalanceType();
                        myBalanceType.ShowDialog();
                        myBalanceType.Dispose();
                    }
                    break;
                case "��Ʒ֤��":
                    if (IsOpenAs("frmCertificate") == false)
                    {
                        Base.frmCast myCertificate = new Base.frmCast();
                        myCertificate.MdiParent = this;
                        myCertificate.Show();
                    }
                    break;
                    
                case "��������":
                    if (IsOpenAs("frmAssistBase") == false)
                    {
                        Base.frmAssistBase myAssist = new Base.frmAssistBase();
                        myAssist.MdiParent = this;
                        myAssist.Show();
                    }
                    break;

          //////////������/////////////////

                case "�ɹ�����":
                    if (IsOpenAs("frmStockPrice") == false)
                    {
                        Base.frmStockPrice myStockPrice = new Base.frmStockPrice();
                        myStockPrice.MdiParent = this;
                        myStockPrice.Show();
                    }
                    break;
                case "�깺��":   
                    if (IsOpenAs("frmApplyStockList") == false)
                    {
                        Stock.frmApplyStockList myApplyStockList = new Stock.frmApplyStockList();
                        myApplyStockList.MdiParent = this;
                        myApplyStockList.Show();
                    }
                    break;
                case "�ɹ�����":    
                    if (IsOpenAs("frmStockOrderList") == false)
                    {
                        Stock.frmStockOrderList myStockOrderList = new Stock.frmStockOrderList();
                        myStockOrderList.MdiParent = this;
                        myStockOrderList.Show();
                    }
                    break;
                case "�ɹ�����":   
                    if (IsOpenAs("frmStockInList") == false)
                    {
                        Stock.frmStockInList myStockInList = new Stock.frmStockInList();
                        myStockInList.MdiParent = this;
                        myStockInList.Show();
                    }
                    break;
                case "�ɹ�����":    
                    if (IsOpenAs("frmStockPayList") == false)
                    {
                        Stock.frmStockPayList myStockPayList = new Stock.frmStockPayList();
                        myStockPayList.MdiParent = this;
                        myStockPayList.Show();
                    }
                    break;
                case "�ɹ��˻�":  
                    if (IsOpenAs("frmStockBackList") == false)
                    {
                        Stock.frmStockBackList myStockBackList = new Stock.frmStockBackList();
                        myStockBackList.MdiParent = this;
                        myStockBackList.Show();
                    }
                    break;
                case "���۶���":
                    if (IsOpenAs("frmReSellPriceList") == false)
                    {
                        Sell.frmReSellPriceList myReSellPriceList = new Sell.frmReSellPriceList();
                        myReSellPriceList.MdiParent = this;
                        myReSellPriceList.Show();
                    }
                    break;
                case "ѯ�۵�":
                    if (IsOpenAs("frmAskPriceList") == false)
                    {
                        Sell.frmAskPriceList myAskPriceList = new Sell.frmAskPriceList();
                        myAskPriceList.MdiParent = this;
                        myAskPriceList.Show();
                    }
                    break;
                case "���۵�":   
                    if (IsOpenAs("frmSellPriceList") == false)
                    {
                        Sell.frmSellPriceList mySellPriceList = new Sell.frmSellPriceList();
                        mySellPriceList.MdiParent = this;
                        mySellPriceList.Show();
                    }
                    break;
                case "�ͻ�����":   
                    if (IsOpenAs("frmSellOrderList") == false)
                    {
                        Sell.frmSellOrderList mySellOrderList = new Sell.frmSellOrderList();
                        mySellOrderList.MdiParent = this;
                        mySellOrderList.Show();
                    }
                    break;
                case "����֪ͨ��":  
                    if (IsOpenAs("frmSellPreList") == false)
                    {
                        Sell.frmSellPreList mySellPreList = new Sell.frmSellPreList();
                        mySellPreList.MdiParent = this;
                        mySellPreList.Show();
                    }
                    break;
                case "������":
                    if (IsOpenAs("frmSellOutList") == false)/////////���
                    {
                        Sell.frmSellOutList mySellout = new Sell.frmSellOutList();
                        mySellout.MdiParent = this;
                        mySellout.Show();
                    }
                    break;
                case "���۵�": 
                    if (IsOpenAs("frmSellOutList") == false)
                    {
                        Sell.frmSellOutList mySellOutList = new Sell.frmSellOutList();
                        mySellOutList.MdiParent = this;
                        mySellOutList.Show();
                    }
                    break;
                case "�տ":
                    if (IsOpenAs("frmSellAcceptList") == false)
                    {
                        Sell.frmSellAcceptList mySellAcceptList = new Sell.frmSellAcceptList();
                        mySellAcceptList.MdiParent = this;
                        mySellAcceptList.Show();
                    }
                    break;
                case "�ͻ�����":
                    if (IsOpenAs("frmClientFee") == false)
                    {
                        Sell.frmClientFee myClientFee = new Sell.frmClientFee();
                        myClientFee.MdiParent = this;
                        myClientFee.Show();
                    }
                    break;
                case "�����˻�":  
                    if (IsOpenAs("frmSellBackList") == false)
                    {
                        Sell.frmSellBackList mySellBackList = new Sell.frmSellBackList();
                        mySellBackList.MdiParent = this;
                        mySellBackList.Show();
                    }
                    break;
                case "�̵㵥":   
                    if (IsOpenAs("frmCheckList") == false)
                    {
                        Storage.frmCheckList mySellCheckList = new Storage.frmCheckList();
                        mySellCheckList.MdiParent = this;
                        mySellCheckList.Show();
                    }
                    break;
                case "���ε�":    
                    if (IsOpenAs("frmExchangeList") == false)
                    {
                        Storage.frmExchangeList myExchangeList = new Storage.frmExchangeList();
                        myExchangeList.MdiParent = this;
                        myExchangeList.Show();
                    }
                    break;
                case "��װ��":   
                    if (IsOpenAs("frmInstallList") == false)
                    {
                        Storage.frmInstallList myInstallList = new Storage.frmInstallList();
                        myInstallList.MdiParent = this;
                        myInstallList.Show();
                    }
                    break;
                case "�������ֵ�":    
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "�������";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "�������ֵ�":  
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "��������";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "�ɹ���ⵥ":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "�ɹ��������";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "�����˻����":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "�����˻����";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "������ⵥ":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "�����������";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "�����깤���":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "�����깤���";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "ί���������":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "ί���������";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "ί���깤���":
                    if (IsOpenAs("frmOtherInList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 0;
                        myOtherInOutList.strSelectValue = "ί���깤���";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "�������ⵥ":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "���۷�������";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "�ɹ��˻�����":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "�ɹ��˻�����";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "�����˻�����":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "�����˻�����";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "���ϳ��ⵥ":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "�������ϳ���";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "���ϳ��ⵥ":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "�������ϳ���";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "ί�����ϳ���":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "ί�����ϳ���";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "ί���˻�����":
                    if (IsOpenAs("frmOtherOutList") == false)
                    {
                        Storage.frmOtherInOutList myOtherInOutList = new Storage.frmOtherInOutList();
                        myOtherInOutList.intTag = 1;
                        myOtherInOutList.strSelectValue = "ί���˻�����";
                        myOtherInOutList.MdiParent = this;
                        myOtherInOutList.Show();
                    }
                    break;
                case "���ϵ�":   
                    if (IsOpenAs("frmDrawGoodsList") == false)
                    {
                        Product.frmDrawGoodsList myDrawGoodsList = new Product.frmDrawGoodsList();
                        myDrawGoodsList.MdiParent = this;
                        myDrawGoodsList.Show();
                    }
                    break;
                case "���ϵ�": 
                    if (IsOpenAs("frmPatchGoodsList") == false)
                    {
                        Product.frmPatchGoodsList myPatchGoodsList = new Product.frmPatchGoodsList();
                        myPatchGoodsList.MdiParent = this;
                        myPatchGoodsList.Show();
                    }
                    break;
                case "���ϵ�":   
                    if (IsOpenAs("frmBackGoodsList") == false)
                    {
                        Product.frmBackGoodsList myBackGoodsList = new Product.frmBackGoodsList();
                        myBackGoodsList.MdiParent = this;
                        myBackGoodsList.Show();
                    }
                    break;
                case "�����깤��":  
                    if (IsOpenAs("frmProductInList") == false)
                    {
                        Product.frmProductInList myProductInList = new Product.frmProductInList();
                        myProductInList.MdiParent = this;
                        myProductInList.Show();
                    }
                    break;
                case "ʵʱ���":   
                    if (IsOpenAs("frmStorageQty") == false)
                    {
                        Storage.frmStorageQty myStorageQty = new Storage.frmStorageQty();
                        myStorageQty.MdiParent = this;
                        myStorageQty.Show();
                    }
                    break;
                case "������":
                    if (IsOpenAs("frmCheckOut") == false)
                    {
                        Sys.frmCheckOut myCheckOut = new Sys.frmCheckOut();
                        myCheckOut.ShowDialog();
                        myCheckOut.Dispose();
                    }
                    break;
                case "�������ݲ�ѯ":   
                    if (IsOpenAs("frmCheckOutQuery") == false)
                    {
                        Report.frmCheckOutQuery myCheckOutQuery = new Report.frmCheckOutQuery();
                        myCheckOutQuery.MdiParent = this;
                        myCheckOutQuery.Show();
                    }
                    break;
                case "ҵ�����":
                    if (IsOpenAs("frmFindBill") == false)
                    {
                        frmFindBill myFindBill = new frmFindBill();
                        myFindBill.ShowDialog();
                        myFindBill.Dispose();
                    }
                    break;

            //////////��������////////////  
 
                case "�����嵥":
                    if (IsOpenAs("frmBom") == false)
                    {
                        Product.frmBom myBom = new Product.frmBom();
                        myBom.MdiParent = this;
                        myBom.Show();
                    }
                    break;
                case "MRP����":
                    if (IsOpenAs("frmMRP") == false)
                    {
                        Stock.frmMRP myMRP = new Stock.frmMRP();
                        myMRP.ShowDialog();
                        myMRP.Dispose();
                    }
                    break;
                case "�ų̲���":
                    if (IsOpenAs("frmArrangeDept") == false)
                    {
                        Product.frmArrangeDept myArrangeDept = new Product.frmArrangeDept();
                        myArrangeDept.ShowDialog();
                        myArrangeDept.Dispose();
                    }
                    break;
                case "�����ų�":
                    if (IsOpenAs("frmProductArrange") == false)
                    {
                        Product.frmProductArrange myProductArrange = new Product.frmProductArrange();
                        myProductArrange.MdiParent = this;
                        myProductArrange.Show();
                    }
                    break;
                case "�����ƻ���":
                    if (IsOpenAs("frmProductPlanList") == false)
                    {
                        Product.frmProductPlanList myProductPlanList = new Product.frmProductPlanList();
                        myProductPlanList.MdiParent = this;
                        myProductPlanList.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmTaskList") == false)
                    {
                        Product.frmTaskList myTaskList = new Product.frmTaskList();
                        myTaskList.MdiParent = this;
                        myTaskList.Show();
                    }
                    break;
                case "����״����":
                    if (IsOpenAs("frmProductStatusList") == false)
                    {
                        Product.frmProductStatusList myProductStatusList = new Product.frmProductStatusList();
                        myProductStatusList.MdiParent = this;
                        myProductStatusList.Show();
                    }
                    break;
                case "�ʼ쵥":
                    if (IsOpenAs("frmQcList") == false)
                    {
                        Product.frmQcList myQcList = new Product.frmQcList();
                        myQcList.MdiParent = this;
                        myQcList.Show();
                    }
                    break;

                case "�������ٱ�":                
                    if (IsOpenAs("frmOutPayList") == false)/////////����
                    {
                        Product.frmProductotal myProductotalList = new Product.frmProductotal();
                        myProductotalList.MdiParent = this;
                        myProductotalList.Show();
                    }
                    break;
                case "��Ʒ���ֵ�"://///////////����

                    break;


                ///////////ί��ӹ�///////////

                case "ί��ӹ���":
                    if (IsOpenAs("frmOutBillList") == false)
                    {
                        OutProduct.frmOutBillList myOutBillList = new OutProduct.frmOutBillList();
                        myOutBillList.MdiParent = this;
                        myOutBillList.Show();
                    }
                    break;
                case "ί�����ϵ�":
                    if (IsOpenAs("frmOutDrawGoodsList") == false)
                    {
                        OutProduct.frmOutDrawGoodsList myOutDrawGoodsList = new OutProduct.frmOutDrawGoodsList();
                        myOutDrawGoodsList.MdiParent = this;
                        myOutDrawGoodsList.Show();
                    }
                    break;
                case "ί�����ϵ�":
                    if (IsOpenAs("frmOutBackGoodsList") == false)
                    {
                        OutProduct.frmOutBackGoodsList myOutBackGoodsList = new OutProduct.frmOutBackGoodsList();
                        myOutBackGoodsList.MdiParent = this;
                        myOutBackGoodsList.Show();
                    }
                    break;
                case "ί����ⵥ":
                    if (IsOpenAs("frmOutInStoreList") == false)
                    {
                        OutProduct.frmOutInStoreList myOutInStoreList = new OutProduct.frmOutInStoreList();
                        myOutInStoreList.MdiParent = this;
                        myOutInStoreList.Show();
                    }
                    break;
                case "ί���˻���":
                    if (IsOpenAs("frmOutBackStoreList") == false)
                    {
                        OutProduct.frmOutBackStoreList myOutBackStoreList = new OutProduct.frmOutBackStoreList();
                        myOutBackStoreList.MdiParent = this;
                        myOutBackStoreList.Show();
                    }
                    break;
                case "ί�⸶�":
                    if (IsOpenAs("frmOutPayList") == false)
                    {
                        OutProduct.frmOutPayList myOutPayList = new OutProduct.frmOutPayList();
                        myOutPayList.MdiParent = this;
                        myOutPayList.Show();
                    }
                    break;
               

                ///////////���ʹ���///////////

                case "������Ŀ�趨":
                    if (IsOpenAs("frmWageItem") == false)
                    {
                        Wage.frmWageItem myWageItem = new Wage.frmWageItem();
                        myWageItem.ShowDialog();
                        myWageItem.Dispose();
                    }
                    break;
                case "������ת����":
                    if (IsOpenAs("frmWageCheckOut") == false)
                    {
                        Wage.frmWageCheckOut myWageCheckOut = new Wage.frmWageCheckOut();
                        myWageCheckOut.ShowDialog();
                        myWageCheckOut.Dispose();
                    }
                    break;
                case "�Ƽ�����¼��":
                    if (IsOpenAs("frmWageInput") == false)
                    {
                        Wage.frmWageInput myWageInput = new Wage.frmWageInput();
                        myWageInput.MdiParent = this;
                        myWageInput.Show();
                    }                   
                    break;
                case "���¹���¼��":
                    if (IsOpenAs("frmMonthWage") == false)
                    {
                        Wage.frmMonthWage myMonthWage = new Wage.frmMonthWage();
                        myMonthWage.MdiParent = this;
                        myMonthWage.Show();
                    }
                    break;
                case "���ʷ��ű�":  
                    if (IsOpenAs("frmGiffWage") == false)
                    {
                        Wage.frmGiffWage myGiffWage = new Wage.frmGiffWage();
                        myGiffWage.MdiParent = this;
                        myGiffWage.Show();
                    }
                    break;
                case "����Ƽ�¼��":
                    if (IsOpenAs("frmWageGroupInput") == false)
                    {
                        Wage.frmWageGroupInput myWageGroupInput = new Wage.frmWageGroupInput();
                        myWageGroupInput.MdiParent = this;
                        myWageGroupInput.Show();
                    }
                    break;

                case "����Ƽ�ͳ��":
                    if (IsOpenAs("frmGroupWage") == false)
                    {
                        Wage.frmGroupWage myWageQuery = new Wage.frmGroupWage();
                        myWageQuery.MdiParent = this;
                        myWageQuery.Show();
                    }
                    break;

         ///////////ͳ�Ʊ���///////////

                case "�ɹ�����ִ�������":
                    if (IsOpenAs("frmStockOrderExe") == false)
                    {
                        Report.frmStockOrderExe myStockOrderExe = new Report.frmStockOrderExe();
                        myStockOrderExe.MdiParent = this;
                        myStockOrderExe.Show();
                    }
                    break;
                case "��Ӧ�̹�������":
                    if (IsOpenAs("frmSupplierReport") == false)
                    {
                        Report.frmSupplierReport mySupplierReport = new Report.frmSupplierReport();
                        mySupplierReport.MdiParent = this;
                        mySupplierReport.Show();
                    }
                    break;
                case "��Ʒ�ɹ�����":
                    if (IsOpenAs("frmItemStockReport") == false)
                    {
                        Report.frmItemStockReport myItemStockReport = new Report.frmItemStockReport();
                        myItemStockReport.MdiParent = this;
                        myItemStockReport.Show();
                    }
                    break;
                case "�ɹ��걨��":
                    if (IsOpenAs("frmStockYearReport") == false)
                    {
                        Report.frmStockYearReport myStockYearReport = new Report.frmStockYearReport();
                        myStockYearReport.MdiParent = this;
                        myStockYearReport.Show();
                    }
                    break;
                case "Ӧ�����":
                    if (IsOpenAs("frmPayReport") == false)
                    {
                        Report.frmPayReport myPayReport = new Report.frmPayReport();
                        myPayReport.MdiParent = this;
                        myPayReport.Show();
                    }
                    break;
                case "Ӧ�����ʱ�":
                    if (IsOpenAs("frmPayAccount") == false)
                    {
                        Report.frmPayAccount myPayAccount = new Report.frmPayAccount();
                        myPayAccount.MdiParent = this;
                        myPayAccount.Show();
                    }
                    break;
                case "Ӧ���������":
                    if (IsOpenAs("frmPayAge") == false)
                    {
                        Report.frmPayAge myPayAge = new Report.frmPayAge();
                        myPayAge.MdiParent = this;
                        myPayAge.Show();
                    }
                    break;
                case "�ͻ�����ִ�������":
                    if (IsOpenAs("frmSellOrderExe") == false)
                    {
                        Report.frmSellOrderExe mySellOrderExe = new Report.frmSellOrderExe();
                        mySellOrderExe.MdiParent = this;
                        mySellOrderExe.Show();
                    }
                    break;
                case "�ͻ����۱���":
                    if (IsOpenAs("frmClientReport") == false)
                    {
                        Report.frmClientReport myClientReport = new Report.frmClientReport();
                        myClientReport.MdiParent = this;
                        myClientReport.Show();
                    }
                    break;
                case "ҵ��Ա���۱���":
                    if (IsOpenAs("frmOpertorReport") == false)
                    {
                        Report.frmOpertorReport myOpertorReport = new Report.frmOpertorReport();
                        myOpertorReport.MdiParent = this;
                        myOpertorReport.Show();
                    }
                    break;
                case "��Ʒ���۱���":
                    if (IsOpenAs("frmItemSellReport") == false)
                    {
                        Report.frmItemSellReport myItemSellReport = new Report.frmItemSellReport();
                        myItemSellReport.MdiParent = this;
                        myItemSellReport.Show();
                    }
                    break;
                case "��Ʒ���������":
                    if (IsOpenAs("frmItemProfitReport") == false)
                    {
                        Report.frmItemProfitReport myItemProfitReport = new Report.frmItemProfitReport();
                        myItemProfitReport.MdiParent = this;
                        myItemProfitReport.Show();
                    }
                    break;
                case "�����걨��":
                    if (IsOpenAs("frmSellYearReport") == false)
                    {
                        Report.frmSellYearReport mySellYearReport = new Report.frmSellYearReport();
                        mySellYearReport.MdiParent = this;
                        mySellYearReport.Show();
                    }
                    break;
                case "�������۱���":
                    if (IsOpenAs("frmAreaSellReport") == false)
                    {
                        Report.frmAreaSellReport myAreaSellReport = new Report.frmAreaSellReport();
                        myAreaSellReport.MdiParent = this;
                        myAreaSellReport.Show();
                    }
                    break;
                case "Ӧ�տ��":
                    if (IsOpenAs("frmAcceptReport") == false)
                    {
                        Report.frmAcceptReport myAcceptReport = new Report.frmAcceptReport();
                        myAcceptReport.MdiParent = this;
                        myAcceptReport.Show();
                    }
                    break;
                case "Ӧ�տ��ʱ�":
                    if (IsOpenAs("frmAcceptAccount") == false)
                    {
                        Report.frmAcceptAccount myAcceptAccount = new Report.frmAcceptAccount();
                        myAcceptAccount.MdiParent = this;
                        myAcceptAccount.Show();
                    }
                    break;
                case "Ӧ���������":
                    if (IsOpenAs("frmAcceptAge") == false)
                    {
                        Report.frmAcceptAge myAcceptAge = new Report.frmAcceptAge();
                        myAcceptAge.MdiParent = this;
                        myAcceptAge.Show();
                    }
                    break;
                case "��汨������":
                    if (IsOpenAs("frmStoreLimit") == false)
                    {
                        Report.frmStoreLimit myStoreLimit = new Report.frmStoreLimit();
                        myStoreLimit.MdiParent = this;
                        myStoreLimit.Show();
                    }
                    break;
                case "���Ͻ�������ܱ�":
                    if (IsOpenAs("frmStorageSum") == false)
                    {
                        Report.frmStorageSum myStorageSum = new Report.frmStorageSum();
                        myStorageSum.MdiParent = this;
                        myStorageSum.Show();
                    }
                    break;
                case "���Ͻ�������ϸ��":
                    if (IsOpenAs("frmStorageDetail") == false)
                    {
                        Report.frmStorageDetail myStorageDetail = new Report.frmStorageDetail();
                        myStorageDetail.MdiParent = this;
                        myStorageDetail.Show();
                    }
                    break;
                case "�豸ά������":
                    if (IsOpenAs("frmRepairDeviceReport") == false)
                    {
                        Report.frmRepairDeviceReport myRepairDeviceReport = new Report.frmRepairDeviceReport();
                        myRepairDeviceReport.MdiParent = this;
                        myRepairDeviceReport.Show();
                    }
                    break;

                    
                case "����ִ�������":
                    if (IsOpenAs("frmTaskExe") == false)
                    {
                        Report.frmTaskExe myTaskExe = new Report.frmTaskExe();
                        myTaskExe.MdiParent = this;
                        myTaskExe.Show();
                    }
                    break;
                case "�������������":
                    if (IsOpenAs("frmItemDrawReport") == false)
                    {
                        Report.frmItemDrawReport myItemDrawReport = new Report.frmItemDrawReport();
                        myItemDrawReport.MdiParent = this;
                        myItemDrawReport.Show();
                    }
                    break;
                case "�������ٱ�":
                    if (IsOpenAs("frmProductTract") == false)
                    {
                        Report.frmProductTract myProductTract = new Report.frmProductTract();
                        myProductTract.MdiParent = this;
                        myProductTract.Show();
                    }
                    break;
                case "��Ʒά�޵�":
                    if (IsOpenAs("frmRepairList") == false)
                    {
                        Product.frmRepairList myRepairList = new Product.frmRepairList();
                        myRepairList.MdiParent = this;
                        myRepairList.Show();
                    }
                    break;
                case "ά�����ϵ�":
                    if (IsOpenAs("frmRepairDrawGoodsList") == false)
                    {
                        Product.frmRepairDrawGoodsList myRepairDrawGoodsList = new Product.frmRepairDrawGoodsList();
                        myRepairDrawGoodsList.MdiParent = this;
                        myRepairDrawGoodsList.Show();
                    }
                    break;
                case "�����ɱ�����":
                    if (IsOpenAs("frmProductCost") == false)
                    {
                        Report.frmProductCost myProductCost = new Report.frmProductCost();
                        myProductCost.MdiParent = this;
                        myProductCost.Show();
                    }
                    break;
                case "�����ձ���":
                    if (IsOpenAs("frmProductDayReport") == false)
                    {
                        Report.frmProductDayReport myProductDayReport = new Report.frmProductDayReport();
                        myProductDayReport.MdiParent = this;
                        myProductDayReport.Show();
                    }
                    break;
                case "��ӹ���ִ�������":
                    if (IsOpenAs("frmOutBillExe") == false)
                    {
                        Report.frmOutBillExe myOutBillExe = new Report.frmOutBillExe();
                        myOutBillExe.MdiParent = this;
                        myOutBillExe.Show();
                    }
                    break;
                case "��ӹ����������":
                    if (IsOpenAs("frmOutDrawReport") == false)
                    {
                        Report.frmOutDrawReport myOutDrawReport = new Report.frmOutDrawReport();
                        myOutDrawReport.MdiParent = this;
                        myOutDrawReport.Show();
                    }
                    break;
                case "��ӹ����ñ���":
                    if (IsOpenAs("frmOutPayReport") == false)
                    {
                        Report.frmOutPayReport myOutPayReport = new Report.frmOutPayReport();
                        myOutPayReport.MdiParent = this;
                        myOutPayReport.Show();
                    }
                    break;

                case "ҵ����":
                    if (IsOpenAs("frmOtherStorageQty") == false)
                    {
                        Storage.frmOtherStorageQty myOtherStorageQty = new Storage.frmOtherStorageQty();
                        myOtherStorageQty.MdiParent = this;
                        myOtherStorageQty.Show();
                    }
                    break;

                case "�ֿ���ˮ��":
                    if (IsOpenAs("frmSequence") == false)
                    {
                        Report.frmSequence mySequence = new Report.frmSequence();
                        mySequence.MdiParent = this;
                        mySequence.Show();
                    }
                    break;

                case "�豸�Ǽ�":
                    Card.frmRegDevice myDevice = new Card.frmRegDevice();
                    myDevice.ShowDialog();
                    myDevice.Dispose();
                    break;

                //case "��������":
                //    Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 0);
                //    /*
                //    Card.frmSetDevice mySetDevice = new Card.frmSetDevice();
                //    mySetDevice.ShowDialog();
                //    mySetDevice.Dispose();
                //     */ 
                //    break;

                case "��������":
                    Card.frmNetDevice myNetDevice = new Card.frmNetDevice();
                    myNetDevice.ShowDialog();
                    myNetDevice.Dispose();
                    break;

                case "U�̲���":
                    Card.frmNetDevice myNetDevice1 = new Card.frmNetDevice();
                    myNetDevice1.iFlag = 1;
                    myNetDevice1.ShowDialog();
                    myNetDevice1.Dispose();
                    break;

                case "ʵʱ�ɼ�":
                    //Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 3);
                    Card.frmRealPick myRealPick = new Card.frmRealPick();
                    myRealPick.ShowDialog();
                    myRealPick.Dispose();
                    break;
                case "��ʱ�ɼ�":
                    //Card.frmTimPick myTimPick = new Card.frmTimPick();
                    //myTimPick.ShowDialog();
                    //myTimPick.Dispose();
                    break;

                case "����趨":
                    Card.frmSetClass mySetClass = new Card.frmSetClass();
                    mySetClass.ShowDialog();
                    mySetClass.Dispose();
                    break;

                case "���ڹ���":
                    Card.frmKQRule myKQRule = new Card.frmKQRule();
                    myKQRule.ShowDialog();
                    myKQRule.Dispose();
                    break;

                case "ˢ����¼":
                    Card.frmCardReport myCardRecord = new Card.frmCardReport();
                    myCardRecord.ShowDialog();
                    myCardRecord.Dispose();
                    break;
                case "���ڻ��ܱ�":
                    Card.frmKQTotalReport myKQTotalReport = new Card.frmKQTotalReport();
                    myKQTotalReport.ShowDialog();
                    myKQTotalReport.Dispose();
                    break;
                case "�����ձ���":
                    Card.frmKQDayReport myKQDayReport = new Card.frmKQDayReport();
                    myKQDayReport.ShowDialog();
                    myKQDayReport.Dispose();
                    break;
                case "δˢ����Ա����":
                    Card.frmNoCardReport myNoCardReport = new Card.frmNoCardReport();
                    myNoCardReport.ShowDialog();
                    myNoCardReport.Dispose();
                    break;
                case "��ٵǼ�":
                    Card.frmRegLeave myRegLeave = new Card.frmRegLeave();
                    myRegLeave.ShowDialog();
                    myRegLeave.Dispose();
                    break;
                case "����Ǽ�":
                    Card.frmRegTravel myRegTravel = new Card.frmRegTravel();
                    myRegTravel.ShowDialog();
                    myRegTravel.Dispose();
                    break;
                case "���ݲ���":
                    Card.frmOtherRest myOtherRest = new Card.frmOtherRest();
                    myOtherRest.ShowDialog();
                    myOtherRest.Dispose();
                    break;
                case "�ֹ�����":
                    Card.frmUserCard myUserCard = new Card.frmUserCard();
                    myUserCard.ShowDialog();
                    myUserCard.Dispose();
                    break;
                case "ͣ������":
                    Card.frmRegStop myRegStop = new Card.frmRegStop();
                    myRegStop.ShowDialog();
                    myRegStop.Dispose();
                    break;
                case "Ա���Ű�":
                    Card.frmArrangeClass myArrangeClass = new Card.frmArrangeClass();
                    myArrangeClass.ShowDialog();
                    myArrangeClass.Dispose();
                    break;
                case "��������":
                    Card.frmReadEmpPic myReadEmpPic = new Card.frmReadEmpPic();
                    myReadEmpPic.ShowDialog();
                    myReadEmpPic.Dispose();
                    break;
                case "����":
                    Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 1);
                    /*
                    Card.frmSendCard mySendCard = new Card.frmSendCard();
                    mySendCard.ShowDialog();
                    mySendCard.Dispose();
                     */ 
                    break;
                case "�˿�":
                    Card.frmBackCard myBackCard = new Card.frmBackCard();
                    myBackCard.ShowDialog();
                    myBackCard.Dispose();
                    break;
                case "�˿�":
                    Card.frmBackMoney myBackMoney = new Card.frmBackMoney();
                    myBackMoney.ShowDialog();
                    myBackMoney.Dispose();
                    break;
                case "��ֵ":
                    Card.EastRiver.ShowForm(IntPtr.Zero, DataLib.SysVar.strCon, 1);
                    /*
                    Card.frmFillMoney myFillMoney = new Card.frmFillMoney();
                    myFillMoney.ShowDialog();
                    myFillMoney.Dispose();
                     */ 
                    break;
                case "��ʧ����":
                    Card.frmLostCard myLostCard = new Card.frmLostCard();
                    myLostCard.ShowDialog();
                    myLostCard.Dispose();
                    break;
                case "������¼":
                    Card.frmPreDinner myPreDinner = new Card.frmPreDinner();
                    myPreDinner.ShowDialog();
                    myPreDinner.Dispose();
                    break;
                case "�۷���¼":
                    Card.frmSellDinner mySellDinner = new Card.frmSellDinner();
                    mySellDinner.ShowDialog();
                    mySellDinner.Dispose();
                    break;
                case "�۷������":
                    Card.frmDinnerReport myDinnerReport = new Card.frmDinnerReport();
                    myDinnerReport.ShowDialog();
                    myDinnerReport.Dispose();
                    break;
                case "�����¼":
                    if (IsOpenAs("DispTelReport") == false)
                    {
                        Report.DispTelReport myTelReport = new Report.DispTelReport();
                        myTelReport.MdiParent = this;
                        myTelReport.Show();
                    }
                    break;
                case "��ƿ�Ŀ":
                    if (IsOpenAs("frmSubject") == false)
                    {
                        Finance.frmSubject mySubject = new Finance.frmSubject();
                        mySubject.ShowDialog();
                        mySubject.Dispose();
                    }
                    break;
                case "����ժҪ":
                    if (IsOpenAs("frmAbstract") == false)
                    {
                        Finance.frmAbstract myAbstract = new Finance.frmAbstract();
                        myAbstract.ShowDialog();
                        myAbstract.Dispose();
                    }
                    break;
                case "�ұ�":
                    if (IsOpenAs("frmCurrency") == false)
                    {
                        Finance.frmCurrency myCurrency = new Finance.frmCurrency();
                        myCurrency.MdiParent = this;
                        myCurrency.Show();
                    }
                    break;
                case "�ڳ����":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCWInit") == false)
                    {
                        Finance.frmCWInit myCWInit = new Finance.frmCWInit();
                        myCWInit.MdiParent = this;
                        myCWInit.Show();
                    }
                    break;
                case "��������":
                    if (IsOpenAs("frmFinanceInit") == false)
                    {
                        Finance.frmFinanceInit myFinanceInit = new Finance.frmFinanceInit();
                        myFinanceInit.ShowDialog();
                        myFinanceInit.Dispose();
                    }
                    break;
                case "ƾ֤¼��":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCertificate") == false)
                    {
                        Finance.frmCertificate myCertificate = new Finance.frmCertificate();
                        myCertificate.ShowDialog();
                        myCertificate.Dispose();
                    }
                    break;
                case "ƾ֤��ѯ":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCertificateList") == false)
                    {
                        Finance.frmCertificateList myCertificateList = new Finance.frmCertificateList();
                        myCertificateList.MdiParent = this;
                        myCertificateList.Show();
                    }
                    break;
                case "ƾ֤���":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCertificateList") == false)
                    {
                        Finance.frmCertificateList myCertificateList = new Finance.frmCertificateList();
                        myCertificateList.MdiParent = this;
                        myCertificateList.Show();
                    }
                    break;  
                case "ƾ֤����":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmRecordCf") == false)
                    {
                        Finance.frmRecordCf myRecordCf = new Finance.frmRecordCf();
                        myRecordCf.ShowDialog();
                        myRecordCf.Dispose();
                    }
                    break;
                case "��ĩ����":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCfCehckOut") == false)
                    {
                        Finance.frmCfCehckOut myCfCehckOut = new Finance.frmCfCehckOut();
                        myCfCehckOut.ShowDialog();
                        myCfCehckOut.Dispose();
                    }
                    break;
                case "��ת����":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmCheckLoss") == false)
                    {
                        Finance.frmCheckLoss myCheckLoss = new Finance.frmCheckLoss();
                        myCheckLoss.ShowDialog();
                        myCheckLoss.Dispose();
                    }
                    break;
                case "�ܷ�����":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFTotalReport") == false)
                    {
                        Finance.frmFTotalReport myFTotalReport = new Finance.frmFTotalReport();
                        myFTotalReport.MdiParent = this;
                        myFTotalReport.Show();
                    }
                    break;
                case "�ռ���":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFDayReport") == false)
                    {
                        Finance.frmFDayReport myFDayReport = new Finance.frmFDayReport();
                        myFDayReport.MdiParent = this;
                        myFDayReport.Show();
                    }
                    break;
                case "��ϸ������":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFDetailReport") == false)
                    {
                        Finance.frmFDetailReport myFDetailReport = new Finance.frmFDetailReport();
                        myFDetailReport.MdiParent = this;
                        myFDetailReport.Show();
                    }
                    break;
                case "����ʽ��ϸ��":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFMulDetailReport") == false)
                    {
                        Finance.frmFMulDetailReport myFMulDetailReport = new Finance.frmFMulDetailReport();
                        myFMulDetailReport.MdiParent = this;
                        myFMulDetailReport.Show();
                    }
                    break;
                case "��Ŀ���ܱ�":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFSubjectTotalReport") == false)
                    {
                        Finance.frmFSubjectTotalReport myFSubjectTotalReport = new Finance.frmFSubjectTotalReport();
                        myFSubjectTotalReport.MdiParent = this;
                        myFSubjectTotalReport.Show();
                    }
                    break;
                case "����ƽ���":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFTryCalReport") == false)
                    {
                        Finance.frmFTryCalReport myFTryCalReport = new Finance.frmFTryCalReport();
                        myFTryCalReport.MdiParent = this;
                        myFTryCalReport.Show();
                    }
                    break;

                case "�Զ�����񱨱�":
                    if (TestcwInit() == false) return;
                    ShowFinaceReport();
                    break;
                case "�ʲ���ծ��":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFdebtReport") == false)
                    {
                        Finance.frmFdebtReport myFdebtReport = new Finance.frmFdebtReport();
                        myFdebtReport.MdiParent = this;
                        myFdebtReport.Show();
                    }
                    break;
                case "�����":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFGainReport") == false)
                    {
                        Finance.frmFGainReport myFGainReport = new Finance.frmFGainReport();
                        myFGainReport.MdiParent = this;
                        myFGainReport.Show();
                    }
                    break;
                case "�����":
                    if (TestcwInit() == false) return;
                    if (IsOpenAs("frmFProfitReport") == false)
                    {
                        Finance.frmFProfitReport myFProfitReport = new Finance.frmFProfitReport();
                        myFProfitReport.MdiParent = this;
                        myFProfitReport.Show();
                    }
                    break;
                case "�ֽ��ʼ���":
                    if (IsOpenAs("frmIniCash") == false)
                    {
                        Cash.frmIniCash myIniCash = new Cash.frmIniCash();
                        myIniCash.ShowDialog();
                        myIniCash.Dispose();
                    }
                    break;
                case "���г�ʼ���":
                    if (IsOpenAs("frmIniBank") == false)
                    {
                        Cash.frmIniBank myIniBank = new Cash.frmIniBank();
                        myIniBank.ShowDialog();
                        myIniBank.Dispose();
                    }
                    break;
                case "�ֽ��ռ���":
                    if (IsOpenAs("frmCashList") == false)
                    {
                        Cash.frmCashList myFCashList = new Cash.frmCashList();
                        myFCashList.MdiParent = this;
                        myFCashList.Show();
                    }
                    break;
                case "�����ռ���":
                    if (IsOpenAs("frmBankList") == false)
                    {
                        Cash.frmBankList myBankList = new Cash.frmBankList();
                        myBankList.MdiParent = this;
                        myBankList.Show();
                    }
                    break;
                case "���ɽ���":
                    if (IsOpenAs("frmCashCheckOut") == false)
                    {
                        Cash.frmCashCheckOut myCashCheckOut = new Cash.frmCashCheckOut();
                        myCashCheckOut.ShowDialog();
                        myCashCheckOut.Dispose();
                    }
                    break;
                case "���ɽ��ʱ���":
                    if (IsOpenAs("frmCashCheckOutQuery") == false)
                    {
                        Report.frmCashCheckOutQuery myCashCheckOutQuery = new Report.frmCashCheckOutQuery();
                        myCashCheckOutQuery.MdiParent = this;
                        myCashCheckOutQuery.Show();
                    }
                    break;
                case "�ʲ����":
                    if (IsOpenAs("frmAssetType") == false)
                    {
                        Finance.frmAssetType myAssetType = new Finance.frmAssetType();
                        myAssetType.ShowDialog();
                        myAssetType.Dispose();
                    }
                    break;
                case "������ʽ":
                    if (IsOpenAs("frmAddType") == false)
                    {
                        Finance.frmAddType frmAddType = new Finance.frmAddType();
                        frmAddType.ShowDialog();
                        frmAddType.Dispose();
                    }
                    break;
                case "�ʲ�����":
                    if (IsOpenAs("frmAssetList") == false)
                    {
                        Finance.frmAssetList myAssetList = new Finance.frmAssetList();
                        myAssetList.MdiParent = this;
                        myAssetList.Show();
                    }
                    break;
                case "�ʲ�����":
                    if (IsOpenAs("frmAssetReduceList") == false)
                    {
                        Finance.frmAssetReduceList myAssetReduceList = new Finance.frmAssetReduceList();
                        myAssetReduceList.MdiParent = this;
                        myAssetReduceList.Show();
                    }
                    break;
                case "�����۾�":
                    CalAsset();
                    break;
                case "ʹ�����":
                    if (IsOpenAs("frmUseInfo") == false)
                    {
                        Finance.frmUseInfo myUseInfo = new Finance.frmUseInfo();
                        myUseInfo.ShowDialog();
                        myUseInfo.Dispose();
                    }
                    break;
                case "�̶��ʲ��嵥":
                    if (IsOpenAs("frmAssetReport") == false)
                    {
                        Finance.frmAssetReport myAssetReport = new Finance.frmAssetReport();
                        myAssetReport.MdiParent = this;
                        myAssetReport.Show();
                    }
                    break;
                case "�̶��ʲ��۾ɱ�":
                    if (IsOpenAs("frmAssetDepreReport") == false)
                    {
                        Finance.frmAssetDepreReport myAssetDepreReport = new Finance.frmAssetDepreReport();
                        myAssetDepreReport.MdiParent = this;
                        myAssetDepreReport.Show();
                    }
                    break;
                case "�̶��ʲ��ۼ��۾ɱ�":
                    if (IsOpenAs("frmAssetTotalOldReport") == false)
                    {
                        Finance.frmAssetTotalOldReport myAssetTotalOldReport = new Finance.frmAssetTotalOldReport();
                        myAssetTotalOldReport.MdiParent = this;
                        myAssetTotalOldReport.Show();
                    }
                    break;
                case "�ۼƹ�������ѯ":
                    if (IsOpenAs("frmWorkQueryReport") == false)
                    {
                        Finance.frmWorkQueryReport myWorkQueryReport = new Finance.frmWorkQueryReport();
                        myWorkQueryReport.MdiParent = this;
                        myWorkQueryReport.Show();
                    }
                    break;

                case "ͨ����Ϣ":
                    Sys.frmWakeNotice myWakeNotice = new Sys.frmWakeNotice();
                    myWakeNotice.ShowDialog();
                    myWakeNotice.Dispose();
                    break;
                case "���������":
                    Sys.MBAdrQueryForm mr = new Sys.MBAdrQueryForm();
                    mr.ShowDialog();
                    mr.Dispose();
                    break;
                case "���Ų�ѯ":
                    Sys.AreaCodeQueryForm AQF = new Sys.AreaCodeQueryForm();
                    AQF.ShowDialog();
                    AQF.Dispose();
                    break;
                case "�豸����":
                    if (IsOpenAs("frmDevice") == false)
                    {
                        Base.frmDevice myDeviceList = new Base.frmDevice();
                        myDeviceList.MdiParent = this;
                        myDeviceList.Show();
                    }
                    break;
                case "�豸ά��":
                    if (IsOpenAs("frmDeviceRepair") == false)
                    {
                        Base.frmDeviceRepair myDeviceRepair = new Base.frmDeviceRepair();
                        myDeviceRepair.MdiParent = this;
                        myDeviceRepair.Show();
                    }
                    break;
                case "�༶���":
                    if (IsOpenAs("frmMultCheck") == false)
                    {
                        Sys.frmMultCheck myMultCheck = new Sys.frmMultCheck();
                        myMultCheck.ShowDialog();
                        myMultCheck.Dispose();
                    }
                    break;


                case "���ο����ӿ�":
                    if (IsOpenAs("UserDesign") == false)
                    {
                        Common.UserDesign myUserDesign = new Common.UserDesign();
                        myUserDesign.MdiParent = this;
                        myUserDesign.Show();
                    }
                    break;
                case "���������":
                    if (IsOpenAs("DesignForm") == false)
                    {
                        DataLib.SysVar.blnDesignForm = true;
                        try
                        {

                            UserDesignForm.DesignForm myDesignForm = new UserDesignForm.DesignForm();
                            myDesignForm.ShowDialog();
                            myDesignForm.Dispose();
                        }
                        catch (Exception E)
                        {
                            MessageBox.Show(E.Message, "����");
                        }
                        finally
                        {
                            DataLib.SysVar.blnDesignForm = false;
                        }
                    }
                    break;
            }

        }

        /// <summary>
        /// �����۾�
        /// </summary>
        private void CalAsset()
        {
            if (TestRight("CalAsset") == false) return;
            if (MessageBox.Show(this, "���Ҫ�Ա��ڽ��м����۾ɲ�����?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("exec sp_CalAsset " + DateTime.Today.Year.ToString() + "," + DateTime.Today.Month.ToString()) == 0)
            {
                MessageBox.Show(this,"���ڼ���ɹ�!!","��ʾ");
            }
            
        }

        private void ShowFinaceReport()
        {
            if (TestRight("FinaceReport") == false) return;
            DataLib.SysVar.ShowUserReport(this.Handle, DataLib.SysVar.strCon);
            /*
            int intYear, intMonth;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select top 1 * from t_Period order by AID Desc");
            if (ds.Tables[0].Rows.Count == 0) return;
            intYear = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Year"]);
            intMonth = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Month"]);
            intMonth = intMonth + 1;
            if (intMonth > 12)
            {
                intMonth = 1;
                intYear = intYear + 1;
            }
            string sValue = intYear.ToString() + ";" + intMonth.ToString();
            DataLib.SysVar.RMDesigner(IntPtr.Zero, DataLib.SysVar.strCon, "Finance", "Year;Month", sValue);
             */ 
        }

        private void SetLinkEvent()
        {
            foreach (BarItemLink bItem in this.MenuBar.ItemLinks)
            {
                if (bItem is BarSubItemLink)
                {
                    if (bItem.Item.Name == "bsReport")
                    {
                        foreach (BarItemLink con in (bItem as BarSubItemLink).VisibleLinks)
                        {
                            foreach (BarButtonItemLink Btn in (con as BarSubItemLink).VisibleLinks)
                            {
                                Btn.Item.ItemClick += new ItemClickEventHandler(ItemClick);
                            }    
                        }
                    }
                    else
                    {
                        foreach (BarButtonItemLink con in (bItem as BarSubItemLink).VisibleLinks)
                        {
                            con.Item.ItemClick += new ItemClickEventHandler(ItemClick);
                        }
                    }
                }
            }          
        }

        private void ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(e.Item.Caption);
        }   

        /// <summary>
        /// �жϣͣģɴ����Ƿ��
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        private bool IsOpenAs(string FormName)
        {
            if (FormName == "frmBack") return false;
            if (TestRight(FormName) == false) return true;
            if (this.MdiChildren.Length == 0) return false;

            if (DataLib.SysVar.blnInit == false)
            {
                MessageBox.Show("ϵͳδ���г�ʼ��!!", "��ʾ");
                return false;
            }

            foreach (Form myForm in this.MdiChildren)
            {
                if (myForm.Name == FormName)
                {
                    if (myForm.WindowState == FormWindowState.Minimized)
                        myForm.WindowState = FormWindowState.Normal;
                    myForm.Activate();
                    return true;
                }
            }
            return false;

        }

        private void bmBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowBack();
        }


        /// <summary>
        /// �ж��Ƿ��ʼ��
        /// </summary>
        public void SetIniStatus()
        {
            DataLib.SysVar.intIndex = DataLib.SysVar.GetIntParmValue("F_C1");
            if (DataLib.SysVar.blnInit == false)
            {
                bsJxc.Enabled = false;
                bsProduct.Enabled = false;
                bsOut.Enabled = false;
                bsWage.Enabled = false;
                bsReport.Enabled = false;
            }
            else
            {
                bsJxc.Enabled = true;
                bsProduct.Enabled = true;
                bsOut.Enabled = true;
                bsWage.Enabled = true;
                bsReport.Enabled = true;
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (DataLib.SysVar.GetParmValue("F_N2") == true)
            {
                if (IsOpenAs("frmWakeCenter") == false)
                {
                    Sys.frmWakeCenter myWakeCenter = new Sys.frmWakeCenter();
                    myWakeCenter.MdiParent = this;
                    myWakeCenter.Show();
                }

            }

            //OA.frmOAWakeUp F = new OA.frmOAWakeUp();
            ////F.MdiParent = this;
            //F.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void binAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAbout myAbout = new frmAbout();
            myAbout.ShowDialog();
            myAbout.Dispose();
        }

        private void barButtonItem97_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.skinEngine1.SkinFile = "DiamondBlue.ssk";

        }

        private void barButtonItem98_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.skinEngine1.SkinFile = "DiamondGreen.ssk";

        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if(this .WindowState ==FormWindowState.Minimized)
            {
                this.Hide();
                this.notIcon.Visible = true;
            }
        }

        private void notIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Maximized;
                this.notIcon.Visible = false;
            }
        }

        private void ��ʾToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            this.notIcon.Visible = false;

        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}

