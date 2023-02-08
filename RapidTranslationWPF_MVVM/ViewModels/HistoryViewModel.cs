using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        public HistoryViewModel()
        {
            PlaySoundCommand = new RelayCommand(PlaySound);
            GetFullInfomationCommand = new RelayCommand(GetFullInformation);

            
            //ListWordHistoryObj.SaveToFile();
            ListWordHistoryObj.LoadFromFile();
        }

        private static ListWordHistory _listWordHistoryObj = new ListWordHistory();
        public ListWordHistory ListWordHistoryObj
        {
            get { return _listWordHistoryObj; }
            set { _listWordHistoryObj = value; OnPropertyChanged(); }
        }

        public ICommand GetFullInfomationCommand { get; set; }
        public ICommand PlaySoundCommand { get; set; }

        private void GetFullInformation(object obj)
        {

        }
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
