using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTwoSolitaireExam
{
    public partial class MainForm : Form
    {
        private List<string> deck;
        private List<string> currentCards;
        private Random rng = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            labelResult.Text = "Пасьянс запущен...";
            deck = GenerateShuffledDeck();
            currentCards = new List<string>();
            timerStep.Enabled = true;

            pictureBoxDeck.Image = GetBackImage();
        }

        private List<string> GenerateShuffledDeck()
        {
            string[] suits = { "H", "D", "C", "S" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var cards = new List<string>();

            foreach (string suit in suits)
                foreach (string value in values)
                    cards.Add(suit + value);

            return cards.OrderBy(_ => rng.Next()).ToList();
        }

        private Image GetBackImage()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "back.png");
            if (File.Exists(imagePath))
                return Image.FromFile(imagePath);
            else
            {
                Bitmap bmp = new Bitmap(80, 120);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Blue);
                    using (Font f = new Font("Arial", 12, FontStyle.Bold))
                    using (Brush b = Brushes.White)
                        g.DrawString("Back", f, b, 10, 45);
                }
                return bmp;
            }
        }

        private void timerStep_Tick(object sender, EventArgs e)
        {
            if (deck.Count == 0)
            {
                labelResult.Text = "Пасьянс сошёлся! Желание сбудется!";
                timerStep.Enabled = false;
                UpdateInterface();
                return;
            }

            if (currentCards.Count < 4)
            {
                int countToDraw = 4 - currentCards.Count;
                for (int i = 0; i < countToDraw && deck.Count > 0; i++)
                {
                    currentCards.Add(deck[0]);
                    deck.RemoveAt(0);
                }
            }

            if (currentCards.Count == 4)
            {
                var groups = currentCards.GroupBy(card => card[0]); 
                bool matchFound = false;

                foreach (var group in groups)
                {
                    if (group.Count() >= 2)
                    {
                        var matchedCards = group.Take(2).ToList();
                        foreach (var card in matchedCards)
                            currentCards.Remove(card);

                        for (int i = 0; i < 2 && deck.Count > 0; i++)
                        {
                            currentCards.Add(deck[0]);
                            deck.RemoveAt(0);
                        }

                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                {
                    labelResult.Text = "Пасьянс не сошёлся. Увы.";
                    timerStep.Enabled = false;
                }
            }

            UpdateInterface();
        }

        private Image CreateCardImage(string cardCode)
        {
            string imagePath = Path.Combine(Application.StartupPath, "Resources", cardCode + ".png");
            if (File.Exists(imagePath))
            {
                try
                {
                    return Image.FromFile(imagePath);
                }
                catch
                {
                }
            }

            Bitmap bmp = new Bitmap(80, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                using (Font f = new Font("Arial", 14, FontStyle.Bold))
                using (Brush b = new SolidBrush(Color.Black))
                {
                    g.DrawRectangle(Pens.Black, 0, 0, bmp.Width - 1, bmp.Height - 1);
                    g.DrawString(cardCode, f, b, new PointF(10, 45));
                }
            }

            return bmp;
        }

        private void UpdateInterface()
        {
            var boxes = new[] { pictureBoxCard1, pictureBoxCard2, pictureBoxCard3, pictureBoxCard4 };
            for (int i = 0; i < 4; i++)
                boxes[i].Image = i < currentCards.Count
                    ? CreateCardImage(currentCards[i])
                    : null;

            toolStripStatusLabelDeckCount.Text = $"Осталось карт: {deck.Count}";
        }

        private void вероятностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProbabilityForm();
            form.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBoxDeck.Image = GetBackImage();
        }
    }
}