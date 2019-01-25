﻿namespace Autopraonica_Markus.forms.userControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnHireEmployee = new System.Windows.Forms.Button();
            this.cmbEmployees = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToResizeColumns = false;
            this.dgvEmployees.AllowUserToResizeRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFirstName,
            this.colLastName,
            this.colPhoneNumber,
            this.colAddress});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployees.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEmployees.Location = new System.Drawing.Point(23, 57);
            this.dgvEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(865, 334);
            this.dgvEmployees.TabIndex = 4;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellContentClick);
            // 
            // colFirstName
            // 
            this.colFirstName.HeaderText = "Ime zaposlenog";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "Prezime zaposlenog";
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.HeaderText = "Broj telefona";
            this.colPhoneNumber.Name = "colPhoneNumber";
            this.colPhoneNumber.ReadOnly = true;
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Adresa";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnNewEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewEmployee.Location = new System.Drawing.Point(23, 398);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(219, 55);
            this.btnNewEmployee.TabIndex = 5;
            this.btnNewEmployee.Text = "Novi zaposleni";
            this.btnNewEmployee.UseVisualStyleBackColor = false;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnUpdateEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnUpdateEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateEmployee.Location = new System.Drawing.Point(248, 398);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(219, 55);
            this.btnUpdateEmployee.TabIndex = 6;
            this.btnUpdateEmployee.Text = "Izmjena zaposlenog";
            this.btnUpdateEmployee.UseVisualStyleBackColor = false;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnDeleteEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnDeleteEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(473, 398);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(219, 55);
            this.btnDeleteEmployee.TabIndex = 7;
            this.btnDeleteEmployee.Text = "Obrisi zaposlenog";
            this.btnDeleteEmployee.UseVisualStyleBackColor = false;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // tbSearchEmployee
            // 
            this.tbSearchEmployee.Location = new System.Drawing.Point(576, 18);
            this.tbSearchEmployee.Name = "tbSearchEmployee";
            this.tbSearchEmployee.Size = new System.Drawing.Size(312, 22);
            this.tbSearchEmployee.TabIndex = 8;
            this.tbSearchEmployee.TextChanged += new System.EventHandler(this.tbSearchEmployee_TextChanged);
            // 
            // lblSrcEmp
            // 
            this.lblSrcEmp.AutoSize = true;
            this.lblSrcEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrcEmp.Location = new System.Drawing.Point(194, 14);
            this.lblSrcEmp.Name = "lblSrcEmp";
            this.lblSrcEmp.Size = new System.Drawing.Size(354, 29);
            this.lblSrcEmp.TabIndex = 9;
            this.lblSrcEmp.Text = "Pretraga po imenu i prezimenu :";
            // 
            // btnHireEmployee
            // 
            this.btnHireEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHireEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnHireEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHireEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnHireEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHireEmployee.Location = new System.Drawing.Point(473, 398);
            this.btnHireEmployee.Name = "btnHireEmployee";
            this.btnHireEmployee.Size = new System.Drawing.Size(219, 55);
            this.btnHireEmployee.TabIndex = 12;
            this.btnHireEmployee.Text = "Ponovo zaposli";
            this.btnHireEmployee.UseVisualStyleBackColor = false;
            this.btnHireEmployee.Visible = false;
            this.btnHireEmployee.Click += new System.EventHandler(this.btnHireEmployee_Click);
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(23, 14);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(165, 26);
            this.cmbEmployees.TabIndex = 14;
            this.cmbEmployees.SelectedIndexChanged += new System.EventHandler(this.cmbEmployees_SelectedIndexChanged);
            // 
            // uclZaposleni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbEmployees);
            this.Controls.Add(this.btnHireEmployee);
            this.Controls.Add(this.lblSrcEmp);
            this.Controls.Add(this.tbSearchEmployee);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnUpdateEmployee);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.dgvEmployees);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uclZaposleni";
            this.Size = new System.Drawing.Size(911, 470);
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
        private System.Windows.Forms.Button btnHireEmployee;
        private System.Windows.Forms.ComboBox cmbEmployees;
    }
}
