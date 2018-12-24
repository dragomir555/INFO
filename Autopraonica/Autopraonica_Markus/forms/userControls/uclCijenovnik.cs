using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Autopraonica_Markus.Model.Entities;
using System.Text.RegularExpressions;
using Autopraonica_Markus.forms.pricelistForms;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclCijenovnik : UserControl
    {
        private static uclCijenovnik instance;

        public static uclCijenovnik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclCijenovnik();
                }
                return instance;
            }
        }
        public uclCijenovnik()
        {
            InitializeComponent();
            addTables();
            //fillTables();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnAddServiceType_Click(object sender, EventArgs e)
        {

            NewServiceTypeForm nstf = new NewServiceTypeForm();
            if (DialogResult.OK == nstf.ShowDialog())
            {
                using (MarkusDb context = new MarkusDb())
                {
                    var serviceType = new servicetype()
                    {
                        Name = nstf.Name
                    };
                    context.servicetypes.Add(serviceType);
                    context.SaveChanges();
                    addTables();
                }
            }
        }

        private void btnAddPricelistItem_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var resultString = Regex.Match(button.Name, @"\d+").Value;
            string dataGridViewName = "dataGridView" + resultString;
            int serviceType_id = Int32.Parse(resultString);
            NewPricelistItem npi = new NewPricelistItem();
            if (DialogResult.OK == npi.ShowDialog())
            {
                using (MarkusDb context = new MarkusDb())
                {
                    var pricelistItem = new pricelistitem()
                    {
                        Price = npi.Price,
                        PricelistItemName_Id = npi.Id,
                        ServiceType_Id = serviceType_id,
                        DateFrom = DateTime.Now,
                        Current = 1,

                    };
                    context.pricelistitems.Add(pricelistItem);
                    context.SaveChanges();
                    Console.WriteLine("Da vidimo: " + this.Controls[dataGridViewName] + " STRING: " + resultString);
                    fillTable(this.Controls[dataGridViewName] as DataGridView, serviceType_id);
                }
            }

        }

        private void btnUpdatePricelistItem_Click(object sender, EventArgs e)
        {

            var button = (Button)sender;
            var resultString = Regex.Match(button.Name, @"\d+").Value;
            string dataGridViewName = "dataGridView" + resultString;
            DataGridView dgw = this.Controls[dataGridViewName] as DataGridView;
            UpdatePricelistItem npi = new UpdatePricelistItem(Int32.Parse(dgw.Rows[dgw.CurrentCell.RowIndex].Cells[2].Value.ToString()));
            if (DialogResult.OK == npi.ShowDialog())
            {
                using (MarkusDb context = new MarkusDb())
                {

                }
            }
        }

        private void btnDisplayPricelistItemNames_Click(object sender, EventArgs e)
        {
            DisplayPricelistItemNamesForm dpinf = new DisplayPricelistItemNamesForm();
            dpinf.ShowDialog();
        }

            private void addTables()
        {
            this.Controls.Clear();
            Label lblPriceList = new Label();
            this.Controls.Add(lblPriceList);
            lblPriceList.Text = "CJENOVNIK";
            lblPriceList.Location = new Point(27, 0);
            lblPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
|           System.Windows.Forms.AnchorStyles.Left)
|           System.Windows.Forms.AnchorStyles.Right)));
            lblPriceList.Size = new Size(this.Width - 40, 33);
            lblPriceList.TextAlign = ContentAlignment.MiddleCenter;
            lblPriceList.Font = new Font("Verdana", 20, FontStyle.Bold);
            using (MarkusDb context = new MarkusDb())
            {
                var serviceTypes = context.servicetypes;
                int i = 1;
                foreach(var s in serviceTypes)
                {
                    Label lbl = new Label();
                    DataGridView dgw = new DataGridView();
                    Button btnAddPricelistItem = new Button();
                    Button btnUpdatePricelistItem = new Button();
                    this.Controls.Add(lbl);
                    this.Controls.Add(dgw);
                    this.Controls.Add(btnAddPricelistItem);
                    this.Controls.Add(btnUpdatePricelistItem);

                    lbl.Text = s.Name;
                    lbl.Location = new Point(24, 80 + (i-1) * 200);
                    lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
|                   System.Windows.Forms.AnchorStyles.Left)
|                   System.Windows.Forms.AnchorStyles.Right)));
                    lbl.Size = new Size(this.Width - 40, 20);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                    lbl.SendToBack();

                    btnUpdatePricelistItem.Name = "btnUpdatePricelistItem" + s.Id;
                    btnUpdatePricelistItem.Location = new Point(440, 70 + (i - 1) * 200);
                    btnUpdatePricelistItem.Text = "Izmijeni stavku cjenovnika";
                    btnUpdatePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Right)));
                    btnUpdatePricelistItem.Size = new Size(140, 23);
                    btnUpdatePricelistItem.Click += new EventHandler(btnUpdatePricelistItem_Click);

                    btnAddPricelistItem.Name = "btnAddPricelistItem" + s.Id;
                    btnAddPricelistItem.Location = new Point(595, 70 + (i - 1) * 200);
                    btnAddPricelistItem.Text = "Dodaj stavku cjenovnika";
                    btnAddPricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Right)));
                    btnAddPricelistItem.Size = new Size(140, 23);
                    btnAddPricelistItem.Click += new EventHandler(btnAddPricelistItem_Click);

                    dgw.Name = "dataGridView" + s.Id;
                    dgw.ColumnCount = 3;
                    dgw.Columns[0].Name = "Naziv usluge";
                    dgw.Columns[1].Name = "Cijena";
                    dgw.Columns[2].Name = "Id";
                    dgw.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgw.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgw.Columns[2].Visible = false;
                    dgw.RowHeadersVisible = false;
                    dgw.AllowUserToAddRows = false;
                    dgw.AllowUserToDeleteRows = false;
                    dgw.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgw.Location = new Point(21, 100 + (i - 1) * 200);
                    dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                    dgw.Size = new Size(this.Width - 40, 150);
                    fillTable(dgw, s.Id);
                    i++;
                }

                Button btnAddService = new Button();
                btnAddService.Text = "Dodaj novu vrstu usluge";
                btnAddService.Location = new Point(21, 200 + (i - 1) * 200);
                btnAddService.Size = new Size(159, 23);
                btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
