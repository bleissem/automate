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
            this.MousMovePosition = "Hello Automate";
            this.m_KeyboardRecorder = new KeyboardRecorder();
            this.m_MouseRecorder = new MouseRecorder();
            this.m_MouseRecorder.RegisterMousMove((e) =>
            {
                this.MousMovePosition = "x: " + e.X + " y:" + e.Y;
                if (null != OnMouseMove)
                {
                    OnMouseMove(e.X, e.Y);
                }

                this.WindowText = WindowRecorder.GetWindowText(new System.Drawing.Point(e.X, e.Y));
            });                    
        }

        private KeyboardRecorder m_KeyboardRecorder;
        private MouseRecorder m_MouseRecorder;


        ~MainViewModel()
        {
            m_KeyboardRecorder.Dispose();
            m_KeyboardRecorder = null;
          
        }

        public delegate void MouseMove(int x, int y);
        public event MouseMove OnMouseMove;       


        private string m_MousMovePosition;
        public string MousMovePosition
        {
            get
            {
                return m_MousMovePosition;
            }
            set
            {
                m_MousMovePosition = value;
                base.OnPropertyChanged(() => MousMovePosition);
            }
        }


        private string m_WindowText;
        public string WindowText
        {
            get
            {
                return m_WindowText;
            }
            set
            {
                if (value == m_WindowText) return;

                m_WindowText = value;
                base.OnPropertyChanged(() => WindowText);
            }
        }
    }
}
