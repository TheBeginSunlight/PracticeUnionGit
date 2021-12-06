using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeUnionGit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(0, 0, 0, 0);
            MessageBox.Show("Добро пожаловать в симулятор... \nЗАВОДА КОМПЛЕКТУЮЩИХ ДЛЯ ПК");
            if (BackColor == Color.DimGray)
            {
                listBox1.BackColor = Color.Gray;
                textBox1.BackColor = Color.Gray;
                textBox2.BackColor = Color.Gray;
                textBox3.BackColor = Color.Gray;
                textBox4.BackColor = Color.Gray;
                textBox5.BackColor = Color.Gray;
                textBox6.BackColor = Color.Gray;
                textBox7.BackColor = Color.Gray;
                textBox8.BackColor = Color.Gray;
                textBox9.BackColor = Color.Gray;
                textBox10.BackColor = Color.Gray;
                textBox11.BackColor = Color.Gray;
                textBox12.BackColor = Color.Gray;
                
            }
        }
        abstract class Komplekt<A>
        {
            public int cost;
            public string data;
            public A vendor_code;

            public Komplekt(int Cost, string Data, A Vendor_code)  // Создаём метод Комплектующие
            {
                cost = Cost;
                data = Data;
                vendor_code = Vendor_code;
            }
            public abstract void Display(ListBox listBox1);  // Указываем, что метод дисплей выводит данные в listbox1
        }
        class CPU<A> : Komplekt <A>
        {
            public CPU(int Cost, string Data, double CF, int Cores, int Streams, A Vendor_Code) // Наследование 
                : base (Cost, Data, Vendor_Code)
            {
                cf = CF;
                cores = Cores;
                streams = Streams;
            }
            double cf; // cf - clock frequency - тактовая частота
            int cores;
            int streams; // streams - потоки. Не думаю, что это слово подходит к ПК...
            public double CF // Здесь и в подобных - Создание свойств для возвращения значений
            { 
                get 
                {
                    return cf;
                } 
            }
            public int Cores 
            { 
                get 
                {
                    return cores;
                } 
            }
            public int Streams 
            {
                get 
                {
                    return streams;
                }
            }
            public override void Display(ListBox listBox1) // Метод вывода 
            {
                listBox1.Items.Add($"Процессор:\n");
                listBox1.Items.Add($"Цена - {cost}");
                listBox1.Items.Add($"Дата - {data}");
                listBox1.Items.Add($"Тактовая частота - {cf}");
                listBox1.Items.Add($"Кол-во Ядер - {cores}");
                listBox1.Items.Add($"Кол-во Потоков - {streams}");
                listBox1.Items.Add($"Артикул - {vendor_code}");
                listBox1.Items.Add("");
            }
        }
        class Videocard<A> : Komplekt<A> 
        {
            double cf; // cf - clock frequency - тактовая частота
            string who; // Производитель??? А не производительность? ладно...
            double memory;

            public Videocard(int Cost, string Data, double cf, string who, double memory, A Vendor_Code)
                : base(Cost, Data, Vendor_Code)
            {
                cf = CF;
                who = Who;
                memory = Memory;
            }


            private double CF
            {
                get
                {
                    return cf;
                }
            }
            private string Who
            {
                get
                {
                    return who;
                }
            }
            private double Memory
            {
                get
                {
                    return memory;
                }
            }
            public override void Display(ListBox listBox1)
            {
                listBox1.Items.Add($"Видеокарта:\n");
                listBox1.Items.Add($"Цена - {cost}");
                listBox1.Items.Add($"Дата - {data}");
                listBox1.Items.Add($"Тактовая частота - {cf}");
                listBox1.Items.Add($"Производитель - {who}");
                listBox1.Items.Add($"Объём Памяти - {memory}");
                listBox1.Items.Add($"Артикул - {vendor_code}");
                listBox1.Items.Add("");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int cost = Convert.ToInt32(textBox1.Text);
            string data = textBox2.Text;
            double cf = Convert.ToDouble(textBox3.Text);
            int cores = Convert.ToInt32(textBox4.Text);
            int streams = Convert.ToInt32(textBox5.Text);
            int vendor_code = Convert.ToInt32(textBox6.Text);
            CPU<int> proc = new CPU<int>(cost, data, cf, cores, streams, vendor_code);  // Создание нового 
            proc.Display(listBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int cost = Convert.ToInt32(textBox12.Text);
            string data = textBox11.Text;
            double cf = Convert.ToDouble(textBox10.Text);
            string who = textBox9.Text;
            double memory = Convert.ToDouble(textBox8.Text);
            int vendor_code = Convert.ToInt32(textBox7.Text);
            Videocard<int> vid = new Videocard<int>(cost, data, cf, who, memory, vendor_code );
            vid.Display(listBox1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EA ea = new EA();
            ea.ShowDialog();
        }
    }
}