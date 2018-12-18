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
using System.Data.Entity.SqlServer;
 

//**kod svih upita try catch blok
//**ispraviti greske z u ž, s u š itd.
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

        public void UpdateComboBox()
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
            lvUpSer.Items.Clear();
            string dateFrom = dtpDateFrom.Value.ToShortDateString();
            string dateTo = dtpDateTo.Value.ToShortDateString();
            fillListOfUnpaidServices();
            Boolean areValidFields = true;

            if (dateTo.CompareTo(dateFrom) == -1)
            {
                MessageBox.Show("Datum od mora biti prije datuma do.");
                areValidFields = false;
            }
            if (cmbClients.SelectedItem == null)
            {
                MessageBox.Show("Odaberite klijenta kojem zelite da izlistate neplacene usluge.");
                areValidFields = false;
            }
            if(areValidFields)
            {
                decimal suma = 0;
               
                using (MarkusDb context = new MarkusDb())
                {
                  var listOfClientsUnpaidServices = 
                  ( from les in context.legalentityservices
                    join cl in context.clients on les.Client_Id equals cl.Id
                    join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                    join plit in context.pricelistitems on nes.PricelistItem_Id equals plit.Id
                    join plin in context.pricelistitemnames on plit.PricelistItemName_Id equals plin.Id
                    join serTp in context.servicetypes on plit.ServiceType_Id equals serTp.Id
                    where cl.Name == cmbClients.Text
                  //  where  String.Compare((nes.ServiceTime.ToShortDateString()), dateFrom) >= 0 /* puca */
                    //where String.Compare(dateTo,s =nes.ServiceTime.ToShortDateString()) >= 0  /* puca */
                    select new { serTp.Name, les.FirstName, priceName = plin.Name ,les.LastName, nes.ServiceTime , les.LicencePlate, nes.Price}).ToList();
                    int i = 1;
                    foreach (var v in listOfClientsUnpaidServices)
                    {
                        ListViewItem item = new ListViewItem(i++.ToString());
                        item.SubItems.Add(v.Name);
                        item.SubItems.Add(v.priceName);
                        item.SubItems.Add(v.FirstName);
                        item.SubItems.Add(v.LastName);
                        item.SubItems.Add(v.ServiceTime.ToShortDateString());
                        item.SubItems.Add(v.LicencePlate);
                        item.SubItems.Add(v.Price.ToString());
                        suma += v.Price;
                        lvUpSer.Items.Add(item);
                    }
                }
                lblPrice.Text = suma.ToString();
                
                if (lblPrice.Text == "0")
                    btnGenBill.Enabled = false;
                else
                    btnGenBill.Enabled = true; 
            }
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
            Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();
            Aspose.Pdf.Generator.Section section1 = pdf.Sections.Add();
            Aspose.Pdf.Generator.Text text1 = new Aspose.Pdf.Generator.Text("Hello world...");
                section1.Paragraphs.Add(text1);
         
            pdf.Save("C:/Users/Nikola/Desktop/GenersianjeRacuna");
        }
    }
}
