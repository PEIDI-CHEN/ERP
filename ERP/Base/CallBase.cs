using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    class CallBase
    {
        public void ShowItemNew()
        {
            frmEditItem myEditItem = new frmEditItem();
            myEditItem.New();
            myEditItem.ShowDialog();
            myEditItem.Dispose();
        }

        public void ShowItemEdit(string strItemID)
        {
            frmEditItem myEditItem = new frmEditItem();
            myEditItem.Edit(strItemID);
            myEditItem.ShowDialog();
            myEditItem.Dispose();
        }

        public void ShowSupplierNew()
        {
            frmEditSupplier myEditSupplier = new frmEditSupplier();
            myEditSupplier.New();
            myEditSupplier.ShowDialog();
            myEditSupplier.Dispose();
        }

        public void ShowSupplierEdit(string strItemID)
        {
            frmEditSupplier myEditSupplier = new frmEditSupplier();
            myEditSupplier.Edit(strItemID);
            myEditSupplier.ShowDialog();
            myEditSupplier.Dispose();
        }

        public void ShowProductNew()
        {
            frmEditProduct myEditProduct = new frmEditProduct();
            myEditProduct.New();
            myEditProduct.ShowDialog();
            myEditProduct.Dispose();
        }

        public void ShowProductEdit(string strItemID)
        {
            frmEditProduct myEditProduct = new frmEditProduct();
            myEditProduct.Edit(strItemID);
            myEditProduct.ShowDialog();
            myEditProduct.Dispose();
        }
    }
}
