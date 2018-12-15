using Autopraonica_Markus.Model.Entities;
using MySql.Data.MySqlClient;
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
                var employee = new employee();
                employee.FirstName = tbFirstName.Text;
                employee.LastName = tbLastName.Text;
                employee.PID = tbPID.Text;
                employee.E_mail = tbEMail.Text;
                employee.Address = tbAddress.Text;
               
                ctx.employees.Add(employee);
           //   ctx.SaveChanges();
                MessageBox.Show("Generisani ID: " + employee.Id);
            }
            }
            catch (Exception ex)
            {
                string poruka =
                (ex.InnerException.InnerException as MySqlException).Number == 1062
                ? "Postoji zaposleni sa istim ID-om."
                : "Greška prilikom dodavanja zaposlenog.";
                MessageBox.Show(poruka, "Novi zaposleni uspješno dodan.");
            }
        }
    }
}
