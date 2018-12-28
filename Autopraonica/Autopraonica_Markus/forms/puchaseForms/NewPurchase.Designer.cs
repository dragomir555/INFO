namespace Autopraonica_Markus.forms.puchaseForms
{
    partial class NewPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPurchase));
            this.tbNumberPurchase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.clNameItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSumPrize = new System.Windows.Forms.Label();
            this.newItemT = new System.Windows.Forms.Button();
            this.deleteItemT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNumberPurchase
            // 
            this.tbNumberPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNumberPurchase.Location = new System.Drawing.Point(94, 20);
            this.tbNumberPurchase.Name = "tbNumberPurchase";
            this.tbNumberPurchase.Size = new System.Drawing.Size(169, 22);
            this.tbNumberPurchase.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj racuna";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNameItem,
            this.clQuantity,
            this.clUnit,
            this.clPrice});
            this.dgvItems.Location = new System.Drawing.Point(3, 52);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.Size = new System.Drawing.Size(535, 182);
            this.dgvItems.TabIndex = 2;
            // 
            // clNameItem
            // 
            this.clNameItem.HeaderText = "Naziv stavke";
            this.clNameItem.Name = "clNameItem";
            // 
            // clQuantity
            // 
            this.clQuantity.HeaderText = "Kolicina";
            this.clQuantity.Name = "clQuantity";
            // 
            // clUnit
            // 
            this.clUnit.HeaderText = "Jedinica";
            this.clUnit.Name = "clUnit";
            // 
            // clPrice
            // 
            this.clPrice.HeaderText = "Cijena";
            this.clPrice.Name = "clPrice";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(82, 267);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 35);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Zavrsi";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(295, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Otkazi";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ukupan iznos nabavke:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(205, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "[KM]";
            // 
            // lbSumPrize
            // 
            this.lbSumPrize.AutoSize = true;
            this.lbSumPrize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSumPrize.Location = new System.Drawing.Point(157, 237);
            this.lbSumPrize.Name = "lbSumPrize";
            this.lbSumPrize.Size = new System.Drawing.Size(52, 16);
            this.lbSumPrize.TabIndex = 8;
            this.lbSumPrize.Text = "150.25";
            // 
            // newItemT
            // 
            this.newItemT.Location = new System.Drawing.Point(269, 16);
            this.newItemT.Name = "newItemT";
            this.newItemT.Size = new System.Drawing.Size(132, 30);
            this.newItemT.TabIndex = 9;
            this.newItemT.Text = "Nova stavka";
            this.newItemT.UseVisualStyleBackColor = true;
            this.newItemT.Click += new System.EventHandler(this.newItemT_Click);
            // 
            // deleteItemT
            // 
            this.deleteItemT.Location = new System.Drawing.Point(407, 16);
            this.deleteItemT.Name = "deleteItemT";
            this.deleteItemT.Size = new System.Drawing.Size(131, 30);
            this.deleteItemT.TabIndex = 10;
            this.deleteItemT.Text = "Ukloni stavku";
            this.deleteItemT.UseVisualStyleBackColor = true;
            // 
            // NewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 314);
            this.Controls.Add(this.deleteItemT);
            this.Controls.Add(this.newItemT);
            this.Controls.Add(this.lbSumPrize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNumberPurchase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewPurchase";
            this.Text = "Nova nabavka";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNumberPurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNameItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPrice;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSumPrize;
        private System.Windows.Forms.Button newItemT;
        private System.Windows.Forms.Button deleteItemT;
    }
}