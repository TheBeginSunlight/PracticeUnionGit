using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using MySql.Data.MySqlClient;

namespace PracticeUnionGit
{
    public partial class Form5 : Form
    {
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        DataSet ds = new DataSet();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MySqlConnection classn = new MySqlConnection(Class1.Connect()); // подключение к БД используя библиотеку ConnectDB
            string sql1 = $"SELECT idStud, fioStud, datetimeStud FROM t_PraktStud"; // SQL-запрос на выбору полей из таблицы
            classn.Open(); // Открытие соединения
            MyDA.SelectCommand = new MySqlCommand(sql1, classn); // объект для выполнения SQL-запроса
            MyDA.Fill(ds, "Test"); // Заполняем таблицу записями из БД
            bSource.DataSource = ds; // Указываем, что источником данных в bindingsource является заполненная таблица выше
            dataGridView1.DataSource = bSource; // Указываем, что источником данных ДатаГрида является bindingsource
            dataGridView1.DataMember = "Test"; // Необходимая для заполнения БД строка
            classn.Close(); // Закрытие соединения

            button2.Visible = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection classn = new MySqlConnection(Class1.Connect()); // подключение к БД используя библиотеку ConnectDB
            classn.Open();
            string fio = textBox1.Text;
            string data = textBox2.Text;
            string sql = $"INSERT INTO t_PraktStud (fioStud, datetimeStud)  VALUES ('{fio}','{data}');"; // SQL-запрос на добавление
            MySqlCommand a = new MySqlCommand(sql, classn);
            a.ExecuteNonQuery(); // Ввод данных в БД
            classn.Close();

            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = true;
            button2.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            button2.Visible = false;

            MySqlConnection classn = new MySqlConnection(Class1.Connect()); // подключение к БД используя библиотеку ConnectDB
            string sql1 = $"SELECT idStud, fioStud, datetimeStud FROM t_PraktStud";
            classn.Open();
            MyDA.SelectCommand = new MySqlCommand(sql1, classn);
            MyDA.Fill(ds, "Test");
            bSource.DataSource = ds;
            dataGridView1.DataSource = bSource;
            dataGridView1.DataMember = "Test";
            classn.Close();
        }

    }
}
