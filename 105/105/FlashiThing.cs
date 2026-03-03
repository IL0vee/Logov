using System;
using System.Drawing;
using System.Windows.Forms;

namespace _105
{
    public partial class FlashiThing : Form
    {
        public FlashiThing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (Visible)
            {
                for (int c = 0; c <= 255; c++)
                {
                    this.BackColor = Color.FromArgb(c, 255 - c, c);

                    Application.DoEvents();

                    System.Threading.Thread.Sleep(3);
                }
                for (int c = 254; c >= 0; c--)
                {
                    this.BackColor = Color.FromArgb(c, 255 - c, c);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }

            }
        }
    }
}
