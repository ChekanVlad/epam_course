using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Paper
{
    /// <summary>
    /// Rectangle class
    /// </summary>
    public class Rectangle : PaperFigures
    {
        private int[] sides;
        Color colorIndex;
        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Rectangle(int a, int b)
        {
            if (a <= 0 && b <= 0)
            {
                throw new Exception();
            }
            sides = new int[2] { a, b };
            colorIndex = 0;
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="figure"></param>
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
        /// Paint figure to concrect color
        /// </summary>
        /// <param name="color"></param>
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
        /// Check if rect sides are the same
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
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
            Rectangle rect = obj as Rectangle;
            if (rect == null)
            {
                return false;
            }

            return IsSameSides(sides, rect.sides) && colorIndex == rect.colorIndex && Square == rect.Square;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 99 * (sides[0] + sides[1]) + 8 * GetMaterial().Length;
        }

        /// <summary>
        /// Return figure type
        /// </summary>
        /// <returns></returns>
        public string GetFigureType()
        {
            return "Rectangle";
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string text = "";
            text += GetFigureType() + " " + GetMaterial() + " " + (int)GetColor() + " " + sides[0] + " " + sides[1];
            return text;
        }
    }

}
