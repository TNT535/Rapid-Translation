using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
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
using GTranslate.Translators;


namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class TranslationSentencePageViewModel : ViewModelBase
    {
        private string _translationSentencePage = "translation sentence page";
        public string TranslationSentencePage
        {
            get { return _translationSentencePage; }
            set { _translationSentencePage = value; OnPropertyChanged(); }
        }

        private string _input = "Hello";
        public string InputText
        {
            get { return _input; }
            set { _input = value; OnPropertyChanged(); }
        }

        private string _output = "";
        public string OutputText
        {
            get { return _output; }
            set { _output = value; OnPropertyChanged(); }
        }

        private string _lanBefore = "Auto";
        public string LanBefore
        {
            get { return _lanBefore; }
            set { _lanBefore = value; OnPropertyChanged(); }
        }

        private string _lanAfter = "Vietnamese";
        public string LanAfter
        {
            get { return _lanAfter; }
            set { _lanAfter = value; OnPropertyChanged(); }
        }


        public TranslationSentencePageViewModel()
        {
            TranslationSentencePage = "translation sentence page user control window";
            TranslateSentenceCommand = new RelayCommand(translate_Click);

            TranslateFromCapture();
            translate_Click(null);
        }

        public ICommand TranslateSentenceCommand { get; set; }

        private async void translate_Click(object obj)
        {
            string textToTranslate = InputText;
            string before = LanBefore;
            string after = LanAfter;
            string translatedText = await TranslateText(textToTranslate, before, after);

            OutputText = translatedText;
        }


        private Capture _captureObject = new Capture();
        public Capture CaptureObject
        {
            get { return _captureObject; }
            set { _captureObject = value; OnPropertyChanged(); }
        }


        private async Task<string> TranslateText(string inputText, string before, string after)
        {
            string url;
            if (before == "Auto")
            {
                if (after == "Vietnamese")
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=vi&dt=t&q={inputText}\r\n";
                else
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=en&dt=t&q={inputText}\r\n";
            }
            else if (before == "English")
            {
                if (after == "Vietnamese")
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=vi&dt=t&q={inputText}\r\n";
                else
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=en&dt=t&q={inputText}\r\n";
            }
            else
            {
                if (after == "Vietnamese")
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=vi&tl=vi&dt=t&q={inputText}\r\n";
                else
                    url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=vi&tl=en&dt=t&q={inputText}\r\n";
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

        private void TranslateFromCapture()
        {
            string text = "";
            if (CaptureObject.WordInfoList.Count > 0)
            {
                foreach (var item in CaptureObject.WordInfoList)
                {
                    if (item.Word != " ")
                        text += item.Word + " ";
                }
            }
            InputText = text;
        }
    }
}
