using System;
using System.Windows.Forms;

namespace _116
{
    public partial class TalkerTester : Form
    {
        public TalkerTester()
        {
            InitializeComponent();
        }

        class Talker
        {
            public static int BlahBlahBlah(string thingToSay, int numberOfTimes)
            {
                string finalString = "";
                for (int count = 1; count <= numberOfTimes; count++)
                {
                    finalString = finalString + thingToSay + "\n";
                }
                MessageBox.Show(finalString);
                return finalString.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int len = Talker.BlahBlahBlah(textBox1.Text, (int)numericUpDown1.Value);
            MessageBox.Show("Длина сообщения: " + len);
        }
    }
}
