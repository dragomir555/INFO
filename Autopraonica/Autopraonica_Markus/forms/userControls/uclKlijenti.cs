using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclKlijenti : UserControl
    {
        private static uclKlijenti instance;

        public static uclKlijenti Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclKlijenti();
                }
                return instance;
            }
        }
        public uclKlijenti()
        {
            InitializeComponent();
        }
    }
}
