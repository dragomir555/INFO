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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnIzmjeniKlijenta = new System.Windows.Forms.Button();
            this.tbSearchText = new System.Windows.Forms.TextBox();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.colNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUgovorOd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUgovorDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNoviKlijent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbContractOver = new System.Windows.Forms.CheckBox();
            this.cancelContract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIzmjeniKlijenta
            // 
            this.btnIzmjeniKlijenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIzmjeniKlijenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnIzmjeniKlijenta.FlatAppearance.BorderSize = 0;
            this.btnIzmjeniKlijenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnIzmjeniKlijenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmjeniKlijenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIzmjeniKlijenta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIzmjeniKlijenta.Location = new System.Drawing.Point(241, 404);
            this.btnIzmjeniKlijenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzmjeniKlijenta.Name = "btnIzmjeniKlijenta";
            this.btnIzmjeniKlijenta.Size = new System.Drawing.Size(187, 55);
            this.btnIzmjeniKlijenta.TabIndex = 1;
            this.btnIzmjeniKlijenta.Text = "Izmjeni klijenta";
            this.btnIzmjeniKlijenta.UseVisualStyleBackColor = false;
            this.btnIzmjeniKlijenta.Click += new System.EventHandler(this.btnIzmjeniKlijenta_Click);
            // 
            // tbSearchText
            // 
            this.tbSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSearchText.Location = new System.Drawing.Point(536, 18);
            this.tbSearchText.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearchText.Name = "tbSearchText";
            this.tbSearchText.Size = new System.Drawing.Size(316, 30);
            this.tbSearchText.TabIndex = 2;
            this.tbSearchText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.AllowUserToAddRows = false;
            this.dgvKlijenti.AllowUserToDeleteRows = false;
            this.dgvKlijenti.AllowUserToResizeRows = false;
            this.dgvKlijenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKlijenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKlijenti.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKlijenti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNaziv,
            this.colJIB,
            this.colGrad,
            this.colAddress,
            this.colUgovorOd,
            this.colUgovorDo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKlijenti.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKlijenti.Location = new System.Drawing.Point(27, 59);
            this.dgvKlijenti.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKlijenti.MultiSelect = false;
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            this.dgvKlijenti.RowHeadersVisible = false;
            this.dgvKlijenti.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(865, 337);
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
            this.colGrad.ReadOnly = true;
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Adresa";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colUgovorOd
            // 
            this.colUgovorOd.HeaderText = "UgovorOd";
            this.colUgovorOd.Name = "colUgovorOd";
            this.colUgovorOd.ReadOnly = true;
            // 
            // colUgovorDo
            // 
            this.colUgovorDo.HeaderText = "UgovorDo";
            this.colUgovorDo.Name = "colUgovorDo";
            this.colUgovorDo.ReadOnly = true;
            // 
            // btnNoviKlijent
            // 
            this.btnNoviKlijent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNoviKlijent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnNoviKlijent.FlatAppearance.BorderSize = 0;
            this.btnNoviKlijent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnNoviKlijent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoviKlijent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNoviKlijent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNoviKlijent.Location = new System.Drawing.Point(27, 404);
            this.btnNoviKlijent.Margin = new System.Windows.Forms.Padding(4);
            this.btnNoviKlijent.Name = "btnNoviKlijent";
            this.btnNoviKlijent.Size = new System.Drawing.Size(187, 55);
            this.btnNoviKlijent.TabIndex = 4;
            this.btnNoviKlijent.Text = "Novi klijent";
            this.btnNoviKlijent.UseVisualStyleBackColor = false;
            this.btnNoviKlijent.Click += new System.EventHandler(this.btnNoviKlijent_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(476, 404);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Novi ugovor";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Naziv",
            "JIB"});
            this.cmbSearchType.Location = new System.Drawing.Point(367, 16);
            this.cmbSearchType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(160, 33);
            this.cmbSearchType.TabIndex = 6;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(236, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pretraga po";
            // 
            // cbContractOver
            // 
            this.cbContractOver.AutoSize = true;
            this.cbContractOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbContractOver.Location = new System.Drawing.Point(27, 18);
            this.cbContractOver.Margin = new System.Windows.Forms.Padding(4);
            this.cbContractOver.Name = "cbContractOver";
            this.cbContractOver.Size = new System.Drawing.Size(178, 29);
            this.cbContractOver.TabIndex = 8;
            this.cbContractOver.Text = "Završeni ugovori";
            this.cbContractOver.UseVisualStyleBackColor = true;
            this.cbContractOver.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cancelContract
            // 
            this.cancelContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelContract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.cancelContract.FlatAppearance.BorderSize = 0;
            this.cancelContract.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.cancelContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelContract.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelContract.Location = new System.Drawing.Point(705, 404);
            this.cancelContract.Margin = new System.Windows.Forms.Padding(4);
            this.cancelContract.Name = "cancelContract";
            this.cancelContract.Size = new System.Drawing.Size(187, 55);
            this.cancelContract.TabIndex = 9;
            this.cancelContract.Text = "Ponisti ugovor";
            this.cancelContract.UseVisualStyleBackColor = false;
            this.cancelContract.Click += new System.EventHandler(this.button2_Click);
            // 
            // uclKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.cancelContract);
            this.Controls.Add(this.tbSearchText);
            this.Controls.Add(this.cmbSearchType);
            this.Controls.Add(this.cbContractOver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNoviKlijent);
            this.Controls.Add(this.dgvKlijenti);
            this.Controls.Add(this.btnIzmjeniKlijenta);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uclKlijenti";
            this.Size = new System.Drawing.Size(911, 470);
            this.Load += new System.EventHandler(this.uclKlijenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnIzmjeniKlijenta;
        private System.Windows.Forms.TextBox tbSearchText;
        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.Button btnNoviKlijent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbContractOver;
        private System.Windows.Forms.Button cancelContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUgovorOd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUgovorDo;
    }
}
