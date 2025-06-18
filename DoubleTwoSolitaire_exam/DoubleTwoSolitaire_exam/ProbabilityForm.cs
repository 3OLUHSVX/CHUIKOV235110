using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoubleTwoSolitaire_exam
{
    public class ProbabilityForm : Form
    {
        // Явно инициализируем элементы управления
        private Button calculateButton = new Button();
        private Button exitButton = new Button();
        private Label resultLabel = new Label();
        private Label infoLabel = new Label();
        private NumericUpDown experimentCount = new NumericUpDown();
        private ProgressBar progressBar = new ProgressBar();

        public ProbabilityForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Настройка формы
            this.Text = "Расчет вероятности";
            this.ClientSize = new Size(400, 300);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Настройка элементов управления
            // infoLabel
            infoLabel.Text = "Количество экспериментов:";
            infoLabel.Location = new Point(20, 20);
            infoLabel.AutoSize = true;

            // experimentCount
            experimentCount.Minimum = 1;
            experimentCount.Maximum = 2000000;
            experimentCount.Value = 1000;
            experimentCount.Location = new Point(20, 50);
            experimentCount.Width = 200;

            // calculateButton
            calculateButton.Text = "Рассчитать";
            calculateButton.Location = new Point(20, 90);
            calculateButton.Size = new Size(100, 30);
            calculateButton.Click += CalculateButton_Click;

            // exitButton
            exitButton.Text = "Выход";
            exitButton.Location = new Point(150, 90);
            exitButton.Size = new Size(100, 30);
            exitButton.Click += (s, e) => this.Close();

            // progressBar
            progressBar.Location = new Point(20, 140);
            progressBar.Size = new Size(350, 30);

            // resultLabel
            resultLabel.Location = new Point(20, 190);
            resultLabel.AutoSize = true;
            resultLabel.Text = "Результат появится здесь";

            // Добавляем элементы на форму
            this.Controls.Add(infoLabel);
            this.Controls.Add(experimentCount);
            this.Controls.Add(calculateButton);
            this.Controls.Add(exitButton);
            this.Controls.Add(progressBar);
            this.Controls.Add(resultLabel);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int totalExperiments = (int)experimentCount.Value;
            progressBar.Maximum = totalExperiments;
            progressBar.Value = 0;
            resultLabel.Text = "Вычисление...";
            Application.DoEvents(); // Обновляем UI

            // Запускаем фоновый расчет
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            worker.DoWork += (s, args) =>
            {
                int successes = 0;
                Random rand = new Random();

                for (int i = 0; i < totalExperiments; i++)
                {
                    if (SimulateGame(rand))
                        successes++;

                    if (i % 100 == 0)
                    {
                        worker.ReportProgress(i);
                        // Для больших N замедляем обновление
                        if (totalExperiments > 10000 && i % 10000 == 0)
                        {
                            System.Threading.Thread.Sleep(1);
                        }
                    }
                }
                args.Result = successes;
            };

            worker.ProgressChanged += (s, args) =>
            {
            progressBar.Value = args.
                ProgressPercentage;
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                if (args.Error != null)
                {
                    resultLabel.Text = "Ошибка: " + args.Error.Message;
                }
                else
                {
                    int successes = (int)args.Result;
                    double probability = (double)successes / totalExperiments;
                    resultLabel.Text = $"Вероятность: {probability:P4} (Успешно: {successes}/{totalExperiments})";
                }
                progressBar.Value = totalExperiments;
            };

            worker.RunWorkerAsync();
        }

        private bool SimulateGame(Random rand)
        {
            // Создаем колоду
            List<string> deck = new List<string>();
            string[] suits = { "H", "D", "C", "S" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits)
                foreach (string rank in ranks)
                    deck.Add(suit + rank);

            // Перемешиваем колоду
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                string temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

            // Имитация игры
            string[] table = new string[4];

            // Выкладываем первые 4 карты
            for (int i = 0; i < 4; i++)
            {
                table[i] = deck[0];
                deck.RemoveAt(0);
            }

            while (deck.Count > 0)
            {
                bool foundPair = false;
                int pairIndex1 = -1;
                int pairIndex2 = -1;

                // Поиск пар по масти
                for (int i = 0; i < 4; i++)
                {
                    if (table[i] == null) continue;
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (table[j] == null) continue;
                        if (table[i][0] == table[j][0])
                        {
                            foundPair = true;
                            pairIndex1 = i;
                            pairIndex2 = j;
                            break;
                        }
                    }
                    if (foundPair) break;
                }

                if (!foundPair)
                {
                    // Если пар нет и остались карты - пасьянс не сошелся
                    return false;
                }

                // Заменяем карты
                table[pairIndex1] = deck[0];
                deck.RemoveAt(0);

                table[pairIndex2] = deck[0];
                deck.RemoveAt(0);
            }

            // Проверяем остались ли пары после исчерпания колоды
            for (int i = 0; i < 4; i++)
            {
                if (table[i] == null) continue;
                for (int j = i + 1; j < 4; j++)
                {
                    if (table[j] == null) continue;
                    if (table[i][0] == table[j][0])
                    {
                        // Нашли пару - пасьянс не сошелся
                        return false;
                    }
                }
            }

            // Если дошли сюда - пасьянс сошелся
            return true;
        }
    }
}