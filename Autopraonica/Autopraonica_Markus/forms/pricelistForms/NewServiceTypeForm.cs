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
    public partial class NewServiceTypeForm : Form
    {
        private System.Windows.Forms.ErrorProvider errName = new System.Windows.Forms.ErrorProvider();

        public string Name { get; set; }

        public NewServiceTypeForm()
        {
            InitializeComponent();
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

        private void CheckPressedKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAddServiceType_Click(sender, e);
                e.Handled = true;
            } else if(e.KeyChar == (char)Keys.Escape)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnAddServiceType_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Name = tbName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
