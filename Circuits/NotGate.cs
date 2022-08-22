using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements a NOT gate with one input
    /// and one output.
    /// </summary>
    class NotGate : Gate
    {
        /// <summary>
        /// Creates a not gate
        /// </summary>
        /// <param name="x">X position of not gate</param>
        /// <param name="y">Y position of not gate</param>
        public NotGate(int x, int y) : base(x, y)
        {
            height = 40;
            width = 40;

            ////Single input and one output for NOT gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, false, 20));
        }

        /// <summary>
        /// Where to move the gate to
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
                pins[0].X = x - width / 4;
                pins[0].Y = y + height / 2;
                pins[1].X = x + width + GAP;
                pins[1].Y = y + height / 2;
            }
            catch
            {
                Debug.WriteLine("No Pins.");
            }
        }

        /// <summary>
        /// Draws the gate on the given graphics
        /// </summary>
        /// <param name="paper">Where to draw the gate</param>
        public override void Draw(Graphics paper)
        {
            Bitmap bmp = new Bitmap(Properties.Resources.NotGate);

            if (selected)
            {
                bmp = new Bitmap(Properties.Resources.NotGate___Red);
            }
            else
            {
                bmp = new Bitmap(Properties.Resources.NotGate);
            }
            pins[0].Draw(paper);
            pins[1].Draw(paper);


            // Draw NOT gate
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
                return !gateA.Evaluate();
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
