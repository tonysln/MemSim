using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

/// <summary>
/// Simulaator mäluhõivamisalgoritmide töö visualiseerimiseks
/// Operatsioonisüsteemid 20/21
/// Tartu Ülikool
/// @author Anton Slavin
/// </summary>
namespace MemSim
{
    class Simulaator
    {
        public List<Protsess> SaabunudProtsessid { get; }
        private List<Protsess> Blocks;
        public List<List<Protsess>> OutputMatrix { get; }
        
        private readonly Color[] colors;
        private readonly string names;

        public Simulaator()
        {
            SaabunudProtsessid = new List<Protsess>();
            Blocks = new List<Protsess>();
            // Add one empty block with memory = 50
            Blocks.Add(new Protsess("-", 50));

            OutputMatrix = new List<List<Protsess>>();

            // Req: 10 processes max., so 10 distinct colors (will most likely crash if more tasks found)
            colors = new Color[10] { Color.DarkRed,  Color.Red, Color.Orange, Color.Yellow,
                                     Color.Green, Color.SpringGreen, Color.Cyan, Color.Blue,
                                     Color.CadetBlue, Color.BlueViolet};
            names = "ABCDEFGHIJ";
        }

        private void connectEmptyBlocks()
        {
            for (int i = 1; i < Blocks.Count; i++)
            {
                // This and previous blocks are empty - connect them
                // Very inefficient!
                if (Blocks[i-1].Name.Equals("-") && Blocks[i].Name.Equals("-"))
                {
                    // Previous block size + this block size
                    Blocks[i - 1].Memory += Blocks[i].Memory;
                    // Remove current block from list
                    Blocks.Remove(Blocks[i]);
                    // Block list size changed, move back one index (check again with this one)
                    i--;
                }
            }
        }

