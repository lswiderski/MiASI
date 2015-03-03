using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class Data
    {
        public int Lambda { get; set; }
        public double P { get; set; }

        public Data(int lambda, double p)
        {
            Lambda = lambda;
            P = p;
        }
    }
}
