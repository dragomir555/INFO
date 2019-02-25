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
using Autopraonica_Markus.forms.statisticsForms;
using System.Collections;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclStatistics : UserControl
    {
        private static uclStatistics instance;

        public static uclStatistics Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclStatistics();
                }
                return instance;
            }
        }
        public uclStatistics()
        {
            InitializeComponent();
            //label3.Text = "";
            cbStatistics.SelectedIndex = 0;
        }

        /*private void cbStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerateStatistics.Enabled = true;
            Object selectedItem = cbStatistics.SelectedItem;
            if ("Statistika po radniku".Equals(selectedItem.ToString()))
            {
                dataGridView1.Enabled = true;
                lblSearch.Enabled = true;
                label3.Enabled = true;
                tbSearch.Enabled = true;
                lblSearch.Text = "Pretraži po imenu";
                label3.Text = "Odaberite radnika za pregled statistike";
                fillEmployeeDataGrid();
            }
            else if ("Statistika po klijentu".Equals(selectedItem.ToString()))
            {
                dataGridView1.Enabled = true;
                lblSearch.Enabled = true;
                label3.Enabled = true;
                tbSearch.Enabled = true;
                lblSearch.Text = "Pretraži po nazivu";
                label3.Text = "Odaberite klijenta za pregled statistike";
                fillClientDataGrid();
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 0;
                dataGridView1.Enabled = false;
                lblSearch.Enabled = false;
                label3.Enabled = false;
                tbSearch.Enabled = false;
                label3.Text = "";
                setTotalStatisticsLabels();
            }
        }*/


        private void fillEmployeeDataGrid()
        {

            string text = tbSearch.Text.Trim();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Ime";
            dataGridView1.Columns[1].Name = "Prezime";
            dataGridView1.Columns[2].Name = "Ukupan broj sati";
            dataGridView1.Columns[3].Name = "Broj sati kao ispomoc";
            dataGridView1.Columns[4].Name = "Ukupan broj pranja";
            dataGridView1.Columns[5].Name = "Broj pranja kao ispomoc";
            dataGridView1.Columns[6].Name = "Id";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int hours = 0;
            int hoursAsHelp = 0;
            int numberOfWashings = 0;
            int numberOfWashingsAsHelp = 0;
            ArrayList employeeIds = new ArrayList();
            ArrayList employeeFirstNames = new ArrayList();
            ArrayList employeeLastNames = new ArrayList();
            using (MarkusDb context = new MarkusDb())
            {
                var employees = (
                    from e in context.employees
                    where e.FirstName.StartsWith(text)
                    select e
                    );
                foreach (var e in employees)
                {
                    employeeIds.Add(e.Id);
                    employeeFirstNames.Add(e.FirstName);
                    employeeLastNames.Add(e.LastName);
                }
            }

            using (MarkusDb context = new MarkusDb())
            {
                for (int i = 0; i < employeeIds.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = employeeIds[i]
                    };
                    DateTime dt1 = this.dateTimePicker1.Value.Date;
                    DateTime dt2 = this.dateTimePicker2.Value.Date.AddDays(1);

                    int id = (int)employeeIds[i];
                    var employeerecords = (
                       from er in context.employeerecords
                       where er.Employee_Id == id &&
                       DateTime.Compare(er.LoginTime, dt1) >= 0 && er.LogoutTime != null && DateTime.Compare(er.LogoutTime.Value, dt2) <= 0
                       select er
                       ).ToList();

                    int seconds = 0;
                    foreach (var er in employeerecords)
                    {
                        seconds += (int)(er.LogoutTime.Value - er.LoginTime).TotalSeconds;
                    }
                    hours = seconds / 3600;

                    var helpingemployeerecords = (
                        from her in context.helpingemployeerecords
                        where her.HelpingEmployee_Id == id &&
                        DateTime.Compare(her.LoginTime, dt1) >= 0 && her.LogoutTime != null && DateTime.Compare(her.LogoutTime.Value, dt2) <= 0
                        select her
                        ).ToList();

                    int seconds2 = 0;
                    foreach (var h in helpingemployeerecords)
                    {
                        seconds2 += (int)(h.LogoutTime.Value - h.LoginTime).TotalSeconds;
                    }

                    hoursAsHelp = seconds2 / 3600;

                    numberOfWashings = (
                        from es in context.employees
                        join nes in context.naturalentityservices on es.Id equals nes.Employee_Id
                        where es.Id == id && DateTime.Compare(nes.ServiceTime, dt1) >= 0 && DateTime.Compare(nes.ServiceTime, dt2) <= 0 && nes.Canceled == false
                        select nes
                        ).Count();

                    numberOfWashingsAsHelp = (
                        from es in context.employees
                        join nes in context.naturalentityservices on es.Id equals nes.HelpingEmployee_Id
                        where nes.HelpingEmployee_Id == id && DateTime.Compare(nes.ServiceTime, dt1) >= 0 && DateTime.Compare(nes.ServiceTime, dt2) <= 0 && nes.Canceled == false
                        select nes
                        ).Count();


                    row.CreateCells(dataGridView1);
                    row.SetValues(employeeFirstNames[i], employeeLastNames[i], hours, hoursAsHelp, numberOfWashings, numberOfWashingsAsHelp, id);
                    dataGridView1.Rows.Add(row);
                }

            }
        }

        private void fillClientDataGrid()
        {
            string text = tbSearch.Text.Trim();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Naziv";
            dataGridView1.Columns[1].Name = "Ukupan prihod";
            dataGridView1.Columns[2].Name = "Ukupan broj usluga";
            dataGridView1.Columns[3].Name = "Id";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ArrayList clientNames = new ArrayList();
            ArrayList clientIds = new ArrayList();
            using (MarkusDb context = new MarkusDb())
            {
                var clients = (
                    from c in context.clients
                    where c.Name.StartsWith(text)
                    select c
                    );
                foreach (var c in clients)
                {
                    clientNames.Add(c.Name);
                    clientIds.Add(c.Id);
                }
            }

            using (MarkusDb context = new MarkusDb())
            {
                DateTime dt1 = this.dateTimePicker1.Value.Date;
                DateTime dt2 = this.dateTimePicker2.Value.Date;
                for (int i = 0; i < clientIds.Count; i++)
                {
                    decimal incomesFromClient = 0;
                    int numberOfServices = 0;
                    int id = (int)clientIds[i];

                    var entityservices = (
                        from les in context.legalentityservices
                        join c in context.clients on les.Client_Id equals c.Id
                        join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                        where c.Id == id && DateTime.Compare(nes.ServiceTime, dt1) >= 0 && DateTime.Compare(nes.ServiceTime, dt2) <= 0
                        select nes
                        ).ToList();
                    foreach (var e in entityservices)
                    {
                        incomesFromClient += e.Price;
                        numberOfServices++;
                    }
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = clientIds[i]
                    };
                    row.CreateCells(dataGridView1);
                    row.SetValues(clientNames[i], incomesFromClient, numberOfServices, clientIds[i]);
                    dataGridView1.Rows.Add(row);

                }
                /* foreach (var c in clients)
                 {
                     DataGridViewRow row = new DataGridViewRow()
                     {
                         Tag = c
                     };
                     row.CreateCells(dataGridView1);
                     row.SetValues(c.Name, c.Id);
                     dataGridView1.Rows.Add(row);
                 }*/
            }
        }

        private void setTotalStatisticsLabels()
        {
            DateTime dt1 = this.dateTimePicker1.Value.Date;
            DateTime dt2 = this.dateTimePicker2.Value.Date;

            label3.Text =  dt1.Day + "." + dt1.Month + "."  + dt1.Year + " - "  + dt2.Day + "." + dt2.Month + "." + dt2.Year;
            decimal costs = 0;
            decimal prices = 0;
            using (MarkusDb context = new MarkusDb())
            {
                var purchases = (
                from p in context.purchases
                join pi in context.purchaseitems on p.Id equals pi.Purchase_Id
                where DateTime.Compare(p.PurchaseTime, dt1) >= 0 && DateTime.Compare(p.PurchaseTime, dt2) <= 0
                select new
                {
                    Quantity = pi.Quantity,
                    Price = pi.Price,
                }).ToList();

                foreach (var p in purchases)
                {
                    costs += p.Quantity * p.Price;
                }

                var naturalentityservices = (
                    from n in context.naturalentityservices
                    where DateTime.Compare(n.ServiceTime, dt1) >= 0 && DateTime.Compare(n.ServiceTime, dt2) <= 0
                    select n
                    ).ToList();
                foreach (var n in naturalentityservices)
                {
                    prices += n.Price;
                }
            }

            label6.Text = "Ukupni troškovi iznose: " + costs;
            label7.Text = "Prihod od usluga: " + prices;
        }

        private void cbFormat(object sender, ListControlConvertEventArgs e)
        {
            string lastname = ((employee)e.ListItem).FirstName;
            string firstname = ((employee)e.ListItem).LastName;
            e.Value = lastname + " " + firstname;
        }


        private void btnGenerateStatistics_Click(object sender, EventArgs e)
        {
            /* DateTime dt1 = this.dateTimePicker1.Value.Date;
             DateTime dt2 = this.dateTimePicker2.Value.Date;
             if (DateTime.Compare(dt1, dt2) >= 0)
             {
                 MessageBox.Show("Datum 'od' je veći od datuma 'do'. Odaberite korektan datum.", "Obavjestenje o datumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 if ("Statistika po radniku".Equals(cbStatistics.Text))
                 {
                     int id = (int)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value;
                     string name = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "  " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                     EmployeeStatisticsForm ecf = new EmployeeStatisticsForm(id, name, dt1, dt2);
                     ecf.ShowDialog();
                 }
                 else if ("Statistika po klijentu".Equals(cbStatistics.Text))
                 {
                     int id = (int)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value;
                     string name = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                     ClientStatisticsForm ccf = new ClientStatisticsForm(id, name, dt1, dt2);
                     ccf.ShowDialog();
                 }
                 else
                 {
                     TotalStatisticsForm tscf = new TotalStatisticsForm(dt1, dt2);
                     tscf.ShowDialog();
                 }
             }*/
            //btnGenerateStatistics.Enabled = true;
            Object selectedItem = cbStatistics.SelectedItem;
            if ("Statistika po radniku".Equals(selectedItem.ToString()))
            {
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.Enabled = true;
                lblSearch.Enabled = true;
                //label3.Enabled = true;
                tbSearch.Enabled = true;
                //  label6.Visible = false;
                //   label7.Visible = false;
                btnClientStatistics.Visible = false;
                lblSearch.Text = "Pretraži po imenu";
                // label3.Text = "Odaberite radnika za pregled statistike";
                fillEmployeeDataGrid();
                setTotalStatisticsLabels();
            }
            else if ("Statistika po klijentu".Equals(selectedItem.ToString()))
            {
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.Enabled = true;
                lblSearch.Enabled = true;
                //  label3.Enabled = true;
                tbSearch.Enabled = true;
                //   label6.Visible = false;
                //   label7.Visible = false;
                lblSearch.Text = "Pretraži po nazivu";
                btnClientStatistics.Visible = true;
                // label3.Text = "Odaberite klijenta za pregled statistike";
                fillClientDataGrid();
                setTotalStatisticsLabels();
            }
            /*  else
              {
                  dataGridView1.Rows.Clear();
                  dataGridView1.Columns.Clear();
                  dataGridView1.ColumnCount = 0;
                  dataGridView1.BackgroundColor = Color.Gray;
                  dataGridView1.Enabled = false;
                  lblSearch.Enabled = false;
                  //    label3.Enabled = false;
                  tbSearch.Enabled = false;
                  label6.Visible = true;
                  label7.Visible = true;
                  btnClientStatistics.Visible = false;
                  //    label3.Text = "";
                  setTotalStatisticsLabels();
              }*/
        }


        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if ("Statistika po radniku".Equals(cbStatistics.SelectedItem.ToString()))
            {
                fillEmployeeDataGrid();
            }
            else
            {
                fillClientDataGrid();
            }
        }

        private void btnGenerateStatistics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGenerateStatistics_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnClientStatistics_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value.Date;
            DateTime dt2 = dateTimePicker2.Value.Date;
            int id = (int)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value;
            string name = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            ClientStatisticsForm ccf = new ClientStatisticsForm(id, name, dt1, dt2);
            ccf.ShowDialog();
        }

        private void uclStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
