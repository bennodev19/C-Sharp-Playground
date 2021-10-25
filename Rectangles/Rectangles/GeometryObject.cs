using System;
namespace Rectangles
{

    public class GeometryObject
    {
        public bool valid = false;

        // Coordinates
        private int x = 0;
        private int y = 0;

        public GeometryObject()
        {
        }

        public GeometryObject(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool isValid()
        {
            return this.valid;
        }

        public bool move(int x, int y)
        {
            this.x = x;
            this.y = y;
            return true;
        }
    }
}
