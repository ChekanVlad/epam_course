using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Plenka
{
    public class Circle : PlenkaFigures
    {
        private int radius;
        public Circle(int radius)
        {
            if (radius <= 0)
            {
                throw new Exception();
            }
            this.radius = radius;
        }

        public Circle(int radius, IGFigures figure)
        {
            if (figure.GetMaterial() != "Plenka")
            {
                throw new Exception();
            }
            if (radius <= 0)
            {
                throw new Exception();
            }
            this.radius = radius;
            if (figure.Square < Square)
            {
                throw new Exception();
            }
        }

        public double Square => radius * radius * Math.PI;

        public double Perimetr => 2 * radius * Math.PI;

        public string GetMaterial()
        {
            return "Plenka";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Circle circle = obj as Circle;
            if (obj as Circle == null)
            {
                return false;
            }

            return radius == circle.radius && Square == circle.Square;
        }

        public override int GetHashCode()
        {
            return 131 * radius + 27 * (int)Square + 200 * GetMaterial().Length;
        }

        public string GetFigureType()
        {
            return "Circle";
        }

        public override string ToString()
        {
            string text = "";
            text += GetFigureType() + " " + GetMaterial() + " " + radius;
            return text;
        }
    }
}
