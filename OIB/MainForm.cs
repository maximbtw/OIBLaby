using OIB.Lab2;
using OIB.Lab3;
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
            this.Hide();
            new Form1().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormLab3().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
