using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string HomeString
        {
            get { return _exampleModel.ExampleHomeString; }
            set { _exampleModel.ExampleHomeString = value; OnPropertyChanged(); }
        }

        private string _ResultSearchVocab;
        public string ResultSearchVocab
        {
            get { return _ResultSearchVocab; }
            set { _ResultSearchVocab = value; OnPropertyChanged(); }
        }

        public HomeViewModel()
        {
            _exampleModel = new ExampleModel();
            HomeString = "home user control window";
            ResultSearchVocab = "";
            SearchVocabularyCommand = new RelayCommand(SearchVocabulary);
        }

        public ICommand SearchVocabularyCommand { get; set; }

        private void SearchVocabulary(object obj)
        {
            string json_path_file = "Data/vocab.0.4.json";
            List<ItemVocab> source = new List<ItemVocab>();

            using (StreamReader r = new StreamReader(json_path_file))
            {
                string json_file_vocab = r.ReadToEnd();
                source = JsonSerializer.Deserialize<List<ItemVocab>>(json_file_vocab);

                var item = source.Find(x => x.Vocabulary == HomeString);
                if (item == null)
                {
                    ResultSearchVocab = "Không tìm thấy từ vựng"; 
                }
                else
                { 
                    ResultSearchVocab = "";
                    ResultSearchVocab += "Từ vựng: " + item.Vocabulary + '\n';
                    ResultSearchVocab += "Phiên âm: " + item.Phonetic + '\n';
                    ResultSearchVocab += "Chi tiết: " + item.Details + '\n';
                }

            }
        }
    }

    public class ItemVocab
    {
        public string Vocabulary { get; set; }
        public string Phonetic { get; set; }
        public string Details { get; set; } 
    }
}
