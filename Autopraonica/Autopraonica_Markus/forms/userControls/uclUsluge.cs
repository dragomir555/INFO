using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.Model.Entities;
using Autopraonica_Markus.forms.serviceForms;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclUsluge : UserControl
    {
        private static uclUsluge instance;
        private employee employee;
        private employee helpingEmployee;

        public static uclUsluge Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclUsluge();
                }
                return instance;
            }
        }

        public uclUsluge()
        {
            InitializeComponent();
            helpingEmployee = null;
            cmbEntities.SelectedIndex = 0;
        }

        public void SetEmployee(employee employee)
        {
            this.employee = employee;
            FillTableNaturalEntityServices();
            FillTableLegalEntityServices();
            cmbEntities.SelectedIndex = 0;
        }

        public void SetHelpingEmployee(employee employee)
        {
            helpingEmployee = employee;
        }

        public void RemoveHelpingEmployee()
        {
            helpingEmployee = null;
        }

        private void FillTableLegalEntityServices()
        {
            dgvLegalEntity.Rows.Clear();
            using(MarkusDb context = new MarkusDb())
            {
                var services = (from c in context.legalentityservices
                                where c.naturalentityservice.Employee_Id == employee.Id &&
                                c.naturalentityservice.Canceled == false &&
                                c.naturalentityservice.ServiceTime.Day == DateTime.Now.Day &&
                                c.naturalentityservice.ServiceTime.Month == DateTime.Now.Month &&
                                c.naturalentityservice.ServiceTime.Year == DateTime.Now.Year
                                select c).ToList();
                foreach(var s in services)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = s
                    };
                    row.CreateCells(dgvLegalEntity);
                    row.SetValues(s.client.Name, s.naturalentityservice.ServiceTime.ToString("HH:mm:ss"),
                        s.naturalentityservice.pricelistitem.servicetype.Name,
                        s.naturalentityservice.pricelistitem.pricelistitemname.Name, s.naturalentityservice.Price);
                    dgvLegalEntity.Rows.Add(row);
                }
            }
            dgvLegalEntity.BringToFront();
        }

        private void FillTableNaturalEntityServices()
        {
            dgvNaturalEntity.Rows.Clear();
            using(MarkusDb context = new MarkusDb())
            {
                var legalServices = (from c in context.legalentityservices
                                     where c.naturalentityservice.Employee_Id == employee.Id
                                     select c).ToList();
                var services = (from c in context.naturalentityservices
                                where c.Employee_Id == employee.Id &&
                                c.Canceled == false &&
                                c.ServiceTime.Day == DateTime.Now.Day &&
                                c.ServiceTime.Month == DateTime.Now.Month &&
                                c.ServiceTime.Year == DateTime.Now.Year
                                select c).ToList();
                List<naturalentityservice> naturalservices = new List<naturalentityservice>();
                foreach(var s in legalServices)
                {
                    naturalservices.Add(s.naturalentityservice);
                }
                foreach(var s in services)
                {
                    if (!naturalservices.Contains(s))
                    {
                        DataGridViewRow row = new DataGridViewRow()
                        {
                            Tag = s
                        };
                        row.CreateCells(dgvNaturalEntity);
                        row.SetValues(s.ServiceTime.ToString("HH:mm:ss"), s.pricelistitem.servicetype.Name,
                            s.pricelistitem.pricelistitemname.Name, s.Price);
                        dgvNaturalEntity.Rows.Add(row);
                    }
                }
            }
            dgvNaturalEntity.BringToFront();
        }

        private void btnNewNaturalEntityService_Click(object sender, EventArgs e)
        {
            NewNaturalEntityServiceForm nnesf = new NewNaturalEntityServiceForm();
            if(DialogResult.OK == nnesf.ShowDialog())
            {
                try
                {
                    using(MarkusDb context = new MarkusDb())
                    {
                        var naturalEntityService = new naturalentityservice()
                        {
                            Price = nnesf.Price,
                            CarBrand_Id = nnesf.CarBrand_Id,
                            PricelistItem_Id = nnesf.PricelistItem_Id,
                            ServiceTime = DateTime.Now,
                            Employee_Id = employee.Id,
                            HelpingEmployee_Id = (helpingEmployee == null) ? new int?() : helpingEmployee.Id,
                            Canceled = false
                        };
                        context.naturalentityservices.Add(naturalEntityService);
                        context.SaveChanges();
                        FillTableNaturalEntityServices();
                        cmbEntities.SelectedIndex = 1;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Source);
                }
            }
        }

        private void btnNewLegalEntityService_Click(object sender, EventArgs e)
        {
            NewLegalEntityServiceForm nlesf = new NewLegalEntityServiceForm();
            if(DialogResult.OK == nlesf.ShowDialog())
            {
                try
                {
                    using (MarkusDb context = new MarkusDb())
                    {
                        var naturalEntityService = new naturalentityservice()
                        {
                            Price = nlesf.Price,
                            CarBrand_Id = nlesf.CarBrand_Id,
                            PricelistItem_Id = nlesf.PricelistItem_Id,
                            ServiceTime = DateTime.Now,
                            Employee_Id = employee.Id,
                            HelpingEmployee_Id = (helpingEmployee == null) ? new int?() : helpingEmployee.Id,
                            Canceled = false
                        };
                        context.naturalentityservices.Add(naturalEntityService);
                        context.SaveChanges();
                        var legalEntityService = new legalentityservice()
                        {
                            Client_Id = nlesf.Client_Id,
                            NaturalEntityService_Id = naturalEntityService.Id,
                            FirstName = nlesf.FirstName,
                            LastName = nlesf.LastName,
                            LicencePlate = nlesf.LicencePlate
                        };
                        context.legalentityservices.Add(legalEntityService);
                        context.SaveChanges();
                        FillTableLegalEntityServices();
                        cmbEntities.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void cmbEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbEntities.SelectedIndex == 0)
            {
                dgvLegalEntity.BringToFront();
            }
            else
            {
                dgvNaturalEntity.BringToFront();
            }
        }

        private void btnCancelService_Click(object sender, EventArgs e)
        {
            if (cmbEntities.SelectedIndex == 0)
            {
                if (dgvLegalEntity.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da poništite odabranu uslugu?",
                    "Markus", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow row = dgvLegalEntity.CurrentRow;
                        naturalentityservice service = ((legalentityservice)row.Tag).naturalentityservice;
                        using (MarkusDb context = new MarkusDb())
                        {
                            context.naturalentityservices.Attach(service);
                            service.Canceled = true;
                            context.SaveChanges();
                        }
                        FillTableLegalEntityServices();
                    }
                }
                else
                {
                    MessageBox.Show("Niste odabrali uslugu za poništavanje.", "Markus");
                }
            }
            else
            {
                if (dgvNaturalEntity.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da poništite odabranu uslugu?",
                        "Markus", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DataGridViewRow row = dgvNaturalEntity.CurrentRow;
                        naturalentityservice service = (naturalentityservice)row.Tag;
                        using (MarkusDb context = new MarkusDb())
                        {
                            context.naturalentityservices.Attach(service);
                            service.Canceled = true;
                            context.SaveChanges();
                        }
                        FillTableNaturalEntityServices();
                    }
                }
                else
                {
                    MessageBox.Show("Niste odabrali uslugu za poništavanje.", "Markus");
                }
            }
        }
    }
}
