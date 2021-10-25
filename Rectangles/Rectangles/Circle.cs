using System;
namespace Rectangles
{
    public class Circle : GeometryObject
    {
        // Dimensions
        private double _radius;
        // https://stackoverflow.com/questions/6709072/c-getter-setter
        public double radius
        {
            get { return _radius; }
            set
            {
                _radius = this.formatRadius(value);
                this.validate();
            }
        }

        public Circle()
        {
            this.radius = 10;
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        // 'base' https://stackoverflow.com/questions/15251167/how-to-extend-a-class-in-c
        public Circle(double radius, int x, int y) : base(x, y)
        {
            this.radius = radius;
        }

        public double getArea()
        {
            return Math.Round(this.radius * this.radius * Math.PI, 2);
        }

        public double getScope()
        {
            return Math.Round(this.radius * 2 * Math.PI, 2);
        }

        private double formatRadius(double value)
        {
            if (value > 0)
                return value;
            else
                return -1;
        }

        private bool validate()
        {
            bool valid = this.radius != -1;
            this.valid = valid;
            return valid;
        }
    }
}
