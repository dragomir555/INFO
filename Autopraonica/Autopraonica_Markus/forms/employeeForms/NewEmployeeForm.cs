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
        public String Password { get; set; }
        private int counter = 0;

        public NewEmployeeForm()
        {
            InitializeComponent();
        }

        public void fillTextBoxes() {
            tbFirstName.Text = FirstName;
            tbLastName.Text = LastName;
            tbAddress.Text = Address;
            tbPhoneNumber.Text = PhoneNumber;
        }

        public void hideUnnecessaryItems() {
            tbPassword.Hide();
            tbEMail.Hide();
            lblPassword.Hide();
            lblEmail.Hide();
        }

        public void changeButtonName()
        {
            btnAddEmployee.Text = "Izmjeni zaposlenog";
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
                    Password = tbPassword.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                e.Cancel = true;
                tbFirstName.Focus();
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
            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                e.Cancel = true;
                tbLastName.Focus();
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
                tbAddress.Focus();
                errorProvider.SetError(tbAddress, "Molimo da unesete ispravno adresu !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbLastName, null);
            }


        }

        private void tbPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhoneNumber.Text))
            {
                e.Cancel = true;
                tbPhoneNumber.Focus();
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
            if (string.IsNullOrWhiteSpace(tbEMail.Text))
            {
                e.Cancel = true;
                tbEMail.Focus();
                errorProvider.SetError(tbEMail, "Molimo da unesete ispravno e-mail !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbEMail, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProvider.SetError(tbPassword, "Molimo da unesete ispravno lozinku !");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPassword, null);
            }

        }
    }
}
