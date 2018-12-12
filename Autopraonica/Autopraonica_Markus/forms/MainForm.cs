using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autopraonica_Markus.forms.userControls;

namespace Autopraonica_Markus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTroskovnik_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclTroskovnik.Instance))
            {
                pnlContent.Controls.Add(uclTroskovnik.Instance);
                uclTroskovnik.Instance.Dock = DockStyle.Fill;
                uclTroskovnik.Instance.BringToFront();
            }
            else
            {
                uclTroskovnik.Instance.BringToFront();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUsluge_Click(object sender, EventArgs e)
        {
            if (!pnlContent.Controls.Contains(uclUsluge.Instance))
            {
                pnlContent.Controls.Add(uclUsluge.Instance);
                uclUsluge.Instance.Dock = DockStyle.Fill;
                uclUsluge.Instance.BringToFront();
            }
            else
            {
                uclUsluge.Instance.BringToFront();
            }
        }
    }
}
