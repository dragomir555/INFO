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
            fillComboBox();
            FillTable();
        }

        private void fillComboBox()
        {
            cmbEmployees.Items.Add("Trenutnih");
            cmbEmployees.Items.Add("Bivših");
            cmbEmployees.Text = "Trenutnih";
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

                if ("Trenutnih".Equals(cmbEmployees.Text))
                    employeed = praviZaposleni;
                else
                {
                    foreach (var z in nezaposleni)
                    {
                        if (!praviZaposleni.Contains(z))
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
                employeeForm.Text = "Izmjena zaposlenog";

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
                        DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite sačuvati promjene?", "Izmjena zaposlenog", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
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

                            } }
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
                MessageBox.Show("Izaberite zaposlenog iz tabele");
            }
        }

        private void deleteSelectedEmployee() {
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
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite obrisati označenog zaposlenog?", "Brisanje zaposlenog", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
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

            dgvEmployees.Rows.Clear();
            var empl = new System.Collections.Generic.List<employee>();
            empl = getEmployee(empl);
            empl = empl.Distinct().ToList();

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



        private System.Collections.Generic.List<employee> getEmployee(List<employee> empl)
        {
            string[] text = tbSearchEmployee.Text.Split(' ');
            string firstName = text[0];
            string lastName = "";

            if (text.Count() > 1)
                lastName = text[1];
            List<employee> employees;




            if ("Trenutnih".Equals(cmbEmployees.Text))
            {
                empl = getCurrentEmpl();
            }
            else
            {
                employees = getCurrentEmpl();
                empl = getUnemployees(employees);
            }

            return empl;
        }

        private List<employee> getUnemployees(List<employee> empl)
        {
            string[] text = tbSearchEmployee.Text.Split(' ');
            string firstName = text[0];
            string lastName = "";
            List<employee> currentUnemp = empl;
            List<employee> realUnemployees = new List<employee>();


            if (text.Count() > 1)
                lastName = text[1];

            using (MarkusDb context = new MarkusDb()) {
                if (!"".Equals(lastName))
                    currentUnemp = (from c in context.employees
                                    join emp in context.employments on c.Id equals emp.Employee_Id
                                    where ((c.FirstName.StartsWith(firstName) && c.LastName.StartsWith(lastName) && emp.DateTo != null)
                                    || (c.LastName.StartsWith(firstName) && c.FirstName.StartsWith(lastName) && emp.DateTo != null))
                                    orderby c.LastName
                                    select c).ToList();
                else
                    currentUnemp = (from c in context.employees
                                    join emp in context.employments on c.Id equals emp.Employee_Id
                                    where ((c.FirstName.StartsWith(firstName) && emp.DateTo != null) ||
                                    (c.LastName.StartsWith(firstName) && emp.DateTo != null))
                                    orderby c.LastName
                                    select c).ToList();
            }

            foreach (var e in currentUnemp)
            {
                if (!empl.Any(x => x.E_mail.Equals(e.E_mail)))
                    realUnemployees.Add(e);
            }
            realUnemployees = realUnemployees.Distinct().ToList();
            return realUnemployees;
        }

        private List<employee> getCurrentEmpl()
        {
            string[] text = tbSearchEmployee.Text.Split(' ');
            string firstName = text[0];
            string lastName = "";
            List<employee> empl;

            if (text.Count() > 1)
                lastName = text[1];
            using (MarkusDb context = new MarkusDb())
            {
                if (!"".Equals(lastName))
                    empl = (from c in context.employees
                            join emp in context.employments on c.Id equals emp.Employee_Id
                            where ((c.FirstName.StartsWith(firstName) && c.LastName.StartsWith(lastName) && emp.DateTo == null)
                                    || (c.LastName.StartsWith(firstName) && c.FirstName.StartsWith(lastName) && emp.DateTo == null))
                            orderby c.LastName
                            select c).ToList();
                else
                    empl = (from c in context.employees
                            join emp in context.employments on c.Id equals emp.Employee_Id
                            where ((c.FirstName.StartsWith(firstName) && emp.DateTo == null) ||
                                    (c.LastName.StartsWith(firstName) && emp.DateTo == null))
                            orderby c.LastName
                            select c).ToList();
            }
            return empl;
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
                    empnt = (from c in context.employments where c.Employee_Id == empl.Id select c).ToList().First();
                }

                try
                {
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite ponovo da zaposlite odabranog nezaposlenog?", "Ponovno zaposlenje", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
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
                MessageBox.Show("Izaberite zaposlenog iz tabele");
            }
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideButtons();
        }

        public void hideButtons()
        {
            if ("Trenutnih".Equals(cmbEmployees.Text))
            {
                tbSearchEmployee.Clear();
                lblEmp.Visible = false;
                btnNewEmployee.Visible = true;
                btnHireEmployee.Visible = false;
                btnUpdateEmployee.Visible = true;
                btnDeleteEmployee.Visible = true;
            }
            else
            {
                tbSearchEmployee.Clear();
                btnHireEmployee.Visible = true;
                FillTable();
                lblEmp.Visible = true;
                btnNewEmployee.Visible = false;
                btnUpdateEmployee.Visible = false;
                btnDeleteEmployee.Visible = false;
            }
            FillTable();
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                employee emp = (employee)row.Tag;
                employee empl = null;
                employment empnt = null;
                List<manager> managers = null;

                int idEmployee = emp.Id;
                
                using (MarkusDb context = new MarkusDb())
                {
                    empl = (from c in context.employees where c.Id == idEmployee select c).ToList().First();
                    managers = (from c in context.managers select c).ToList();
                }
                
                foreach(manager m in managers)
                {
                    if (m.Employee_Id == empl.Id)
                        btnDeleteEmployee.Enabled = false;
                    else
                        btnDeleteEmployee.Enabled = true;
                }
            }
        }
    }
}