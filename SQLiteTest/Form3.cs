using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "companyBD.ИнформацияОРуководителях". При необходимости она может быть перемещена или удалена.
            this.ИнформацияОРуководителяхTableAdapter.Fill(this.companyBD.ИнформацияОРуководителях);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "companyBD.СредняяЗП". При необходимости она может быть перемещена или удалена.
            this.ИнформацияОРуководителяхTableAdapter.Fill(this.companyBD.ИнформацияОРуководителях);
            this.reportViewer1.RefreshReport();

        }
    }
}
