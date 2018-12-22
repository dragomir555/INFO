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
        public NewLegalEntityServiceForm()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            using (MarkusDb context = new MarkusDb())
            {
                var clients = (from c in context.clients select c).ToList();
                cmbClient.DataSource = clients;
                cmbClient.DisplayMember = "Name";
                cmbClient.ValueMember = "Id";
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
                btnAddCarBrand.Visible = false;
                lblPrice.Location = new Point(30, 380);
                tbPrice.Location = new Point(229, 370);
                btnConfirm.Location = new Point(200, 430);
                btnCancel.Location = new Point(359, 430);
                this.Size = new Size(550, 521);
            }
            else
            {
                lblCarpetSize.Visible = false;
                tbCarpetSize.Visible = false;
                tbCarpetSize.Clear();
                lblCarBrand.Visible = true;
                cmbCarBrand.Visible = true;
                btnAddCarBrand.Visible = true;
                lblPrice.Location = new Point(30, 380);
                tbPrice.Location = new Point(229, 370);
                btnConfirm.Location = new Point(200, 430);
                btnCancel.Location = new Point(359, 430);
                this.Size = new Size(550, 521);
                if ("Ostalo".Equals(((servicetype)serviceType).Name))
                {
                    lblCarBrand.Visible = false;
                    cmbCarBrand.Visible = false;
                    btnAddCarBrand.Visible = false;
                    lblPrice.Location = new Point(30, 330);
                    tbPrice.Location = new Point(229, 320);
                    btnConfirm.Location = new Point(200, 380);
                    btnCancel.Location = new Point(359, 380);
                    this.Size = new Size(550, 471);
                    tbPrice.Clear();
                    tbPrice.Enabled = true;
                }
            }
        }
    }
}
