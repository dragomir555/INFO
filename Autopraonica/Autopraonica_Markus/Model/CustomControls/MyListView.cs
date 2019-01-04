using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

public class MyListView : ListView
{
    public MyListView()
    {
        EmptyText = "Nemate prihoda za ovaj period.";
    }
    [DefaultValue("Nemate prihoda za ovaj period.")]
    public string EmptyText { get; set; }
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 0xF)
        {
            if (this.Items.Count == 0)
                using (var g = Graphics.FromHwnd(this.Handle))
                    TextRenderer.DrawText(g, EmptyText, new Font("Microsoft Sans Serif", 11, FontStyle.Regular), ClientRectangle, ForeColor);
        }
    }
}