using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace OIB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int lePas = 10;
            var N = identificator.Text.Length;
            var Q = N % 6;

            answerText.Text = CreatePassword(
                GetRandom(0, 2, 'A', 'Z'),
                GetRandom(2, lePas - Q - 1, 'a', 'z'),
                GetRandom(lePas - Q - 1, lePas, '1', '9'));

        }

        private string CreatePassword(params IEnumerable<char>[] func)
        {
            string answer = "";
            foreach(var rnd in func)
                foreach(var ch in rnd)
                    answer += ch;
            return answer;
        }

        private IEnumerable<char> GetRandom(int from, int to, char start, char end)
        {
            var rnd = new Random();
            for(int i = from; i < to; i++)
                yield return (char)rnd.Next(start, end + 1);
        }
    }
}
