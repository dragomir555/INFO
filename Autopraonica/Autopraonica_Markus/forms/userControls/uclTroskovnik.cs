using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.Model.Entities;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclTroskovnik : UserControl
    {

        private static uclTroskovnik instance;

        public static uclTroskovnik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclTroskovnik();
                }
                return instance;
            }
        }
        public uclTroskovnik()
        {
            InitializeComponent();
            FillTable();
        }

        private void FillTable()
        {
            dgvPurchase.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var purchase = (from pi in context.purchaseitems select pi);
            
                foreach(var p in purchase)
                {
                    DataGridViewRow r = new DataGridViewRow() { Tag = p };
                    r.CreateCells(dgvPurchase);
                    r.SetValues(p.purchase.PurchaseNumber,p.purchase.SupplierName,p.purchase.employee.FirstName+" "+
                        p.purchase.employee.LastName,p.purchase.PurchaseTime.ToString("dd.MM.yyyy HH:mm"),p.Price);
                    dgvPurchase.Rows.Add(r);
                }
               
            }
           

        }
    }
}
