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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDspUnpSer = new System.Windows.Forms.Button();
            this.lvUpSer = new System.Windows.Forms.ListView();
            this.hdSerNumSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdTypeSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdSecName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdDtTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdLicPl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGenBill = new System.Windows.Forms.Button();
            this.hdSubtypeSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Naziv klijenta";
            // 
            // cmbClients
            // 
            this.cmbClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(122, 56);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(247, 26);
            this.cmbClients.TabIndex = 11;
            this.cmbClients.Text = "    Odabir klijenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Datum do";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Datum od";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(122, 142);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(247, 22);
            this.dtpDateTo.TabIndex = 8;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(122, 96);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(247, 22);
            this.dtpDateFrom.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(328, 419);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(84, 38);
            this.lblPrice.TabIndex = 16;
            this.lblPrice.Text = "00.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 38);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ukupna suma  :";
            // 
            // btnDspUnpSer
            // 
            this.btnDspUnpSer.Location = new System.Drawing.Point(440, 416);
            this.btnDspUnpSer.Name = "btnDspUnpSer";
            this.btnDspUnpSer.Size = new System.Drawing.Size(183, 41);
            this.btnDspUnpSer.TabIndex = 14;
            this.btnDspUnpSer.Text = "Prikaži neplaćenih usluga";
            this.btnDspUnpSer.UseVisualStyleBackColor = true;
            this.btnDspUnpSer.Click += new System.EventHandler(this.btnDspUnpSer_Click);
            // 
            // lvUpSer
            // 
            this.lvUpSer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdSerNumSer,
            this.hdTypeSer,
            this.hdSubtypeSer,
            this.hdFirstName,
            this.hdSecName,
            this.hdDtTime,
            this.hdLicPl,
            this.hdPrice});
            this.lvUpSer.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvUpSer.Location = new System.Drawing.Point(19, 191);
            this.lvUpSer.Name = "lvUpSer";
            this.lvUpSer.Size = new System.Drawing.Size(689, 210);
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
            // hdFirstName
            // 
            this.hdFirstName.Text = "Ime";
            this.hdFirstName.Width = 78;
            // 
            // hdSecName
            // 
            this.hdSecName.Text = "Prezime";
            this.hdSecName.Width = 86;
            // 
            // hdDtTime
            // 
            this.hdDtTime.Text = "Datum usluge";
            this.hdDtTime.Width = 94;
            // 
            // hdLicPl
            // 
            this.hdLicPl.Text = "Registarske tablice";
            this.hdLicPl.Width = 130;
            // 
            // hdPrice
            // 
            this.hdPrice.Text = "Cijena";
            this.hdPrice.Width = 51;
            // 
            // btnGenBill
            // 
            this.btnGenBill.Enabled = false;
            this.btnGenBill.Location = new System.Drawing.Point(629, 416);
            this.btnGenBill.Name = "btnGenBill";
            this.btnGenBill.Size = new System.Drawing.Size(169, 40);
            this.btnGenBill.TabIndex = 17;
            this.btnGenBill.Text = "Generiši račun";
            this.btnGenBill.UseVisualStyleBackColor = true;
            this.btnGenBill.Click += new System.EventHandler(this.btnGenBill_Click);
            // 
            // hdSubtypeSer
            // 
            this.hdSubtypeSer.Text = "Podvrsta usluge";
            this.hdSubtypeSer.Width = 109;
            // 
            // uclIzdavanjeRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenBill);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDspUnpSer);
            this.Controls.Add(this.lvUpSer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbClients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uclIzdavanjeRacuna";
            this.Size = new System.Drawing.Size(801, 470);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDspUnpSer;
        private System.Windows.Forms.ListView lvUpSer;
        private System.Windows.Forms.ColumnHeader hdSerNumSer;
        private System.Windows.Forms.ColumnHeader hdTypeSer;
        private System.Windows.Forms.ColumnHeader hdFirstName;
        private System.Windows.Forms.ColumnHeader hdSecName;
        private System.Windows.Forms.Button btnGenBill;
        private System.Windows.Forms.ColumnHeader hdDtTime;
        private System.Windows.Forms.ColumnHeader hdLicPl;
        private System.Windows.Forms.ColumnHeader hdPrice;
        private System.Windows.Forms.ColumnHeader hdSubtypeSer;
    }
}
