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
    public partial class NewItem : Form
    {
        public string NameItem { set; get; }
        public string NameUnit { set; get; }
        public NewItem()
        {
            InitializeComponent();
            FillCombo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FillCombo()
        {
            using(MarkusDb context=new MarkusDb())
            {
                List<item> it = (from c in context.items select c).ToList().GroupBy((x)=>x.MeasuringUnit).Select(y=>y.First()).ToList();
                cmbUnit.DataSource = it;
                cmbUnit.DisplayMember = "MeasuringUnit";
                cmbUnit.ValueMember = "Id";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled)) {
                Debug.WriteLine("Nije dobra validacija");
            }
            else {
                NameItem = tbNameItem.Text;
                NameUnit = ((item)cmbUnit.SelectedItem).MeasuringUnit;
                using (MarkusDb context = new MarkusDb())
                {
                    var ci = (from c in context.items where c.Name == NameItem select c).Count();
                    if (ci != 0)
                    {
                        MessageBox.Show("Usluga sa " + NameItem + " imenom postoji u bazi", "Error");
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void tbNameItem_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNameItem.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNameItem, "Molimo vas unesite naziv stavke.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNameItem, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

 
    }
}
