using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

public class MyDataGridView : DataGridView
{
    public MyDataGridView()
    {
        EmptyText = "Ne postoje stavke cjenovnika.";
    }
    [DefaultValue("Ne postoje stavke cjenovnika.")]
    public string EmptyText { get; set; }
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 0xF)
        {
            if (this.RowCount == 0)
                using (var g = Graphics.FromHwnd(this.Handle))
                    TextRenderer.DrawText(g, EmptyText, new Font("Microsoft Sans Serif", 13, FontStyle.Regular), ClientRectangle, ForeColor);
        }
    }
}