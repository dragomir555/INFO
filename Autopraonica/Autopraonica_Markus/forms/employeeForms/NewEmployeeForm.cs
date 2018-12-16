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

        public NewEmployeeForm()
        {
            InitializeComponent();
        }

        public Boolean checkFields()
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text) && string.IsNullOrWhiteSpace(tbFirstName.Text) &&
                string.IsNullOrWhiteSpace(tbLastName.Text) &&
                string.IsNullOrWhiteSpace(tbEMail.Text) && string.IsNullOrWhiteSpace(tbPhoneNumber.Text)
                && string.IsNullOrWhiteSpace(tbPassword.Text))
                return false;
            return true;
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

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
        
            using (MarkusDb ctx = new MarkusDb())
            {
                if(!checkFields())
                {
                    MessageBox.Show("Niste popunili sva polja", "Greska");
                }
                else
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
    }
}
