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
    public partial class uclIzdavanjeRacuna : UserControl
    {
        private static uclIzdavanjeRacuna instance;

        public static uclIzdavanjeRacuna Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclIzdavanjeRacuna();
                }
                return instance;
            }
        }
        public uclIzdavanjeRacuna()
        {
            InitializeComponent();
        }
    }
}
