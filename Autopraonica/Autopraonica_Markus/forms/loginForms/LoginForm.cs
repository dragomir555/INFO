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
    public partial class LoginForm : Form
    {
        private int numberOfFailedLogin;
        private MainForm mainForm;

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();
            numberOfFailedLogin = 0;
            this.mainForm = mainForm;
            tbPassword.Text = "admin123";
            tbUsername.Text = "nikola.nikolic";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if(string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Niste unijeli korisničko ime.", "Upozorenje");
                tbUsername.Focus();
            }
            else if(string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Niste unijeli lozinku.", "Upozorenje");
                tbPassword.Focus();
            }
            else
            {
                using(MarkusDb context = new MarkusDb())
                {
                    var employment = (from c in context.employments where username.Equals(c.UserName) select c).ToList();
                    if(employment == null)
                    {
                        MessageBox.Show("Ne postoji uneseno korisničko ime.", "Upozorenje");
                        tbUsername.Clear();
                        tbPassword.Clear();
                        tbUsername.Focus();
                    }
                    else
                    {
                        if (((employment)employment[0]).FirstLogin == 1)
                        {
                            PasswordChangeForm pcf = new PasswordChangeForm(employment[0], mainForm);
                            pcf.Show();
                            this.Close();
                        }
                        else
                        {
                            string salt = ((employment)employment[0]).Salt;
                            string passwordHash = PasswordService.GetPasswordHash(salt, password);
                            if (passwordHash.Equals(((employment)employment[0]).HashPassword))
                            {
                                employee employee = ((employment)employment[0]).employee;
                                var emp = new employeerecord()
                                {
                                    Employee_Id = employee.Id,
                                    LoginTime = DateTime.Now,
                                    LogoutTime = null
                                };
                                employee.employeerecords.Add(emp);
                                mainForm.SetEmployee(employee);
                                mainForm.ChangeAllowShowDisplay();
                                this.Close();
                            }
                            else
                            {
                                numberOfFailedLogin++;
                                if (numberOfFailedLogin == 3)
                                {
                                    string mail = ((employment)employment[0]).employee.E_mail;
                                    // Treba dodati slanje maila
                                    MessageBox.Show("Na vaš e-mail je poslata poruka sa vašom novom lozinkom.", "Obavještenje");
                                    PasswordChangeForm pcf = new PasswordChangeForm(employment[0], mainForm);
                                    pcf.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Niste unijeli odgovarajuću lozinku.", "Upozorenje");
                                    tbPassword.Clear();
                                    tbPassword.Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.ChangeAllowShowDisplay();
            mainForm.Close();
        }
    }
}
