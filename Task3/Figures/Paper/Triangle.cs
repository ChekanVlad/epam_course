using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Paper
{
    public class Triangle : PaperFigures
    {
        private int[] sides;
        Color colorIndex;

        public Triangle(int a, int b, int c)
        {
            if (!IsConsist(a, b, c))
            {
                throw new Exception();
            }
            sides = new int[3] { a, b, c };
            colorIndex = 0;
        }

        public Triangle(int a, int b, int c, IGFigures figure)
        {
            if (figure.GetMaterial() != "Paper")
            {
                throw new Exception();
            }
            if (!IsConsist(a, b, c))
            {
                throw new Exception();
            }
            sides = new int[3] { a, b, c };
            if (figure.Square < Square)
            {
                throw new Exception();
            }
            colorIndex = ((PaperFigures)figure).GetColor();
        }

        public double Square
        {
            get { return Math.Sqrt(GetHalfP() * (GetHalfP() - sides[0]) * (GetHalfP() - sides[1]) * (GetHalfP() - sides[2])); }
        }

        public double Perimetr => sides[0] + sides[1] + sides[2];

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

        private static bool IsConsist(int a, int b, int c)
        {
            if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double GetHalfP()
        {
            return (double)(sides[0] + sides[1] + sides[2]) / 2;
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
            Triangle triangle = obj as Triangle;
            if (triangle == null)
            {
                return false;
            }

            return IsSameSides(sides, triangle.sides) && colorIndex == triangle.colorIndex && Square == triangle.Square;
        }

        public override int GetHashCode()
        {
            return 80 * (sides[0] + sides[1] + sides[2]) + 12 * GetMaterial().Length;
        }

        public string GetFigureType()
        {
            return "Triangle";
        }

        public override string ToString()
        {
            string text = "";
            text += GetFigureType() + " " + GetMaterial() + " " + (int)GetColor() + " " + sides[0] + " " + sides[1] + " " + sides[2];
            return text;
        }
    }
}
