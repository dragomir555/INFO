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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDspUnpSer = new System.Windows.Forms.Button();
            this.lvUpSer = new System.Windows.Forms.ListView();
            this.hdSerNumSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdTypeSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdDateSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdPriceSer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGenBill = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Naziv klijenta";
            // 
            // cmbClients
            // 
            this.cmbClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(155, 61);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(200, 26);
            this.cmbClients.TabIndex = 11;
            this.cmbClients.Text = "    Odabir klijenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Datum do";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Datum od";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(155, 147);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(200, 22);
            this.dtpDateTo.TabIndex = 8;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(155, 101);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpDateFrom.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 38);
            this.label5.TabIndex = 16;
            this.label5.Text = "00.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 38);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ukupna suma   :";
            // 
            // btnDspUnpSer
            // 
            this.btnDspUnpSer.Location = new System.Drawing.Point(418, 416);
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
            this.hdDateSer,
            this.hdPriceSer,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvUpSer.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvUpSer.Location = new System.Drawing.Point(29, 197);
            this.lvUpSer.Name = "lvUpSer";
            this.lvUpSer.Size = new System.Drawing.Size(557, 210);
            this.lvUpSer.TabIndex = 13;
            this.lvUpSer.UseCompatibleStateImageBehavior = false;
            this.lvUpSer.View = System.Windows.Forms.View.Details;
            // 
            // hdSerNumSer
            // 
            this.hdSerNumSer.Text = "Redni broj usluge";
            this.hdSerNumSer.Width = 120;
            // 
            // hdTypeSer
            // 
            this.hdTypeSer.Text = "Vrsta usluge";
            this.hdTypeSer.Width = 137;
            // 
            // hdDateSer
            // 
            this.hdDateSer.Text = "Datum usluge";
            this.hdDateSer.Width = 137;
            // 
            // hdPriceSer
            // 
            this.hdPriceSer.Text = "Cijena usluge";
            this.hdPriceSer.Width = 137;
            // 
            // btnGenBill
            // 
            this.btnGenBill.Enabled = false;
            this.btnGenBill.Location = new System.Drawing.Point(622, 367);
            this.btnGenBill.Name = "btnGenBill";
            this.btnGenBill.Size = new System.Drawing.Size(176, 40);
            this.btnGenBill.TabIndex = 17;
            this.btnGenBill.Text = "Generiši račun";
            this.btnGenBill.UseVisualStyleBackColor = true;
            this.btnGenBill.Click += new System.EventHandler(this.btnGenBill_Click);
            // 
            // uclIzdavanjeRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenBill);
            this.Controls.Add(this.label5);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDspUnpSer;
        private System.Windows.Forms.ListView lvUpSer;
        private System.Windows.Forms.ColumnHeader hdSerNumSer;
        private System.Windows.Forms.ColumnHeader hdTypeSer;
        private System.Windows.Forms.ColumnHeader hdDateSer;
        private System.Windows.Forms.ColumnHeader hdPriceSer;
        private System.Windows.Forms.Button btnGenBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
