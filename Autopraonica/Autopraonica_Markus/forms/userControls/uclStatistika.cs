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

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclStatistika : UserControl
    {
        private static uclStatistika instance;

        public static uclStatistika Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclStatistika();
                }
                return instance;
            }
        }
        public uclStatistika()
        {
            InitializeComponent();
        }

        private void cbStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerateStatistics.Enabled = true;
            Object selectedItem = cbStatistics.SelectedItem;
            if("Statistika po radniku".Equals(selectedItem.ToString()))
            {
                dataGridView1.Enabled = true;
                lblSearch.Enabled = true;
                tbSearch.Enabled = true;
                lblSearch.Text = "Pretraži po imenu";
                fillEmployeeDataGrid();
            } else if("Statistika po klijentu".Equals(selectedItem.ToString()))
            {
                dataGridView1.Enabled = true;
                lblSearch.Enabled = true;
                tbSearch.Enabled = true;
                lblSearch.Text = "Pretraži po nazivu";
                fillClientDataGrid();
            } else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 0;
                dataGridView1.Enabled = false;
                lblSearch.Enabled = false;
                tbSearch.Enabled = false;
            }
        }


        private void fillEmployeeDataGrid()
        {

            string text = tbSearch.Text.Trim();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Ime";
            dataGridView1.Columns[1].Name = "Prezime";
            dataGridView1.Columns[2].Name = "Id";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            using (MarkusDb context = new MarkusDb())
            {
                var employees = (
                    from e in context.employees
                    where e.FirstName.StartsWith(text)
                    select e
                    );
                foreach(var e in employees)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = e
                    };
                    row.CreateCells(dataGridView1);
                    row.SetValues(e.FirstName, e.LastName, e.Id);
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void fillClientDataGrid()
        {
            string text = tbSearch.Text.Trim();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Naziv";
            dataGridView1.Columns[1].Name = "Id";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            using (MarkusDb context = new MarkusDb())
            {
                var clients = (
                    from c in context.clients
                    where c.Name.StartsWith(text)
                    select c
                    );
                foreach(var c in clients)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = c
                    };
                    row.CreateCells(dataGridView1);
                    row.SetValues(c.Name, c.Id);
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void cbFormat(object sender, ListControlConvertEventArgs e)
        {
            string lastname = ((employee)e.ListItem).FirstName;
            string firstname = ((employee)e.ListItem).LastName;
            e.Value = lastname + " " + firstname;
        }

    /*    private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            foreach (System.Windows.Forms.DataGridViewRow r in dataGridView1.Rows)
            {
                if ((r.Cells[0].Value).ToString().ToUpper().Contains(textBox1.Text.ToUpper()))
                {
                    dataGridView1.Rows[r.Index].Visible = true;
                    dataGridView1.Rows[r.Index].Selected = true;
                }
                else
                {
                    dataGridView1.CurrentCell = null;
                    dataGridView1.Rows[r.Index].Visible = false;
                }
            }
            Console.WriteLine("Dobar dan " + textBox1.Text);
            
        }*/

        private void btnGenerateStatistics_Click(object sender, EventArgs e)
        {
            DateTime dt1 = this.dateTimePicker1.Value.Date;
            DateTime dt2 = this.dateTimePicker2.Value.Date;
            if ("Statistika po radniku".Equals(cbStatistics.Text))
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                EmployeeChartForm ecf = new EmployeeChartForm(id, name, dt1, dt2);
                ecf.ShowDialog();
            } else if("Statistika po klijentu".Equals(cbStatistics.Text))
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ClientChartForm ccf = new ClientChartForm(id, name, dt1, dt2);
                ccf.ShowDialog();
            } else
            {
                TotalStatisticsChartForm tscf = new TotalStatisticsChartForm(dt1, dt2);
                tscf.ShowDialog();
            }
        }


        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if("Statistika po radniku".Equals(cbStatistics.SelectedItem.ToString()))
            {
                fillEmployeeDataGrid();
            } else
            {
                fillClientDataGrid();
            }
        }
    }
}
