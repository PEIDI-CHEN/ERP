using Base;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmStorageDetail : Common.frmReport
    {
        public frmStorageDetail()
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

        //11月25日代码修改
        private void frmStorageSum_Load(object sender, EventArgs e)
        {
            judge = 1;
            //this.dtValue = Convert.ToDateTime(deMonth.EditValue);
            //this.strItemType = cbType.Text;
            //if (gvReport.FocusedRowHandle < 0) return;
            //base.Edit();
            //DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            //frmEditItem myEditItem = new frmEditItem();
            //myEditItem.Edit(dr["F_ID"].ToString());
            //if (myEditItem.ShowDialog() == DialogResult.OK)
            //    BindData();
            //myEditItem.Dispose();
        }
        private void sbRefresh_Click(object sender, EventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }
        //11月24日增添代码，没有实现功能
        private void gcReport_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("gridcontrol双击事件");
            //string colValue = this.gvReport.GetRowCellValue(this.gvReport.FocusedRowHandle, this.gvReport.Columns[1]).ToString();
            //if (gvReport.FocusedRowHandle < 0) return;
            //base.Edit();
            //DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            //frmEditItem myEditItem = new frmEditItem();
            //myEditItem.Edit(dr["F_ID"].ToString());
            //if (myEditItem.ShowDialog() == DialogResult.OK)
            //    BindData();
            //myEditItem.Dispose();

        }
        //11月25日增添功能，没有实现功能
        private void gcReport_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string st = "";
            //ColumnView cv = (ColumnView)gcReport.FocusedView;//重新获取此ID 否则无法从表头连删获取不到id
            //int focusedhandle = cv.FocusedRowHandle;
            //object rowIdObj = gvReport.GetRowCellValue(focusedhandle, "工艺号");

            ////            string aa =gridView1.GetSelectedRows

            ////得到当前行的RowHandle   
            //DataRow myDataRow = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            //st = myDataRow["工艺号"].ToString();
            //MessageBox.Show(st);

        }
        //视图层添加功能，也无效
        private void gvReport_Click(object sender, EventArgs e)
        {
            //string colValue = this.gvReport.GetRowCellValue(this.gvReport.FocusedRowHandle, this.gvReport.Columns[1]).ToString();
            //if (gvReport.FocusedRowHandle < 0) return;
            //base.Edit();
            //DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            //frmEditItem myEditItem = new frmEditItem();
            //myEditItem.Edit(dr["F_ID"].ToString());
            //if (myEditItem.ShowDialog() == DialogResult.OK)
            //    BindData();
            //myEditItem.Dispose();
            //myEditItem.Show();
        }

        private void gvReport_MouseDown(object sender, MouseEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvReport.CalcHitInfo(new Point(e.X, e.Y));
            //if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    //判断光标是否在行范围内 
            //    if (hInfo.InRow)
            //    {
            //        //取得选定行信息  ------   这里写双击后操作
            //        string nodeName = gvReport.GetRowCellValue(gvReport.FocusedRowHandle, "nodeName").ToString();
                   //MessageBox.Show("gridview MouseDown事件");
            //    }
            //}
        }
        public static int number;
        //11月30号更新代码：实现点击功能
        private void gcReport_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("初步测试");
            //number = Convert.ToInt32(gvReport.GetRowCellValue(gvReport.FocusedRowHandle, "物料编号"));
            //frmForStorageDetail newForm = new frmForStorageDetail();
            //newForm.Show();
        }
        //12月1日新增代码：通过新增控件查看图片
        private void showImage_Click(object sender, EventArgs e)
        {
            //number = Convert.ToInt32(gvReport.GetRowCellValue(gvReport.FocusedRowHandle, "物料编号"));
            //MessageBox.Show(number.ToString());
        }
    }
}

