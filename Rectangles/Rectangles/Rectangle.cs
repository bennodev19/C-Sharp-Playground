using System;
namespace Rectangles
{
    public class Rectangle : GeometryObject
    {
        // Dimensions
        private double _siteA;
        // https://stackoverflow.com/questions/6709072/c-getter-setter
        public double siteA
        {
            get { return _siteA; }
            set
            {
                _siteA = this.formatSite(value);
                this.validate();
            }
        }
        private double _siteB;
        // https://stackoverflow.com/questions/6709072/c-getter-setter
        public double siteB
        {
            get { return _siteB; }
            set
            {
                _siteB = this.formatSite(value);
                this.validate();
            }
        }

        public Rectangle()
        {
            this.siteA = 10;
            this.siteB = 10;
        }

        public Rectangle(double siteA, double siteB)
        {
            this.siteA = siteA;
            this.siteB = siteB;
        }

        // 'base' https://stackoverflow.com/questions/15251167/how-to-extend-a-class-in-c
        public Rectangle(double siteA, double siteB, int x, int y) : base(x, y)
        {
            this.siteA = siteA;
            this.siteB = siteB;
        }

        public bool setSite(string siteType, double siteLength)
        {
            switch (siteType)
            {
                case "A":
                case "a":
                    this.siteA = siteLength;
                    return true;
                    // break; Not neccessary due to 'return'

                case "B":
                case "b":
                    this.siteB = siteLength;
                    return true;
                    // break; Not neccessary due to 'return'
                default:
                    return false;
            }
        }

        public double getArea()
        {
            return Math.Round(this.siteA * this.siteB, 2);
        }

        public double getScope()
        {
            return Math.Round(this.siteA * 2 + this.siteB * 2, 2);
        }

        // 0 -- 1
        // |    |
        // 2 -- 3
        public int[] getCornerCoordinates()
        {
            // https://stackoverflow.com/questions/306316/determine-if-two-rectangles-overlap-each-other
            int[] cornerCoordinates = { this.x, this.y, 0, 0 };
            return cornerCoordinates;
        }

        private double formatSite(double value)
        {
            if (value > 0)
                return value;
            else 
                return -1;
        }

        private bool validate()
        {
            bool valid = this.siteA != -1 && this.siteB != -1;
            this.valid = valid;
            return valid;
        }
    }
}
