using Automate.Recorder;
using Gma.System.MouseKeyHook;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Common.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            this.MousMove = "Hello Automate";
            this.m_KeyboardRecorder = new KeyboardRecorder();
            this.m_MouseRecorder = new MouseRecorder();
                       
        }

        private KeyboardRecorder m_KeyboardRecorder;
        private MouseRecorder m_MouseRecorder;


        ~MainViewModel()
        {
            m_KeyboardRecorder.Dispose();
            m_KeyboardRecorder = null;
          
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
