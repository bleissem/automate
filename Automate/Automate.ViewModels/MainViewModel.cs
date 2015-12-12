using Automate.Wrapper;
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
            m_Hook = new Hook();
            m_Hook.RegisterMouse((msg) =>
            {
                this.MousMove = msg;
            });
        }


        ~MainViewModel()
        {
            m_Hook.Dispose();
        }

        private Hook m_Hook;

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
