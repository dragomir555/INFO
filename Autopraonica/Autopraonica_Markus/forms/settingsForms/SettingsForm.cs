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


    }
}
