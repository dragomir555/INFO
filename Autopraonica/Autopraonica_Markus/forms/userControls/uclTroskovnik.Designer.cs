namespace Autopraonica_Markus.forms.userControls
{
    partial class uclTroskovnik
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.purchaseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newPurchase = new System.Windows.Forms.Button();
            this.stormPurchase = new System.Windows.Forms.Button();
            this.ViewPurchase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.tbSearchtext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSumPurchase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AllowUserToAddRows = false;
            this.dgvPurchase.AllowUserToDeleteRows = false;
            this.dgvPurchase.AllowUserToResizeRows = false;
            this.dgvPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchase.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchaseNumber,
            this.suplierName,
            this.usernameEmployee,
            this.time,
            this.sumValue});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchase.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPurchase.Location = new System.Drawing.Point(21, 59);
            this.dgvPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPurchase.MultiSelect = false;
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.ReadOnly = true;
            this.dgvPurchase.RowHeadersVisible = false;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchase.Size = new System.Drawing.Size(872, 339);
            this.dgvPurchase.TabIndex = 0;
            this.dgvPurchase.SelectionChanged += new System.EventHandler(this.dgvPurchase_SelectionChanged);
            // 
            // purchaseNumber
            // 
            this.purchaseNumber.HeaderText = "Broj računa";
            this.purchaseNumber.Name = "purchaseNumber";
            this.purchaseNumber.ReadOnly = true;
            // 
            // suplierName
            // 
            this.suplierName.HeaderText = "Ime dobavljača";
            this.suplierName.Name = "suplierName";
            this.suplierName.ReadOnly = true;
            // 
            // usernameEmployee
            // 
            this.usernameEmployee.HeaderText = "Radnik";
            this.usernameEmployee.Name = "usernameEmployee";
            this.usernameEmployee.ReadOnly = true;
            // 
            // time
            // 
            this.time.HeaderText = "Vrijeme preuzimanja";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // sumValue
            // 
            this.sumValue.HeaderText = "Ukupan iznos[KM]";
            this.sumValue.Name = "sumValue";
            this.sumValue.ReadOnly = true;
            // 
            // newPurchase
            // 
            this.newPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.newPurchase.FlatAppearance.BorderSize = 0;
            this.newPurchase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.newPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newPurchase.ForeColor = System.Drawing.Color.White;
            this.newPurchase.Location = new System.Drawing.Point(21, 406);
            this.newPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.newPurchase.Name = "newPurchase";
            this.newPurchase.Size = new System.Drawing.Size(187, 55);
            this.newPurchase.TabIndex = 1;
            this.newPurchase.Text = "Nova nabavka";
            this.newPurchase.UseVisualStyleBackColor = false;
            this.newPurchase.Click += new System.EventHandler(this.newPurchase_Click);
            // 
            // stormPurchase
            // 
            this.stormPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stormPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.stormPurchase.FlatAppearance.BorderSize = 0;
            this.stormPurchase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.stormPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stormPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stormPurchase.ForeColor = System.Drawing.Color.White;
            this.stormPurchase.Location = new System.Drawing.Point(228, 405);
            this.stormPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.stormPurchase.Name = "stormPurchase";
            this.stormPurchase.Size = new System.Drawing.Size(187, 55);
            this.stormPurchase.TabIndex = 2;
            this.stormPurchase.Text = "Poništi nabavku";
            this.stormPurchase.UseVisualStyleBackColor = false;
            this.stormPurchase.Click += new System.EventHandler(this.stormPurchase_Click);
            // 
            // ViewPurchase
            // 
            this.ViewPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ViewPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.ViewPurchase.FlatAppearance.BorderSize = 0;
            this.ViewPurchase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.ViewPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ViewPurchase.ForeColor = System.Drawing.Color.White;
            this.ViewPurchase.Location = new System.Drawing.Point(441, 406);
            this.ViewPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.ViewPurchase.Name = "ViewPurchase";
            this.ViewPurchase.Size = new System.Drawing.Size(187, 55);
            this.ViewPurchase.TabIndex = 4;
            this.ViewPurchase.Text = "Detalji nabavke";
            this.ViewPurchase.UseVisualStyleBackColor = false;
            this.ViewPurchase.Click += new System.EventHandler(this.ViewPurchase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(388, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pretraga po";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Broj Računa",
            "Radnik",
            "Dobavljač"});
            this.cmbSearchType.Location = new System.Drawing.Point(498, 13);
            this.cmbSearchType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(139, 28);
            this.cmbSearchType.TabIndex = 6;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // tbSearchtext
            // 
            this.tbSearchtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSearchtext.Location = new System.Drawing.Point(645, 15);
            this.tbSearchtext.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearchtext.Name = "tbSearchtext";
            this.tbSearchtext.Size = new System.Drawing.Size(248, 26);
            this.tbSearchtext.TabIndex = 7;
            this.tbSearchtext.TextChanged += new System.EventHandler(this.tbSearchtext_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(688, 405);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ukupan iznos troškova";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbSumPurchase
            // 
            this.tbSumPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSumPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSumPurchase.Location = new System.Drawing.Point(692, 429);
            this.tbSumPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.tbSumPurchase.Name = "tbSumPurchase";
            this.tbSumPurchase.ReadOnly = true;
            this.tbSumPurchase.Size = new System.Drawing.Size(145, 28);
            this.tbSumPurchase.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(24, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Od";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(65, 12);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFrom.MaxDate = new System.DateTime(2018, 12, 25, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(2018, 1, 25, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(135, 26);
            this.dtpFrom.TabIndex = 11;
            this.dtpFrom.Value = new System.DateTime(2018, 1, 25, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(208, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Do";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(247, 13);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTo.MaxDate = new System.DateTime(2018, 12, 25, 21, 39, 27, 0);
            this.dtpTo.MinDate = new System.DateTime(2018, 1, 25, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(139, 26);
            this.dtpTo.TabIndex = 13;
            this.dtpTo.Value = new System.DateTime(2018, 12, 25, 0, 0, 0, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            this.dtpTo.Enter += new System.EventHandler(this.dtpTo_Enter);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(840, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "[KM]";
            // 
            // uclTroskovnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSumPurchase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearchtext);
            this.Controls.Add(this.cmbSearchType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ViewPurchase);
            this.Controls.Add(this.stormPurchase);
            this.Controls.Add(this.newPurchase);
            this.Controls.Add(this.dgvPurchase);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uclTroskovnik";
            this.Size = new System.Drawing.Size(911, 470);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.Button newPurchase;
        private System.Windows.Forms.Button stormPurchase;
        private System.Windows.Forms.Button ViewPurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.TextBox tbSearchtext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSumPurchase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn suplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumValue;
        private System.Windows.Forms.Label label5;
    }
}
