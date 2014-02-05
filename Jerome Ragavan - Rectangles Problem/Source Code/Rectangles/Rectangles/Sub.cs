using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Rectangles
{
    public class Sub
    {
        public List<int> GetHeightsList(List<Rectangle> lstRectangles)
        {
            //this method returns a list of heights that are in the List<Rectangle>
            List<int> Heights = new List<int>();

            foreach (Rectangle r in lstRectangles)
            {
                Heights.Add(r.Height);
            }

            return Heights;
        }

        public Rectangle Merge(List<Rectangle> lstNew)
        {
            //this method checks for rectangles that have the same starting position and the same width and merges them to form one larger rectangle.
            int rectCount = 0;
            Rectangle Rect = new Rectangle(0, 0, 0, 0);
            foreach (Rectangle r in lstNew)
            {
                if (rectCount == 0)
                {
                    Rect = r;
                    rectCount++;
                }
                else
                {
                    Rect = Rectangle.Union(Rect, r);
                    rectCount++;
                }
            }

            return Rect;
        }

        public string fetchFile(string path)
        {
            string contents = "";
            //Here a file is being selected for use.

            //The streamReader will read the file and convert it to a string.
            if (path != "")
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    contents = sr.ReadToEnd();
                }
            }

            return contents;
        }
    }
}
