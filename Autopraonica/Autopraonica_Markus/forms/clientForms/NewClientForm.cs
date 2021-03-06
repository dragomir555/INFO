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
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Autopraonica_Markus.forms.clientForms
{
   
    public partial class NewClientForm : Form
    {
        public String NameClient { get; set; }
        public String UID { get; set; }
        public String Address { get; set; }
        public int IdCity { get; set; }
        public DateTime? ContractTo { get; set; }
        public NewClientForm()
        {
            InitializeComponent();
            dtpUgovorDo.Hide();
            FillComboCity();
            dtpUgovorDo.MinDate = DateTime.Now.AddMonths(1);
        }


        private void FillComboCity()
        {
            using (MarkusDb context = new MarkusDb())
            {
               List<city> gradovi= (from c in context.cities select c).ToList();
                cmbCityList.DataSource = gradovi;
                cmbCityList.DisplayMember = "Name";
                cmbCityList.ValueMember = "Id";
                
            }
            

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                //Debug.WriteLine("Dragomir");
            }
            else
            {
                NameClient = txtName.Text;
                UID = txtUID.Text;
                Address = txtAddress.Text;
                IdCity =((city)cmbCityList.SelectedItem).Id;
                if (cbUgovorNa.Checked == true)
                {
                    ContractTo = dtpUgovorDo.Value.Date;
                }
                else
                {
                    ContractTo = null;
                }
                this.DialogResult = DialogResult.OK;
               // this.Close();
            }
            
        }

        private void cbUgovorNa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUgovorNa.Checked == true)
            {
                dtpUgovorDo.Show();
            }
            else
            {
                dtpUgovorDo.Hide();
            }
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            NewCityForm newCity = new NewCityForm();
            if (DialogResult.OK == newCity.ShowDialog()) {
            using(MarkusDb context=new MarkusDb())
                {
                    try
                    {
                        var c = new city()
                        {
                            Name = newCity.NameCity,
                            PostCode = newCity.PostCode
                        };
                        context.cities.Add(c);
                        context.SaveChanges();
                        FillComboCity();
                        MessageBox.Show($"Uspješno dodano mjesto {c.Name} sa poštanskim brojem {c.PostCode}"  ,"Novo mjesto");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Greska prilikom dodavanja grada"+ex, "Error");
                    }


                }
            }
            else
            {
                Debug.WriteLine("Nece");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProviderClient.SetError(txtName, "Molimo vas da unesete ispravan naziv klijenta!");
            }
            else
            {
                e.Cancel = false;
                errorProviderClient.SetError(txtName, null);
            }
        }

        private void txtUID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUID.Text)) {
                e.Cancel = true;
                errorProviderClient.SetError(txtUID, "Molimo vas da unesete JIB!");
            }
            else
            {
                Regex pattern = new Regex("[0-9]{13}");
                if (!pattern.IsMatch(txtUID.Text) || txtUID.Text.Length>13)
                {
                    e.Cancel = true;
                    errorProviderClient.SetError(txtUID, "Molimo vas da unesete ispravan JIB!");
                }
                else
                {
                    e.Cancel = false;
                    errorProviderClient.SetError(txtUID, null);
                }

            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                errorProviderClient.SetError(txtAddress, "Molimo vas da unesete adresu klijenta !");
            }
            else
            {
                e.Cancel = false;
                errorProviderClient.SetError(txtAddress, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void NewClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.DialogResult = DialogResult.Cancel;
        }

        private void NewClientForm_Load(object sender, EventArgs e)
        {
            txtName.Text = NameClient;
            txtAddress.Text = Address;
            txtUID.Text = UID;
            if ((int)this.Tag == 1) {
            cbUgovorNa.Hide();
            dtpUgovorDo.Hide();

                FillComboCity();
                cmbCityList.SelectedValue = IdCity;
            }
            
          
            if ((int)this.Tag == 2)
            {
                txtName.Enabled = false;
                txtAddress.Enabled = false;
                txtUID.Enabled = false;
                cmbCityList.Enabled = false;
            }
            
        }
        private void AllowInteger(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
        private void txtUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowInteger(sender, e);
        }

        private void cmbCityList_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCityList.SelectedItem == null)
            {
                e.Cancel = true;
                errorProviderClient.SetError(cmbCityList, "Izaberite grad");
            }
            else
            {
                e.Cancel = false;
                errorProviderClient.SetError(cmbCityList, null);
            }
        }
    }
}
