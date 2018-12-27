using Autopraonica_Markus.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopraonica_Markus.forms.statisticsForms
{
    public partial class ClientChartForm : Form
    {
        public ClientChartForm(int id, string name, DateTime dt1, DateTime dt2)
        {
            InitializeComponent();
            fillChart(id, name, dt1, dt2);
        }

        private void fillChart(int id, string name, DateTime dt1, DateTime dt2)
        {
            decimal incomesFromClient = 0;
            int numberOfServices = 0;
            using (MarkusDb context = new MarkusDb())
            {
                var entityservices = (
                    from les in context.legalentityservices
                    join c in context.clients on les.Client_Id equals c.Id
                    join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                    where c.Id == id && DateTime.Compare(nes.ServiceTime, dt1) >= 0 && DateTime.Compare(nes.ServiceTime, dt2) <= 0
                    select nes
                    ).ToList();
                foreach(var e in entityservices)
                {
                    incomesFromClient += e.Price;
                    numberOfServices++;
                }

                var serviceswithservicetype = (
                    from les in context.legalentityservices
                    join c in context.clients on les.Client_Id equals c.Id
                    join nes in context.naturalentityservices on les.NaturalEntityService_Id equals nes.Id
                    join pli in context.pricelistitems on nes.PricelistItem_Id equals pli.Id
                    join st in context.servicetypes on pli.ServiceType_Id equals st.Id
                    where c.Id == id && DateTime.Compare(nes.ServiceTime, dt1) >= 0 && DateTime.Compare(nes.ServiceTime, dt2) <= 0
                    select new { pli.ServiceType_Id, nes.Price, st.Name } into x
                    group x by new { x.ServiceType_Id } into g
                    select new
                    {
                        Id = g.Key,
                        Price = g.Sum(m => m.Price),
                        Name = g.FirstOrDefault().Name
                    }).ToList();

                lblName.Text = "Statistika za klijenta " + name;

            
                foreach(var s in serviceswithservicetype)
                {
                    listView1.Items.Add(s.Name + ": " + s.Price);
                }
                foreach(ListViewItem lvi in listView1.Items)
                {
                    lvi.Font = new Font("Consolas", 12f);
                }
                
                Label lbl2 = new Label();
                lbl2.Text = "Ukupan prihod: " + incomesFromClient;
                lbl2.Location = new Point(0, 290);
                lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    ));
                lbl2.Size = new Size(200, 20);
                lbl2.TextAlign = ContentAlignment.MiddleLeft;
                lbl2.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                this.Controls.Add(lbl2);

                Label lbl3 = new Label();
                lbl3.Text = "Ukupan broj usluga: " + numberOfServices;
                lbl3.Location = new Point(0, 320);
                lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)));
                lbl3.Size = new Size(200, 20);
                lbl3.TextAlign = ContentAlignment.MiddleLeft;
                lbl3.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
                this.Controls.Add(lbl3);
            }
        }
    }
}
