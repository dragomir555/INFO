namespace Autopraonica_Markus
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pbChangePass = new System.Windows.Forms.PictureBox();
            this.pbInactive = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.pbLogOut = new System.Windows.Forms.PictureBox();
            this.cmbHelper = new System.Windows.Forms.ComboBox();
            this.btnRemoveHelper = new System.Windows.Forms.Button();
            this.btnAddHelper = new System.Windows.Forms.Button();
            this.lblHelper = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnStatistika = new System.Windows.Forms.Button();
            this.btnUsluge = new System.Windows.Forms.Button();
            this.btnIzdRac = new System.Windows.Forms.Button();
            this.btnZaposleni = new System.Windows.Forms.Button();
            this.btnKlijenti = new System.Windows.Forms.Button();
            this.btnCjenovnik = new System.Windows.Forms.Button();
            this.btnTroskovnik = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChangePass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInactive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).BeginInit();
            this.tlpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStatus
            // 
            this.pnlStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.pnlStatus.Controls.Add(this.pbChangePass);
            this.pnlStatus.Controls.Add(this.pbInactive);
            this.pnlStatus.Controls.Add(this.pbSettings);
            this.pnlStatus.Controls.Add(this.pbLogOut);
            this.pnlStatus.Controls.Add(this.cmbHelper);
            this.pnlStatus.Controls.Add(this.btnRemoveHelper);
            this.pnlStatus.Controls.Add(this.btnAddHelper);
            this.pnlStatus.Controls.Add(this.lblHelper);
            this.pnlStatus.Controls.Add(this.lblUser);
            this.pnlStatus.Controls.Add(this.lblDate);
            this.pnlStatus.Controls.Add(this.lblTime);
            this.pnlStatus.Location = new System.Drawing.Point(267, 0);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(4);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(977, 86);
            this.pnlStatus.TabIndex = 1;
            this.pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pbChangePass
            // 
            this.pbChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChangePass.Image = global::Autopraonica_Markus.Properties.Resources.key;
            this.pbChangePass.Location = new System.Drawing.Point(610, 15);
            this.pbChangePass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbChangePass.Name = "pbChangePass";
            this.pbChangePass.Size = new System.Drawing.Size(64, 64);
            this.pbChangePass.TabIndex = 13;
            this.pbChangePass.TabStop = false;
            this.pbChangePass.Click += new System.EventHandler(this.pbChangePass_Click);
            this.pbChangePass.MouseHover += new System.EventHandler(this.pbChangePass_MouseHover);
            // 
            // pbInactive
            // 
            this.pbInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInactive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInactive.Image = global::Autopraonica_Markus.Properties.Resources.lock1;
            this.pbInactive.Location = new System.Drawing.Point(683, 16);
            this.pbInactive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbInactive.Name = "pbInactive";
            this.pbInactive.Size = new System.Drawing.Size(64, 64);
            this.pbInactive.TabIndex = 12;
            this.pbInactive.TabStop = false;
            this.pbInactive.Click += new System.EventHandler(this.pbInactive_Click);
            this.pbInactive.MouseHover += new System.EventHandler(this.pbInactive_MouseHover);
            // 
            // pbSettings
            // 
            this.pbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSettings.Image = global::Autopraonica_Markus.Properties.Resources.set;
            this.pbSettings.Location = new System.Drawing.Point(540, 16);
            this.pbSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(64, 64);
            this.pbSettings.TabIndex = 11;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            this.pbSettings.MouseHover += new System.EventHandler(this.pbSettings_MouseHover);
            // 
            // pbLogOut
            // 
            this.pbLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogOut.Image = global::Autopraonica_Markus.Properties.Resources.izlaz;
            this.pbLogOut.Location = new System.Drawing.Point(766, 15);
            this.pbLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbLogOut.Name = "pbLogOut";
            this.pbLogOut.Size = new System.Drawing.Size(64, 64);
            this.pbLogOut.TabIndex = 10;
            this.pbLogOut.TabStop = false;
            this.pbLogOut.Click += new System.EventHandler(this.pbLogOut_Click);
            this.pbLogOut.MouseHover += new System.EventHandler(this.pbLogOut_MouseHover);
            // 
            // cmbHelper
            // 
            this.cmbHelper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHelper.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHelper.FormattingEnabled = true;
            this.cmbHelper.Location = new System.Drawing.Point(323, 47);
            this.cmbHelper.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHelper.Name = "cmbHelper";
            this.cmbHelper.Size = new System.Drawing.Size(193, 32);
            this.cmbHelper.TabIndex = 7;
            this.cmbHelper.Visible = false;
            this.cmbHelper.SelectionChangeCommitted += new System.EventHandler(this.cmbHelper_SelectionChangeCommitted);
            this.cmbHelper.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbHelper_Format);
            // 
            // btnRemoveHelper
            // 
            this.btnRemoveHelper.BackColor = System.Drawing.Color.White;
            this.btnRemoveHelper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveHelper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveHelper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnRemoveHelper.Location = new System.Drawing.Point(213, 47);
            this.btnRemoveHelper.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveHelper.Name = "btnRemoveHelper";
            this.btnRemoveHelper.Size = new System.Drawing.Size(104, 33);
            this.btnRemoveHelper.TabIndex = 6;
            this.btnRemoveHelper.Text = "Ukloni";
            this.btnRemoveHelper.UseVisualStyleBackColor = false;
            this.btnRemoveHelper.Visible = false;
            this.btnRemoveHelper.Click += new System.EventHandler(this.btnRemoveHelper_Click);
            // 
            // btnAddHelper
            // 
            this.btnAddHelper.BackColor = System.Drawing.Color.White;
            this.btnAddHelper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHelper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHelper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnAddHelper.Location = new System.Drawing.Point(213, 46);
            this.btnAddHelper.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddHelper.Name = "btnAddHelper";
            this.btnAddHelper.Size = new System.Drawing.Size(104, 33);
            this.btnAddHelper.TabIndex = 5;
            this.btnAddHelper.Text = "Dodaj";
            this.btnAddHelper.UseVisualStyleBackColor = false;
            this.btnAddHelper.Click += new System.EventHandler(this.btnAddHelper_Click);
            // 
            // lblHelper
            // 
            this.lblHelper.AutoSize = true;
            this.lblHelper.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelper.ForeColor = System.Drawing.Color.White;
            this.lblHelper.Location = new System.Drawing.Point(209, 12);
            this.lblHelper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelper.Name = "lblHelper";
            this.lblHelper.Size = new System.Drawing.Size(105, 29);
            this.lblHelper.TabIndex = 4;
            this.lblHelper.Text = "Ispomoć";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(9, 12);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(182, 29);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Marko Markovic";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(838, 47);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(129, 29);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "13.12.2018";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(837, 12);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(82, 31);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "14:47";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.ForeColor = System.Drawing.Color.Black;
            this.pnlContent.Location = new System.Drawing.Point(267, 86);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(977, 527);
            this.pnlContent.TabIndex = 2;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // tlpMenu
            // 
            this.tlpMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.tlpMenu.ColumnCount = 1;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Controls.Add(this.btnStatistika, 0, 8);
            this.tlpMenu.Controls.Add(this.btnUsluge, 0, 2);
            this.tlpMenu.Controls.Add(this.btnIzdRac, 0, 7);
            this.tlpMenu.Controls.Add(this.btnZaposleni, 0, 6);
            this.tlpMenu.Controls.Add(this.btnKlijenti, 0, 5);
            this.tlpMenu.Controls.Add(this.btnCjenovnik, 0, 4);
            this.tlpMenu.Controls.Add(this.btnTroskovnik, 0, 3);
            this.tlpMenu.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpMenu.Location = new System.Drawing.Point(0, 0);
            this.tlpMenu.Margin = new System.Windows.Forms.Padding(4);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 10;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpMenu.Size = new System.Drawing.Size(267, 620);
            this.tlpMenu.TabIndex = 4;
            this.tlpMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpContent_Paint);
            // 
            // btnStatistika
            // 
            this.btnStatistika.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStatistika.FlatAppearance.BorderSize = 0;
            this.btnStatistika.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnStatistika.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistika.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStatistika.ForeColor = System.Drawing.Color.White;
            this.btnStatistika.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistika.Image")));
            this.btnStatistika.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistika.Location = new System.Drawing.Point(4, 536);
            this.btnStatistika.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatistika.Name = "btnStatistika";
            this.btnStatistika.Size = new System.Drawing.Size(259, 54);
            this.btnStatistika.TabIndex = 3;
            this.btnStatistika.Text = "Statistika";
            this.btnStatistika.UseVisualStyleBackColor = true;
            this.btnStatistika.Click += new System.EventHandler(this.btnStatistika_Click);
            // 
            // btnUsluge
            // 
            this.btnUsluge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUsluge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnUsluge.FlatAppearance.BorderSize = 0;
            this.btnUsluge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnUsluge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsluge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsluge.ForeColor = System.Drawing.Color.White;
            this.btnUsluge.Image = ((System.Drawing.Image)(resources.GetObject("btnUsluge.Image")));
            this.btnUsluge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsluge.Location = new System.Drawing.Point(4, 164);
            this.btnUsluge.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsluge.Name = "btnUsluge";
            this.btnUsluge.Size = new System.Drawing.Size(259, 54);
            this.btnUsluge.TabIndex = 0;
            this.btnUsluge.Text = "Usluge";
            this.btnUsluge.UseVisualStyleBackColor = true;
            this.btnUsluge.Click += new System.EventHandler(this.btnUsluge_Click);
            // 
            // btnIzdRac
            // 
            this.btnIzdRac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIzdRac.FlatAppearance.BorderSize = 0;
            this.btnIzdRac.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnIzdRac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzdRac.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIzdRac.ForeColor = System.Drawing.Color.White;
            this.btnIzdRac.Image = ((System.Drawing.Image)(resources.GetObject("btnIzdRac.Image")));
            this.btnIzdRac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIzdRac.Location = new System.Drawing.Point(4, 474);
            this.btnIzdRac.Margin = new System.Windows.Forms.Padding(4);
            this.btnIzdRac.Name = "btnIzdRac";
            this.btnIzdRac.Size = new System.Drawing.Size(259, 54);
            this.btnIzdRac.TabIndex = 0;
            this.btnIzdRac.Text = "Računi";
            this.btnIzdRac.UseVisualStyleBackColor = true;
            this.btnIzdRac.Click += new System.EventHandler(this.btnIzdRac_Click);
            // 
            // btnZaposleni
            // 
            this.btnZaposleni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZaposleni.FlatAppearance.BorderSize = 0;
            this.btnZaposleni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnZaposleni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaposleni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnZaposleni.ForeColor = System.Drawing.Color.White;
            this.btnZaposleni.Image = ((System.Drawing.Image)(resources.GetObject("btnZaposleni.Image")));
            this.btnZaposleni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZaposleni.Location = new System.Drawing.Point(4, 412);
            this.btnZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.btnZaposleni.Name = "btnZaposleni";
            this.btnZaposleni.Size = new System.Drawing.Size(259, 54);
            this.btnZaposleni.TabIndex = 2;
            this.btnZaposleni.Text = "Zaposleni";
            this.btnZaposleni.UseVisualStyleBackColor = true;
            this.btnZaposleni.Click += new System.EventHandler(this.btnZaposleni_Click);
            // 
            // btnKlijenti
            // 
            this.btnKlijenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKlijenti.FlatAppearance.BorderSize = 0;
            this.btnKlijenti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnKlijenti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKlijenti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKlijenti.ForeColor = System.Drawing.Color.White;
            this.btnKlijenti.Image = ((System.Drawing.Image)(resources.GetObject("btnKlijenti.Image")));
            this.btnKlijenti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKlijenti.Location = new System.Drawing.Point(4, 350);
            this.btnKlijenti.Margin = new System.Windows.Forms.Padding(4);
            this.btnKlijenti.Name = "btnKlijenti";
            this.btnKlijenti.Size = new System.Drawing.Size(259, 54);
            this.btnKlijenti.TabIndex = 0;
            this.btnKlijenti.Text = "Klijenti";
            this.btnKlijenti.UseVisualStyleBackColor = true;
            this.btnKlijenti.Click += new System.EventHandler(this.btnKlijenti_Click);
            // 
            // btnCjenovnik
            // 
            this.btnCjenovnik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCjenovnik.FlatAppearance.BorderSize = 0;
            this.btnCjenovnik.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnCjenovnik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCjenovnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCjenovnik.ForeColor = System.Drawing.Color.White;
            this.btnCjenovnik.Image = ((System.Drawing.Image)(resources.GetObject("btnCjenovnik.Image")));
            this.btnCjenovnik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCjenovnik.Location = new System.Drawing.Point(4, 288);
            this.btnCjenovnik.Margin = new System.Windows.Forms.Padding(4);
            this.btnCjenovnik.Name = "btnCjenovnik";
            this.btnCjenovnik.Size = new System.Drawing.Size(259, 54);
            this.btnCjenovnik.TabIndex = 0;
            this.btnCjenovnik.Text = "Cjenovnik";
            this.btnCjenovnik.UseVisualStyleBackColor = true;
            this.btnCjenovnik.Click += new System.EventHandler(this.btnCjenovnik_Click);
            // 
            // btnTroskovnik
            // 
            this.btnTroskovnik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTroskovnik.FlatAppearance.BorderSize = 0;
            this.btnTroskovnik.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnTroskovnik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTroskovnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTroskovnik.ForeColor = System.Drawing.Color.White;
            this.btnTroskovnik.Image = ((System.Drawing.Image)(resources.GetObject("btnTroskovnik.Image")));
            this.btnTroskovnik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTroskovnik.Location = new System.Drawing.Point(4, 226);
            this.btnTroskovnik.Margin = new System.Windows.Forms.Padding(4);
            this.btnTroskovnik.Name = "btnTroskovnik";
            this.btnTroskovnik.Size = new System.Drawing.Size(259, 54);
            this.btnTroskovnik.TabIndex = 1;
            this.btnTroskovnik.Text = "Troškovnik";
            this.btnTroskovnik.UseVisualStyleBackColor = true;
            this.btnTroskovnik.Click += new System.EventHandler(this.btnTroskovnik_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 613);
            this.Controls.Add(this.tlpMenu);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1262, 660);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Markus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChangePass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInactive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).EndInit();
            this.tlpMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnTroskovnik;
        private System.Windows.Forms.Button btnUsluge;
        private System.Windows.Forms.Button btnIzdRac;
        private System.Windows.Forms.Button btnStatistika;
        private System.Windows.Forms.Button btnZaposleni;
        private System.Windows.Forms.Button btnKlijenti;
        public System.Windows.Forms.Button btnCjenovnik;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblHelper;
        private System.Windows.Forms.Button btnRemoveHelper;
        private System.Windows.Forms.Button btnAddHelper;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbHelper;
        private System.Windows.Forms.PictureBox pbChangePass;
        private System.Windows.Forms.PictureBox pbInactive;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.PictureBox pbLogOut;
        private System.Windows.Forms.ToolTip tlTip;
    }
}

