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
    public partial class NewPricelistItem : Form
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public NewPricelistItem()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Id = ((pricelistitemname)cbPricelistItemNames.SelectedItem).Id;
            Price = decimal.Parse(tbPrice.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void fillComboBox()
        {
            using (MarkusDb context = new MarkusDb())
            {
                var pricelistItemNames = context.pricelistitemnames.ToList();
                cbPricelistItemNames.DataSource = pricelistItemNames;
                cbPricelistItemNames.DisplayMember = "Name";
                cbPricelistItemNames.ValueMember = "Id";
            }
        }
    }
}
