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
        public NewClientForm()
        {
            InitializeComponent();
            FillComboCity();
        }

        private void FillComboCity()
        {
            using (MarkusDb context = new MarkusDb())
            {
               List<city> gradovi= (from c in context.cities select c).ToList();
               // cmbCityList.Items.AddRange(gradovi);
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
                this.Close();
            }
            else
            {
                NameClient = txtName.Text;
                UID = txtUID.Text;
                Address = txtAddress.Text;
                IdCity =((city)cmbCityList.SelectedItem).Id;
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void cmbCityList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
