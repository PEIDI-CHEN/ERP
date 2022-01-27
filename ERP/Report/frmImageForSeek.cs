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
    public partial class frmImageForSeek : Form
    {
        public DataSet dataSet;
        public frmImageForSeek()
        {
            InitializeComponent();
        }

        private void frmImageForSeek_Load(object sender, EventArgs e)
        {
            connectDataBase();
            showImage();
        }
        public void connectDataBase()
        {
            string A = frmForSeek.a;
            string B = frmForSeek.b;
            string newB = B.Replace("物料名称", "F_Name").Replace("物料编码", "F_ID").Replace("物料规格", "F_Spec").Replace("物料品牌", "F_Brand").Replace("物料类别", "F_Kind").Replace("物料颜色", "F_Color").Replace("物料存放位置", "F_Position").Replace("图片", "F_Photo").Replace("物料材质", "F_Attrib");
            string connection = ConfigurationManager.AppSettings["Connection"];
            SqlConnection sql = new SqlConnection(connection);
            string select = $"Select F_Photo From t_Item where {newB}=@id";
            SqlCommand command = new SqlCommand(select, sql);
            command.Parameters.AddWithValue("@id", A);
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
            catch (Exception)
            {
                MessageBox.Show("还没有放入图片");
                this.Close();
            }
        }
    }
}
