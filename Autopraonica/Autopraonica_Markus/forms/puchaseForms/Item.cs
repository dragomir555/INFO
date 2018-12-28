using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.puchaseForms
{
    public partial class Item : Form
    {
        Decimal Count { get; set; }
        Decimal Prize { get; set; }
        int IdItem { get; set;}

        public Item()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            NewItem newItem = new NewItem();
            if (DialogResult.OK == newItem.ShowDialog())
            {




            }

        }
    }
}
