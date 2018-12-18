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
using System.Data.SqlClient;
//**kod svih upita try catch blok
namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclIzdavanjeRacuna : UserControl
    {
        private static uclIzdavanjeRacuna instance;

        public static uclIzdavanjeRacuna Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclIzdavanjeRacuna();
                }
                return instance;
            }
        }

        public uclIzdavanjeRacuna()
        {
            InitializeComponent();
            UpdateComboBox();
        }

        public void UpdateComboBox() //bice potrebno ažuriranje pri dodavanju novog klijenta u bazu
        {
            cmbClients.Items.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var clients = (from c in context.clients select c).ToList();

                foreach(client c in clients)
                {
                    cmbClients.Items.Add(c.Name);
                }
            }
        }

        private void btnDspUnpSer_Click(object sender, EventArgs e)
        {
            string dateFrom = dtpDateFrom.Value.ToShortDateString();
            string dateTo = dtpDateTo.Value.ToShortDateString();
            fillListOfUnpaidServices();

            btnGenBill.Enabled = true; //ovdje mora neka izmjena koda
           
        }

        private void fillListOfUnpaidServices() {
            using (MarkusDb ctx = new MarkusDb())
            {
                var klijenti = (from les in ctx.legalentityservices
                                join cl in ctx.clients on les.Client_Id equals cl.Id
                                select new { legalentityservice = les, Contract = cl}).ToList();
            }
        }

        private void btnGenBill_Click(object sender, EventArgs e)
        {

        }
    }
}
