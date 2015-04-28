using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad8
{
    public class Element
    {
        public int Lambda { get; set; }
        public double MM1 { get; set; }
        public double MD1 { get; set; }
        public double Sigma1 { get; set; } //0.9
        public double Sigma2 { get; set; } //0.6
        public double Sigma3 { get; set; } //0.3
    }

    class Data
    {
        public ObservableCollection<Element> DataN { get; set; }
        public ObservableCollection<Element> DataV { get; set; }
        public ObservableCollection<Element> DataW { get; set; }
        public List<int> Lambdas { get; set; }

        public Data()
        {
            Lambdas = new List<int>();
            DataN = new ObservableCollection<Element>();
            DataV = new ObservableCollection<Element>();
            DataW = new ObservableCollection<Element>();
            int mi = 8;
            float sigma1 = 0.9f;
            float sigma2 = 0.6f;
            float sigma3 = 0.3f;
            for (int i = 1; i <= 7; i++)
            {
                Lambdas.Add(i);
                DataN.Add(new Element()
                {
                    Lambda = i,
                    MD1 = Md1N(mi, i),
                    MM1 = Mm1N(mi,i),
                    Sigma1 = SigmaN(mi,i,sigma1),
                    Sigma2 = SigmaN(mi, i, sigma2),
                    Sigma3 = SigmaN(mi, i, sigma3)
                });
                DataV.Add(new Element()
                {
                    Lambda = i,
                    MD1 = Md1V(mi, i),
                    MM1 = Mm1V(mi, i),
                    Sigma1 = SigmaV(mi, i, sigma1),
                    Sigma2 = SigmaV(mi, i, sigma2),
                    Sigma3 = SigmaV(mi, i, sigma3)
                });
                DataW.Add(new Element()
                {
                    Lambda = i,
                    MD1 = Md1W(mi, i),
                    MM1 = Mm1W(mi, i),
                    Sigma1 = SigmaW(mi, i, sigma1),
                    Sigma2 = SigmaW(mi, i, sigma2),
                    Sigma3 = SigmaW(mi, i, sigma3)
                });
            }
        }

        public static double Mm1N(double mi, double lambda) { return (lambda / mi) / (1 - (lambda / mi)); }
        public static double Mm1V(double mi, double lambda) { return Mm1N(mi, lambda) - (lambda / mi); }
        public static double Mm1W(double mi, double lambda) { return Mm1V(mi, lambda) / lambda; }
        public static double Md1N(double mi, double lambda) { return (lambda / mi) + (Math.Pow((lambda / mi), 2) / (2 * (1 - (lambda / mi)))); }
        public static double Md1V(double mi, double lambda) { return Md1N(mi, lambda) - (lambda / mi); }
        public static double Md1W(double mi, double lambda) { return Md1V(mi, lambda) / lambda; }

        public static double SigmaN(double mi, double lambda, double value)
        {
            return (lambda / mi) + ((Math.Pow((lambda / mi), 2) + Math.Pow(lambda, 2) * Math.Pow((value * 1 / mi), 2)) / (2 * (1 - (lambda / mi))));
        }
        public static double SigmaV(double mi, double lambda, double value) { return SigmaN(mi, lambda, value) - (lambda / mi); }

        public static double SigmaW(double mi, double lambda, double value)
        {

            return SigmaV(mi, lambda, value) / lambda;

        }
    }
}
