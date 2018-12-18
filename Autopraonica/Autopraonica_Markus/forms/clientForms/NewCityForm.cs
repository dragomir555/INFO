using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
