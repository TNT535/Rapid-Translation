using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.Models
{
    public class DayCountSearchCollection:Collection<DayCountSearch>
    {
        public DayCountSearchCollection()
        {
            Add(new DayCountSearch { Day = "1", Count = 0 });
            Add(new DayCountSearch { Day = "2", Count = 2 });
            Add(new DayCountSearch { Day = "3", Count = 20 });
            Add(new DayCountSearch { Day = "4", Count = 12 });
            Add(new DayCountSearch { Day = "5", Count = 25 });
            Add(new DayCountSearch { Day = "6", Count = 5 });
            Add(new DayCountSearch { Day = "7", Count = 20 });
            Add(new DayCountSearch { Day = "8", Count = 30 });
            Add(new DayCountSearch { Day = "9", Count = 30 });
            Add(new DayCountSearch { Day = "10", Count = 30 });
            Add(new DayCountSearch { Day = "11", Count = 30 });
            Add(new DayCountSearch { Day = "12", Count = 30 });
            Add(new DayCountSearch { Day = "13", Count = 30 });
            Add(new DayCountSearch { Day = "14", Count = 30 });
            Add(new DayCountSearch { Day = "15", Count = 30 });
            Add(new DayCountSearch { Day = "16", Count = 30 });
            Add(new DayCountSearch { Day = "17", Count = 30 });
            Add(new DayCountSearch { Day = "18", Count = 30 });
            Add(new DayCountSearch { Day = "19", Count = 30 });
            Add(new DayCountSearch { Day = "20", Count = 30 });
            Add(new DayCountSearch { Day = "21", Count = 30 });
            Add(new DayCountSearch { Day = "22", Count = 30 });
            Add(new DayCountSearch { Day = "23", Count = 30 });
            Add(new DayCountSearch { Day = "24", Count = 30 });
            Add(new DayCountSearch { Day = "25", Count = 30 });
            Add(new DayCountSearch { Day = "26", Count = 30 });
            Add(new DayCountSearch { Day = "27", Count = 30 });
            Add(new DayCountSearch { Day = "28", Count = 30 });
            Add(new DayCountSearch { Day = "29", Count = 30 });
            Add(new DayCountSearch { Day = "30", Count = 30 });
        }
    }
}
