namespace Autopraonica_Markus.forms.userControls
{
    partial class uclIzdavanjeRacuna
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDspUnpSer = new System.Windows.Forms.Button();
            this.lvUpSer = new System.Windows.Forms.ListView();
            this.hdSerNumSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdTypeSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdSubtypeSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdDtTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdLicPl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGenBill = new System.Windows.Forms.Button();
            this.lblGenBill = new System.Windows.Forms.Label();
            this.lblRacuni = new System.Windows.Forms.Label();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbState = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Naziv klijenta :";
            // 
            // cmbClients
            // 
            this.cmbClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbClients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(172, 83);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(343, 26);
            this.cmbClients.TabIndex = 11;
            this.cmbClients.Text = "  Odabir klijenta";
            this.cmbClients.SelectedValueChanged += new System.EventHandler(this.cmbClients_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Za mjesec :";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDateFrom.Location = new System.Drawing.Point(172, 134);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(343, 22);
            this.dtpDateFrom.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(259, 419);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(84, 38);
            this.lblPrice.TabIndex = 16;
            this.lblPrice.Text = "00.0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 38);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ukupna suma:";
            // 
            // btnDspUnpSer
            // 
            this.btnDspUnpSer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDspUnpSer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnDspUnpSer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDspUnpSer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnDspUnpSer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDspUnpSer.Location = new System.Drawing.Point(370, 408);
            this.btnDspUnpSer.Name = "btnDspUnpSer";
            this.btnDspUnpSer.Size = new System.Drawing.Size(235, 49);
            this.btnDspUnpSer.TabIndex = 14;
            this.btnDspUnpSer.Text = "Prikaži izvrsenih usluga";
            this.btnDspUnpSer.UseVisualStyleBackColor = false;
            this.btnDspUnpSer.Click += new System.EventHandler(this.btnDspUnpSer_Click);
            // 
            // lvUpSer
            // 
            this.lvUpSer.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvUpSer.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvUpSer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUpSer.BackColor = System.Drawing.SystemColors.Menu;
            this.lvUpSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvUpSer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdSerNumSer,
            this.hdTypeSer,
            this.hdSubtypeSer,
            this.hdFirstName,
            this.hdLastName,
            this.hdDtTime,
            this.hdLicPl,
            this.hdPrice});
            this.lvUpSer.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvUpSer.Location = new System.Drawing.Point(21, 192);
            this.lvUpSer.Name = "lvUpSer";
            this.lvUpSer.Size = new System.Drawing.Size(855, 210);
            this.lvUpSer.TabIndex = 13;
            this.lvUpSer.UseCompatibleStateImageBehavior = false;
            this.lvUpSer.View = System.Windows.Forms.View.Details;
            // 
            // hdSerNumSer
            // 
            this.hdSerNumSer.Text = "R.b.";
            this.hdSerNumSer.Width = 37;
            // 
            // hdTypeSer
            // 
            this.hdTypeSer.Text = "Vrsta usluge";
            this.hdTypeSer.Width = 96;
            // 
            // hdSubtypeSer
            // 
            this.hdSubtypeSer.Text = "Podvrsta usluge";
            this.hdSubtypeSer.Width = 109;
            // 
            // hdFirstName
            // 
            this.hdFirstName.Text = "Ime";
            this.hdFirstName.Width = 89;
            // 
            // hdLastName
            // 
            this.hdLastName.Text = "Prezime";
            this.hdLastName.Width = 99;
            // 
            // hdDtTime
            // 
            this.hdDtTime.Text = "Datum usluge";
            this.hdDtTime.Width = 119;
            // 
            // hdLicPl
            // 
            this.hdLicPl.Text = "Registarske tablice";
            this.hdLicPl.Width = 136;
            // 
            // hdPrice
            // 
            this.hdPrice.Text = "Cijena";
            this.hdPrice.Width = 73;
            // 
            // btnGenBill
            // 
            this.btnGenBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnGenBill.Enabled = false;
            this.btnGenBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGenBill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenBill.Location = new System.Drawing.Point(611, 408);
            this.btnGenBill.Name = "btnGenBill";
            this.btnGenBill.Size = new System.Drawing.Size(235, 49);
            this.btnGenBill.TabIndex = 17;
            this.btnGenBill.Text = "Generiši račun";
            this.btnGenBill.UseVisualStyleBackColor = false;
            this.btnGenBill.Click += new System.EventHandler(this.btnGenBill_Click);
            // 
            // lblGenBill
            // 
            this.lblGenBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGenBill.AutoSize = true;
            this.lblGenBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenBill.Location = new System.Drawing.Point(16, 11);
            this.lblGenBill.Name = "lblGenBill";
            this.lblGenBill.Size = new System.Drawing.Size(488, 38);
            this.lblGenBill.TabIndex = 18;
            this.lblGenBill.Text = "Parametri za generisanje racuna";
            // 
            // lblRacuni
            // 
            this.lblRacuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRacuni.AutoSize = true;
            this.lblRacuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRacuni.Location = new System.Drawing.Point(573, 15);
            this.lblRacuni.Name = "lblRacuni";
            this.lblRacuni.Size = new System.Drawing.Size(123, 29);
            this.lblRacuni.TabIndex = 20;
            this.lblRacuni.Text = "Racuni za ";
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AllowUserToResizeColumns = false;
            this.dgvBills.AllowUserToResizeRows = false;
            this.dgvBills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.cmbState});
            this.dgvBills.Location = new System.Drawing.Point(578, 48);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.RowTemplate.Height = 24;
            this.dgvBills.Size = new System.Drawing.Size(298, 120);
            this.dgvBills.TabIndex = 22;
            this.dgvBills.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBills_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Broj racuna";
            this.Column1.Name = "Column1";
            // 
            // cmbState
            // 
            this.cmbState.HeaderText = "Stanje";
            this.cmbState.Name = "cmbState";
            // 
            // dtpYear
            // 
            this.dtpYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpYear.Location = new System.Drawing.Point(702, 20);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(173, 22);
            this.dtpYear.TabIndex = 23;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpYear_ValueChanged);
            // 
            // uclIzdavanjeRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.lblRacuni);
            this.Controls.Add(this.lblGenBill);
            this.Controls.Add(this.btnGenBill);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDspUnpSer);
            this.Controls.Add(this.lvUpSer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbClients);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateFrom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uclIzdavanjeRacuna";
            this.Size = new System.Drawing.Size(897, 470);
            this.Resize += new System.EventHandler(this.uclIzdavanjeRacuna_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDspUnpSer;
        private System.Windows.Forms.ListView lvUpSer;
        private System.Windows.Forms.ColumnHeader hdTypeSer;
        private System.Windows.Forms.ColumnHeader hdFirstName;
        private System.Windows.Forms.ColumnHeader hdLastName;
        private System.Windows.Forms.Button btnGenBill;
        private System.Windows.Forms.ColumnHeader hdDtTime;
        private System.Windows.Forms.ColumnHeader hdLicPl;
        private System.Windows.Forms.ColumnHeader hdPrice;
        private System.Windows.Forms.ColumnHeader hdSubtypeSer;
        private System.Windows.Forms.Label lblGenBill;
        private System.Windows.Forms.ColumnHeader hdSerNumSer;
        private System.Windows.Forms.Label lblRacuni;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbState;
    }
}
