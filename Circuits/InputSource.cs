using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements an intput source with one output
    /// </summary>
    public class InputSource : Gate
    {
        private bool _highVoltage;

        /// <summary>
        /// Creates a new input source
        /// </summary>
        /// <param name="x">X position of input source</param>
        /// <param name="y">Y position of input source</param>
        public InputSource(int x, int y) : base(x, y)
        {
            _highVoltage = false;
            height = 16;
            width = 10;

            //Single output for input source
            pins.Add(new Pin(this, false, 10));
        }

        /// <summary>
        /// Sets and gets whether the input source is on or off
        /// </summary>
        public bool HighVoltage
        {
            get { return _highVoltage; }
            set { _highVoltage = value; }
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
                pins[0].X = x + width + GAP;
                pins[0].Y = y + height / 2;
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
            Bitmap bmp;

            if (_highVoltage == true)
            {
                bmp = new Bitmap(Properties.Resources.InputIcon_Green2);
            }
            else
            {
                bmp = new Bitmap(Properties.Resources.InputIcon);
            }
            pins[0].Draw(paper);

            // Draw Input Source
            paper.DrawImage(bmp, left, top);
        }

        /// <summary>
        /// Evaluates whethere the circuit coming into the gate is true
        /// </summary>
        /// <returns>Evaluates whethere the circuit coming into the gate is true</returns>
        public override bool Evaluate()
        {
            return _highVoltage;
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
