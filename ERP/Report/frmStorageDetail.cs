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

        //11��25�մ����޸�
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
        //11��24��������룬û��ʵ�ֹ���
        private void gcReport_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("gridcontrol˫���¼�");
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
        //11��25�������ܣ�û��ʵ�ֹ���
        private void gcReport_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string st = "";
            //ColumnView cv = (ColumnView)gcReport.FocusedView;//���»�ȡ��ID �����޷��ӱ�ͷ��ɾ��ȡ����id
            //int focusedhandle = cv.FocusedRowHandle;
            //object rowIdObj = gvReport.GetRowCellValue(focusedhandle, "���պ�");

            ////            string aa =gridView1.GetSelectedRows

            ////�õ���ǰ�е�RowHandle   
            //DataRow myDataRow = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            //st = myDataRow["���պ�"].ToString();
            //MessageBox.Show(st);

        }
        //��ͼ����ӹ��ܣ�Ҳ��Ч
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
            //    //�жϹ���Ƿ����з�Χ�� 
            //    if (hInfo.InRow)
            //    {
            //        //ȡ��ѡ������Ϣ  ------   ����д˫�������
            //        string nodeName = gvReport.GetRowCellValue(gvReport.FocusedRowHandle, "nodeName").ToString();
                   //MessageBox.Show("gridview MouseDown�¼�");
            //    }
            //}
        }
        public static int number;
        //11��30�Ÿ��´��룺ʵ�ֵ������
        private void gcReport_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("��������");
            //number = Convert.ToInt32(gvReport.GetRowCellValue(gvReport.FocusedRowHandle, "���ϱ��"));
            //frmForStorageDetail newForm = new frmForStorageDetail();
            //newForm.Show();
        }
        //12��1���������룺ͨ�������ؼ��鿴ͼƬ
        private void showImage_Click(object sender, EventArgs e)
        {
            //number = Convert.ToInt32(gvReport.GetRowCellValue(gvReport.FocusedRowHandle, "���ϱ��"));
            //MessageBox.Show(number.ToString());
        }
    }
}

