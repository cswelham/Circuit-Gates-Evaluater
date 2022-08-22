using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Circuits
{
    /// <summary>
    /// This class implements a COMPOUND gate which is a group
    /// of gates.
    /// </summary>
    public class Compound : Gate
    {
        public List<Gate> compoundList;

        /// <summary>
        /// Creates a new compound gate
        /// </summary>
        /// <param name="x">X position of compound gate</param>
        /// <param name="y">Y position of compound gate</param>
        public Compound(int x, int y) : base(x, y)
        {
            height = 40;
            width = 40;
            compoundList = new List<Gate>();
        }

        /// <summary>
        /// Where to move the gate to
        /// </summary>
        /// <param name="x">Amount to move x position by</param>
        /// <param name="y">Amount to move y postion by</param>
        public override void MoveTo(int x, int y)
        {
            try
            {
                //For each gate in the compound list
                foreach (Gate g in compoundList)
                {
                    //Move the gate by the given x and y values
                    g.MoveTo(g.Left + x, g.Top + y);
                    Console.WriteLine(g.Left.ToString() + "," + g.Top.ToString());
                }               
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
            //For each gate in the compound list
            foreach (Gate g in compoundList)
            {
                //Call the gates draw method
                g.Draw(paper);
            }
        }

        /// <summary>
        /// Overrides the selected property so all gates in compound are selected
        /// </summary>
        public override bool Selected
        {
            get { return selected; }
            set
            {
                foreach (Gate g in compoundList)
                {
                    g.Selected = value;
                }
            }
        }

        /// <summary>
        /// Evaluates whethere the circuit coming into the gate is true
        /// </summary>
        /// <returns>Evaluates whethere the circuit coming into the gate is true</returns>
        public override bool Evaluate()
        {
            //This evaluate method is never called so always returns false
            return false;
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
