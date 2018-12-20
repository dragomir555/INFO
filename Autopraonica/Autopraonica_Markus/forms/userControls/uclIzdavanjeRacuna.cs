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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Font = iTextSharp.text.Font;
using System.Globalization;




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

        private void populateRows(DataTable dt, string dateFrom, string dateTo) {
            using (MarkusDb context = new MarkusDb())
            {
                var listOfClientsUnpaidServices =
                (from les in context.legalentityservices
                 join cl in context.clients on les.Client_Id equals cl.Id
                 join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                 join plit in context.pricelistitems on nes.PricelistItem_Id equals plit.Id
                 join plin in context.pricelistitemnames on plit.PricelistItemName_Id equals plin.Id
                 join serTp in context.servicetypes on plit.ServiceType_Id equals serTp.Id
                 where cl.Name == cmbClients.Text
                 select new
                 {
                     serTp.Name,
                     les.FirstName,
                     priceName = plin.Name,
                     les.LastName,
                     nes.ServiceTime,
                     les.LicencePlate,
                     nes.Price,
                 }).ToList();
                int i = 1;
                foreach (var v in listOfClientsUnpaidServices)
                {
                    string serviceDate = v.ServiceTime.ToShortDateString();
                    if ((serviceDate.CompareTo(dateFrom) == -1 && dateTo.CompareTo(serviceDate) == -1) || true)
                    {
                        dt.Rows.Add(i++, v.Name, v.priceName, v.FirstName, v.LastName, serviceDate,v.LicencePlate, v.Price.ToString());
                        
                        //dodati ukupnu cijenu
                    }
                }
            }
        }

        private void searchUnpaidServices(string dateFrom, string dateTo, decimal suma) {

            using (MarkusDb context = new MarkusDb())
            {
                var listOfClientsUnpaidServices =
                (from les in context.legalentityservices
                 join cl in context.clients on les.Client_Id equals cl.Id
                 join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                 join plit in context.pricelistitems on nes.PricelistItem_Id equals plit.Id
                 join plin in context.pricelistitemnames on plit.PricelistItemName_Id equals plin.Id
                 join serTp in context.servicetypes on plit.ServiceType_Id equals serTp.Id
                 where cl.Name == cmbClients.Text
                 select new
                 {
                     serTp.Name,
                     les.FirstName,
                     priceName = plin.Name,
                     les.LastName,
                     nes.ServiceTime,
                     les.LicencePlate,
                     nes.Price,
                 }).ToList();
                int i = 1;
                foreach (var v in listOfClientsUnpaidServices)
                {
                    string serviceDate = v.ServiceTime.ToShortDateString();
                    if (true ||(serviceDate.CompareTo(dateFrom) == 1 && dateTo.CompareTo(serviceDate) == -1))   //promijeniti uslov
                    {
                        ListViewItem item = new ListViewItem(i++.ToString());
                        item.SubItems.Add(v.Name);
                        item.SubItems.Add(v.priceName);
                        item.SubItems.Add(v.FirstName);
                        item.SubItems.Add(v.LastName);
                        item.SubItems.Add(serviceDate);
                        item.SubItems.Add(v.LicencePlate);
                        item.SubItems.Add(v.Price.ToString());
                        suma += v.Price;
                        lvUpSer.Items.Add(item);
                        
                    }
                }

            }
        }

        private void btnDspUnpSer_Click(object sender, EventArgs e)
        {
            lvUpSer.Items.Clear();
            decimal suma = 0;
            string dateFrom = dtpDateFrom.Value.ToShortDateString();
            string dateTo = dtpDateTo.Value.ToShortDateString();

            fillListOfClients();
            searchUnpaidServices(dateFrom, dateTo, suma);
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
            if(areValidFields || true)//promijeniti uslov 
            {               
                lblPrice.Text = suma.ToString();
                
                if (lblPrice.Text == "0" && false) //promijeniti uslov
                    btnGenBill.Enabled = false;
                else
                    btnGenBill.Enabled = true; 
            }
        }

        private void fillListOfClients() {
            using (MarkusDb ctx = new MarkusDb())
            {
                var klijenti = (from les in ctx.legalentityservices
                                join cl in ctx.clients on les.Client_Id equals cl.Id
                                select new { legalentityservice = les, Contract = cl}).ToList();
            }
        }

        private void btnGenBill_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtbl = MakeDataTableForUnpaidServices();

                var month = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month - 1);

                Func<string> year = () => {
                    if (DateTime.Now.Month == 1)
                        return (DateTime.Now.Year - 1).ToString();
                    return (DateTime.Now.Year).ToString();
                };

                ExportDataTableOfUnpaidServicesToPdf(dtbl, @"D:\NeplaćeneUsluge" + month + year() + ".pdf", "AUTOPRAONICA MARKUS");
                ExportDataTableToPdf(dtbl, @"D:\RačunZa" + month + year() + ".pdf", "AUTOPRAONICA MARKUS");
                //if (cbxopen.checked)
                //{
                //        system.diagnostics.process.start(@"e:\test.pdf");
                //        this.windowstate = system.windows.forms.formwindowstate.minimized;
                //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }

        }

        DataTable MakeDataTable()
        {
            //Create friend table object
            DataTable friend = new DataTable();
          
            
            //Define columns
            friend.Columns.Add("Redni broj usluge");
            friend.Columns.Add("Vrsta usluge");
            friend.Columns.Add("Podvrsta usluge");
            friend.Columns.Add("Ime");
            friend.Columns.Add("Prezime");
            friend.Columns.Add("Datum usluge");
            friend.Columns.Add("Registarske\r\ntablice");
            friend.Columns.Add("Cijena");


           
            //Populate with unpaid services 
            string dateFrom = dtpDateFrom.Value.ToShortDateString();
            string dateTo = dtpDateTo.Value.ToShortDateString();
            populateRows(friend, dateFrom, dateTo);
            
            return friend;
        }

        DataTable MakeDataTableForUnpaidServices()
        {
            //Create friend table object
            DataTable friend = new DataTable();


            //Define columns
            friend.Columns.Add("Redni broj usluge");
            friend.Columns.Add("Datum usluge");
            friend.Columns.Add("Marka i tip vozila");
            friend.Columns.Add("Registarski broj\r\nvozila");
            friend.Columns.Add("Vrsta usluge"); 
            friend.Columns.Add("Potpis vozača");
            
            //Populate with unpaid services 
            string dateFrom = dtpDateFrom.Value.ToShortDateString();
            string dateTo = dtpDateTo.Value.ToShortDateString();
            populateRowsForUnpaidServices(friend, dateFrom, dateTo);

            return friend;
        }

        private void populateRowsForUnpaidServices(DataTable dt, string dateFrom, string dateTo)
        {
            using (MarkusDb context = new MarkusDb())
            {
                var listOfClientsUnpaidServices =
                (from les in context.legalentityservices
                 join cl in context.clients on les.Client_Id equals cl.Id
                 join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                 join cb in context.carbrands on nes.CarBrand_Id equals cb.Id
                 join plit in context.pricelistitems on nes.PricelistItem_Id equals plit.Id
                 join plin in context.pricelistitemnames on plit.PricelistItemName_Id equals plin.Id
                 join serTp in context.servicetypes on plit.ServiceType_Id equals serTp.Id
                 where cl.Name == cmbClients.Text
                 select new
                 {
                     serTp.Name,
                     les.FirstName,
                     priceName = plin.Name,
                     les.LastName,
                     nes.ServiceTime,
                     les.LicencePlate,
                     nes.Price,
                     carBrandName = cb.Name,
                 }).ToList();
                int i = 1;
                foreach (var v in listOfClientsUnpaidServices)
                {
                    string serviceDate = v.ServiceTime.ToShortDateString();
                    if ((serviceDate.CompareTo(dateFrom) == -1 && dateTo.CompareTo(serviceDate) == -1) || true)
                    {
                        dt.Rows.Add(i++, serviceDate, v.carBrandName, v.LicencePlate, v.Name, v.priceName);
                    }
                }
            }
        }


        void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 15, 1, iTextSharp.text.Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgCompanyInfo = new Paragraph();
            Paragraph prgAuthor = new Paragraph();

            Paragraph prgAuthor1 = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, iTextSharp.text.Color.GRAY);

            prgCompanyInfo.Alignment = Element.ALIGN_RIGHT;

            using (MarkusDb ctx = new MarkusDb())
            {
               var man = (from c in ctx.managers
                               where c != null
                               select c);

                prgAuthor.Add(new Chunk("Kreirao : Menadzer", fntAuthor));
            }
            prgAuthor1.Add(new Chunk("ssssiranja : " + DateTime.Now.ToShortDateString(), fntAuthor));
            prgAuthor1.Alignment = Element.ALIGN_RIGHT;

            prgAuthor.Add(new Chunk("\nDatum kreiranja : " + DateTime.Now.ToShortDateString(), fntAuthor));
            prgAuthor.Add(new Chunk("\nDatum kreiranja : " + DateTime.Now.ToShortDateString(), fntAuthor));
            prgAuthor.Add(new Chunk("\nDatum kreiranja : " + DateTime.Now.ToShortDateString(), fntAuthor));
            prgAuthor.Add(new Chunk("\nDatum kreiranja : " + DateTime.Now.ToShortDateString(), fntAuthor));

            prgCompanyInfo.Add(new Chunk("\nJIB : " + "000000000000", fntAuthor));
            prgCompanyInfo.Add(new Chunk("\nAdresa : " + "Patre 5", fntAuthor));
            prgCompanyInfo.Add(new Chunk("\nAdresa : " + "Patre 5", fntAuthor));
            prgCompanyInfo.Add(new Chunk("\nAdresa : " + "Patre 5", fntAuthor));
            

            document.Add(prgAuthor);
            document.Add(prgCompanyInfo);

            document.Add(prgAuthor1);
            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 6, 1, iTextSharp.text.Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
        
                }
            }
            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }
        
        void ExportDataTableOfUnpaidServicesToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 15, 1, iTextSharp.text.Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgContent = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, iTextSharp.text.Color.GRAY);

            var month = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month - 1); 

            Func<string> year = () => {
                if (DateTime.Now.Month == 1)
                    return (DateTime.Now.Year - 1).ToString();
                return (DateTime.Now.Year).ToString();
            };           
            prgContent.Add(new Chunk("\nPREGLED USLUGA PRANJA PUTNIČKIH VOZILA ZA : " + month  , fntAuthor));
            prgContent.Add(new Chunk("\n" + year() + ". GODINA  " + cmbClients.Text, fntAuthor));
            prgContent.Add(new Chunk("\n                                                     "));
            prgContent.Add(new Chunk("\n                                                     "));
            document.Add(prgContent);
 
            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 6, 1, iTextSharp.text.Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());

                }
            }
            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}

