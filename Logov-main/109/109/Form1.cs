using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _109
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Первый способ - измененный порядок операций
        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            String Poem = "";

            while (x < 4)
            {
                Poem = Poem + "a";

                if (x == 1)
                {
                    Poem = Poem + "noys ";
                }

                if (x < 1)
                {
                    Poem = Poem + " ";
                    Poem = Poem + "oise ";
                }

                Poem = Poem + "n";

                if (x > 1)
                {
                    Poem = Poem + " oyster";
                    x = x + 2;
                }

                x = x + 1;
            }

            MessageBox.Show(Poem);
        }

        // Второй способ - исходный порядок
        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            String Poem = "";

            while (x < 4)
            {
                Poem = Poem + "a";

                if (x > 1)
                {
                    Poem = Poem + " oyster";
                    x = x + 2;
                }
                else
                {
                    if (x == 1)
                    {
                        Poem = Poem + "noys ";
                    }
                    else
                    {
                        Poem = Poem + " ";
                        Poem = Poem + "oise ";
                    }
                }

                Poem = Poem + "n";
                x = x + 1;
            }

            MessageBox.Show(Poem);
        }
    }
}