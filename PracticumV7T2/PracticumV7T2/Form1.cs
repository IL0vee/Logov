using System;
using System.Windows.Forms;

namespace PracticumV7T2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Установка начальных значений как в образце
            txtX.Text = "0,1";
            txtB.Text = "0,356";
            rbExp.Checked = true; // По умолчанию выбрана функция e^x

            // Очистка и добавление заголовка в результат
            lstResult.Items.Clear();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение значений из полей ввода
                double x = ConvertToDouble(txtX.Text);
                double b = ConvertToDouble(txtB.Text);

                // Очистка результата и добавление заголовка
                lstResult.Items.Clear();
                lstResult.Items.Add($"X = {txtX.Text}");
                lstResult.Items.Add($"B = {txtB.Text}");

                // Вычисление f(x) в зависимости от выбранной функции
                double fx = 0;
                string functionName = "";

                if (rbSh.Checked)
                {
                    fx = Math.Sinh(x);
                    functionName = "sh(x)";
                }
                else if (rbSquare.Checked)
                {
                    fx = x * x;
                    functionName = "x²";
                }
                else if (rbExp.Checked)
                {
                    fx = Math.Exp(x);
                    functionName = "e^x";
                }

                lstResult.Items.Add($"f(x) = {functionName} = {fx:F8}");

                // Применение модуля если отмечен CheckBox maxabs
                if (chkMaxAbs.Checked)
                {
                    fx = Math.Abs(fx);
                    b = Math.Abs(b);
                    lstResult.Items.Add("Применен модуль (maxabs)");
                }

                // Вычисление xb = x * b
                double xb = x * b;
                lstResult.Items.Add($"xb = {xb:F8}");

                // Вычисление s по условиям варианта 7
                double s = 0;
                string condition = "";

                // Проверка условий
                if (xb > 1 && xb < 10)
                {
                    // s = e^(f(x))
                    s = Math.Exp(fx);
                    condition = "1 < xb < 10: e^(f(x))";
                }
                else if (xb > 12 && xb < 40)
                {
                    // s = sqrt(f(x) + 4*b)
                    double underSqrt = fx + 4 * b;

                    // Проверка на отрицательное подкоренное выражение
                    if (underSqrt < 0)
                    {
                        MessageBox.Show("Ошибка: подкоренное выражение отрицательное!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstResult.Items.Add("ОШИБКА: подкоренное выражение отрицательное!");
                        return;
                    }

                    s = Math.Sqrt(underSqrt);
                    condition = "12 < xb < 40: sqrt(f(x) + 4*b)";
                }
                else
                {
                    // s = b * f(x)^2
                    s = b * fx * fx;
                    condition = "иначе: b * f(x)²";
                }

                // Вывод результатов
                lstResult.Items.Add($"Условие: {condition}");
                lstResult.Items.Add($"Результат s = {s:F8}");

                // Вывод в поле результата
                txtResult.Text = s.ToString("F8");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Очистка результата и добавление заголовка
            lstResult.Items.Clear();
            txtResult.Clear();
        }

        private double ConvertToDouble(string value)
        {
            // Замена запятой на точку для корректного парсинга
            value = value.Replace(",", ".");

            if (double.TryParse(value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out double result))
            {
                return result;
            }

            throw new Exception($"Некорректное значение: {value}");
        }
    }
}
