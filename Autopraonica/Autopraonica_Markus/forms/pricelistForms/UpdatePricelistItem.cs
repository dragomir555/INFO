using Autopraonica_Markus.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.pricelistForms
{
    public partial class UpdatePricelistItem : Form
    {
        public UpdatePricelistItem(int pricelistItem_id)
        {
            InitializeComponent();
            fillFields(pricelistItem_id);
        }

        private void fillFields(int id)
        {
            using (MarkusDb context = new MarkusDb())
            {
                var pricelistItem = context.pricelistitems.Find(id);
                var pricelistItemName = context.pricelistitemnames.Find(pricelistItem.PricelistItemName_Id);
                
            }
        }
    }
}
