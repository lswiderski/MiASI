using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    public class Element
    {
        public int Lambda { get; set; }
        public double V { get; set; }
        public double L { get; set; }
        public double W { get; set; }
        public double BigLambda { get; set; }
    }

    public class Pi
    {
        public int I { get; set; }
        public double P { get; set; }
    }
    public class Data
    {
        public ObservableCollection<Element> Datas { get; set; }
        public ObservableCollection<Pi> Stany { get; set; }
        public List<int> Lambdas { get; set; }

        public Data()
        {
            Datas = new ObservableCollection<Element>();
            Stany = new ObservableCollection<Pi>();
            Lambdas = new List<int>();
            int c = 3;
            int N = 15;
            int mi = 10;
            for (int i = 1; i < 9; i++)
            {
                Lambdas.Add(i);
                Datas.Add(new Element()
                {
                    Lambda = i,
                    BigLambda = lambda(c, N, mi, i),
                    L = l(c, N, mi, i),
                    V = v(c, N, mi, i),
                    W = w(c,N,mi,i)
                });

            }
            for (int i = 0; i < N; i++)
            {
                Stany.Add(new Pi()
                {
                    I = i,
                    P = p(c, N, mi, i, 6)

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
        public static double q(double c, double N, double mi, double i, double lambda)
        {
            double q = 0;
            if (i >= 0 && i <= c)
            {
                q = silnia(N) / (silnia(N - i) * silnia(i)) * Math.Pow(lambda / mi, i);

            }
            if (i >= c + 1 && i <= N)
            {
                q = ((Math.Pow(c, c) * silnia(N)) / (silnia(N - i) * silnia(c))) * Math.Pow(lambda / mi / c, i);
            }
            return q;
        }


        public static double p(double c, double N, double mi, double i, double lambda)
        {
            if (i == -1)
            {
                double p = 0;
                for (double k = 0; k <= N; k++)
                {
                    p = p + q(c, N, mi, k, lambda);
                }
                return 1 / p;
            }
            else
            {
                return p(c, N, mi, -1, lambda) * q(c, N, mi, i, lambda);
            }
        }

        public static double v(double c, double N, double mi, double lambda)
        {
            double v_ = 0;
            for (double i = c + 1; i <= N; i++)
            {
                v_ = v_ + ((i - c) * p(c, N, mi, i, lambda));
            }
            return v_;
        }
        public static double n(double c, double N, double mi, double lambda)
        {
            double n_ = 0;
            for (double i = c + 1; i <= N; i++)
            {
                n_ = n_ + ((i - c) * p(c, N, mi, i, lambda));
            }
            for (int i = 1; i <= c; i++)
            {
                n_ = n_ + (i * p(c, N, mi, i, lambda));
            }
            for (int i = (int)(c + 1); i <= N; i++)
            {
                n_ = n_ + (c * p(c, N, mi, i, lambda));
            }
            return n_;
        }
        public static double l(double c, double N, double mi, double lambda)
        {
            double l = 0;
            for (int i = 1; i <= c; i++)
            {
                l = l + (i * p(c, N, mi, i, lambda));
            }
            for (int i = (int)(c + 1); i <= N; i++)
            {
                l = l + (c * p(c, N, mi, i, lambda));
            }
            return l;
        }
        public static double lambda(double c, double N, double mi, double lambda)
        {
            double l = 0;
            l = lambda * (N - n(c, N, mi, lambda));
            return l;
        }

        public static double w(double c, double N, double mi, double _lambda)
        {
            return v(c, N, mi, _lambda) / lambda(c, N, mi, _lambda);
        }

    }
}
