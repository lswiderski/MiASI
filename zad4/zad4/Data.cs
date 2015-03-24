using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad4;

namespace zad4
{
    public class Elemten
    {
       public double X { get; set; }
        public double Pstrp { get; set; }
        public double Lp { get; set; }
        public double N { get; set; }
        public double W { get; set; }
    }
    public class Data
    {
        public ObservableCollection<Elemten> ListP { get; set; }
        private List<double> Lambda { get; set; }

        public Data()
        {
            //Inicjalizacja zmiennych
            Lambda = new List<double>();
            for (int i = 3; i <= 27; i += 3)
            {
                Lambda.Add(i);
            }


            ListP = new ObservableCollection<Elemten>();


            //Obliczenie M/M/1
            foreach (double item in Lambda)
            {
                ListP.Add(new Elemten
                {
                    X = item,
                    Pstrp = Pstr(4, 10, 5,item,14),
                    Lp = L(4, 10, 5, item),
                    N = N(4, 10, 5, item),
                    W = W(4, 10, 5, item)
                }
                    );
            }
        }

        public double RHO(double lambda, double mi)
        {
            return lambda/mi;
        }

        /// <summary>
        ///     Obliczenie Q
        /// </summary>
        public double Q(double lambda, double mi, double c, double i)
        {
                             double q0;
                if (i >= 0 && i <= c) {
                q0 = Math.Pow(lambda, i) / (Silnia(i) * Math.Pow(mi, i));
                 } else {
                q0 = Math.Pow(lambda, i) / (Silnia(c) * Math.Pow(mi, i) * Math.Pow(c, i - c));
                }
                 return q0;

        }

        /// <summary>
        ///     Obliczenie p
        /// </summary>
        //public double P(double lambda, double mi, double i, double c, double m)
        //{
        //    var suma = 0.0;
        //    for (int k = 0; k <=m+c; k++)
        //    {
        //        suma += Q(lambda, mi, k, c, m);
        //    }
        //
        //    return Q(lambda, mi, i, c, m)/suma;
        //}

        /// <summary>
        ///     prawdopodobieństwo straty zgłoszenia 
        /// </summary>

        public double Pstr(double c, double m, double mi, double lambda, double x)
        {
            double p0 = 0;
                if (x == -1) 
                {
                
                    for (double k = 0; k <= c + m; k++)
                    {
                
                        p0 = p0 + Q(lambda, mi, c, k);
                
                    }
                    p0 = 1/p0;
                return p0;
                } 
                else 
                {
                    return Pstr(c, m, mi, lambda, -1) * Q(lambda, mi, c, x);
                }
        }
        /// <summary>
        ///     średnia liczba zajętych stanowisk
        /// </summary>
        public double L( double c, double m,double mi,double lambda )
        {
            var suma1 = 0.0;
            for (double k = 1; k <= c; k++)
            {
                suma1 += k * Pstr(c,m,mi,lambda,k);
            }

            var suma2 = 0.0;
            for (double k = c + 1; k <= m + c; k++)
            {
                suma2 += c * Pstr(c, m, mi, lambda, k);
            }

            return suma1 + suma2;
        }
        public double N( double c, double m, double mi,double lambda )
        {
            double suma = 0;
            suma = L(c, m, mi, lambda) + V(c, m, mi, lambda);
            return suma;
        }

        public double W(  double c, double m,double mi,double lambda)
        {

            double suma = 0;
            suma = V(c, m, mi, lambda)/lambda;
            return suma;
        }

        public double V( double c, double m, double mi,double lambda)
        {

            double suma = 0;
            for (int i = 1; i <= m; i++)
            {
                suma = suma + (i*Pstr(c,m,mi,lambda,c+1));
            }
            return suma;
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
