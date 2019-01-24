using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.settingsForms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            SetValues();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Name = tbName.Text;
            Properties.Settings.Default.UID = tbUID.Text;
            Properties.Settings.Default.Address = tbAddress.Text;
            Properties.Settings.Default.PhoneNumber = tbPhoneNumber.Text;
            Properties.Settings.Default.AccountNumber = tbAccountNumber.Text;
            Properties.Settings.Default.Email = tbEmail.Text;
            Properties.Settings.Default.Password = tbPassword.Text;
            Properties.Settings.Default.Save();
            btnSave.Enabled = false;
            this.Close();
        }

        public void SetValues()
        {
            tbName.Text = Properties.Settings.Default.Name;
            tbUID.Text = Properties.Settings.Default.UID;
            tbAddress.Text = Properties.Settings.Default.Address;
            tbPhoneNumber.Text = Properties.Settings.Default.PhoneNumber;
            tbAccountNumber.Text = Properties.Settings.Default.AccountNumber;
            tbEmail.Text = Properties.Settings.Default.Email;
            tbPassword.Text = Properties.Settings.Default.Password;
            btnSave.Enabled = false;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                e.Cancel = true;
                //tbName.Focus();
                errorProvider.SetError(tbName, "Niste unijeli naziv autopraonice.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbName, null);
            }
        }

        private void tbUID_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbUID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUID.Text))
            {
                e.Cancel = true;
                //tbUID.Focus();
                errorProvider.SetError(tbUID, "Niste unijeli JIB.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbUID, null);
            }
        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                e.Cancel = true;
                //tbAddress.Focus();
                errorProvider.SetError(tbAddress, "Niste unijeli adresu.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbAddress, null);
            }
        }

        private void tbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhoneNumber.Text))
            {
                e.Cancel = true;
                //tbPhoneNumber.Focus();
                errorProvider.SetError(tbPhoneNumber, "Niste unijeli broj telefona.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPhoneNumber, null);
            }
        }

        private void tbAccountNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAccountNumber.Text))
            {
                e.Cancel = true;
                //tbAccountNumber.Focus();
                errorProvider.SetError(tbAccountNumber, "Niste unijeli broj računa.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbAccountNumber, null);
            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                e.Cancel = true;
                //tbEmail.Focus();
                errorProvider.SetError(tbEmail, "Niste unijeli e-mail adresu.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbEmail, null);
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                e.Cancel = true;
                //tbPassword.Focus();
                errorProvider.SetError(tbPassword, "Niste unijeli lozinku.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPassword, null);
            }
        }

        private void AllowAlphaNumerical(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void AllowDigits(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowAlphaNumerical(sender, e);
        }

        private void tbUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDigits(sender, e);
        }

        private void tbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowAlphaNumerical(sender, e);
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDigits(sender, e);
        }

        private void tbAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDigits(sender, e);
        }
    }
}
