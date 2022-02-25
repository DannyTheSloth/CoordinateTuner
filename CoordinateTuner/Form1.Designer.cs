namespace CoordinateTuner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.coordinatePanel = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAfterThisPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fieldPanel = new System.Windows.Forms.Panel();
            this.coordinatePanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // coordinatePanel
            // 
            this.coordinatePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coordinatePanel.Controls.Add(this.listBox1);
            this.coordinatePanel.Controls.Add(this.button2);
            this.coordinatePanel.Controls.Add(this.button1);
            this.coordinatePanel.Location = new System.Drawing.Point(12, 12);
            this.coordinatePanel.Name = "coordinatePanel";
            this.coordinatePanel.Size = new System.Drawing.Size(185, 429);
            this.coordinatePanel.TabIndex = 0;
            this.coordinatePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.coordinatePanel_Paint);
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(179, 364);
            this.listBox1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.addAfterThisPointToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addAfterThisPointToolStripMenuItem
            // 
            this.addAfterThisPointToolStripMenuItem.Name = "addAfterThisPointToolStripMenuItem";
            this.addAfterThisPointToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addAfterThisPointToolStripMenuItem.Text = "Add After This Point";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "Linear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Spline";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fieldPanel
            // 
            this.fieldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldPanel.Location = new System.Drawing.Point(203, 12);
            this.fieldPanel.Name = "fieldPanel";
            this.fieldPanel.Size = new System.Drawing.Size(429, 429);
            this.fieldPanel.TabIndex = 1;
            this.fieldPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fieldPanel_MouseDown);
            this.fieldPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fieldPanel_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 453);
            this.Controls.Add(this.fieldPanel);
            this.Controls.Add(this.coordinatePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.coordinatePanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel coordinatePanel;
        private Button button1;
        private Panel fieldPanel;
        private ListBox listBox1;
        private Button button2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem addAfterThisPointToolStripMenuItem;
    }
}