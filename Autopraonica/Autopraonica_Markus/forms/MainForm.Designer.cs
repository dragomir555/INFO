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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnTroskovnik = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnUsluge = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.pnlMenu.Controls.Add(this.btnUsluge);
            this.pnlMenu.Controls.Add(this.btnTroskovnik);
            this.pnlMenu.Location = new System.Drawing.Point(0, -4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(203, 456);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnTroskovnik
            // 
            this.btnTroskovnik.Location = new System.Drawing.Point(38, 187);
            this.btnTroskovnik.Name = "btnTroskovnik";
            this.btnTroskovnik.Size = new System.Drawing.Size(111, 23);
            this.btnTroskovnik.TabIndex = 1;
            this.btnTroskovnik.Text = "Troskovnik";
            this.btnTroskovnik.UseVisualStyleBackColor = true;
            this.btnTroskovnik.Click += new System.EventHandler(this.btnTroskovnik_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Location = new System.Drawing.Point(201, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(601, 74);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.Yellow;
            this.pnlContent.Location = new System.Drawing.Point(201, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(601, 382);
            this.pnlContent.TabIndex = 2;
            // 
            // btnUsluge
            // 
            this.btnUsluge.Location = new System.Drawing.Point(38, 135);
            this.btnUsluge.Name = "btnUsluge";
            this.btnUsluge.Size = new System.Drawing.Size(111, 23);
            this.btnUsluge.TabIndex = 0;
            this.btnUsluge.Text = "Usluge";
            this.btnUsluge.UseVisualStyleBackColor = true;
            this.btnUsluge.Click += new System.EventHandler(this.btnUsluge_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Markus";
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnTroskovnik;
        private System.Windows.Forms.Button btnUsluge;
    }
}

