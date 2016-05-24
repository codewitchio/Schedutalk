using Schedutalk.ViewModel;
using Schedutalk.Model;

namespace Schedutalk.Logic
{
    public class Program
    {
        public static MEvent[] getProgramEvents (string program)
        {
            return new MEvent[1];
        }

        private void downloadIcs (string program)
        {
            //http://www.kth.se/schema/ical?showweekend=false&start=2016-05-20&end=2016-06-20&freetext=&module=CDATE_1&outputview=table
            //var url = "http://www.kth.se/schema/ical?showweekend=false&start=" + startDate + "&end=" + endDate + "&module=" + program + "&outputview=table";
        }
    }

}