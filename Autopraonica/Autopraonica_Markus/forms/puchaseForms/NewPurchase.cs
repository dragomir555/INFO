using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Autopraonica_Markus.forms.puchaseForms
{
    public partial class NewPurchase : Form
    {
        public NewPurchase()
        {
            InitializeComponent();
        }

        private void newItemT_Click(object sender, EventArgs e)
        {
            Item item = new Item();        
            if (DialogResult.OK == item.ShowDialog())
            {





            }
            else
            {
                Debug.WriteLine("Dialog result don't OK");
            }
        }
    }
}
