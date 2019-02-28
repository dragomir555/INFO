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
        private employment firstEmployment;
        private MainForm mainForm;
        private int caller;

        public PasswordChangeForm(employment firstEmployment, MainForm mainForm, int caller)
        {
            InitializeComponent();
            this.firstEmployment = firstEmployment;
            this.mainForm = mainForm;
            this.caller = caller;
            if(caller == 1)
            {
                linkLblBackToLogin.Visible = false;
                this.Size = new Size(500, 355);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string currentPassword = tbCurrentPassword.Text;
            string newPassword = tbNewPassword.Text;
            string newPasswordConfirm = tbNewPasswordConfirm.Text;
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                using (MarkusDb context = new MarkusDb())
                {
                    var employment = (from c in context.employments
                                         where c.Id == firstEmployment.Id select c).ToList()[0];
                    string salt = employment.Salt;
                    string currentPasswordHash1 = employment.HashPassword;
                    string currentPasswordHash2 = UserService.GetPasswordHash(salt, currentPassword);
                    if (currentPasswordHash2.Equals(currentPasswordHash1))
                    {
                        if (!newPassword.Equals(newPasswordConfirm))
                        {
                            errorProvider.SetError(tbNewPasswordConfirm, "Dva unosa nove lozinke se ne podudaraju.");
                        }
                        else
                        {
                            string newSalt = UserService.GenerateSalt();
                            string newPasswordHash = UserService.GetPasswordHash(newSalt, newPassword);
                            context.employments.Attach(employment);
                            employment.Salt = newSalt;
                            employment.HashPassword = newPasswordHash;
                            employment.FirstLogin = 0;
                            context.SaveChanges();
                            if (caller == 0)
                            {
                                employee employee = employment.employee;
                                var emp = new employeerecord()
                                {
                                    Employee_Id = employee.Id,
                                    LoginTime = DateTime.Now,
                                    LogoutTime = null
                                };
                                employee.employeerecords.Add(emp);
                                context.SaveChanges();
                                var managers = (from c in context.managers select c).ToList();
                                mainForm.SetButtonsVisibility(false);
                                foreach (manager m in managers)
                                {
                                    if (employee.Id == m.Employee_Id)
                                    {
                                        mainForm.SetButtonsVisibility(true);
                                    }
                                }
                                mainForm.StartEmployeeLogoutUpdate();
                                mainForm.SetEmployee(employment.employee);
                                mainForm.SetUclUslugeFirst();
                                mainForm.ChangeAllowShowDisplay();
                            }
                            MessageBox.Show("Lozinka uspješno promjenjena.", "Markus");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        tbCurrentPassword.Clear();
                        tbNewPassword.Clear();
                        tbNewPasswordConfirm.Clear();
                        errorProvider.SetError(tbCurrentPassword, "Pogrešno ste unijeli trenutnu lozinku.");
                    }
                }
            }
        }

        private void PasswordChangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                mainForm.WindowState = FormWindowState.Minimized;
                mainForm.ChangeAllowShowDisplay();
                mainForm.Close();
            }
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tbCurrentPassword, "Niste unijeli trenutnu lozinku.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbCurrentPassword, null);
            }
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tbNewPassword, "Niste unijeli novu lozinku.");
            }
            else if (tbNewPassword.Text.Length < 8)
            {
                e.Cancel = true;
                errorProvider.SetError(tbNewPassword, "Unesena lozinka mora imati minimum 8 karaktera.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbNewPassword, null);
            }
        }

        private void tbNewPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            string newPassword = tbNewPassword.Text;
            string newPasswordConfirm = tbNewPasswordConfirm.Text;

            if (string.IsNullOrWhiteSpace(tbNewPasswordConfirm.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tbNewPasswordConfirm, "Niste potvrdili novu lozinku.");
            }
            else if (newPasswordConfirm.Length < 8)
            {
                e.Cancel = true;
                errorProvider.SetError(tbNewPasswordConfirm, "Unesena lozinka mora imati minimum 8 karaktera.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbNewPasswordConfirm, null);
            }
        }

        private void linkLblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm(mainForm);
            loginForm.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
