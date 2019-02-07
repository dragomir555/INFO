using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Autopraonica_Markus.Model.Entities;
using Autopraonica_Markus.forms.userControls;

namespace Autopraonica_Markus.forms.puchaseForms
{
    public partial class NewPurchase : Form
    {
        List<purchaseitem> list = new List<purchaseitem>();

        public NewPurchase()
        {
            InitializeComponent();
        }

        private void newItemT_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            if (DialogResult.OK == item.ShowDialog())
            {
                var c = new purchaseitem()
                {
                    Price = item.Prize,
                    Quantity = item.Count,
                    Item_Id = item.ItemInForm.Id,
                    item = item.ItemInForm
                };
                list.Add(c);
                FillTable();
            }
            else
            {
                Debug.WriteLine("Dialog result don't OK");
            }
        }
        private void FillTable()
        {         
                dgvItems.Rows.Clear();
                decimal sumPrize = 0;
                foreach (purchaseitem p in list)
                {
                    DataGridViewRow row = new DataGridViewRow() { Tag = p };
                    row.CreateCells(dgvItems);
                    row.SetValues(p.item.Name, p.Quantity, p.item.MeasuringUnit, p.Price);
                    dgvItems.Rows.Add(row);
                    sumPrize += p.Price;
                }
                lbSumPrize.Text = sumPrize.ToString() + "  [KM]";             
        }

        private void deleteItemT_Click(object sender, EventArgs e)
        {
            int id=-1;
            if (dgvItems.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvItems.SelectedRows[0];
                purchaseitem temp = (purchaseitem)row.Tag;
                id = temp.Item_Id;
            }
            else
            {
                MessageBox.Show("Izaberite stavku u nabavci", "Markus");
            }
            list.RemoveAll((x) => x.Item_Id == id);
            FillTable();
        }
        private void AllowInteger(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                Debug.WriteLine("Nije dobra validacija");
            }
            else
            {
                if (this.Tag != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    int idPur;
                    if (list.Count() > 0)
                    {
                        using (MarkusDb context = new MarkusDb())
                        {
                            var purchase = new purchase()
                            {
                                PurchaseTime = DateTime.Now,
                                SupplierName = tbNameSuplier.Text,
                                PurchaseNumber = tbNumberPurchase.Text,
                                Employee_Id = uclTroskovnik.ActiveEmployee.Id,
                                Canceled=false

                            };
                            context.purchases.Add(purchase);
                            context.SaveChanges();
                            idPur = purchase.Id;
                            foreach (purchaseitem p in list)
                            {
                                p.Purchase_Id = idPur;
                                p.item = (from c in context.items where c.Id == p.Item_Id select c).ToList().First();
                                context.purchaseitems.Add(p);                              
                                context.SaveChanges();
                            }
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nemate stavki u nabavci", "Info");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void NewPurchase_Load(object sender, EventArgs e)
        { decimal sum = 0;
            if (this.Tag != null)
            {
                purchase temp = (purchase)this.Tag;
                tbNameSuplier.Text = temp.SupplierName;
                tbNumberPurchase.Text = temp.PurchaseNumber;

                tbNameSuplier.ReadOnly = true;
                tbNumberPurchase.ReadOnly = true;
                ActiveControl = btnCancel;
                btnCancel.Text = "OK";
                btnCancel.Left = 200;
                btnConfirm.Hide();
                btnDeleteItemT.Hide();
                btnNewItemT.Hide();

                using(MarkusDb context=new MarkusDb())
                {
                    var xl = (from c in context.purchaseitems where c.Purchase_Id == temp.Id select c).ToList();
                    foreach(purchaseitem p in xl)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvItems);
                        row.SetValues(p.item.Name, p.Quantity, p.item.MeasuringUnit, p.Price);
                        dgvItems.Rows.Add(row);
                        sum += p.Price;
                    }
                    lbSumPrize.Text = sum + " [KM]";
                }

            }
        }

        private void tbNumberPurchase_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumberPurchase.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNumberPurchase, "Molimo vas unesite broj računa.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNumberPurchase, null);
            }
        }

        private void tbNameSuplier_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNameSuplier.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNameSuplier, "Molimo vas unesite naziv dobavljaca");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNameSuplier,null);
            }
        }

        private void tbNumberPurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowInteger(sender,e);
        }
    }
}
