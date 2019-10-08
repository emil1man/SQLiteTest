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

            CMD = new SQLiteCommand("SELECT * FROM Иерархия", sqLiteConnection); // Отображает всех сотрудников без начальника
            sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            compStruct = new Node(0);
            if (sqLiteDataReader.HasRows)
            {
                while (sqLiteDataReader.Read())
                {
                    int idS = 0;
                    if (sqLiteDataReader[2].ToString() != "") { idS = Convert.ToInt32(sqLiteDataReader[2].ToString()); }
                    Node.NodesAdd(compStruct, idS, Convert.ToInt32(sqLiteDataReader[1].ToString()));
                }
            }
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

        private void UpdateWorkersInfoByOpeningTab(object sender, EventArgs e)
        {
            possibleSupervisers.Clear();
            possibleEmployees.Clear();
            cb_Sup.Items.Clear();
            cb_Wor.Items.Clear();
            compStruct = new Node(0);

            SQLiteCommand CMD = new SQLiteCommand("SELECT * FROM Сотрудники WHERE Сотрудники.Должность <> 1", sqLiteConnection);    // Отображает всех MNG и SLM
            SQLiteDataReader sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            if (sqLiteDataReader.HasRows)
            {
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
            }
            // Добавляем в выпадающий список сотрудников, которые могут иметь подчиненных

            CMD = new SQLiteCommand("SELECT Сотрудники.ID, Сотрудники.Имя, Сотрудники.Должность, Сотрудники.ДатаТрудоустройства FROM Иерархия LEFT JOIN Сотрудники ON Иерархия.Работник = Сотрудники.ID WHERE Иерархия.Начальник IS NULL;", sqLiteConnection); // Отображает всех сотрудников без начальника
            sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            if (sqLiteDataReader.HasRows)
            {
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
            }
            // Добавляем в выпадающий список сотрудников, которые не имеют руководителя

            CMD = new SQLiteCommand("SELECT * FROM Иерархия", sqLiteConnection); // Отображает всех сотрудников без начальника
            sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"

            if (sqLiteDataReader.HasRows)
            {
                while (sqLiteDataReader.Read())
                {
                    int idS = 0;
                    if (sqLiteDataReader[2].ToString() != "") { idS = Convert.ToInt32(sqLiteDataReader[2].ToString()); }
                    Node.NodesAdd(compStruct, idS, Convert.ToInt32(sqLiteDataReader[1].ToString()));
                }
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
            if (sqLiteDataReader.HasRows)
            {
                while (sqLiteDataReader.Read()) // Цикл будет считывать записи в "sqLiteDataReader" до последней 
                {
                    workersAll.Add(new string[2]);
                    workersAll[workersAll.Count - 1][0] = sqLiteDataReader[1].ToString();
                    workersAll[workersAll.Count - 1][1] = tb_worPos.Items[Convert.ToInt32(sqLiteDataReader[2]) - 1].ToString();
                }
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


        double getSalary(Node nd, List<string[]> table)
        {
            double retSum = 0;
            for (int i = 0; i < nd.Employees.Count; i++)
            {
                if (table[nd.Employees[i].ID - 1][8] != "")
                {
                    retSum += Convert.ToDouble(table[nd.Employees[i].ID - 1][9]);
                }
                else
                {
                    string[] temp = table[nd.Employees[i].ID - 1];
                    temp[8] = (getSalary(nd.Employees[i], table) * (temp[5] == "Manager" ? 0.005 : 0.003)).ToString();
                    double tempsum = 0;
                    for (int j = 6; j < 9; j++)
                    {
                        tempsum += Convert.ToDouble(temp[j]);
                    }
                    temp[9] = tempsum.ToString();
                    table.Remove(table[nd.Employees[i].ID - 1]);
                    table.Add(temp);
                    table.Sort(new compareListByID());
                    retSum += Convert.ToDouble(table[nd.Employees[i].ID][9]);
                }

            }
            return retSum;
        }   // Посчитать ЗП и записать в БД
        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteCommand CMDa = new SQLiteCommand("DROP TABLE IF EXISTS СотрудникиЗП; CREATE TABLE СотрудникиЗП (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Сотрудник TEXT, Должность TEXT, ЗП5 NUMERIC, ЗП4 NUMERIC, ЗП3 NUMERIC, ЗП2 NUMERIC, ЗП1 NUMERIC, ЗП0 NUMERIC); INSERT INTO СотрудникиЗП ( Сотрудник, Должность ) SELECT Имя, Должность FROM Сотрудники; UPDATE СотрудникиЗП SET Должность = (SELECT Должности.Название FROM Должности WHERE Должность = Должности.ID);", sqLiteConnection);
            CMDa.ExecuteNonQuery();
            for (int MONTHS = 6; MONTHS > 0; MONTHS--)
            {
                SQLiteCommand CMD = new SQLiteCommand("DROP TABLE IF EXISTS СотрудникиЗарплатыTemp; CREATE TABLE СотрудникиЗарплатыTemp AS SELECT Сотрудники.ID, Сотрудники.Имя, Должности.Название AS Должность, Должности.БазоваяСтавка, Должности.БазоваяСтавка * (min((@Date - Сотрудники.ДатаТрудоустройства - CASE WHEN strftime('%m-%d', @Date) < strftime('%m-%d', Сотрудники.ДатаТрудоустройства) THEN 1 ELSE 0 END) * Должности.НадбавкаСтаж, Должности.НадбавкаСтажМакс)) AS НадбавкаСтаж, NULL AS НадбавкаСотрудники, NULL AS НадбавкаИтог FROM Сотрудники LEFT JOIN Должности ON Сотрудники.Должность = Должности.ID", sqLiteConnection);
                // Выведет всех людей с надбавками за @Date во временную таблицу, предварительно удаляя уже существующую
                CMD.Parameters.Add("@Date", System.Data.DbType.DateTime).Value = DateTime.Today.AddMonths(1 - MONTHS).ToString("O").Split('T')[0];   // Параметр в который записывается Имя
                CMD.ExecuteNonQuery();  // Выполнить запрос
                CMD = new SQLiteCommand("UPDATE СотрудникиЗарплатыTemp SET НадбавкаСотрудники = 0 WHERE NOT EXISTS(SELECT Начальник FROM Иерархия WHERE СотрудникиЗарплатыTemp.ID = Иерархия.Начальник); UPDATE СотрудникиЗарплатыTemp SET НадбавкаИтог = БазоваяСтавка + НадбавкаСтаж + НадбавкаСотрудники WHERE НадбавкаСотрудники NOT NULL; UPDATE СотрудникиЗарплатыTemp SET НадбавкаСотрудники = 0, НадбавкаИтог = 0 WHERE НадбавкаСтаж< 0; ", sqLiteConnection);
                // Сначала задает надбавку за подчиненных равной нулю тем у кого их нет
                // Потом высчитывает зарплату тех у кого заполнено поле с надбавкой за подчиненных
                // Потом задает итоговую ЗП равной нулю тем, кто на указанный момент ещё не устроился
                CMD.ExecuteNonQuery();  // Выполнить запрос
                //getSalary(compStruct);

                List<string[]> tempDB = new List<string[]>();

                CMD = new SQLiteCommand("SELECT * FROM Иерархия LEFT JOIN СотрудникиЗарплатыTemp ON Иерархия.Работник = СотрудникиЗарплатыTemp.ID", sqLiteConnection);    // Отображает всех MNG и SLM
                SQLiteDataReader sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
                if (sqLiteDataReader.HasRows)
                {
                    while (sqLiteDataReader.Read()) // Цикл будет считывать записи в "sqLiteDataReader" до последней 
                    {
                        tempDB.Add(new string[10]);
                        for (int i = 0; i < tempDB[tempDB.Count - 1].Length; i++)
                        {
                            tempDB[tempDB.Count - 1][i] = sqLiteDataReader[i].ToString();
                        }
                    }
                }
                sqLiteDataReader.Close();

                // Заносим в таблицу temp данные из запроса
                getSalary(compStruct, tempDB);

                switch (MONTHS - 1)
                {
                    case 5:
                        {
                            for (int i = 0; i < tempDB.Count; i++)
                            {
                                CMD = new SQLiteCommand("UPDATE СотрудникиЗП SET ЗП5 = @MONEY WHERE СотрудникиЗП.ID = @ID;", sqLiteConnection);
                                CMD.Parameters.Add("@MONEY", System.Data.DbType.Double).Value = tempDB[i][9];
                                CMD.Parameters.Add("@ID", System.Data.DbType.Int32).Value = i + 1;
                                CMD.ExecuteNonQuery();
                            }
                            break;
                        }
                    case 4:
                        {
                            for (int i = 0; i < tempDB.Count; i++)
                            {
                                CMD = new SQLiteCommand("UPDATE СотрудникиЗП SET ЗП4 = @MONEY WHERE СотрудникиЗП.ID = @ID;", sqLiteConnection);
                                CMD.Parameters.Add("@MONEY", System.Data.DbType.Double).Value = tempDB[i][9];
                                CMD.Parameters.Add("@ID", System.Data.DbType.Int32).Value = i + 1;
                                CMD.ExecuteNonQuery();
                            }
                            break;
                        }
                    case 3:
                        {
                            for (int i = 0; i < tempDB.Count; i++)
                            {
                                CMD = new SQLiteCommand("UPDATE СотрудникиЗП SET ЗП3 = @MONEY WHERE СотрудникиЗП.ID = @ID;", sqLiteConnection);
                                CMD.Parameters.Add("@MONEY", System.Data.DbType.Double).Value = tempDB[i][9];
                                CMD.Parameters.Add("@ID", System.Data.DbType.Int32).Value = i + 1;
                                CMD.ExecuteNonQuery();
                            }
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < tempDB.Count; i++)
                            {
                                CMD = new SQLiteCommand("UPDATE СотрудникиЗП SET ЗП2 = @MONEY WHERE СотрудникиЗП.ID = @ID;", sqLiteConnection);
                                CMD.Parameters.Add("@MONEY", System.Data.DbType.Double).Value = tempDB[i][9];
                                CMD.Parameters.Add("@ID", System.Data.DbType.Int32).Value = i + 1;
                                CMD.ExecuteNonQuery();
                            }
                            break;
                        }
                    case 1:
                        {
                            for (int i = 0; i < tempDB.Count; i++)
                            {
                                CMD = new SQLiteCommand("UPDATE СотрудникиЗП SET ЗП1 = @MONEY WHERE СотрудникиЗП.ID = @ID;", sqLiteConnection);
                                CMD.Parameters.Add("@MONEY", System.Data.DbType.Double).Value = tempDB[i][9];
                                CMD.Parameters.Add("@ID", System.Data.DbType.Int32).Value = i + 1;
                                CMD.ExecuteNonQuery();
                            }
                            break;
                        }
                    case 0:
                        {
                            for (int i = 0; i < tempDB.Count; i++)
                            {
                                CMD = new SQLiteCommand("UPDATE СотрудникиЗП SET ЗП0 = @MONEY WHERE СотрудникиЗП.ID = @ID;", sqLiteConnection);
                                CMD.Parameters.Add("@MONEY", System.Data.DbType.Double).Value = tempDB[i][9];
                                CMD.Parameters.Add("@ID", System.Data.DbType.Int32).Value = i + 1;
                                CMD.ExecuteNonQuery();
                            }
                            break;
                        }
                }
            }
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }   // Посчитать ЗП всех сотрудников за последние 6 месяцев
        private void button4_Click(object sender, EventArgs e)
        {
            List<int> supIDs = new List<int>();   // Список ID всех начальников
            //List<string[]>[] chiefWithEmp;    // 
            List<string[]> workers = new List<string[]>();
            SQLiteCommand CMD = new SQLiteCommand("SELECT * FROM Иерархия", sqLiteConnection); // Отображает всех сотрудников без начальника
            SQLiteDataReader sqLiteDataReader = CMD.ExecuteReader();    // Переменная для чтения из "CMD"
            compStruct = new Node(0);
            if (sqLiteDataReader.HasRows)
            {
                while (sqLiteDataReader.Read())
                {
                    int idS = 0;
                    if (sqLiteDataReader[2].ToString() != "") { idS = Convert.ToInt32(sqLiteDataReader[2].ToString()); }
                    Node.NodesAdd(compStruct, idS, Convert.ToInt32(sqLiteDataReader[1].ToString()));
                }
            }   // Заполняем иерархию в compStruct

            CMD = new SQLiteCommand("SELECT * FROM СотрудникиЗП", sqLiteConnection);
            sqLiteDataReader = CMD.ExecuteReader();
            if (sqLiteDataReader.HasRows)
            {
                while (sqLiteDataReader.Read())
                {
                    workers.Add(new string[9]);
                    for (int i = 0; i < 9; i++)
                    {
                        workers[workers.Count - 1][i] = sqLiteDataReader[i].ToString();
                    }
                }
            }   // Считываем данные по сотрудникам

            CMD = new SQLiteCommand("SELECT* FROM Иерархия WHERE Начальник IS NOT NULL GROUP BY Начальник", sqLiteConnection);
            sqLiteDataReader = CMD.ExecuteReader();
            if (sqLiteDataReader.HasRows)
            {
                while (sqLiteDataReader.Read())
                {
                    supIDs.Add(sqLiteDataReader.GetInt32(2));
                }
            }   // Находим ID всех у кого есть подчиненные

            CMD = new SQLiteCommand("DROP TABLE IF EXISTS ИнформацияОРуководителях; CREATE TABLE ИнформацияОРуководителях (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Сотрудник TEXT, Должность TEXT, ЗПЗатраты2 NUMERIC, ЗПЗатраты1 NUMERIC, ЗПЗатраты0 NUMERIC, СредняяЗП NUMERIC, МинимальнаяЗП NUMERIC, Максимальная NUMERIC);", sqLiteConnection);
            CMD.ExecuteNonQuery();
            List<string[]> supInfo = new List<string[]>();
            for (int i = 0; i < supIDs.Count; i++)
            {
                List<string[]> temp = new List<string[]>(); // Список для хранения начальника и его подчиненных
                temp.AddRange(getListOfSupAndEmp(Node.FindNodyByID(compStruct, supIDs[i]), workers));   // Заполнение списка

                double[] sumSalByMonths = new double[6] { 0, 0, 0, 0, 0, 0 }; // Переменная для нахождения сумм зарплат
                double[] avgCountByMonths = new double[6] { 0, 0, 0, 0, 0, 0 }; // Переменная для хранения количества получающих ЗП за месяц
                double avdSalBy6Months = 0; // Переменная для нахождения средней ЗП за 6 месяцев
                double minSal = Convert.ToDouble(temp[1][3]), maxSal = Convert.ToDouble(temp[1][3]);  // Минимальная и максимальная ЗП

                // ID, Имя, должн, зп5, 4, 3, 2, 1, 0
                for (int j = 1; j < temp.Count; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        sumSalByMonths[k] += Convert.ToDouble(temp[j][3 + k]); // Прибавляем к итоговой сумме ЗП подчиненного за месяц k
                        avgCountByMonths[k] += Convert.ToDouble(temp[j][3 + k]) > 0 ? 1 : 0;   // Считает работал ли подчиненный j в месяце k
                        minSal = Convert.ToDouble(temp[j][3 + k]) < minSal && Convert.ToDouble(temp[j][3 + k]) > 0 ? Convert.ToDouble(temp[j][3 + k]) : minSal;   // Ищет минимальную ЗП для каждого j в k
                        maxSal = Convert.ToDouble(temp[j][3 + k]) > maxSal ? Convert.ToDouble(temp[j][3 + k]) : maxSal;    // Ищет максимальную ЗП для каждого j в k
                    }
                }

                for (int j = 0; j < 6; j++)
                {
                    double d = (sumSalByMonths[j] / avgCountByMonths[j]);
                    avdSalBy6Months += d;
                }
                avdSalBy6Months /= 6;   // Подсчёт средней ЗП
                supInfo.Add(new string[9]);
                for (int j = 0; j < 3; j++)
                {
                    supInfo[supInfo.Count - 1][j] = temp[0][j];
                }
                for (int j = 3; j < 6; j++)
                {
                    supInfo[supInfo.Count - 1][j] = sumSalByMonths[j].ToString();
                }
                supInfo[supInfo.Count - 1][6] = avdSalBy6Months.ToString();
                supInfo[supInfo.Count - 1][7] = minSal.ToString();
                supInfo[supInfo.Count - 1][8] = maxSal.ToString();
            }
            for (int j = 0; j < supInfo.Count; j++)
            {
                CMD = new SQLiteCommand("INSERT INTO ИнформацияОРуководителях (Сотрудник, Должность, ЗПЗатраты2, ЗПЗатраты1, ЗПЗатраты0, СредняяЗП, МинимальнаяЗП, Максимальная) VALUES (@Name, @Pos, @SalSum2, @SalSum1, @SalSum0, @AvgSalMonths, @MinSal, @MaxSal);", sqLiteConnection);
                CMD.Parameters.Add("@Name", System.Data.DbType.String).Value = supInfo[j][1].ToUpper();   // Параметр в который записывается Имя
                CMD.Parameters.Add("@Pos", System.Data.DbType.String).Value = supInfo[j][2].ToUpper();   // Параметр в который записывается Имя
                CMD.Parameters.Add("@SalSum2", System.Data.DbType.Double).Value = supInfo[j][3];   // Параметр в который записывается Имя
                CMD.Parameters.Add("@SalSum1", System.Data.DbType.Double).Value = supInfo[j][4];   // Параметр в который записывается Имя
                CMD.Parameters.Add("@SalSum0", System.Data.DbType.Double).Value = supInfo[j][5];   // Параметр в который записывается Имя
                CMD.Parameters.Add("@AvgSalMonths", System.Data.DbType.Double).Value = supInfo[j][6];   // Параметр в который записывается Имя
                CMD.Parameters.Add("@MinSal", System.Data.DbType.Double).Value = supInfo[j][7];   // Параметр в который записывается Имя
                CMD.Parameters.Add("@MaxSal", System.Data.DbType.Double).Value = supInfo[j][8];   // Параметр в который записывается Имя
                CMD.ExecuteNonQuery();
            }

            Form3 f3 = new Form3();
            f3.ShowDialog();
        }   // Вывести отчёт с информацией о руководителях
        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }   // Вывести отчёт для средних ЗП по должностям

        List<string[]> getListOfSupAndEmp(Node nd, List<string[]> workers)
        {
            List<string[]> temp = new List<string[]>();
            temp.Add(workers[nd.ID - 1]);
            if (nd.Employees.Count > 0)
            {
                foreach (Node sup in nd.Employees)
                {
                    temp.AddRange(getListOfSupAndEmp(sup, workers));
                }
            }
            return temp;
        }   // Возвращает List с подчиненными для nd.ID, первый элемент списка - начальник

    }

    class compareListByID : IComparer<string[]>
    {
        public int Compare(string[] o1, string[] o2)
        {
            if (Convert.ToUInt32(o1[0]) > Convert.ToUInt32(o2[0]))
            {
                return 1;
            }
            else if (Convert.ToUInt32(o1[0]) < Convert.ToUInt32(o2[0]))
            {
                return -1;
            }

            return 0;
        }
    }   // Класс для сортировки по ID

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

        public static Node FindNodyByID(Node nd, int id)
        {
            if (nd.ID == id)
            {
                return nd;
            }
            else
            {
                if (nd.Employees.Count > 0)
                {
                    for (int i = 0; i < nd.Employees.Count; i++)
                    {
                        return FindNodyByID(nd.Employees[i], id);
                    }
                }
            };
            throw new Exception("Can't find node with ID");
        }
    }   // Класс для работы с деревом
}
