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
using System.Speech.Synthesis;

namespace RapidTranslationWPF_MVVM.Views
{
    /// <summary>
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        public HistoryView()
        {
            InitializeComponent();
        }
        private void SpeakBtn1_Click(object sender, RoutedEventArgs e)
        {
            if (Word1.Text != "")
            {
                SpeechSynthesizer ss = new SpeechSynthesizer();

                ss.Speak(Word1.Text);
            }

        }

        private void SpeakBtn2_Click(object sender, RoutedEventArgs e)
        {
            if (Word2.Text != "")
            {
                SpeechSynthesizer ss = new SpeechSynthesizer();

                ss.Speak(Word2.Text);
            }
        }

        private void SpeakBtn3_Click(object sender, RoutedEventArgs e)
        {
            if (Word3.Text != "")
            {
                SpeechSynthesizer ss = new SpeechSynthesizer();

                ss.Speak(Word3.Text);
            }
        }

        private void SpeakBtn4_Click(object sender, RoutedEventArgs e)
        {
            if (Word4.Text != "")
            {
                SpeechSynthesizer ss = new SpeechSynthesizer();

                ss.Speak(Word4.Text);
            }
        }
    }
}
