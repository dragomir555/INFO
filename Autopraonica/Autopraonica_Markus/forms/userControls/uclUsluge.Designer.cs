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
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbPravnaLica = new System.Windows.Forms.RadioButton();
            this.rbFizickaLica = new System.Windows.Forms.RadioButton();
            this.btnNewLegalEntityService = new System.Windows.Forms.Button();
            this.btnNewNaturalEntityService = new System.Windows.Forms.Button();
            this.dgvNaturalEntity = new System.Windows.Forms.DataGridView();
            this.Vrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KategorijaUsluge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usluga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegalEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNaturalEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLegalEntity
            // 
            this.dgvLegalEntity.AllowUserToAddRows = false;
            this.dgvLegalEntity.AllowUserToDeleteRows = false;
            this.dgvLegalEntity.AllowUserToResizeColumns = false;
            this.dgvLegalEntity.AllowUserToResizeRows = false;
            this.dgvLegalEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLegalEntity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLegalEntity.BackgroundColor = System.Drawing.Color.White;
            this.dgvLegalEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegalEntity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvLegalEntity.Location = new System.Drawing.Point(17, 135);
            this.dgvLegalEntity.MultiSelect = false;
            this.dgvLegalEntity.Name = "dgvLegalEntity";
            this.dgvLegalEntity.ReadOnly = true;
            this.dgvLegalEntity.RowHeadersVisible = false;
            this.dgvLegalEntity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLegalEntity.Size = new System.Drawing.Size(649, 230);
            this.dgvLegalEntity.TabIndex = 0;
            this.dgvLegalEntity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLegalEntity_CellContentClick);
            // 
            // Naziv
            // 
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Vrijeme";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Kategorija usluge";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Usluga";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cijena";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // rbPravnaLica
            // 
            this.rbPravnaLica.AutoSize = true;
            this.rbPravnaLica.Checked = true;
            this.rbPravnaLica.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPravnaLica.Location = new System.Drawing.Point(17, 100);
            this.rbPravnaLica.Name = "rbPravnaLica";
            this.rbPravnaLica.Size = new System.Drawing.Size(137, 29);
            this.rbPravnaLica.TabIndex = 1;
            this.rbPravnaLica.TabStop = true;
            this.rbPravnaLica.Text = "Pravna lica";
            this.rbPravnaLica.UseVisualStyleBackColor = true;
            this.rbPravnaLica.CheckedChanged += new System.EventHandler(this.rbPravnaLica_CheckedChanged);
            // 
            // rbFizickaLica
            // 
            this.rbFizickaLica.AutoSize = true;
            this.rbFizickaLica.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFizickaLica.Location = new System.Drawing.Point(180, 100);
            this.rbFizickaLica.Name = "rbFizickaLica";
            this.rbFizickaLica.Size = new System.Drawing.Size(137, 29);
            this.rbFizickaLica.TabIndex = 2;
            this.rbFizickaLica.Text = "Fizička lica";
            this.rbFizickaLica.UseVisualStyleBackColor = true;
            this.rbFizickaLica.CheckedChanged += new System.EventHandler(this.rbFizickaLica_CheckedChanged);
            // 
            // btnNewLegalEntityService
            // 
            this.btnNewLegalEntityService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnNewLegalEntityService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnNewLegalEntityService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewLegalEntityService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLegalEntityService.ForeColor = System.Drawing.Color.White;
            this.btnNewLegalEntityService.Location = new System.Drawing.Point(17, 20);
            this.btnNewLegalEntityService.Name = "btnNewLegalEntityService";
            this.btnNewLegalEntityService.Size = new System.Drawing.Size(300, 45);
            this.btnNewLegalEntityService.TabIndex = 3;
            this.btnNewLegalEntityService.Text = "Dodavanje usluge za pravna lica";
            this.btnNewLegalEntityService.UseVisualStyleBackColor = false;
            this.btnNewLegalEntityService.Click += new System.EventHandler(this.btnNewLegalEntityService_Click);
            // 
            // btnNewNaturalEntityService
            // 
            this.btnNewNaturalEntityService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnNewNaturalEntityService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnNewNaturalEntityService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewNaturalEntityService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewNaturalEntityService.ForeColor = System.Drawing.Color.White;
            this.btnNewNaturalEntityService.Location = new System.Drawing.Point(366, 20);
            this.btnNewNaturalEntityService.Name = "btnNewNaturalEntityService";
            this.btnNewNaturalEntityService.Size = new System.Drawing.Size(300, 45);
            this.btnNewNaturalEntityService.TabIndex = 4;
            this.btnNewNaturalEntityService.Text = "Dodavanje usluge za fizička lica";
            this.btnNewNaturalEntityService.UseVisualStyleBackColor = false;
            this.btnNewNaturalEntityService.Click += new System.EventHandler(this.btnNewNaturalEntityService_Click);
            // 
            // dgvNaturalEntity
            // 
            this.dgvNaturalEntity.AllowUserToAddRows = false;
            this.dgvNaturalEntity.AllowUserToDeleteRows = false;
            this.dgvNaturalEntity.AllowUserToResizeColumns = false;
            this.dgvNaturalEntity.AllowUserToResizeRows = false;
            this.dgvNaturalEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNaturalEntity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNaturalEntity.BackgroundColor = System.Drawing.Color.White;
            this.dgvNaturalEntity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNaturalEntity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vrijeme,
            this.KategorijaUsluge,
            this.Usluga,
            this.Cijena});
            this.dgvNaturalEntity.Location = new System.Drawing.Point(17, 135);
            this.dgvNaturalEntity.MultiSelect = false;
            this.dgvNaturalEntity.Name = "dgvNaturalEntity";
            this.dgvNaturalEntity.ReadOnly = true;
            this.dgvNaturalEntity.RowHeadersVisible = false;
            this.dgvNaturalEntity.Size = new System.Drawing.Size(649, 230);
            this.dgvNaturalEntity.TabIndex = 5;
            // 
            // Vrijeme
            // 
            this.Vrijeme.HeaderText = "Vrijeme";
            this.Vrijeme.Name = "Vrijeme";
            this.Vrijeme.ReadOnly = true;
            // 
            // KategorijaUsluge
            // 
            this.KategorijaUsluge.HeaderText = "Kategorija usluge";
            this.KategorijaUsluge.Name = "KategorijaUsluge";
            this.KategorijaUsluge.ReadOnly = true;
            // 
            // Usluga
            // 
            this.Usluga.HeaderText = "Usluga";
            this.Usluga.Name = "Usluga";
            this.Usluga.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // uclUsluge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvNaturalEntity);
            this.Controls.Add(this.btnNewNaturalEntityService);
            this.Controls.Add(this.btnNewLegalEntityService);
            this.Controls.Add(this.rbFizickaLica);
            this.Controls.Add(this.rbPravnaLica);
            this.Controls.Add(this.dgvLegalEntity);
            this.Name = "uclUsluge";
            this.Size = new System.Drawing.Size(683, 382);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegalEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNaturalEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLegalEntity;
        private System.Windows.Forms.RadioButton rbPravnaLica;
        private System.Windows.Forms.RadioButton rbFizickaLica;
        private System.Windows.Forms.Button btnNewLegalEntityService;
        private System.Windows.Forms.Button btnNewNaturalEntityService;
        private System.Windows.Forms.DataGridView dgvNaturalEntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vrijeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorijaUsluge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usluga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
