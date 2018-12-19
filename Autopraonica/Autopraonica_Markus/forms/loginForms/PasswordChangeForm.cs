using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.Model.Entities;
using Autopraonica_Markus.services;

namespace Autopraonica_Markus.forms
{
    public partial class PasswordChangeForm : Form
    {
        private employee employee;
        private MainForm mainForm;

        public PasswordChangeForm(employee employee, MainForm mainForm)
        {
            InitializeComponent();
            this.employee = employee;
            this.mainForm = mainForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string currentPassword = tbCurrentPassword.Text;
            string newPassword = tbNewPassword.Text;
            string newPasswordConfirm = tbNewPasswordConfirm.Text;

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                MessageBox.Show("Niste unijeli trenutnu lozinku.", "Upozorenje");
                tbCurrentPassword.Focus();
            }
            else if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Niste unijeli novu lozinku.", "Upozorenje");
                tbNewPassword.Focus();
            }
            else if (string.IsNullOrWhiteSpace(newPasswordConfirm))
            {
                MessageBox.Show("Niste potvrdili novu lozinku.", "Upozorenje");
                tbNewPasswordConfirm.Focus();
            }
            else if (!newPassword.Equals(newPasswordConfirm))
            {
                MessageBox.Show("Dva unosa nove lozinke se ne podudaraju", "Upozorenje");
                tbNewPassword.Clear();
                tbNewPasswordConfirm.Clear();
                tbNewPassword.Focus();
            }
            else if (newPassword.Length < 8)
            {
                MessageBox.Show("Unesena lozinka mora imati minimum 8 karaktera.", "Upozorenje");
                tbNewPassword.Clear();
                tbNewPasswordConfirm.Clear();
                tbNewPassword.Focus();
            }
            else
            {
                employment employment = null;
                var emps = employee.employments;
                foreach(var emp in emps)
                {
                    if(emp.DateTo == null)
                    {
                        employment = emp;
                    }
                }
                string salt = employment.Salt;
                string currentPasswordHash1 = employment.HashPassword;
                string currentPasswordHash2 = PasswordService.GetPasswordHash(salt, currentPassword);
                if (currentPasswordHash2.Equals(currentPasswordHash1))
                {
                    string newSalt = PasswordService.GenerateSalt();
                    string newPasswordHash = PasswordService.GetPasswordHash(newSalt, newPassword);
                    using(MarkusDb context = new MarkusDb())
                    {
                        context.employments.Attach(employment);
                        employment.Salt = newSalt;
                        employment.HashPassword = newPasswordHash;
                        employment.FirstLogin = 0;
                        context.SaveChanges();
                    }
                    mainForm.SetEmployee(employee);
                    mainForm.Visible = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Pogrešno ste unijeli trenutnu lozinku.", "Upozorenje");
                    tbCurrentPassword.Clear();
                    tbNewPassword.Clear();
                    tbNewPasswordConfirm.Clear();
                    tbCurrentPassword.Focus();
                }
            }
        }
    }
}
