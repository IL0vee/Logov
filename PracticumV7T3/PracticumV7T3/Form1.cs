using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticumV7T3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Установка начальных значений
            txtA.Text = "0,1";
            txtB.Text = "1";
            txtN.Text = "120";
            txtSteps.Text = "10";

            // Очистка Memo
            memoResult.Clear();

            // Добавление заголовка
            memoResult.AppendText("Задание: S(x) = x^3/3 - x^5/15 + ... + (-1)^(n+1) * x^(2n+1)/(4n^2 - 1)\r\n");
            memoResult.AppendText("Y(x) = (1 + x^2)/2 * arctg(x) - x/2\r\n\r\n");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Чтение входных данных
                double a = ConvertToDouble(txtA.Text);
                double b = ConvertToDouble(txtB.Text);
                int n = ConvertToInt(txtN.Text);
                int steps = ConvertToInt(txtSteps.Text);

                // Проверка корректности данных
                if (a >= b)
                {
                    MessageBox.Show("Ошибка: a должно быть меньше b", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (n <= 0 || steps <= 0)
                {
                    MessageBox.Show("Ошибка: N и Steps должны быть положительными числами", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Вычисление шага
                double h = (b - a) / steps;

                // Вывод параметров
                memoResult.AppendText($"Параметры:\r\n");
                memoResult.AppendText($"a (X1) = {a:F2}\r\n");
                memoResult.AppendText($"b (X2) = {b:F2}\r\n");
                memoResult.AppendText($"N = {n}\r\n");
                memoResult.AppendText($"Steps = {steps}\r\n");
                memoResult.AppendText($"h = {h:F4}\r\n\r\n");

                // Заголовок таблицы
                memoResult.AppendText("=================================================================================\r\n");
                memoResult.AppendText("|     x     |        S(x)        |        Y(x)        |      |S(x) - Y(x)|     |\r\n");
                memoResult.AppendText("=================================================================================\r\n");

                // Вычисление и вывод результатов
                for (int i = 0; i <= steps; i++)
                {
                    double x = a + i * h;
                    double s = CalculateS(x, n);
                    double y = CalculateY(x);
                    double difference = Math.Abs(s - y);

                    string line = String.Format("| {0,8:F3}  | {1,18:F10} | {2,18:F10} | {3,20:F10} |\r\n",
                        x, s, y, difference);

                    memoResult.AppendText(line);
                }

                memoResult.AppendText("=================================================================================\r\n\r\n");

                // Автопрокрутка в конец
                memoResult.SelectionStart = memoResult.Text.Length;
                memoResult.ScrollToCaret();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: Неверный формат числа. Используйте запятую как разделитель.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            memoResult.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Преобразование строки в double с учетом культуры
        /// </summary>
        private double ConvertToDouble(string text)
        {
            // Замена точки на запятую если необходимо
            text = text.Replace('.', ',');
            return Convert.ToDouble(text);
        }

        /// <summary>
        /// Преобразование строки в int
        /// </summary>
        private int ConvertToInt(string text)
        {
            return Convert.ToInt32(text);
        }

        /// <summary>
        /// Вычисление S(x) - разложение в ряд
        /// S(x) = x^3/3 - x^5/15 + ... + (-1)^(n+1) * x^(2n+1)/(4n^2 - 1)
        /// </summary>
        private double CalculateS(double x, int n)
        {
            double sum = 0;

            for (int k = 1; k <= n; k++)
            {
                // Вычисляем знак: (-1)^(k+1)
                double sign = (k % 2 == 0) ? -1.0 : 1.0;

                // Вычисляем степень x^(2k+1)
                double power = Math.Pow(x, 2 * k + 1);

                // Вычисляем знаменатель: 4k^2 - 1
                double denominator = 4 * k * k - 1;

                // Текущий член ряда
                double term = sign * power / denominator;

                sum += term;
            }

            return sum;
        }

        /// <summary>
        /// Вычисление Y(x) - точное значение функции
        /// Y(x) = (1 + x^2)/2 * arctg(x) - x/2
        /// </summary>
        private double CalculateY(double x)
        {
            return (1 + x * x) / 2 * Math.Atan(x) - x / 2;
        }
    }
}
