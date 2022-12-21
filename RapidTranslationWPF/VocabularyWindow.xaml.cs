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
using System.Speech.Recognition;
using WinFormsApp1;

namespace RapidTranslationWPF
{
    /// <summary>
    /// Interaction logic for VocabularyWindow.xaml
    /// </summary>
    public partial class VocabularyWindow : Page
    {
        public VocabularyWindow()
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
    }
}
