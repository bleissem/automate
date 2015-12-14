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
            this.m_Hook = Hook.GlobalEvents();
            m_Hook.KeyPress += M_Hook_KeyPress;
            m_Hook.MouseMoveExt += M_Hook_MouseMoveExt;
            m_Hook.MouseDownExt += M_Hook_MouseDownExt;
            m_Hook.MouseDown += M_Hook_MouseDown;
        }

        private void M_Hook_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.MousMove = "Maus:" + e.Location;
            if (e.Clicks > 0)
            {
                this.MousMove += " Button: " + e.Button.ToString();
            }
        }

        ~MainViewModel()
        {
            m_Hook.KeyPress -= M_Hook_KeyPress;
            m_Hook.MouseMoveExt -= M_Hook_MouseMoveExt;
            m_Hook.MouseDownExt -= M_Hook_MouseDownExt;
            m_Hook.Dispose();
            m_Hook = null;
        }


        private void M_Hook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            
        }

        private void M_Hook_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            this.MousMove = "Maus:" + e.Location;
            if (e.Clicks>0)
            {
                this.MousMove += " Button: " + e.Button.ToString();
            }
        }

        private void M_Hook_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
        }


        private IKeyboardMouseEvents m_Hook;

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
