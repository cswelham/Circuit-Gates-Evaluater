using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Circuits
{
    public abstract class Gate
    {
        // left is the left-hand edge of the main part of the gate.
        // So the input pins are further left than left.
        protected int left;

        // top is the top of the whole gate
        protected int top;

        // width and height of the main part of the gate
        protected int width;
        protected int height;
        // length of the connector legs sticking out left and right
        protected const int GAP = 10;

        protected Brush selectedBrush = Brushes.Red;
        protected Brush normalBrush = Brushes.LightGray;

        /// <summary>
        /// This is the list of all the pins of this gate.
        /// An AND gate always has two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        protected List<Pin> pins = new List<Pin>();

        protected bool selected = false;

        /// <summary>
        /// Creates a new gate
        /// </summary>
        /// <param name="x">X position of gate</param>
        /// <param name="y">Y position of gate</param>
        public Gate(int x, int y)
        {
            MoveTo(x, y); // move the gate and position the pins
        }

        /// <summary>
        /// Indicates whether this gate is the current one selected.
        /// </summary>
        public virtual bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public int Left
        {
            get { return left; }
        }

        public int Top
        {
            get { return top; }
        }

        public List<Pin> Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// True if the given (x,y) position is roughly
        /// on top of this gate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + width
                && top <= y && y < top + height)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Draws the gate on the given graphics
        /// </summary>
        /// <param name="paper">Where to draw the gate</param>
        public abstract void Draw(Graphics paper);

        /// <summary>
        /// Where to move the gate to
        /// </summary>
        /// <param name="x">X position to move gate to</param>
        /// <param name="y">Y position to move gate to</param>
        public abstract void MoveTo(int x, int y);

        /// <summary>
        /// Evaluates whethere the circuit coming into the gate is true
        /// </summary>
        /// <returns>Evaluates whethere the circuit coming into the gate is true</returns>
        public abstract bool Evaluate();

        /// <summary>
        /// Returns gate to clone
        /// </summary>
        /// <returns>Gate to clone</returns>
        public abstract Gate Clone();
    }
}
