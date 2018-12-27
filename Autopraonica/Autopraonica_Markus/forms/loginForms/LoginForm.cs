﻿using System;
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

            /*(string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Niste unijeli korisničko ime.", "Upozorenje");
                tbUsername.Focus();
            }
            else if(string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Niste unijeli lozinku.", "Upozorenje");
                tbPassword.Focus();
            }*/
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
                        //MessageBox.Show("Ne postoji uneseno korisničko ime.", "Upozorenje");
                        tbUsername.Clear();
                        tbPassword.Clear();
                        tbUsername.Focus();
                        errorProvider.SetError(tbUsername, "Ne postoji uneseno korisničko ime.");
                    }
                    else
                    {
                        if (((employment)employment[0]).FirstLogin == 1)
                        {
                            PasswordChangeForm pcf = new PasswordChangeForm(employment[0], mainForm, 0);
                            pcf.Show();
                            this.Close();
                        }
                        else
                        {
                            string salt = ((employment)employment[0]).Salt;
                            string passwordHash = UserService.GetPasswordHash(salt, password);
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
                                mainForm.ChangeAllowShowDisplay();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                numberOfFailedLogin++;
                                if (numberOfFailedLogin == 3)
                                {
                                    string mail = ((employment)employment[0]).employee.E_mail;
                                    // Treba dodati slanje maila
                                    NetworkCredential login = new NetworkCredential("autopraonica.markus@gmail.com", "admin!23");
                                    MailMessage mailMessage = new MailMessage("autopraonica.markus@gmail.com", "dragomir555@hotmail.rs");
                                    SmtpClient client = new SmtpClient();
                                    client.Port = 587;
                                    client.EnableSsl = true;
                                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    client.UseDefaultCredentials = false;
                                    client.Credentials = login;
                                    client.Host = "smtp.gmail.com";
                                    mailMessage.Subject = "Test";
                                    mailMessage.Body = "Testiram slanje maila iz aplikacije.";
                                    client.Send(mailMessage);

                                    MessageBox.Show("Na vaš e-mail je poslata poruka sa vašom novom lozinkom.", "Obavještenje");
                                    PasswordChangeForm pcf = new PasswordChangeForm(employment[0], mainForm, 0);
                                    pcf.Show();
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //MessageBox.Show("Niste unijeli odgovarajuću lozinku.", "Upozorenje");
                                    tbPassword.Clear();
                                    tbPassword.Focus();
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
                tbUsername.Focus();
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
                tbPassword.Focus();
                errorProvider.SetError(tbPassword, "Niste unijeli lozinku.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPassword, null);
            }
        }
    }
}
