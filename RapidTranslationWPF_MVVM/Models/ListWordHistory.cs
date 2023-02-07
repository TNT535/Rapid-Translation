using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RapidTranslationWPF_MVVM.Models
{
    public class ListWordHistory : ObservableObject
    {
        private string _nameClass = "ListWordHistory";
        public string NameClass
        {
            get { return _nameClass; }
            set { _nameClass = value; RaisePropertyChanged("NameClass"); }
        }
        
        private static ObservableCollection<WordHistory> _listWordHistory = new ObservableCollection<WordHistory>(new List<WordHistory>() { new WordHistory() {Word="Hello", Mean="Động từ: Xin chào" }, new WordHistory() { Word = "You", Mean = "Đại từ: Bạn" } });
        public ObservableCollection<WordHistory> ListWordHistorys
        {
            get { return _listWordHistory; }
            set { _listWordHistory = value; RaisePropertyChanged("ListWordHistorys"); }
        }

        public ObservableCollection<WordHistory> LoadFromFile(string path = "UserData/dataFile.xml")
        {
            ObservableCollection<WordHistory> fileData = new ObservableCollection<WordHistory>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open)) //double check that...
                {
                    XmlSerializer _xSer = new XmlSerializer(typeof(ObservableCollection<WordHistory>));

                    var myObject = _xSer.Deserialize(fs);

                    fileData = ((myObject as ObservableCollection<WordHistory>) != null) ? (myObject as ObservableCollection<WordHistory>) : fileData;
                    ListWordHistorys = fileData;
                }
            }
            catch
            {
                return fileData;
            }
            return fileData;
        }

        public void SaveToFile(string path = "UserData/dataFile.xml")
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xSer = new XmlSerializer(typeof(ObservableCollection<WordHistory>));

                xSer.Serialize(fs, ListWordHistorys);
            }
        }

    }
}
