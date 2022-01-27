using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraReports;

namespace myControl
{
    public partial class CustomDesignForm : DevExpress.XtraReports.UserDesigner.XRDesignFormEx
    {
        protected override void SaveLayout()
        {
            base.SaveLayout();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDesignForm));
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // xrDesignPanel
            // 
            resources.ApplyResources(this.xrDesignPanel, "xrDesignPanel");
            // 
            // CustomDesignForm
            // 
            resources.ApplyResources(this, "$this");
            this.KeyPreview = true;
            this.Name = "CustomDesignForm";
            this.Controls.SetChildIndex(this.xrDesignPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
