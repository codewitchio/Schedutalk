using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedutalk.Model
{
    public class MEvent : ViewModel.VMBase
    {
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
