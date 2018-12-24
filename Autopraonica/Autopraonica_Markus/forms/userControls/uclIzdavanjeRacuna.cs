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
            setColumnSize();
        }

        private void setColumnSize() {
            lvUpSer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvUpSer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            hdFirstName.Width = 70;
            hdSecName.Width = 70;
            hdPrice.Width = 55;
            hdTypeSer.Width = 100;
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

        private void populateRowsForBill(DataTable dt, DateTimePicker dateFrom, DateTimePicker dateTo) {
            using (MarkusDb context = new MarkusDb())
            {
                var listNamesOfServiceTypes =
                (from st in context.servicetypes
                 select new { st.Name}).ToList();
                
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
                decimal totalSumOfServiceType = 0;

                foreach (var stN in listNamesOfServiceTypes)
                {
                    totalSumOfServiceType = 0;
                    
                    foreach (var v in listOfClientsUnpaidServices)
                    {
                    var serviceDate = v.ServiceTime;
                    if ((serviceDate > dateFrom.Value) && (serviceDate < dateTo.Value) && stN.Name.Equals(v.Name))
                    {
                            totalSumOfServiceType += v.Price;
                    }}
                    if(totalSumOfServiceType !=0)
                        dt.Rows.Add(i++, stN.Name, totalSumOfServiceType);
                }
            }
    }


        private decimal searchUnpaidServices(DateTimePicker dateFrom, DateTimePicker dateTo) {
            decimal suma = 0;

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
                    var serviceDate = v.ServiceTime;
                    if ((serviceDate > dateFrom.Value) && (serviceDate < dateTo.Value))
                    {
                        ListViewItem item = new ListViewItem(i++.ToString());
                        item.SubItems.Add(v.Name);
                        item.SubItems.Add(v.priceName);
                        item.SubItems.Add(v.FirstName);
                        item.SubItems.Add(v.LastName);
                        item.SubItems.Add(serviceDate.ToShortDateString());
                        item.SubItems.Add(v.LicencePlate);
                        item.SubItems.Add(v.Price.ToString());
                        suma += v.Price;
                        lvUpSer.Items.Add(item);
                        
                    }
                }

            }
            return suma;
        }

        private void btnDspUnpSer_Click(object sender, EventArgs e)
        {
            lvUpSer.Items.Clear();
            DateTimePicker dateFrom = new DateTimePicker();
            dateFrom.Value = dtpDateFrom.Value;
            DateTimePicker dateTo = new DateTimePicker();
            dateTo.Value = dtpDateTo.Value;
  
            fillListOfClients();
            decimal suma = searchUnpaidServices(dateFrom, dateTo);
            Boolean areValidFields = true;

            int year = dateFrom.Value.Year - dateTo.Value.Year;
            int month = dateFrom.Value.Month - dateTo.Value.Month;
            int day = dateFrom.Value.Day - dateTo.Value.Day;
             
            if ((year > 0) || (year == 0 && month > 0 ) || (year == 0 && month == 0 && day > 0))
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
                lblPrice.Text = suma.ToString();
                
                if (lblPrice.Text == "0") 
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
                DataTable dtus = MakeDataTableForUnpaidServices();
                DataTable dtbl = MakeDataTableForBill();

                var month = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month - 1);

                Func<string> year = () => {
                    if (DateTime.Now.Month == 1)
                        return (DateTime.Now.Year - 1).ToString();
                    return (DateTime.Now.Year).ToString();
                };

                
                

                //make directory if not exists
                ExportDataTableOfUnpaidServicesToPdf(dtus, @"D:efp\NeplaćeneUsluge" + month + year() + ".pdf", "AUTOPRAONICA MARKUS");
                ExportDataTableForBillToPdf(dtbl, @"D:efp\RačunZa" + month + year() + ".pdf", "AUTOPRAONICA MARKUS");
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

        DataTable MakeDataTableForBill()
        {
            //Create friend table object
            DataTable friend = new DataTable();
          
            
            //Define columns
            friend.Columns.Add("R.b.");
            friend.Columns.Add("Naziv usluge");
            friend.Columns.Add("Iznos(KM)");

            
            //Populate with unpaid services 
            populateRowsForBill(friend, dtpDateFrom, dtpDateTo);
            
            return friend;
        }

        DataTable MakeDataTableForUnpaidServices()
        {
            //Create friend table object
            DataTable friend = new DataTable();


            //Define columns
            friend.Columns.Add("R.b.");
            friend.Columns.Add("Datum usluge");
            friend.Columns.Add("Marka i tip vozila");
            friend.Columns.Add("Registarski broj\r\nvozila");
            friend.Columns.Add("Vrsta usluge"); 
            friend.Columns.Add("Ime vozaca");
            friend.Columns.Add("Prezime vozaca");
            friend.Columns.Add("Cijena sa PDV-om");

            //Populate with unpaid services 
            populateRowsForUnpaidServices(friend, dtpDateFrom, dtpDateTo);

            return friend;
        }

        private void populateRowsForUnpaidServices(DataTable dt, DateTimePicker dateFrom, DateTimePicker dateTo)
        {
            using (MarkusDb context = new MarkusDb())
            {
                String clientName = cmbClients.Text;
                var listOfClientsUnpaidServices =
                (from les in context.legalentityservices
                 join cl in context.clients on les.Client_Id equals cl.Id
                 join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                 join cb in context.carbrands on nes.CarBrand_Id equals cb.Id
                 join plit in context.pricelistitems on nes.PricelistItem_Id equals plit.Id
                 join plin in context.pricelistitemnames on plit.PricelistItemName_Id equals plin.Id
                 join serTp in context.servicetypes on plit.ServiceType_Id equals serTp.Id
                 where cl.Name == clientName
                 select new
                 {
                     lesFsName = nes.legalentityservice.FirstName,
                     leseLtName = nes.legalentityservice.LastName,
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
                    var serviceDate = v.ServiceTime;
                    if ((serviceDate > dateFrom.Value) && (serviceDate < dateTo.Value))
                    {
                        dt.Rows.Add(i++, serviceDate.ToShortDateString() , v.carBrandName, v.LicencePlate, v.Name, v.FirstName , v.LastName, v.Price);
                    }
                }
            }
        }


        void ExportDataTableForBillToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 10, 1, iTextSharp.text.Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgCompanyInfo = new Paragraph();
            Paragraph prgAuthor = new Paragraph();
            Paragraph prgAuthor1 = new Paragraph();
            Paragraph prgBillNumb = new Paragraph();

            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 10, 2, iTextSharp.text.Color.GRAY);

            Paragraph prgAuthor2 = new Paragraph();
            
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            prgBillNumb.Alignment = Element.ALIGN_CENTER;

            prgCompanyInfo.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("\nUL.V.Putnika bb prop",boldFont));
            prgAuthor.Add(new Chunk("\nKoz.Dubica prop", boldFont));
            String clientName = cmbClients.Text;
            using (MarkusDb ctx = new MarkusDb()) {

                var cl = (from c in ctx.clients
                            where c.Name ==clientName
                            select c).FirstOrDefault();
                prgCompanyInfo.Add(new Chunk("\n" + cl.Name, boldFont));  
                prgCompanyInfo.Add(new Chunk("\n" + cl.Address, boldFont));
                prgCompanyInfo.Add(new Chunk("\n" + cl.city.PostCode, boldFont));
                prgCompanyInfo.Add(new Chunk("\n" + cl.city.Name, boldFont));
            }
            prgAuthor1.Alignment = Element.ALIGN_RIGHT;
            prgAuthor1.Add(new Chunk("\n"));
            string strDate = DateTime.Now.ToString("dd/MM/yyyy");
            prgAuthor1.Add(new Chunk("\n Datum izdavanja: " + strDate));
            prgAuthor1.Add(new Chunk("\n Za period: " + dtpDateFrom.Value.ToShortDateString() + " - " + dtpDateTo.Value.ToShortDateString() +" GOD."));
            prgAuthor.Add(new Chunk("\nJIB  property123214", boldFont));
            prgAuthor.Add(new Chunk("\nZ.r. property312311", boldFont));
            
            prgBillNumb.Add(new Chunk("RACUN BR. " + (DateTime.Now.Month-1) + "/" + Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)) , boldFont));

            document.Add(prgAuthor);
            document.Add(prgCompanyInfo);
            document.Add(prgBillNumb);
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

            table.SetWidths(new int[] { 1, 3, 3});

            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
        
                }
            }
            document.Add(table);

            Paragraph prgTotAm = new Paragraph();
            prgTotAm.Alignment = Element.ALIGN_RIGHT;
            prgTotAm.Add(new Chunk("\nUkupan iznos: " + lblPrice.Text + " KM"));
            document.Add(prgTotAm);

            Paragraph prgSignature = new Paragraph();
            prgSignature.Alignment = Element.ALIGN_LEFT;
            prgSignature.Add(new Chunk("\nMP                       " + "POTPIS"));
            document.Add(prgSignature); 

            document.Close();
            writer.Close();
            fs.Close();
        }

        String getNameOfMonth(int monthIndex) {
              switch (monthIndex) {
                case 1: return "Januar";
                case 2: return "Februar";
                case 3: return "Mart";
                case 4: return "April";
                case 5: return "Maj";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Avgust";
                case 9: return "Septembar";
                case 10:return "Oktobar";
                case 11:return "Novembar";
                case 12:return "Decembar";
                default: return null;
              }
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

            var monthIndex = DateTime.Now.Month - 1;
            var month = getNameOfMonth(monthIndex);

            Func<string> year = () => {
                if (DateTime.Now.Month == 1)
                    return (DateTime.Now.Year - 1).ToString();
                return (DateTime.Now.Year).ToString();
            };
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            prgContent.Add(new Chunk("\nPREGLED USLUGA PRANJA PUTNICKIH VOZILA ZA : " + month  , boldFont));
            prgContent.Add(new Chunk("\n" + year() + ". GODINA  " + cmbClients.Text, boldFont));
            prgContent.Add(new Chunk("\nRACUN BR. " + (DateTime.Now.Month - 1) + "/" + Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2, 2)), boldFont));
            prgContent.Add(new Chunk("\n                                                     "));
            prgContent.Add(new Chunk("\n                                                     "));
            document.Add(prgContent);
 
            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            table.SetWidths(new int[] { 1, 3, 2, 3, 3, 3,3, 2});

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

