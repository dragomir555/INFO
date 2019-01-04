using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Autopraonica_Markus.Model.Entities;
using System.Text.RegularExpressions;
using Autopraonica_Markus.forms.pricelistForms;
using System.Collections.Generic;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclCijenovnik : UserControl
    {
        private static uclCijenovnik instance;
        private int i = 1;
        Button btnAddService = new Button();

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
                    addTable(serviceType);
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
                    var pricelistItemName = new pricelistitemname()
                    {
                        Name = npi.Name
                    };

                    context.pricelistitemnames.Add(pricelistItemName);
                    context.SaveChanges();

                    var pricelistItem = new pricelistitem()
                    {
                        Price = npi.Price,
                        PricelistItemName_Id = pricelistItemName.Id,
                        ServiceType_Id = serviceType_id,
                        DateFrom = DateTime.Now,
                        Current = 1,

                    };
                    context.pricelistitems.Add(pricelistItem);
                    context.SaveChanges();
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
                    int pricelistItem_id = Int32.Parse(dgw.Rows[dgw.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    var pricelistItem = context.pricelistitems.Find(pricelistItem_id);
                    if(Decimal.Compare(pricelistItem.Price, npi.Price) != 0)
                    {
                        pricelistItem.DateTo = DateTime.Now;
                        pricelistItem.Current = 0;
                        context.SaveChanges();

                        var newPricelistItem = new pricelistitem()
                        {
                            Price = npi.Price,
                            PricelistItemName_Id = pricelistItem.PricelistItemName_Id,
                            ServiceType_Id = pricelistItem.ServiceType_Id,
                            DateFrom = DateTime.Now,
                            Current = 1,
                        };
                        context.pricelistitems.Add(newPricelistItem);
                        context.SaveChanges();
                        fillTable(this.Controls[dataGridViewName] as DataGridView, pricelistItem.ServiceType_Id);
                    }
                }
            }
        }

        private void btnDeletePricelistItem_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var resultString = Regex.Match(button.Name, @"\d+").Value;
            string dataGridViewName = "dataGridView" + resultString;
            DataGridView dgw = this.Controls[dataGridViewName] as DataGridView;
            using (MarkusDb context = new MarkusDb())
            {
                int pricelistItem_id = Int32.Parse(dgw.Rows[dgw.CurrentCell.RowIndex].Cells[2].Value.ToString());
                var pricelistItem = context.pricelistitems.Find(pricelistItem_id);
                pricelistItem.DateTo = DateTime.Now;
                pricelistItem.Current = 0;
                context.SaveChanges();
                fillTable(this.Controls[dataGridViewName] as DataGridView, pricelistItem.ServiceType_Id);
            }
        }



            private void addTables()
        {


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
                foreach(var s in serviceTypes)
                {
                    Label lbl = new Label();
                    MyDataGridView dgw = new MyDataGridView();
                    Button btnAddPricelistItem = new Button();
                    Button btnUpdatePricelistItem = new Button();
                    Button btnDeletePricelistItem = new Button();
                    this.Controls.Add(lbl);
                    this.Controls.Add(dgw);
                    this.Controls.Add(btnAddPricelistItem);
                    this.Controls.Add(btnUpdatePricelistItem);
                    this.Controls.Add(btnDeletePricelistItem);

                    lbl.Text = s.Name;
                    lbl.Location = new Point(24, 110 + (i-1) * 220);
                    lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
|                   System.Windows.Forms.AnchorStyles.Left)
|                   System.Windows.Forms.AnchorStyles.Right)));
                    lbl.Size = new Size(this.Width - 40, 20);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                    lbl.AutoSize = false;
                    lbl.SendToBack();

                    btnDeletePricelistItem.Name = "btnDeletePricelistItem" + s.Id;
                    btnDeletePricelistItem.Location = new Point(438, 285 + (i - 1) * 220);
                    btnDeletePricelistItem.Text = "Obrisi";
                    btnDeletePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Right)));
                    btnDeletePricelistItem.Size = new Size(70, 23);
                    btnDeletePricelistItem.Click += new EventHandler(btnDeletePricelistItem_Click);
                    btnDeletePricelistItem.AutoSize = false;
                    btnDeletePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
                    btnDeletePricelistItem.FlatStyle = FlatStyle.Flat;
                    btnDeletePricelistItem.ForeColor = Color.White;

                    btnUpdatePricelistItem.Name = "btnUpdatePricelistItem" + s.Id;
                    btnUpdatePricelistItem.Location = new Point(518, 285 + (i - 1) * 220);
                    btnUpdatePricelistItem.Text = "Izmijeni";
                    btnUpdatePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Right)));
                    btnUpdatePricelistItem.Size = new Size(70, 23);
                    btnUpdatePricelistItem.Click += new EventHandler(btnUpdatePricelistItem_Click);
                    btnUpdatePricelistItem.AutoSize = false;
                    btnUpdatePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
                    btnUpdatePricelistItem.FlatStyle = FlatStyle.Flat;
                    btnUpdatePricelistItem.ForeColor = Color.White;

                    btnAddPricelistItem.Name = "btnAddPricelistItem" + s.Id;
                    btnAddPricelistItem.Location = new Point(598, 285 + (i - 1) * 220);
                    btnAddPricelistItem.Text = "Dodaj";
                    btnAddPricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Right)));
                    btnAddPricelistItem.Size = new Size(70, 23);
                    btnAddPricelistItem.Click += new EventHandler(btnAddPricelistItem_Click);
                    btnAddPricelistItem.AutoSize = false;
                    btnAddPricelistItem.BackColor = Color.FromArgb(107, 65, 150);
                    btnAddPricelistItem.FlatStyle = FlatStyle.Flat;
                    btnAddPricelistItem.ForeColor = Color.White;

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
                    dgw.Location = new Point(21, 130 + (i - 1) * 220);
                    dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                    dgw.Size = new Size(this.Width - 40, 150);
                    dgw.AutoSize = false;
                    fillTable(dgw, s.Id);
                    dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    i++;
                }

                btnAddService.Text = "Dodaj novu vrstu usluge";
                btnAddService.Location = new Point(this.Width / 2 - btnAddService.Width / 2, 180 + (i - 1) * 220);
                btnAddService.Size = new Size(150, 40);
                btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top)));
                this.Controls.Add(btnAddService);
                btnAddService.Click += new EventHandler(btnAddServiceType_Click);
                btnAddService.BackColor = Color.FromArgb(107, 65, 150);
                btnAddService.FlatStyle = FlatStyle.Flat;
                btnAddService.ForeColor = Color.White;
            }
        }

        private void addTable(servicetype serviceType)
        {
            this.Controls.Remove(btnAddService);
            btnAddService.Dispose();

            DataGridView dgw = new DataGridView();
            Label lbl = new Label();
            Button btnAddPricelistItem = new Button();
            Button btnUpdatePricelistItem = new Button();
            Button btnDeletePricelistItem = new Button();
            this.Controls.Add(lbl);
            this.Controls.Add(dgw);
            this.Controls.Add(btnAddPricelistItem);
            this.Controls.Add(btnUpdatePricelistItem);
            this.Controls.Add(btnDeletePricelistItem);

            lbl.Text = serviceType.Name;
            lbl.Location = new Point(24,  (i - 1) * 220 - 20);
            lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
|           System.Windows.Forms.AnchorStyles.Left)
|           System.Windows.Forms.AnchorStyles.Right)));
            lbl.Size = new Size(this.Width - 60, 20);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            lbl.AutoSize = false;
            lbl.SendToBack();

            btnDeletePricelistItem.Name = "btnDeletePricelistItem" + serviceType.Id;
            btnDeletePricelistItem.Location = new Point(this.Width - 270, 155 + (i - 1) * 220);
            btnDeletePricelistItem.Text = "Obrisi";
            btnDeletePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Right)));
            btnDeletePricelistItem.Size = new Size(70, 23);
            btnDeletePricelistItem.Click += new EventHandler(btnDeletePricelistItem_Click);
            btnDeletePricelistItem.AutoSize = false;
            btnDeletePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
            btnDeletePricelistItem.FlatStyle = FlatStyle.Flat;
            btnDeletePricelistItem.ForeColor = Color.White;

            btnUpdatePricelistItem.Name = "btnUpdatePricelistItem" + serviceType.Id;
            btnUpdatePricelistItem.Location = new Point(this.Width - 190, 155 + (i - 1) * 220);
            btnUpdatePricelistItem.Text = "Izmijeni";
            btnUpdatePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Right)));
            btnUpdatePricelistItem.Size = new Size(70, 23);
            btnUpdatePricelistItem.Click += new EventHandler(btnUpdatePricelistItem_Click);
            btnUpdatePricelistItem.AutoSize = false;
            btnUpdatePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
            btnUpdatePricelistItem.FlatStyle = FlatStyle.Flat;
            btnUpdatePricelistItem.ForeColor = Color.White;

            btnAddPricelistItem.Name = "btnAddPricelistItem" + serviceType.Id;
            btnAddPricelistItem.Location = new Point(this.Width - 107, 155 + (i - 1) * 220);
            btnAddPricelistItem.Text = "Dodaj";
            btnAddPricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Right)));
            btnAddPricelistItem.Size = new Size(70, 23);
            btnAddPricelistItem.Click += new EventHandler(btnAddPricelistItem_Click);
            btnAddPricelistItem.AutoSize = false;
            btnAddPricelistItem.BackColor = Color.FromArgb(107, 65, 150);
            btnAddPricelistItem.FlatStyle = FlatStyle.Flat;
            btnAddPricelistItem.ForeColor = Color.White;

            dgw.Name = "dataGridView" + serviceType.Id;
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
            dgw.Location = new Point(21,  (i - 1) * 220);
            dgw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dgw.Size = new Size(this.Width - 60, 150);
            dgw.AutoSize = false;
            fillTable(dgw, serviceType.Id);
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            i++;

            btnAddService = new Button();
            btnAddService.Location = new Point(this.Width/2 - btnAddService.Width/2, 50 + (i-1) * 220);
            btnAddService.Text = "Dodaj novu vrstu usluge";
            btnAddService.Size = new Size(150, 40);
            btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top)));
            btnAddService.Click += new EventHandler(btnAddServiceType_Click);
            btnAddService.AutoSize = false;
            this.Controls.Add(btnAddService);
            btnAddService.BackColor = Color.FromArgb(107, 65, 150);
            btnAddService.FlatStyle = FlatStyle.Flat;
            btnAddService.ForeColor = Color.White;
        }

        private void fillTable(DataGridView dgw, int id)
        {
            dgw.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var pricelistitems =
                    (from pli in context.pricelistitems
                     join pln in context.pricelistitemnames on pli.PricelistItemName_Id equals pln.Id
                     where pli.ServiceType_Id == id && pli.Current == 1
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
