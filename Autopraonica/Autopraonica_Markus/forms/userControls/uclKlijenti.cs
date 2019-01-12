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
            cmbSearchType.SelectedIndex=0;
        }


        private void uclKlijenti_Load(object sender, EventArgs e)
        {
        }

        private void FillTable()
        {
            dgvKlijenti.Rows.Clear();
            using (MarkusDb context = new MarkusDb())
            {
                var klijenti = (from cl in context.clients
                                join cop in context.contracts on cl.Id equals cop.Client_Id
                                select
new { Client = cl, Contract = cop }).ToList();

                int conOver = 1;
                if (cbContractOver.Checked == true)
                {
                    conOver = 0;
                }
                foreach (var c in klijenti)
                {
                    if (c.Contract.Current == conOver)
                    {

                        DataGridViewRow r = new DataGridViewRow() { Tag = c.Contract };
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
            newClientForm.Tag = 0;
            if (DialogResult.OK == newClientForm.ShowDialog())
            {
                try
                {
                    using (MarkusDb context = new MarkusDb())
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
                            co.DateTo = newClientForm.ContractTo;
                        }
                        context.clients.Add(cl);
                        context.SaveChanges();
                        co.Client_Id = cl.Id;
                        context.contracts.Add(co);
                        context.SaveChanges();
                        FillTable();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("greska prilikom dodavanja klijenta+\n\n" + ex, "Novo mesto");
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
            tbSearchText.Text = "";
            FillTable();
            tbSearchText.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FillTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbContractOver.Checked==false)
            {
                if (dgvKlijenti.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvKlijenti.SelectedRows[0];
                    contract con = (contract)row.Tag;
                    using (MarkusDb context = new MarkusDb())
                    {
                        try
                        {
                            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite poništiti ugovor?",
                             "Markus", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                context.contracts.Attach(con);
                                con.Current = 0;
                                con.DateTo = DateTime.Now;
                                context.SaveChanges();
                                FillTable();
                                MessageBox.Show("Ponisten ugovor klijenta " + con.client.Name + ".", "Markus");
                            }
                        }
                        catch (Exception ex) { Debug.WriteLine(ex); }
                    }
                }
                else
                {
                    MessageBox.Show("Izaberite klijenta iz tabele","Markus");
                }
            }
            else
            {
                MessageBox.Show("Izabrani ugovor je neaktivan","Markus");
            }
        }

        private void btnIzmjeniKlijenta_Click(object sender, EventArgs e)
        {
            NewClientForm clientForm = new NewClientForm();
            if (dgvKlijenti.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKlijenti.SelectedRows[0];
                contract con = (contract)row.Tag;
                client cl = null;
                int idClient = con.Client_Id;
                using (MarkusDb context = new MarkusDb()) {
                    cl = (from c in context.clients where c.Id == idClient select c).ToList().First();
                    }
                clientForm.IdCity = cl.City_Id;
                clientForm.NameClient = cl.Name;
                clientForm.UID = cl.UID;
                clientForm.Address = cl.Address;
                clientForm.Tag = 1;

                if (DialogResult.OK == clientForm.ShowDialog())
                {
                    try
                    {
                        using (MarkusDb context = new MarkusDb())
                        {
                            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite sačuvati izmjene?",
                             "Markus", MessageBoxButtons.YesNo);
                            if (dialogResult==DialogResult.Yes) {
                                context.clients.Attach(cl);
                                cl.Name = clientForm.NameClient;
                                cl.Address = clientForm.Address;
                                cl.City_Id = clientForm.IdCity;
                                cl.UID = clientForm.UID;
                                context.SaveChanges();
                                FillTable();
                            }
                        }
                    }
                    catch (Exception ex) { Debug.WriteLine(ex); }
                }
                else { Debug.WriteLine("Dragoljub ne otvori Dialog"); }

            }
            else
            {
                MessageBox.Show("Izaberite klijenta iz tabele");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewClientForm clientForm = new NewClientForm();
            if (dgvKlijenti.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKlijenti.SelectedRows[0];
                contract con = (contract)row.Tag;
                if (con.DateTo < DateTime.Now)
                {
                    client cl = null;
                    int idClient = con.Client_Id;
                    using (MarkusDb context = new MarkusDb())
                    {
                        cl = (from c in context.clients where c.Id == idClient select c).ToList().First();
                    }
                    clientForm.IdCity = cl.City_Id;
                    clientForm.NameClient = cl.Name;
                    clientForm.UID = cl.UID;
                    clientForm.Address = cl.Address;
                    clientForm.Tag = 2;

                    if (DialogResult.OK == clientForm.ShowDialog())
                    {
                        try
                        {
                            using (MarkusDb context = new MarkusDb())
                            {
                                var co = new contract()
                                {
                                    Current = 1,
                                    DateFrom = DateTime.Now
                                };
                                if (clientForm.ContractTo != null)
                                {
                                    co.DateTo = clientForm.ContractTo;
                                }
                                co.Client_Id = cl.Id;
                                context.contracts.Add(co);
                                context.SaveChanges();
                                FillTable();
                            }
                        }
                        catch (Exception ex) { Debug.WriteLine(ex); }
                    }
                    else { Debug.WriteLine("Dragoljub ne otvori Dialog"); }

                }
                else
                {
                    MessageBox.Show("Кlijent ima aktivan ugovor za novi ugovor poništiti prethodni", "Markus");
                }
            }
            else
            {
                MessageBox.Show("Izaberite klijenta iz tabele");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = (string)cmbSearchType.SelectedItem;
            string searchText = tbSearchText.Text;
            dgvKlijenti.Rows.Clear();
            using (MarkusDb context=new MarkusDb())
                {
                if ("Naziv".Equals(text))
                {
                    var klijenti = (from cl in context.clients
                                    join cop in context.contracts on cl.Id equals cop.Client_Id
                                    where cl.Name.StartsWith(searchText)
                                    select
                     new { Client = cl, Contract = cop }).ToList();
                    Debug.WriteLine(klijenti.Count());
                    int conOver = 1;
                    if (cbContractOver.Checked == true)
                    {
                        conOver = 0;
                    }
                    foreach (var c in klijenti)
                    {
                        if (c.Contract.Current == conOver)
                        {

                            DataGridViewRow r = new DataGridViewRow() { Tag = c.Contract };
                            r.CreateCells(dgvKlijenti);
                            r.SetValues(c.Client.Name, c.Client.UID, c.Client.city.Name, c.Client.Address, c.Contract.DateFrom.ToString("dd.MM.yyyy"),
                            c.Contract.DateTo.HasValue ? c.Contract.DateTo.Value.ToString("dd.MM.yyyy") : "-");
                            dgvKlijenti.Rows.Add(r);
                        }
                    }

                }
                else
                {
                    var klijenti = (from cl in context.clients
                                    join cop in context.contracts on cl.Id equals cop.Client_Id
                                    where cl.UID.StartsWith(searchText)
                                    select
                     new { Client = cl, Contract = cop }).ToList();
                    int conOver = 1;
                    if (cbContractOver.Checked == true)
                    {
                        conOver = 0;
                    }
                    foreach (var c in klijenti)
                    {
                        if (c.Contract.Current == conOver)
                        {

                            DataGridViewRow r = new DataGridViewRow() { Tag = c.Contract };
                            r.CreateCells(dgvKlijenti);
                            r.SetValues(c.Client.Name, c.Client.UID, c.Client.city.Name, c.Client.Address, c.Contract.DateFrom.ToString("dd.MM.yyyy"),
                            c.Contract.DateTo.HasValue ? c.Contract.DateTo.Value.ToString("dd.MM.yyyy") : "-");
                            dgvKlijenti.Rows.Add(r);
                        }
                    }
                }


                }
        
        }
    }
}
