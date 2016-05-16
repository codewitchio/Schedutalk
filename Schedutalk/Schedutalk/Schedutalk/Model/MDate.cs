using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedutalk.Model
{
    class MDate : ViewModel.VMBase
    {
        private int hour;
        private int minute;

        public MDate(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
                OnPropertyChanged("Hour");
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
                OnPropertyChanged("Minute");
            }
        }
    }
}
