using Autopraonica_Markus.Model.Entities;
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
    public partial class DisplayPricelistItemNamesForm : Form
    {
    
        public DisplayPricelistItemNamesForm()
        {
            InitializeComponent();
            fillList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewPricelistItemName nplin = new NewPricelistItemName();
            if (DialogResult.OK == nplin.ShowDialog())
            {
                using (MarkusDb context = new MarkusDb())
                {
                    var pricelistItemName = new pricelistitemname()
                    {
                        Name = nplin.Name
                    };
                    context.pricelistitemnames.Add(pricelistItemName);
                    context.SaveChanges();
                    fillList();
                }
            }
        }

        private void fillList()
        {
            lvPricelistItemNames.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var pricelistItemNames = context.pricelistitemnames;
                foreach(var p in pricelistItemNames)
                {
                    lvPricelistItemNames.Items.Add(p.Name);
                }
            }
        }
    }
}
