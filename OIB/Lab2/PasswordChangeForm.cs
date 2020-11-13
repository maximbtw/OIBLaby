using System.Windows.Forms;
using System.Linq;
using System;


namespace OIB.Lab2
{
    public partial class PasswordChangeForm : Form
    {
        public PasswordChangeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new LoginForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckCorrectnessData())
                DBManager.ChangePassword(textBoxPrevPassword.Text, textBoxNewPassword.Text);
        }

        private bool CheckCorrectnessData()
        {
            if (Controls.OfType<TextBox>().Any(x => string.IsNullOrEmpty(x.Text)))
            {
                Helper.ErrorMessage("Заполните все поля");
                return false;
            }
            if (textBoxNewPassword.Text != textBoxNewPassword2.Text)
            {
                Helper.ErrorMessage("Пароли не совпадают");
                return false;
            }
            if (!DBManager.PasswordVerification(textBoxNewPassword.Text))
            {
                return false;
            }
            return true;
        }
    }
}
