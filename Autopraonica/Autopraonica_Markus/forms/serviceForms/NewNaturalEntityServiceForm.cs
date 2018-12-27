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
    public partial class NewNaturalEntityServiceForm : Form
    {
        public int CarBrand_Id { get; set; }
        public int PricelistItem_Id { get; set; }
        public decimal Price { get; set; }

        public NewNaturalEntityServiceForm()
        {
            InitializeComponent();
            FillComboBoxes();
            RefreshCarBrandComboBox();
        }

        private void FillComboBoxes()
        {
            using(MarkusDb context = new MarkusDb())
            {
                var serviceTypes = (from c in context.servicetypes select c).ToList();
                cmbServiceType.DataSource = serviceTypes;
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
                                          where c2.ServiceType_Id == ((servicetype)serviceType).Id
                                          select c1).ToList();
                cmbPricelistItem.DataSource = pricelistItemNames;
                cmbPricelistItem.DisplayMember = "Name";
                cmbPricelistItem.ValueMember = "Id";
            }
        }

        private void cmbPricelistItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serviceType = cmbServiceType.SelectedItem;
            var pricelistItem = cmbPricelistItem.SelectedItem;
            using(MarkusDb context = new MarkusDb())
            {
                var price = (from c in context.pricelistitems where c.ServiceType_Id == ((servicetype)serviceType).Id &&
                              c.PricelistItemName_Id == ((pricelistitemname)pricelistItem).Id &&
                              c.DateTo == null
                              select c).ToList();
                tbPrice.Text = price[0].Price.ToString();
            }
            tbPrice.Enabled = false;
            if("Pranje tepiha".Equals(((servicetype)serviceType).Name)) {
                lblCarpetSize.Visible = true;
                tbCarpetSize.Visible = true;
                lblCarBrand.Visible = false;
                cmbCarBrand.Visible = false;
                btnAddCarBrand.Visible = false;
                lblPrice.Location = new Point(30, 180);
                tbPrice.Location = new Point(229, 170);
                btnConfirm.Location = new Point(200, 230);
                btnCancel.Location = new Point(359, 230);
                this.Size = new Size(550, 321);
            }
            else
            {
                lblCarpetSize.Visible = false;
                tbCarpetSize.Visible = false;
                tbCarpetSize.Clear();
                lblCarBrand.Visible = true;
                cmbCarBrand.Visible = true;
                btnAddCarBrand.Visible = true;
                lblPrice.Location = new Point(30, 180);
                tbPrice.Location = new Point(229, 170);
                btnConfirm.Location = new Point(200, 230);
                btnCancel.Location = new Point(359, 230);
                this.Size = new Size(550, 321);
                if ("Ostalo".Equals(((servicetype)serviceType).Name))
                {
                    lblCarBrand.Visible = false;
                    cmbCarBrand.Visible = false;
                    btnAddCarBrand.Visible = false;
                    lblPrice.Location = new Point(30, 130);
                    tbPrice.Location = new Point(229, 120);
                    btnConfirm.Location = new Point(200, 180);
                    btnCancel.Location = new Point(359, 180);
                    this.Size = new Size(550, 271);
                    tbPrice.Clear();
                    tbPrice.Enabled = true;
                }
            }
        }

        public void RefreshCarBrandComboBox()
        {
            using(MarkusDb context = new MarkusDb())
            {
                var carBrands = (from c in context.carbrands select c).ToList();
                cmbCarBrand.DataSource = carBrands;
                cmbCarBrand.DisplayMember = "Name";
                cmbCarBrand.ValueMember = "Id";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            /*if(cmbServiceType.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali kategoriju usluge.", "Upozorenje");
                cmbServiceType.Focus();
            }
            else if(cmbPricelistItem.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali uslugu.", "Upozorenje");
                cmbPricelistItem.Focus();
            }
            else if(cmbCarBrand.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali marku automobila.", "Upozorenje");
                cmbCarBrand.Focus();
            }
            else
            {
                if("Pranje tepiha".Equals(((servicetype)cmbServiceType.SelectedItem).Name))
                {
                    if(string.IsNullOrWhiteSpace(tbCarpetSize.Text))
                    {
                        MessageBox.Show("Niste unijeli kvadraturu opranog tepiha.", "Upozorenje");
                        tbCarpetSize.Focus();
                    }
                }
                else if (string.IsNullOrWhiteSpace(tbPrice.Text))
                {
                    MessageBox.Show("Niste unijeli cijenu usluge.", "Upozorenje");
                    tbPrice.Focus();
                }
                else
                {
                    CarBrand_Id = ((carbrand)cmbCarBrand.SelectedItem).Id;
                    using(MarkusDb context = new MarkusDb())
                    {
                        List<pricelistitem> pricelistItems = (from c in context.pricelistitems
                                              where c.ServiceType_Id == ((servicetype)cmbServiceType.SelectedItem).Id
                                              && c.PricelistItemName_Id == ((pricelistitemname)cmbPricelistItem.SelectedItem).Id
                                              &&  c.DateTo == null
                                              select c).ToList();
                        if(pricelistItems.Count == 1)
                        {
                            PricelistItem_Id = pricelistItems[0].Id;
                        }
                    }
                    if("Pranje tepiha".Equals(((servicetype)cmbServiceType.SelectedItem).Name))
                    {
                        decimal carpetSize = decimal.Parse(tbCarpetSize.Text);
                        decimal price = decimal.Parse(tbPrice.Text);
                        Price = price * carpetSize;
                    }
                    else
                    {
                        Price = decimal.Parse(tbPrice.Text);
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }*/
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                CarBrand_Id = ((carbrand)cmbCarBrand.SelectedItem).Id;
                using (MarkusDb context = new MarkusDb())
                {
                    List<pricelistitem> pricelistItems = (from c in context.pricelistitems
                                                          where c.ServiceType_Id == ((servicetype)cmbServiceType.SelectedItem).Id
                                                          && c.PricelistItemName_Id == ((pricelistitemname)cmbPricelistItem.SelectedItem).Id
                                                          && c.DateTo == null
                                                          select c).ToList();
                    if (pricelistItems.Count == 1)
                    {
                        PricelistItem_Id = pricelistItems[0].Id;
                    }
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
                this.DialogResult = DialogResult.OK;
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

        private void tbCarpetSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDecimal(sender, e);
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDecimal(sender, e);
        }

        private void tbCarpetSize_Validating(object sender, CancelEventArgs e)
        {
            if ("Pranje tepiha".Equals(((servicetype)cmbServiceType.SelectedItem).Name) && 
                string.IsNullOrWhiteSpace(tbCarpetSize.Text))
            {
                e.Cancel = true;
                tbCarpetSize.Focus();
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
                tbPrice.Focus();
                errorProvider.SetError(tbPrice, "Niste unijeli cijenu usluge.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbPrice, null);
            }
        }
    }
}
