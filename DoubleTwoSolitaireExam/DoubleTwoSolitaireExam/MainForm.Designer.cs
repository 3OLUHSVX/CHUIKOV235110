namespace DoubleTwoSolitaireExam
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вероятностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxDeck = new System.Windows.Forms.PictureBox();
            this.pictureBoxCard1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCard2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCard3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCard4 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDeckCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelResult = new System.Windows.Forms.Label();
            this.timerStep = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard4)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.вероятностьToolStripMenuItem,
            this.выходToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            resources.ApplyResources(this.новаяИграToolStripMenuItem, "новаяИграToolStripMenuItem");
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // вероятностьToolStripMenuItem
            // 
            this.вероятностьToolStripMenuItem.Name = "вероятностьToolStripMenuItem";
            resources.ApplyResources(this.вероятностьToolStripMenuItem, "вероятностьToolStripMenuItem");
            this.вероятностьToolStripMenuItem.Click += new System.EventHandler(this.вероятностьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            resources.ApplyResources(this.выходToolStripMenuItem, "выходToolStripMenuItem");
            // 
            // pictureBoxDeck
            // 
            resources.ApplyResources(this.pictureBoxDeck, "pictureBoxDeck");
            this.pictureBoxDeck.Name = "pictureBoxDeck";
            this.pictureBoxDeck.TabStop = false;
            // 
            // pictureBoxCard1
            // 
            resources.ApplyResources(this.pictureBoxCard1, "pictureBoxCard1");
            this.pictureBoxCard1.Name = "pictureBoxCard1";
            this.pictureBoxCard1.TabStop = false;
            // 
            // pictureBoxCard2
            // 
            resources.ApplyResources(this.pictureBoxCard2, "pictureBoxCard2");
            this.pictureBoxCard2.Name = "pictureBoxCard2";
            this.pictureBoxCard2.TabStop = false;
            // 
            // pictureBoxCard3
            // 
            resources.ApplyResources(this.pictureBoxCard3, "pictureBoxCard3");
            this.pictureBoxCard3.Name = "pictureBoxCard3";
            this.pictureBoxCard3.TabStop = false;
            // 
            // pictureBoxCard4
            // 
            resources.ApplyResources(this.pictureBoxCard4, "pictureBoxCard4");
            this.pictureBoxCard4.Name = "pictureBoxCard4";
            this.pictureBoxCard4.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDeckCount});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelDeckCount
            // 
            this.toolStripStatusLabelDeckCount.Name = "toolStripStatusLabelDeckCount";
            resources.ApplyResources(this.toolStripStatusLabelDeckCount, "toolStripStatusLabelDeckCount");
            // 
            // labelResult
            // 
            resources.ApplyResources(this.labelResult, "labelResult");
            this.labelResult.Name = "labelResult";
            // 
            // timerStep
            // 
            this.timerStep.Interval = 1000;
            this.timerStep.Tick += new System.EventHandler(this.timerStep_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBoxCard4);
            this.Controls.Add(this.pictureBoxCard3);
            this.Controls.Add(this.pictureBoxCard2);
            this.Controls.Add(this.pictureBoxCard1);
            this.Controls.Add(this.pictureBoxDeck);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard4)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вероятностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxDeck;
        private System.Windows.Forms.PictureBox pictureBoxCard1;
        private System.Windows.Forms.PictureBox pictureBoxCard2;
        private System.Windows.Forms.PictureBox pictureBoxCard3;
        private System.Windows.Forms.PictureBox pictureBoxCard4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDeckCount;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Timer timerStep;
    }
}

