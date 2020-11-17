using OIB.Lab2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OIB.Lab4
{
    public partial class FormLab4 : Form
    {
        public FormLab4()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Helper.NextForm(this, new MainForm());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            labelKSumm.Text = Hash.KSumm(password.Text).ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            labelSummKodBukvOtkr.Text = Hash.SummKodBukvOtkr(password.Text).ToString();
        }
    }
}
