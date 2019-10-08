namespace SQLiteTest
{
    partial class Form2
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.СотрудникиЗПBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyBD = new SQLiteTest.companyBD();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.СотрудникиЗПTableAdapter = new SQLiteTest.companyBDTableAdapters.СотрудникиЗПTableAdapter();
            this.СуммаЗПBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.СуммаЗПTableAdapter = new SQLiteTest.companyBDTableAdapters.СуммаЗПTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.СотрудникиЗПBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.СуммаЗПBindingSource)).BeginInit();
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
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "salWor";
            reportDataSource1.Value = this.СотрудникиЗПBindingSource;
            reportDataSource2.Name = "sumSalWor";
            reportDataSource2.Value = this.СуммаЗПBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SQLiteTest.AllWorksSalLast6MM.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(916, 383);
            this.reportViewer1.TabIndex = 0;
            // 
            // СотрудникиЗПTableAdapter
            // 
            this.СотрудникиЗПTableAdapter.ClearBeforeFill = true;
            // 
            // СуммаЗПBindingSource
            // 
            this.СуммаЗПBindingSource.DataMember = "СуммаЗП";
            this.СуммаЗПBindingSource.DataSource = this.companyBD;
            // 
            // СуммаЗПTableAdapter
            // 
            this.СуммаЗПTableAdapter.ClearBeforeFill = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 383);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.СотрудникиЗПBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.СуммаЗПBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource СотрудникиЗПBindingSource;
        private companyBD companyBD;
        private companyBDTableAdapters.СотрудникиЗПTableAdapter СотрудникиЗПTableAdapter;
        private System.Windows.Forms.BindingSource СуммаЗПBindingSource;
        private companyBDTableAdapters.СуммаЗПTableAdapter СуммаЗПTableAdapter;
    }
}