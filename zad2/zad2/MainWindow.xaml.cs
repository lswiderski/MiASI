using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static ObservableCollection<Data> Datas { get; set; }
        public MainWindow()
        {
            //Datas = new ObservableCollection<Data>();
            //FillData();
            //Thread.Sleep(1000);
            InitializeComponent();
            
           // DataGrid1.ItemsSource = Datas;
        }

        void FillData()
        {
            for (int i = 2; i <=16; i+=2)
            {
                var p = CalcP(i, 16);

                Datas.Add(new Data(i,p,1-p));
            }
        }
        double CalcP(int lambda, int kmax)
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
