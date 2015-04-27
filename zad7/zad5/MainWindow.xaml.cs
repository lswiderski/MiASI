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

namespace zad6
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
            DataGridPbl.ItemsSource = data.Datas;
            DataGridNbl.ItemsSource = data.Datas;
            DataGridTbl.ItemsSource = data.Datas;
            DataGridW.ItemsSource = data.Datas;
            DataGridBL.ItemsSource = data.Datas;
            DataGridPstr.ItemsSource = data.Datas;
        }
    }
}
