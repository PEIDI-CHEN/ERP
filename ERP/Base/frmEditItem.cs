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
 *11月22日，gbox内容不可放入panel中，要不然更新数据库时候，会引发数据库主键值冲突 
 *自定义的控件依然需要更改
 *更改额gbox的控件布局
 *更改了自定义控件中的cbcontrol，editcontrol，lupcontrol，spincontrol，具体更改地方见控件代码页
 *问题全部解决
 *开始添加摄像头
 *添加Nuget包：AForge
 *
 */
namespace Base
{
    public partial class frmEditItem : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        private string strUnit;
        //11月23日添加的公共变量
        public FilterInfoCollection videoDevices;
        public VideoCaptureDevice videoSource;
        public Bitmap bitmap;
        public int selectedDeviceIndex = 0;
        //12月13日新增代码：
        //把寻址方式仍然是绝对路径，但是绝对路径由currentdirectory生成，指定到debug文件夹
        //private static string relativePath = System.Environment.CurrentDirectory;
        //private static string Path = relativePath + @"\捕获文件夹";
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
        /// 填充单位
        /// </summary>
        private void FillUnit()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Name from t_Assist where F_Type = '计量单位'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbUnit.Items.Add(dr["F_Name"]);
            }
            ds.AcceptChanges();
        }

        /// <summary>
        /// 填充颜色
        /// </summary>
        private void FillColor()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Name from t_Assist where F_Type = '颜色'");
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
                dr["F_ID"] = GetMaxCode("原材料", "t_Item");
                dr["F_Type"] = strType;
                dr["F_Kind"] = "原材料";
                dr["F_Attrib"] = "原材料";
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
                MessageBox.Show("请检查物料代码是否重复");
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
        /// 保存前检查
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
                    MessageBox.Show("单位名称不能为空!!");
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
                MessageBox.Show("不能同时存在多个主单位!!", "提示");
                xtraTabControl1.SelectedTabPageIndex = 1;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
            //return base.Save();
            binData.EndEdit();
            if (SavePre() == false) return false;
            //1月15日添加
            ///<summary>
            ///添加ds.acceptchanges同步更新数据
            /// </summary>
            //1月15日添加代码
            //string strSaveSlaverSQL = "select * from t_Item where F_ID = ''";
            //string strUnit = "select * from t_Unit where F_ItemID = ''";
            //感觉是edit的内容没更新到数据库上
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
        //11月23日更改删除
        //private void sbLoad_Click(object sender, EventArgs e)
        //{
        //    string strFile = DataLib.sysClass.ShowOpenFileDialog("图片文件", "所有文件|*.*");
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
            //11月23日添加代码
            string relativePath = System.Environment.CurrentDirectory;
            string Path = relativePath + @"\捕获文件夹";
            var files = Directory.GetFiles(Path, "*.*");
            foreach (var file in files)
            {
                File.Delete(file);
            }
            try
            {
                // 枚举所有视频输入设备
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
        /*11月23日添加的代码
         * FilterInfoCollection videoDevices;//摄像头设备集合
           VideoCaptureDevice videoSource;//捕获设备源
           Bitmap img;public声明在了代码开头处
         * */
        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    var files = Directory.GetFiles("D:/陈沛迪的个人资料/SDK摄像头/捕获文件夹", "*.*");
        //    foreach (var file in files)
        //    {
        //        File.Delete(file);
        //    }
        //    try
        //    {
        //        // 枚举所有视频输入设备
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
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
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
            //11月23日问题：try catch捕获不到这个异常
            //原因：release情况下可以捕获，debug模式下无法捕获dispose
            try
            {
                string relativePath = System.Environment.CurrentDirectory;
                string Path = relativePath + "/捕获文件夹";
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
                string Path = relativePath + @"\捕获文件夹";
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
            //var files = Directory.GetFiles("D:/陈沛迪的个人资料/SDK摄像头/捕获文件夹", "*.*");
            //foreach (var file in files)
            //{
            //    File.Delete(file);
            //}
            //12月13日添加代码，解决摄像头占用问题
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }
        //UserControl editControl2 = new UserControl();
        //frmEditItem item = new frmEditItem();
        //更改一下自定义控件
        Dictionary<string, string> dic = new Dictionary<string, string>() 
        { 
            { "集成电路", "TZ.IC" } ,
            { "电容器", "TZ.CC" },
            { "电阻器", "TZ.RS" } ,
            { "二极管", "TZ.RG" } ,
            { "三极管", "TZ.ZG" } ,
            { "场效应管", "TZ.ZG" } ,
            { "晶闸管", "TZ.JG" },
            { "电感器", "TZ.DG" } ,
            { "稳压器", "TZ.WY" } ,
            { "磁珠", "TZ.CZ" } ,
            { "晶体振荡器", "TZ.JZ" }, 
            { "开关", "TZ.KG" } ,
            { "电声器件", "TZ.DS" }, 
            { "电位器", "TZ.DW" } ,
            { "电池", "TZ.DC" },
            { "充电器件", "TZ.CD" },
            { "电子接插件", "TZ.JC" },
            { "电子线材", "TZ.XC" },
            { "印刷电路板", "TZ.PF" },
            { "照明灯具", "TZ.DZ" },
        };
        Dictionary<string, string> dic1 = new Dictionary<string, string>()
        {
            { "集成", "TZ.IC" } ,
            { "电容", "TZ.CC" },
            { "电阻", "TZ.RS" } ,
            { "二极管", "TZ.RG" } ,
            { "三极管", "TZ.ZG" } ,
            { "效应", "TZ.ZG" } ,
            { "晶闸", "TZ.JG" },
            { "电感", "TZ.DG" } ,
            { "稳压", "TZ.WY" } ,
            { "磁珠", "TZ.CZ" } ,
            { "振荡器", "TZ.JZ" },
            { "开关", "TZ.KG" } ,
            { "电声", "TZ.DS" },
            { "电位", "TZ.DW" } ,
            { "电池", "TZ.DC" },
            { "充电", "TZ.CD" },
            { "接插件", "TZ.JC" },
            { "线材", "TZ.XC" },
            { "印刷", "TZ.PF" },
            { "照明", "TZ.DZ" },
        };
        Dictionary<string, string> dicForOpt = new Dictionary<string, string>()
        {
            { "镜头", "GX.JT" } ,
            { "玻璃", "GX.BL" },
        };
        Dictionary<string, string> dicForSJ = new Dictionary<string, string>
        {
            { "塑胶结构件", "SJ.SJ" } ,
            { "塑胶工具", "SJ.GJ" },
            { "塑胶模具", "SJ.SG" },
            { "其他塑胶材料", "SJ.SQ" },
        };
        Dictionary<string, string> dicForJS = new Dictionary<string, string>()
        {
            { "金属紧固件", "JS.JG" } ,
            { "金属结构件", "JS.JK" },
            { "模具", "JS.MG" } ,
            { "刀具", "JS.RG" } ,
            { "夹具", "JS.JG" } ,
            { "钳具", "JS.DG" } ,
            { "磨具", "JS.AG" },
            { "量具", "JS.LG" } ,
            { "容具", "JS.EG" } ,
            { "锁具", "JS.XG" } ,
            { "焊具", "JS.HG" },
            { "锯具", "JS.ZG" } ,
            { "锉具", "JS.BG" },
            { "斧锤具", "JS.FG" } ,
            { "铲具", "JS.CG" },
        };
        Dictionary<string, string> dicForBZ = new Dictionary<string, string>()
        {
            { "包装箱", "BZ.BX" } ,
            { "包装盒", "BZ.BH" },
            { "包装袋", "BZ.BD" } ,
            { "包装带", "BZ.BT" } ,
            { "标识件", "BZ.BS" } ,
            { "其他包装材料", "BZ.BL" } ,
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

