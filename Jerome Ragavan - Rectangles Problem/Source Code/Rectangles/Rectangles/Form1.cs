//Jerome Ragavan
//The Rotating Rectangle Problem
//11-01-2014

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rectangles
{
    public partial class Form1 : Form
    {
        #region Public Variables

        //currently using this to carry the List of Rectangles accross from one method to the next.
        public List<Rectangle> InputRectangles = new List<Rectangle>();
        public List<Rectangle> OutputRectangles = new List<Rectangle>();
        string path = "";
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Rectangles from file

        public void DrawRectanglesFromFile(string contents)
        {
            //String from file is processed here for the input rectangles.
            try
            {
                Sub sub = new Sub();
                List<Rectangle> lstRectangles = new List<Rectangle>();
                Graphics g = pnlInput.CreateGraphics();
                g.Clear(Color.White);
                contents = contents.Replace("\r", "");
                string[] rectangles = contents.Split('\n');
                foreach (string s in rectangles)
                {
                    if (s != "")
                    {
                        string[] variables = s.Split('\t');
                        string[] Width = variables[1].Split(':');
                        string[] Height = variables[2].Split(':');
                        string[] X = variables[3].Split(':');
                        string[] Y = variables[4].Split(':');

                        Rectangle rect = new Rectangle(Convert.ToInt32(X[1]), Convert.ToInt32(Y[1]), Convert.ToInt32(Width[1]), Convert.ToInt32(Height[1]));
                        lstRectangles.Add(rect);
                    }
                }


                Pen p = new Pen(Color.Black, 1);
                g.DrawRectangles(p, lstRectangles.ToArray());

                string Outputcontents = sub.fetchFile(path);
                DrawOutputRectanglesFromFile(Outputcontents);
                SaveFileAsText(lstRectangles, "Output.txt");
            }
            catch (Exception ex)
            {
                //Error handling - Most common issue would probably be that the file is in an incorrect format.
                MessageBox.Show(String.Format("An error has occured, Input rectangles failed to generate due to the following reason: {0}",ex.Message));
            }
        }

        public void DrawOutputRectanglesFromFile(string contents)
        {
            //String from file is processed here for Output rectangles.
            try
            {
                Graphics g = pnlOutput.CreateGraphics();
                g.Clear(Color.White);
                List<Rectangle> lstRectangles = new List<Rectangle>();
                contents = contents.Replace("\r", "");
                string[] rectangles = contents.Split('\n');
                foreach (string s in rectangles)
                {
                    if (s != "")
                    {
                        string[] variables = s.Split('\t');
                        string[] Width = variables[1].Split(':');
                        string[] Height = variables[2].Split(':');
                        string[] X = variables[3].Split(':');
                        string[] Y = variables[4].Split(':');

                        Rectangle rect = new Rectangle(Convert.ToInt32(X[1]), Convert.ToInt32(Y[1]), Convert.ToInt32(Width[1]), Convert.ToInt32(Height[1]));
                        lstRectangles.Add(rect);
                    }
                }

                DrawRandomRectanglesOutput(lstRectangles);
            }
            catch (Exception ex)
            {
                //Error handling - Most common issue would probably be that the file is in an incorrect format.
                MessageBox.Show(String.Format("An error has occured, Output rectangles failed to generate due to the following reason: {0}", ex.Message));
            }
        }

        #endregion

        #region Rectangles from Random

        public void DrawRandomRectanglesInput()
        {
            //thos method generates the input rectangles and writes them to a file to be accessed later.
            Sub s = new Sub();
            int numInput = Convert.ToInt32(nudInput.Value);
            int numWidth = 0;
            int numHeight = 0;
            int numX = 0;
            int numY = 0;
            Random r = new Random();
            Graphics g = pnlInput.CreateGraphics();

            g.Clear(Color.White);

            Pen p = new Pen(Color.Black, 1);

            List<Rectangle> rectangles = new List<Rectangle>();
            try
            {
                if (numInput > 0)
                {
                    for (int i = 0; i < numInput; i++)
                    {
                        if (numWidth == 0)
                        {
                            int thisHeight = r.Next(30, 100);
                            int thisWidth = r.Next(30, 100);
                            Rectangle rect = new Rectangle(10, 150, thisWidth, thisHeight);
                            numWidth = rect.Width;
                            numHeight = rect.Height;
                            numX = rect.X;
                            numY = rect.Y;
                            rectangles.Add(rect);
                        }
                        else
                        {
                            int thisHeight = r.Next(30, 100);
                            int thisWidth = r.Next(30, 100);
                            Rectangle rect = new Rectangle(numX + numWidth, numY - (thisHeight - numHeight), thisWidth, thisHeight);
                            numWidth = rect.Width;
                            numX = rect.X;
                            rectangles.Add(rect);
                        }
                    }

                    SaveFileAsText(rectangles, "Input.txt");
                    string contents = s.fetchFile(path);
                    DrawRectanglesFromFile(contents);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Random input failed due to th following reason: {0}", ex.Message));
            }
        }

        public void DrawRandomRectanglesOutput(List<Rectangle> lstRectangles)
        {
            //This method goes through each input rectangle and calculates the output to display.
            Sub s = new Sub();
            Graphics g = pnlOutput.CreateGraphics();
            List<Rectangle> lstRects = new List<Rectangle>();
            Pen p = new Pen(Color.Black, 1);
            List<int> Heights = s.GetHeightsList(lstRectangles);
            int lastMinHeight = 0;
            int rectCount = 0;

            g.Clear(Color.White);

            try
            {
                foreach (Rectangle rect in lstRectangles)
                {
                    bool assigned = false;
                    int smallest = Heights.Min();
                    int width = 0;
                    int firstX = 0;

                    if (rectCount == 0)
                    {
                        foreach (Rectangle r in lstRectangles)
                        {
                            width = width + r.Width;
                        }
                        Rectangle re = new Rectangle(10, 160 - smallest, width, smallest);
                        lstRects.Add(re);
                        rectCount++;
                    }
                    else
                    {
                        foreach (Rectangle r in lstRectangles)
                        {
                            if (r.Height >= smallest)
                            {
                                if (!assigned)
                                {
                                    firstX = r.X;
                                    assigned = true;
                                }
                                width = width + r.Width;
                            }

                            if (assigned && (r.Height < smallest))
                            {
                                assigned = false;
                                Rectangle rect1 = new Rectangle(firstX, 160 - smallest, width, smallest - lastMinHeight);
                                lstRects.Add(rect1);
                                width = 0;
                            }
                        }
                        Rectangle re = new Rectangle(firstX, 160 - smallest, width, smallest - lastMinHeight);
                        lstRects.Add(re);
                        rectCount++;
                    }
                    lastMinHeight = Heights.Min();
                    Heights.Remove(Heights.Min());
                }

                List<Rectangle> lstNew = new List<Rectangle>();
                
                foreach (Rectangle rec in lstRects)
                {
                    var x = (from l in lstRects
                            where l.X == rec.X && l.Width == rec.Width
                            select l).ToList();

                    lstNew.Add(s.Merge(x));
                }

                OutputRectangles = lstNew;
                g.DrawRectangles(p, lstNew.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Random output failed due to the following reason: {0}", ex.Message));
            }
        }

        #endregion

        #region File Handling

        public void SaveFileAsText(List<Rectangle> rectangles, string name)
        {
            try
            {
                //This method allows the user to select a location to save the parameters of the 
                //generated rectangles as a text document which can be used in the future to generate rectangles.
                StringBuilder sb = new StringBuilder();
                int count = 1;
                //for each rectangle generated, I am writing line by line so that the user reading the file can easily identify the rectangles.
                foreach (Rectangle rect in rectangles)
                {
                    sb.AppendFormat("Rectangle:{0}\tWidth:{1}\tHeight:{2}\tX:{3}\tY:{4}", count, rect.Width, rect.Height, rect.X, rect.Y);
                    sb.AppendLine("");
                    count++;
                }

                path = name;
                using (StreamWriter sw = new StreamWriter(name))
                    sw.WriteLine(sb.ToString());
                //default filepath is the debug folder within the the project
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("An error has occured, Unable to save file due to the following reason: {0}", ex.Message));
            }
        }

        #endregion

        private void btnInput_Click(object sender, EventArgs e)
        {
            //Calls to both of my methods that generate both the input and output rectangles onto the display panels.
            DrawRandomRectanglesInput();
            //DrawRandomRectanglesOutput(InputRectangles);
        }

    }
}
