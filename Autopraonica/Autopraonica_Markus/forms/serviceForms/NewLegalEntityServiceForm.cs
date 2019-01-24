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

namespace Autopraonica_Markus.forms.serviceForms
{
    public partial class NewLegalEntityServiceForm : Form
    {
        public int CarBrand_Id { get; set; }
        public int PricelistItem_Id { get; set; }
        public decimal Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicencePlate { get; set; }
        public int Client_Id { get; set; }

        public NewLegalEntityServiceForm()
        {
            InitializeComponent();
            FillComboBoxes();
            RefreshCarBrandComboBox();
        }

        private void FillComboBoxes()
        {
            using (MarkusDb context = new MarkusDb())
            {
                var clients = (from c1 in context.clients join c2 in context.contracts
                               on c1.Id equals c2.Client_Id where c2.Current == 1
                               select c1).ToList();
                cmbClient.DataSource = clients;
                cmbClient.DisplayMember = "Name";
                cmbClient.ValueMember = "Id";
                var serviceTypes = (from c in context.servicetypes select c).ToList();
                var newServiceTypes = new List<servicetype>();
                foreach(var serviceType in serviceTypes)
                {
                    var pricelistItems = (from c in context.pricelistitems
                                          where c.ServiceType_Id == serviceType.Id
                                          select c).ToList();
                    if(pricelistItems.Count != 0)
                    {
                        newServiceTypes.Add(serviceType);
                    }
                }
                cmbServiceType.DataSource = newServiceTypes;
                cmbServiceType.DisplayMember = "Name";
                cmbServiceType.ValueMember = "Id";
            }
        }

        private void cmbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serviceType = cmbServiceType.SelectedItem;
            using(MarkusDb context = new MarkusDb())
            {
                var pricelistItemNames = (from c1 in context.pricelistitemnames join c2 in context.pricelistitems
                                          on c1.Id equals c2.PricelistItemName_Id
                                          where c2.ServiceType_Id == ((servicetype)serviceType).Id &&
                                          c2.Current == 1 select c1).ToList();
                cmbPricelistItem.DataSource = pricelistItemNames;
                cmbPricelistItem.DisplayMember = "Name";
                cmbPricelistItem.ValueMember = "Id";
            }
        }

