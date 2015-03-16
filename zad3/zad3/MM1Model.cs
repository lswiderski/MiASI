using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    public class MM1Model
    {
        public static ObservableCollection<MM1Data> Datas { get; set; }
        private static int u = 10;
        public MM1Model()
        {
            Datas = new ObservableCollection<MM1Data>();
            FillData();
        }

        private void FillData()
        {
            for (int i = 1; i < 13; i++)
            {
                Datas.Add(new MM1Data()
                {
                    Lambda = i,
                    Obsluga = 1 / ((float)i / u + 1),
                    Strata = (float)((float)i / (float)u) / ((float)((float)i / (float)u) + 1)
                });
            }
        }
    }
}
