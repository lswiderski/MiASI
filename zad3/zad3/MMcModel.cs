using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    public class MMcModel
    {
        public static ObservableCollection<MMcData> Datas { get; set; }
        private static int u = 5;
        private static int c = 4;
        public MMcModel()
        {
            Datas = new ObservableCollection<MMcData>();
            FillData();
        }

        private void FillData()
        {
            for (int i = 2; i < 29; i+=2)
            {
                var ro = (float)i/(float)u;
                var gora = (float)(Math.Pow(ro, c)/Factorial(c));
                float dol = 0f;
                for (int j = 0; j < u; j++)
                {

                    dol += ((float)(Math.Pow(ro, j) / Factorial(j)));
                }
                Datas.Add(new MMcData()
                {
                    Lambda = i,
                    Obsluga = 1f - (gora / dol),
                    Strata = gora/dol,
                    Srednia = (1f - (gora / dol) )*ro
                });
            }
        }
        long Factorial(long i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
