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

        private void txtUID_TextChanged(object sender, EventArgs e)
        {

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

        private void txtAddress_TextChanged(object sender, EventArgs e)
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
                            Name = newCity.Name,
                            PostCode = newCity.PostCode
                        };

                    }
                    catch (Exception ex) {
                        MessageBox.Show("Greska prilikom dodavanja grada"+ex, "Error");
                    }


                }                
            }
        }
    }
}
