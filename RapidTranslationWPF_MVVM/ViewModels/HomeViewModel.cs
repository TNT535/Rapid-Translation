using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using static RapidTranslationWPF_MVVM.Models.DataGobalVariable;

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

        private bool isVocabFound = true;
        public DataGobalVariable dataGobalVariable = new DataGobalVariable();

        public HomeViewModel()
        {
            _exampleModel = new ExampleModel();
            HomeString = "";
            getPreviousVocab();
            SearchVocabularyCommand = new RelayCommand(SearchVocabulary); 
            PlaySoundCommand = new RelayCommand(PlaySound);

        }

        public ICommand SearchVocabularyCommand { get; set; }
        private void setResultSearchVocab(ItemVocab itemVocab, bool update)
        {
            if (itemVocab == null)
            {
                ResultSearchVocab = "Không tìm thấy từ vựng";
                return;
            }
            ResultSearchVocab = "";
            ResultSearchVocab += "Từ vựng: " + itemVocab.Vocabulary + '\n';
            ResultSearchVocab += "Phiên âm: " + itemVocab.Phonetic + '\n';
            ResultSearchVocab += "Chi tiết: " + itemVocab.Details;

            if (update == true)
            {
                dataGobalVariable.SourceItemLog.Add(new ItemLog() { 
                    LogVocab = itemVocab.Vocabulary,
                    LogDateTime = DateTime.Now
                });
                dataGobalVariable.saveLogs();
            }
        }
        private void getPreviousVocab()
        {
            var lastVocab = dataGobalVariable.SourceItemLog.Last();

            if (lastVocab == null)
                ResultSearchVocab = "Bạn chưa tìm kiếm từ vựng nào.";

            if (lastVocab != null)
            {
                var itemFromItemVocab = dataGobalVariable.SourceItemVocab.Find(x => x.Vocabulary == lastVocab.LogVocab);
                setResultSearchVocab(itemFromItemVocab, false);
            }
        }
        private void SearchVocabulary(object obj)
        {  
            var item = dataGobalVariable.SourceItemVocab.Find(x => x.Vocabulary == HomeString);
            setResultSearchVocab(item, true);
        }

        public ICommand PlaySoundCommand { get; set; }

        private void PlaySound(object obj)
        {
            if (obj is string)
            {
                string word = obj as string;
                SpeechSynthesizer ss = new SpeechSynthesizer();
                ss.Speak(word);
            }
        }

        

    }
}
