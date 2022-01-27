using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using DevExpress.Utils.OAuth.Provider;
using DevExpress.XtraEditors.Controls;
/*
 *11��22�գ�gbox���ݲ��ɷ���panel�У�Ҫ��Ȼ�������ݿ�ʱ�򣬻��������ݿ�����ֵ��ͻ 
 *�Զ���Ŀؼ���Ȼ��Ҫ����
 *���Ķ�gbox�Ŀؼ�����
 *�������Զ���ؼ��е�cbcontrol��editcontrol��lupcontrol��spincontrol��������ĵط����ؼ�����ҳ
 *����ȫ�����
 *��ʼ�������ͷ
 *���Nuget����AForge
 *
 */
namespace Base
{
    public partial class frmEditItem : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        private string strUnit;
        //11��23����ӵĹ�������
        public FilterInfoCollection videoDevices;
        public VideoCaptureDevice videoSource;
        public Bitmap bitmap;
        public int selectedDeviceIndex = 0;
        //12��13���������룺
        //��Ѱַ��ʽ��Ȼ�Ǿ���·�������Ǿ���·����currentdirectory���ɣ�ָ����debug�ļ���
        //private static string relativePath = System.Environment.CurrentDirectory;
        //private static string Path = relativePath + @"\�����ļ���";
        public frmEditItem()
        {
            InitializeComponent();
            blnNew = true;
            gbox.Parent = Page1;
            gbox.Dock = DockStyle.Fill;
            strNoCopyField = "F_ID";
        }

        protected override void CopyRecord()
        {

            int i, intCnt;
            intCnt = binUnit.Count;

            DataRow[] dr = new DataRow[intCnt];
            for (i = 0; i <= intCnt - 1; i++)
            {
                dr[i] = ((DataRowView)binUnit[i]).Row;

            }
            base.CopyRecord();

            if (binUnit.Count > 0) binUnit.RemoveCurrent();
            DataTable dt = ((DataView)binUnit.DataSource).Table;
            dt.AcceptChanges();
            for (i = 0; i <= intCnt - 1; i++)
            {
                DataRow drUnit = ((DataRowView)binUnit.AddNew()).Row;
                foreach (DataColumn dc in dt.Columns)
                {
                    drUnit[dc.ColumnName] = dr[i][dc.ColumnName];

                }
                drUnit.AcceptChanges();
                drUnit.EndEdit();
                drUnit.AcceptChanges();
            }
        }

