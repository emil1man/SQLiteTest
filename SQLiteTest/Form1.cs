using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace SQLiteTest
{
    public partial class Form1 : Form
    {
        private SQLiteConnection sqLiteConnection;  // Переменная для подключения к БД "testBD.db"
        List<string[]> possibleSupervisers = new List<string[]>();  // Переменная для хранения найденных MNG и SLM
        List<string[]> possibleEmployees = new List<string[]>();  // Переменная для хранения Сотрудников без Начальника
        Node compStruct = new Node(0);  // Переменная для хранения и работы с иерархией предприятия, хранящая в себе ID работника и List<> с Nodes подчиненных. Т.к. сотрудника с ID 0 не существует, то сотрудники без начальника будут ссылаться на 0.

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqLiteConnection = new SQLiteConnection("Data Source=testBD.db");   // Переменная для подключения к БД "testBD.db"
            sqLiteConnection.Open();    // Подключение к БД "testBD.db"
            SQLiteCommand CMD = new SQLiteCommand("SELECT * FROM Должности ORDER BY ID", sqLiteConnection); // Исполнитель запросов (первый аргумент) в таблице подключенной к БД через "sqLiteConnection"
            SQLiteDataReader sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            while (sqLiteDataReader.Read()) // Цикл будет считывать записи в "sqLiteDataReader" до последней 
            {
                tb_worPos.Items.Add(sqLiteDataReader[1]);   // Заполняем названиями должностей выпадающий список из первого столбца
            }
            tb_worPos.SelectedIndex = 0;    // Выбираем значение по умолчанию
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqLiteConnection.Close();   // Отключение от БД "testBD.db"
        }

        private void AddWorker_Click(object sender, EventArgs e)
        {
            if (tb_worName.Text != "")
            {
                SQLiteCommand CMD = new SQLiteCommand("INSERT INTO Сотрудники (Имя, Должность, ДатаТрудоустройства) VALUES (@Name, @Position, @Date)", sqLiteConnection);   // Исполнитель запросов (первый аргумент) в таблице подключенной к БД через "sqLiteConnection"
                CMD.Parameters.Add("@Name", System.Data.DbType.String).Value = tb_worName.Text.ToUpper();   // Параметр в который записывается Имя
                CMD.Parameters.Add("@Position", System.Data.DbType.Int32).Value = tb_worPos.SelectedIndex;  // Параметр в который записывается должность
                CMD.Parameters.Add("@Date", System.Data.DbType.DateTime).Value = DateTime.Today.ToString("O").Split('T')[0];    // Параметр в который записывается текущая дата
                CMD.ExecuteNonQuery();  // Выполнить запрос
                CMD = new SQLiteCommand("INSERT INTO Иерархия (Работник) SELECT (ID) FROM Сотрудники WHERE ID = (SELECT MAX(ID) FROM Сотрудники)", sqLiteConnection);   // Добавляем запись о новом работнике в таблицу Иерархия
                CMD.ExecuteNonQuery();
                tb_output.Text = "Новый сотрудник добавлен в базу. \r\nИмя: " + tb_worName.Text.ToUpper().ToString() + "\r\nДолжность: " + tb_worPos.SelectedItem + "\r\nДата трудоустройства: " + DateTime.Today.ToString("O").Split('T')[0];  // Сообщение показывающее введеные данные 
            }
        }   // Нажатие кнопки "Добавить сотрудника"

        private void SearchForWorker_Click(object sender, EventArgs e)
        {
            tb_output.Text = "ID\tИмя\tДолжность\tДата Трудоустройства\r\n";
            if (tb_worName.Text != "")
            {
                SQLiteCommand CMD = new SQLiteCommand("SELECT * FROM Сотрудники WHERE Сотрудники.Имя like '%' || @Name || '%'", sqLiteConnection);  // Исполнитель запросов (первый аргумент) в таблице подключенной к БД через "sqLiteConnection"
                CMD.Parameters.Add("@Name", System.Data.DbType.String).Value = tb_worName.Text.ToUpper();   // Параметр в который записывается Имя
                CMD.ExecuteNonQuery();  // Выполнить запрос
                SQLiteDataReader sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
                if (sqLiteDataReader.HasRows)
                {
                    while (sqLiteDataReader.Read())
                    {
                        tb_output.Text += sqLiteDataReader["ID"] + "\t" + sqLiteDataReader["Имя"] + "\t" + tb_worPos.Items[Convert.ToInt32(sqLiteDataReader["Должность"].ToString()) - 1] + "\t\t" + sqLiteDataReader["ДатаТрудоустройства"] + "\r\n";
                    }
                }

            }
        }   // Поиск среди имён сотрудников попадания @Name

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime(2018, 10, 7, 0, 0, 0);
            DateTime dt2 = DateTime.Now;
            if (dt1.DayOfYear <= DateTime.Now.DayOfYear)
            {
                MessageBox.Show((dt2.Year - dt1.Year).ToString());
            }
            else
            {
                MessageBox.Show((dt2.Year - dt1.Year - 1).ToString());
            }
        }

        private void UpdateWorkersInfoByOpeningTab(object sender, EventArgs e)
        {
            possibleSupervisers.Clear();
            possibleEmployees.Clear();
            cb_Sup.Items.Clear();
            cb_Wor.Items.Clear();

            SQLiteCommand CMD = new SQLiteCommand("SELECT * FROM Сотрудники WHERE Сотрудники.Должность <> 1", sqLiteConnection);    // Отображает всех MNG и SLM
            SQLiteDataReader sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            while (sqLiteDataReader.Read()) // Цикл будет считывать записи в "sqLiteDataReader" до последней 
            {
                possibleSupervisers.Add(new string[4]);
                string s = "";  // Переменная для хранения строки для выпадающего списка

                possibleSupervisers[possibleSupervisers.Count - 1][0] = sqLiteDataReader[0].ToString();
                possibleSupervisers[possibleSupervisers.Count - 1][1] = sqLiteDataReader[1].ToString();
                possibleSupervisers[possibleSupervisers.Count - 1][2] = tb_worPos.Items[Convert.ToInt32(sqLiteDataReader[2]) - 1].ToString();
                possibleSupervisers[possibleSupervisers.Count - 1][3] = sqLiteDataReader[3].ToString();
                for (int i = 0; i < 4; i++)
                {
                    s += possibleSupervisers[possibleSupervisers.Count - 1][i] + " ";
                }
                cb_Sup.Items.Add(s);
            }
            // Добавляем в выпадающий список сотрудников, которые могут иметь подчиненных

            CMD = new SQLiteCommand("SELECT Сотрудники.ID, Сотрудники.Имя, Сотрудники.Должность, Сотрудники.ДатаТрудоустройства FROM Иерархия LEFT JOIN Сотрудники ON Иерархия.Работник = Сотрудники.ID WHERE Иерархия.Начальник IS NULL;", sqLiteConnection); // Отображает всех сотрудников без начальника
            sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            while (sqLiteDataReader.Read()) // Цикл будет считывать записи в "sqLiteDataReader" до последней 
            {
                possibleEmployees.Add(new string[4]);
                string s = "";  // Переменная для хранения строки для выпадающего списка

                possibleEmployees[possibleEmployees.Count - 1][0] = sqLiteDataReader[0].ToString();
                possibleEmployees[possibleEmployees.Count - 1][1] = sqLiteDataReader[1].ToString();
                possibleEmployees[possibleEmployees.Count - 1][2] = tb_worPos.Items[Convert.ToInt32(sqLiteDataReader[2]) - 1].ToString();
                possibleEmployees[possibleEmployees.Count - 1][3] = sqLiteDataReader[3].ToString();
                for (int i = 0; i < 4; i++)
                {
                    s += possibleEmployees[possibleEmployees.Count - 1][i] + " ";
                }
                cb_Wor.Items.Add(s);
            }
            // Добавляем в выпадающий список сотрудников, которые не имеют руководителя

            CMD = new SQLiteCommand("SELECT * FROM Иерархия", sqLiteConnection); // Отображает всех сотрудников без начальника
            sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"

            while (sqLiteDataReader.Read())
            {
                int idS = 0;
                if (sqLiteDataReader[2].ToString() != "") { idS = Convert.ToInt32(sqLiteDataReader[2].ToString()); }
                Node.NodesAdd(compStruct, idS, Convert.ToInt32(sqLiteDataReader[1].ToString()));
            }
            // Заполняем Nodes 


        } // Загрузка Информации о сотрудниках при переключении вкладки

        private void SetSupOnWor_Click(object sender, EventArgs e)
        {
            if (cb_Sup.Text != "" && cb_Wor.Text != "")
            {
                if (cb_Sup.Text != cb_Wor.Text)
                {
                    int ID_Sup = Convert.ToInt32(possibleSupervisers[cb_Sup.SelectedIndex][0]);
                    int ID_Wor = Convert.ToInt32(possibleEmployees[cb_Wor.SelectedIndex][0]);
                    SQLiteCommand CMD = new SQLiteCommand("UPDATE Иерархия SET Начальник = @idSup WHERE Иерархия.Работник = @idWor", sqLiteConnection);   // Исполнитель запросов (первый аргумент) в таблице подключенной к БД через "sqLiteConnection"
                    CMD.Parameters.Add("@idWor", System.Data.DbType.Int32).Value = ID_Wor;   // Параметр в который записывается Работник
                    CMD.Parameters.Add("@idSup", System.Data.DbType.Int32).Value = ID_Sup;  // Параметр в который записывается Начальник
                    Node.NodesAdd(compStruct, ID_Sup, ID_Wor);  // Добавить в структуру иерархии выбранные данные
                    CMD.ExecuteNonQuery();  // Выполнить запрос
                    MessageBox.Show("Руководитель успешно назначен.");
                }
                else
                {
                    MessageBox.Show("Сотрудник не может руководить сам собой.");
                }
            }
            else
            {
                MessageBox.Show("Заполните оба выпадающих списка.");
            };
        }   // Назначает руководителя сотруднику

        private void ShowWorForSup_Click(object sender, EventArgs e)
        {
            SQLiteCommand CMD = new SQLiteCommand("SELECT * FROM Сотрудники", sqLiteConnection);    // Отображает всех MNG и SLM
            SQLiteDataReader sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            List<string[]> workersAll = new List<string[]>();

            while (sqLiteDataReader.Read()) // Цикл будет считывать записи в "sqLiteDataReader" до последней 
            {
                workersAll.Add(new string[2]);
                workersAll[workersAll.Count - 1][0] = sqLiteDataReader[1].ToString();
                workersAll[workersAll.Count - 1][1] = tb_worPos.Items[Convert.ToInt32(sqLiteDataReader[2]) - 1].ToString();
            }   // Заполняет массив работников их фамилиями и должностями

            string hierarchy = Node.NodesFindShowByID(compStruct, 0, Convert.ToInt32(possibleSupervisers[cb_Sup.SelectedIndex][0])); // Поиск в Иерархии по выбранному в cb ID и вывод в строковое представление
            Regex reg = new Regex(@"[\d]+", RegexOptions.Multiline);    // Создание регулярного выражения для поиска ID
            int max = Regex.Matches(hierarchy, @"[\d]+").Count; // Вычисление кол-ва позиций
            for (int i = 0; i < max; i++)
            {
                string[] temp = workersAll[Convert.ToInt32(Regex.Match(hierarchy, @"[\d]+").Value) - 1];
                hierarchy = reg.Replace(hierarchy, temp[0] + " " + temp[1], 1);
            }   // Замена цифр на имена по ID сотрудника
            tab_Sup.Update();
            tb_outTree.Text = hierarchy;
        }   // Отображает руководителя со всеми подчиненными
    }

    public class Node
    {
        public int ID { get; set; }
        public int Supervisor { get; set; }
        public List<Node> Employees { get; set; }

        public Node(int workerID)
        {
            this.ID = workerID;
            Employees = new List<Node>();
        }
        void Add(Node item)
        {
            item.Supervisor = this.ID;
            this.Employees.Add(item);
        }

        public static string NodesShow(Node nd, int lvl)
        {
            string s = nd.ID.ToString();
            string t = "\r\n";
            for (int i = 0; i <= lvl; i++)
            {
                t += "-";
            }
            if (nd.Employees.Count > 0)
            {
                for (int i = 0; i < nd.Employees.Count; i++)
                {
                    s += t + NodesShow(nd.Employees[i], lvl + 1);
                }
            }
            return s;
        }
        // Вывести все узслы начиная с корня nd. lvl нужно для корректного добавления отступов
        public static bool NodesAdd(Node nd, int idSup, int idWor)
        {
            bool addeed = false;
            if (nd.ID == idSup && !addeed)
            {
                nd.Add(new Node(idWor));
                addeed = true;
            }
            else
            {
                if (nd.Employees.Count > 0)
                {
                    for (int i = 0; i < nd.Employees.Count; i++)
                    {
                        if (!addeed) addeed = NodesAdd(nd.Employees[i], idSup, idWor); else break;
                    }
                }
            }
            return addeed;
        }
        // Добавляет в узел nd с ID = idSup узел с ID = idWor
        public static string NodesFindShowByID(Node nd, int level, int id)
        {
            if (nd.ID == id)
            {
                return NodesShow(nd, level);
            }
            else
            {
                if (nd.Employees.Count > 0)
                {
                    for (int i = 0; i < nd.Employees.Count; i++)
                    {
                        string s = NodesFindShowByID(nd.Employees[i], level + 1, id);
                        if (s != "") return s;
                    }
                }
            };
            return "";
        }
        // Ищет в дереве nd по ID id и отображает в виде строки

    }   // Класс для работы с деревом
}
