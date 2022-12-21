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
using System.Windows.Shapes;

namespace RapidTranslationWPF
{
    /// <summary>
    /// Interaction logic for StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow : Window
    {
        public StatisticWindow()
        {
            InitializeComponent();
        }


                private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                Button btn = sender as Button;
                if (btn.Background == Brushes.White)
                {
                    BrushConverter brushConverter = new BrushConverter();
                    btn.Background = (Brush)brushConverter.ConvertFrom("#0F9D58");
                }
                else
                    btn.Background = Brushes.White;

            }
        }


    }
}
