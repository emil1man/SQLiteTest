namespace SQLiteTest
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.СотрудникиЗПBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyBD = new SQLiteTest.companyBD();
            this.СредняяЗПBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.СотрудникиЗПTableAdapter = new SQLiteTest.companyBDTableAdapters.СотрудникиЗПTableAdapter();
            this.СредняяЗПTableAdapter = new SQLiteTest.companyBDTableAdapters.СредняяЗПTableAdapter();
            this.средняяЗПTableAdapter1 = new SQLiteTest.companyBDTableAdapters.СредняяЗПTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.СотрудникиЗПBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.СредняяЗПBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // СотрудникиЗПBindingSource
            // 
            this.СотрудникиЗПBindingSource.DataMember = "СотрудникиЗП";
            this.СотрудникиЗПBindingSource.DataSource = this.companyBD;
            // 
            // companyBD
            // 
            this.companyBD.DataSetName = "companyBD";
            this.companyBD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // СредняяЗПBindingSource
            // 
            this.СредняяЗПBindingSource.DataMember = "СредняяЗП";
            this.СредняяЗПBindingSource.DataSource = this.companyBD;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "avgSal";
            reportDataSource1.Value = this.СредняяЗПBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SQLiteTest.AvgSalary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(916, 383);
            this.reportViewer1.TabIndex = 0;
            // 
            // СотрудникиЗПTableAdapter
            // 
            this.СотрудникиЗПTableAdapter.ClearBeforeFill = true;
            // 
            // СредняяЗПTableAdapter
            // 
            this.СредняяЗПTableAdapter.ClearBeforeFill = true;
            // 
            // средняяЗПTableAdapter1
            // 
            this.средняяЗПTableAdapter1.ClearBeforeFill = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 383);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.СотрудникиЗПBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.СредняяЗПBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource СотрудникиЗПBindingSource;
        private companyBD companyBD;
        private System.Windows.Forms.BindingSource СредняяЗПBindingSource;
        private companyBDTableAdapters.СотрудникиЗПTableAdapter СотрудникиЗПTableAdapter;
        private companyBDTableAdapters.СредняяЗПTableAdapter СредняяЗПTableAdapter;
        private companyBDTableAdapters.СредняяЗПTableAdapter средняяЗПTableAdapter1;
    }
}