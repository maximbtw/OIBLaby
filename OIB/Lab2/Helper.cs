using System.Windows.Forms;

namespace OIB.Lab2
{
    public static class Helper
    {
        public static void NextForm(Form currentForm, Form newForm)
        {
            currentForm.Hide();
            newForm.Show();
        }

        public static void InformationMessage(string text, string label)
        {
            MessageBox.Show(
                text,
                label,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void ErrorMessage(string text)
        {
            MessageBox.Show(
                text,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
