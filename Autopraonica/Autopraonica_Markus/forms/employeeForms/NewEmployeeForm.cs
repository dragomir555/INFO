using Autopraonica_Markus.Model.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.forms.userControls;
using System.Text.RegularExpressions;

namespace Autopraonica_Markus.forms.employeeForms
{
    public partial class NewEmployeeForm : Form
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PID { get; set; }
        public String E_mail { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }

        public NewEmployeeForm()
        {
            InitializeComponent();
        }

        public void fillTextBoxes() {
            tbFirstName.Text = FirstName;
            tbLastName.Text = LastName;
            tbAddress.Text = Address;
            tbPhoneNumber.Text = PhoneNumber;
            tbEMail.Text = E_mail;
            tbPID.Text = PID;
        }

        public void hideUnnecessaryItems() {
            tbEMail.Hide();
            lblEmail.Hide();
        }

     
        private void btnAddEmployee_Click_1(object sender, EventArgs e)
        {
           
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                using (MarkusDb ctx = new MarkusDb())
                {
                    
                    FirstName = tbFirstName.Text;
                    LastName = tbLastName.Text;
                    E_mail = tbEMail.Text;
                    Address = tbAddress.Text;
                    PhoneNumber = tbPhoneNumber.Text;
                    PID = tbPID.Text;
                   

                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            var regex = @"^[^0-9]+$";
            var match = Regex.Match(tbFirstName.Text, regex, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(tbFirstName.Text) || !match.Success)
            {
                e.Cancel = true;
                errorProvider.SetError(tbFirstName, "Molimo da unesete ispravno ime !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbFirstName, null);
            }
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            var regex = @"^[^0-9]+$";
            var match = Regex.Match(tbLastName.Text, regex, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(tbLastName.Text) || !match.Success)
            {
                e.Cancel = true;
                errorProvider.SetError(tbLastName, "Molimo da unesete ispravno prezime !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbLastName, null);
            }

        }

        private void tbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tbAddress, "Molimo da unesete ispravno adresu !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbAddress, null);
            }


        }

        private void tbPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            var regex = @"^[0-9]*$";
            var match = Regex.Match(tbPhoneNumber.Text, regex, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(tbPhoneNumber.Text) || !match.Success)
            {
                e.Cancel = true;
                errorProvider.SetError(tbPhoneNumber, "Molimo da unesete ispravno broj telefona !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPhoneNumber, null);
            }


        }

        private void tbEMail_Validating(object sender, CancelEventArgs e)
        {
            var regex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            var match = Regex.Match(tbEMail.Text, regex, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(tbEMail.Text) || !match.Success)
            {
                e.Cancel = true;
                errorProvider.SetError(tbEMail, "Molimo da unesete ispravno e-mail !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbEMail, null);
            }
        }

        private void tbPID_Validating(object sender, CancelEventArgs e)
        {
            var regex = @"[0-9]+";
            var match = Regex.Match(tbPID.Text, regex, RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(tbPID.Text) || (tbPID.Text.Length!=13) || (!match.Success))
            {
                e.Cancel = true;
                errorProvider.SetError(tbPID, "Molimo da unesete ispravno JMB !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPID, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
