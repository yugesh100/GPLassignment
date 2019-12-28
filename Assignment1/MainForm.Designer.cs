namespace GPLAssignment
{
    partial class MainForm
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
            this.paintPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multilineCommandTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.paintColorButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.paintBrushSizeComboBox = new System.Windows.Forms.ComboBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.singleLineTextBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // paintPanel
            // 
            this.paintPanel.BackColor = System.Drawing.Color.White;
            this.paintPanel.Location = new System.Drawing.Point(12, 44);
            this.paintPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(587, 326);
            this.paintPanel.TabIndex = 0;
            this.paintPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseDown);
            this.paintPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseMove);
            this.paintPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(789, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.helpToolStripMenuItem.Text = "version control";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // multilineCommandTextBox
            // 
            this.multilineCommandTextBox.Location = new System.Drawing.Point(605, 64);
            this.multilineCommandTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.multilineCommandTextBox.Multiline = true;
            this.multilineCommandTextBox.Name = "multilineCommandTextBox";
            this.multilineCommandTextBox.Size = new System.Drawing.Size(172, 272);
            this.multilineCommandTextBox.TabIndex = 2;
            this.multilineCommandTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(173, 376);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(251, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(605, 340);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Executes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.multilineExecuteButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(430, 370);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Executes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 467);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(93, 467);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Location = new System.Drawing.Point(71, 430);
            this.rectangleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(108, 33);
            this.rectangleButton.TabIndex = 6;
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(195, 431);
            this.circleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(97, 33);
            this.circleButton.TabIndex = 6;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circlButton_Click);
            // 
            // paintColorButton
            // 
            this.paintColorButton.Location = new System.Drawing.Point(195, 400);
            this.paintColorButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paintColorButton.Name = "paintColorButton";
            this.paintColorButton.Size = new System.Drawing.Size(111, 26);
            this.paintColorButton.TabIndex = 6;
            this.paintColorButton.Text = "Set pen color";
            this.paintColorButton.UseVisualStyleBackColor = true;
            this.paintColorButton.Click += new System.EventHandler(this.paintColorButton_Click);
            // 
            // triangleButton
            // 
            this.triangleButton.Location = new System.Drawing.Point(312, 431);
            this.triangleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(99, 33);
            this.triangleButton.TabIndex = 6;
            this.triangleButton.Text = "Triangle";
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // paintBrushSizeComboBox
            // 
            this.paintBrushSizeComboBox.FormattingEnabled = true;
            this.paintBrushSizeComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.paintBrushSizeComboBox.Location = new System.Drawing.Point(312, 402);
            this.paintBrushSizeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paintBrushSizeComboBox.Name = "paintBrushSizeComboBox";
            this.paintBrushSizeComboBox.Size = new System.Drawing.Size(97, 24);
            this.paintBrushSizeComboBox.TabIndex = 9;
            this.paintBrushSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.paintBrushSizeComboBox_SelectedIndexChanged);
            // 
            // singleLineTextBox
            // 
            this.singleLineTextBox.AutoSize = true;
            this.singleLineTextBox.Location = new System.Drawing.Point(9, 377);
            this.singleLineTextBox.Name = "singleLineTextBox";
            this.singleLineTextBox.Size = new System.Drawing.Size(158, 17);
            this.singleLineTextBox.TabIndex = 11;
            this.singleLineTextBox.Text = "singleLineCommandBox";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(608, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "MultipleLineCommandBox";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.singleLineTextBox);
            this.Controls.Add(this.paintBrushSizeComboBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.triangleButton);
            this.Controls.Add(this.paintColorButton);
            this.Controls.Add(this.circleButton);
            this.Controls.Add(this.rectangleButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.multilineCommandTextBox);
            this.Controls.Add(this.paintPanel);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paintPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox multilineCommandTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button paintColorButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.ComboBox paintBrushSizeComboBox;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label singleLineTextBox;
        private System.Windows.Forms.Label label1;
    }
}

