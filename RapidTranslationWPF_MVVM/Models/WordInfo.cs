using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.Models
{
    public class WordInfo:ObservableObject
    {
        private string _word ="";
        public string Word
        {
            get { return _word; }
            set
            {
                _word = value;
                RaisePropertyChanged("Word");
            }
        }
        private bool selected = true;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                RaisePropertyChanged("Selected");
            }
        }
    }
}
