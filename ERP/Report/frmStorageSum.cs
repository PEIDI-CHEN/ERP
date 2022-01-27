using BaseClass;
using Common;
using Product;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*11��23����ӷŴ���
 * */
namespace Report
{
    public partial class frmStorageSum : Common.frmReport
    {
        public frmStorageSum()
        {
            InitializeComponent();
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@sKind", cbType.Text);
            return parm;
        }

        protected override Hashtable GetParm1()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@sKind", cbType.Text);
            parm.Add("@Value", strValue);
            return parm;
        }

        protected override void SelectIndexChange()
        {
            if (gvReport.FocusedRowHandle < 0)
            {
                strValue = "";
            }
            else
            {
                if (rgOption.SelectedIndex == 1)
                {
                    DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
                    strValue = dr["F_ItemID"].ToString()+dr["F_StorageID"].ToString();
                }
            }

            base.SelectIndexChange();
        }

        private void frmStorageSum_Load(object sender, EventArgs e)
        {
            judge = 1;
            panel3.Location = new Point
            {
                X = textBox1.Location.X + textBox1.Size.Width + 20,
                Y = textBox1.Location.Y
            };
            panel4.Location = new Point
            {
                X = panel3.Location.X + panel3.Size.Width + 20,
                Y = panel3.Location.Y
            };
            panel3.Hide();
            panel4.Hide();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void OnViewDbClick(object sender, EventArgs e)
        {
            base.OnViewDbClick(sender, e);
            //ShowBill();
        }

        private void ShowBill()
        {
            if (gvReport.FocusedRowHandle < 0) return;

            DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            string strTag = dr["F_Type"].ToString();
            switch (strTag)
            {
                
                case "�̵�":
                    Storage.frmCheck myCheck = new Storage.frmCheck();
                    myCheck.strBillID = dr["F_BillID"].ToString();
                    myCheck.ShowDialog();
                    myCheck.Dispose();
                    break;
                case "��װ":
                    Storage.frmInstall myInstall = new Storage.frmInstall();
                    myInstall.strBillID = dr["F_BillID"].ToString();
                    myInstall.ShowDialog();
                    myInstall.Dispose();
                    break;
                case "��ж":
                    Storage.frmInstall myInstall1 = new Storage.frmInstall();
                    myInstall1.strBillID = dr["F_BillID"].ToString();
                    myInstall1.ShowDialog();
                    myInstall1.Dispose();
                    break;
                case "����":
                    Storage.frmExchange myExchange = new Storage.frmExchange();
                    myExchange.strBillID = dr["F_BillID"].ToString();
                    myExchange.ShowDialog();
                    myExchange.Dispose();
                    break;
                case "����":
                    Storage.frmExchange myExchange1 = new Storage.frmExchange();
                    myExchange1.strBillID = dr["F_BillID"].ToString();
                    myExchange1.ShowDialog();
                    myExchange1.Dispose();
                    break;
                default :
                    Storage.frmOtherIn myOtherIn = new Storage.frmOtherIn();
                    myOtherIn.strBillID = dr["F_BillID"].ToString();
                    myOtherIn.ShowDialog();
                    myOtherIn.Dispose();
                    break;
            }

        }
        //12��15����Ӵ���
        //12��15����������frmForSeek�������ؼ�button��seek�Լ�textbox1
      // frmForSeek seekForm = new frmForSeek();
        private void seek_Click(object sender, EventArgs e)
        {
            seekForm.Close();
           // getIndex();
            getDataSet();
            showSeekForm();
        }
        //��ģ�����ҵ�ҳ��
       // public static string index;
        public static DataSet ds;
        public static DataTable table;
        public static string index;
        public string getIndex()
        {
            //string index;
            index = textBox1.Text;
            return index;
        }
        frmForSeek seekForm = new frmForSeek();
        public void showSeekForm()
        { 
                seekForm = new frmForSeek();
                seekForm.TopLevel = false;
                seekForm.Parent = gcReport;
                seekForm.Dock = DockStyle.Fill;
                seekForm.FormBorderStyle = FormBorderStyle.None;
                seekForm.Show();

        }
        public static bool FLAG=false;
        //�����ݿ���õ�������ȡ����
        public void getDataSet()
        {
            //ds=new DataSet();
            //string index = textBox1.Text;
            string connection = ConfigurationManager.AppSettings["Connection"];
            SqlConnection connection1 = new SqlConnection(connection);
            StringBuilder gridCmd = new StringBuilder();
            gridCmd.Append("Select F_ID As ���ϱ���,F_Name As ��������,F_Spec As ���Ϲ��,F_Brand As ����Ʒ��,F_Kind As �������,F_Color As ������ɫ,F_Position As ���ϴ��λ��,F_Photo As ͼƬ,F_Attrib As ���ϲ��� from t_Item where F_ID like '%'+@name+'%'");
            SqlCommand command = new SqlCommand(gridCmd.ToString(), connection1);
            command.Parameters.Add("@name", SqlDbType.Char).Value = getIndex();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            ds = new DataSet();
            sqlDataAdapter.Fill(ds,"ҳ1");
            //ƴ��ds
            StringBuilder gridCmd1 = new StringBuilder();
            gridCmd1.Append("Select F_ItemID, F_Qty From t_StorageQty where F_ItemID like '%'+@name1+'%'");
            SqlCommand command1 = new SqlCommand(gridCmd1.ToString(), connection1);
            command1.Parameters.Add("@name1", SqlDbType.Char).Value = getIndex();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(command1);
            DataSet ds1 = new DataSet();
            sqlDataAdapter1.Fill(ds1);
            Dictionary<string, int> tmpDic = new Dictionary<string, int>();
            //List<string> tmpList = new List<string>();
            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                if (!tmpDic.Keys.Contains(row["F_ItemID"]))
                {
                    tmpDic.Add(row["F_ItemID"].ToString(), Convert.ToInt32(row["F_Qty"]));

                }
                else
                {
                    tmpDic[row["F_ItemID"].ToString()] = tmpDic[row["F_ItemID"].ToString()] + Convert.ToInt32(row["F_Qty"]);
                }
            }
            DataTable finalDt = new DataTable();
            finalDt.Columns.Add("��������");
            finalDt.Columns.Add("F_Item");
            foreach (var colName in tmpDic)
            {
                DataRow dr = finalDt.NewRow();
                dr["��������"] = colName.Value;
                dr["F_Item"] = colName.Key;
                finalDt.Rows.Add(dr);
            }
            DataTable table1 = new DataTable();
            table1.Columns.Add("��������");
            foreach (DataRow A in ds.Tables["ҳ1"].Rows)
            {
                foreach(DataRow B in finalDt.Rows)
                {
                    if(A["���ϱ���"].ToString()==B["F_Item"].ToString())
                    {
                        DataRow dr = table1.NewRow();
                        dr["��������"] = B["��������"];
                        table1.Rows.Add(dr);
                    }
                }
            }
            //table = ds.Tables["ҳ1"];
            table = UniteDataTable(ds.Tables["ҳ1"], table1, "ҳ1");
            //ds.Tables["ҳ1"].Merge(ds1.Tables[0]);
            //sqlDataAdapter.Fill(ds);





        }
        /// <summary>
        /// �������в�ͬ��DataTable�ϲ���һ���µ�DataTable
        /// </summary>
        /// <param name="dt1">��1</param>
        /// <param name="dt2">��2</param>
        /// <param name="DTName">�ϲ����µı���</param>
        /// <returns></returns>
        public DataTable UniteDataTable(DataTable dt1, DataTable dt2, string DTName)
        {
            DataTable dt3 = new DataTable();
            dt3=dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                dt3.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[dt3.Columns.Count];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                dt3.Rows.Add(obj);
            }

            if (dt1.Rows.Count >= dt2.Rows.Count)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            else
            {
                DataRow dr3;
                for (int i = 0; i < dt2.Rows.Count - dt1.Rows.Count; i++)
                {
                    dr3 = dt3.NewRow();
                    dt3.Rows.Add(dr3);
                }
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            dt3.TableName = DTName; //����DT������
            return dt3;
        }


        //��� �ṹ��ͬ��DataTable�ϲ�

        //public DataTable GetAllEntrysDataTable()
        //{
        //    DataTable newDataTable = GetEntrysDataTable(0).Clone();

        //    object[] obj = new object[newDataTable.Columns.Count];

        //    for (int i = 0; i < entryGroups.GetEntryGroupCount(); i++)
        //    {
        //        for (int j = 0; j < GetEntrysDataTable(i).Rows.Count; j++)
        //        {
        //            GetEntrysDataTable(i).Rows[j].ItemArray.CopyTo(obj, 0);
        //            newDataTable.Rows.Add(obj);
        //        }
        //    }
        //    return newDataTable;
        //}
    }
}

