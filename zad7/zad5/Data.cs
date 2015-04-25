using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    public class Element
    {
        public double Lambda { get; set; }
        public double Pbl { get; set; }
        public double Nbl { get; set; }
        public double Tbl { get; set; }
        public double W { get; set; }
        public double BigLambda { get; set; }
    }

    public class Data
    {
        public ObservableCollection<Element> Datas { get; set; }
        public List<float> Lambdas { get; set; }

        public Data()
        {
            Datas = new ObservableCollection<Element>();
            Lambdas = new List<float>();
            int m = 5;
            int N = 15;
            int mi = 4;
            for (float i = 0.15f; i < 1.21; i += 0.15f)
            {
                Lambdas.Add(i);
                Datas.Add(new Element()
                {
                    Lambda = i,
                    BigLambda = Lambda(N, m, mi, i),
                    Nbl = nbl(N, m, mi, i),
                    Pbl = pbl(N, m, mi, i),
                    Tbl = tbl(N,m,mi,i),
                    W = w(N,m,mi,i)
                });

            }



        }
        public static double silnia(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * silnia(n - 1);
            }

        }
        public static double p0(double N, double m, double mi, double lambda)
        {
            double suma = 0;
            double p0 = 0;
            for (double k = 0; k <= m + 2; k++)
            {
                suma = suma + ((Math.Pow(lambda / mi, k)) / silnia(N - k));
            }
            p0 = Math.Pow(silnia(N) * suma, -1);
            return p0;
        }
        public static double v(double N, double m, double mi, double lambda)
        {
            double v = 0;
            double suma = 0;
            for (double k = 2; k <= m + 1; k++)
            {
                suma = suma + (((k - 1) * silnia(N)) / silnia(N - k)) * Math.Pow(lambda / mi,
               k);
            }
            v = p0(N, m, mi, lambda) * (suma + (m * (silnia(N) / (silnia(N - m -
           2))) * Math.Pow(lambda / mi, m + 2)));
            return v;
        }
        public static double Lambda(double N, double m, double mi, double lambda)
        {
            double suma = 0;
            double l = 0;
            for (double k = 0; k <= m + 1; k++)
            {
                suma = suma + ((lambda / silnia(N - k - 1)) * Math.Pow(lambda / mi, k));
            }
            l = p0(N, m, mi, lambda) * silnia(N) * suma;
            return l;
        }
        public static double pbl(double N, double m, double mi, double lambda)
        {
            double pbl = p0(N, m, mi, lambda) * (silnia(N) / silnia(N - m - 2
            )) * Math.Pow(lambda / mi, m + 2);
            return pbl;
        }
        public static double nbl(double N, double m, double mi, double lambda)
        {
            double nbl = (N - m - 1) * p0(N, m, mi, lambda) * (silnia(N) / (silnia(N - m -
           2))) * Math.Pow(lambda / mi, m + 2);
            return nbl;
        }

        public static double w(double N, double m, double mi, double lambda)
        {
            return v(N, m, mi, lambda) / Lambda(N, m, mi, lambda);
        }
        public static double tbl(double N, double m, double mi, double lambda)
        {
            return nbl(N, m, mi, lambda) / Lambda(N, m, mi, lambda);
        }

    }
}
