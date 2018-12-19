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
        private MainForm mainForm;

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
            FillTableNaturalEntityServices();
            FillTableLegalEntityServices();
        }

        public void SetMainForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        private void FillTableLegalEntityServices()
        {
            dgvLegalEntity.Rows.Clear();
            using(MarkusDb context = new MarkusDb())
            {
                var services = (from c in context.legalentityservices select c).ToList();
                foreach(var s in services)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = s
                    };
                    row.CreateCells(dgvLegalEntity);
                    row.SetValues(s.client.Name, s.naturalentityservice.ServiceTime,
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
                var services = (from c in context.naturalentityservices select c).ToList();
                foreach(var s in services)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = s
                    };
                    row.CreateCells(dgvNaturalEntity);
                    row.SetValues(s.ServiceTime, s.pricelistitem.servicetype.Name,
                        s.pricelistitem.pricelistitemname.Name, s.Price);
                    dgvNaturalEntity.Rows.Add(row);
                }
            }
            dgvNaturalEntity.BringToFront();
        }

        private void dgvLegalEntity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbPravnaLica_CheckedChanged(object sender, EventArgs e)
        {
            dgvLegalEntity.BringToFront();
        }

        private void rbFizickaLica_CheckedChanged(object sender, EventArgs e)
        {
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
                            // Employee_Id = mainForm.getEmployee().Id;
                        };
                        context.naturalentityservices.Add(naturalEntityService);
                        context.SaveChanges();
                        FillTableNaturalEntityServices();
                        rbFizickaLica.Checked = true;
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
