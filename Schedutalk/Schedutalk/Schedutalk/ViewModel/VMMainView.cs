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
        public string Greeting {
            get; private set;
        }
        public string Name {
            get; set;
        }
        public ICommand Test
        {
            get; set;
        }

        public VMMainView()
        {
            Debug.WriteLine("Debug line");
            Name = "Hello world";
            Greeting = "";
            Test = SayHello;
        }

        public ICommand SayHello { 
	            get {
                    return new Command(() =>
                    {
                        Debug.WriteLine("Command executed");
                        Greeting = $"Hello {Name}";
                    });   
                } 
            }
        }
}
