using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmForSeek : Form
    {
        public string F_ID;
        public string F_Name;
        public frmForSeek()
        {
            InitializeComponent();
            timer1.Stop();
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.barCodePrintPage);
        }
        private void barCodePrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{
                F_ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料编码").ToString().Substring(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料编码").ToString().Length-12).Remove(8);
                F_Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料名称").ToString();
           // }
            //catch (Exception)
            //{

           // }
           // MessageBox.Show(F_Name);
            Printer objPrint = new Printer(e);
            //生成彩票信息
            //条形码
            string serialNum = F_ID;//流水号（生成条码使用）
            objPrint.DrawBarCode(serialNum);
            //分界线
            objPrint.DrawDoundary(150);
            //标题
            objPrint.DrawContent(F_Name, new Font("仿宋", 18), Brushes.Black, 105);
            //分界线
            objPrint.DrawDoundary(150);
            //写入内容
            //List<string> num = new List<string>();
            //num.Add("4  9  6  1  0  3    9");
            //num.Add("7  0  1  2  3  5    5");
            //num.Add("7  1  3  2  4  6    5");
            //num.Add("5  7  8  2  7  8    5");
            //num.Add("2  1  2  1  1  6    9");
            //objPrint.DrawContent(num);
            ////分界线            
            //objPrint.DrawDoundary(150);
            ////购买时间
            //string time = "购买时间：" + DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss");
            //objPrint.DrawContent(time);
            ////二维码图片         
            //int height = objPrint.DrawQRCodeBmp("http://www.baidu.com",40);
            //objPrint.DrawContent("扫描二维码可直接查询兑奖结果");
        }
        private PrintDocument printDoc = new PrintDocument();//创建打印对象
        public bool Flags = true;
        //frmStorageSum frm = new frmStorageSum();
        private void frmForSeek_Load(object sender, EventArgs e)
        {
            frmStorageSum frm = new frmStorageSum();
            timer1.Stop();
            panel1.Location = frm.panel3.Location;
            panel1.Size =new Size{ Width = frm.panel3.Width,
                                   Height = frm.panel3.Height };
            checkedComboBoxEdit1.Parent = panel1;
            checkedComboBoxEdit1.Dock = DockStyle.Fill;
                DataTable ds = frmStorageSum.table;
                gridControl1.DataSource = ds;
            //panel1.Hide();
            List<string> choosenItem = new List<string> { "物料编码", "物料名称", "物料规格", " 物料品牌", "物料类别", "物料颜色", "物料存放位置", "图片", "物料材质" };
            checkedComboBoxEdit1.Properties.DataSource = choosenItem;
            setUpPrint();
            //panel1.Hide();
            //frm.panel3.Show();
            //checkedComboBoxEdit1.Show();
        }
        private void setUpPrint()
        {
            frmStorageSum frm = new frmStorageSum();
            panel2.Location = frm.panel4.Location;
            panel2.Size=new Size{ Width = frm.panel4.Width,
                                  Height = frm.panel4.Height };
            button1.Parent = panel2;
            button1.Dock = DockStyle.Fill;
        }
        public static string number;
        //private void gridControl1_Click(object sender, EventArgs e)
        //{

        //}

        //private void frmForSeek_MouseClick(object sender, MouseEventArgs e)
        //{

        //}
        public static string a;
        public static string b;
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
         //  // try
         //   //{
         //      // F_ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料编码").ToString().Substring(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料编码").ToString().Length - 8);
         //       F_Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料名称").ToString();
         // //  }
         //  // catch (Exception)
         //  // {

         ////   }
         //   MessageBox.Show(F_Name);
         //   //if (e.Button == MouseButtons.Left)
         //   //{
         //   //    try
         //   //    {
         //   //        //number = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料编码").ToString();
         //   //        a = gridView1.GetFocusedDisplayText();
         //   //        b = gridView1.FocusedColumn.ToString();
         //   //        frmImageForSeek newForm = new frmImageForSeek();
         //   //        newForm.TopLevel = false;
         //   //        newForm.Parent = gridControl1;
         //   //        newForm.Dock = DockStyle.Fill;
         //   //        newForm.FormBorderStyle = FormBorderStyle.None;
         //   //        newForm.Show();
         //   //    }
         //   //    catch (Exception)
         //   //    {

         //   //    }
            //}
            //else
            //{

            //    //panel1.Show();
            //    timer1.Start();
            //}
        }
        public static string stringForSelect;
        private void frmForSeek_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    //number = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料编码").ToString();
            //    a = gridView1.GetFocusedDisplayText();
            //    b = gridView1.FocusedColumn.ToString();
            //    frmImageForSeek newForm = new frmImageForSeek();
            //    newForm.TopLevel = false;
            //    newForm.Parent = gridControl1;
            //    newForm.Dock = DockStyle.Fill;
            //    newForm.FormBorderStyle = FormBorderStyle.None;
            //    newForm.Show();
            //}
            //catch (Exception)
            //{

            //}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            // MessageBox.Show("测试");
            stringForSelect = checkedComboBoxEdit1.EditValue.ToString();
            //MessageBox.Show(stringForSelect);
            if (stringForSelect != null)
            {
                stringForSelect = checkedComboBoxEdit1.EditValue.ToString();
                //MessageBox.Show("测试");
                Flags = false;
                frmStorageSum frm = new frmStorageSum();
                string connection = ConfigurationManager.AppSettings["Connection"];
                SqlConnection connection1 = new SqlConnection(connection);
                StringBuilder gridCmd = new StringBuilder();
                string newStringForSelect;
                newStringForSelect=stringForSelect.Replace("物料名称", "F_Name").Replace("物料编码", "F_ID").Replace("物料规格", "F_Spec").Replace("物料品牌", "F_Brand").Replace("物料类别", "F_Kind").Replace("物料颜色", "F_Color").Replace("物料存放位置", "F_Position").Replace("图片", "F_Photo").Replace("物料材质", "F_Attrib");
                gridCmd.Append($"Select {newStringForSelect} from t_Item where F_ID like '%'+@name+'%'");
                SqlCommand command = new SqlCommand(gridCmd.ToString(), connection1);
                command.Parameters.Add("@name", SqlDbType.Char).Value = frmStorageSum.index;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                //sqlDataAdapter.ColumnMappings.Add("CustomerID", "ID"); 
                DataSet ds = new DataSet();
                ds = new DataSet();
                sqlDataAdapter.Fill(ds, "页1");
                if (ds.Tables["页1"].Columns["F_Name"] != null)
                {
                    ds.Tables["页1"].Columns["F_Name"].ColumnName = "物料名称";
                }
                if (ds.Tables["页1"].Columns["F_ID"] != null)
                {
                    ds.Tables["页1"].Columns["F_ID"].ColumnName = "物料编码";
                }
                if (ds.Tables["页1"].Columns["F_Spec"] != null)
                {
                    ds.Tables["页1"].Columns["F_Spec"].ColumnName = "物料规格";
                }
                if (ds.Tables["页1"].Columns["F_Brand"] != null)
                {
                    ds.Tables["页1"].Columns["F_Brand"].ColumnName = "物料品牌";
                }
                if (ds.Tables["页1"].Columns["F_Kind"] != null)
                {
                    ds.Tables["页1"].Columns["F_Kind"].ColumnName = "物料类别";
                }
                if (ds.Tables["页1"].Columns["F_Color"] != null)
                {
                    ds.Tables["页1"].Columns["F_Color"].ColumnName = "物料颜色";
                }
                if (ds.Tables["页1"].Columns["F_Position"] != null)
                {
                    ds.Tables["页1"].Columns["F_Position"].ColumnName = "物料存放位置";
                }
                if (ds.Tables["页1"].Columns["F_Photo"] != null)
                {
                    ds.Tables["页1"].Columns["F_Photo"].ColumnName = "图片";
                }
                if (ds.Tables["页1"].Columns["F_Attrib"] != null)
                {
                    ds.Tables["页1"].Columns["F_Attrib"].ColumnName = "物料材质";
                }
                //拼接ds
                StringBuilder gridCmd1 = new StringBuilder();
                gridCmd1.Append("Select F_Qty From t_OtherDetail where F_ItemID like '%'+@name1+'%'");
                SqlCommand command1 = new SqlCommand(gridCmd1.ToString(), connection1);
                command1.Parameters.Add("@name1", SqlDbType.Char).Value = frmStorageSum.index;
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(command1);
                DataSet ds1 = new DataSet();
                sqlDataAdapter1.Fill(ds1);
                ds1.Tables[0].Columns["F_Qty"].ColumnName = "物料材质";
                table = frm.UniteDataTable(ds.Tables["页1"], ds1.Tables[0], "页1");
                gridView1.Columns.Clear();
                gridControl1.DataSource = table;
            }
            //if (Flags == true)
            //{
            //    gridView1.Columns.Clear();
            //    DataTable ds12 = frmStorageSum.table;
            //    gridControl1.DataSource = ds12;
            //    gridControl1.Refresh();
            //}
            //else
            //{
            //    gridView1.Columns.Clear();
            //    gridControl1.DataSource = table;
            //    gridControl1.Refresh();
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.printDoc.Print();
        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //timer1.Start();
            DataTable table = new DataTable();
            // MessageBox.Show("测试");
            stringForSelect = checkedComboBoxEdit1.EditValue.ToString();
            if (stringForSelect.Length != 0)
            {
                //MessageBox.Show(stringForSelect);
                if (stringForSelect != null)
                {
                    stringForSelect = checkedComboBoxEdit1.EditValue.ToString();
                    //MessageBox.Show("测试");
                    Flags = false;
                    frmStorageSum frm = new frmStorageSum();
                    string connection = ConfigurationManager.AppSettings["Connection"];
                    SqlConnection connection1 = new SqlConnection(connection);
                    StringBuilder gridCmd = new StringBuilder();
                    string newStringForSelect;
                    newStringForSelect = stringForSelect.Replace("物料名称", "F_Name").Replace("物料编码", "F_ID").Replace("物料规格", "F_Spec").Replace("物料品牌", "F_Brand").Replace("物料类别", "F_Kind").Replace("物料颜色", "F_Color").Replace("物料存放位置", "F_Position").Replace("图片", "F_Photo").Replace("物料材质", "F_Attrib");
                    gridCmd.Append($"Select {newStringForSelect} from t_Item where F_ID like '%'+@name+'%'");
                    SqlCommand command = new SqlCommand(gridCmd.ToString(), connection1);
                    command.Parameters.Add("@name", SqlDbType.Char).Value = frmStorageSum.index;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    //sqlDataAdapter.ColumnMappings.Add("CustomerID", "ID"); 
                    DataSet ds = new DataSet();
                    ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "页1");
                    if (ds.Tables["页1"].Columns["F_Name"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Name"].ColumnName = "物料名称";
                    }
                    if (ds.Tables["页1"].Columns["F_ID"] != null)
                    {
                        ds.Tables["页1"].Columns["F_ID"].ColumnName = "物料编码";
                    }
                    if (ds.Tables["页1"].Columns["F_Spec"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Spec"].ColumnName = "物料规格";
                    }
                    if (ds.Tables["页1"].Columns["F_Brand"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Brand"].ColumnName = "物料品牌";
                    }
                    if (ds.Tables["页1"].Columns["F_Kind"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Kind"].ColumnName = "物料类别";
                    }
                    if (ds.Tables["页1"].Columns["F_Color"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Color"].ColumnName = "物料颜色";
                    }
                    if (ds.Tables["页1"].Columns["F_Position"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Position"].ColumnName = "物料存放位置";
                    }
                    if (ds.Tables["页1"].Columns["F_Photo"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Photo"].ColumnName = "图片";
                    }
                    if (ds.Tables["页1"].Columns["F_Attrib"] != null)
                    {
                        ds.Tables["页1"].Columns["F_Attrib"].ColumnName = "物料材质";
                    }
                    //拼接ds
                    StringBuilder gridCmd1 = new StringBuilder();
                    gridCmd1.Append("Select F_ItemID, F_Qty From t_StorageQty where F_ItemID like '%'+@name1+'%'");
                    SqlCommand command1 = new SqlCommand(gridCmd1.ToString(), connection1);
                    command1.Parameters.Add("@name1", SqlDbType.Char).Value = frmStorageSum.index;
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(command1);
                    DataSet ds1 = new DataSet();
                    sqlDataAdapter1.Fill(ds1);
                    //ds1.Tables[0].Columns["F_Qty"].ColumnName = "物料数量";
                    Dictionary<string, int> tmpDic = new Dictionary<string, int>();
                    //List<string> tmpList = new List<string>();
                    foreach (DataRow row in ds1.Tables[0].Rows)
                    {
                        if(!tmpDic.Keys.Contains(row["F_ItemID"]) )
                            {
                                 tmpDic.Add(row["F_ItemID"].ToString(),Convert.ToInt32(row["F_Qty"]));
                                  
                            }
                        else
                        {
                            tmpDic[row["F_ItemID"].ToString()] = tmpDic[row["F_ItemID"].ToString()] + Convert.ToInt32(row["F_Qty"]);
                        }
                    }
                    DataTable finalDt = new DataTable();
                    finalDt.Columns.Add("物料数量");
                    finalDt.Columns.Add("F_Item");
                    foreach (var colName in tmpDic)
                    {
                        DataRow dr = finalDt.NewRow();
                        dr["物料数量"] = colName.Value;
                        dr["F_Item"] = colName.Key;
                        finalDt.Rows.Add(dr);
                    }
                    DataTable table1 = new DataTable();
                    table1.Columns.Add("物料数量");
                    foreach (DataRow A in ds.Tables["页1"].Rows)
                    {
                        foreach (DataRow B in finalDt.Rows)
                        {
                            if (A["物料编码"].ToString() == B["F_Item"].ToString())
                            {
                                DataRow dr = table1.NewRow();
                                dr["物料数量"] = B["物料数量"];
                                table1.Rows.Add(dr);
                            }
                        }
                    }
                    table = frm.UniteDataTable(ds.Tables["页1"], table1, "页1");


                    gridView1.Columns.Clear();
                    gridControl1.DataSource = table;
                }
            }
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //number = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "物料编码").ToString();
                a = gridView1.GetFocusedDisplayText();
                b = gridView1.FocusedColumn.ToString();
                frmImageForSeek newForm = new frmImageForSeek();
                newForm.TopLevel = false;
                newForm.Parent = gridControl1;
                newForm.Dock = DockStyle.Fill;
                newForm.FormBorderStyle = FormBorderStyle.None;
                newForm.Show();
            }
            catch (Exception)
            {

            }
        }

        //private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //{

        //}

        //private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}