        private void cmbPricelistItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serviceType = cmbServiceType.SelectedItem;
            var pricelistItem = cmbPricelistItem.SelectedItem;
            using (MarkusDb context = new MarkusDb())
            {
                var price = (from c in context.pricelistitems
                             where c.ServiceType_Id == ((servicetype)serviceType).Id &&
                             c.PricelistItemName_Id == ((pricelistitemname)pricelistItem).Id &&
                             c.DateTo == null
                             select c).ToList();
                tbPrice.Text = price[0].Price.ToString();
            }
            tbPrice.Enabled = false;
            if ("Pranje tepiha".Equals(((servicetype)serviceType).Name))
            {
                lblCarpetSize.Visible = true;
                tbCarpetSize.Visible = true;
                lblCarBrand.Visible = false;
                cmbCarBrand.Visible = false;
                //btnAddCarBrand.Visible = false;
                lblLicencePlates.Visible = false;
                mtbLicencePlate.Visible = false;
                lblServiceType.Location = new Point(30, 180);
                cmbServiceType.Location = new Point(229, 168);
                lblPricelistItem.Location = new Point(30, 230);
                cmbPricelistItem.Location = new Point(229, 218);
                lblCarpetSize.Location = new Point(30, 280);
                tbCarpetSize.Location = new Point(229, 270);
                lblPrice.Location = new Point(30, 330);
                tbPrice.Location = new Point(229, 320);
                btnConfirm.Location = new Point(200, 380);
                btnCancel.Location = new Point(359, 380);
                this.Size = new Size(550, 471);
            }
            else
            {
                lblCarpetSize.Visible = false;
                tbCarpetSize.Visible = false;
                tbCarpetSize.Clear();
                lblCarBrand.Visible = true;
                cmbCarBrand.Visible = true;
                //btnAddCarBrand.Visible = true;
                lblLicencePlates.Visible = true;
                mtbLicencePlate.Visible = true;
                lblServiceType.Location = new Point(30, 230);
                cmbServiceType.Location = new Point(229, 218);
                lblPricelistItem.Location = new Point(30, 280);
                cmbPricelistItem.Location = new Point(229, 268);
                lblPrice.Location = new Point(30, 380);
                tbPrice.Location = new Point(229, 370);
                btnConfirm.Location = new Point(200, 430);
                btnCancel.Location = new Point(359, 430);
                this.Size = new Size(550, 521);
                if ("Ostalo".Equals(((servicetype)serviceType).Name))
                {
                    lblCarBrand.Visible = false;
                    cmbCarBrand.Visible = false;
                    //btnAddCarBrand.Visible = false;
                    lblLicencePlates.Visible = false;
                    mtbLicencePlate.Visible = false;
                    lblServiceType.Location = new Point(30, 180);
                    cmbServiceType.Location = new Point(229, 168);
                    lblPricelistItem.Location = new Point(30, 230);
                    cmbPricelistItem.Location = new Point(229, 218);
                    lblPrice.Location = new Point(30, 280);
                    tbPrice.Location = new Point(229, 270);
                    btnConfirm.Location = new Point(200, 330);
                    btnCancel.Location = new Point(359, 330);
                    this.Size = new Size(550, 421);
                    tbPrice.Clear();
                    tbPrice.Enabled = true;
                }
            }
        }

        public void RefreshCarBrandComboBox()
        {
            using (MarkusDb context = new MarkusDb())
            {
                var carBrands = (from c in context.carbrands select c).ToList();
                cmbCarBrand.DataSource = carBrands;
                cmbCarBrand.DisplayMember = "Name";
                cmbCarBrand.ValueMember = "Id";
            }
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                e.Cancel = true;
                //tbFirstName.Focus();
                errorProvider.SetError(tbFirstName, "Niste unijeli ime.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbFirstName, null);
            }
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                e.Cancel = true;
                //tbLastName.Focus();
                errorProvider.SetError(tbLastName, "Niste unijeli prezime.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbLastName, null);
            }
        }

        private void tbCarpetSize_Validating(object sender, CancelEventArgs e)
        {
            if ("Pranje tepiha".Equals(((servicetype)cmbServiceType.SelectedItem).Name) &&
                string.IsNullOrWhiteSpace(tbCarpetSize.Text))
            {
                e.Cancel = true;
                //tbCarpetSize.Focus();
                errorProvider.SetError(tbCarpetSize, "Niste unijeli kvadraturu opranog tepiha.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbCarpetSize, null);
            }
        }

        private void tbPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPrice.Text))
            {
                e.Cancel = true;
                //tbPrice.Focus();
                errorProvider.SetError(tbPrice, "Niste unijeli cijenu usluge.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPrice, null);
            }
        }

        private void AllowDecimal(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1 || (sender as TextBox).Text.Length == 0)
                    e.Handled = true;
            }
        }

        private void AllowLetters(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbCarpetSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDecimal(sender, e);
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDecimal(sender, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                CarBrand_Id = ((carbrand)cmbCarBrand.SelectedItem).Id;
                using (MarkusDb context = new MarkusDb())
                {
                    List<pricelistitem> pricelistItems = (from c in context.pricelistitems
                                                          where c.ServiceType_Id == ((servicetype)cmbServiceType.SelectedItem).Id
                                                          && c.PricelistItemName_Id == ((pricelistitemname)cmbPricelistItem.SelectedItem).Id
                                                          && c.Current == 1
                                                          select c).ToList();
                    //Console.WriteLine();
                    //Console.WriteLine("ServiceType_Id " + ((servicetype)cmbServiceType.SelectedItem).Id);
                    //Console.WriteLine("PricelistItemName_Id " + ((pricelistitemname)cmbPricelistItem.SelectedItem).Id);
                    //Console.WriteLine("Count " + pricelistItems.Count);
                    if (pricelistItems.Count == 1)
                    {
                        PricelistItem_Id = pricelistItems[0].Id;
                    }
                    //Console.WriteLine("PriceListItem_Id " + PricelistItem_Id);
                    //Console.WriteLine();
                }
                if ("Pranje tepiha".Equals(((servicetype)cmbServiceType.SelectedItem).Name))
                {
                    decimal carpetSize = decimal.Parse(tbCarpetSize.Text);
                    decimal price = decimal.Parse(tbPrice.Text);
                    Price = price * carpetSize;
                }
                else
                {
                    Price = decimal.Parse(tbPrice.Text);
                }
                FirstName = tbFirstName.Text;
                LastName = tbLastName.Text;
                LicencePlate = mtbLicencePlate.Text.ToUpper();
                Client_Id = ((client)cmbClient.SelectedItem).Id;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void mtbLicencePlate_Validating(object sender, CancelEventArgs e)
        {
            if (!mtbLicencePlate.MaskCompleted)
            {
                e.Cancel = true;
                //mtbLicencePlate.Focus();
                errorProvider.SetError(mtbLicencePlate, "Niste unijeli registarske tablice.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(mtbLicencePlate, null);
            }
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowLetters(sender, e);
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowLetters(sender, e);
        }
    }
}
