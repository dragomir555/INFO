using Autopraonica_Markus.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Autopraonica_Markus.forms.statisticsForms
{
    public partial class EmployeeStatisticsForm : Form
    {
        public EmployeeStatisticsForm(int employeeId, string employeeName, DateTime dt1, DateTime dt2)
        {
            InitializeComponent();
            fillChart(employeeId, employeeName, dt1, dt2);
        }

        private void fillChart(int employeeId, string employeeName, DateTime dt1, DateTime dt2)
        {
            label5.Text = "Period " + dt1.ToString("dd.MM.yyyy") + " - " + dt2.ToString("dd.MM.yyyy");
            int hours = 0;
            int hoursAsHelp = 0;
            int numberOfWashings = 0;
            int numberOfWashingsAsHelp = 0;
            using (MarkusDb context = new MarkusDb())
            {
                var employeerecords = (
                    from er in context.employeerecords
                    where er.Employee_Id == employeeId &&
                    DateTime.Compare(er.LoginTime, dt1) >= 0 && er.LogoutTime != null &&  DateTime.Compare(er.LogoutTime.Value, dt2) <= 0
                    select er
                    ).ToList();

                foreach(var e in employeerecords)
                {
                    hours += (int)(e.LogoutTime.Value - e.LoginTime).TotalHours;
                }
                if(hours == 0)
                {
                    chart1.Visible = false;
                }
                var helpingemployeerecords = (
                    from her in context.helpingemployeerecords
                    where her.HelpingEmployee_Id == employeeId &&
                    DateTime.Compare(her.LoginTime, dt1) >= 0 && her.LogoutTime != null && DateTime.Compare(her.LogoutTime.Value, dt2) <= 0
                    select her
                    ).ToList();

                foreach (var h in helpingemployeerecords)
                {
                    hoursAsHelp += (int)(h.LogoutTime.Value - h.LoginTime).TotalHours;
                }

             /*   if(numberOfWashings == 0)
                {
                    chart2.Visible = false;
                }*/
            
                numberOfWashings = (
                    from e in context.employees
                    join nes in context.naturalentityservices on e.Id equals nes.Employee_Id
                    where e.Id == employeeId && DateTime.Compare(nes.ServiceTime, dt1) >= 0 && DateTime.Compare(nes.ServiceTime, dt2) <= 0
                    select nes
                    ).Count();

                numberOfWashingsAsHelp = (
                    from her in context.helpingemployeerecords
                    join nes in context.naturalentityservices on her.HelpingEmployee_Id equals nes.HelpingEmployee_Id
                    where her.HelpingEmployee_Id == employeeId && DateTime.Compare(nes.ServiceTime, dt1) >= 0 && DateTime.Compare(nes.ServiceTime, dt2) <= 0
                    select nes
                    ).Count();
            }
            Title title = chart1.Titles.Add("Statistika  za  radnika  " + employeeName);
            title.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            title.ForeColor = System.Drawing.Color.White;
            chart1.Series["Hours"].IsValueShownAsLabel = true;
            chart1.Series["Hours"].Points.AddXY("Ukupan broj sati", hours);
            chart1.Series["Hours"].Points.AddXY("Broj sati kao ispomoc", hoursAsHelp);

            Title title2 = chart2.Titles.Add("Statistika  za  radnika  " + employeeName);
            title2.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
            title2.ForeColor = System.Drawing.Color.White;
            chart2.Series["Washings"].IsValueShownAsLabel = true;
            chart2.Series["Washings"].Points.AddXY("Ukupan broj pranja", numberOfWashings);
            chart2.Series["Washings"].Points.AddXY("Broj pranja kao ispomoc", numberOfWashingsAsHelp);
            chart1.Series[0].Points[0].Color = Color.DarkGray;
            chart2.Series[0].Points[0].Color = Color.Purple;
            lblName.Text = "Statistika za radnika " + employeeName;
            label1.Text = "Ukupan broj sati: " + hours;
            label2.Text = "Broj sati kao ispomoc: " + hoursAsHelp;
            label3.Text = "Ukupan broj pranja: " + numberOfWashings;
            label4.Text = "Broj pranja kao ispomoc: " + numberOfWashingsAsHelp;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
