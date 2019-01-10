﻿namespace Autopraonica_Markus.forms.puchaseForms
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
            this.components = new System.ComponentModel.Container();
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
            this.lbSumPrize = new System.Windows.Forms.Label();
            this.btnNewItemT = new System.Windows.Forms.Button();
            this.btnDeleteItemT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNameSuplier = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNumberPurchase
            // 
            this.tbNumberPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNumberPurchase.Location = new System.Drawing.Point(139, 15);
            this.tbNumberPurchase.Name = "tbNumberPurchase";
            this.tbNumberPurchase.Size = new System.Drawing.Size(242, 22);
            this.tbNumberPurchase.TabIndex = 0;
            this.tbNumberPurchase.Validating += new System.ComponentModel.CancelEventHandler(this.tbNumberPurchase_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(15, 18);
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
            this.dgvItems.Location = new System.Drawing.Point(3, 83);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(535, 174);
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
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(94, 279);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 35);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Zavrsi";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(295, 279);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Otkazi";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ukupan iznos nabavke:";
            // 
            // lbSumPrize
            // 
            this.lbSumPrize.AutoSize = true;
            this.lbSumPrize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSumPrize.Location = new System.Drawing.Point(156, 260);
            this.lbSumPrize.Name = "lbSumPrize";
            this.lbSumPrize.Size = new System.Drawing.Size(0, 16);
            this.lbSumPrize.TabIndex = 8;
            // 
            // btnNewItemT
            // 
            this.btnNewItemT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnNewItemT.FlatAppearance.BorderSize = 0;
            this.btnNewItemT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnNewItemT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewItemT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNewItemT.ForeColor = System.Drawing.Color.White;
            this.btnNewItemT.Location = new System.Drawing.Point(407, 11);
            this.btnNewItemT.Name = "btnNewItemT";
            this.btnNewItemT.Size = new System.Drawing.Size(132, 30);
            this.btnNewItemT.TabIndex = 9;
            this.btnNewItemT.Text = "Nova stavka";
            this.btnNewItemT.UseVisualStyleBackColor = false;
            this.btnNewItemT.Click += new System.EventHandler(this.newItemT_Click);
            // 
            // btnDeleteItemT
            // 
            this.btnDeleteItemT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.btnDeleteItemT.FlatAppearance.BorderSize = 0;
            this.btnDeleteItemT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(46)))), ((int)(((byte)(140)))));
            this.btnDeleteItemT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItemT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteItemT.ForeColor = System.Drawing.Color.White;
            this.btnDeleteItemT.Location = new System.Drawing.Point(407, 47);
            this.btnDeleteItemT.Name = "btnDeleteItemT";
            this.btnDeleteItemT.Size = new System.Drawing.Size(131, 30);
            this.btnDeleteItemT.TabIndex = 10;
            this.btnDeleteItemT.Text = "Ukloni stavku";
            this.btnDeleteItemT.UseVisualStyleBackColor = false;
            this.btnDeleteItemT.Click += new System.EventHandler(this.deleteItemT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(15, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Naziv dobavljača";
            // 
            // tbNameSuplier
            // 
            this.tbNameSuplier.Location = new System.Drawing.Point(139, 53);
            this.tbNameSuplier.Name = "tbNameSuplier";
            this.tbNameSuplier.Size = new System.Drawing.Size(242, 20);
            this.tbNameSuplier.TabIndex = 12;
            this.tbNameSuplier.Validating += new System.ComponentModel.CancelEventHandler(this.tbNameSuplier_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // NewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 326);
            this.Controls.Add(this.tbNameSuplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDeleteItemT);
            this.Controls.Add(this.btnNewItemT);
            this.Controls.Add(this.lbSumPrize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNumberPurchase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nova nabavka";
            this.Load += new System.EventHandler(this.NewPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.Label lbSumPrize;
        private System.Windows.Forms.Button btnNewItemT;
        private System.Windows.Forms.Button btnDeleteItemT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNameSuplier;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}