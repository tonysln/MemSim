using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

/// <summary>
/// Simulaator mäluhõivamisalgoritmide töö visualiseerimiseks
/// Operatsioonisüsteemid 20/21
/// Tartu Ülikool
/// @author Anton Slavin
/// </summary>
namespace MemSim
{
    class Protsess
    {
        public string Name { get; }
        public int Remaining { get; set; }
        public int Memory { get; set; }
        public int Steps { get; }
        public Color Color { get; set; }

        public Protsess(string name, int memory, int steps, Color color)
        {
            this.Name = name;
            this.Memory = memory;
            this.Steps = steps;
            this.Color = color;
            this.Remaining = this.Steps;
        }

        public Protsess(string name, int memory)
        {
            // Used for generating an empty block
            this.Name = name;
            this.Memory = memory;
            this.Steps = -1;
            this.Color = Color.LightGray;
            this.Remaining = this.Steps;
        }

        public override string ToString()
        {
            return "[" + this.Name + "] (Steps = " + this.Steps + ", Memory = " + this.Memory + ", Remaining = " + this.Remaining + ")";
        }

    }
}
