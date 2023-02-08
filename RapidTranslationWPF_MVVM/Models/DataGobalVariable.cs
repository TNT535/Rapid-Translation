using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RapidTranslationWPF_MVVM.Models
{
    public class DataGobalVariable : ObservableObject
    {
        public static List<ItemVocab> load_vocab_json()
        {
            StreamReader jsonFile = new StreamReader("Data/vocab.0.4.json");
            var sourceItemVocab = JsonSerializer.Deserialize<List<ItemVocab>>(jsonFile.ReadToEnd());

            return sourceItemVocab;
        } 
        public static List<ItemLog> load_log_xml()
        {
            string path_log_file = "Data/logFile.xml";
            List<ItemLog> logsData = new List<ItemLog>();

            try
            {
                using (FileStream fs = new FileStream(path_log_file, FileMode.Open))
                {
                    XmlSerializer _xSer = new XmlSerializer(typeof(List<ItemLog>)); 
                    var myObject = _xSer.Deserialize(fs); 
                    logsData = ((myObject as List<ItemLog>) != null) ? (myObject as List<ItemLog>) : logsData; 
                }
            }
            catch
            {
                return logsData;
            }
            return logsData;
        }
        public static void save_log_xml()
        {
            string path_log_file = "Data/logFile.xml";
            using (FileStream fs = new FileStream(path_log_file, FileMode.Create))
            {
                XmlSerializer xSer = new XmlSerializer(typeof(List<ItemLog>));
                xSer.Serialize(fs, _sourceItemLog);
            } 
        }
        public List<ItemVocab> SourceItemVocab {
            get { return _sourceItemVocab; }
            set
            {
                _sourceItemVocab = value;
                RaisePropertyChanged("SourceItemVocab");
            }
        }
        public List<ItemLog> SourceItemLog
        {
            get { return _sourceItemLog; }
            set
            {
                _sourceItemLog = value;
                RaisePropertyChanged("SourceItemLog");
            }
        }
        public void saveLogs()
        {
            save_log_xml();
        }

        private static List<ItemVocab> _sourceItemVocab = new List<ItemVocab>(load_vocab_json());
        private static List<ItemLog> _sourceItemLog = new List<ItemLog>(load_log_xml());
    }
}
