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
    public partial class TotalStatisticsForm : Form
    {
        public TotalStatisticsForm(DateTime dt1, DateTime dt2)
        {
            InitializeComponent();
            fillChart(dt1, dt2);
        }

        private void fillChart(DateTime dt1, DateTime dt2)
        {
            label4.Text = "Period "  + dt1.ToString("dd.MM.yyyy") + " - " + dt2.ToString("dd.MM.yyyy");
            decimal costs = 0;
            decimal prices = 0;
            using (MarkusDb context = new MarkusDb())
            {
                var purchases = (
                from p in context.purchases
                join pi in context.purchaseitems on p.Id equals pi.Purchase_Id
                where DateTime.Compare(p.PurchaseTime, dt1) >= 0 && DateTime.Compare(p.PurchaseTime, dt2) <= 0
                select new
                {
                    Quantity = pi.Quantity,
                    Price = pi.Price,
                }).ToList();

                foreach(var p in purchases)
                {
                    costs += p.Quantity * p.Price;
                }

                var naturalentityservices = (
                    from n in context.naturalentityservices
                    where DateTime.Compare(n.ServiceTime, dt1) >= 0 && DateTime.Compare(n.ServiceTime, dt2) <= 0
                    select n
                    ).ToList();
                foreach(var n in naturalentityservices)
                {
                    prices += n.Price;
                }
            }

            label2.Text = "Ukupni troškovi iznose: " + costs;
            label3.Text = "Ukupan prihod iznosi: " + prices;
        }
    }
}
