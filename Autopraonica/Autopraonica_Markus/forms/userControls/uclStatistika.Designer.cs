namespace Autopraonica_Markus.forms.userControls
{
    partial class uclStatistika
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatistics = new System.Windows.Forms.ComboBox();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateStatistics = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberite vrstu statistike";
            // 
            // cbStatistics
            // 
            this.cbStatistics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatistics.FormattingEnabled = true;
            this.cbStatistics.Items.AddRange(new object[] {
            "Statistika po radniku",
            "Statistika po klijentu",
            "Ukupna statistika"});
            this.cbStatistics.Location = new System.Drawing.Point(191, 26);
            this.cbStatistics.Name = "cbStatistics";
            this.cbStatistics.Size = new System.Drawing.Size(121, 21);
            this.cbStatistics.TabIndex = 1;
            this.cbStatistics.SelectedIndexChanged += new System.EventHandler(this.cbStatistics_SelectedIndexChanged);
            // 
            // cbEmployee
            // 
            this.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployee.Enabled = false;
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(36, 144);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(121, 21);
            this.cbEmployee.TabIndex = 2;
            this.cbEmployee.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbFormat);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Odaberite radnika";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unesite klijenta";
            // 
            // cbClient
            // 
            this.cbClient.Enabled = false;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(216, 144);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(121, 21);
            this.cbClient.TabIndex = 5;
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 231);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(66, 268);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Od";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Do";
            // 
            // btnGenerateStatistics
            // 
            this.btnGenerateStatistics.Location = new System.Drawing.Point(259, 340);
            this.btnGenerateStatistics.Name = "btnGenerateStatistics";
            this.btnGenerateStatistics.Size = new System.Drawing.Size(98, 23);
            this.btnGenerateStatistics.TabIndex = 10;
            this.btnGenerateStatistics.Text = "Generisi statistiku";
            this.btnGenerateStatistics.UseVisualStyleBackColor = true;
            this.btnGenerateStatistics.Click += new System.EventHandler(this.btnGenerateStatistics_Click);
            // 
            // uclStatistika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenerateStatistics);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.cbStatistics);
            this.Controls.Add(this.label1);
            this.Name = "uclStatistika";
            this.Size = new System.Drawing.Size(601, 382);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatistics;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerateStatistics;
    }
}
