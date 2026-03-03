using System;
using System.Windows.Forms;

namespace PracticumV7T2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Объявление компонентов
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.GroupBox grbFunction;
        private System.Windows.Forms.RadioButton rbSh;
        private System.Windows.Forms.RadioButton rbSquare;
        private System.Windows.Forms.RadioButton rbExp;
        private System.Windows.Forms.CheckBox chkMaxAbs;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label lblResultTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.grbFunction = new System.Windows.Forms.GroupBox();
            this.rbSh = new System.Windows.Forms.RadioButton();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.rbExp = new System.Windows.Forms.RadioButton();
            this.chkMaxAbs = new System.Windows.Forms.CheckBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.grbFunction.SuspendLayout();
            this.SuspendLayout();

            // lblTitle - Заголовок
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Лаб. раб. №2 ст. гр. 920201 Петрова И.И.";

            // lblX - Подпись для X
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblX.Location = new System.Drawing.Point(12, 45);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(21, 17);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X =";

            // txtX - Поле ввода X
            this.txtX.Location = new System.Drawing.Point(39, 42);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 23);
            this.txtX.TabIndex = 2;
            this.txtX.Text = "0,1";

            // lblB - Подпись для B
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblB.Location = new System.Drawing.Point(145, 45);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(22, 17);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "B =";

            // txtB - Поле ввода B
            this.txtB.Location = new System.Drawing.Point(173, 42);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 23);
            this.txtB.TabIndex = 4;
            this.txtB.Text = "0,356";

            // lblResult - Подпись для результата
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResult.Location = new System.Drawing.Point(279, 45);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(20, 17);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "S =";

            // txtResult - Поле вывода результата
            this.txtResult.Location = new System.Drawing.Point(305, 42);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 23);
            this.txtResult.TabIndex = 6;
            this.txtResult.ReadOnly = true;

            // grbFunction - Группа для выбора функции
            this.grbFunction.Controls.Add(this.rbSh);
            this.grbFunction.Controls.Add(this.rbSquare);
            this.grbFunction.Controls.Add(this.rbExp);
            this.grbFunction.Location = new System.Drawing.Point(12, 80);
            this.grbFunction.Name = "grbFunction";
            this.grbFunction.Size = new System.Drawing.Size(200, 110);
            this.grbFunction.TabIndex = 7;
            this.grbFunction.TabStop = false;
            this.grbFunction.Text = "f(x)";

            // rbSh - RadioButton для sh(x)
            this.rbSh.AutoSize = true;
            this.rbSh.Location = new System.Drawing.Point(6, 22);
            this.rbSh.Name = "rbSh";
            this.rbSh.Size = new System.Drawing.Size(56, 19);
            this.rbSh.TabIndex = 0;
            this.rbSh.Text = "sh(x)";
            this.rbSh.UseVisualStyleBackColor = true;

            // rbSquare - RadioButton для x²
            this.rbSquare.AutoSize = true;
            this.rbSquare.Location = new System.Drawing.Point(6, 47);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(48, 19);
            this.rbSquare.TabIndex = 1;
            this.rbSquare.Text = "x²";
            this.rbSquare.UseVisualStyleBackColor = true;

            // rbExp - RadioButton для e^x
            this.rbExp.AutoSize = true;
            this.rbExp.Location = new System.Drawing.Point(6, 72);
            this.rbExp.Name = "rbExp";
            this.rbExp.Size = new System.Drawing.Size(52, 19);
            this.rbExp.TabIndex = 2;
            this.rbExp.Text = "e^x";
            this.rbExp.UseVisualStyleBackColor = true;

            // chkMaxAbs - CheckBox для модуля
            this.chkMaxAbs.AutoSize = true;
            this.chkMaxAbs.Location = new System.Drawing.Point(218, 100);
            this.chkMaxAbs.Name = "chkMaxAbs";
            this.chkMaxAbs.Size = new System.Drawing.Size(67, 19);
            this.chkMaxAbs.TabIndex = 8;
            this.chkMaxAbs.Text = "maxabs";
            this.chkMaxAbs.UseVisualStyleBackColor = true;

            // btnExecute - Кнопка выполнения
            this.btnExecute.Location = new System.Drawing.Point(218, 130);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 30);
            this.btnExecute.TabIndex = 9;
            this.btnExecute.Text = "Выполнить";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);

            // btnClear - Кнопка очистки
            this.btnClear.Location = new System.Drawing.Point(324, 130);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // lblResultTitle - Заголовок для списка результатов
            this.lblResultTitle.AutoSize = true;
            this.lblResultTitle.Location = new System.Drawing.Point(12, 200);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(149, 15);
            this.lblResultTitle.TabIndex = 10;
            this.lblResultTitle.Text = "Результат выполнения программы:";

            // lstResult - Список для вывода результатов
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 15;
            this.lstResult.Location = new System.Drawing.Point(12, 220);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(420, 150);
            this.lstResult.TabIndex = 11;

            // Form1 - Главная форма
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 400);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.lblResultTitle);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.chkMaxAbs);
            this.Controls.Add(this.grbFunction);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №2 (Вариант 7)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbFunction.ResumeLayout(false);
            this.grbFunction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

