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
            lbSumPrize.Text = sumPrize.ToString();
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
            list.RemoveAll((x) => x.Item_Id == id);
            FillTable();
        }
    }
}
