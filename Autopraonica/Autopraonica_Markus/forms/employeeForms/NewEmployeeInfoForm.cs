using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.employeeForms
{
    public partial class NewEmployeeInfoForm : Form
    {
        public NewEmployeeInfoForm(String firstName, String lastName, String userName, String password)        {
            InitializeComponent();
            fillTextBoxes(firstName, lastName, userName, password);
        }

        public void fillTextBoxes(String firstName, String lastName, String userName, String password)
        {
            tbName.Text = firstName + " " + lastName;
            tbUsername.Text = userName;
            tbPassword.Text = password; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
