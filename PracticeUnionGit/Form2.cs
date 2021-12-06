using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PracticeUnionGit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        class Connect
        {
            public string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;"; // Подключение к БД
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            Connect can = new Connect(); //  Инициализация класса Коннект

            MySqlConnection conn = new MySqlConnection(can.connStr);  // Инициализация MySql 
            button2.BackColor = Color.White;
            try  // Проверка Подключения соединения. Если цвет зелёный - то соеднинение успешно, если красный - всё плохо
            {
                conn.Open();
                button2.BackColor = Color.Green;
            }

            catch
            {
                button2.BackColor = Color.Red;
            }
            finally
            {
                if (button2.BackColor == Color.Green)
                {
                    MessageBox.Show("ПОДКЛЮЧЕНО");
                }
                else
                {
                    MessageBox.Show("СЕРВЕР НЕ ДОСТУПЕН");
                    button2.BackColor = Color.Red;
                }
            }
        }


    }
}
