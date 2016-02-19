using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Bridge decouples an abstraction from its implementation so that the two can vary independently.
 */
namespace Pattern.Structural.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = new IShape[]{
                new CircleShape(1,2,3, new DrawingApi1()),
                new CircleShape(5,7,11, new DrawingApi2())
            };
            foreach (var s in shapes)
            {
                s.ResizeByPercentage(2.5);
                s.Draw();
            }

            Console.ReadLine();
        }
    }

    interface IDrawingApi
    {
        void DrawCircle(double x, double y, double radius);
    }

    class DrawingApi1 : IDrawingApi
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine("API1.circle at {0:0.000000}:{1:0.000000} radius {2:0.000000}", x, y, radius);
        }
    }

    class DrawingApi2 : IDrawingApi
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine("API2.circle at {0:0.000000}:{1:0.000000} radius {2:0.000000}", x, y, radius);
        }
    }

    interface IShape
    {
        void Draw();
        void ResizeByPercentage(double p);
    }

    class CircleShape : IShape
    {
        private double x, y, radius;
        private IDrawingApi drawingApi;
        public CircleShape(double x, double y, double radius, IDrawingApi drawingApi)
        {
            this.x = x; this.y = y; this.radius = radius;
            this.drawingApi = drawingApi;
        }

        public void Draw()
        {
            drawingApi.DrawCircle(x, y, radius);
        }

        public void ResizeByPercentage(double p)
        {
            radius *= p;
        }
    }
}
