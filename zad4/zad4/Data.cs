using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad4;

namespace zad4
{
    public class Elemten
    {
       public double X { get; set; }
        public double Pstr { get; set; }
        public double L { get; set; }
        public double N { get; set; }
        public double W { get; set; }
    }
    public class Data
    {
        public List<Elemten> ListP { get; set; }
        private List<Elemten> ListT { get; set; }
        private List<Elemten> ListN { get; set; }
        private List<Elemten> ListW { get; set; }
        private List<double> Lambda { get; set; }

        public Data()
        {
            //Inicjalizacja zmiennych
            Lambda = new List<double>();
            for (int i = 3; i <= 27; i += 3)
            {
                Lambda.Add(i);
            }


            ListP = new List<Elemten>();
            ListT = new List<Elemten>();
            ListN = new List<Elemten>();
            ListW = new List<Elemten>();


            //Obliczenie M/M/1
            foreach (double item in Lambda)
            {
                ListP.Add(new Elemten
                {
                    X = item,
                    Pstr = Pbl(item, 5, 4, 10),
                    L= T(item, 5, 4, 10),
                    N = N(item, 5, 4, 10),
                    W = W(item, 5, 4, 10)
                }
                    );
                //ListT.Add(new Elemten
                //{
                //    X = item,
                //    L= T(item, 5, 4, 10)
                //});
                //ListN.Add(new Elemten
                //{
                //    X = item,
                //    N = N(item, 5, 4, 10)
                //});
                //ListW.Add(new Elemten
                //{
                //    X = item,
                //    W = W(item, 5, 4, 10)
                //});

            }
        }

        public double RHO(double lambda, double mi)
        {
            return lambda/mi;
        }

        /// <summary>
        ///     Obliczenie Q
        /// </summary>
        public double Q(double lambda, double mi, double i, double c, double m)
        {
            if (i != 0)
            {
                if (i <= c)
                {
                    return Math.Pow(RHO(lambda, mi), i)/Silnia(i);
                }
                else if (i <= m + c && i > c + 1)
                {
                    return (Math.Pow(c, c)/Silnia(c))*Math.Pow((RHO(lambda, mi)/c), i);
                }
            }
            else
            {
                return 1;
            }
            return lambda / mi;
        }

        /// <summary>
        ///     Obliczenie p
        /// </summary>
        public double P(double lambda, double mi, double i, double c, double m)
        {
            var suma = 0.0;
            for (int k = 0; k <=m+c; k++)
            {
                suma += Q(lambda, mi, k, c, m);
            }

            return Q(lambda, mi, i, c, m)/suma;
        }

        /// <summary>
        ///     prawdopodobieństwo straty zgłoszenia 
        /// </summary>
        public double Pbl(double lambda, double mi, double c, double m)
        {
            return P(lambda, mi, m+c, c, m);
        }

        /// <summary>
        ///     średnia liczba zajętych stanowisk
        /// </summary>
        public double T(double lambda, double mi, double c, double m)
        {
            var suma1 = 0.0;
            for (double k = 1; k <= c; k++)
            {
                suma1 += k * P(lambda, mi, k, c, m);
            }

            var suma2 = 0.0;
            for (double k = c + 1; k <= m + c; k++)
            {
                suma2 += c * P(lambda, mi, k, c, m);
            }

            return suma1 + suma2;
        }

        /// <summary>
        ///     średnia liczbę zgłoszeń w systemie (kolejka + stanowisko obsługi)
        /// </summary>
        public double N(double lambda, double mi, double c, double m)
        {

            var suma1 = 0.0;
            for (double k = 1; k <= c; k++)
            {
                suma1 += Math.Pow(RHO(lambda, mi),k)/Silnia(k-1);
            }

            var suma2 = 0.0;
            for (double k = c + 1; k <= m + c; k++)
            {
                suma2 += Math.Pow((RHO(lambda, mi)/c),k);
            }

            suma2 = suma2*(Math.Pow(c, c)/Silnia(c));

            return P(lambda, mi, 0, c, m)*(suma1 + suma2);
        }

        /// <summary>
        ///     średnia liczbę zgłoszeń w systemie (kolejka + stanowisko obsługi)
        /// </summary>
        public double W(double lambda, double mi, double c, double m)
        {

            var suma1 = 0.0;
            for (double k = 1; k <= m; k++)
            {
                suma1 +=  k * Math.Pow((RHO(lambda, mi) / c), k-1);
            }



            return P(lambda, mi, 0, c, m) * (Math.Pow(c, c) / (Silnia(c) * c)) * (1 / m) * Math.Pow((RHO(lambda, mi) / c), c) * suma1;
        }


        /// <summary>
        ///     Obliczenie silni
        /// </summary>
        public double Silnia(double liczba)
        {
            double val = 1;
            for (int i = 1; i <= liczba; i++)
            {
                val *= i;
            }
            return val;
        }

    }
}
