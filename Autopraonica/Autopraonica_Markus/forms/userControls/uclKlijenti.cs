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
using System.Diagnostics;

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
            FillTable();
        }


        private void uclKlijenti_Load(object sender, EventArgs e)
        {
        }

        private void FillTable()
        {
            dgvKlijenti.Rows.Clear();
            using(MarkusDb context=new MarkusDb())
            {
                var klijenti = (from cl in context.clients join cop in context.contracts on cl.Id equals cop.Client_Id select
                           new {Client=cl,Contract=cop}).ToList();

                int conOver = 1;
                if (cbContractOver.Checked == true)
                {
                    conOver = 0;
                }
                foreach(var c in klijenti)
                {
                    if (c.Contract.Current==conOver) {
                        DataGridViewRow r = new DataGridViewRow() { Tag = c };
                        r.CreateCells(dgvKlijenti);
                        r.SetValues(c.Client.Name, c.Client.UID, c.Client.city.Name, c.Client.Address, c.Contract.DateFrom.ToString("dd.MM.yyyy"),
                            c.Contract.DateTo.HasValue ? c.Contract.DateTo.Value.ToString("dd.MM.yyyy") : "-");
                        dgvKlijenti.Rows.Add(r);
                    }
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
                        var cl = new client()
                        {
                            Name = newClientForm.NameClient,
                            Address = newClientForm.Address,
                            City_Id = newClientForm.IdCity,
                            UID = newClientForm.UID
                        };
                        var co = new contract()
                        {
                            Current = 1,
                            DateFrom = DateTime.Now                                                      
                        };
                        if (newClientForm.ContractTo != null)
                        {                          
                            co.DateTo=newClientForm.ContractTo;
                        }
                        context.clients.Add(cl);
                        context.SaveChanges();
                        co.Client_Id = cl.Id;
                        context.contracts.Add(co);
                        context.SaveChanges();
                        FillTable();
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("greska prilikom dodavanja klijenta+\n\n"+ex, "Novo mesto");
                }



            }
            else
            {
             //   Debug.WriteLine("Negativan Dialog");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FillTable();
        }
    }
}
