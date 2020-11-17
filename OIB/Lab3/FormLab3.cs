using System.Windows.Forms;
using OIB.Lab2;
using System;


namespace OIB.Lab3
{
    public partial class FormLab3 : Form
    {
        public FormLab3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new MainForm());
        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            var P = double.Parse(boxInputP.Text);
            var V = double.Parse(boxInputV.Text);
            var T = double.Parse(boxInputT.Text);

            var pasProt = new Password(P, V, T);
            UpdateCheckBox(pasProt);

            textS.Text = pasProt.S.ToString();
            textA.Text = pasProt.A.ToString();
            textL.Text = pasProt.L.ToString();
            textPassword.Text = pasProt.GeneratePassword();
        }

        private void UpdateCheckBox(Password pp)
        {
            pp.ChekingCheckBox(checkBoxEngBig, 'A', 'Z');
            pp.ChekingCheckBox(checkBoxEngMin, 'a', 'z');
            pp.ChekingCheckBox(checkBoxRusBig, 'А', 'Я');
            pp.ChekingCheckBox(checkBoxRusMin, 'а', 'я');
            pp.ChekingCheckBox(checkBoxSymvol, '!', '*');
            pp.ChekingCheckBox(checkBoxDigit, '0', '9');
            pp.SetLengthPassword();
        }
    }
}
