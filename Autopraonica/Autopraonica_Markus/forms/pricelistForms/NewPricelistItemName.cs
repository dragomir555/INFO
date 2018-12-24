using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.pricelistForms
{
    public partial class NewPricelistItemName : Form
    {

        public string Name { get; set; }

        public NewPricelistItemName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Name = tbPricelistItemName.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}
