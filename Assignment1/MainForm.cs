using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using GPLAssignment.shape;
using System.IO;
using System.Net.Http;

namespace GPLAssignment
{
    public partial class MainForm : Form
    {
        private ShapeFactory factory;
        private Graphics graphics;
        private int? initX = null;
        private int? initY = null;
        private int? moveX = null;
        private int? moveY = null;
        private bool startPaint = false;
        private float brushSize = 1;
        private Color brushColor = Color.Black;
        /// <summary>
        /// main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            graphics = this.paintPanel.CreateGraphics();
            paintBrushSizeComboBox.SelectedIndex = 0;
            this.brushSize = float.Parse(paintBrushSizeComboBox.SelectedItem.ToString());
            paintColorButton.BackColor = brushColor;
            factory = new ShapeFactory();
        }

        private void paintPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!startPaint) return;

            Pen p = new Pen(this.brushColor, brushSize);
            /// <summary>
            /// Drawing the line
            /// </summary>

            graphics.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
            initX = e.X;
            initY = e.Y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintPanel_MouseDown(object sender, MouseEventArgs e)///to paint mouse down
        {
            startPaint = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintPanel_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            //initX = null;
            //initY = null;
        }

        private void paintBrushSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.brushSize = float.Parse(paintBrushSizeComboBox.SelectedItem.ToString());
        }

        private void paintColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                this.brushColor = c.Color;
                paintColorButton.BackColor = c.Color;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }

        private void resetButton_Click(object sender, EventArgs e)/// to reset button from original position
        {
            
            initX = 0;
            initY = 0;
        }

        private void circlButton_Click(object sender, EventArgs e)/// to draw circle
        {
            string shape = "circle";
            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;

            Shapes circle = factory.getShape(shape);
            circle.set(brushColor, x, y, x/2);
            circle.draw(graphics);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"> parameter</param>
        /// <param name="e">  parameter</param>
        private void rectangleButton_Click(object sender, EventArgs e)  /// to draw rectangle
        {
            string  shape = "rectangle";

            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;

            Shapes rectangle = factory.getShape(shape);
            rectangle.set(brushColor, x, y, x / 2,  y/2);
            rectangle.draw(graphics);
        }

        private void triangleButton_Click(object sender, EventArgs e)/// to draw triangle
        {
            string shape = "triangle";

            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;

            Shapes Triangle = factory.getShape(shape);
            Triangle.set(brushColor, x, y, x / 2, y / 2);
            Triangle.draw(graphics);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Parameter</param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)  ///to exit the form
        {
            Application.Exit();
        }
        private void executeButton_Click(object sender, EventArgs e) /// to execute command box
        {
            string command = textBox2.Text;
            executeCommand(command);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"> to clear command</param>
        private void executeCommand(string command) // to clear the panel
        {
            if (!string.IsNullOrEmpty(command) && command.Contains("clear"))/// check the parameter 
            {
                graphics.Clear(Color.White);
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("reset"))///check the parameter
            {
                initX = 0;
                initY = 0;
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("rectangle"))/// check the parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1], strlist[2]))
                {
                    int length = Int16.Parse(strlist[1]);
                    int breadth = Int16.Parse(strlist[2]);
                    drawRectangle(length,breadth);
                }
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("circle"))///to check valid parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1]))
                {
                    int radius = Int16.Parse(strlist[1]);
                    drawCircle(radius);
                }
               
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("triangle"))/// to check valid parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1], strlist[2]))
                {
                    int side1 = Int16.Parse(strlist[1]);
                    int side2 = Int16.Parse(strlist[2]);
                    drawTriangle(side1, side2);
                }
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("moveto"))/// to  check valid parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1], strlist[2]))
                {
                    int x = Int16.Parse(strlist[1]);
                    int y = Int16.Parse(strlist[2]);
                    moveTo(x, y);
                }
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("drawto"))/// to check valid parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1], strlist[2]))
                {
                    int x = Int16.Parse(strlist[1]);
                    int y = Int16.Parse(strlist[2]);
                    drawTo(x, y);
                }

             
            }
        }

        private bool validateInput(string param1, string param2)
        {
            if (!param1.All(char.IsNumber) || !param2.All(char.IsNumber)) ///to check valid command
            {
                MessageBox.Show("Input error .please type number only ");
                return false;
            }

            return true;
        }

        private bool validateInput(string param1)
        {
            if (!param1.All(char.IsNumber))/// to check valid command
            {
                MessageBox.Show("Input error .please type number only ");
                return false;
            }

            return true;
        }

        private void drawTriangle(int side1,int side2)
        {
            string shape = "triangle";
           
            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;
           
            Shapes Triangle = factory.getShape(shape);
            Triangle.set(brushColor, x, y, side1, side2);
            Triangle.draw(graphics);
        }
        private void drawRectangle(int length,int breadth)
        {
            string shape = "rectangle";
            int x = this.paintPanel.Width / 7;
            int y = this.paintPanel.Height / 7;
            Shapes rectangle = factory.getShape(shape);
            rectangle.set(brushColor, x, y, length, breadth);
            rectangle.draw(graphics);
        }
        private void drawCircle(int radius)
        {
            string shape = "circle";
            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;

            Shapes circle = factory.getShape(shape);
            circle.set(brushColor, x, y, radius);
            circle.draw(graphics);
        }
        private void moveTo(int x, int y)
        {
            
            moveX = x;
            moveY = y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"> x coordinate</param>
        /// <param name="y">y coordinate </param>
        private void drawTo(int x, int y)
        {
            Pen p = new Pen(this.brushColor, brushSize);
            graphics.DrawLine(p, new Point(moveX ?? 0, moveY ?? 0), new Point(x, y));
            moveX = x;
            moveY = y;
        }
        private void multilineExecuteButton_Click(object sender, EventArgs e)
        {
            string commands = this.multilineCommandTextBox.Text;
            Console.WriteLine(commands);

            foreach (var command in commands.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                executeCommand(command);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader s = File.OpenText("c:\\inputcommand.txt");
                string lines = s.ReadToEnd();
                multilineCommandTextBox.Text = lines;

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error", "Cannot find limerick.txt");

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commands = this.multilineCommandTextBox.Text;    ///multiline command box
            StreamWriter fWriter = File.CreateText("C:\\inputcommand.txt");
            fWriter.WriteLine(commands);
            fWriter.Close();
        }

        private async Task label1_ClickAsync(object sender, EventArgs e)
        {
           
    }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/yugesh100/GPLassignment");
        }
    }
    }

