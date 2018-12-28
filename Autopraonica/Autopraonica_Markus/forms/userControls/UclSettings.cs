using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class UclSettings : UserControl
    {
        private static UclSettings instance;

        public static UclSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UclSettings();
                }
                return instance;
            }
        }

        public UclSettings()
        {
            InitializeComponent();
            tbName.Text = Properties.Settings.Default.Name;
            tbUID.Text = Properties.Settings.Default.UID;
            tbAddress.Text = Properties.Settings.Default.Address;
            tbPhoneNumber.Text = Properties.Settings.Default.PhoneNumber;
            tbAccountNumber.Text = Properties.Settings.Default.AccountNumber;
            tbEmail.Text = Properties.Settings.Default.Email;
            tbPassword.Text = Properties.Settings.Default.Password;
        }
    }
}
