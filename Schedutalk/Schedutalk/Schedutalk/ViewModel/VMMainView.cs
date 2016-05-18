using Schedutalk.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Schedutalk.ViewModel
{
    public class VMMainView : VMBase
    {
        public ObservableCollection<MEvent> ScheduleInfo
        {
            get; set;
        }

        public ObservableCollection<MEvent> ScheduleEvents
        {
            get; set;
        }


        public VMMainView()
        {
            ScheduleInfo = new ObservableCollection<MEvent>();
            ScheduleEvents = new ObservableCollection<MEvent>();

            ScheduleInfo = getScheduleInfo();

            string longText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            ScheduleEvents.Add(new Model.MEvent { Title = "Matematics", StartDate = new Model.MDate(08, 00), EndDate = new Model.MDate(9, 00) });
            ScheduleEvents.Add(new Model.MEvent { Title = "Exercise", StartDate = new Model.MDate(12, 00), EndDate = new Model.MDate(15, 00) });
            ScheduleEvents.Add(new Model.MEvent { Title = "Hackathon", Information=longText, StartDate = new Model.MDate(20, 00), EndDate = new Model.MDate(23, 59) });
        }

        private ObservableCollection<MEvent> getScheduleInfo()
        {
            ObservableCollection<MEvent> scheduleInfo = new ObservableCollection<MEvent>();

            for (int i = 0; i < 24; i++)
            {
                scheduleInfo.Add(new Model.MEvent { Title = "", StartDate = new Model.MDate(i, 00), EndDate = new Model.MDate(i, 59) });

            }

            return scheduleInfo;
        }
    }

}

