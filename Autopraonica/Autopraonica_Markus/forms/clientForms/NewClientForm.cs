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
   
    public partial class NewClientForm : Form
    {
        public String Name { get; set; }
        public String UID { get; set; }
        public String Address { get; set; }
        public int IdCity { get; set; }
        public NewClientForm()
        {
            InitializeComponent();
        }
    }
}
