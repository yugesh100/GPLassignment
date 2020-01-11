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
        /// <summary>
        /// 
        ///combobox paint brush </summary>
        /// <param name="sender"> parameter</param>
        /// <param name="e"> events argument</param>
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
        /// <summary>
        /// clean button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }
        /// <summary>
        /// Reset to initial position where x=0 and y =0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            circle.set(brushColor, x, y, x / 2);
            circle.draw(graphics);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"> parameter</param>
        /// <param name="e">  parameter</param>
        private void rectangleButton_Click(object sender, EventArgs e)  /// to draw rectangle
        {
            string shape = "rectangle";

            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;

            Shapes rectangle = factory.getShape(shape);
            rectangle.set(brushColor, x, y, x / 2, y / 2);
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
            if (!string.IsNullOrEmpty(command) && command.Contains("CLEAR"))/// check the parameter 
            {
                graphics.Clear(Color.White);
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("RESET"))///check the parameter
            {
                initX = 0;
                initY = 0;
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("RECTANGLE"))/// check the parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1], strlist[2]))
                {
                    int length = Int16.Parse(strlist[1]);
                    int breadth = Int16.Parse(strlist[2]);
                    drawRectangle(length, breadth);
                }
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("CIRCLE"))///to check valid parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1]))
                {
                    int radius = Int16.Parse(strlist[1]);
                    drawCircle(radius);
                }

            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("TRIANGLE"))/// to check valid parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1], strlist[2]))
                {
                    int side1 = Int16.Parse(strlist[1]);
                    int side2 = Int16.Parse(strlist[2]);
                    drawTriangle(side1, side2);
                }
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("MOVETO"))/// to  check valid parameter
            {
                string[] strlist = command.Split(' ');
                if (validateInput(strlist[1], strlist[2]))
                {
                    int x = Int16.Parse(strlist[1]);
                    int y = Int16.Parse(strlist[2]);
                    moveTo(x, y);
                }
            }
            else if (!string.IsNullOrEmpty(command) && command.Contains("DRAWTO"))/// to check valid parameter
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

        private void drawTriangle(int side1, int side2)
        {
            string shape = "triangle";

            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;

            Shapes Triangle = factory.getShape(shape);
            Triangle.set(brushColor, moveX ?? x, moveY ?? y, side1, side2);
            Triangle.draw(graphics);
        }
        private void drawRectangle(int length, int breadth)
        {
            string shape = "rectangle";
            int x = this.paintPanel.Width / 7;
            int y = this.paintPanel.Height / 7;
            Shapes rectangle = factory.getShape(shape);
            rectangle.set(brushColor, moveX ?? x, moveY ?? y, length, breadth);
            rectangle.draw(graphics);
        }
        private void drawCircle(int radius)
        {
            string shape = "circle";
            int x = this.paintPanel.Width / 4;
            int y = this.paintPanel.Height / 4;

            Shapes circle = factory.getShape(shape);
            circle.set(brushColor, moveX ?? x, moveY ?? y, radius);
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
            string multipleCommands = this.multilineCommandTextBox.Text;

            Dictionary<string, int> variabes = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> executions = new Dictionary<string, HashSet<string>>();
            foreach (var commands in multipleCommands.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {

                bool isExecutionPending = false;
                bool isVeriableDeclrationPending = false;
                string lastExecutionCommand = null;
                foreach (var command in commands.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {

                    if (isVeriableDeclrationPending)
                    {
                        try
                        {
                            Console.WriteLine(command);
                            int value = Int16.Parse(command);
                            Console.WriteLine(value);
                            if (variabes.ContainsKey(lastExecutionCommand)) variabes[lastExecutionCommand] = value;
                            else variabes.Add(lastExecutionCommand, value);
                            isVeriableDeclrationPending = false;
                        }
                        catch (Exception ignore)
                        {
                            MessageBox.Show("Input error.");
                            variabes.Add(lastExecutionCommand, 0);
                            isVeriableDeclrationPending = false;
                        }
                    }
                    else if (isSpecialChar(command))
                    {

                    }
                    else if (isExecutableChar(command))
                    {
                        isExecutionPending = true;
                        if (executions.ContainsKey(command)) executions[command] = new HashSet<string>();
                        else executions.Add(command, new HashSet<string>());
                        lastExecutionCommand = command;
                    }
                    else if (command == "=")
                    {
                        isVeriableDeclrationPending = true;
                    }
                    else
                    {
                        if (null != lastExecutionCommand && isExecutionPending)
                        {
                            if (!executions.ContainsKey(lastExecutionCommand)) executions.Add(lastExecutionCommand, new HashSet<string>());
                            executions[lastExecutionCommand].Add(command);
                        }
                        else lastExecutionCommand = command;
                    }


                }

                foreach (var command in executions.Keys)
                {
                    HashSet<string> values = executions[command];
                    if("CIRCLE" == command)
                    {
                        if(values == null || values.Count == 0 || values.First() == null)
                        {
                            MessageBox.Show("Input error. Could not draw circle");
                        }
                        else
                        {
                            int radius = 0;
                            if (variabes.ContainsKey(values.First()))
                            {
                                radius = variabes[values.First()];
                            }
                            else
                            {
                                try
                                {
                                    radius = Int16.Parse(values.First());
                                }
                                catch (Exception ignore) { }
                            }
                            drawCircle(radius);
                        }
                    }else if("RECTANGLE" == command)
                    {
                        if (values == null || values.Count < 2 || values.First() == null || values.Last() == null)
                        {
                            MessageBox.Show("Input error. Could not draw rectangle");
                        }
                        else
                        {
                            int width = 0;
                            int height = 0;

                            if (variabes.ContainsKey(values.First()) && variabes.ContainsKey(values.Last()))
                            {
                                width = variabes[values.First()];
                                height = variabes[values.Last()];
                            }
                            else
                            {
                                try
                                {
                                    width = Int16.Parse(values.First());
                                    height = Int16.Parse(values.Last());
                                }
                                catch (Exception ignore) { }
                            }

                            drawRectangle(width, height);
                        }
                    }
                    else if ("TRIANGLE" == command)
                    {
                        if (values == null || values.Count < 2 || values.First() == null || values.Last() == null)
                        {
                            MessageBox.Show("Input error. Could not draw rectangle");
                        }
                        else
                        {
                            int width = 0;
                            int height = 0;

                            if (variabes.ContainsKey(values.First()) && variabes.ContainsKey(values.Last()))
                            {
                                width = variabes[values.First()];
                                height = variabes[values.Last()];
                            }
                            else
                            {
                                try
                                {
                                    width = Int16.Parse(values.First());
                                    height = Int16.Parse(values.Last());
                                }
                                catch (Exception ignore) { }
                            }

                            drawTriangle(width, height);
                        }
                    }
                    else if ("MOVETO" == command)
                    {
                        if (values == null || values.Count < 2 || values.First() == null || values.Last() == null)
                        {
                            MessageBox.Show("Input error. Could not draw rectangle");
                        }
                        else
                        {
                            int width = 0;
                            int height = 0;

                            if (variabes.ContainsKey(values.First()) && variabes.ContainsKey(values.Last()))
                            {
                                width = variabes[values.First()];
                                height = variabes[values.Last()];
                            }
                            else
                            {
                                try
                                {
                                    width = Int16.Parse(values.First());
                                    height = Int16.Parse(values.Last());
                                }
                                catch (Exception ignore) { }
                            }

                            moveTo(width, height);
                        }
                    }
                    else if ("DRAWTO" == command)
                    {
                        if (values == null || values.Count < 2 || values.First() == null || values.Last() == null)
                        {
                            MessageBox.Show("Input error. Could not draw rectangle");
                        }
                        else
                        {
                            int width = 0;
                            int height = 0;

                            if (variabes.ContainsKey(values.First()) && variabes.ContainsKey(values.Last()))
                            {
                                width = variabes[values.First()];
                                height = variabes[values.Last()];
                            }
                            else
                            {
                                try
                                {
                                    width = Int16.Parse(values.First());
                                    height = Int16.Parse(values.Last());
                                }
                                catch (Exception ignore) { }
                            }

                            drawTo(width, height);
                        }
                    }else
                    {
                        executeCommand(command);
                    }

                }

                // executeCommand(command);

            }
        }

        private HashSet<string> specialChars = new HashSet<string> { "IF", "LOOP", "ENDIF", "ENDLOOP" };
        private HashSet<string> executableChar = new HashSet<string>
        {
            "CIRCLE", "TRIANGLE", "RECTANGLE", "DRAWTO",  "MOVETO", "CLEAR", "RESET"
        };

        private bool isSpecialChar(string command)
        {
            return specialChars.Contains(command);
        }

        private bool isExecutableChar(string command)
        {
            Console.WriteLine(command);
            return executableChar.Contains(command);
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
                OpenFileDialog sfd = new OpenFileDialog();
                sfd.InitialDirectory = @"C:\";
                sfd.RestoreDirectory = true;
                sfd.FileName = "*.txt";
                sfd.DefaultExt = "txt";
                sfd.Filter = "txt files (*.txt)| *.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = sfd.OpenFile();
                    StreamReader sw = new StreamReader(fileStream);
                    string lines = sw.ReadToEnd();
                    multilineCommandTextBox.Text = lines;
                    sw.Close();
                    fileStream.Close();

                }


            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error", "Cannot find text file");

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commands = this.multilineCommandTextBox.Text;    ///multiline command box

            //StreamWriter fWriter = File.CreateText("C:\\inputcommand.txt");
            //fWriter.WriteLine(commands);
            // fWriter.Close();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.FileName = "*.txt";
            sfd.DefaultExt = "txt";
            sfd.Filter = "txt files (*.txt)| *.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);
                sw.Write(multilineCommandTextBox.Text);
                sw.Close();
                fileStream.Close();
                multilineCommandTextBox.Clear();
            }
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

