namespace SQLiteTest
{
    partial class Form3
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.companyBD = new SQLiteTest.companyBD();
            this.СредняяЗПBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.СредняяЗПTableAdapter = new SQLiteTest.companyBDTableAdapters.СредняяЗПTableAdapter();
            this.ИнформацияОРуководителяхBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ИнформацияОРуководителяхTableAdapter = new SQLiteTest.companyBDTableAdapters.ИнформацияОРуководителяхTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.companyBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.СредняяЗПBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ИнформацияОРуководителяхBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "supInfo";
            reportDataSource1.Value = this.ИнформацияОРуководителяхBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SQLiteTest.Reports.SupInfo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(916, 383);
            this.reportViewer1.TabIndex = 1;
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
            // СредняяЗПTableAdapter
            // 
            this.СредняяЗПTableAdapter.ClearBeforeFill = true;
            // 
            // ИнформацияОРуководителяхBindingSource
            // 
            this.ИнформацияОРуководителяхBindingSource.DataMember = "ИнформацияОРуководителях";
            this.ИнформацияОРуководителяхBindingSource.DataSource = this.companyBD;
            // 
            // ИнформацияОРуководителяхTableAdapter
            // 
            this.ИнформацияОРуководителяхTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 383);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.СредняяЗПBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ИнформацияОРуководителяхBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource СредняяЗПBindingSource;
        private companyBD companyBD;
        private companyBDTableAdapters.СредняяЗПTableAdapter СредняяЗПTableAdapter;
        private System.Windows.Forms.BindingSource ИнформацияОРуководителяхBindingSource;
        private companyBDTableAdapters.ИнформацияОРуководителяхTableAdapter ИнформацияОРуководителяхTableAdapter;
    }
}