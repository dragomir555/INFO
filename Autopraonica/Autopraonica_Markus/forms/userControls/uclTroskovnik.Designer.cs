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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.newPurchase = new System.Windows.Forms.Button();
            this.stormPurchase = new System.Windows.Forms.Button();
            this.ViewPurchase = new System.Windows.Forms.Button();
            this.purchaseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchaseNumber,
            this.suplierName,
            this.usernameEmployee,
            this.time,
            this.sumValue});
            this.dataGridView1.Location = new System.Drawing.Point(20, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(649, 243);
            this.dataGridView1.TabIndex = 0;
            // 
            // newPurchase
            // 
            this.newPurchase.Location = new System.Drawing.Point(20, 21);
            this.newPurchase.Name = "newPurchase";
            this.newPurchase.Size = new System.Drawing.Size(113, 42);
            this.newPurchase.TabIndex = 1;
            this.newPurchase.Text = "Nova nabavka";
            this.newPurchase.UseVisualStyleBackColor = true;
            // 
            // stormPurchase
            // 
            this.stormPurchase.Location = new System.Drawing.Point(160, 21);
            this.stormPurchase.Name = "stormPurchase";
            this.stormPurchase.Size = new System.Drawing.Size(113, 41);
            this.stormPurchase.TabIndex = 2;
            this.stormPurchase.Text = "Poništi nabavku";
            this.stormPurchase.UseVisualStyleBackColor = true;
            // 
            // ViewPurchase
            // 
            this.ViewPurchase.Location = new System.Drawing.Point(303, 21);
            this.ViewPurchase.Name = "ViewPurchase";
            this.ViewPurchase.Size = new System.Drawing.Size(130, 42);
            this.ViewPurchase.TabIndex = 4;
            this.ViewPurchase.Text = "Detalji nabavke";
            this.ViewPurchase.UseVisualStyleBackColor = true;
            // 
            // purchaseNumber
            // 
            this.purchaseNumber.HeaderText = "Broj računa";
            this.purchaseNumber.Name = "purchaseNumber";
            this.purchaseNumber.ReadOnly = true;
            // 
            // suplierName
            // 
            this.suplierName.HeaderText = "Ime dobavljaca";
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
            // uclTroskovnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ViewPurchase);
            this.Controls.Add(this.stormPurchase);
            this.Controls.Add(this.newPurchase);
            this.Controls.Add(this.dataGridView1);
            this.Name = "uclTroskovnik";
            this.Size = new System.Drawing.Size(695, 382);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn suplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumValue;
        private System.Windows.Forms.Button newPurchase;
        private System.Windows.Forms.Button stormPurchase;
        private System.Windows.Forms.Button ViewPurchase;
    }
}
