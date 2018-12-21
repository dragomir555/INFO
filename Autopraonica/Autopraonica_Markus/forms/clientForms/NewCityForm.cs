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
            NameCity = tbCityName.Text;
            PostCode = tbPostCode.Text;
            if (string.IsNullOrWhiteSpace(NameCity))
            {
                
            }
            using(MarkusDb context=new MarkusDb())
            {
                var ci = (from c in context.cities where c.PostCode == PostCode select c);
                if (ci != null)
                {
                    MessageBox.Show("Grad sa "+PostCode+" postcodom postoji u bazi", "Error");
                }
                return;
            }
            this.DialogResult=DialogResult.OK;
            this.Close();
        }
    }
}
