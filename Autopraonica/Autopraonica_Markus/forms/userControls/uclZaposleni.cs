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
            NewEmployeeForm nef = new NewEmployeeForm();
            nef.ShowDialog();
        }

        private void FillTable()
        {
            dgvZaposleni.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var zaposleni = (from c in context.employees select c).ToList();
                foreach (var c in zaposleni)
                {
                    DataGridViewRow r = new DataGridViewRow() { Tag = c };
                    r.CreateCells(dgvZaposleni);
                    //var to = c.DateTo;

                    r.SetValues(c.FirstName, c.LastName, c.Address, c.PID, c.E_mail);
                    dgvZaposleni.Rows.Add(r);

                }
            }
        }

    }
}
