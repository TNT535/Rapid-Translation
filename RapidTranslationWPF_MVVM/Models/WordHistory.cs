using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.Models
{
    [Serializable]
    public class WordHistory:ObservableObject
    {
        private String _word;
        public String Word
        {
            get { return _word; }
            set { _word = value; RaisePropertyChanged("Word"); }
        }

        private String _pronounce;
        public String Pronounce
        {
            get { return _pronounce; }
            set { _pronounce = value; RaisePropertyChanged("Pronounce"); }
        }

        private String _mean;
        public String Mean
        {
            get { return _mean; }
            set { _mean = value; RaisePropertyChanged("Mean"); }
        }

        private String _translatino;
        public String Translation
        {
            get { return _translatino; }
            set { _translatino = value; RaisePropertyChanged("Translation"); }
        }
    }
}
