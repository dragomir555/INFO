namespace Autopraonica_Markus.forms.userControls
{
    partial class uclZaposleni
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
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.colNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUgovorOd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUgovorDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
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
            this.dgvKlijenti.Location = new System.Drawing.Point(28, 122);
            this.dgvKlijenti.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.Size = new System.Drawing.Size(802, 295);
            this.dgvKlijenti.TabIndex = 4;
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
            // btnNewEmployee
            // 
            this.btnNewEmployee.Location = new System.Drawing.Point(246, 65);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(194, 23);
            this.btnNewEmployee.TabIndex = 5;
            this.btnNewEmployee.Text = "Novi zaposleni";
            this.btnNewEmployee.UseVisualStyleBackColor = true;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // uclZaposleni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.dgvKlijenti);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uclZaposleni";
            this.Size = new System.Drawing.Size(847, 470);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUgovorOd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUgovorDo;
        private System.Windows.Forms.Button btnNewEmployee;
    }
}
