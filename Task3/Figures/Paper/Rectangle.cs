using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Paper
{
    public class Rectangle : PaperFigures
    {
        private int[] sides;
        Color colorIndex;
        public Rectangle(int a, int b)
        {
            if (a <= 0 && b <= 0)
            {
                throw new Exception();
            }
            sides = new int[2] { a, b };
            colorIndex = 0;
        }

        public Rectangle(int a, int b, IGFigures figure)
        {
            if (figure.GetMaterial() != "Paper")
            {
                throw new Exception();
            }
            if (a <= 0 && b <= 0)
            {
                throw new Exception();
            }
            sides = new int[2] { a, b };
            Array.Sort(sides);
            if (figure.Square < Square)
            {
                throw new Exception();
            }
            colorIndex = ((PaperFigures)figure).GetColor();
        }

        public double Square => sides[0] * sides[1];

        public double Perimetr => 2 * (sides[0] + sides[1]);

        //public string Material => "Paper";

        public Color GetColor()
        {
            return colorIndex;
        }

        public string GetMaterial()
        {
            return "Paper";
        }

        public bool IsPainted()
        {
            return (colorIndex != Color.None);
        }

        public void Paint(Color color)
        {
            if (IsPainted())
            {
                colorIndex = color;
            }
            else
            {
                throw new Exception();
            }
        }

        private static bool IsSameSides(int[] arr1, int[] arr2)
        {
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

            return IsSameSides(sides, rect.sides) && colorIndex == rect.colorIndex && Square == rect.Square;
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
            text += GetFigureType() + " " + GetMaterial() + " " + (int)GetColor() + " " + sides[0] + " " + sides[1];
            return text;
        }
    }

}
