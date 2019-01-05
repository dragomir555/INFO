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
using Autopraonica_Markus.forms.puchaseForms;
using System.Diagnostics;

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
            cmbSearchType.SelectedIndex = 1;
            dtpTo.MaxDate = DateTime.Now;
            dtpTo.Value = DateTime.Now;
        }

        private void FillTable()
        {
            dgvPurchase.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                string textSearch = tbSearchtext.Text;
                string text = cmbSearchType.Text;
                List <purchase> lista= null;
                if ("Radnik".Equals(text)){
                    lista= (from p in context.purchases where p.employee.FirstName.StartsWith(textSearch) select p).ToList();
                }
                else if ("Dobavljač".Equals(text))
                {
                    lista = (from p in context.purchases where p.SupplierName.StartsWith(textSearch) select p).ToList();
                }
                else
                {
                    lista = (from p in context.purchases where p.PurchaseNumber.StartsWith(textSearch) select p).ToList();
                }             
                decimal sumPurchase = 0;
                foreach (var p in lista)
                {
                    if (p.PurchaseTime<=dtpTo.Value && p.PurchaseTime>=dtpFrom.Value) { 
                    DataGridViewRow r = new DataGridViewRow() { Tag = p };
                    r.CreateCells(dgvPurchase);
                    Decimal dec = 0;
                    foreach (var x in p.purchaseitems) {
                        dec += x.Price;
                    }
                    r.SetValues(p.PurchaseNumber, p.SupplierName, p.employee.FirstName + " " + p.employee.LastName, p.PurchaseTime.ToString("dd.MM.yyyy HH:mm"), dec);
                    dgvPurchase.Rows.Add(r);
                    sumPurchase += dec;
                }
                }
                tbSumPurchase.Text = sumPurchase.ToString();
            }           
        }

        private void tbSearchtext_TextChanged(object sender, EventArgs e)
        {
            FillTable();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            FillTable();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            FillTable();
        }

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearchtext.Text = "";
            FillTable();
        }

        private void newPurchase_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            NewPurchase newPurchase = new NewPurchase();
            if (DialogResult.OK == newPurchase.ShowDialog())
            {
                FillTable();
                MessageBox.Show("Uspjesno dodavanje nabavke", "Info");
            }
            else
            {
                Debug.WriteLine("Dialog result don't OK");
            }




        }

        private void dgvPurchase_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvPurchase.SelectedRows.Count > 0)
            {
                //Sta se desi kad se oznaci neka nabavka
            }
               
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            dtpTo.MaxDate = DateTime.Now;
        }
    }
}
