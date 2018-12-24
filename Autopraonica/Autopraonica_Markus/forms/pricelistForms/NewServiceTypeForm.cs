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
    public partial class NewServiceTypeForm : Form
    {
        public string Name { get; set; }

        public NewServiceTypeForm()
        {
            InitializeComponent();
        }

        private void btnAddServiceType_Click(object sender, EventArgs e)
        {
            Name = tbServiceType.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
