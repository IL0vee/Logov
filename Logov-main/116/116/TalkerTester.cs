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

            // Если текст не введён, используем строку из звёздочек для наглядной пирамиды
            if (string.IsNullOrEmpty(input))
            {
                input = new string('*', 19); // нечётная длина для симметрии
            }

            // Убедимся, что длина строки нечётная — так пирамида будет симметричной
            if (input.Length % 2 == 0)
            {
                input = input.Substring(0, input.Length - 1);
            }

            StringBuilder pyramid = new StringBuilder();
            pyramid.AppendLine("");
            pyramid.AppendLine();

            int maxWidth = input.Length;

            // Строим пирамиду сверху вниз: начинаем с полной строки, уменьшаем по 1 символу с каждого края на каждом шаге
            for (int level = 0; level < (maxWidth + 1) / 2; level++)
            {
                int numChars = maxWidth - 2 * level; // количество символов на текущем уровне
                int startIndex = level; // начальный индекс в исходной строке (сдвигаем влево на каждом уровне)

                // Извлекаем нужные символы из исходной строки — без пробелов между ними
                string currentLevel = input.Substring(startIndex, numChars);


                // Вычисляем отступы для центрирования: каждый уровень сдвигается на 1 пробел вправо
                int padding = level;
                string spaces = new string(' ', padding);

                pyramid.Append(spaces);
                pyramid.Append(currentLevel);
                pyramid.AppendLine(); // Гарантированный перенос строки
            }

            // Создаём окно для вывода пирамиды с моноширинным шрифтом
            Form pyramidForm = new Form();
            pyramidForm.Text = "Пирамида (смотрит вверх)";
            pyramidForm.Size = new Size(600, 500);
            pyramidForm.StartPosition = FormStartPosition.CenterScreen;
            pyramidForm.FormBorderStyle = FormBorderStyle.Sizable;

            TextBox displayBox = new TextBox();
            displayBox.Multiline = true;
            displayBox.ReadOnly = true;
            displayBox.ScrollBars = ScrollBars.Vertical;
            displayBox.WordWrap = false;
            // Моноширинный шрифт — гарантирует одинаковую ширину всех символов
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