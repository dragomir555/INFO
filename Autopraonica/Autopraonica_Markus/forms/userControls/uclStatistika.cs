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
    public partial class uclStatistika : UserControl
    {
        private static uclStatistika instance;

        public static uclStatistika Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclStatistika();
                }
                return instance;
            }
        }
        public uclStatistika()
        {
            InitializeComponent();
        }
    }
}
