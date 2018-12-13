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
    public partial class uclUsluge : UserControl
    {
        private static uclUsluge instance;

        public static uclUsluge Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclUsluge();
                }
                return instance;
            }
        }

        public uclUsluge()
        {
            InitializeComponent();
        }
    }
}
