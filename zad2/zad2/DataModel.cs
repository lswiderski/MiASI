using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class DataModel
    {
        public static ObservableCollection<Data> Datas { get; set; }

        public DataModel()
        {
            Datas = new ObservableCollection<Data>();
            FillData();
        }
        void FillData()
        {
            for (int i = 2; i <= 16; i += 2)
            {
                var p = CalcP(i, 16);

                Datas.Add(new Data(i, p*100, (1 - p)*100));
            }
        }
        double CalcP(int lambda, int kmax)
        {
            double p = 0;
            for (int k = 0; k <= kmax; k++)
            {
                var x = (Math.Pow(lambda, k) / Factorial(k)) * Math.Pow(2.7183, (-1) * lambda);
                p += x;
            }
            return p;
        }

        long Factorial(long i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
        
    }
}
