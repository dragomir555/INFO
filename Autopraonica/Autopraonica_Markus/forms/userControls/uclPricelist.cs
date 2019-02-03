using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Autopraonica_Markus.Model.Entities;
using System.Text.RegularExpressions;
using Autopraonica_Markus.forms.pricelistForms;
using System.Collections.Generic;
using System.IO;
using Autopraonica_Markus.forms.dialogForm;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclPricelist : UserControl
    {
        private static uclPricelist instance;
        private int i = 1;
        private int rb = 1;
        Button btnAddService = new Button();

        public static uclPricelist Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new uclPricelist();
                }
                return instance;
            }
        }
        public uclPricelist()
        {

            InitializeComponent();
            addTables();
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
            DataGridView dgv = this.Controls[dataGridViewName] as DataGridView;
            if (dgv.CurrentCell != null)
            {
                UpdatePricelistItem npi = new UpdatePricelistItem(Int32.Parse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString()));
                if (DialogResult.OK == npi.ShowDialog())
                {
                    using (MarkusDb context = new MarkusDb())
                    {
                        int pricelistItem_id = Int32.Parse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString());
                        var pricelistItem = context.pricelistitems.Find(pricelistItem_id);
                        if (Decimal.Compare(pricelistItem.Price, npi.Price) != 0)
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
            else
            {
                MessageBox.Show("Nemate stavki za izmjenu", "Obavjestenje o izmjeni", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite obrisati tabelu?", "Brisanje tabele", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var button = (Button)sender;
                var resultString = Regex.Match(button.Name, @"\d+").Value;
                string dataGridViewName = "dataGridView" + resultString;
                DataGridView dgv = this.Controls[dataGridViewName] as DataGridView;
                using (MarkusDb context = new MarkusDb())
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        int pricelistItem_id = Int32.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                        var pricelistItem = context.pricelistitems.Find(pricelistItem_id);
                        pricelistItem.DateTo = DateTime.Now;
                        pricelistItem.Current = 0;
                        context.SaveChanges();
                    }
                    Label lbl = this.Controls["label" + resultString] as Label;
                    Button btnAddPricelistItem = this.Controls["btnAddPricelistItem" + resultString] as Button;
                    Button btnUpdatePricelistItem = this.Controls["btnUpdatePricelistItem" + resultString] as Button;
                    Button btnDeletePricelistItem = this.Controls["btnDeletePricelistItem" + resultString] as Button;
                    int redniBroj = Int32.Parse(Regex.Match(button.Name, @"\d+").Value);
                    btnAddPricelistItem.Dispose();
                    btnDeletePricelistItem.Dispose();
                    dgv.Dispose();
                    lbl.Dispose();
                    button.Dispose();
                    btnUpdatePricelistItem.Dispose();
                    this.Controls.Remove(dgv);
                    this.Controls.Remove(lbl);
                    this.Controls.Remove(btnAddPricelistItem);
                    this.Controls.Remove(btnUpdatePricelistItem);
                    this.Controls.Remove(btnDeletePricelistItem);
                    this.Controls.Remove(button);
                    Console.WriteLine("AAAAAAAAAAAAAA " + redniBroj);
                    for (int j = redniBroj + 1; j < i; j++)
                    {
                        int tmp = j - 1;
                        DataGridView dgv2 = this.Controls["dataGridView" + j] as DataGridView;
                        Label lbl2 = this.Controls["label" + j] as Label;
                        Button btnAddPricelistItem2 = this.Controls["btnAddPricelistItem" + j] as Button;
                        Button btnUpdatePricelistItem2 = this.Controls["btnUpdatePricelistItem" + j] as Button;
                        Button btnDeletePricelistItem2 = this.Controls["btnDeletePricelistItem" + j] as Button;
                        Button btnDeleteTable2 = this.Controls["btnDeleteTable" + j] as Button;
                        dgv2.Location = new Point(21, (j - 2) * 220);
                        dgv2.Name = "dataGridView" + tmp;
                        lbl2.Location = new Point((this.ClientSize.Width - lbl.Size.Width) / 2, (j - 2) * 220 - 20);
                        lbl2.Name = "label" + tmp;
                        btnAddPricelistItem2.Location = new Point(this.Width - 127, 155 + (j - 2) * 220);
                        btnAddPricelistItem2.Name = "btnAddPricelistItem" + tmp;
                        btnUpdatePricelistItem2.Location = new Point(this.Width - 227, 155 + (j - 2) * 220);
                        btnUpdatePricelistItem2.Name = "btnUpdatePricelistItem" + tmp;
                        btnDeletePricelistItem2.Location = new Point(this.Width - 327, 155 + (j - 2) * 220);
                        btnDeletePricelistItem2.Name = "btnDeletePricelistItem" + tmp;
                        btnDeleteTable2.Location = new Point(lbl2.Left + lbl2.Width - 10, (j - 2) * 220 - 20);
                        btnDeleteTable2.Name = "btnDeleteTable" + tmp;
                    }
                    i--;
                    rb--;
                    btnAddService.Location = new Point(this.Width / 2 - btnAddService.Width / 2, 50 + (i - 1) * 220);
                    // addTables();
                }
            }
        }


        private void btnDeletePricelistItem_Click(object sender, EventArgs e)
        {

            var button = (Button)sender;
            var resultString = Regex.Match(button.Name, @"\d+").Value;
            string dataGridViewName = "dataGridView" + resultString;
            DataGridView dgv = this.Controls[dataGridViewName] as DataGridView;
            if (dgv.CurrentCell != null)
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite obrisati stavku?", "Brisanje stavke", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (MarkusDb context = new MarkusDb())
                    {
                        int pricelistItem_id = Int32.Parse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString());
                        var pricelistItem = context.pricelistitems.Find(pricelistItem_id);
                        pricelistItem.DateTo = DateTime.Now;
                        pricelistItem.Current = 0;
                        context.SaveChanges();
                        fillTable(this.Controls[dataGridViewName] as DataGridView, pricelistItem.ServiceType_Id);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nemate stavki za brisanje", "Obavjestenje o brisanju", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private Boolean isEmpty(servicetype s)
        {
            using (MarkusDb context = new MarkusDb())
            {
                var pricelistitems = (
                    from pli in context.pricelistitems
                    where pli.ServiceType_Id == s.Id
                    select pli
                    ).ToList();
                int count = pricelistitems.Count;
                int tmp = 0;
                foreach (var p in pricelistitems)
                {
                    if (p.Current == 0)
                    {
                        tmp++;
                    }
                }
                if (count == tmp)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void addTables()
        {

            this.Controls.Clear();
            Label lblPriceList = new Label();
            this.Controls.Add(lblPriceList);
            lblPriceList.Text = "CJENOVNIK";
            lblPriceList.Location = new Point(27, 0);
            lblPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            lblPriceList.Size = new Size(this.Width - 40, 33);
            lblPriceList.TextAlign = ContentAlignment.MiddleCenter;
            lblPriceList.Font = new Font("Verdana", 20, FontStyle.Bold);
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            using (MarkusDb context = new MarkusDb())
            {
                var serviceTypes = context.servicetypes;
                foreach (var s in serviceTypes)
                {
                    if (!isEmpty(s))
                    {
                        Label lbl = new Label();
                        MyDataGridView dgv = new MyDataGridView();
                        Button btnDeleteTable = new Button();
                        Button btnAddPricelistItem = new Button();
                        Button btnUpdatePricelistItem = new Button();
                        Button btnDeletePricelistItem = new Button();
                        this.Controls.Add(lbl);
                        this.Controls.Add(dgv);
                        this.Controls.Add(btnDeleteTable);
                        this.Controls.Add(btnAddPricelistItem);
                        this.Controls.Add(btnUpdatePricelistItem);
                        this.Controls.Add(btnDeletePricelistItem);

                        lbl.Name = "label" + rb;
                        lbl.Text = s.Name;
                        lbl.Anchor = AnchorStyles.Top;
                        lbl.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        Size size = TextRenderer.MeasureText(s.Name, lbl.Font);
                        lbl.Size = new Size(size.Width + 20, size.Height);
                        lbl.AutoSize = false;
                        lbl.Location = new Point((this.ClientSize.Width - lbl.Size.Width) / 2, 110 + (i - 1) * 220);
                        lbl.SendToBack();

                        btnDeleteTable.Name = "btnDeleteTable" + rb; ;
                        btnDeleteTable.Location = new Point(lbl.Left + lbl.Width - 10, 110 + (i - 1) * 220);
                        btnDeleteTable.Anchor = AnchorStyles.Top;
                        btnDeleteTable.Size = new Size(20, 17);
                        btnDeleteTable.AutoSize = false;
                        btnDeleteTable.FlatStyle = FlatStyle.Flat;
                        btnDeleteTable.FlatAppearance.BorderSize = 0;
                        btnDeleteTable.Click += new EventHandler(btnDeleteTable_Click);
                        btnDeleteTable.Image = Image.FromFile(projectDirectory + "/resources/Hopstarter-Button-Button-Close.ico");
                        btnDeleteTable.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDeleteTable.BringToFront();

                        btnDeletePricelistItem.Name = "btnDeletePricelistItem" + rb;
                        btnDeletePricelistItem.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                        btnDeletePricelistItem.Location = new Point(this.Width - 307, 285 + (i - 1) * 220);
                        btnDeletePricelistItem.Text = "Obriši";
                        btnDeletePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                        | System.Windows.Forms.AnchorStyles.Right)));
                        btnDeletePricelistItem.Size = new Size(90, 35);
                        btnDeletePricelistItem.Click += new EventHandler(btnDeletePricelistItem_Click);
                        btnDeletePricelistItem.AutoSize = false;
                        btnDeletePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
                        btnDeletePricelistItem.FlatStyle = FlatStyle.Flat;
                        btnDeletePricelistItem.ForeColor = Color.White;
                //        btnDeletePricelistItem.Image = Image.FromFile(projectDirectory + "/resources/282471-24.png");
                        btnDeletePricelistItem.ImageAlign = ContentAlignment.MiddleLeft;

                        btnUpdatePricelistItem.Name = "btnUpdatePricelistItem" + rb;
                        btnUpdatePricelistItem.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                        btnUpdatePricelistItem.Location = new Point(this.Width - 207, 285 + (i - 1) * 220);
                        btnUpdatePricelistItem.Text = "Izmijeni";
                        btnUpdatePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                        | System.Windows.Forms.AnchorStyles.Right)));
                        btnUpdatePricelistItem.Size = new Size(90, 35);
                        btnUpdatePricelistItem.Click += new EventHandler(btnUpdatePricelistItem_Click);
                        btnUpdatePricelistItem.AutoSize = false;
                        btnUpdatePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
                        btnUpdatePricelistItem.FlatStyle = FlatStyle.Flat;
                        btnUpdatePricelistItem.ForeColor = Color.White;
               //         btnUpdatePricelistItem.Image = Image.FromFile(projectDirectory + "/resources/2571204-24.png");
                        btnUpdatePricelistItem.ImageAlign = ContentAlignment.MiddleLeft;

                        btnAddPricelistItem.Name = "btnUpdatePricelistItem" + rb;
                        btnAddPricelistItem.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                        btnAddPricelistItem.Name = "btnAddPricelistItem" + rb;
                        btnAddPricelistItem.Location = new Point(this.Width - 107, 285 + (i - 1) * 220);
                        btnAddPricelistItem.Text = "Dodaj";
                        btnAddPricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
                        | System.Windows.Forms.AnchorStyles.Right)));
                        btnAddPricelistItem.Size = new Size(90, 35);
                        btnAddPricelistItem.Click += new EventHandler(btnAddPricelistItem_Click);
                        btnAddPricelistItem.AutoSize = false;
                        btnAddPricelistItem.BackColor = Color.FromArgb(107, 65, 150);
                        btnAddPricelistItem.FlatStyle = FlatStyle.Flat;
                        btnAddPricelistItem.ForeColor = Color.White;
                 //       btnAddPricelistItem.Image = Image.FromFile(projectDirectory + "/resources/299068-24.png");
                        btnAddPricelistItem.ImageAlign = ContentAlignment.MiddleLeft;

                        dgv.Name = "dataGridView" + rb;
                        dgv.ColumnCount = 3;
                        dgv.Columns[0].Name = "Naziv usluge";
                        dgv.Columns[1].Name = "Cijena";
                        dgv.Columns[2].Name = "Id";
                        dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgv.Columns[2].Visible = false;
                        dgv.RowHeadersVisible = false;
                        dgv.AllowUserToAddRows = false;
                        dgv.AllowUserToDeleteRows = false;
                        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgv.Location = new Point(21, 130 + (i - 1) * 220);
                        dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                        dgv.Size = new Size(this.Width - 40, 150);
                        dgv.AutoSize = false;
                        dgv.ReadOnly = true;
                        dgv.MultiSelect = false;
                        dgv.BackgroundColor = Color.White;
                        fillTable(dgv, s.Id);
                        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                        i++;
                        rb++;
                    }
                }

                btnAddService.Text = "Dodaj novu vrstu usluge";
                btnAddService.Size = new Size(200, 40);
                btnAddService.Location = new Point(this.Width / 2 - btnAddService.Width / 2, 130 + (i - 1) * 220);
                btnAddService.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top)));
                this.Controls.Add(btnAddService);
                btnAddService.Click += new EventHandler(btnAddServiceType_Click);
                btnAddService.BackColor = Color.FromArgb(107, 65, 150);
                btnAddService.FlatStyle = FlatStyle.Flat;
                btnAddService.ForeColor = Color.White;
            //    btnAddService.Image = Image.FromFile(projectDirectory + "/resources/299068-24.png");
                btnAddService.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void addTable(servicetype serviceType)
        {
            this.Controls.Remove(btnAddService);
            btnAddService.Dispose();

            MyDataGridView dgv = new MyDataGridView();
            Label lbl = new Label();
            Button btnDeleteTable = new Button();
            Button btnAddPricelistItem = new Button();
            Button btnUpdatePricelistItem = new Button();
            Button btnDeletePricelistItem = new Button();
            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
            this.Controls.Add(btnAddPricelistItem);
            this.Controls.Add(btnUpdatePricelistItem);
            this.Controls.Add(btnDeletePricelistItem);
            this.Controls.Add(btnDeleteTable);


            lbl.Name = "label" + rb;
            lbl.Text = serviceType.Name;
            lbl.Anchor = AnchorStyles.Top;
            lbl.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            Size size = TextRenderer.MeasureText(serviceType.Name, lbl.Font);
            lbl.Size = new Size(size.Width + 20, size.Height);
            lbl.AutoSize = false;
            lbl.Location = new Point((this.ClientSize.Width - lbl.Size.Width) / 2, (i - 1) * 220 - 20);
            lbl.SendToBack();

            btnDeleteTable.Name = "btnDeleteTable" + rb;
            btnDeleteTable.Location = new Point(lbl.Left + lbl.Width - 10, (i - 1) * 220 - 20);
            btnDeleteTable.Anchor = AnchorStyles.Top;
            btnDeleteTable.Size = new Size(20, 17);
            btnDeleteTable.AutoSize = false;
            btnDeleteTable.FlatStyle = FlatStyle.Flat;
            btnDeleteTable.FlatAppearance.BorderSize = 0;
            btnDeleteTable.Click += new EventHandler(btnDeleteTable_Click);
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            btnDeleteTable.Image = Image.FromFile(projectDirectory + "/resources/Hopstarter-Button-Button-Close.ico");
            btnDeleteTable.ImageAlign = ContentAlignment.MiddleCenter;
            btnDeleteTable.BringToFront();

            btnDeletePricelistItem.Name = "btnDeletePricelistItem" + rb;
            btnDeletePricelistItem.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            btnDeletePricelistItem.Location = new Point(this.Width - 327, 155 + (i - 1) * 220);
            btnDeletePricelistItem.Text = "Obriši";
            btnDeletePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Right)));
            btnDeletePricelistItem.Size = new Size(90, 35);
            btnDeletePricelistItem.Click += new EventHandler(btnDeletePricelistItem_Click);
            btnDeletePricelistItem.AutoSize = false;
            btnDeletePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
            btnDeletePricelistItem.FlatStyle = FlatStyle.Flat;
            btnDeletePricelistItem.ForeColor = Color.White;
            //btnDeletePricelistItem.Image = Image.FromFile(projectDirectory + "/resources/282471-24.png");
            btnDeletePricelistItem.ImageAlign = ContentAlignment.MiddleLeft;

            btnUpdatePricelistItem.Name = "btnUpdatePricelistItem" + rb;
            btnUpdatePricelistItem.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            btnUpdatePricelistItem.Location = new Point(this.Width - 227, 155 + (i - 1) * 220);
            btnUpdatePricelistItem.Text = "Izmijeni";
            btnUpdatePricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Right)));
            btnUpdatePricelistItem.Size = new Size(90, 35);
            btnUpdatePricelistItem.Click += new EventHandler(btnUpdatePricelistItem_Click);
            btnUpdatePricelistItem.AutoSize = false;
            btnUpdatePricelistItem.BackColor = Color.FromArgb(107, 65, 150);
            btnUpdatePricelistItem.FlatStyle = FlatStyle.Flat;
            btnUpdatePricelistItem.ForeColor = Color.White;
           // btnUpdatePricelistItem.Image = Image.FromFile(projectDirectory + "/resources/2571204-24.png");
            btnUpdatePricelistItem.ImageAlign = ContentAlignment.MiddleLeft;

            btnAddPricelistItem.Name = "btnAddPricelistItem" + rb;
            btnAddPricelistItem.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            btnAddPricelistItem.Location = new Point(this.Width - 127, 155 + (i - 1) * 220);
            btnAddPricelistItem.Text = "Dodaj";
            btnAddPricelistItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Right)));
            btnAddPricelistItem.Size = new Size(90, 35);
            btnAddPricelistItem.Click += new EventHandler(btnAddPricelistItem_Click);
            btnAddPricelistItem.AutoSize = false;
            btnAddPricelistItem.BackColor = Color.FromArgb(107, 65, 150);
            btnAddPricelistItem.FlatStyle = FlatStyle.Flat;
            btnAddPricelistItem.ForeColor = Color.White;
          //  btnAddPricelistItem.Image = Image.FromFile(projectDirectory + "/resources/299068-24.png");
            btnAddPricelistItem.ImageAlign = ContentAlignment.MiddleLeft;


            dgv.Name = "dataGridView" + rb;
            dgv.ColumnCount = 3;
            dgv.Columns[0].Name = "Naziv usluge";
            dgv.Columns[1].Name = "Cijena";
            dgv.Columns[2].Name = "Id";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[2].Visible = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Location = new Point(21, (i - 1) * 220);
            dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dgv.Size = new Size(this.Width - 60, 150);
            dgv.AutoSize = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.BackgroundColor = Color.White;
            fillTable(dgv, serviceType.Id);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            i++;
            rb++;

            btnAddService = new Button();
            btnAddService.Text = "Dodaj novu vrstu usluge";
            btnAddService.Size = new Size(200, 40);
            btnAddService.Location = new Point(this.Width / 2 - btnAddService.Width / 2, 50 + (i - 1) * 220);
            btnAddService.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top)));
            btnAddService.Click += new EventHandler(btnAddServiceType_Click);
            this.Controls.Add(btnAddService);
            btnAddService.BackColor = Color.FromArgb(107, 65, 150);
            btnAddService.FlatStyle = FlatStyle.Flat;
            btnAddService.ForeColor = Color.White;
         //   btnAddService.Image = Image.FromFile(projectDirectory + "/resources/299068-24.png");
            btnAddService.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void fillTable(DataGridView dgv, int id)
        {
            dgv.Rows.Clear();
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
                foreach (var p in pricelistitems)
                {
                    DataGridViewRow row = new DataGridViewRow()
                    {
                        Tag = p
                    };
                    row.CreateCells(dgv);
                    row.SetValues(p.Name, p.Price, p.Id);
                    row.MinimumHeight = 31;
                    dgv.Rows.Add(row);
                }
            }
        }
    }
}