using System;
using System.Globalization;
using System.Numerics;

namespace Project01
{
    class MathF
    {
        public string EE(double value)
        {
            string[] str = value.ToString(new NumberFormatInfo() { NumberDecimalSeparator = "." }).Split('.');
            int comma = (str.Length == 2 ? str[1].Length : 0) - 3;

            string lenght = value.ToString();

            for (int i = 0; i < comma; i++)
            {
                lenght = lenght.Remove(lenght.Length - 1);
            }

            return lenght.Replace(',', '.') + " " + "*" + " " + "10^" + comma;
        }

        public double VariableDegree(double x, double y)
        {
            return Math.Pow(x, y);
        }

        public BigInteger Factorial(double value)
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= value; i++)
                factorial *= i;

            return factorial;
        }

        public double Rnd()
        {
            Random rnd = new Random();
            double d = Math.Round(0.1 + rnd.NextDouble() * 0.89, 13);

            return d;
        }

        public double ArcSinH(double value)
        {
            double result = Math.Log(value + Math.Sqrt(Math.Pow(value, 2) + 1));

            return result;
        }

        public double ArcCosH(double value)
        {
            double result = Math.Log(value + Math.Sqrt(Math.Pow(value, 2) - 1));

            return result;
        }

        public double ArcTanH(double value)
        {
            double result = Math.Log(value + Math.Sqrt(Math.Pow(value, 2) + 1)) * (value / Math.Sqrt(1 - Math.Pow(value, 2)));

            return result;
        }


    }
}
