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
    public partial class Menu : Form
    {
        Form1 form1 = new Form1();
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();
        Form5 form5 = new Form5();
        public Menu()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BackColor = Color.DimGray;
            form1.BackColor = Color.DimGray;
            form2.BackColor = Color.DimGray;
            form3.BackColor = Color.DimGray;
            form4.BackColor = Color.DimGray;
            form5.BackColor = Color.DimGray;
        }
    }
}
