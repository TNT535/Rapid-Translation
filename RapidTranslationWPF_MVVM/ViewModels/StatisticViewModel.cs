using RapidTranslationWPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization; 

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class StatisticViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string StatisticString
        {
            get { return _exampleModel.ExampleStatisticString; }
            set { _exampleModel.ExampleStatisticString = value; OnPropertyChanged(); }
        }
        public StatisticViewModel()
        {
            _exampleModel = new ExampleModel();
            StatisticString = "";
            TotalVocab1Day = getInfoVocabDay(1).totalLogs.ToString();
            TotalVocab7Day = getInfoVocabDay(7).totalLogs.ToString();
            TotalVocab30Day = getInfoVocabDay(30).totalLogs.ToString();

            Last1DayStored = getInfoVocabDay(1).LogDateTime.ToString();
            Last7DayStored = getInfoVocabDay(7).LogDateTime.ToString();
            Last30DayStored = getInfoVocabDay(30).LogDateTime.ToString();
        }
        

        private string totalVocab1Day;
        private string totalVocab7Day;
        private string totalVocab30Day;
        private string last1DayStored;
        private string last7DayStored;
        private string last30DayStored;
        public DataGobalVariable dataGobalVariable = new DataGobalVariable();

        public string TotalVocab1Day
        { 
            get { return totalVocab1Day; }
            set { totalVocab1Day = value; OnPropertyChanged(); } 
        }
        public string TotalVocab7Day
        {
            get { return totalVocab7Day; }
            set { totalVocab7Day = value; OnPropertyChanged(); }
        }
        public string TotalVocab30Day
        {
            get { return totalVocab30Day; }
            set { totalVocab30Day = value; OnPropertyChanged(); }
        }
        public string Last1DayStored
        {
            get { return last1DayStored; }
            set { last1DayStored = value; OnPropertyChanged(); }
        }
        public string Last7DayStored
        {
            get { return last7DayStored; }
            set { last7DayStored = value; OnPropertyChanged(); }
        }
        public string Last30DayStored
        {
            get { return last30DayStored; }
            set { last30DayStored = value; OnPropertyChanged(); }
        }
        public ItemInfoLog getInfoVocabDay(int d)
        {
            DateTime nowDateTime = DateTime.Now;
            List <ItemLog> itemLogs = dataGobalVariable.SourceItemLog;

            ItemInfoLog resultInfo = new ItemInfoLog();
            resultInfo.totalLogs = 0;

            foreach (var itemLog in itemLogs)
            {
                DateTime dateTimeItem = itemLog.LogDateTime;
                TimeSpan interval = nowDateTime - dateTimeItem;
                 
                if ((int)(interval.TotalDays) <= d)
                {
                    resultInfo.totalLogs += 1;
                    resultInfo.LogDateTime = dateTimeItem;
                }
                else
                    break;
            }
            return resultInfo;
        }

        public class ItemChart
        {
            public string days { get; set; } 
            public int numVocab { get; set; }  
        }
        private List<ItemChart> getNumVocabPerDay()
        { 
            List<ItemLog> itemLogs = dataGobalVariable.SourceItemLog;
            DateTime nowDateTime = DateTime.Now;

            List<int> flags = new List<int>(31);
            List<ItemChart> itemChart = new List<ItemChart>(); 

            foreach (var itemLog in itemLogs)
            {
                DateTime dateTimeItem = itemLog.LogDateTime;
                TimeSpan interval = nowDateTime - dateTimeItem;

                if (interval.Days <= 30)
                    flags[interval.Days] += 1;
            }

            for(int i = 1; i <= 30; ++i)
            {
                itemChart.Add(new ItemChart() { days = i.ToString(), numVocab = flags[i] });;
            }

            return itemChart;
        }
    }
}
