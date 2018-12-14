namespace Autopraonica_Markus.forms.userControls
{
    partial class uclKlijenti
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
            this.btnIzmjeniKlijenta = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.colNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUgovorOd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUgovorDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNoviKlijent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIzmjeniKlijenta
            // 
            this.btnIzmjeniKlijenta.Location = new System.Drawing.Point(146, 20);
            this.btnIzmjeniKlijenta.Name = "btnIzmjeniKlijenta";
            this.btnIzmjeniKlijenta.Size = new System.Drawing.Size(107, 23);
            this.btnIzmjeniKlijenta.TabIndex = 1;
            this.btnIzmjeniKlijenta.Text = "Izmjeni klijenta";
            this.btnIzmjeniKlijenta.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 20);
            this.textBox1.TabIndex = 2;
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKlijenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNaziv,
            this.colJIB,
            this.colGrad,
            this.colAddress,
            this.colUgovorOd,
            this.colUgovorDo});
            this.dgvKlijenti.Location = new System.Drawing.Point(19, 129);
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.Size = new System.Drawing.Size(649, 240);
            this.dgvKlijenti.TabIndex = 3;
            // 
            // colNaziv
            // 
            this.colNaziv.HeaderText = "Naziv klijenta";
            this.colNaziv.Name = "colNaziv";
            this.colNaziv.ReadOnly = true;
            // 
            // colJIB
            // 
            this.colJIB.HeaderText = "JIB";
            this.colJIB.Name = "colJIB";
            this.colJIB.ReadOnly = true;
            // 
            // colGrad
            // 
            this.colGrad.HeaderText = "Grad";
            this.colGrad.Name = "colGrad";
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Adresa";
            this.colAddress.Name = "colAddress";
            // 
            // colUgovorOd
            // 
            this.colUgovorOd.HeaderText = "UgovorOd";
            this.colUgovorOd.Name = "colUgovorOd";
            // 
            // colUgovorDo
            // 
            this.colUgovorDo.HeaderText = "UgvorDo";
            this.colUgovorDo.Name = "colUgovorDo";
            // 
            // btnNoviKlijent
            // 
            this.btnNoviKlijent.Location = new System.Drawing.Point(19, 20);
            this.btnNoviKlijent.Name = "btnNoviKlijent";
            this.btnNoviKlijent.Size = new System.Drawing.Size(121, 23);
            this.btnNoviKlijent.TabIndex = 4;
            this.btnNoviKlijent.Text = "Novi klijent";
            this.btnNoviKlijent.UseVisualStyleBackColor = true;
            this.btnNoviKlijent.Click += new System.EventHandler(this.btnNoviKlijent_Click);
            // 
            // uclKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNoviKlijent);
            this.Controls.Add(this.dgvKlijenti);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnIzmjeniKlijenta);
            this.Name = "uclKlijenti";
            this.Size = new System.Drawing.Size(683, 382);
            this.Load += new System.EventHandler(this.uclKlijenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnIzmjeniKlijenta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUgovorOd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUgovorDo;
        private System.Windows.Forms.Button btnNoviKlijent;
    }
}
