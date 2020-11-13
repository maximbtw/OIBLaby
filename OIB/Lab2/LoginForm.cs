using System.Windows.Forms;
using System.Linq;
using System;

namespace OIB.Lab2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new MainForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new RegistrForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new PasswordChangeForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckCorrectnessData())
                DBManager.Entrance(textBoxLogin.Text, textBoxPassword.Text);
        }

        private bool CheckCorrectnessData()
        {
            if (Controls.OfType<TextBox>().Any(x => string.IsNullOrEmpty(x.Text)))
            {
                Helper.ErrorMessage("Заполните все поля");
                return false;
            }
            if (!DBManager.PasswordVerification(textBoxPassword.Text)) return false;

            return true;
        }
    }
}
