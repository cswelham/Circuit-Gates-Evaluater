using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Circuits
{
    //Questions
    //1. Better to fully document the gate class is it is the abstract class that all other classes
    //   interact with. You can only inherit comments when they are parameters and typing in the 
    //   parameters for each subclass.
    //2. An abstract class allows you to have base properties and base fucntions. It creates functionality
    //   that subclasses can implement or override. This also enforces a method onto each class
    //   so that the program writer does not forget to write a property. Only disadvantage is that an
    //   abstract class can not support multiple inheritance and that every subclass must override abstract methods. 
    //3. A class has to be abstract to have an abstracted method in it.
    //4. A compound gate inside a compound gate is hard to do, but it is doable. My program runs by using
    //   a list of compound gates. I would need to delete the previous 2 compound gates in the list and have
    //   only one compound for both compounds.


    /// <summary>
    /// The main GUI for the COMP104 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int startX, startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        protected Pin startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int currentX, currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Gate> gates = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> wires = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        protected Gate current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit
        /// </summary>
        protected Gate newGate = null;

        /// <summary>
        /// The cloned compound gate
        /// </summary>
        protected Compound compoundClone = null;

        /// <summary>
        /// Compound gate
        /// </summary>
        protected Compound newCompound = null;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Finds the pin that is close to (x,y), or returns
        /// null if there are no pins close to the position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Pin findPin(int x, int y)
        {
            foreach (Gate g in gates)
            {
                foreach (Pin p in g.Pins)
                {
                    if (p.isMouseOn(x, y))
                        return p;
                }
            }
            return null;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Gate g in gates)
            {
                g.Draw(e.Graphics);
            } 
            foreach (Wire w in wires)
            {
                w.Draw(e.Graphics);
            }
            if (startPin != null)
            {
                e.Graphics.DrawLine(Pens.White, 
                    startPin.X, startPin.Y, 
                    currentX, currentY);
            }
            if (newGate != null)
            {
                //If there is a compound clone gate
                if (compoundClone != null)
                {
                    foreach (Gate a in compoundClone.compoundList)
                    {
                        //Add all gates in compound to gates
                        gates.Add(a);
                    }
                    //Set compound clone gate to null
                    compoundClone = null;
                }
                else if (newGate is Compound)
                {
                    newGate.Draw(e.Graphics);
                }
                else
                {
                    // show the gate that we are dragging into the circuit
                    newGate.MoveTo(currentX, currentY);
                    newGate.Draw(e.Graphics);
                }
                                             
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bool comp = false;

            if (current != null)
            {
                //If the gate is in a compound then set all gates to not selected in compound
                comp = false;
                foreach (Gate g in gates)
                {
                    if (g is Compound)
                    {
                        Compound c = (Compound)g;
                        //See if new gate is a compound
                        foreach (Gate a in c.compoundList)
                        {
                            if (current == a)
                            {
                                c.Selected = false;
                            }
                        }
                    }
                }
                //If the gate is not in a compound set individual gate to not selected
                if (comp == false)
                {
                    current.Selected = false;
                }
                current = null;
                this.Invalidate();
            }
            // See if we are inserting a new gate
            else if (newGate != null)
            {
                if (newGate is Compound)
                { }
                else
                {
                    newGate.MoveTo(e.X, e.Y);
                }
                gates.Add(newGate);
                newGate = null;
                this.Invalidate();
            }
            else
            {
                // search for the first gate under the mouse position
                foreach (Gate g in gates)
                {
                    if (g.IsMouseOn(e.X, e.Y))
                    {
                        if (newCompound != null)
                        {
                            //Add gate to the compund group
                            newCompound.compoundList.Add(g);
                            MessageBox.Show("Added " + g + " To Group");
                        }
                        else if (g is InputSource)
                        {
                            //Set high voltage to opposite
                            InputSource s = (InputSource)g;
                            s.HighVoltage = !s.HighVoltage;
                        }
                        current = g;
                        comp = false;
                        foreach (Gate a in gates)
                        {
                            //If the gate is in a compound then set all gates to selected in compound
                            if (a is Compound)
                            {
                                Compound c = (Compound)a;
                                //See if new gate is a compound
                                foreach (Gate b in c.compoundList)
                                {
                                    if (current == b)
                                    {
                                        c.Selected = true;
                                    }
                                }
                            }
                        }
                        //If the gate is not in a compound set individual gate to not selected
                        if (comp == false)
                        {
                            current.Selected = true;
                        }
                        this.Invalidate();
                        break;
                    }
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
            }
            else if (current.IsMouseOn(e.X, e.Y))
            {
                // start dragging the current object around
                startX = e.X;
                startY = e.Y;
                currentX = current.Left;
                currentY = current.Top;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int diffX = 0;
            int diffY = 0;

            bool comp = false;

            if (startPin != null)
            {
                Debug.WriteLine("wire from "+startPin+" to " + e.X + "," + e.Y);
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();  // this will draw the line
            }
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                Debug.WriteLine("mouse move to " + e.X + "," + e.Y);

                comp = false;
                foreach (Gate a in gates)
                {
                    //See if new gate is a compound
                    if (a is Compound)
                    {
                        Compound c = (Compound)a;                        
                        foreach (Gate b in c.compoundList)
                        {
                            if (current == b)
                            {
                                //Calculate distance to move x position and y position of each gate in compound
                                diffX = e.X - current.Left;
                                diffY = e.Y - current.Top;
                                c.MoveTo(diffX, diffY);
                                comp = true;
                            }
                        }
                    }
                }
                if (comp == false)
                {
                    current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));
                }               
                this.Invalidate();
            }
            else if (newGate != null)
            {
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Creates a new OR gate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOr_Click(object sender, EventArgs e)
        {
            newGate = new OrGate(0, 0);
        }
        
        /// <summary>
        /// Creates a new NOT gate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNot_Click(object sender, EventArgs e)
        {
            newGate = new NotGate(0, 0);
        }

        /// <summary>
        /// Creates a new INPUT SOURCE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newGate = new InputSource(0, 0);
        }

        /// <summary>
        /// Creates a new OUTPUT LAMP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            newGate = new OutputLamp(0, 0);
        }

        /// <summary>
        /// Evaluates the boolean value of all output lamps on form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripEvaluate_Click(object sender, EventArgs e)
        {
            foreach (Gate g in gates)
            {
                if (g is OutputLamp)
                {
                    MessageBox.Show("Circuit is " + g.Evaluate().ToString() + ". Click a gate to change lamp colour.");
                    OutputLamp l = (OutputLamp)g;
                    if (g.Evaluate() == true)
                    {
                        l.HighVoltage = true;
                    }   
                    else
                    {
                        l.HighVoltage = false;
                    }
                }
            }
        }

        /// <summary>
        /// Copies/Clones a gate that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripCopy_Click(object sender, EventArgs e)
        {
            bool comp = false;
            int outputGateNum = 0;
            List<Gate> createCompound = new List<Gate>();

            foreach (Gate g in gates)
            {
                if (g.Selected == true)
                {
                    g.Selected = false;

                    foreach (Gate a in gates)
                    {
                        //If we need to clone a compound
                        if (a is Compound)
                        {
                            Compound c = (Compound)a;
                            foreach (Gate b in c.compoundList)
                            {
                                //Get the compound in compound list we are cloning
                                if (g.Clone() == b)
                                {
                                    //Create new compound clone and assign it to new gate
                                    compoundClone = new Compound(0, 0);
                                    newGate = compoundClone;
                                    //For each gate in compound list create a new gate shifted 100 down and right
                                    foreach (Gate x in c.compoundList)
                                    {
                                        comp = true;
                                        //Find what type of gate x is and add it to compound list
                                        if (x.Clone() is AndGate)
                                        {
                                            compoundClone.compoundList.Add(new AndGate(x.Left + 100, x.Top + 100));
                                        }

                                        else if (x.Clone() is InputSource)
                                        {
                                            compoundClone.compoundList.Add(new InputSource(x.Left + 100, x.Top + 100));
                                        }

                                        else if (x.Clone() is NotGate)
                                        {
                                            compoundClone.compoundList.Add(new NotGate(x.Left + 100, x.Top + 100));
                                        }

                                        else if (x.Clone() is OrGate)
                                        {
                                            compoundClone.compoundList.Add(new OrGate(x.Left + 100, x.Top + 100));
                                        }

                                        else if (x.Clone() is OutputLamp)
                                        {
                                            compoundClone.compoundList.Add(new OutputLamp(x.Left + 100, x.Top + 100));
                                        }
                                    }
                                    //For each gate find pins that are connected and connect them
                                    for (int i = 0; i < c.compoundList.Count; i++)
                                    {
                                        for (int q = 0; q < c.compoundList[i].Pins.Count; q++)
                                        {
                                            try
                                            {
                                                //If pin has input connected
                                                if (c.compoundList[i].Pins[q].InputWire.FromPin.Owner != null)
                                                {
                                                    //Gate output pin belongs to
                                                    Gate gateA = c.compoundList[i].Pins[q].InputWire.FromPin.Owner;

                                                    //Find number of gate in list which output pin belongs to
                                                    for (int t = 0; t < c.compoundList.Count; t++)
                                                    {
                                                        if (gateA == c.compoundList[t])
                                                        {
                                                            outputGateNum = t;
                                                        }
                                                    }
                                                    //Output pin that input pin is connected to
                                                    Pin gateAPin = c.compoundList[i].Pins[q].InputWire.FromPin;

                                                    //Find pin number output pin
                                                    for (int s = 0; s < gateA.Pins.Count; s++)
                                                    {
                                                        if (gateA.Pins[s] == gateAPin)
                                                        {
                                                            //Create new wire
                                                            Wire w = new Wire(compoundClone.compoundList[outputGateNum].Pins[s], compoundClone.compoundList[i].Pins[q]);
                                                            wires.Add(w);
                                                        }
                                                    }                                   
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("No wires.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //If it is not a compound we are cloning
                    if (comp == false)
                    {
                        //Find what type the gate is and create a new version of that gate
                        if (g.Clone() is AndGate)
                        {
                            newGate = new AndGate(0, 0);
                        }

                        else if (g.Clone() is InputSource)
                        {
                            newGate = new InputSource(0, 0);
                        }

                        else if (g.Clone() is NotGate)
                        {
                            newGate = new NotGate(0, 0);
                        }

                        else if (g.Clone() is OrGate)
                        {
                            newGate = new OrGate(0, 0);
                        }

                        else if (g.Clone() is OutputLamp)
                        {
                            newGate = new OutputLamp(0, 0);
                        }
                    }
                }
            }
            //If we did clone a compound show this message
            if (comp == true)
            {
                MessageBox.Show("Start dragging Gate for Pins and Wires to appear.");
            }
        }

        /// <summary>
        /// Creates a new compound group to start adding gates to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            newCompound = new Compound(0, 0);
        }

        /// <summary>
        /// Ends group by setting compound list to new gate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            //Set new gate to the compound
            newGate = newCompound;
            //Set new compound back to null
            newCompound = null;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);
                if (endPin != null)
                {
                    Debug.WriteLine("Trying to connect " + startPin + " to " + endPin);
                    Pin input, output;
                    if (startPin.IsOutput)
                    {
                        input = endPin;
                        output = startPin;
                    }
                    else
                    {
                        input = startPin;
                        output = endPin;
                    }
                    if (input.IsInput && output.IsOutput)
                    {
                        if (input.InputWire == null)
                        {
                            Wire newWire = new Wire(output, input);
                            input.InputWire = newWire;
                            wires.Add(newWire);
                        }
                        else
                        {
                            MessageBox.Show("That input is already used.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");
                    }
                }
                startPin = null;
                this.Invalidate();
            }
            // We have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;
        }

        /// <summary>
        /// Creates a new AND gate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnd_Click(object sender, EventArgs e)
        {
            newGate = new AndGate(0, 0);
        }
    }
}