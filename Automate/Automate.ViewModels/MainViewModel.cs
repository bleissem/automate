using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            this.MousMove = "Hello Automate";
       }


        ~MainViewModel()
        {
        }


        private string _MouseMove;
        public string MousMove
        {
            get
            {
                return _MouseMove;
            }
            set
            {
                _MouseMove = value;
                base.OnPropertyChanged(() => MousMove);
            }
        }
    }
}
