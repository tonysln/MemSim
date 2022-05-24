namespace MemSim
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.algoInput = new System.Windows.Forms.GroupBox();
            this.customAlgoTextbox = new System.Windows.Forms.TextBox();
            this.customAlgo = new System.Windows.Forms.RadioButton();
            this.sampleAlgo3 = new System.Windows.Forms.RadioButton();
            this.sampleAlgo2 = new System.Windows.Forms.RadioButton();
            this.sampleAlgo1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.FirstFitButton = new System.Windows.Forms.Button();
            this.LastFitButton = new System.Windows.Forms.Button();
            this.BestFitButton = new System.Windows.Forms.Button();
            this.WorstFitButton = new System.Windows.Forms.Button();
            this.RandomFitButton = new System.Windows.Forms.Button();
            this.chosenAlgoLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.simChart = new System.Windows.Forms.PictureBox();
            this.etappLabel = new System.Windows.Forms.Label();
            this.lisatudLabel = new System.Windows.Forms.Label();
            this.stepNumberBox = new System.Windows.Forms.PictureBox();
            this.algoInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // algoInput
            // 
            this.algoInput.Controls.Add(this.customAlgoTextbox);
            this.algoInput.Controls.Add(this.customAlgo);
            this.algoInput.Controls.Add(this.sampleAlgo3);
            this.algoInput.Controls.Add(this.sampleAlgo2);
            this.algoInput.Controls.Add(this.sampleAlgo1);
            this.algoInput.Location = new System.Drawing.Point(29, 23);
            this.algoInput.Name = "algoInput";
            this.algoInput.Size = new System.Drawing.Size(545, 177);
            this.algoInput.TabIndex = 0;
            this.algoInput.TabStop = false;
            this.algoInput.Text = "Vali või sisesta kuni kümneelemendiline järjend kujul 3,5;2,7;8,2;4,6;7,1;6,4;8,8" +
    ";3,6;1,10;9,2";
            // 
            // customAlgoTextbox
            // 
            this.customAlgoTextbox.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customAlgoTextbox.Location = new System.Drawing.Point(119, 125);
            this.customAlgoTextbox.Name = "customAlgoTextbox";
            this.customAlgoTextbox.Size = new System.Drawing.Size(320, 25);
            this.customAlgoTextbox.TabIndex = 4;
            this.customAlgoTextbox.Click += new System.EventHandler(this.customAlgoTextbox_Click);
            this.customAlgoTextbox.TextChanged += new System.EventHandler(this.customAlgoTextbox_TextChanged);
            this.customAlgoTextbox.Enter += new System.EventHandler(this.customAlgoTextbox_Enter);
            // 
            // customAlgo
            // 
            this.customAlgo.AutoSize = true;
            this.customAlgo.Location = new System.Drawing.Point(28, 125);
            this.customAlgo.Name = "customAlgo";
            this.customAlgo.Size = new System.Drawing.Size(85, 21);
            this.customAlgo.TabIndex = 3;
            this.customAlgo.TabStop = true;
            this.customAlgo.Text = "Enda oma";
            this.customAlgo.UseVisualStyleBackColor = true;
            // 
            // sampleAlgo3
            // 
            this.sampleAlgo3.AutoSize = true;
            this.sampleAlgo3.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sampleAlgo3.Location = new System.Drawing.Point(28, 97);
            this.sampleAlgo3.Name = "sampleAlgo3";
            this.sampleAlgo3.Size = new System.Drawing.Size(362, 22);
            this.sampleAlgo3.TabIndex = 2;
            this.sampleAlgo3.TabStop = true;
            this.sampleAlgo3.Text = "5,10;6,6;3,9;8,4;3,6;5,12;1,4;15,3;3,4;9,7";
            this.sampleAlgo3.UseVisualStyleBackColor = true;
            // 
            // sampleAlgo2
            // 
            this.sampleAlgo2.AutoSize = true;
            this.sampleAlgo2.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sampleAlgo2.Location = new System.Drawing.Point(28, 69);
            this.sampleAlgo2.Name = "sampleAlgo2";
            this.sampleAlgo2.Size = new System.Drawing.Size(346, 22);
            this.sampleAlgo2.TabIndex = 1;
            this.sampleAlgo2.TabStop = true;
            this.sampleAlgo2.Text = "1,10;6,6;3,9;2,4;1,6;5,2;1,4;5,2;2,1;2,7";
            this.sampleAlgo2.UseVisualStyleBackColor = true;
            // 
            // sampleAlgo1
            // 
            this.sampleAlgo1.AutoSize = true;
            this.sampleAlgo1.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sampleAlgo1.Location = new System.Drawing.Point(28, 41);
            this.sampleAlgo1.Name = "sampleAlgo1";
            this.sampleAlgo1.Size = new System.Drawing.Size(346, 22);
            this.sampleAlgo1.TabIndex = 0;
            this.sampleAlgo1.TabStop = true;
            this.sampleAlgo1.Text = "4,5;2,7;9,2;4,6;7,1;6,4;8,8;3,6;1,10;9,2";
            this.sampleAlgo1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algoritmi käivitamiseks tee valik ja klõpsa nupule";
            // 
            // FirstFitButton
            // 
            this.FirstFitButton.Location = new System.Drawing.Point(29, 239);
            this.FirstFitButton.Name = "FirstFitButton";
            this.FirstFitButton.Size = new System.Drawing.Size(83, 25);
            this.FirstFitButton.TabIndex = 2;
            this.FirstFitButton.Text = "First-Fit";
            this.FirstFitButton.UseVisualStyleBackColor = true;
            this.FirstFitButton.Click += new System.EventHandler(this.FirstFitButton_Click);
            // 
            // LastFitButton
            // 
            this.LastFitButton.Location = new System.Drawing.Point(118, 239);
            this.LastFitButton.Name = "LastFitButton";
            this.LastFitButton.Size = new System.Drawing.Size(83, 25);
            this.LastFitButton.TabIndex = 3;
            this.LastFitButton.Text = "Last-Fit";
            this.LastFitButton.UseVisualStyleBackColor = true;
            this.LastFitButton.Click += new System.EventHandler(this.LastFitButton_Click);
            // 
            // BestFitButton
            // 
            this.BestFitButton.Location = new System.Drawing.Point(207, 239);
            this.BestFitButton.Name = "BestFitButton";
            this.BestFitButton.Size = new System.Drawing.Size(83, 25);
            this.BestFitButton.TabIndex = 4;
            this.BestFitButton.Text = "Best-Fit";
            this.BestFitButton.UseVisualStyleBackColor = true;
            this.BestFitButton.Click += new System.EventHandler(this.BestFitButton_Click);
            // 
            // WorstFitButton
            // 
            this.WorstFitButton.Location = new System.Drawing.Point(296, 239);
            this.WorstFitButton.Name = "WorstFitButton";
            this.WorstFitButton.Size = new System.Drawing.Size(83, 25);
            this.WorstFitButton.TabIndex = 5;
            this.WorstFitButton.Text = "Worst-Fit";
            this.WorstFitButton.UseVisualStyleBackColor = true;
            this.WorstFitButton.Click += new System.EventHandler(this.WorstFitButton_Click);
            // 
            // RandomFitButton
            // 
            this.RandomFitButton.Location = new System.Drawing.Point(385, 239);
            this.RandomFitButton.Name = "RandomFitButton";
            this.RandomFitButton.Size = new System.Drawing.Size(83, 25);
            this.RandomFitButton.TabIndex = 6;
            this.RandomFitButton.Text = "Random-Fit";
            this.RandomFitButton.UseVisualStyleBackColor = true;
            this.RandomFitButton.Click += new System.EventHandler(this.RandomFitButton_Click);
            // 
            // chosenAlgoLabel
            // 
            this.chosenAlgoLabel.AutoSize = true;
            this.chosenAlgoLabel.Font = new System.Drawing.Font("Segoe UI", 8.830189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chosenAlgoLabel.Location = new System.Drawing.Point(29, 276);
            this.chosenAlgoLabel.Name = "chosenAlgoLabel";
            this.chosenAlgoLabel.Size = new System.Drawing.Size(23, 17);
            this.chosenAlgoLabel.TabIndex = 8;
            this.chosenAlgoLabel.Text = "---";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(474, 239);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(83, 25);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Puhasta";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Etapp";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(83, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 39);
            this.label3.TabIndex = 11;
            this.label3.Text = "Lisatud protsess";
            // 
            // simChart
            // 
            this.simChart.Location = new System.Drawing.Point(166, 347);
            this.simChart.Name = "simChart";
            this.simChart.Size = new System.Drawing.Size(1106, 181);
            this.simChart.TabIndex = 13;
            this.simChart.TabStop = false;
            // 
            // etappLabel
            // 
            this.etappLabel.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.etappLabel.Location = new System.Drawing.Point(29, 347);
            this.etappLabel.Name = "etappLabel";
            this.etappLabel.Size = new System.Drawing.Size(48, 180);
            this.etappLabel.TabIndex = 14;
            this.etappLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lisatudLabel
            // 
            this.lisatudLabel.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lisatudLabel.Location = new System.Drawing.Point(74, 347);
            this.lisatudLabel.Name = "lisatudLabel";
            this.lisatudLabel.Size = new System.Drawing.Size(89, 178);
            this.lisatudLabel.TabIndex = 15;
            this.lisatudLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // stepNumberBox
            // 
            this.stepNumberBox.Location = new System.Drawing.Point(165, 327);
            this.stepNumberBox.Name = "stepNumberBox";
            this.stepNumberBox.Size = new System.Drawing.Size(1106, 19);
            this.stepNumberBox.TabIndex = 16;
            this.stepNumberBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 556);
            this.Controls.Add(this.stepNumberBox);
            this.Controls.Add(this.lisatudLabel);
            this.Controls.Add(this.etappLabel);
            this.Controls.Add(this.simChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.chosenAlgoLabel);
            this.Controls.Add(this.RandomFitButton);
            this.Controls.Add(this.WorstFitButton);
            this.Controls.Add(this.BestFitButton);
            this.Controls.Add(this.LastFitButton);
            this.Controls.Add(this.FirstFitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.algoInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mäluhõive Simulaator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.algoInput.ResumeLayout(false);
            this.algoInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepNumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox algoInput;
        private System.Windows.Forms.RadioButton customAlgo;
        private System.Windows.Forms.RadioButton sampleAlgo3;
        private System.Windows.Forms.RadioButton sampleAlgo2;
        private System.Windows.Forms.RadioButton sampleAlgo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FirstFitButton;
        private System.Windows.Forms.Button LastFitButton;
        private System.Windows.Forms.Button BestFitButton;
        private System.Windows.Forms.Button WorstFitButton;
        private System.Windows.Forms.Button RandomFitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox customAlgoTextbox;
        private System.Windows.Forms.Label chosenAlgoLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox simChart;
        private System.Windows.Forms.Label etappLabel;
        private System.Windows.Forms.Label lisatudLabel;
        private System.Windows.Forms.PictureBox stepNumberBox;
    }
}

