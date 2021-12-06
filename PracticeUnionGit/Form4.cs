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
// static abstract using fixed string = Convert.ToDouble(MySql.Data.MySqlClient) < T > {get {return static void;}, set {abstract void = value;}}; \\
using MySql.Data.MySqlClient;

namespace PracticeUnionGit
{
    public partial class Form4 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        BindingSource bSource = new BindingSource();
        DataSet ds = new DataSet();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
            conn = new MySqlConnection(connStr);

            string sql = $"SELECT idStud, fioStud, drStud FROM t_datetime";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(sql, conn); // Инициализация 
            MyDA.Fill(ds, "Test");
            bSource.DataSource = ds;
            dataGridView1.DataSource = bSource;
            dataGridView1.DataMember = "Test"; // Инициализация таблицы данных БД
            conn.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
 
            object name = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            string whattimeis = Convert.ToString(DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value));
            MessageBox.Show("Игрок " + name + " зашёл на сервер " +  whattimeis.Substring(0, whattimeis.Length - 17) + " дней назад", "Сервер БОЛЬШИЕ ПУШКИ 16+");
        }

    }
}
