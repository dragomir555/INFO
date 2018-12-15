using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.Model.Entities;
using Autopraonica_Markus.forms.clientForms;

namespace Autopraonica_Markus.forms.userControls
{
    public partial class uclKlijenti : UserControl
    {
        private static uclKlijenti instance;

        public static uclKlijenti Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new uclKlijenti();
                }
                return instance;
            }
        }
        public uclKlijenti()
        {
            InitializeComponent();
        }


        private void uclKlijenti_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void FillTable()
        {
            dgvKlijenti.Rows.Clear();
            using(MarkusDb context=new MarkusDb())
            {
                var klijenti = (from c in context.clients select c).ToList();
                foreach(var c in klijenti)
                {
                    DataGridViewRow r = new DataGridViewRow() {Tag=c};
                    r.CreateCells(dgvKlijenti);
                   // var to = c.DateTo;
                    r.SetValues(c.Name, c.UID, c.City_Id, c.Address,"Treba","Treba");
                    dgvKlijenti.Rows.Add(r);
                    
                }
            }
        }

        private void btnNoviKlijent_Click(object sender, EventArgs e)
        {
            NewClientForm newClientForm = new NewClientForm();
            if (DialogResult.OK == newClientForm.ShowDialog())
            {
                try
                {
                    using(MarkusDb context=new MarkusDb())
                    {

                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("greska prilikom dodavanja klijenta+\n\n"+ex, "Novo mesto");
                }



            }
        }

        
    }
}
