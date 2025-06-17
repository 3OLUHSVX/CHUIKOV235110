namespace DoubleTwoSolitaireExam
{
    partial class ProbabilityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownExperiments = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProbabilityResult = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExperiments)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownExperiments
            // 
            this.numericUpDownExperiments.Location = new System.Drawing.Point(298, 223);
            this.numericUpDownExperiments.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDownExperiments.Name = "numericUpDownExperiments";
            this.numericUpDownExperiments.Size = new System.Drawing.Size(200, 22);
            this.numericUpDownExperiments.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(248, 251);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 23);
            this.progressBar.TabIndex = 1;
            // 
            // labelProbabilityResult
            // 
            this.labelProbabilityResult.AutoSize = true;
            this.labelProbabilityResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProbabilityResult.Location = new System.Drawing.Point(219, 277);
            this.labelProbabilityResult.Name = "labelProbabilityResult";
            this.labelProbabilityResult.Size = new System.Drawing.Size(365, 29);
            this.labelProbabilityResult.TabIndex = 2;
            this.labelProbabilityResult.Text = "Результат будет показан здесь";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(248, 319);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(95, 23);
            this.buttonCalculate.TabIndex = 3;
            this.buttonCalculate.Text = "Рассчитать";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(423, 319);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ProbabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.labelProbabilityResult);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.numericUpDownExperiments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProbabilityForm";
            this.Text = "Вычисление вероятности";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExperiments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownExperiments;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProbabilityResult;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonExit;
    }
}