        private void GetFile(int intFlag)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (intFlag)
                {
                    case 1:
                        editControl7.SetValue(openFileDialog.FileName);
                        break;
                    case 2:
                        editControl8.SetValue(openFileDialog.FileName);
                        break;
                    case 3:
                        editControl10.SetValue(openFileDialog.FileName);
                        break;
                    case 4:
                        editControl11.SetValue(openFileDialog.FileName);
                        break;
                }
            }
        }

        /// <summary>
        /// ��䵥λ
        /// </summary>
        private void FillUnit()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Name from t_Assist where F_Type = '������λ'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbUnit.Items.Add(dr["F_Name"]);
            }
            ds.AcceptChanges();
        }

        /// <summary>
        /// �����ɫ
        /// </summary>
        private void FillColor()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Name from t_Assist where F_Type = '��ɫ'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbColor.AddItem(dr["F_Name"]);
            }
            ds.AcceptChanges();
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Class where left(F_ID,3) = '04.'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            ds.AcceptChanges();
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_Storage";
            DataSet ds1 = myHelper.GetDs(strSQL);
            ds1.AcceptChanges();
            lupControl2.LookUpDataSource = ds1.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_Supplier";
            DataSet ds2 = myHelper.GetDs(strSQL);
            ds2.AcceptChanges();
            lupControl3.LookUpDataSource = ds2.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_ID";
        }

        public override void New()
        {
            try
            {
                strSQL = "select * from t_Item where F_ID = ''";
                strUnit = "select * from t_Unit where F_ItemID = ''";

                if (blnBind == false)
                {
                    BindData();
                    FillColor();
                    FillUnit();
                }
                else
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds1 = myHelper.GetDs(strUnit);
                    ds1.AcceptChanges();
                    binUnit.DataSource = ds1.Tables[0].DefaultView;
                }
                DataRow dr = ((DataRowView)binData.AddNew()).Row;
                dr.BeginEdit();
                dr["F_ID"] = GetMaxCode("ԭ����", "t_Item");
                dr["F_Type"] = strType;
                dr["F_Kind"] = "ԭ����";
                dr["F_Attrib"] = "ԭ����";
                dr["F_CalStorage"] = true;
                if (DataLib.SysVar.GetParmValue("F_N9") == true)
                {
                    dr["F_BarCode"] = DataLib.sysClass.GetRandom();
                }
                dr.EndEdit();
                binData.EndEdit();
                xtraTabControl1.SelectedTabPageIndex = 0;
                editControl1.Focus();
                NewUnit();
                base.New();
            }
            catch (Exception)
            {
                MessageBox.Show("�������ϴ����Ƿ��ظ�");
            }
        }

        private void NewUnit()
        {
            DataRow drUnit = ((DataRowView)binUnit.AddNew()).Row;
            drUnit["F_Main"] = true;
            drUnit["F_Rate"] = 1;
        }

        public override void Edit(string strID)
        {
            ckOption.Checked = false;
            base.Edit(strID);
            strSQL = "select * from t_Item where F_ID = '" + strID + "'";
            strUnit = "select * from t_Unit where F_ItemID = '" + strID + "'";
            BindData();
            FillColor();
            FillUnit();
        }

        /// <summary>
        /// ����ǰ���
        /// </summary>
        /// <returns></returns>
        protected override bool SavePre()
        {
            int m = 0;
            if (base.SavePre() == false) return false;
            DataRow drItem = ((DataRowView)binData.Current).Row;
            binUnit.EndEdit();
            int intCnt = binUnit.Count;
            binUnit.MoveFirst();
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = ((DataRowView)binUnit.Current).Row;
                if (dr["F_Name"] == DBNull.Value)
                {
                    MessageBox.Show("��λ���Ʋ���Ϊ��!!");
                    Page2.Focus();
                    return false;
                }
                if (Convert.ToBoolean(dr["F_Main"]) == true)
                    m = m + 1;
                dr["F_ItemID"] = drItem["F_ID"];
                binUnit.MoveNext();
            }
            if (m > 1)
            {
                MessageBox.Show("����ͬʱ���ڶ������λ!!", "��ʾ");
                xtraTabControl1.SelectedTabPageIndex = 1;
                return false;
            }
            return true;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
            //return base.Save();
            binData.EndEdit();
            if (SavePre() == false) return false;
            //1��15�����
            ///<summary>
            ///���ds.acceptchangesͬ����������
            /// </summary>
            //1��15����Ӵ���
            //string strSaveSlaverSQL = "select * from t_Item where F_ID = ''";
            //string strUnit = "select * from t_Unit where F_ItemID = ''";
            //�о���edit������û���µ����ݿ���
            DataSet ds = ((DataView)binData.DataSource).Table.DataSet;
            ds.AcceptChanges();
            DataSet dsUnit = ((DataView)binUnit.DataSource).Table.DataSet;
            dsUnit.AcceptChanges();
            DataSet[] dsData = new DataSet[2];
            dsData[0] = ds;
            dsData[1] = dsUnit;

            string[] strSQL = new string[2];
            strSQL[0] = strSaveSlaverSQL;
            strSQL[1] = strUnit;

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (myHelper.SaveMuteData(dsData, strSQL).Length == 0)
            {
                ds.AcceptChanges();
                dsUnit.AcceptChanges();
                return true;
            }
            else
                return false;
        }
        DataLib.DataHelper myHelper = new DataLib.DataHelper();
        public static DataSet ds;
        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            // DataLib.DataHelper myHelper = new DataLib.DataHelper();
            ds = myHelper.GetDs(strSQL);
            ds.AcceptChanges();
            binData.DataSource = ds.Tables[0].DefaultView;
            SetDropSource();

            DataSet ds1 = myHelper.GetDs(strUnit);
            ds1.AcceptChanges();
            binUnit.DataSource = ds1.Tables[0].DefaultView;
            base.BindData();
            peItem.DataBindings.Add("EditValue", binData, "F_Photo");

            foreach (Control uCon in Page4.Controls)
            {
                if (uCon is myControl.EditControl)
                    (uCon as myControl.EditControl).BindData();

                if (uCon is myControl.lupControl)
                    (uCon as myControl.lupControl).BindData();

                if (uCon is myControl.cbControl)
                    (uCon as myControl.cbControl).BindData();

                if (uCon is myControl.DateControl)
                    (uCon as myControl.DateControl).BindData();

                if (uCon is myControl.SpinControl)
                    (uCon as myControl.SpinControl).BindData();

                if (uCon is myControl.ckControl)
                    (uCon as myControl.ckControl).BindData();
            }


        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            NewUnit();
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            binUnit.RemoveCurrent();
        }
        //11��23�ո���ɾ��
        //private void sbLoad_Click(object sender, EventArgs e)
        //{
        //    string strFile = DataLib.sysClass.ShowOpenFileDialog("ͼƬ�ļ�", "�����ļ�|*.*");
        //    if (strFile != "")
        //    {
        //         peItem.Image = Image.FromFile(strFile);
        //    }

        //}

        private void peItem_DoubleClick(object sender, EventArgs e)
        {
            frmPic myPic = new frmPic();
            myPic.pePic.Image = peItem.Image;
            myPic.ShowDialog();
            myPic.Dispose();
        }

        private void sbClear_Click(object sender, EventArgs e)
        {
            peItem.Image = null;
        }

        private void ckOption_CheckedChanged(object sender, EventArgs e)
        {
            blnNew = ckOption.Checked;
        }

        private void frmEditItem_Load(object sender, EventArgs e)
        {
            editControl1.Focus();
            this.radioButton3.Checked = true;
            /*
            string[] strKind;
            DataLib.sysClass myClass = new DataLib.sysClass();
            strKind = myClass.GetItemKind();

            for (int i = 0; i < strKind.Length; i++)
            {
                cbControl1.AddItem(strKind[i]);
            }
             */
            //11��23����Ӵ���
            string relativePath = System.Environment.CurrentDirectory;
            string Path = relativePath + @"\�����ļ���";
            var files = Directory.GetFiles(Path, "*.*");
            foreach (var file in files)
            {
                File.Delete(file);
            }
            try
            {
                // ö��������Ƶ�����豸
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                //comboBox1.SelectedIndex = 0;

            }
            catch (ApplicationException)
            {
                comboBox1.Items.Add("No local capture devices");
                videoDevices = null;
            }
        }

        private void frmEditItem_Shown(object sender, EventArgs e)
        {
            editControl1.Focus();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            GetFile(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            GetFile(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            GetFile(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            GetFile(4);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbControl1_SelectIndexChange(object sender, EventArgs e)
        {

        }

        private void lupControl3_Load(object sender, EventArgs e)
        {

        }
        /*11��23����ӵĴ���
         * FilterInfoCollection videoDevices;//����ͷ�豸����
           VideoCaptureDevice videoSource;//�����豸Դ
           Bitmap img;public�������˴��뿪ͷ��
         * */
        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    var files = Directory.GetFiles("D:/����ϵĸ�������/SDK����ͷ/�����ļ���", "*.*");
        //    foreach (var file in files)
        //    {
        //        File.Delete(file);
        //    }
        //    try
        //    {
        //        // ö��������Ƶ�����豸
        //        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        //        if (videoDevices.Count == 0)
        //            throw new ApplicationException();
        //        foreach (FilterInfo device in videoDevices)
        //        {
        //            comboBox1.Items.Add(device.Name);
        //        }
        //        //comboBox1.SelectedIndex = 0;

        //    }
        //    catch (ApplicationException)
        //    {
        //        comboBox1.Items.Add("No local capture devices");
        //        videoDevices = null;
        //    }
        //}

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (comboBox1.SelectedIndex == 0)
            {
                selectedDeviceIndex = 0;
            }
            else
            {
                selectedDeviceIndex = 1;
            }
            try
            {
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//��������ͷ��
                videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
                videoSourcePlayer1.VideoSource = videoSource;
                // set NewFrame event handler
                videoSourcePlayer1.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose the video device");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (videoSource == null)
            //{
            //    return;
            //}  
            Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
            //11��23�����⣺try catch���񲻵�����쳣
            //ԭ��release����¿��Բ���debugģʽ���޷�����dispose
            try
            {
                string relativePath = System.Environment.CurrentDirectory;
                string Path = relativePath + "/�����ļ���";
                bitmap.Save(Path + @"\" + fileName, ImageFormat.Jpeg);
                bitmap.Dispose();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no useful video devices");
            }
            try
            {
                string relativePath = System.Environment.CurrentDirectory;
                string Path = relativePath + @"\�����ļ���";
                var files = Directory.GetFiles(Path, "*.*");
                foreach (var file in files)
                {
                    var PicAddress = file;
                    Image imge = Image.FromFile(PicAddress);
                    Bitmap bm = new Bitmap(imge, peItem.Width, peItem.Height);
                    peItem.Image = bm;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is no photo");
            }
        }

        private void frmEditItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var files = Directory.GetFiles("D:/����ϵĸ�������/SDK����ͷ/�����ļ���", "*.*");
            //foreach (var file in files)
            //{
            //    File.Delete(file);
            //}
            //12��13����Ӵ��룬�������ͷռ������
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }
        //UserControl editControl2 = new UserControl();
        //frmEditItem item = new frmEditItem();
        //����һ���Զ���ؼ�
        Dictionary<string, string> dic = new Dictionary<string, string>() 
        { 
            { "���ɵ�·", "TZ.IC" } ,
            { "������", "TZ.CC" },
            { "������", "TZ.RS" } ,
            { "������", "TZ.RG" } ,
            { "������", "TZ.ZG" } ,
            { "��ЧӦ��", "TZ.ZG" } ,
            { "��բ��", "TZ.JG" },
            { "�����", "TZ.DG" } ,
            { "��ѹ��", "TZ.WY" } ,
            { "����", "TZ.CZ" } ,
            { "��������", "TZ.JZ" }, 
            { "����", "TZ.KG" } ,
            { "��������", "TZ.DS" }, 
            { "��λ��", "TZ.DW" } ,
            { "���", "TZ.DC" },
            { "�������", "TZ.CD" },
            { "���ӽӲ��", "TZ.JC" },
            { "�����߲�", "TZ.XC" },
            { "ӡˢ��·��", "TZ.PF" },
            { "�����ƾ�", "TZ.DZ" },
        };
        Dictionary<string, string> dic1 = new Dictionary<string, string>()
        {
            { "����", "TZ.IC" } ,
            { "����", "TZ.CC" },
            { "����", "TZ.RS" } ,
            { "������", "TZ.RG" } ,
            { "������", "TZ.ZG" } ,
            { "ЧӦ", "TZ.ZG" } ,
            { "��բ", "TZ.JG" },
            { "���", "TZ.DG" } ,
            { "��ѹ", "TZ.WY" } ,
            { "����", "TZ.CZ" } ,
            { "����", "TZ.JZ" },
            { "����", "TZ.KG" } ,
            { "����", "TZ.DS" },
            { "��λ", "TZ.DW" } ,
            { "���", "TZ.DC" },
            { "���", "TZ.CD" },
            { "�Ӳ��", "TZ.JC" },
            { "�߲�", "TZ.XC" },
            { "ӡˢ", "TZ.PF" },
            { "����", "TZ.DZ" },
        };
        Dictionary<string, string> dicForOpt = new Dictionary<string, string>()
        {
            { "��ͷ", "GX.JT" } ,
            { "����", "GX.BL" },
        };
        Dictionary<string, string> dicForSJ = new Dictionary<string, string>
        {
            { "�ܽ��ṹ��", "SJ.SJ" } ,
            { "�ܽ�����", "SJ.GJ" },
            { "�ܽ�ģ��", "SJ.SG" },
            { "�����ܽ�����", "SJ.SQ" },
        };
        Dictionary<string, string> dicForJS = new Dictionary<string, string>()
        {
            { "�������̼�", "JS.JG" } ,
            { "�����ṹ��", "JS.JK" },
            { "ģ��", "JS.MG" } ,
            { "����", "JS.RG" } ,
            { "�о�", "JS.JG" } ,
            { "ǯ��", "JS.DG" } ,
            { "ĥ��", "JS.AG" },
            { "����", "JS.LG" } ,
            { "�ݾ�", "JS.EG" } ,
            { "����", "JS.XG" } ,
            { "����", "JS.HG" },
            { "���", "JS.ZG" } ,
            { "ﱾ�", "JS.BG" },
            { "������", "JS.FG" } ,
            { "����", "JS.CG" },
        };
        Dictionary<string, string> dicForBZ = new Dictionary<string, string>()
        {
            { "��װ��", "BZ.BX" } ,
            { "��װ��", "BZ.BH" },
            { "��װ��", "BZ.BD" } ,
            { "��װ��", "BZ.BT" } ,
            { "��ʶ��", "BZ.BS" } ,
            { "������װ����", "BZ.BL" } ,
        };
        //public void writeDictionary()
        //{
        //    //pairs.Add(){ { 1, "str111" } };
        //}
        public static string timeNow;
        private void timer1_Tick(object sender, EventArgs e) => onTimeEvent();
        public void onTimeEvent()
        {
            ds = myHelper.GetDs(strSQL);
            //bool FLAG = true;
            string valueForControl1 = editControl2.GetValue().ToString();
            string result = dic.Where(A => valueForControl1.Contains(A.Key) == true).FirstOrDefault().Value;
            string result1 = dic1.Where(A => valueForControl1.Contains(A.Key) == true).FirstOrDefault().Value;
            string result2 = dicForOpt.Where(A => valueForControl1.Contains(A.Key) == true).FirstOrDefault().Value;
            string result3= dicForSJ.Where(A => valueForControl1.Contains(A.Key) == true).FirstOrDefault().Value;
            string result4= dicForJS.Where(A => valueForControl1.Contains(A.Key) == true).FirstOrDefault().Value;
            string result5= dicForBZ.Where(A => valueForControl1.Contains(A.Key) == true).FirstOrDefault().Value;
            //var result = from A in dic
            //             where valueForControl1.Contains(A.Key) == true
            //             select A.Value;
            //var result1 = from A in dic1
            //               where valueForControl1.Contains(A.Key) == true
            //               select A.Value;
            //var result2 = from A in dicForOpt
            //              where valueForControl1.Contains(A.Key) == true
            //              select A.Value;
            //var result3 = from A in dicForSJ
            //              where valueForControl1.Contains(A.Key) == true
            //              select A.Value;
            //var result4 = from A in dicForJS
            //              where valueForControl1.Contains(A.Key) == true
            //              select A.Value;
            //var result5 = from A in dicForBZ
            //              where valueForControl1.Contains(A.Key) == true
            //              select A.Value;
            string time = DateTime.Now.ToString("yyyyMMddhhss");
            //timeNow= DateTime.Now.ToString("M")+ DateTime.Now.ToString("HH");
            //time = time.Substring(0, 10);
            // time = time.Replace("/", "");
            //List<IEnumerable<string>> newList = new List<IEnumerable<string>>();
            List<string> list = new List<string>() { result, result1,result2,result3,result4,result5 };
            //var a= list.RemoveAll(i => i.ToList().Count == 0);
                foreach(string B in list)
                {
                    if(B!=null)
                    {
                                StringBuilder fianlResult = new StringBuilder();
                                fianlResult.Append(B).Append(".").Append(time);
                                editControl1.SetValue(fianlResult.ToString());
                    }
                }
            //foreach(IEnumerable<string> A in tmpResult)
            //{

            //}
            //if (finalResult1.Count!=0)
            //{
            //    foreach (string A in finalResult1)
            //    {
            //        StringBuilder fianlResult = new StringBuilder();
            //        fianlResult.Append(A).Append(".").Append(time);
            //        editControl1.SetValue(fianlResult.ToString());
            //    }
            //}
            //foreach (var A in tmpResult)
            //{
            //    if (!A)
            //         {
            //    StringBuilder fianlResult = new StringBuilder();
            //    fianlResult.Append(A).Append(".").Append(time);
            //    editControl1.SetValue(fianlResult.ToString());
            //          }
            //}
            //bool FLAG = false;
            //while(FLAG)
            //if (result.Count()!=0)
            //{
            //    foreach (string A in result)
            //    {
            //        //A.Join(time);
            //        StringBuilder fianlResult = new StringBuilder();
            //        fianlResult.Append(A).Append(".").Append(time);
            //        editControl1.SetValue(fianlResult.ToString());
            //    }
            //}
            //else
            //{
            //    var result1 = from A in dic1
            //                 where valueForControl1.Contains(A.Key) == true
            //                 select A.Value;
            //    foreach (string A in result1)
            //    {
            //        //A.Join(time);
            //        StringBuilder fianlResult = new StringBuilder();
            //        fianlResult.Append(A).Append(".").Append(time);
            //        editControl1.SetValue(fianlResult.ToString());
            //    }
            //}

        }

        private void lupControl1_Load(object sender, EventArgs e)
        {

        }
    }
}

