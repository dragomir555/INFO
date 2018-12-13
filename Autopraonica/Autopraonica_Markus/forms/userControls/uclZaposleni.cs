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
    public partial class uclZaposleni : UserControl
    {
        private static uclZaposleni instance;

        public static uclZaposleni Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclZaposleni();
                }
                return instance;
            }
        }
        public uclZaposleni()
        {
            InitializeComponent();
        }
    }
}
