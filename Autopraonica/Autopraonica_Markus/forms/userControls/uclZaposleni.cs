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
using Autopraonica_Markus.forms.dialogForm;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclZaposleni : UserControl
    {
        private static uclZaposleni instance;
        private Label lblEmp = new Label();

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
                        String password = UserService.GeneratePassword();
                        emplmnt.HashPassword = UserService.GetPasswordHash(emplmnt.Salt, password);
                        context.employments.Add(emplmnt);
                        context.employees.Add(emp);
                        context.SaveChanges();
                        NewEmployeeInfoForm newEmp = new NewEmployeeInfoForm(newEmployeeForm.FirstName, newEmployeeForm.LastName, emplmnt.UserName, password);
                        newEmp.ShowDialog();
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
                var employeed = new System.Collections.Generic.List<employee>();

                var praviZaposleni = new System.Collections.Generic.List<employee>();
                var nezaposleni = new System.Collections.Generic.List<employee>();

                praviZaposleni = (from c in context.employees
                                 join ents in context.employments on c.Id equals ents.Employee_Id
                                 where ents.DateTo == null 
                                 select c).ToList();
               
                nezaposleni = (from c in context.employees
                                 join ents in context.employments on c.Id equals ents.Employee_Id
                                 where ents.DateTo != null 
                                 select c).ToList();

                if (rbPresent.Checked)
                    employeed = praviZaposleni;
                else
                {
                    foreach (var z in nezaposleni)
                    {
                        if (!praviZaposleni.Contains(z) )
                            employeed.Add(z);
                    }    
                }

                employeed = employeed.Distinct().ToList();
                foreach (var c in employeed)
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
                employeeForm.Tag = 1;

                if (DialogResult.OK == employeeForm.ShowDialog())
                {
                  try
                    {
                        DialogForm dialogForm = new DialogForm("Da li ste sigurni da želite sačuvati promjene?", "Izmjena zaposlenog");
                        dialogForm.ShowDialog();
                        if (dialogForm.DialogResult == DialogResult.Yes)
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

                        }}
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
                employment empnt = (from c in context.employments
                                    where c.Employee_Id == emp.Id
                                    where c.DateTo == null
                                    select c).ToList().First();

                context.employments.Attach(empnt);
                empnt.DateTo = DateTime.Now;
                context.SaveChanges();
                FillTable();
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 1)
            {
                DialogForm dialogForm = new DialogForm("Da li ste sigurni da želite obrisati označenog zaposlenog?", "Brisanje zaposlenog");
                dialogForm.ShowDialog();
                if (dialogForm.DialogResult == DialogResult.Yes)
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
            string lastName="";

            if (text.Count()>1)
            lastName = text[1];

            dgvEmployees.Rows.Clear();

            using (MarkusDb context = new MarkusDb())
            {
                var empl = new System.Collections.Generic.List<employee>();

                if (rbPresent.Checked)
                {
                    if (!"".Equals(lastName))
                        empl = (from c in context.employees
                                join emp in context.employments on c.Id equals emp.Employee_Id
                                where c.FirstName.StartsWith(firstName) && c.LastName.StartsWith(lastName) && emp.DateTo == null
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
                    if (!"".Equals(lastName))
                        empl = (from c in context.employees
                                join emp in context.employments on c.Id equals emp.Employee_Id
                                where c.FirstName.StartsWith(firstName) && c.LastName.StartsWith(lastName) && emp.DateTo != null
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
            lblEmp.Visible = false;
            btnNewEmployee.Visible = true;
            btnHireEmployee.Visible = false;
            btnUpdateEmployee.Visible = true;
            btnDeleteEmployee.Visible = true;
        }

        private void rbPerfect_CheckedChanged(object sender, EventArgs e)
        {
            tbSearchEmployee.Clear();
            btnHireEmployee.Visible = true;
            FillTable();
            lblEmp.Visible = true;
            btnNewEmployee.Visible = false;
            btnUpdateEmployee.Visible = false;
            btnDeleteEmployee.Visible = false;          
      //    lblEmp.Text = "Arhivirani zaposleni";
       //     lblEmp.Location = new Point(218, 19);
        //    FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
          //  Font font = new Font(
            //   fontFamily,
              // 20,
              // FontStyle.Regular,
              // GraphicsUnit.Pixel);
     //       lblEmp.Width = 200;
      //      lblEmp.Font = font;
       //     this.Controls.Add(lblEmp);
        }

        private void btnHireEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                employee emp = (employee)row.Tag;
              


                employee empl = null;
                employment empnt = null;

                int idEmployee = emp.Id;
                using (MarkusDb context = new MarkusDb())
                {
                    empl = (from c in context.employees where c.Id == idEmployee select c).ToList().First();
                }
                 
                using (MarkusDb context = new MarkusDb())
                {
                    empnt = (from c in context.employments where c.Employee_Id ==  empl.Id select c).ToList().First();
                }

                try
                {
                    DialogForm dialogForm = new DialogForm("Da li ste sigurni da želite ponovo da zaposlite odabranog nezaposlenog?", "Zaposlenje");
                    dialogForm.ShowDialog();
                    if (dialogForm.DialogResult == DialogResult.Yes)
                    {
                        using (MarkusDb context = new MarkusDb())
                        {
                            context.employees.Attach(empl);


                            var emplmnt = new employment()
                            {
                                DateFrom = DateTime.Now,
                                UserName = empnt.UserName,
                                Salt = UserService.GenerateSalt(),
                                FirstLogin = 1,
                                Employee_Id = idEmployee,
                                DateTo = null
                            };


                            String password = UserService.GeneratePassword();
                            emplmnt.HashPassword = UserService.GetPasswordHash(emplmnt.Salt, password);
                            context.employments.Add(emplmnt);
                            context.SaveChanges();

                            NewEmployeeInfoForm newEmp = new NewEmployeeInfoForm(empl.FirstName, empl.LastName, emplmnt.UserName, password);
                            newEmp.ShowDialog();
                            FillTable();
                          
                        }
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
            else
            {
                MessageBox.Show("Izaberite klijenta iz tabele");
            }
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
