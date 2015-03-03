using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zad2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Data> datas;
        public MainWindow()
        {
            datas = new List<Data>();
            InitializeComponent();
            fillData();
            DataGrid1.ItemsSource = datas;
        }

        public void fillData()
        {
            for (int i = 2; i <=16; i+=2)
            {
                datas.Add(new Data(i,calcP(i,16)));
            }
        }
        public double calcP(int lambda, int kmax)
        {
            double p=0;
            for (int k = 0; k <= kmax; k++)
            {
                var x = (Math.Pow(lambda, k)/Factorial(k))*Math.Pow(2.7183, (-1)*lambda);
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
