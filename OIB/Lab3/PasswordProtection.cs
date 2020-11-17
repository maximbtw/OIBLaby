using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;

namespace OIB.Lab3
{
    class Password
    {
        private List<List<char>> chars;
        public double S { get; private set; }
        public int A { get; private set; }
        public int L { get; private set; }

        public Password(double P, double V, double T)
        {
            chars = new List<List<char>>();
            S = Math.Ceiling(V * T / P);
            A = 0;
            L = 0;
        }

        public void ChekingCheckBox(CheckBox checkBox, char from, char to)
        {
            if (!checkBox.Checked) return;
            var list = new List<char>();
            for (int k = from; k <= to; k++)
            {
                A++;
                list.Add((char)k);
            }
            chars.Add(list);
        }

        public void SetLengthPassword()
        {
            for (int l = 0; S > Math.Pow(A, l); l++)
                L++;
        }

        public string GeneratePassword()
        {
            var password = "";
            var rnd = new Random();

            for (int i = 0; i < L; i++)
            {
                var index = rnd.Next(0, chars.Count);
                password += (char)rnd.Next(chars[index].First(), chars[index].Last() + 1);
            }
            return password;
        }
    }
}
