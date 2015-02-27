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
using MathNet;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;

namespace zad1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public static List<Lambdas> table1 { get; set; }
         public static List<Lambdas> table2 { get; set; }
        private int K;
        private float T;
        public MainWindow()
        {
            K = 20;
            T = 1.5f;
            table1 = new List<Lambdas>();
            table2 = new List<Lambdas>();
            Fill1stTable();
            Fill2ndTable();
            
            InitializeComponent();
            DataGrid1.ItemsSource = table1;
            DataGrid2.ItemsSource = table2;
            DataGrid1.UpdateLayout();

        }

        void Fill1stTable()
        {
            var lambda1 = 2;
            var lambda2 = 10;
            MathNet.Numerics.Distributions.Poisson k1 = new Poisson(lambda1);
            MathNet.Numerics.Distributions.Poisson k2 = new Poisson(lambda2);
           
            for (int k = 0; k < K+1; k++)
            { 
                //lambda = 2 && lambda = 10
                table1.Add(new Lambdas(k,k1.Probability(k), k2.Probability(k)));
            }
        }

        void Fill2ndTable()
        {
            var lambda1 = 2;
            var lambda2 = 10;
            for (float t = 0.1f; t < T + 0.1; t+=0.1f)
            {
                //lambda = 2 && lambda = 10
                var lamb1 = 1 - (Math.Exp (-lambda1 * t));
                var lamb2 = 1 - (Math.Exp(-lambda2 * t));
                table2.Add(new Lambdas(t,lamb1,lamb2));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new A().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new B().Show();
        }

    }
}
