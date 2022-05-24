using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Simulaator mäluhõivamisalgoritmide töö visualiseerimiseks
/// Operatsioonisüsteemid 20/21
/// Tartu Ülikool
/// @author Anton Slavin
/// </summary>
namespace MemSim
{
    public partial class MainForm : Form
    {

        private Simulaator sim;
        private string algoInputString;
        private Bitmap chart;
        private int boxWidth;
        private int boxHeight;

        public MainForm()
        {
            InitializeComponent();
            sim = new Simulaator();
            algoInputString = "";
            boxWidth = 22;
            boxHeight = 18;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Clear();
            drawStepNumbers();
        }

        private void loadAlgoInput()
        {
            // Check if custom input is selected & copy input from the textbox
            if (customAlgo.Checked && (customAlgoTextbox.Text.Length != 0))
            {
                algoInputString = customAlgoTextbox.Text;
            }
            else
            {
                // Find the selected radio button (yes there are many better ways to do this)
                algoInputString = sampleAlgo1.Checked ? sampleAlgo1.Text :
                    (sampleAlgo2.Checked ? sampleAlgo2.Text :
                    (sampleAlgo3.Checked ? sampleAlgo3.Text : ""));
            }
        }

        private void startAlgorithm(string algorithm)
        {
            Clear();
            loadAlgoInput();

            if (String.IsNullOrEmpty(algoInputString)) return; // No input was given at all, exit.

            chosenAlgoLabel.Text = algorithm;

            // Display messagebox on error (wrong string format)
            try { sim.LoadFromString(algoInputString); }
            catch (FormatException)
            {
                MessageBox.Show("Vale sisend!", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Algorithm switcher based on the given parameter
            switch (algorithm)
            {
                case "First-Fit":
                    sim.Allocate("First-Fit");
                    break;
                case "Last-Fit":
                    sim.Allocate("Last-Fit");
                    break;
                case "Best-Fit":
                    sim.Allocate("Best-Fit");
                    break;
                case "Worst-Fit":
                    sim.Allocate("Worst-Fit");
                    break;
                case "Random-Fit":
                    sim.Allocate("Random-Fit");
                    break;
                default:
                    return;
            }

            DrawSimulation();

        }

        private void DrawSimulation()
        {
            chart = new Bitmap(simChart.Width, simChart.Height);

            using (Graphics gr = Graphics.FromImage(chart))
            using (Brush blackBrush = new SolidBrush(Color.Black))
            using (Font font = new Font("Consolas", 10))
            {
                gr.Clear(SystemColors.Control);
                gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Go through all 10 steps and for each step, draw out a line of the grid.
                for (int i = 0, yPos = 0; i < 10; i++, yPos += boxHeight)
                {
                    if (i >= sim.OutputMatrix.Count) break;
                    // First, add the step number to the label.
                    etappLabel.Text += (i + 1) + "\n";
                    if (i < sim.SaabunudProtsessid.Count)
                    {
                        // Then add the processes in the order they arrive.
                        Protsess prots = sim.SaabunudProtsessid[i];
                        string protsLabelText = prots.Name + " : " + prots.Memory + "," + prots.Steps + "\n";
                        lisatudLabel.Text += protsLabelText;
                    }
                    else
                    {
                        // If there are < 10 processes, just add "-".
                        lisatudLabel.Text += "-\n";
                    }

                    // Output matrix contains 10 Lists of Processes, get the i-th list.
                    List<Protsess> etapp = sim.OutputMatrix[i];

                    // Loop over all blocks in etapp
                    for (int j = 0, xPos = 0; j < etapp.Count; j++)
                    {
                        Protsess block = etapp[j];

                        for (int mem = 0; mem < block.Memory; mem++, xPos += boxWidth)
                        {
                            // One rectangle - one tick.
                            Rectangle rect = new Rectangle(xPos, yPos, boxWidth, boxHeight);

                            // Processes have letters for names, or "-" if the tick was empty.
                            SizeF stringSize = gr.MeasureString("A", font);
                            PointF stringLocation = new PointF(xPos + (boxWidth / 2) - (stringSize.Width / 2),
                                                               yPos + (boxHeight / 2) - (stringSize.Height / 2) + 1);

                            // Color: from process
                            gr.FillRectangle(new SolidBrush(block.Color), rect);
                            using (Pen selPen = new Pen(Color.Black))
                            {
                                gr.DrawRectangle(selPen, rect);
                            }
                            // Label: name of process.
                            gr.DrawString(block.Name, font, blackBrush, stringLocation);
                        }

                        // Check if there was not enough memory left (process name "x"), draw extra text on top
                        if (block.Name.Equals("x"))
                        {
                            string text = "Protsess ei mahu mällu";
                            SizeF stringSize = gr.MeasureString(text, font);
                            PointF stringLocation = new PointF((boxWidth*50 / 2) - (stringSize.Width / 2),
                                                               yPos + (boxHeight / 2) - (stringSize.Height / 2) + 1);
                            gr.DrawString(text, font, new SolidBrush(Color.White), stringLocation);
                        }
                    }
                }
            }
            simChart.Image = chart;
        }

        private void drawStepNumbers()
        {
            chart = new Bitmap(stepNumberBox.Width, stepNumberBox.Height);

            using (Graphics gr = Graphics.FromImage(chart))
            using (Brush blackBrush = new SolidBrush(Color.Black))
            using (Font font = new Font("Consolas", 10))
            {
                gr.Clear(SystemColors.Control);
                gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Very similiar to the method for drawing grid, but draws just one top row - the numbers.
                // I've decided to separate the numbers so there would be no need to adjust the Y position of everything in the grid.
                // Numbers use the same width and are centered nicely.
                for (int j = 0, xPos = 0; j < 50; j++, xPos += boxWidth)
                {
                    string number = j + "";
                    SizeF stringSize = gr.MeasureString(number, font);
                    PointF stringLocation = new PointF(xPos + (boxWidth  / 2) - (stringSize.Width / 2),
                                                       (boxHeight / 2) - (stringSize.Height / 2) + 1);
                    gr.DrawString(number, font, blackBrush, stringLocation);
                }
            }

            stepNumberBox.Image = chart;
        }

        private void Clear()
        {
            sim.ClearLists();
            chosenAlgoLabel.Text = "---";
            etappLabel.Text = "";
            lisatudLabel.Text = "";
            simChart.Image = null;
            GC.Collect();
        }

        // Button clicks
        private void FirstFitButton_Click(object sender, EventArgs e) { startAlgorithm("First-Fit"); }
        private void LastFitButton_Click(object sender, EventArgs e) { startAlgorithm("Last-Fit"); }
        private void BestFitButton_Click(object sender, EventArgs e) { startAlgorithm("Best-Fit"); }
        private void WorstFitButton_Click(object sender, EventArgs e) { startAlgorithm("Worst-Fit"); }
        private void RandomFitButton_Click(object sender, EventArgs e) { startAlgorithm("Random-Fit"); }
        private void ClearButton_Click(object sender, EventArgs e) { Clear(); }

        // Switch to the "custom algorithm" option automatically when selecting its input textbox
        private void customAlgoTextbox_TextChanged(object sender, EventArgs e) { customAlgo.Checked = true; }
        private void customAlgoTextbox_Click(object sender, EventArgs e) { customAlgo.Checked = true; }
        private void customAlgoTextbox_Enter(object sender, EventArgs e) { customAlgo.Checked = true; }
    }
}
