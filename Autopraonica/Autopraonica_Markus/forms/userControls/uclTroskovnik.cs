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
    public partial class uclTroskovnik : UserControl
    {

        private static uclTroskovnik instance;

        public static uclTroskovnik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclTroskovnik();
                }
                return instance;
            }
        }
        public uclTroskovnik()
        {
            InitializeComponent();
        }
    }
}
