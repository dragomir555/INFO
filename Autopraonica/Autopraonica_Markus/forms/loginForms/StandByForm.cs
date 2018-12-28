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

namespace Autopraonica_Markus.forms.loginForms
{
    public partial class StandByForm : Form
    {
        private employee employee;

        public StandByForm(employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            lblName.Text = employee.FirstName + " " + employee.LastName;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                using (MarkusDb context = new MarkusDb())
                {
                    var employment = (from c in context.employments
                                      where c.Employee_Id == employee.Id &&
                                      c.DateTo == null
                                      select c).ToList()[0];
                    string salt = employment.Salt;
                    string hash = employment.HashPassword;
                    string password = tbPassword.Text;
                    string newHash = UserService.GetPasswordHash(salt, password);
                    if (hash.Equals(newHash))
                    {
                        this.Close();
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void StandByForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProvider.SetError(tbPassword, "Niste unijeli lozinku.");
            }
            else
            {
                using(MarkusDb context = new MarkusDb())
                {
                    var employment = (from c in context.employments where c.Employee_Id == employee.Id &&
                                   c.DateTo == null select c).ToList()[0];
                    string salt = employment.Salt;
                    string hash = employment.HashPassword;
                    string password = tbPassword.Text;
                    string newHash = UserService.GetPasswordHash(salt, password);
                    if(!hash.Equals(newHash))
                    {
                        e.Cancel = true;
                        tbPassword.Focus();
                        errorProvider.SetError(tbPassword, "Niste ispravno unijeli lozinku.");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider.SetError(tbPassword, null);
                    }
                }
            }
        }
    }
}
