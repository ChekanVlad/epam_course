using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures.Plenka
{
    /// <summary>
    /// Triangle class
    /// </summary>
    public class Triangle : PlenkaFigures
    {
        private int[] sides;

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
                throw new InvalidParamException();
            }
            sides = new int[3] { a, b, c };
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
            if (figure.GetMaterial() != "Plenka")
            {
                throw new WrongMaterialException();
            }
            if (!IsConsist(a, b, c))
            {
                throw new InvalidParamException();
            }
            sides = new int[3] { a, b, c };
            if (figure.Square < Square)
            {
                throw new CuttingException();
            }
        }

        public double Square
        {
            get { return Math.Sqrt(GetHalfP() * (GetHalfP() - sides[0]) * (GetHalfP() - sides[1]) * (GetHalfP() - sides[2])); }
        }

        public double Perimetr => sides[0] + sides[1] + sides[2];
        
        /// <summary>
        /// Returns figure material
        /// </summary>
        /// <returns></returns>
        public string GetMaterial()
        {
            return "Plenka";
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
        /// Return half of perimetr
        /// </summary>
        /// <returns></returns>
        private double GetHalfP()
        {
            return (double)(sides[0] + sides[1] + sides[2]) / 2;
        }

        /// <summary>
        /// Check if triangle sides are the same
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

            return IsSameSides(sides, triangle.sides) && Square == triangle.Square;
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
            text += GetFigureType() + " " + GetMaterial() + " " + sides[0] + " " + sides[1] + " " + sides[2];
            return text;
        }
    }

}
