using OIB.Lab2;
using OIB.Lab3;
using OIB.Lab4;
using System;
using System.Windows.Forms;

namespace OIB
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new Form1());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new LoginForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new FormLab3());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new FormLab4());
        }
    }
}
