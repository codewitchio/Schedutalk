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

        public Dictionary<DateTime, ObservableCollection<MEvent>> ScheduleData
        {
            get; set;
        }

        public ObservableCollection<MEvent> ScheduleEvents
        {
            get; set;
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                
                if (ScheduleData.ContainsKey(_selectedDate))
                {
                    ScheduleEvents = ScheduleData[_selectedDate];
                }
                else
                { 
                    ScheduleEvents = new ObservableCollection<MEvent>();
                }
                OnPropertyChanged("ScheduleEvents");
            }
        }

        public Command OnSelectEvent
        {
            get
            {
                return new Command(item =>
                {
                });
            }
        }

        public VMMainView()
        {
            ScheduleInfo = new ObservableCollection<MEvent>();
            ScheduleEvents = new ObservableCollection<MEvent>();
            ScheduleData = new Dictionary<DateTime, ObservableCollection<MEvent>>();

            //Set todays date at the calendar
            DateTime presentDate = DateTime.Now;
            setDemoValues(presentDate);
            SelectedDate = new DateTime(presentDate.Year, presentDate.Month, presentDate.Day);
            ScheduleInfo = getScheduleInfo();
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

        /// <summary>
        /// Use for simulating data
        /// </summary>
        private void setDemoValues(DateTime presentDate)
        {
            ObservableCollection<MEvent> demo = new ObservableCollection<MEvent>();
            string longText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            demo.Add(new Model.MEvent { Title = "Matematics", StartDate = new Model.MDate(08, 00), EndDate = new Model.MDate(9, 00) });
            demo.Add(new Model.MEvent { Title = "Exercise", StartDate = new Model.MDate(12, 00), EndDate = new Model.MDate(15, 00) });
            demo.Add(new Model.MEvent { Title = "Hackathon", Information = longText, StartDate = new Model.MDate(20, 00), EndDate = new Model.MDate(23, 59) });

            ScheduleData.Add(new DateTime(presentDate.Year, presentDate.Month, presentDate.Day), demo);

            ObservableCollection<MEvent> demo2 = new ObservableCollection<MEvent>();
            demo2.Add(new Model.MEvent { Title = "Mac goes: (╯°□°）╯︵ ┻━┻)", Information = "Why are PCs like air conditioners?" + Environment.NewLine + "Mac: They stop working properly if you open Windows!", StartDate = new Model.MDate(16, 00), EndDate = new Model.MDate(18, 00) });
            demo2.Add(new Model.MEvent { Title = "Mac goes: (╯°□°）╯︵ ┻━┻)", Information = "Why are PCs like air conditioners?" + Environment.NewLine + "Mac: They stop working properly if you open Windows!", StartDate = new Model.MDate(14, 00), EndDate = new Model.MDate(15, 00) });
            ScheduleData.Add(new DateTime(presentDate.Year, presentDate.Month, presentDate.Day + 1), demo2);
        }
    }

}

