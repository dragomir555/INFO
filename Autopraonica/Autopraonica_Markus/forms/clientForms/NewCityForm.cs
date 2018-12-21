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
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Autopraonica_Markus.forms.clientForms
{
    public partial class NewCityForm : Form
    {
        public string NameCity { get; set; }
        public string PostCode { get; set; }
        public NewCityForm()
        {
            InitializeComponent();
           
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {

                Debug.WriteLine("Dragomir");
            }
            else
            {
                NameCity = tbCityName.Text;
                PostCode = tbPostCode.Text;
                using (MarkusDb context = new MarkusDb())
                {
                    var ci= (from c in context.cities where c.PostCode == PostCode select c).Count();
                    Debug.WriteLine(ci);
                    if (ci != 0)
                    {
                        MessageBox.Show("Grad sa " + PostCode + " postcodom postoji u bazi", "Error");
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                
            }
        }

        private void tbCityName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCityName.Text))
            {
                e.Cancel = true;
                tbCityName.Focus();
                errorProvider1.SetError(tbCityName, "Molimo vas da unesete ispravan naziv grada !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCityName, null);
            }
        }

        private void tbPostCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPostCode.Text))
            {             
                e.Cancel = true;
                tbPostCode.Focus();
                errorProvider1.SetError(tbPostCode, "Molimo vas da unesete ispravan Postcode!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPostCode, null);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void NewCityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
