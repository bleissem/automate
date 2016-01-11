using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Recorder
{
    public class MouseRecorder: IDisposable
    {
        #region constructor

        public MouseRecorder()
        {
            this.m_Hook = Hook.GlobalEvents();
            m_Hook.MouseMoveExt += M_Hook_MouseMoveExt;
            m_Hook.MouseDownExt += M_Hook_MouseDownExt;
            m_Hook.MouseDown += M_Hook_MouseDown;
        }

        #endregion


        private IKeyboardMouseEvents m_Hook;

        private void Dispose(bool disposing)
        {
            if (null != m_Hook)
            {
                m_Hook.MouseMoveExt -= M_Hook_MouseMoveExt;
                m_Hook.MouseDownExt -= M_Hook_MouseDownExt;
                m_Hook.MouseDown -= M_Hook_MouseDown;
                m_Hook = null;
            }
        }
        public void Dispose()
        {

        }



        private void M_Hook_MouseDownExt(object sender, MouseEventExtArgs e)
        {

        }

        private void M_Hook_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            
        }


        private void M_Hook_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {           
        }
    }
}
