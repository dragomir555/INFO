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
        private System.Windows.Forms.ErrorProvider errName = new System.Windows.Forms.ErrorProvider();
        private System.Windows.Forms.ErrorProvider errPrice = new System.Windows.Forms.ErrorProvider();
        // public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public NewPricelistItem()
        {
            InitializeComponent();
            //fillComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Id = ((pricelistitemname)cbPricelistItemNames.SelectedItem).Id;
            if (ValidateChildren(ValidationConstraints.Enabled))
            { 
            Name = tbName.Text.Trim();
            Price = decimal.Parse(tbPrice.Text);
            this.DialogResult = DialogResult.OK;
            }
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                e.Cancel = true;
                tbName.Focus();
                errName.SetError(tbName, "Niste unijeli naziv.");
            }
            else
            {
                errName.SetError(tbName, null);
            }
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

        private void CheckPressedKey(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                button2_Click(sender, e);
                e.Handled = true;
            }
        }

        private void CheckPressedKey2(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                button2_Click(sender, e);
                e.Handled = true;
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDecimal(sender, e);
            CheckPressedKey2(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
