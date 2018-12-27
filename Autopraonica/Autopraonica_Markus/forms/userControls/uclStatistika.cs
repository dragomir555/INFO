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
            Object selectedItem = cbStatistics.SelectedItem;
            if("Statistika po radniku".Equals(selectedItem.ToString()))
            {
                cbEmployee.Enabled = true;
                cbClient.Enabled = false;
                fillEmployeeComboBox();
            } else if("Statistika po klijentu".Equals(selectedItem.ToString()))
            {

                cbEmployee.Enabled = false;
                cbClient.Enabled = true;
                fillClientComboBox();
            } else
            {
                cbEmployee.Enabled = false;
                cbClient.Enabled = false;
            }
        }

        private void fillEmployeeComboBox()
        {
            using (MarkusDb context = new MarkusDb())
            {
                var employees = context.employees.ToList();
                cbEmployee.DataSource = employees;
                cbEmployee.ValueMember = "Id";
                cbEmployee.DisplayMember = "FirstName";
            }
        }

        private void fillClientComboBox()
        {
            using (MarkusDb context = new MarkusDb())
            {
                var clients = context.clients.ToList();
                cbClient.DataSource = clients;
                cbClient.ValueMember = "Id";
                cbClient.DisplayMember = "Name";
            }
        }

        private void cbFormat(object sender, ListControlConvertEventArgs e)
        {
            string lastname = ((employee)e.ListItem).FirstName;
            string firstname = ((employee)e.ListItem).LastName;
            e.Value = lastname + " " + firstname;
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerateStatistics_Click(object sender, EventArgs e)
        {
            DateTime dt1 = this.dateTimePicker1.Value.Date;
            DateTime dt2 = this.dateTimePicker2.Value.Date;
            if ("Statistika po radniku".Equals(cbStatistics.Text))
            {
                int id = (int)cbEmployee.SelectedValue;
                EmployeeChartForm ecf = new EmployeeChartForm(id, cbEmployee.Text, dt1, dt2);
                ecf.ShowDialog();
            } else if("Statistika po klijentu".Equals(cbStatistics.Text))
            {
                int id = (int)cbClient.SelectedValue;
                ClientChartForm ccf = new ClientChartForm(id, cbClient.Text, dt1, dt2);
                ccf.ShowDialog();
            } else
            {
                TotalStatisticsChartForm tscf = new TotalStatisticsChartForm(dt1, dt2);
                tscf.ShowDialog();
            }
        }
    }
}
