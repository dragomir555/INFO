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
    public partial class UpdatePricelistItem : Form
    {
        private System.Windows.Forms.ErrorProvider errPrice = new System.Windows.Forms.ErrorProvider();
        public decimal Price { get; set; }

        public UpdatePricelistItem(int pricelistItem_id)
        {
            InitializeComponent();
            fillFields(pricelistItem_id);
        }

        private void fillFields(int id)
        {
            using (MarkusDb context = new MarkusDb())
            {
                var pricelistItem = context.pricelistitems.Find(id);
                var pricelistItemName = context.pricelistitemnames.Find(pricelistItem.PricelistItemName_Id);
                lblName.Text = pricelistItemName.Name;
                tbPrice.Text = pricelistItem.Price.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Price = decimal.Parse(tbPrice.Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                e.Cancel = true;
                tbPrice.Focus();
                errPrice.SetError(tbPrice, "Niste unijeli cijenu.");
            }
            else
            {
                errPrice.SetError(tbPrice, null);
            }
        }

        private void AllowDecimal(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDecimal(sender, e);
        }
    }
}
