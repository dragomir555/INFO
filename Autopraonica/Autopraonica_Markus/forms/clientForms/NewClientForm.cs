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
            //String is empty
            if (string.IsNullOrWhiteSpace(txtAddress.Text) && string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtUID.Text))
            {
                MessageBox.Show("Niste popunili sva polja", "Greska");
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
            }
            
        }

        private void cmbCityList_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
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
                txtUID.Focus();
                errorProviderClient.SetError(txtUID, "Molimo vas da unesete JIB!");
            }
            else
            {
                Regex pattern = new Regex("[0-9]{13}");
                if (!pattern.IsMatch(txtUID.Text))
                {
                    e.Cancel = true;
                    txtUID.Focus();
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
                txtAddress.Focus();
                errorProviderClient.SetError(txtAddress, "Molimo vas da unesete adresu klijenta !");
            }
            else
            {
                e.Cancel = false;
                errorProviderClient.SetError(txtAddress, null);
            }
        }
    }
}
