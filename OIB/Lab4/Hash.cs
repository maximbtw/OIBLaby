using System;
using System.Linq;

namespace OIB.Lab4
{
    class Hash
    {
        private const int a = 31;
        private const int b = 7;
        private const int c = 255;
        private const int maxVal = 256;
        private const int t0 = 126;

        public static int KSumm(string password)
        {
            var K = password.Sum();
            return (K <= maxVal) ? K % (maxVal + 1) : K;
        }

        public static int SummKodBukvOtkr(string password)
        {
            var X = password.Select(c => ToBinary(c)).ToArray();
            var T = GetRandomDigits(password.Length).Select(c => ToBinary(c)).ToArray();
            var Y = new string[X.Count()];

            for (int k = 0; k < X.Count(); k++)
            {
                var str = "";
                for (int j = 0; j < X[k].Length; j++)
                    str += (X[k][j] + T[k][j]) % 2;
                Y[k] = str;
            }

            var K = Y.Select(x => Convert.ToInt32(x, 2)).Sum();
            return (K <= maxVal) ? K % (maxVal + 1) : K;
        }

        private static int[] GetRandomDigits(int n)
        {
            var arr = new int[n];
            arr[0] = t0;
            for (int i = 0; i < n - 1; i++)
                arr[i + 1] = (a * arr[i] + b) % c;
            return arr;
        }

        private static char[] ToBinary(int digit)
        {
            var result = "";
            ToBinary(digit, ref result);
            while (result.Length != 8) result += '0';
            return result.Reverse().ToArray();
        }

        private static void ToBinary(int digit, ref string result)
        {
            if (digit == 0) return;
            result += digit % 2;
            ToBinary(digit / 2, ref result);
        }
    }
}
