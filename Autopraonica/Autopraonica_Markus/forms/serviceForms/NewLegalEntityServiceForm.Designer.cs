namespace Autopraonica_Markus.forms.serviceForms
{
    partial class NewLegalEntityServiceForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLegalEntityServiceForm));
            this.lblServiceType = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.lblPricelistItem = new System.Windows.Forms.Label();
            this.cmbPricelistItem = new System.Windows.Forms.ComboBox();
            this.lblCarBrand = new System.Windows.Forms.Label();
            this.cmbCarBrand = new System.Windows.Forms.ComboBox();
            this.btnAddCarBrand = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCarpetSize = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.tbCarpetSize = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblLicencePlates = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mtbLicencePlate = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServiceType
            // 
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblServiceType.Location = new System.Drawing.Point(30, 230);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(129, 16);
            this.lblServiceType.TabIndex = 0;
            this.lblServiceType.Text = "Kategorija usluge";
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(229, 218);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(270, 28);
            this.cmbServiceType.TabIndex = 5;
            this.cmbServiceType.SelectedIndexChanged += new System.EventHandler(this.cmbServiceType_SelectedIndexChanged);
            // 
            // lblPricelistItem
            // 
            this.lblPricelistItem.AutoSize = true;
            this.lblPricelistItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPricelistItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblPricelistItem.Location = new System.Drawing.Point(30, 280);
            this.lblPricelistItem.Name = "lblPricelistItem";
            this.lblPricelistItem.Size = new System.Drawing.Size(57, 16);
            this.lblPricelistItem.TabIndex = 0;
            this.lblPricelistItem.Text = "Usluga";
            // 
            // cmbPricelistItem
            // 
            this.cmbPricelistItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPricelistItem.FormattingEnabled = true;
            this.cmbPricelistItem.Location = new System.Drawing.Point(229, 268);
            this.cmbPricelistItem.Name = "cmbPricelistItem";
            this.cmbPricelistItem.Size = new System.Drawing.Size(270, 28);
            this.cmbPricelistItem.TabIndex = 6;
            this.cmbPricelistItem.SelectedIndexChanged += new System.EventHandler(this.cmbPricelistItem_SelectedIndexChanged);
            // 
            // lblCarBrand
            // 
            this.lblCarBrand.AutoSize = true;
            this.lblCarBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblCarBrand.Location = new System.Drawing.Point(30, 330);
            this.lblCarBrand.Name = "lblCarBrand";
            this.lblCarBrand.Size = new System.Drawing.Size(132, 16);
            this.lblCarBrand.TabIndex = 0;
            this.lblCarBrand.Text = "Marka automobila";
            // 
            // cmbCarBrand
            // 
            this.cmbCarBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCarBrand.FormattingEnabled = true;
            this.cmbCarBrand.Location = new System.Drawing.Point(229, 318);
            this.cmbCarBrand.Name = "cmbCarBrand";
            this.cmbCarBrand.Size = new System.Drawing.Size(236, 28);
            this.cmbCarBrand.TabIndex = 7;
            // 
            // btnAddCarBrand
            // 
            this.btnAddCarBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnAddCarBrand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnAddCarBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCarBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCarBrand.ForeColor = System.Drawing.Color.White;
            this.btnAddCarBrand.Location = new System.Drawing.Point(471, 318);
            this.btnAddCarBrand.Name = "btnAddCarBrand";
            this.btnAddCarBrand.Size = new System.Drawing.Size(28, 28);
            this.btnAddCarBrand.TabIndex = 0;
            this.btnAddCarBrand.Text = "+";
            this.btnAddCarBrand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddCarBrand.UseVisualStyleBackColor = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblPrice.Location = new System.Drawing.Point(30, 380);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 16);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Cijena";
            // 
            // lblCarpetSize
            // 
            this.lblCarpetSize.AutoSize = true;
            this.lblCarpetSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarpetSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblCarpetSize.Location = new System.Drawing.Point(30, 330);
            this.lblCarpetSize.Name = "lblCarpetSize";
            this.lblCarpetSize.Size = new System.Drawing.Size(83, 16);
            this.lblCarpetSize.TabIndex = 0;
            this.lblCarpetSize.Text = "Kvadratura";
            this.lblCarpetSize.Visible = false;
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(229, 370);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(270, 26);
            this.tbPrice.TabIndex = 8;
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            this.tbPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbPrice_Validating);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(200, 430);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 35);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Potvrdi";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(359, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Otkaži";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblClient.Location = new System.Drawing.Point(30, 30);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(101, 16);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Naziv kljienta";
            // 
            // cmbClient
            // 
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(229, 18);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(270, 28);
            this.cmbClient.TabIndex = 1;
            // 
            // tbCarpetSize
            // 
            this.tbCarpetSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCarpetSize.Location = new System.Drawing.Point(229, 320);
            this.tbCarpetSize.Name = "tbCarpetSize";
            this.tbCarpetSize.Size = new System.Drawing.Size(270, 26);
            this.tbCarpetSize.TabIndex = 0;
            this.tbCarpetSize.Visible = false;
            this.tbCarpetSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCarpetSize_KeyPress);
            this.tbCarpetSize.Validating += new System.ComponentModel.CancelEventHandler(this.tbCarpetSize_Validating);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblFirstName.Location = new System.Drawing.Point(30, 80);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(33, 16);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "Ime";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblLastName.Location = new System.Drawing.Point(30, 130);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 16);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Prezime";
            // 
            // lblLicencePlates
            // 
            this.lblLicencePlates.AutoSize = true;
            this.lblLicencePlates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencePlates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.lblLicencePlates.Location = new System.Drawing.Point(30, 180);
            this.lblLicencePlates.Name = "lblLicencePlates";
            this.lblLicencePlates.Size = new System.Drawing.Size(143, 16);
            this.lblLicencePlates.TabIndex = 0;
            this.lblLicencePlates.Text = "Registarske tablice";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstName.Location = new System.Drawing.Point(229, 70);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(270, 26);
            this.tbFirstName.TabIndex = 2;
            this.tbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstName_Validating);
            // 
            // tbLastName
            // 
            this.tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastName.Location = new System.Drawing.Point(229, 120);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(270, 26);
            this.tbLastName.TabIndex = 3;
            this.tbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.tbLastName_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // mtbLicencePlate
            // 
            this.mtbLicencePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbLicencePlate.Location = new System.Drawing.Point(229, 170);
            this.mtbLicencePlate.Mask = "A00-L-000";
            this.mtbLicencePlate.Name = "mtbLicencePlate";
            this.mtbLicencePlate.Size = new System.Drawing.Size(270, 26);
            this.mtbLicencePlate.TabIndex = 9;
            this.mtbLicencePlate.Validating += new System.ComponentModel.CancelEventHandler(this.mtbLicencePlate_Validating);
            // 
            // NewLegalEntityServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 483);
            this.Controls.Add(this.mtbLicencePlate);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.lblLicencePlates);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.tbCarpetSize);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.lblCarpetSize);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnAddCarBrand);
            this.Controls.Add(this.cmbCarBrand);
            this.Controls.Add(this.lblCarBrand);
            this.Controls.Add(this.cmbPricelistItem);
            this.Controls.Add(this.lblPricelistItem);
            this.Controls.Add(this.cmbServiceType);
            this.Controls.Add(this.lblServiceType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewLegalEntityServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Markus";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.Label lblPricelistItem;
        private System.Windows.Forms.ComboBox cmbPricelistItem;
        private System.Windows.Forms.Label lblCarBrand;
        private System.Windows.Forms.ComboBox cmbCarBrand;
        private System.Windows.Forms.Button btnAddCarBrand;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCarpetSize;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.TextBox tbCarpetSize;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblLicencePlates;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox mtbLicencePlate;
    }
}