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
    public partial class uclCijenovnik : UserControl
    {
        private static uclCijenovnik instance;

        public static uclCijenovnik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclCijenovnik();
                }
                return instance;
            }
        }
        public uclCijenovnik()
        {
            InitializeComponent();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
