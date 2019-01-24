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
using System.Net.Mail;
using System.Net;
using System.Threading;

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

            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                using(MarkusDb context = new MarkusDb())
                {
                    var employment = (from c in context.employments
                                      where username.Equals(c.UserName) &&
                                      c.DateTo == null
                                      select c).ToList();
                    if(employment.Count == 0)
                    {
                        tbUsername.Clear();
                        tbPassword.Clear();
                        //tbUsername.Focus();
                        errorProvider.SetError(tbUsername, "Ne postoji uneseno korisničko ime.");
                    }
                    else
                    {
                        if (((employment)employment[0]).FirstLogin == 1)
                        {
                            PasswordChangeForm pcf = new PasswordChangeForm(employment[0], mainForm, 0);
                            pcf.Show();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            employee employee = ((employment)employment[0]).employee;
                            var emp = new employeerecord()
                            {
                                Employee_Id = employee.Id,
                                LoginTime = DateTime.Now,
                                LogoutTime = null
                            };
                            employee.employeerecords.Add(emp);
                            context.SaveChanges();
                            mainForm.SetEmployee(employee);
                            var managers = (from c in context.managers select c).ToList();
                            mainForm.SetButtonsVisibility(false);
                            foreach (manager m in managers)
                            {
                                if (employee.Id == m.Employee_Id)
                                {
                                    mainForm.SetButtonsVisibility(true);
                                }
                            }
                            string salt = ((employment)employment[0]).Salt;
                            string passwordHash = UserService.GetPasswordHash(salt, password);
                            if (passwordHash.Equals(((employment)employment[0]).HashPassword))
                            {
                                mainForm.StartEmployeeLogoutUpdate();
                                mainForm.SetUclUslugeFirst();
                                mainForm.ChangeAllowShowDisplay();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                numberOfFailedLogin++;
                                if (numberOfFailedLogin == 3)
                                {
                                    StartMailDelivery(employment[0]);

                                    MessageBox.Show("Na vaš e-mail je poslata poruka sa vašom novom lozinkom.", "Obavještenje");
                                    PasswordChangeForm pcf = new PasswordChangeForm(employment[0], mainForm, 0);
                                    pcf.Show();
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    tbPassword.Clear();
                                    //tbPassword.Focus();
                                    errorProvider.SetError(tbPassword, "Niste unijeli odgovarajuću lozinku.");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.None)
            {
                mainForm.WindowState = FormWindowState.Minimized;
                mainForm.ChangeAllowShowDisplay();
                mainForm.Close();
            }
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                e.Cancel = true;
                //tbUsername.Focus();
                errorProvider.SetError(tbUsername, "Niste unijeli korisničko ime.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbUsername, null);
            }
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

        private void StartMailDelivery(employment employment)
        {
            Thread mailDeliveryThread = new Thread(() =>
            {
                using(MarkusDb context = new MarkusDb())
                {
                    string mail = employment.employee.E_mail;
                    string newSalt = UserService.GenerateSalt();
                    string newPassword = UserService.GeneratePassword();
                    string newHash = UserService.GetPasswordHash(newSalt, newPassword);
                    context.employments.Attach(employment);
                    employment.Salt = newSalt;
                    employment.HashPassword = newHash;
                    employment.FirstLogin = 1;
                    context.SaveChanges();

                    NetworkCredential login = new NetworkCredential(Properties.Settings.Default.Email,
                        Properties.Settings.Default.Password);
                    MailMessage mailMessage = new MailMessage(Properties.Settings.Default.Email, mail);
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = login;
                    client.Host = "smtp.gmail.com";
                    mailMessage.Subject = "Nova lozinka";
                    mailMessage.Body = "Vaša nova lozinka je: " + newPassword;
                    client.Send(mailMessage);
                }
            });
            mailDeliveryThread.Start();
        }
    }
}
