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
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.tbSearchEmployee = new System.Windows.Forms.TextBox();
            this.lblSrcEmp = new System.Windows.Forms.Label();
            this.rbPresent = new System.Windows.Forms.RadioButton();
            this.rbPerfect = new System.Windows.Forms.RadioButton();
            this.btnHireEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToResizeColumns = false;
            this.dgvEmployees.AllowUserToResizeRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFirstName,
            this.colLastName,
            this.colPhoneNumber,
            this.colAddress});
            this.dgvEmployees.Location = new System.Drawing.Point(13, 119);
            this.dgvEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(802, 295);
            this.dgvEmployees.TabIndex = 4;
            // 
            // colFirstName
            // 
            this.colFirstName.HeaderText = "Ime zaposlenog";
            this.colFirstName.Name = "colFirstName";
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "Prezime zaposlenog";
            this.colLastName.Name = "colLastName";
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.HeaderText = "Broj telefona";
            this.colPhoneNumber.Name = "colPhoneNumber";
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Adresa";
            this.colAddress.Name = "colAddress";
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewEmployee.Location = new System.Drawing.Point(13, 26);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(219, 49);
            this.btnNewEmployee.TabIndex = 5;
            this.btnNewEmployee.Text = "Novi zaposleni";
            this.btnNewEmployee.UseVisualStyleBackColor = false;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnUpdateEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateEmployee.Location = new System.Drawing.Point(248, 26);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(219, 49);
            this.btnUpdateEmployee.TabIndex = 6;
            this.btnUpdateEmployee.Text = "Izmjena zaposlenog";
            this.btnUpdateEmployee.UseVisualStyleBackColor = false;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnDeleteEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(486, 26);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(219, 49);
            this.btnDeleteEmployee.TabIndex = 7;
            this.btnDeleteEmployee.Text = "Obrisi zaposlenog";
            this.btnDeleteEmployee.UseVisualStyleBackColor = false;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // tbSearchEmployee
            // 
            this.tbSearchEmployee.Location = new System.Drawing.Point(394, 90);
            this.tbSearchEmployee.Name = "tbSearchEmployee";
            this.tbSearchEmployee.Size = new System.Drawing.Size(360, 22);
            this.tbSearchEmployee.TabIndex = 8;
            this.tbSearchEmployee.TextChanged += new System.EventHandler(this.tbSearchEmployee_TextChanged);
            // 
            // lblSrcEmp
            // 
            this.lblSrcEmp.AutoSize = true;
            this.lblSrcEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrcEmp.Location = new System.Drawing.Point(10, 86);
            this.lblSrcEmp.Name = "lblSrcEmp";
            this.lblSrcEmp.Size = new System.Drawing.Size(354, 29);
            this.lblSrcEmp.TabIndex = 9;
            this.lblSrcEmp.Text = "Pretraga po imenu i prezimenu :";
            // 
            // rbPresent
            // 
            this.rbPresent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbPresent.AutoSize = true;
            this.rbPresent.Checked = true;
            this.rbPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPresent.Location = new System.Drawing.Point(13, 434);
            this.rbPresent.Name = "rbPresent";
            this.rbPresent.Size = new System.Drawing.Size(123, 33);
            this.rbPresent.TabIndex = 10;
            this.rbPresent.TabStop = true;
            this.rbPresent.Text = "Trenutni";
            this.rbPresent.UseVisualStyleBackColor = true;
            this.rbPresent.CheckedChanged += new System.EventHandler(this.rbPresent_CheckedChanged);
            // 
            // rbPerfect
            // 
            this.rbPerfect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbPerfect.AutoSize = true;
            this.rbPerfect.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPerfect.Location = new System.Drawing.Point(170, 434);
            this.rbPerfect.Name = "rbPerfect";
            this.rbPerfect.Size = new System.Drawing.Size(85, 33);
            this.rbPerfect.TabIndex = 11;
            this.rbPerfect.Text = "Bivsi";
            this.rbPerfect.UseVisualStyleBackColor = true;
            this.rbPerfect.CheckedChanged += new System.EventHandler(this.rbPerfect_CheckedChanged);
            // 
            // btnHireEmployee
            // 
            this.btnHireEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnHireEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHireEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHireEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHireEmployee.Location = new System.Drawing.Point(331, 27);
            this.btnHireEmployee.Name = "btnHireEmployee";
            this.btnHireEmployee.Size = new System.Drawing.Size(219, 49);
            this.btnHireEmployee.TabIndex = 12;
            this.btnHireEmployee.Text = "Ponovo zaposli";
            this.btnHireEmployee.UseVisualStyleBackColor = false;
            this.btnHireEmployee.Visible = false;
            this.btnHireEmployee.Click += new System.EventHandler(this.btnHireEmployee_Click);
            // 
            // uclZaposleni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnHireEmployee);
            this.Controls.Add(this.rbPerfect);
            this.Controls.Add(this.rbPresent);
            this.Controls.Add(this.lblSrcEmp);
            this.Controls.Add(this.tbSearchEmployee);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnUpdateEmployee);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.dgvEmployees);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uclZaposleni";
            this.Size = new System.Drawing.Size(847, 470);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnNewEmployee;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.TextBox tbSearchEmployee;
        private System.Windows.Forms.Label lblSrcEmp;
        private System.Windows.Forms.RadioButton rbPresent;
        private System.Windows.Forms.RadioButton rbPerfect;
        private System.Windows.Forms.Button btnHireEmployee;
    }
}
