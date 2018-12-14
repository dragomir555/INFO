namespace Autopraonica_Markus.forms.userControls
{
    partial class uclUsluge
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
            this.dgvLegalEntity = new System.Windows.Forms.DataGridView();
            this.rbPravnaLica = new System.Windows.Forms.RadioButton();
            this.rbFizickaLica = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistarskeTablice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegalEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLegalEntity
            // 
            this.dgvLegalEntity.AllowUserToAddRows = false;
            this.dgvLegalEntity.AllowUserToDeleteRows = false;
            this.dgvLegalEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLegalEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegalEntity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.JIB,
            this.Grad,
            this.Ime,
            this.Prezime,
            this.RegistarskeTablice});
            this.dgvLegalEntity.Location = new System.Drawing.Point(0, 205);
            this.dgvLegalEntity.Name = "dgvLegalEntity";
            this.dgvLegalEntity.ReadOnly = true;
            this.dgvLegalEntity.Size = new System.Drawing.Size(601, 177);
            this.dgvLegalEntity.TabIndex = 0;
            this.dgvLegalEntity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLegalEntity_CellContentClick);
            // 
            // rbPravnaLica
            // 
            this.rbPravnaLica.AutoSize = true;
            this.rbPravnaLica.Checked = true;
            this.rbPravnaLica.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPravnaLica.Location = new System.Drawing.Point(12, 173);
            this.rbPravnaLica.Name = "rbPravnaLica";
            this.rbPravnaLica.Size = new System.Drawing.Size(137, 29);
            this.rbPravnaLica.TabIndex = 1;
            this.rbPravnaLica.TabStop = true;
            this.rbPravnaLica.Text = "Pravna lica";
            this.rbPravnaLica.UseVisualStyleBackColor = true;
            // 
            // rbFizickaLica
            // 
            this.rbFizickaLica.AutoSize = true;
            this.rbFizickaLica.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFizickaLica.Location = new System.Drawing.Point(155, 173);
            this.rbFizickaLica.Name = "rbFizickaLica";
            this.rbFizickaLica.Size = new System.Drawing.Size(137, 29);
            this.rbFizickaLica.TabIndex = 2;
            this.rbFizickaLica.Text = "Fizička lica";
            this.rbFizickaLica.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(400, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Dodavanje usluge za pravna lica";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(400, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "Dodavanje usluge za fizička lica";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Naziv
            // 
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // JIB
            // 
            this.JIB.HeaderText = "JIB";
            this.JIB.Name = "JIB";
            this.JIB.ReadOnly = true;
            // 
            // Grad
            // 
            this.Grad.HeaderText = "Grad";
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            // 
            // Ime
            // 
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // RegistarskeTablice
            // 
            this.RegistarskeTablice.HeaderText = "Registarske tablice";
            this.RegistarskeTablice.Name = "RegistarskeTablice";
            this.RegistarskeTablice.ReadOnly = true;
            // 
            // uclUsluge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbFizickaLica);
            this.Controls.Add(this.rbPravnaLica);
            this.Controls.Add(this.dgvLegalEntity);
            this.Name = "uclUsluge";
            this.Size = new System.Drawing.Size(601, 382);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegalEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLegalEntity;
        private System.Windows.Forms.RadioButton rbPravnaLica;
        private System.Windows.Forms.RadioButton rbFizickaLica;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn JIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistarskeTablice;
    }
}
