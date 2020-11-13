using System.Windows.Forms;
using System.Linq;
using System;

namespace OIB.Lab2
{
    public partial class RegistrForm : Form
    {
        public RegistrForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Helper.NextForm(this, new LoginForm());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckCorrectnessData())     
                CreateUser();
        }

        private bool CheckCorrectnessData()
        {
            if (Controls.OfType<TextBox>().Any(x => string.IsNullOrEmpty(x.Text)))
            {
                Helper.ErrorMessage("Заполните все поля");
                return false;
            }
            if (!DBManager.PasswordVerification(textBoxPassword.Text))
            {
                return false;
            }
            if (!DateTime.TryParse(textBoxBirthday.Text, out var p)) 
            {
                Helper.ErrorMessage("Дата имеет неверный формат");
                return false;
            }
            if (textBoxNumber.Text.Any(x => !char.IsDigit(x)))
            {
                Helper.ErrorMessage("Номер имеет неверный формат");
                return false;
            }
            return true;
        }

        private void CreateUser()
        {
            var user = new User()
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
            };
            var profile = new Profile()
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Patronymic = textBoxPatronymic.Text,
                DateOfBirth = DateTime.Parse(textBoxBirthday.Text),
                PlaceOfBirth = textBoxPlace.Text,
                PhoneNumber = textBoxNumber.Text
            };

            DBManager.AddUser(user, profile);
        }
    }
}
