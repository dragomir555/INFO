using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.forms.userControls;
using Autopraonica_Markus.forms;
using Autopraonica_Markus.Model.Entities;
using Autopraonica_Markus.forms.loginForms;

namespace Autopraonica_Markus
{
    public partial class MainForm : Form
    {
        private Button PressedButton;
        private Timer timer = new Timer();
        private employee employee;
        private employee helpingEmployee;

        private bool allowShowDisplay = false;

        public MainForm()
        {
            InitializeComponent();
            employee = null;
            helpingEmployee = null;
            if (!pnlContent.Controls.Contains(uclUsluge.Instance))
            {
                pnlContent.Controls.Add(uclUsluge.Instance);
                uclUsluge.Instance.Dock = DockStyle.Fill;
                uclUsluge.Instance.BringToFront();
            }
            else
            {
                uclUsluge.Instance.BringToFront();
            }
            btnUsluge.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnUsluge;
            LoginForm loginForm = new LoginForm(this);
            loginForm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTroskovnik_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclTroskovnik.Instance))
            {
                pnlContent.Controls.Add(uclTroskovnik.Instance);
                uclTroskovnik.Instance.Dock = DockStyle.Fill;
                uclTroskovnik.Instance.BringToFront();
            }
            else
            {
                uclTroskovnik.Instance.BringToFront();
            }
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnTroskovnik.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnTroskovnik;
        }

        private void btnUsluge_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclUsluge.Instance))
            {
                pnlContent.Controls.Add(uclUsluge.Instance);
                uclUsluge.Instance.Dock = DockStyle.Fill;
                uclUsluge.Instance.BringToFront();
            }
            else
            {
                uclUsluge.Instance.BringToFront();
            }
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnUsluge.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnUsluge;
        }

        private void btnIzdRac_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclIzdavanjeRacuna.Instance))
            {
                pnlContent.Controls.Add(uclIzdavanjeRacuna.Instance);
                uclIzdavanjeRacuna.Instance.Dock = DockStyle.Fill;
                uclIzdavanjeRacuna.Instance.BringToFront();                
            }
            else
            {
                uclIzdavanjeRacuna.Instance.BringToFront();
            }
            uclIzdavanjeRacuna.Instance.UpdateComboBox();
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnIzdRac.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnIzdRac;
        }

        private void btnCjenovnik_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclCijenovnik.Instance))
            {
                pnlContent.Controls.Add(uclCijenovnik.Instance);
                uclCijenovnik.Instance.Dock = DockStyle.Fill;
                uclCijenovnik.Instance.BringToFront();
            }
            else
            {
                uclCijenovnik.Instance.BringToFront();
            }
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnCjenovnik.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnCjenovnik;
        }

        private void btnKlijenti_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclKlijenti.Instance))
            {
                pnlContent.Controls.Add(uclKlijenti.Instance);
                uclKlijenti.Instance.Dock = DockStyle.Fill;
                uclKlijenti.Instance.BringToFront();
            }
            else
            {
                uclKlijenti.Instance.BringToFront();
            }
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnKlijenti.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnKlijenti;
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclZaposleni.Instance))
            {
                pnlContent.Controls.Add(uclZaposleni.Instance);
                uclZaposleni.Instance.Dock = DockStyle.Fill;
                uclZaposleni.Instance.BringToFront();
            }
            else
            {
                uclZaposleni.Instance.BringToFront();
            }
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnZaposleni.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnZaposleni;
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclStatistika.Instance))
            {
                pnlContent.Controls.Add(uclStatistika.Instance);
                uclStatistika.Instance.Dock = DockStyle.Fill;
                uclStatistika.Instance.BringToFront();
            }
            else
            {
                uclStatistika.Instance.BringToFront();
            }
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnStatistika.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnStatistika;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tlpContent_Paint(object sender, PaintEventArgs e)
        {

        }
        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = (1000) * (1);
            timer.Enabled = true;
            timer.Start();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (helpingEmployee != null)
            {
                DialogResult dialogResult = MessageBox.Show("Ukoliko nastavite i ispomoć će biti odjavljena. Da li ste sigurni da želite da nastavite?",
                "Markus", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveLogoutTime();
                    SaveHelperLogoutTime();
                    btnAddHelper.Visible = true;
                    btnRemoveHelper.Visible = false;
                    lblHelper.Text = "Ispomoć";
                    employee = null;
                    helpingEmployee = null;
                    this.Hide();
                    LoginForm loginForm = new LoginForm(this);
                    loginForm.Show();
                }
            }
            else
            {
                SaveLogoutTime();
                employee = null;
                this.Hide();
                LoginForm loginForm = new LoginForm(this);
                loginForm.Show();
            }
        }

        private void SaveLogoutTime()
        {
            using (MarkusDb context = new MarkusDb())
            {
                var ers = (from c in context.employeerecords
                           where c.Employee_Id == employee.Id &&
                           c.LogoutTime == null select c).ToList();
                var employeerecord = (employeerecord)ers[0];
                context.employeerecords.Attach(employeerecord);
                employeerecord.LogoutTime = DateTime.Now;
                context.SaveChanges();
            }
        }

        private void SaveHelperLogoutTime()
        {
            using(MarkusDb context = new MarkusDb())
            {
                Console.WriteLine("HelpingEmployee_Id " + helpingEmployee.Id + " Employee_Id " + employee.Id);
                var hers = (from c in context.helpingemployeerecords
                            where c.HelpingEmployee_Id == helpingEmployee.Id &&
                            /*c.Employee_Id == employee.Id &&*/
                            c.LogoutTime == null select c).ToList();
                var helpingemployeerecord = (helpingemployeerecord)hers[0];
                context.helpingemployeerecords.Attach(helpingemployeerecord);
                helpingemployeerecord.LogoutTime = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void SetEmployee(employee employee)
        {
            this.employee = employee;
            lblUser.Text = employee.FirstName + " " + employee.LastName;
            uclUsluge.Instance.SetEmployee(employee);
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowShowDisplay ? value : allowShowDisplay);
        }

        public void ChangeAllowShowDisplay()
        {
            this.allowShowDisplay = true;
            this.Visible = !this.Visible;
        }

        public void SetButtonsVisibility(bool b)
        {
            btnCjenovnik.Visible = b;
            btnIzdRac.Visible = b;
            btnKlijenti.Visible = b;
            btnStatistika.Visible = b;
            btnZaposleni.Visible = b;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (employee != null)
            {
                DialogResult dialogResult = MessageBox.Show("Ukoliko nastavite bićete odjavljeni sa sistema. Da li ste sigurni da želite da zatvorite aplikaciju?",
                    "Markus", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveLogoutTime();
                    if (helpingEmployee != null)
                    {
                        SaveHelperLogoutTime();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnRemoveHelper_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li se sigurni da zelite da uklonite ispomoć?",
                "Markus", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                uclUsluge.Instance.RemoveHelpingEmployee();
                SaveHelperLogoutTime();
                lblHelper.Text = "Ispomoć";
                btnAddHelper.Visible = true;
                btnRemoveHelper.Visible = false;
            }
        }

        private void btnAddHelper_Click(object sender, EventArgs e)
        {
            using(MarkusDb context = new MarkusDb())
            {
                var employees = (from c1 in context.employees /*join c2 in context.employments
                                 on c1.Id equals c2.Employee_Id
                                 where c1.Id != employee.Id &&
                                 c2.DateTo == null*/ select c1).ToList();
                var newEmployee = new employee()
                {
                    FirstName = "Odaberi",
                    LastName = "ispomoć"
                };
                employees.Insert(0, newEmployee);
                cmbHelper.DataSource = employees;
                cmbHelper.DisplayMember = "FirstName";
                cmbHelper.ValueMember = "Id";
                cmbHelper.Visible = true;
            }
        }

        private void cmbHelper_Format(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((employee)e.ListItem).FirstName;
            string lastName = ((employee)e.ListItem).LastName;
            e.Value = firstName + " " + lastName;
        }

        private void cmbHelper_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbHelper.SelectedIndex != 0)
            {
                helpingEmployee = (employee)cmbHelper.SelectedItem;
                DialogResult dialogResult = MessageBox.Show("Da li se sigurni da zelite da dodate zaposlenog " +
                    helpingEmployee.FirstName + " " + helpingEmployee.LastName +
                    " kao ispomoć?", "Markus", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    lblHelper.Text = "Ispomoć: " + helpingEmployee.FirstName + " " + helpingEmployee.LastName;
                    btnAddHelper.Visible = false;
                    btnRemoveHelper.Visible = true;
                    cmbHelper.Visible = false;
                    uclUsluge.Instance.SetHelpingEmployee(helpingEmployee);
                    using (MarkusDb context = new MarkusDb())
                    {
                        var her = new helpingemployeerecord()
                        {
                            Employee_Id = employee.Id,
                            HelpingEmployee_Id = (helpingEmployee).Id,
                            LoginTime = DateTime.Now,
                            LogoutTime = null
                        };
                        context.helpingemployeerecords.Add(her);
                        context.SaveChanges();
                    }
                }
                else
                {
                    helpingEmployee = null;
                }
            }
        }

        private void btnInactive_Click(object sender, EventArgs e)
        {
            StandByForm sbf = new StandByForm(employee);
            sbf.ShowDialog();
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            using (MarkusDb context = new MarkusDb())
            {
                var employment = (from c in context.employments
                                  where c.Employee_Id == employee.Id &&
                                  c.DateTo == null
                                  select c).ToList();
                PasswordChangeForm pcf = new PasswordChangeForm(employment[0], this, 1);
                pcf.ShowDialog();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(UclSettings.Instance))
            {
                pnlContent.Controls.Add(UclSettings.Instance);
                UclSettings.Instance.Dock = DockStyle.Fill;
                UclSettings.Instance.BringToFront();
            }
            else
            {
                UclSettings.Instance.BringToFront();
            }
            PressedButton.BackColor = Color.FromArgb(107, 65, 150);
            btnSettings.BackColor = Color.FromArgb(93, 46, 140);
            PressedButton = btnSettings;
        }
    }
}
