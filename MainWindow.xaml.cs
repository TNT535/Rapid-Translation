using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
//using OpenAI;

namespace translate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Add your code here to handle the window closing event.
        }
        private void SettingClick(object sender, RoutedEventArgs e)
        {
            // Add your code here to handle the SettingClick event.
        }


        private async void translate_Click(object sender, RoutedEventArgs e)
        {
            string textToTranslate = input.Text;
            string before = langueBefore.Text;
            string after = langueAfter.Text;
            string translatedText = await TranslateText(textToTranslate, before, after);

            output.Text = translatedText;
        }
        private async Task<string> TranslateText(string inputText, string before, string after)
        {
            string url;
            if (before == "Auto")
            {
                if(after == "Vietnamese")
                {
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=vi&dt=t&q={inputText}\r\n";

                }
                else
                {
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=en&dt=t&q={inputText}\r\n";

                }
            }
            else if(before == "English")
            {
                if (after == "Vietnamese")
                {
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=vi&dt=t&q={inputText}\r\n";

                }
                else
                {
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=en&dt=t&q={inputText}\r\n";

                }
            }
            else
            {
                if (after == "Vietnamese")
                {
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=vi&tl=vi&dt=t&q={inputText}\r\n";

                }
                else
                {
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=vi&tl=en&dt=t&q={inputText}\r\n";

                }
            }
            
            string translatedText = "";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                string[] translatedArray = result.Split(new[] { "\"" }, StringSplitOptions.None);
                translatedText = translatedArray[1];
            }
            return translatedText;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
