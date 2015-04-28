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

namespace zad8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
              Data data = new Data();
            InitializeComponent();
            DataGridN.ItemsSource = data.DataN;
            DataGridV.ItemsSource = data.DataV;
            if (data.DataW.ElementAt(5) != null)
            {
                czasW.Content = "M/M/1 = " + data.DataW.ElementAt(5).MM1 +
                                " M/D/1 = " + data.DataW.ElementAt(5).MD1 +
                                " sigma 0.9 = " + data.DataW.ElementAt(5).Sigma1 +
                                " sigma 0.6 = " + data.DataW.ElementAt(5).Sigma2 +
                                " sigma 0.3 = " + data.DataW.ElementAt(5).Sigma3;
            }
            
            
        }
    }
}
