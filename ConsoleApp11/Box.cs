using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Box
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Breath { get; set; }


        public Box()
            : this(1, 1, 1) { }

        public Box(double length, double width, double breath)
        {
            Length = length;
            Width = width;
            Breath = breath;
        }

        public static Box operator +(Box box1, Box box2)
        {
            Box box = new Box()
            {
                Length = box1.Length + box2.Length,
                Width = box1.Width + box2.Width,
                Breath = box1.Breath + box2.Breath
            };
            return box;
        }

        public static Box operator -(Box box1, Box box2)
        {
            Box box = new Box()
            {
                Length = box1.Length - box2.Length,
                Width = box1.Width - box2.Width,
                Breath = box1.Breath - box2.Breath
            };

            return box;
        }

        public static bool operator ==(Box box1, Box box2)
        {
            if((box1.Length != box2.Length) || 
                (box1.Width != box2.Width) ||
                (box1.Breath != box2.Breath))
            {
                return false;
            }
            return true;
        }
        public static bool operator !=(Box box1, Box box2)
        {
            if ((box1.Length == box2.Length) &&
                (box1.Width == box2.Width) &&
                (box1.Breath == box2.Breath))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return String.Format("Box with height : {0} width : {1} and Breath : {2}", Length, Width, Breath);
        }

        public static explicit operator int(Box b)
        {
            return (int) (b.Length + b.Width + b.Breath)/3;
        }

        public static implicit operator Box(int i)
        {
            return new Box(i, i, i);
        }
    }
}
