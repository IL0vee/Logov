using System;
using System.Windows.Forms;

namespace PracticumV7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Исходные данные
            double x = 0.1722;
            double y = 6.33;
            double z = 3.25e-4; // 3.25 × 10⁻⁴

            // Вычисление по формуле: 
            // γ = 5 * arctg(x) - (1/4) * arccos(x) * (x + 3|x - y| + x²) / (|x - y| * z + x²)

            // 1. Вычисляем arctg(x) и arccos(x)
            double arctgX = Math.Atan(x);
            double arccosX = Math.Acos(x);

            // 2. Вычисляем |x - y|
            double absXY = Math.Abs(x - y);

            // 3. Числитель дроби: x + 3|x - y| + x²
            double numerator = x + 3 * absXY + x * x;

            // 4. Знаменатель дроби: |x - y| * z + x²
            double denominator = absXY * z + x * x;

            // 5. Дробь
            double fraction = numerator / denominator;

            // 6. Вся формула: 5 * arctg(x) - 0.25 * arccos(x) * fraction
            double gamma = 5 * arctgX - 0.25 * arccosX * fraction;

            // Вывод результата
            MessageBox.Show($"γ = {gamma}" );
        }
    }
}
