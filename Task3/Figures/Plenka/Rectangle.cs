using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Plenka
{
    public class Rectangle : PlenkaFigures
    {
        private int[] sides;

        public Rectangle(int a, int b)
        {
            if (a <= 0 && b <= 0)
            {
                throw new Exception();
            }
            sides = new int[2] { a, b };
        }

        public Rectangle(int a, int b, IGFigures figure)
        {
            if (figure.GetMaterial() != "Plenka")
            {
                throw new Exception();
            }
            if (a <= 0 && b <= 0)
            {
                throw new Exception();
            }
            sides = new int[2] { a, b };
            if (figure.Square < Square)
            {
                throw new Exception();
            }
        }

        public double Square => sides[0] * sides[1];

        public double Perimetr => 2 * (sides[0] + sides[1]);
        //public string Material => "Paper";

        public string GetMaterial()
        {
            return "Plenka";
        }

        private static bool IsSameSides(int[] arr1, int[] arr2)
        {
            Array.Sort(arr1);
            Array.Sort(arr2);
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Rectangle rect = obj as Rectangle;
            if (rect == null)
            {
                return false;
            }

            return IsSameSides(sides, rect.sides) && Square == rect.Square;
        }

        public override int GetHashCode()
        {
            return 99 * (sides[0] + sides[1]) + 8 * GetMaterial().Length;
        }

        public string GetFigureType()
        {
            return "Rectangle";
        }

        public override string ToString()
        {
            string text = "";
            text += GetFigureType() + " " + GetMaterial() + " " + sides[0] + " " + sides[1];
            return text;
        }
    }

}
