using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTwoSolitaire_exam
{
    public partial class MainForm : Form
    {
        private List<string> deck;
        private string[] tableCards = new string[4];
        private PictureBox[] cardBoxes;
        private PictureBox deckBox;
        private Random random = new Random();
        private int deckCount = 52;
        private Timer gameTimer;
        private StatusStrip statusBar;
        private ToolStripStatusLabel statusLabel;

        public MainForm()
        {
            InitializeComponents();
            SetupGame();
        }

        private void InitializeComponents()
        {
            // Настройка главной формы
            this.Text = "Пасьянс 'Дважды два'";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Создание главного меню
            MenuStrip mainMenu = new MenuStrip();
            mainMenu.Dock = DockStyle.Top;

            ToolStripMenuItem newGameItem = new ToolStripMenuItem("Новая игра");
            ToolStripMenuItem probabilityItem = new ToolStripMenuItem("Вероятность");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход");

            newGameItem.Click += (s, e) => StartNewGame();
            probabilityItem.Click += (s, e) => ShowProbabilityForm();
            exitItem.Click += (s, e) => Application.Exit();

            mainMenu.Items.AddRange(new ToolStripItem[] { newGameItem, probabilityItem, exitItem });
            this.Controls.Add(mainMenu);

            // Создание PictureBox для колоды
            deckBox = new PictureBox();
            deckBox.Size = new Size(100, 150);
            deckBox.Location = new Point(50, 150);
            deckBox.BackColor = Color.DarkGreen;
            deckBox.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(deckBox);

            // Создание PictureBox для карт на столе
            cardBoxes = new PictureBox[4];
            for (int i = 0; i < 4; i++)
            {
                cardBoxes[i] = new PictureBox();
                cardBoxes[i].Size = new Size(100, 150);
                cardBoxes[i].Location = new Point(200 + i * 120, 150);
                cardBoxes[i].BackColor = Color.DarkGreen;
                cardBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(cardBoxes[i]);
            }

            // Создание строки состояния
            statusBar = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            statusBar.Items.Add(statusLabel);
            statusBar.Dock = DockStyle.Bottom;
            this.Controls.Add(statusBar);

            // Инициализация таймера
            gameTimer = new Timer();
        }

        private void SetupGame()
        {
            gameTimer.Interval = 1000; // 1 секунда задержки
            gameTimer.Tick += GameTimer_Tick;
        }

        private void StartNewGame()
        {
            // Инициализация колоды
            deck = new List<string>();
            string[] suits = { "H", "D", "C", "S" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add(suit + rank);
                }
            }

            // Перемешивание колоды
            ShuffleDeck();

            // Вынимаем 4 карты на стол
            for (int i = 0; i < 4; i++)
            {
                tableCards[i] = deck[0];
                deck.RemoveAt(0);
                UpdateCardImage(cardBoxes[i], tableCards[i]);
            }

            deckCount = deck.Count;
            UpdateStatus();
            gameTimer.Start();
        }

        private void ShuffleDeck()
        {
            // Алгоритм Фишера-Йейтса для перемешивания
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                string temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;
            }
        }

        private void UpdateCardImage(PictureBox box, string card)
        {
            if (string.IsNullOrEmpty(card))
            {
                box.Image = null;
                box.BackColor = Color.DarkGreen;
                return;
            }

            // Создаем простое изображение карты
            Bitmap bmp = new Bitmap(100, 150);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.DrawRectangle(Pens.Black, 0, 0, 99, 149);

                // Определяем цвет масти
                Brush suitBrush = card.StartsWith("H") || card.StartsWith("D")
                    ? Brushes.Red
                    : Brushes.Black;

                // Рисуем обозначение карты
                Font font = new Font("Arial", 14);
                g.DrawString(card, font, suitBrush, 10, 10);
            }
            box.Image = bmp;
        }

        private void UpdateStatus()
        {
            statusLabel.Text = $"Карт в колоде: {deckCount}";
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Проверяем наличие пар
            if (FindMatchingPair(out int index1, out int index2))
            {
                // Заменяем карты если есть пара
                if (deck.Count >= 2)
                {
                    tableCards[index1] = deck[0];
                    deck.RemoveAt(0);
                    tableCards[index2] = deck[0];
                    deck.RemoveAt(0);
                    deckCount = deck.Count;

                    UpdateCardImage(cardBoxes[index1], tableCards[index1]);
                    UpdateCardImage(cardBoxes[index2], tableCards[index2]);
                    UpdateStatus();
                }
                else
                {
                    EndGame(true); // Пасьянс сошелся
                }
            }
            else
            {
                EndGame(deck.Count == 0); // Проверяем результат
            }
        }

        private bool FindMatchingPair(out int index1, out int index2)
        {
            index1 = -1;
            index2 = -1;

            // Ищем две карты с одинаковой мастью
            for (int i = 0; i < 3; i++)
            {
                if (tableCards[i] == null) continue;

                for (int j = i + 1; j < 4; j++)
                {
                    if (tableCards[j] == null) continue;

                    // Сравниваем первую букву (масть)
                    if (tableCards[i][0] == tableCards[j][0])
                    {
                        index1 = i;
                        index2 = j;
                        return true;
                    }
                }
            }
            return false;
        }

        private void EndGame(bool success)
        {
            gameTimer.Stop();
            MessageBox.Show(success
                ? "Пасьянс сошелся! Желание сбудется!"
                : "Пасьянс не сошелся. Попробуйте еще раз.");
        }

        private void ShowProbabilityForm()
        {
            ProbabilityForm probForm = new ProbabilityForm();
            probForm.ShowDialog();
        }
    }
}