        public void Allocate(string algorithm)
        {
            for (int proc = 0; proc < 10; proc++)
            {
                // New etapp - transfer everything from block for drawing
                List<Protsess> etapp = new List<Protsess>();

                // Finish any remaining processes (check for Remaining and replace with empty if needed)
                for (int i = 0; i < Blocks.Count; i++)
                {
                    Protsess block = Blocks[i];
                    // Deal with Remaining if block was not empty
                    if (!block.Name.Equals("-"))
                    {
                        if (block.Remaining == 0) Blocks[i] = new Protsess("-", block.Memory);
                        else Blocks[i].Remaining--;
                    }
                }
                connectEmptyBlocks();

                // No more processes left
                if (proc >= SaabunudProtsessid.Count)
                {
                    // Fill up any remaining processes if needed
                    foreach (Protsess p in Blocks) etapp.Add(new Protsess(p.Name, p.Memory, p.Steps, p.Color));
                    OutputMatrix.Add(etapp);
                    continue;
                }

                // Otherwise deal with new current process
                Protsess newProc = SaabunudProtsessid[proc];

                bool found = false;
                // Algorithm switcher /////////////////////////////////////////////////////////////
                switch (algorithm)
                {
                    case "First-Fit":
                        for (int i = 0; i < Blocks.Count; i++)
                        {
                            Protsess block = Blocks[i];
                            if (block.Name.Equals("-") && block.Memory >= newProc.Memory)
                            {
                                // Overwrite the empty block with the process, but create a leftover empty block
                                int remainderSize = block.Memory - newProc.Memory;
                                Blocks[i] = new Protsess(newProc.Name, newProc.Memory, newProc.Steps, newProc.Color);
                                Blocks[i].Remaining--; // Runs for one step already
                                Blocks.Insert(i + 1, new Protsess("-", remainderSize));
                                found = true;
                                break;
                            }
                        }
                        break;
                    case "Last-Fit":
                        for (int i = Blocks.Count - 1; i >= 0; i--)
                        {
                            Protsess block = Blocks[i];
                            if (block.Name.Equals("-") && block.Memory >= newProc.Memory)
                            {
                                // Overwrite the empty block with the process, but create a leftover empty block
                                int remainderSize = block.Memory - newProc.Memory;
                                Blocks[i] = new Protsess(newProc.Name, newProc.Memory, newProc.Steps, newProc.Color);
                                Blocks[i].Remaining--; // Run for one step already
                                Blocks.Insert(i + 1, new Protsess("-", remainderSize));
                                found = true;
                                break;
                            }
                        }
                        break;
                    case "Best-Fit":
                        int bestFit = newProc.Memory;
                        while (true)
                        {
                            for (int i = 0; i < Blocks.Count; i++)
                            {
                                Protsess block = Blocks[i];
                                if (block.Name.Equals("-") && block.Memory == bestFit)
                                {
                                    // Overwrite the empty block with the process, but create a leftover empty block
                                    int remainderSize = block.Memory - newProc.Memory;
                                    Blocks[i] = new Protsess(newProc.Name, newProc.Memory, newProc.Steps, newProc.Color);
                                    Blocks[i].Remaining--; // Run for one step already
                                    Blocks.Insert(i + 1, new Protsess("-", remainderSize));
                                    found = true;
                                    break;
                                }
                            }
                            if (found || bestFit >= 50) break;
                            else bestFit++;
                        }
                        break;
                    case "Worst-Fit":
                        int worstFit = 50;
                        while (true)
                        {
                            for (int i = 0; i < Blocks.Count; i++)
                            {
                                Protsess block = Blocks[i];
                                if (block.Name.Equals("-") && block.Memory == worstFit)
                                {
                                    // Overwrite the empty block with the process, but create a leftover empty block
                                    int remainderSize = block.Memory - newProc.Memory;
                                    Blocks[i] = new Protsess(newProc.Name, newProc.Memory, newProc.Steps, newProc.Color);
                                    Blocks[i].Remaining--; // Run for one step already
                                    Blocks.Insert(i + 1, new Protsess("-", remainderSize));
                                    found = true;
                                    break;
                                }
                            }
                            if (found || worstFit <= newProc.Memory) break;
                            else worstFit--;
                        }
                        break;
                    case "Random-Fit":
                        List<int> okBlocks = new List<int>();
                        for (int i = 0; i < Blocks.Count; i++)
                        {
                            if (Blocks[i].Name.Equals("-") && Blocks[i].Memory >= newProc.Memory) okBlocks.Add(i);
                        }
                        // Not enough memory, skip to next part (to add "x" block and break)
                        if (okBlocks.Count == 0) break;

                        // Generate a random index from the list of OK indices
                        Random rnd = new Random();
                        int randIndex = okBlocks[rnd.Next(0, okBlocks.Count)];
                        Protsess randBlock = Blocks[randIndex];

                        // Overwrite the empty block with the process, but create a leftover empty block
                        int remainder = randBlock.Memory - newProc.Memory;
                        Blocks[randIndex] = new Protsess(newProc.Name, newProc.Memory, newProc.Steps, newProc.Color);
                        Blocks[randIndex].Remaining--; // Run for one step already
                        Blocks.Insert(randIndex + 1, new Protsess("-", remainder));
                        found = true;
                        break;
                }

                ///////////////////////////////////////////////////////////////////////////////////

                if (!found)
                {
                    // Not enough memory to fit in the process
                    etapp.Clear();
                    etapp.Add(new Protsess("x", 50, -1, Color.Black));
                    OutputMatrix.Add(etapp);
                    break;
                }
                // Save the state of Blocks to output matrix
                foreach (Protsess p in Blocks) etapp.Add(new Protsess(p.Name, p.Memory, p.Steps, p.Color));
                OutputMatrix.Add(etapp);
            }
        }

        public void LoadFromString(string taskString)
        {
            // The input string does not contain ';' nor ',' or it is too long 
            if (!taskString.Contains(",") || (taskString.Length > 6 && !taskString.Contains(";")))
            {
                throw new FormatException();
            }

            String[] protsessid;

            try { protsessid = taskString.Trim().Split(';'); } // Failed to split, input most likely incorrect.
            catch (FormatException) { throw; } // Re-throw the exception to the caller.

            // In case more than 12 tasks are found, throw an error.
            if (protsessid.Length > 10) throw new FormatException();

            int i = 0;
            foreach (string prots in protsessid)
            {
                string[] protsParts = prots.Split(',');
                Protsess newProts = new Protsess(names[i].ToString(), // Nimi
                                                 Int32.Parse(protsParts[0]), // Mälumaht ehk memory
                                                 Int32.Parse(protsParts[1]), // Kestus ehk steps
                                                 (Color)colors[i++]); // Värv
                SaabunudProtsessid.Add(newProts);
            }
        }

        public void ClearLists()
        {
            SaabunudProtsessid.Clear();
            Blocks.Clear();
            // Add one empty block with memory = 50
            Blocks.Add(new Protsess("-", 50));
            OutputMatrix.Clear();
        }
    }
}
