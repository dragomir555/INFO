using Autopraonica_Markus.Model.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.forms.userControls;

namespace Autopraonica_Markus.forms.employeeForms
{
    public partial class NewEmployeeForm : Form
    {
        public NewEmployeeForm()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try { 
            using (MarkusDb ctx = new MarkusDb())
            {
                    
                var emp = new employee();
                emp.FirstName = tbFirstName.Text;
                emp.LastName = tbLastName.Text;
                emp.PID = tbPID.Text;
                emp.E_mail = tbEMail.Text;
                emp.Address = tbAddress.Text;
                emp.PhoneNumber = tbPhoneNumber.Text;

                ctx.employees.Add(emp);
                ctx.SaveChanges();
                this.Close();
            }
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                   .SelectMany(x => x.ValidationErrors)
                   .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);


            }
        }

        private void NewEmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
