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
using System.Data.Entity.Validation;
using Autopraonica_Markus.Model.Entities;

namespace Autopraonica_Markus.forms.puchaseForms
{
    public partial class Item : Form
    {
      public  int Count { get; set; }
      public  Decimal Prize { get; set; }
      public   item ItemInForm { get; set;}

        public Item()
        {
            InitializeComponent();
            FillTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FillTable()
        {
            string textSearch = tbSearchText.Text;
            using (MarkusDb context = new MarkusDb())
            {
                var list = (from c in context.items where c.Name.StartsWith(textSearch) select c ).ToList();
                dgvItems.Rows.Clear();
                foreach(var x in list)
                {
                    DataGridViewRow row = new DataGridViewRow() { Tag = x};
                    row.CreateCells(dgvItems);
                    row.SetValues(x.Name, x.MeasuringUnit);
                    dgvItems.Rows.Add(row);
                }

            }
          
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            NewItem newItem = new NewItem();
            if (DialogResult.OK == newItem.ShowDialog())
            {
                try
                {
                    using(MarkusDb context=new MarkusDb())
                    {
                        var it = new item
                        {
                            Name = newItem.NameItem,
                            MeasuringUnit = newItem.NameUnit
                        };
                        Debug.WriteLine(it.Name+"  "+it.MeasuringUnit);
                        context.items.Add(it);
                        context.SaveChanges();
                        FillTable();
                    }

                }
                catch (DbEntityValidationException ex) { Debug.WriteLine(ex); }
            }
            else
            {
                Debug.WriteLine("Forma nije OK zavrsena");
            }

        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvItems.SelectedRows[0];
                item con = (item)row.Tag;
                tbStavka.Tag = con;
                tbStavka.Text = con.Name;
                tbUnit.Text = con.MeasuringUnit;
                tbUnit.Tag = con;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {             
            }
            else
            {
                Count =int.Parse(tbQuantity.Text);
                Prize = decimal.Parse(tbPrize.Text);
                ItemInForm =(item)tbStavka.Tag;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tbQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbQuantity.Text))
            {
                errorProvider1.SetError(tbQuantity, "Unesite količinu !!!");
                e.Cancel = true;
            }
        }

        private void tbPrize_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPrize.Text))
            {
                errorProvider1.SetError(tbPrize, "Unesite cijenu stavke");
                e.Cancel = true;
            }
        }

        private void tbSearchText_TextChanged(object sender, EventArgs e)
        {
            FillTable();
        }
        /*
       private void AllowInteger(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowInteger(sender, e);
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

        private void tbPrize_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowDecimal(sender, e);
        }*/
    }
}
