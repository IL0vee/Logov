using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace _105
{
    public partial class FlashiThing : Form
    {
        private CheckBox chkStop;
        private CheckBox chkSlow;
        private CheckBox chkFast;
        private Button btnStart;
        private bool isFlashing;
        private int currentDelay;
        private bool isUpdating;
        private System.Threading.CancellationTokenSource cts;
        private int currentColorValue; // Текущее значение цвета
        private bool currentIncreasing; // Текущее направление изменения цвета

        public FlashiThing()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void InitializeCustomControls()
        {
            // Настройка формы
            this.Size = new Size(400, 300);
            this.Text = "Flash Thing";

            // Создание кнопки
            btnStart = new Button();
            btnStart.Text = "Старт";
            btnStart.Size = new Size(100, 40);
            btnStart.Location = new Point(150, 20);
            btnStart.Click += BtnStart_Click;

            // Создание чекбоксов
            chkStop = new CheckBox();
            chkStop.Text = "Стоп";
            chkStop.Size = new Size(100, 30);
            chkStop.Location = new Point(50, 80);
            chkStop.CheckedChanged += ChkSpeed_CheckedChanged;

            chkSlow = new CheckBox();
            chkSlow.Text = "Медленная скорость (10 мс)";
            chkSlow.Size = new Size(180, 30);
            chkSlow.Location = new Point(50, 120);
            chkSlow.CheckedChanged += ChkSpeed_CheckedChanged;

            chkFast = new CheckBox();
            chkFast.Text = "Быстрая скорость (без задержки)";
            chkFast.Size = new Size(200, 30);
            chkFast.Location = new Point(50, 160);
            chkFast.CheckedChanged += ChkSpeed_CheckedChanged;

            // Добавление элементов на форму
            this.Controls.Add(btnStart);
            this.Controls.Add(chkStop);
            this.Controls.Add(chkSlow);
            this.Controls.Add(chkFast);

            // Изначально чекбоксы скрыты
            chkStop.Visible = false;
            chkSlow.Visible = false;
            chkFast.Visible = false;

            isFlashing = false;
            isUpdating = false;
            currentDelay = 10;
            currentColorValue = 0; // Начальное значение цвета
            currentIncreasing = true; // Начинаем увеличивать цвет
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Показываем чекбоксы при нажатии на кнопку
            chkStop.Visible = true;
            chkSlow.Visible = true;
            chkFast.Visible = true;

            // Сбрасываем цвет
            currentColorValue = 0;
            currentIncreasing = true;
            this.BackColor = Color.FromArgb(0, 255, 0);

            // Запускаем мигание с медленной скоростью по умолчанию
            isFlashing = true;
            currentDelay = 10;
            StartFlashing();
        }

        private void ChkSpeed_CheckedChanged(object sender, EventArgs e)
        {
            // Предотвращаем рекурсивные вызовы
            if (isUpdating) return;

            CheckBox clickedCheckBox = sender as CheckBox;

            // Если чекбокс был установлен в true
            if (clickedCheckBox.Checked)
            {
                isUpdating = true;

                // Отжимаем все остальные чекбоксы
                if (clickedCheckBox != chkStop) chkStop.Checked = false;
                if (clickedCheckBox != chkSlow) chkSlow.Checked = false;
                if (clickedCheckBox != chkFast) chkFast.Checked = false;

                // Останавливаем текущее мигание, но сохраняем текущий цвет и направление
                if (cts != null)
                {
                    cts.Cancel();
                    cts.Dispose();
                    cts = null;
                }

                // Устанавливаем соответствующую скорость
                if (clickedCheckBox == chkStop)
                {
                    isFlashing = false;
                }
                else if (clickedCheckBox == chkSlow)
                {
                    isFlashing = true;
                    currentDelay = 10; // медленная скорость - 10 мс
                    StartFlashing(); // Продолжаем с текущего цвета
                }
                else if (clickedCheckBox == chkFast)
                {
                    isFlashing = true;
                    currentDelay = 0; // быстрая скорость - без задержки
                    StartFlashing(); // Продолжаем с текущего цвета
                }

                isUpdating = false;
            }
            else
            {
                // Если чекбокс был снят, но при этом нет других выбранных,
                // то автоматически выбираем "Стоп"
                if (!chkStop.Checked && !chkSlow.Checked && !chkFast.Checked)
                {
                    isUpdating = true;
                    chkStop.Checked = true;
                    isUpdating = false;
                }
            }
        }

        private async void StartFlashing()
        {
            if (!isFlashing) return;

            // Создаем новый токен отмены
            cts = new System.Threading.CancellationTokenSource();
            var token = cts.Token;

            try
            {
                while (isFlashing && this.Visible && !token.IsCancellationRequested)
                {
                    // Продолжаем с текущего цвета и направления
                    if (currentIncreasing)
                    {
                        // Увеличиваем цвет от текущего значения до 255
                        for (int c = currentColorValue; c <= 255; c++)
                        {
                            if (!isFlashing || !this.Visible || token.IsCancellationRequested) break;

                            this.BackColor = Color.FromArgb(c, 255 - c, c);
                            currentColorValue = c;

                            if (currentDelay > 0)
                            {
                                await Task.Delay(currentDelay, token);
                            }
                            else
                            {
                                Application.DoEvents();
                                await Task.Yield();
                            }
                        }

                        if (!token.IsCancellationRequested)
                        {
                            currentIncreasing = false;
                            currentColorValue = 255;
                        }
                    }

                    if (!currentIncreasing && !token.IsCancellationRequested)
                    {
                        // Уменьшаем цвет от текущего значения до 0
                        for (int c = currentColorValue; c >= 0; c--)
                        {
                            if (!isFlashing || !this.Visible || token.IsCancellationRequested) break;

                            this.BackColor = Color.FromArgb(c, 255 - c, c);
                            currentColorValue = c;

                            if (currentDelay > 0)
                            {
                                await Task.Delay(currentDelay, token);
                            }
                            else
                            {
                                Application.DoEvents();
                                await Task.Yield();
                            }
                        }

                        if (!token.IsCancellationRequested)
                        {
                            currentIncreasing = true;
                            currentColorValue = 0;
                        }
                    }
                }
            }
            catch (TaskCanceledException)
            {
                // Ожидаемая отмена задачи - сохраняем текущий цвет и направление
            }
        }

        private void FlashiThing_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isFlashing = false;
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}