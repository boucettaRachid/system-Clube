using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Abdalli_multisport
{
    class ElipseControl : Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int ntopRect,
            int nRightRect,
            int nbottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        private Control _cntrl;
        private int _CornerRadius;

        public Control TargetControl
        {
            get { return _cntrl; }
            set 
            {
                _cntrl = value;
                _cntrl.SizeChanged += (sender, eventArgs) => _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            
            }
        }

        public int ConrnerRadius
        {
            get { return _CornerRadius; }
            set 
            {
                _CornerRadius = value;
                if(_cntrl != null)
                    _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            }
        }
    }
}
