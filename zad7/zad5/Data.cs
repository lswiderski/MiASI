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
        public double P0 { get; set; }
        public double Pstr2 { get; set; }
        public double Pstr1 { get; set; }
        public double Pt { get; set; }
        public double Pl { get; set; }
        public double Pstr { get; set; }
    }

    public class Data
    {
        public ObservableCollection<Element> Datas { get; set; }
        public List<int> Lambdas { get; set; }
        public List<int> Lambda1 { get; set; }
        public List<int> Lambda2 { get; set; }

        public Data()
        {
            Datas = new ObservableCollection<Element>();
            Lambdas = new List<int>();
            Lambda1 = new List<int>();
            Lambda2 = new List<int>();
            int c = 3;
            int m1 = 6;
            int m = 10;
            int mi = 10;
            for (int i = 2, j=4; i <=14; i += 2, j+=4)
            {
                Lambda1.Add(i);
                Lambda2.Add(j);
                Lambdas.Add(i+j);
                Datas.Add(new Element()
                {
                    Lambda = i+j,
                    P0 = P0(Q(i,j,mi),Q2(j,mi),c,m1,m),
                    Pstr2 = Pstr2(Q(i, j, mi), Q2(j, mi), c, m1, m),
                    Pstr1 = Pstr1(Q(i, j, mi), Q2(j, mi), c, m1, m),
                    Pstr = Pstr(Q(i, j, mi), Q2(j, mi), Q1(i,mi), c, m1, m),
                    Pl = Pl(Q(i, j, mi), Q2(j, mi), Q1(i, mi), c, m1, m),
                    Pt = Pt(Q(i, j, mi), Q2(j, mi),  c, m1, m)
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

        public static double Q(int lambda1, int lambda2, int mi)
        {
            return ((lambda1+lambda2)/(double)mi);
        }
        public static double Q2(int lambda2, int mi)
        {
            return Q1(lambda2, mi);
        }
        public static double Q1(int lambda1, int mi)
        {
            return (lambda1 / (double)mi);
        }

        public static double SumC(double q, int c)
        {
            double result = 0.0d;
            for (int i = 0; i <= c-1; i++)
            {
                var tmp1 = Math.Pow(q, i);
                var tmp2 = silnia(i);
                var x =tmp1/tmp2;
                result += x;
            }
            return result;
        }

        public static double SumM1(double q, int c, int m1)
        {
            double result = 0.0d;
            for (int i = 0; i <= m1 - 1; i++)
            {
                result += Math.Pow((q/c), i);
            }
            return result;
        }
        public static double SumMM1(double q2, int c, int m1, int m)
        {
            double result = 0.0d;
            for (int i = 0; i <= m-m1; i++)
            {
                result += Math.Pow(q2/c,i);
            }
            return result;
        }
        public static double QdoCprzezCSilnia(double q, int c)
        {
            return Math.Pow(q, c)/silnia(c);
        }
        public static double QprzezCdoM1(double q, int c, int m1)
        {
            return Math.Pow(q/c, m1);
        }
        public static double Q2przezCdoMM1(double q2, int c, int m1, int m)
        {
            return Math.Pow(q2 / c, m-m1);
        }
        public static double P0(double q, double q2,int c, int m1, int m)
        {
            var result =
                Math.Pow(
                    SumC(q, c) +
                    (QdoCprzezCSilnia(q, c)*((SumM1(q, c, m1) + (QprzezCdoM1(q, c, m1)*SumMM1(q2, c, m1, m))))), -1);
            return result;
        }

        public static double Pstr2(double q, double q2, int c, int m1, int m)
        {
            return P0(q, q2, c, m1, m)*QdoCprzezCSilnia(q, c)*QprzezCdoM1(q, c, m1)*Q2przezCdoMM1(q2, c, m1, m);
        }
        public static double Pstr1(double q, double q2, int c, int m1, int m)
        {
            return P0(q, q2, c, m1, m) * QdoCprzezCSilnia(q, c) * QprzezCdoM1(q, c, m1) * SumMM1(q2,c,m1,m);
        }
        public static double Pt(double q, double q2, int c, int m1, int m)
        {
            return Pstr2(q, q2, c, m1, m)*(q2/q);
        }
        public static double Pl(double q, double q2, double q1, int c, int m1, int m)
        {
            return Pstr1(q, q2, c, m1, m) * (q1 / q);
        }

        public static double Pstr(double q, double q2, double q1, int c, int m1, int m)
        {
            return Pt(q, q2, c, m1, m) + Pl(q, q2, q1, c, m1, m);
        }
    }
}
