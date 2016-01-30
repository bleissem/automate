using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Recorder
{
    public class KeyboardRecorder: IDisposable
    {

        #region constructor

        public KeyboardRecorder()
        {
            this.m_Hook = Hook.GlobalEvents();
            m_Hook.KeyPress += M_Hook_KeyPress;
        }

        #endregion

        ~KeyboardRecorder()
        {
            this.Dispose(false);
            GC.SuppressFinalize(this);
        }
         

        private IKeyboardMouseEvents m_Hook;

        private void M_Hook_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (null != m_Hook)
            {
                m_Hook.KeyPress -= M_Hook_KeyPress;
                m_Hook = null;
            }
        }

        private void Dispose(bool disposing)
        {

        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