|               System.Windows.Forms.AnchorStyles.Left))));
                this.Controls.Add(btnAddService);
                btnAddService.Click += new EventHandler(btnAddServiceType_Click);

                Button btnDisplayPricelistNames = new Button();
                btnDisplayPricelistNames.Text = "Prikaz naziva stavki";
                btnDisplayPricelistNames.Location = new Point(200, 200 + (i - 1) * 200);
                btnDisplayPricelistNames.Size = new Size(159, 23);
                btnDisplayPricelistNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
|               System.Windows.Forms.AnchorStyles.Left))));
                this.Controls.Add(btnDisplayPricelistNames);
                btnDisplayPricelistNames.Click += new EventHandler(btnDisplayPricelistItemNames_Click);

            }
        }

        private void fillTable(DataGridView dgw, int id)
        {
            dgw.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var pricelistitems =
                    (from pli in context.pricelistitems
                     join pln in context.pricelistitemnames on pli.PricelistItemName_Id equals pln.Id
                     where pli.ServiceType_Id == id
                     select new
                     {
                         Name = pln.Name,
                         Price = pli.Price,
                         Id = pli.Id
                     }).ToList();
                foreach(var p in pricelistitems)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = p
                    };
                    row.CreateCells(dgw);
                    row.SetValues(p.Name, p.Price, p.Id);
                    dgw.Rows.Add(row);
                }
            }
        }

        private void btnServiceType_Click(object sender, EventArgs e)
        {

        }
    }
}
