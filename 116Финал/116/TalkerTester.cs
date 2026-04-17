using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _116
{
    public partial class TalkerTester : Form
    {
        public TalkerTester()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 20;
        }

        class Talker
        {
            public static int BlahBlahBlah(string thingToSay, int numberOfTimes)
            {
                numberOfTimes = Math.Max(1, Math.Min(20, numberOfTimes));

                string finalString = "";
                for (int count = 1; count <= numberOfTimes; count++)
                {
                    finalString = finalString + thingToSay + "\n";
                }
                MessageBox.Show(finalString, "Результат");
                return finalString.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int len = Talker.BlahBlahBlah(textBox1.Text, (int)numericUpDown1.Value);
            MessageBox.Show("Длина сообщения: " + len, "Информация");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            // Если текст не введён, используем строку из звёздочек
            if (string.IsNullOrEmpty(input))
            {
                input = new string('*', 20);
            }

            StringBuilder pyramid = new StringBuilder();
            pyramid.AppendLine("");
            pyramid.AppendLine();

            char[] currentChars = input.ToCharArray();
            int step = 0;
            int leftIndex = 0;
            int rightIndex = currentChars.Length - 1;
            int originalLength = currentChars.Length;

            while (leftIndex <= rightIndex)
            {
                // Создаём строку с пробелами на месте удалённых символов
                string currentLine = new string(currentChars);

                // Центрируем строку: добавляем пробелы слева для визуальной пирамиды
                int padding = (originalLength - currentLine.TrimEnd().Length) / 2;
                string centeredLine = new string(' ', padding) + currentLine.TrimEnd();

                pyramid.AppendLine(centeredLine);

                // Чередуем: сначала 2 справа, потом 1 слева
                if (step % 2 == 0)
                {
                    // Чётный шаг - удаляем 2 символа СПРАВА
                    for (int i = 0; i < 2 && rightIndex >= leftIndex; i++)
                    {
                        currentChars[rightIndex] = ' ';
                        rightIndex--;
                    }
                }
                else
                {
                    // Нечётный шаг - удаляем 1 символ СЛЕВА
                    if (leftIndex <= rightIndex)
                    {
                        currentChars[leftIndex] = ' ';
                        leftIndex++;
                    }
                }

                step++;
            }

            // Создаём окно для вывода пирамиды
            Form pyramidForm = new Form();
            pyramidForm.Text = "Пирамида (2 справа, 1 слева)";
            pyramidForm.Size = new Size(600, 500);
            pyramidForm.StartPosition = FormStartPosition.CenterScreen;
            pyramidForm.FormBorderStyle = FormBorderStyle.Sizable;

            TextBox displayBox = new TextBox();
            displayBox.Multiline = true;
            displayBox.ReadOnly = true;
            displayBox.ScrollBars = ScrollBars.Vertical;
            displayBox.WordWrap = false;
            displayBox.Font = new Font("Consolas", 10, FontStyle.Regular);
            displayBox.Text = pyramid.ToString();
            displayBox.Dock = DockStyle.Fill;
            displayBox.BackColor = Color.White;
            displayBox.ForeColor = Color.Black;

            Button closeButton = new Button();
            closeButton.Text = "Закрыть окно";
            closeButton.Dock = DockStyle.Bottom;
            closeButton.Height = 40;
            closeButton.Click += (s, args) => pyramidForm.Close();

            pyramidForm.Controls.Add(displayBox);
            pyramidForm.Controls.Add(closeButton);
            pyramidForm.ShowDialog();
        }
    }
}