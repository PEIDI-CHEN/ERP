namespace Common
{
    partial class frmGraphi
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private new System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.Bar3DSeriesLabel bar3DSeriesLabel1 = new DevExpress.XtraCharts.Bar3DSeriesLabel();
            this.Chart = new DevExpress.XtraCharts.ChartControl();
            this.sbPrint = new DevExpress.XtraEditors.SimpleButton();
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart
            // 
            this.Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart.Legend.Name = "Default Legend";
            this.Chart.Location = new System.Drawing.Point(16, 66);
            this.Chart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chart.Name = "Chart";
            this.Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            bar3DSeriesLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            bar3DSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;
            this.Chart.SeriesTemplate.Label = bar3DSeriesLabel1;
            this.Chart.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.Chart.SeriesTemplate.LegendTextPattern = "{S}";
            this.Chart.Size = new System.Drawing.Size(896, 564);
            this.Chart.TabIndex = 0;
            // 
            // sbPrint
            // 
            this.sbPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbPrint.Location = new System.Drawing.Point(589, 16);
            this.sbPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sbPrint.Name = "sbPrint";
            this.sbPrint.Size = new System.Drawing.Size(100, 31);
            this.sbPrint.TabIndex = 1;
            this.sbPrint.Text = "打印(&P)";
            this.sbPrint.Click += new System.EventHandler(this.sbPrint_Click);
            // 
            // sbExport
            // 
            this.sbExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbExport.Location = new System.Drawing.Point(697, 16);
            this.sbExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(100, 31);
            this.sbExport.TabIndex = 2;
            this.sbExport.Text = "引出(&E)";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // sbClose
            // 
            this.sbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbClose.Location = new System.Drawing.Point(812, 16);
            this.sbClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(100, 31);
            this.sbClose.TabIndex = 3;
            this.sbClose.Text = "关闭(&C)";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // frmGraphi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(928, 647);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.sbExport);
            this.Controls.Add(this.sbPrint);
            this.Controls.Add(this.Chart);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmGraphi";
            this.Text = "图表专家";
            this.Load += new System.EventHandler(this.frmGraphi_Load);
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl Chart;
        private DevExpress.XtraEditors.SimpleButton sbPrint;
        private DevExpress.XtraEditors.SimpleButton sbExport;
        private DevExpress.XtraEditors.SimpleButton sbClose;
    }
}
