using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class SearchWordCaptureViewModel : ViewModelBase
    {

        private string _ResultSearchVocab;
        public string ResultSearchVocab
        {
            get { return _ResultSearchVocab; }
            set { _ResultSearchVocab = value; OnPropertyChanged(); }
        }

        private bool isVocabFound = true;
        public DataGobalVariable dataGobalVariable = new DataGobalVariable();

        public SearchWordCaptureViewModel()
        {
            getPreviousVocab();
            SearchVocabularyCommand = new RelayCommand(SearchVocabulary);
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
                dataGobalVariable.SourceItemLog.Add(new ItemLog()
                {
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
            var item = dataGobalVariable.SourceItemVocab.Find(x => x.Vocabulary == CaptureObject.WordInfoRightClick.Word);
            setResultSearchVocab(item, true);
        }

        private Capture _captureObject = new Capture();
        public Capture CaptureObject
        {
            get { return _captureObject; }
            set { _captureObject = value; OnPropertyChanged(); }
        }

    }
}
