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
            using (MarkusDb context = new MarkusDb())
            {
                var list = (from c in context.items select c).ToList();
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
    }
}
