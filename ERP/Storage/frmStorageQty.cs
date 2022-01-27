using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class frmStorageQty : Common.frmReport
    {
        public frmStorageQty()
        {
            InitializeComponent();
            ucDate.Visible = true;
            rgOption.Visible = true;
            bNormal = true;
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Kind", cbKind.Text);//����Ʒ

            /*
            //return base.GetParm2();
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Kind";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            parm[0].Value = cbKind.Text;
            */
            return parm;
        }

        private void frmStorageQty_Load(object sender, EventArgs e)
        {
            /*
            string[] strKind;
            cbKind.Properties.Items.Clear();
            DataLib.sysClass myClass = new DataLib.sysClass();
            strKind = myClass.GetItemKind();

            for (int i = 0; i < strKind.Length; i++)
            {
                cbKind.Properties.Items.Add(strKind[i]);
            }
            */

            if (cbKind.Properties.Items.Count > 0)
                cbKind.SelectedIndex = 0;
        }

        private void cbKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void frmStorageQty_KeyDown(object sender, KeyEventArgs e)
        {
            //����Bom������
            if (e.KeyCode == Keys.F6)
            {
                if (gvReport.FocusedRowHandle < 0) return;
                 DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
              
                if (dr["F_ItemID"] == DBNull.Value) return;
                Common.frmBomStoreQty F = new Common.frmBomStoreQty(dr["F_ItemID"].ToString());
                F.ShowDialog();
                F.Dispose();
            }
        }

        //protected override 
    }
}

