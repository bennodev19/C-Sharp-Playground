using System;
using System.Collections.Generic;

namespace Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            // -- Test Reactangle
            Rectangle reactangle = new Rectangle(10, 10);
            Console.WriteLine("Reactangle: [a: " + reactangle.siteA + ", " +
                "b: " + reactangle.siteB + ", " +
                "area: " + reactangle.getArea() + ", " +
                "scope: " + reactangle.getScope() + "]");

            // -- Test Circle
            Circle circle = new Circle(10);
            Console.WriteLine("Circle: [radius: " + circle.radius + ", " +
               "area: " + circle.getArea() + ", " +
               "scope: " + circle.getScope() + "]");


            // -- Test Coordinates

            // Generate Geometry Objects
            int geometryObjectCount = 10;
            int[] xScope = { 0, 100 };
            int[] yScope = { 0, 100 };
            int[] widthScope = { 1, 10 };
            int[] heightScope = { 1, 10 };

            List<Rectangle> list = new List<Rectangle>();


            for (int i = 0; i < geometryObjectCount; i++)
            {
                int randomX = generateRandomInt(xScope[0], xScope[1]);
                int randomY = generateRandomInt(yScope[0], yScope[1]);
                int randomWidth = generateRandomInt(widthScope[0], widthScope[1]);
                int randomHeight = generateRandomInt(heightScope[0], heightScope[1]);

                list.Add(new Rectangle(randomWidth, randomHeight, randomX, randomY);
            }
        }

        static int generateRandomInt(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }
    }
}
