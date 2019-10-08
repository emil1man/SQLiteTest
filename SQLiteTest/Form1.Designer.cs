namespace SQLiteTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Wor = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.l_worName = new System.Windows.Forms.Label();
            this.l_worPos = new System.Windows.Forms.Label();
            this.tb_worName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.tb_worPos = new System.Windows.Forms.ComboBox();
            this.tab_Sup = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.l_SupName = new System.Windows.Forms.Label();
            this.l_empName = new System.Windows.Forms.Label();
            this.cb_Sup = new System.Windows.Forms.ComboBox();
            this.cb_Wor = new System.Windows.Forms.ComboBox();
            this.butt_SetSupOnWor = new System.Windows.Forms.Button();
            this.butt_ShowWorForSup = new System.Windows.Forms.Button();
            this.tb_outTree = new System.Windows.Forms.TextBox();
            this.tab_Out = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tab_Wor.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tab_Sup.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tab_Out.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Wor);
            this.tabControl1.Controls.Add(this.tab_Sup);
            this.tabControl1.Controls.Add(this.tab_Out);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 281);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_Wor
            // 
            this.tab_Wor.Controls.Add(this.tableLayoutPanel1);
            this.tab_Wor.Location = new System.Drawing.Point(4, 22);
            this.tab_Wor.Name = "tab_Wor";
            this.tab_Wor.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Wor.Size = new System.Drawing.Size(616, 255);
            this.tab_Wor.TabIndex = 0;
            this.tab_Wor.Text = "Сотрудники";
            this.tab_Wor.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.l_worName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.l_worPos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_worName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_output, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tb_worPos, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 249);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // l_worName
            // 
            this.l_worName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_worName.Location = new System.Drawing.Point(3, 0);
            this.l_worName.Name = "l_worName";
            this.l_worName.Size = new System.Drawing.Size(197, 30);
            this.l_worName.TabIndex = 0;
            this.l_worName.Text = "Имя сотрудника";
            this.l_worName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // l_worPos
            // 
            this.l_worPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_worPos.Location = new System.Drawing.Point(206, 0);
            this.l_worPos.Name = "l_worPos";
            this.l_worPos.Size = new System.Drawing.Size(197, 30);
            this.l_worPos.TabIndex = 1;
            this.l_worPos.Text = "Должность";
            this.l_worPos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tb_worName
            // 
            this.tb_worName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_worName.Location = new System.Drawing.Point(3, 35);
            this.tb_worName.Name = "tb_worName";
            this.tb_worName.Size = new System.Drawing.Size(197, 20);
            this.tb_worName.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(409, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить сотрудника";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddWorker_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(409, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "Найти сотрудника по имени";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SearchForWorker_Click);
            // 
            // tb_output
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_output, 3);
            this.tb_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_output.Location = new System.Drawing.Point(3, 63);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_output.Size = new System.Drawing.Size(604, 183);
            this.tb_output.TabIndex = 6;
            // 
            // tb_worPos
            // 
            this.tb_worPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_worPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_worPos.FormattingEnabled = true;
            this.tb_worPos.Location = new System.Drawing.Point(206, 34);
            this.tb_worPos.Name = "tb_worPos";
            this.tb_worPos.Size = new System.Drawing.Size(197, 21);
            this.tb_worPos.TabIndex = 7;
            // 
            // tab_Sup
            // 
            this.tab_Sup.Controls.Add(this.tableLayoutPanel2);
            this.tab_Sup.Location = new System.Drawing.Point(4, 22);
            this.tab_Sup.Name = "tab_Sup";
            this.tab_Sup.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Sup.Size = new System.Drawing.Size(616, 255);
            this.tab_Sup.TabIndex = 1;
            this.tab_Sup.Text = "Руководители";
            this.tab_Sup.UseVisualStyleBackColor = true;
            this.tab_Sup.Enter += new System.EventHandler(this.UpdateWorkersInfoByOpeningTab);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.l_SupName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.l_empName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cb_Sup, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cb_Wor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.butt_SetSupOnWor, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.butt_ShowWorForSup, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tb_outTree, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(610, 249);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // l_SupName
            // 
            this.l_SupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_SupName.Location = new System.Drawing.Point(3, 0);
            this.l_SupName.Name = "l_SupName";
            this.l_SupName.Size = new System.Drawing.Size(299, 30);
            this.l_SupName.TabIndex = 0;
            this.l_SupName.Text = "Имя руководителя";
            this.l_SupName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // l_empName
            // 
            this.l_empName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_empName.Location = new System.Drawing.Point(308, 0);
            this.l_empName.Name = "l_empName";
            this.l_empName.Size = new System.Drawing.Size(299, 30);
            this.l_empName.TabIndex = 1;
            this.l_empName.Text = "Имя сотрудника";
            this.l_empName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cb_Sup
            // 
            this.cb_Sup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Sup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Sup.FormattingEnabled = true;
            this.cb_Sup.Location = new System.Drawing.Point(3, 33);
            this.cb_Sup.Name = "cb_Sup";
            this.cb_Sup.Size = new System.Drawing.Size(299, 21);
            this.cb_Sup.TabIndex = 2;
            // 
            // cb_Wor
            // 
            this.cb_Wor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Wor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Wor.FormattingEnabled = true;
            this.cb_Wor.Location = new System.Drawing.Point(308, 33);
            this.cb_Wor.Name = "cb_Wor";
            this.cb_Wor.Size = new System.Drawing.Size(299, 21);
            this.cb_Wor.TabIndex = 3;
            // 
            // butt_SetSupOnWor
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.butt_SetSupOnWor, 2);
            this.butt_SetSupOnWor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_SetSupOnWor.Location = new System.Drawing.Point(3, 63);
            this.butt_SetSupOnWor.Name = "butt_SetSupOnWor";
            this.butt_SetSupOnWor.Size = new System.Drawing.Size(604, 24);
            this.butt_SetSupOnWor.TabIndex = 4;
            this.butt_SetSupOnWor.Text = "Назначить руководителем";
            this.butt_SetSupOnWor.UseVisualStyleBackColor = true;
            this.butt_SetSupOnWor.Click += new System.EventHandler(this.SetSupOnWor_Click);
            // 
            // butt_ShowWorForSup
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.butt_ShowWorForSup, 2);
            this.butt_ShowWorForSup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_ShowWorForSup.Location = new System.Drawing.Point(3, 93);
            this.butt_ShowWorForSup.Name = "butt_ShowWorForSup";
            this.butt_ShowWorForSup.Size = new System.Drawing.Size(604, 24);
            this.butt_ShowWorForSup.TabIndex = 5;
            this.butt_ShowWorForSup.Text = "Отобразить подчиненных";
            this.butt_ShowWorForSup.UseVisualStyleBackColor = true;
            this.butt_ShowWorForSup.Click += new System.EventHandler(this.ShowWorForSup_Click);
            // 
            // tb_outTree
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tb_outTree, 2);
            this.tb_outTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_outTree.Location = new System.Drawing.Point(3, 123);
            this.tb_outTree.Multiline = true;
            this.tb_outTree.Name = "tb_outTree";
            this.tb_outTree.ReadOnly = true;
            this.tb_outTree.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_outTree.Size = new System.Drawing.Size(604, 123);
            this.tb_outTree.TabIndex = 6;
            // 
            // tab_Out
            // 
            this.tab_Out.Controls.Add(this.tableLayoutPanel3);
            this.tab_Out.Location = new System.Drawing.Point(4, 22);
            this.tab_Out.Name = "tab_Out";
            this.tab_Out.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Out.Size = new System.Drawing.Size(616, 255);
            this.tab_Out.TabIndex = 2;
            this.tab_Out.Text = "Отчёты";
            this.tab_Out.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.button4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button5, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(610, 249);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(604, 77);
            this.button3.TabIndex = 1;
            this.button3.Text = "Создать отчёт о зарплатах сотрудников за 6 месяцев";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 86);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(604, 77);
            this.button4.TabIndex = 2;
            this.button4.Text = "Вывести информацию о руководителях";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(3, 169);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(604, 77);
            this.button5.TabIndex = 3;
            this.button5.Text = "Отчёт о средних ЗП по должностям";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(640, 320);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_Wor.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tab_Sup.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tab_Out.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Wor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label l_worName;
        private System.Windows.Forms.Label l_worPos;
        private System.Windows.Forms.TextBox tb_worName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox tb_worPos;
        private System.Windows.Forms.TabPage tab_Sup;
        private System.Windows.Forms.TabPage tab_Out;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label l_SupName;
        private System.Windows.Forms.Label l_empName;
        private System.Windows.Forms.ComboBox cb_Sup;
        private System.Windows.Forms.ComboBox cb_Wor;
        private System.Windows.Forms.Button butt_SetSupOnWor;
        private System.Windows.Forms.Button butt_ShowWorForSup;
        private System.Windows.Forms.TextBox tb_outTree;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

