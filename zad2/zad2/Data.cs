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
        public double Pprim { get; set; }

        public Data(int lambda, double p, double pprim)
        {
            Lambda = lambda;
            P = p;
            Pprim = pprim;
        }

        public Data()
        {
            
        }
    }
}
