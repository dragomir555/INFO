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
                            PID = newEmployeeForm.Password
                        };
                        context.employees.Add(emp);
                        context.SaveChanges();
                        FillTable();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("greska prilikom dodavanja zaposlenog+\n\n" + ex, "Novi zaposleni");
                }
            }
        }

        private void FillTable()
        {
            dgvEmployees.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var zaposleni = (from c in context.employees select c).ToList();
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
            if (dgvEmployees.SelectedRows.Count == 1)
            {
                employee emp = (employee)dgvEmployees.SelectedRows[0].Tag;
                NewEmployeeForm newEmployeeForm = new NewEmployeeForm()
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    PhoneNumber = emp.PhoneNumber,
                    Address = emp.Address
                };

                newEmployeeForm.fillTextBoxes();
                newEmployeeForm.hideUnnecessaryItems();
                newEmployeeForm.changeButtonName();

                if (DialogResult.OK == newEmployeeForm.ShowDialog())
                {
                    try
                    {
                        using (MarkusDb context = new MarkusDb())
                        {
                            var changedEmp = new employee()
                            {
                                FirstName = newEmployeeForm.FirstName,
                                LastName = newEmployeeForm.LastName,
                                Address = newEmployeeForm.Address,
                                PID = emp.PID,
                                E_mail = emp.E_mail,
                                PhoneNumber = newEmployeeForm.PhoneNumber
                            };

                            deleteSelectedEmployee();
                            context.employees.Add(changedEmp);
                            context.SaveChanges();
                            FillTable();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("greska prilikom izmjene zaposlenog+\n\n" + ex, "Izmjena zaposlenog");
                    }
                }
            }
        }

        private void deleteSelectedEmployee(){
            using (MarkusDb context = new MarkusDb())
            {
                employee emp = (employee)dgvEmployees.SelectedRows[0].Tag;
                context.employees.Attach(emp);
                context.employees.Remove(emp);
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
    }
}
