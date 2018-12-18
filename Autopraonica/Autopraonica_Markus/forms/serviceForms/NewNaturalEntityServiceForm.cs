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
        public NewNaturalEntityServiceForm()
        {
            InitializeComponent();
            FillComboBoxes();
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
                              c.PricelistItemName_Id == ((pricelistitemname)pricelistItem).Id
                              select c).ToList();
                tbPrice.Text = price[0].Price.ToString();
            }
            tbPrice.Enabled = false;
            if("Pranje tepiha".Equals(((servicetype)serviceType).Name)) {
                lblCarpetSize.Visible = true;
                tbCarpetSize.Visible = true;
                lblPrice.Location = new Point(30, 230);
                tbPrice.Location = new Point(229, 220);
                btnConfirm.Location = new Point(200, 280);
                btnCancel.Location = new Point(359, 280);
                this.Size = new Size(550, 371);
            }
            else
            {
                lblCarpetSize.Visible = false;
                tbCarpetSize.Visible = false;
                lblPrice.Location = new Point(30, 180);
                tbPrice.Location = new Point(229, 170);
                btnConfirm.Location = new Point(200, 230);
                btnCancel.Location = new Point(359, 230);
                this.Size = new Size(550, 321);
                if ("Ostalo".Equals(((servicetype)serviceType).Name))
                {
                    tbPrice.Clear();
                    tbPrice.Enabled = true;
                }
            }
        }
    }
}
