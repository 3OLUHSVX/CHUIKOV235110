using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTwoSolitaireExam
{
    public partial class ProbabilityForm : Form
    {
        public ProbabilityForm()
        {
            InitializeComponent();
        }

        private async void buttonCalculate_Click(object sender, EventArgs e)
        {
            int experiments = (int)numericUpDownExperiments.Value;
            if (experiments <= 0)
            {
                MessageBox.Show("Введите количество экспериментов больше нуля.");
                return;
            }

            buttonCalculate.Enabled = false;
            progressBar.Value = 0;
            labelProbabilityResult.Text = "Вычисление...";

            int successCount = 0;

            await Task.Run(() =>
            {
                var rng = new Random();
                var suits = new[] { "H", "D", "C", "S" };
                var values = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

                for (int i = 0; i < experiments; i++)
                {
                    var deck = new List<string>();
                    foreach (string s in suits)
                        foreach (string v in values)
                            deck.Add(s + v);

                    deck = deck.OrderBy(_ => rng.Next()).ToList();
                    var table = new List<string>();

                    while (deck.Count > 0)
                    {
                        while (table.Count < 4 && deck.Count > 0)
                        {
                            table.Add(deck[0]);
                            deck.RemoveAt(0);
                        }

                        if (table.Count < 4)
                            break;

                        var groups = table.GroupBy(c => c[0]);
                        bool match = false;

                        foreach (var group in groups)
                        {
                            if (group.Count() >= 2)
                            {
                                var toRemove = group.Take(2).ToList();
                                foreach (var card in toRemove)
                                    table.Remove(card);

                                for (int j = 0; j < 2 && deck.Count > 0; j++)
                                {
                                    table.Add(deck[0]);
                                    deck.RemoveAt(0);
                                }

                                match = true;
                                break;
                            }
                        }

                        if (!match)
                            break;
                    }

                    if (deck.Count == 0)
                        successCount++;

                    if (i % 1000 == 0)
                    {
                        int progress = (int)((i / (double)experiments) * 100);
                        Invoke((Action)(() => progressBar.Value = progress));
                    }
                }
            });

            double probability = (double)successCount / experiments;
            labelProbabilityResult.Text = $"Вероятность сходимости: {probability:P2}";
            progressBar.Value = 100;
            buttonCalculate.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}