using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs
    /// and one output.
    /// </summary>
    public class AndGate : Gate
    {
        /// <summary>
        /// Creates an AND gate
        /// </summary>
        /// <param name="x">X position of and gate</param>
        /// <param name="y">Y position of and gate</param>
        public AndGate(int x, int y) : base(x, y)
        {
            height = 40;
            width = 40;

            ////Input and output pins for AND/OR gates
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
        }

        /// <summary>
        /// Moves gate, 2 input pins and one output pins to x and y
        /// </summary>
        /// <param name="x">X position to move gate to</param>
        /// <param name="y">Y position to move gate to</param>
        public override void MoveTo(int x, int y)
        {
            try
            {
                Debug.WriteLine("pins = " + pins.Count);
                left = x;
                top = y;
                // must move the pins too
                pins[0].X = x - GAP;
                pins[0].Y = y + GAP;
                pins[1].X = x - GAP;
                pins[1].Y = y + height - GAP;
                pins[2].X = x + width + GAP;
                pins[2].Y = y + height / 2;
            }
            catch
            {
                Debug.WriteLine("No Pins.");
            }
        }

        /// <summary>
        /// Draws the and gate
        /// </summary>
        /// <param name="paper">Where to draw the gate</param>
        public override void Draw(Graphics paper)
        {
            Bitmap bmp = new Bitmap(Properties.Resources.AndGate);
            //If gate is seletced use red image
            if (selected)
            {
                bmp = new Bitmap(Properties.Resources.AndGate___Red);
            }
            //If not selected use normal image
            else
            {
                bmp = new Bitmap(Properties.Resources.AndGate);
            }

            for (int i = 0; i < 3; i++)
                pins[i].Draw(paper);

            // Draw AND gate
            paper.DrawImage(bmp, left, top);
        }

        /// <summary>
        /// Evaluates whethere the circuit coming into the gate is true 
        /// </summary>
        /// <returns>Evaluates whethere the circuit coming into the gate is true</returns>
        public override bool Evaluate()
        {
            try
            {
                Gate gateA = pins[0].InputWire.FromPin.Owner;
                Gate gateB = pins[1].InputWire.FromPin.Owner;
                return gateA.Evaluate() && gateB.Evaluate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Returns gate to clone
        /// </summary>
        /// <returns>Gate to clone</returns>
        public override Gate Clone()
        {
            return this;
        }
    }
}
