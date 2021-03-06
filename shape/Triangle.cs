﻿using System.Drawing;

 namespace GPLAssignment.shape
{
    public class Triangle : Shape
    {
        int width, height;
        public Triangle() : base()
        {
            width = 100;
            height = 100;
        }
        public Triangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {

            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }

        public override void set(Color colour, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is width, list[3] is height
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];

        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(colour);
            g.FillPolygon(b, new Point[] { new Point(x,y), new Point(x-width/2, y+width), new Point(x+height, y+height) });
            g.DrawPolygon(p, new Point[] { new Point(x, y), new Point(x - width / 2, y + width), new Point(x + height, y + height) });
        }

        public override double calcArea()
        {
            return 1/2*(width * height);
        }

        public override double calcPerimeter()
        {
            return 1 * width + 2 * height;
        }
    }
}
