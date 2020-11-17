using OIB.Lab2;
using System;
using System.Windows.Forms;

namespace OIB.Lab4
{
    public partial class FormLab4 : Form
    {
        public FormLab4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new MainForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelKSumm.Text = Hash.KSumm(password.Text).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelSummKodBukvOtkr.Text = Hash.SummKodBukvOtkr(password.Text).ToString();
        }
    }
}
