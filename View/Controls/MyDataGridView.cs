using ApplicationSettings;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Controls
{
    public partial class MyDataGridView : DataGridView
    {
        private const int CAPTIONHEIGHT = 2;
        private const int BORDERWIDTH = 2;

        public MyDataGridView()
        {
            this.VerticalScrollBar.Visible = true;
            this.VerticalScrollBar.VisibleChanged += new EventHandler(VerticalScrollBar_VisibleChanged);
            this.VerticalScrollBar.Dock = DockStyle.Right;
            this.CellFormatting += new DataGridViewCellFormattingEventHandler(this.grdTableCellFormatting);
        }

        void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            if (!VerticalScrollBar.Visible)
            {
                int width = VerticalScrollBar.Width;

                VerticalScrollBar.Location =
                new Point(ClientRectangle.Width - width - BORDERWIDTH, CAPTIONHEIGHT);

                VerticalScrollBar.Size =
                new Size(width, ClientRectangle.Height - CAPTIONHEIGHT - BORDERWIDTH);

                VerticalScrollBar.Show();
            }
        }

        private void grdTableCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.Value == null) return;

            int channel = e.ColumnIndex - 1;
            float value = float.Parse((string)e.Value);
            
            if (GlobalSettings.SerialSettings.isInf[channel] && value < GlobalSettings.SerialSettings.Inf[channel])
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
            else if (GlobalSettings.SerialSettings.isSup[channel] && value > GlobalSettings.SerialSettings.Sup[channel])
            {
                e.CellStyle.ForeColor = Color.Red;
            }

        }
    }
}
