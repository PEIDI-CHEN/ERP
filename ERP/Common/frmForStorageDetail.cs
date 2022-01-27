using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmForStorageDetail : Form
    {
        public DataSet dataSet;
        public frmForStorageDetail()
        {
            InitializeComponent();
        }

        private void frmForStorageDetail_Load(object sender, EventArgs e)
        {
            connectDataBase();
            showImage();
        }
        public void connectDataBase()
        {
            string connection = ConfigurationManager.AppSettings["Connection"];
            SqlConnection sql = new SqlConnection(connection);
            string select = "Select F_Photo From t_Item where F_ID=@id";
            SqlCommand command = new SqlCommand(select, sql);
            command.Parameters.AddWithValue("@id", frmReport.number);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = command;
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            //gridControl1.DataSource = dataSet;//测试程序问题
        }
        public void showImage()
        {
            try
            {
                byte[] imageBytes = (byte[])dataSet.Tables[0].Rows[0][0];
                //读入MemoryStream对象
                MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                memoryStream.Write(imageBytes, 0, imageBytes.Length);
                //转成图片
                Image image = Image.FromStream(memoryStream);
                Bitmap imgbitmap = new Bitmap(image, pictureEdit1.Width, pictureEdit1.Height);
                Image finalImage = imgbitmap;
                pictureEdit1.Image = finalImage;
            }
            catch(Exception)
            {
                //MessageBox.Show("还没有放入图片");
                this.Close();
            }
        }
    }
}
