using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Plenka
{
    public class Triangle : PlenkaFigures
    {
        private int[] sides;

        public Triangle(int a, int b, int c)
        {
            if (!IsConsist(a, b, c))
            {
                throw new Exception();
            }
            sides = new int[3] { a, b, c };
        }

        public Triangle(int a, int b, int c, IGFigures figure)
        {
            if (figure.GetMaterial() != "Plenka")
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
        }

        public double Square
        {
            get { return Math.Sqrt(GetHalfP() * (GetHalfP() - sides[0]) * (GetHalfP() - sides[1]) * (GetHalfP() - sides[2])); }
        }

        public double Perimetr => sides[0] + sides[1] + sides[2];
        //public string Material => "Paper";

        public string GetMaterial()
        {
            return "Plenka";
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

            return IsSameSides(sides, triangle.sides) && Square == triangle.Square;
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
            text += GetFigureType() + " " + GetMaterial() + " " + sides[0] + " " + sides[1] + " " + sides[2];
            return text;
        }
    }

}
