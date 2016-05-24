using Schedutalk.Logic.KTHPlaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedutalk.Model
{
    public class MEvent : ViewModel.VMBase
    {
        KTHPlacesDataFetcher kthPlacesDataFetcher = new KTHPlacesDataFetcher();
        public MDate StartDate
        {
            get;
            set;
        }

        public MDate EndDate
        {
            get;
            set;
        }

        string _place;
        public string Place
        {
            get
            {
                return _place;
            }
            set
            {
                _place = value;
                HasPowerOutlet = kthPlacesDataFetcher.isRoomHavingPowerOutlet(_place);
                OnPropertyChanged("Place");
            }
        }

        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        string _information;
        public string Information
        {
            get
            {
                return _information;
            }
            set
            {
                _information = value;
                OnPropertyChanged("Information");
            }
        }

        string _hasPowerOutlet;
        public string HasPowerOutlet
        {
            get
            {
                return _hasPowerOutlet;
            }
            set
            {
                _hasPowerOutlet = value;
                OnPropertyChanged("HasPowerOutlet");
            }
        }

        string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }
    }
}
