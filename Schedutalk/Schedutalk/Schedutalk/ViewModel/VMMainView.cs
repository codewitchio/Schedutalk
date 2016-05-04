using System;
using System.Collections.Generic;
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
        public Model.Human Human
        {
            get; set;
        }

        private string greeting;

        public string Greeting
        {
            get
            {
                return greeting;
            }
            private set
            {

                greeting = value;
                OnPropertyChanged("Greeting");
            }
        }

        public VMMainView()
        {
            Human = new Model.Human();
            Human.Name = "Hello world";
        }

        public ICommand SayHello { 
	            get {
                    return new Command(() =>
                    {
                        Greeting = $"Hello {Human.Name}";
                    });   
                } 
            }
        }
}
