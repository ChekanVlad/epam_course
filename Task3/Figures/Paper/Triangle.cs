using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Paper
{
    /// <summary>
    /// Triangle class
    /// </summary>
    public class Triangle : PaperFigures
    {
        private int[] sides;
        Color colorIndex;

        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle(int a, int b, int c)
        {
            if (!IsConsist(a, b, c))
            {
                throw new Exception();
            }
            sides = new int[3] { a, b, c };
            colorIndex = 0;
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="figure"></param>
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


        /// <summary>
        /// Returns figure color
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return colorIndex;
        }

        /// <summary>
        /// Returns figure material
        /// </summary>
        /// <returns></returns>
        public string GetMaterial()
        {
            return "Paper";
        }

        /// <summary>
        /// Check if figure is already painted
        /// </summary>
        /// <returns></returns>
        public bool IsPainted()
        {
            return (colorIndex != Color.None);
        }

        /// <summary>
        /// Check if triangle is exist
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns 
        /// </summary>
        /// <returns></returns>
        private double GetHalfP()
        {
            return (double)(Perimetr) / 2;
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

        /// <summary>
        /// Chech if triangle sides are the same
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 80 * (sides[0] + sides[1] + sides[2]) + 12 * GetMaterial().Length;
        }

        /// <summary>
        /// Returns figure type
        /// </summary>
        /// <returns></returns>
        public string GetFigureType()
        {
            return "Triangle";
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string text = "";
            text += GetFigureType() + " " + GetMaterial() + " " + (int)GetColor() + " " + sides[0] + " " + sides[1] + " " + sides[2];
            return text;
        }
    }
}
