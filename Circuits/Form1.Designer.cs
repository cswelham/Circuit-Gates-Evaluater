namespace Circuits
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAnd = new System.Windows.Forms.ToolStripButton();
            this.buttonOr = new System.Windows.Forms.ToolStripButton();
            this.buttonNot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripEvaluate = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCopy = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAnd,
            this.buttonOr,
            this.buttonNot,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripEvaluate,
            this.toolStripCopy,
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(472, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAnd
            // 
            this.buttonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAnd.Image = global::Circuits.Properties.Resources.AndGate;
            this.buttonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(24, 24);
            this.buttonAnd.Text = "And";
            this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
            // 
            // buttonOr
            // 
            this.buttonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOr.Image = global::Circuits.Properties.Resources.OrGate;
            this.buttonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(24, 24);
            this.buttonOr.Text = "Or";
            this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
            // 
            // buttonNot
            // 
            this.buttonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNot.Image = global::Circuits.Properties.Resources.NotGate;
            this.buttonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(24, 24);
            this.buttonNot.Text = "Not";
            this.buttonNot.Click += new System.EventHandler(this.buttonNot_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Circuits.Properties.Resources.InputIcon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "Input";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "Output";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripEvaluate
            // 
            this.toolStripEvaluate.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.toolStripEvaluate.Name = "toolStripEvaluate";
            this.toolStripEvaluate.Size = new System.Drawing.Size(71, 24);
            this.toolStripEvaluate.Text = "Evaluate";
            this.toolStripEvaluate.Click += new System.EventHandler(this.toolStripEvaluate_Click);
            // 
            // toolStripCopy
            // 
            this.toolStripCopy.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.toolStripCopy.Name = "toolStripCopy";
            this.toolStripCopy.Size = new System.Drawing.Size(55, 24);
            this.toolStripCopy.Text = "Copy";
            this.toolStripCopy.Click += new System.EventHandler(this.toolStripCopy_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 24);
            this.toolStripLabel1.Text = "Start Group";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(63, 24);
            this.toolStripLabel2.Text = "End Group";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(472, 307);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Digital Circuits 104";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonAnd;
        private System.Windows.Forms.ToolStripButton buttonOr;
        private System.Windows.Forms.ToolStripButton buttonNot;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripEvaluate;
        private System.Windows.Forms.ToolStripLabel toolStripCopy;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}

