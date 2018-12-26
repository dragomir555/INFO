using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.forms.employeeForms;
using Autopraonica_Markus.Model.Entities;
using System.Data.Entity.Validation;
using Autopraonica_Markus.services;
using System.Diagnostics;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclZaposleni : UserControl
    {
        private static uclZaposleni instance;

        public static uclZaposleni Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclZaposleni();
                }
                return instance;
            }
        }

        public uclZaposleni()
        {
            InitializeComponent();
            FillTable();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployeeForm newEmployeeForm = new NewEmployeeForm();

            if (DialogResult.OK == newEmployeeForm.ShowDialog())
            {
                try
                {
                    using (MarkusDb context = new MarkusDb())
                    {
                        var emp = new employee()
                        {
                            FirstName = newEmployeeForm.FirstName,
                            LastName = newEmployeeForm.LastName,
                            Address = newEmployeeForm.Address,
                            E_mail = newEmployeeForm.E_mail,
                            PhoneNumber = newEmployeeForm.PhoneNumber,
                            PID = newEmployeeForm.PID
                        };

                        var emplmnt = new employment()
                        {
                            DateFrom = DateTime.Now,
                            UserName = UserService.GenerateUsername(newEmployeeForm.FirstName, newEmployeeForm.LastName),
                            Salt = UserService.GenerateSalt(),
                            FirstLogin = 1,
                        };
                        emplmnt.HashPassword = UserService.GetPasswordHash(emplmnt.Salt, UserService.GeneratePassword());
                        
                        context.employments.Add(emplmnt);
                        context.employees.Add(emp);
                        context.SaveChanges();
                        FillTable();
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
        }

        private void FillTable()
        {
            dgvEmployees.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var zaposleni = new System.Collections.Generic.List<employee>(); ;
                if (rbPresent.Checked)
                zaposleni = (from c in context.employees
                                 join ents in context.employments on c.Id equals ents.Employee_Id
                                 where ents.DateTo == null
                                 select c).ToList();
                else
                    zaposleni = (from c in context.employees
                                 join ents in context.employments on c.Id equals ents.Employee_Id
                                 where ents.DateTo != null
                                 select c).ToList();

                foreach (var c in zaposleni)
                {              
                    DataGridViewRow r = new DataGridViewRow() { Tag = c };
                    r.CreateCells(dgvEmployees);
                    r.SetValues(c.FirstName, c.LastName, c.PhoneNumber, c.Address);
                    dgvEmployees.Rows.Add(r);
                }
            }
        }
        

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {

            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                employee emp = (employee)row.Tag;
                NewEmployeeForm employeeForm = new NewEmployeeForm()
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    PhoneNumber = emp.PhoneNumber,
                    Address = emp.Address,
                    E_mail = emp.E_mail,
                    PID = emp.PID
                };

                
                employee empl = null;
                int idEmployee = emp.Id;
                using (MarkusDb context = new MarkusDb())
                {
                    empl = (from c in context.employees where c.Id == idEmployee select c).ToList().First();
                }

                employeeForm.fillTextBoxes();
                employeeForm.hideUnnecessaryItems();
                employeeForm.changeButtonName();
                employeeForm.Tag = 1;

                if (DialogResult.OK == employeeForm.ShowDialog())
                {
                  try
                    {
                        using (MarkusDb context = new MarkusDb())
                        {
                            context.employees.Attach(empl);
                            empl.FirstName = employeeForm.FirstName;
                            empl.LastName = employeeForm.LastName;
                            empl.Address = employeeForm.Address;
                            empl.PhoneNumber = employeeForm.PhoneNumber;
                            empl.PID = employeeForm.PID;
                            context.SaveChanges();
                            FillTable();

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
            }
            else
            {
                MessageBox.Show("Izaberite klijenta iz tabele");
            }
}
              
        private void deleteSelectedEmployee(){
            using (MarkusDb context = new MarkusDb())
            {
                employee emp = (employee)dgvEmployees.SelectedRows[0].Tag;
                context.employees.Attach(emp);
                emp.employments.ElementAt(0).DateTo = DateTime.Now;
                context.SaveChanges();
                FillTable();
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 1)
            {
                if (DialogResult.Yes == MessageBox.Show("Da li ste sigurni da želite obrisati označeni unos?", "Brisanje zaposlenog", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    deleteSelectedEmployee();
                }
            }
        }

        private void tbSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            string[] text = tbSearchEmployee.Text.Split(' ');
            if (text.Count() == 3) {
                MessageBox.Show("Ne mozete unijeti vise od dva parametra za pretragu");
                tbSearchEmployee.Text = text[0] + " " + text[1];
             }
            SearchEmployee();
        }


       

       
           
               
      
                 
                    



        private void SearchEmployee()
        {
            string[] text = tbSearchEmployee.Text.Split(' ');
            string firstName = text[0];
            string lastName="*";

            if (text.Count()>1)
            lastName = text[1];

            dgvEmployees.Rows.Clear();

            using (MarkusDb context = new MarkusDb())
            {
                var empl = new System.Collections.Generic.List<employee>();

                if (rbPresent.Checked)
                {
                    if (text.Count() == 3)
                        empl = (from c in context.employees
                                join emp in context.employments on c.Id equals emp.Employee_Id
                                where (c.FirstName.StartsWith(firstName) || c.LastName.StartsWith(lastName)) && emp.DateTo == null
                                orderby c.LastName
                                select c).ToList();
                    else
                        empl = (from c in context.employees
                                join emp in context.employments on c.Id equals emp.Employee_Id
                                where c.FirstName.StartsWith(firstName) && emp.DateTo == null
                                orderby c.LastName
                                select c).ToList();
                }
                else {
                    if (text.Count() == 3)
                        empl = (from c in context.employees
                                join emp in context.employments on c.Id equals emp.Employee_Id
                                where (c.FirstName.StartsWith(firstName) || c.LastName.StartsWith(lastName)) && emp.DateTo != null
                                orderby c.LastName
                                select c).ToList();
                    else
                        empl = (from c in context.employees
                                join emp in context.employments on c.Id equals emp.Employee_Id
                                where c.FirstName.StartsWith(firstName) && emp.DateTo != null
                                orderby c.LastName
                                select c).ToList();
                }

                foreach (var e in empl)
                {
                    DataGridViewRow r = new DataGridViewRow()
                    {
                        Tag = e
                    };

                    r.CreateCells(dgvEmployees);
                    r.SetValues(e.FirstName, e.LastName, e.PhoneNumber, e.Address);
                    dgvEmployees.Rows.Add(r);
                }
            }
        }

        private void rbPresent_CheckedChanged(object sender, EventArgs e)
        {
            tbSearchEmployee.Clear();
            FillTable();
        }

        private void rbPerfect_CheckedChanged(object sender, EventArgs e)
        {
            tbSearchEmployee.Clear();
            FillTable();
        }
    }
}
