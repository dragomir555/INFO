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
using System.Data.Entity.Validation;
using System.Collections;
using Autopraonica_Markus.forms.dialogForm;




//**kod svih upita try catch blok
//**ispraviti greske z u ž, s u š itd.
namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclIzdavanjeRacuna : UserControl
    {
        private static uclIzdavanjeRacuna instance;
        private Boolean isFirstTime = true;
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
            updateComboBox();
            dtpFormat();
        }

        private void updateDgvBills()
        {
            dgvBills.Rows.Clear();
            String date = dtpYear.Value.Date.ToString("MM/dd/yyyy");
            String billMonth = date.ToString().Substring(0, 2);
            String billYear = date.ToString().Substring(8, 2);
            int dtpYr = dtpYear.Value.Year;

            if (cmbClients.Text != "  Odabir klijenta")
            {
                using (MarkusDb context = new MarkusDb())
            {
                
                    String clientName = cmbClients.Text;
                    var receipts = (from r in context.receipts
                                    join cl in context.clients on r.Client_Id equals cl.Id
                                    where cl.Name == clientName
                                    where r.DateFrom.Year == dtpYr
                                    select r).ToList();


                    Boolean isChecked;
                    foreach (var r in receipts)
                    {
                        DataGridViewRow rw = new DataGridViewRow() { Tag = r };
                        rw.CreateCells(dgvBills);

                        if (isPaid(r.Paid))
                            isChecked = true;
                        else
                            isChecked = false;

                        rw.SetValues(r.DateFrom.Month + "/" + r.DateFrom.Year, isChecked);
                        dgvBills.Rows.Add(rw);
                    }
                }
            }
            
        }

        private Boolean isPaid(sbyte paid)
        {
            if (paid.Equals(1))
                return true;
            return false;
        }



        private void dtpFormat()
        {
            dtpDateFrom.Format = DateTimePickerFormat.Custom;
            dtpDateFrom.CustomFormat = "MM-yyyy";
            DateTime newDateValue = new DateTime(dtpDateFrom.Value.Year, 1, 1);
            dtpDateFrom.Value = newDateValue;

            dtpDateFrom.ShowUpDown = true;
            dtpDateFrom.Height = 30;

            dtpYear.Format = DateTimePickerFormat.Custom;
            dtpYear.CustomFormat = "yyyy";
            newDateValue = new DateTime(dtpYear.Value.Year, 1, 1);
            dtpYear.Value = newDateValue;

            dtpYear.ShowUpDown = true;
            dtpYear.Height = 30;
            
            dtpDateFrom.MaxDate = DateTime.Now;
            dtpYear.MaxDate = DateTime.Now;
        }

        public void updateComboBox()
        {
            cmbClients.Items.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var clients = (from c in context.clients select c).ToList();
                foreach (client c in clients)
                {
                    cmbClients.Items.Add(c.Name);
                }
            }
        }

        private void populateRowsForBill(DataTable dt, DateTimePicker dateFrom)
        {
            using (MarkusDb context = new MarkusDb())
            {
                var listNamesOfServiceTypes =
                (from st in context.servicetypes
                 select new { st.Name }).ToList();

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

                        if (dateCondition(serviceDate) && stN.Name.Equals(v.Name))
                        {
                            totalSumOfServiceType += v.Price;
                        }
                    }
                    if (totalSumOfServiceType != 0)
                        dt.Rows.Add(i++, stN.Name, totalSumOfServiceType);
                }
            }
        }


        private Boolean dateCondition(DateTime serviceDate)
        {
            if ((dtpDateFrom.Value.Month == serviceDate.Month) && (dtpDateFrom.Value.Year == serviceDate.Year))
                return true;
            return false;
        }

        private decimal searchUnpaidServices(DateTimePicker dateFrom)
        {
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
                DateTime serviceDate;
                String formattedDate;

                foreach (var v in listOfClientsUnpaidServices)
                {
                    serviceDate = v.ServiceTime;
                    formattedDate = serviceDate.ToString("dd-MM-yyyy");
                    if (dateCondition(serviceDate))
                    {
                        ListViewItem item = new ListViewItem(i++.ToString());
                        item.SubItems.Add(v.Name);
                        item.SubItems.Add(v.priceName);
                        item.SubItems.Add(v.FirstName);
                        item.SubItems.Add(v.LastName);
                        item.SubItems.Add(formattedDate);
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

            fillListOfClients();
            decimal suma = searchUnpaidServices(dateFrom);

            lblPrice.Text = suma.ToString();

            if (cmbClients.Text.Equals("  Odabir klijenta"))
                MessageBox.Show("Molimo Vas odaberite klijenta.");
            else if (lblPrice.Text == "0")
                btnGenBill.Enabled = false;
            else
                btnGenBill.Enabled = true;
        }

        private void fillListOfClients()
        {
            using (MarkusDb ctx = new MarkusDb())
            {
                var klijenti = (from les in ctx.legalentityservices
                                join cl in ctx.clients on les.Client_Id equals cl.Id
                                select new { legalentityservice = les, Contract = cl }).ToList();
            }
        }

        private void btnGenBill_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtus = MakeDataTableForUnpaidServices();
                DataTable dtbl = MakeDataTableForBill();

                String date = dtpDateFrom.Value.Date.ToString("MM/dd/yyyy");
                String year = date.ToString().Substring(6, 4);

                int monthIndex = dtpDateFrom.Value.Month;
                int yearIndex = dtpDateFrom.Value.Year;
                String month = getNameOfMonth(monthIndex);
                Autopraonica_Markus.Model.Entities.receipt rec = null;
                string path = null;

                try
                {
                    using (MarkusDb context = new MarkusDb())
                    {
                        var cl = (from c in context.clients
                                  where c.Name == cmbClients.Text
                                  select c).First();

                        rec = (from r in context.receipts
                               where r.PDF != null
                               where r.DateFrom.Month == monthIndex
                               where r.DateFrom.Year == yearIndex
                               select r).FirstOrDefault();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                       .SelectMany(x => x.ValidationErrors)
                       .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);


                }


                if (rec != null)
                { 
                    DialogResult dialogResult = MessageBox.Show("Račun je već generisan.Da li zelite ponovo da sačuvate PDF?", "Generisanje računa", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        String filePath;
                        String filePath1;

                        saveFileDialog.FileName = "Usluge" + cmbClients.Text.ToUpper() + month + year;
                        saveFileDialog.Filter = "Pdf files (*.Pdf)|*.Pdf";
                        saveFileDialog.DefaultExt = "pdf";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = saveFileDialog.FileName;
                            filePath1 = filePath.Replace("Usluge", "Racun");
                            System.IO.File.WriteAllBytes(filePath, rec.PDF);
                            System.IO.File.WriteAllBytes(filePath1, rec.PDF_TABLE);
                        }
                    }
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = "Usluge" + cmbClients.Text.ToUpper() + month + year;
                    saveFileDialog.Filter = "Pdf files (*.Pdf)|*.Pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    String compName = Properties.Settings.Default.Name;
                    String filePath;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        ExportDataTableOfUnpaidServicesToPdf(dtus, @"" + filePath, compName.ToUpper());
                        ExportDataTableForBillToPdf(dtbl, @"" + filePath, compName.ToUpper());
                        databaseFilePut(filePath);
                        MessageBox.Show("Uspješno generisan PDF", "PDF");
                    }
                    else
                        MessageBox.Show("Neuspješno generisan PDF", "PDF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }

        }

        private void databaseFilePut(string varFilePath)
        {
            byte[] file;
            byte[] file1;

            string outputPDF = varFilePath.Replace("Usluge", "Racun");

            using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }

            using (var stream = new FileStream(outputPDF, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file1 = reader.ReadBytes((int)stream.Length);
                }
            }

            try
            {
                int days = DateTime.DaysInMonth(dtpDateFrom.Value.Year, dtpDateFrom.Value.Month);
                String date = dtpDateFrom.Value.Date.ToString("MM/dd/yyyy");
                String dateFrom = date.ToString().Substring(6, 4) + "-" + date.ToString().Substring(0, 2) + "-01";
                String dateTo = date.ToString().Substring(6, 4) + "-" + date.ToString().Substring(0, 2) + "-"+ days.ToString();

                DateTime dtFrom = DateTime.Parse(dateFrom);
                DateTime dtTo = DateTime.Parse(dateTo);
                using (MarkusDb context = new MarkusDb())
                {
                    var emp = (from e in context.employees
                               join emrec in context.employeerecords on e.Id equals emrec.Employee_Id
                               where emrec.LogoutTime != null
                               select e).First();

                    var cl = (from c in context.clients
                              where c.Name == cmbClients.Text
                              select c).First();

                    var rec = new receipt()
                    {
                        DateFrom = dtFrom,
                        DateTo = dtTo,
                        PDF = file,
                        PDF_TABLE = file1,
                        Paid = 0,
                        Client_Id = cl.Id,
                        Manager_Id = emp.Id
                    };

                    context.receipts.Add(rec);
                    context.SaveChanges();
                    System.IO.File.WriteAllBytes(varFilePath, rec.PDF);
                    System.IO.File.WriteAllBytes(outputPDF, rec.PDF_TABLE);
                }
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                   .SelectMany(x => x.ValidationErrors)
                   .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);


            }
        }

        DataTable MakeDataTableForBill()
        {
            //Create friend table object
            DataTable friend = new DataTable();


            //Define columns
            friend.Columns.Add("R.b.");
            friend.Columns.Add("Naziv usluge");
            friend.Columns.Add("Iznos (KM)");


            //Populate with unpaid services 
            populateRowsForBill(friend, dtpDateFrom);

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
            friend.Columns.Add("Ime i prezime vozaca");
            friend.Columns.Add("Cijena sa PDV-om (KM)");

            //Populate with unpaid services 
            populateRowsForUnpaidServices(friend, dtpDateFrom);

            return friend;
        }

        private void populateRowsForUnpaidServices(DataTable dt, DateTimePicker dateFrom)
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
                    if (dateCondition(serviceDate))
                    {
                        dt.Rows.Add(i++, serviceDate.ToShortDateString(), v.carBrandName, v.LicencePlate, v.Name, v.FirstName + " " + v.LastName, v.Price);
                    }
                }
            }
        }


        void ExportDataTableForBillToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
            string outputPDF = strPdfPath.Replace("Usluge", "Racun");

            System.IO.FileStream fs = new FileStream(outputPDF, FileMode.Create, FileAccess.Write, FileShare.None);
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
            prgAuthor.Add(new Chunk("\nUL." + Properties.Settings.Default.Address, boldFont));
            prgAuthor.Add(new Chunk("\nKoz.Dubica", boldFont));
            String clientName = cmbClients.Text;
            using (MarkusDb ctx = new MarkusDb())
            {

                var cl = (from c in ctx.clients
                          where c.Name == clientName
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
            String date = dtpDateFrom.Value.Date.ToString("MM/dd/yyyy");
            prgAuthor1.Add(new Chunk("\n Za period: 01." + date.ToString().Substring(0, 2) + ". - 31." + date.ToString().Substring(0, 2) + "." + date.ToString().Substring(6, 4) + ". GOD."));
            prgAuthor.Add(new Chunk("\nJIB: " + Properties.Settings.Default.UID, boldFont));
            prgAuthor.Add(new Chunk("\nZiro racun: " + Properties.Settings.Default.AccountNumber, boldFont));

            prgBillNumb.Add(new Chunk("RACUN BR. " + date.ToString().Substring(0, 2) + "/" + date.ToString().Substring(8, 2), boldFont));

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

            table.SetWidths(new int[] { 1, 3, 3 });

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
            prgSignature.Add(new Chunk("\nMP                                                    " + "POTPIS"));
            document.Add(prgSignature);



            document.Close();
            writer.Close();
            fs.Close();

        }

        String getNameOfMonth(int monthIndex)
        {
            switch (monthIndex)
            {
                case 1: return "Januar";
                case 2: return "Februar";
                case 3: return "Mart";
                case 4: return "April";
                case 5: return "Maj";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Avgust";
                case 9: return "Septembar";
                case 10: return "Oktobar";
                case 11: return "Novembar";
                case 12: return "Decembar";
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

            var monthIndex = dtpDateFrom.Value.Month;
            var month = getNameOfMonth(monthIndex);

            Func<string> year = () =>
            {
                if (DateTime.Now.Month == 1)
                    return (DateTime.Now.Year - 1).ToString();
                return (DateTime.Now.Year).ToString();
            };
            String date = dtpDateFrom.Value.Date.ToString("MM/dd/yyyy");
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            prgContent.Add(new Chunk("\nPREGLED USLUGA PRANJA PUTNICKIH VOZILA ZA : " + month, boldFont));
            prgContent.Add(new Chunk("\n" + year() + ". GODINA  " + cmbClients.Text, boldFont));
            prgContent.Add(new Chunk("\nRACUN BR. " + date.ToString().Substring(0, 2) + "/" + date.ToString().Substring(8, 2), boldFont));
            prgContent.Add(new Chunk("\n                                                     "));
            prgContent.Add(new Chunk("\n                                                     "));
            document.Add(prgContent);

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            table.SetWidths(new int[] { 1, 3, 2, 3, 3, 3, 3 });

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

        private void uclIzdavanjeRacuna_Resize(object sender, EventArgs e)
        {
            resizeColumns(lvUpSer);
        }

        private void resizeColumns(ListView lv)
        {
            int lvWidth = lv.Width;
            int clmnWidth;

            if (lvWidth > 1000)
            {
                clmnWidth = lvWidth / 7;
            }

            else if (lvWidth > 600)
           {
            clmnWidth = lvWidth / 8;
           }
            else
           {
            clmnWidth = lvWidth / 8 + 10;
           }

            int sum = 0;
            foreach (ColumnHeader column in lv.Columns)
            {
                if (!(column.Text.Equals("R.b.")))
                    column.Width = clmnWidth;
                if (column.Text.Equals("Registarske tablice") || column.Text.Equals("Podvrsta usluge") || column.Text.Equals("Vrsta usluge"))
                    column.Width = clmnWidth + 25;
                if (column.Text.Equals("Cijena"))
                {
                    column.Width = lvWidth - sum;
                    if (column.Width == 50)
                        column.Width += 7;
                }
                sum += column.Width;
            }
        }

        private void lvUpSer_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.lvUpSer.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void cmbClients_SelectedValueChanged(object sender, EventArgs e)
        {
            lvUpSer.Items.Clear();
            updateDgvBills();
            lblPrice.Text = "0";
        }

        private void dtpYear_ValueChanged(object sender, EventArgs e)
        {
            if (cmbClients.Text != "  Odabir klijenta")
                updateDgvBills();
            else if (!isFirstTime)  
                MessageBox.Show("Molimo Vas odaberite klijenta");
            else
                isFirstTime = false;
        }

        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBills.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvBills_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            if (dgvBills.Rows.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Da li želite promijeniti stanje racuna?", "Izdanje računa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                { 
                String cellValue = dgvBills.Rows[e.RowIndex].Cells[0].Value.ToString();
                   String month = cellValue.Substring(0, 2);
                   String year = cellValue.Substring(3, 4);
                   String clientName = cmbClients.Text;
                   receipt rec = null;

                    try
                        {
                            using (MarkusDb context = new MarkusDb())
                            {
                                rec = (from r in context.receipts
                                       join cl in context.clients on r.Client_Id equals cl.Id
                                       where cl.Name == clientName
                                       where r.DateFrom.Year.ToString() == year
                                       where r.DateFrom.Month.ToString() == month
                                       select r).FirstOrDefault();
                                context.receipts.Attach(rec);
                                if (dgvBills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                                {
                                    rec.Paid = 1;
                                }
                                else
                                {
                                    rec.Paid = 0;
                                }

                                context.SaveChanges();

                            }

                        }
                        catch (DbEntityValidationException ex)
                        {
                            var errorMessages = ex.EntityValidationErrors
                               .SelectMany(x => x.ValidationErrors)
                               .Select(x => x.ErrorMessage);

                            // Join the list to a single string.
                            var fullErrorMessage = string.Join("; ", errorMessages);

                            // Combine the original exception message with the new one.
                            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                            // Throw a new DbEntityValidationException with the improved exception message.
                            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);


                        }
                    }
                updateDgvBills();
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            String month = getNameOfMonth(dtpDateFrom.Value.Month).ToUpper();
            String year = dtpDateFrom.Value.Year.ToString().ToUpper();
            lblMtYr.Text = month  + " " + year;
        }

        private void lvUpSer_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.lvUpSer.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void lblPrice_TextChanged(object sender, EventArgs e)
        {
            if ("0".Equals(lblPrice.Text))
                btnGenBill.Enabled = false;
        }
    }
}

