using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class DateTimeWithCounter
    {
        public DateTime DateTimeProp;
        public int Counter;
    }
    public class Analytics
    {
        public List<DateTime> PopularMonth(List<DateTime> dates)
        {
            var DateTimeWithCounterList = new List<DateTimeWithCounter>();
            foreach (DateTime date in dates)
            {
                var DateMonthStart = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
                var index = DateTimeWithCounterList.
                    FindIndex(item => item.DateTimeProp == DateMonthStart);
                if (index == -1)
                {
                    DateTimeWithCounterList.
                        Add(
                        new DateTimeWithCounter
                        {
                            DateTimeProp = DateMonthStart,
                            Counter = 1
                        }
                    );
                }
                else
                {
                    DateTimeWithCounterList[index].Counter++;
                }
            }
            return DateTimeWithCounterList
                .OrderByDescending(item => item.Counter)
                .ThenBy(item => item.DateTimeProp)
                .Select(item => item.DateTimeProp)
                .ToList();
        }
    }
}
