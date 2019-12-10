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
    /// Circle class
    /// </summary>
    public class Circle : PlenkaFigures
    {
        private int radius;
        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="radius"></param>
        public Circle(int radius)
        {
            if (radius <= 0)
            {
                throw new InvalidParamException();
            }
            this.radius = radius;
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="figure"></param>
        public Circle(int radius, IGFigures figure)
        {
            if (figure.GetMaterial() != "Plenka")
            {
                throw new WrongMaterialException();
            }
            if (radius <= 0)
            {
                throw new InvalidParamException();
            }
            this.radius = radius;
            if (figure.Square < Square)
            {
                throw new CuttingException();
            }
        }

        public double Square => radius * radius * Math.PI;

        public double Perimetr => 2 * radius * Math.PI;

        /// <summary>
        /// Returns figure material
        /// </summary>
        /// <returns></returns>
        public string GetMaterial()
        {
            return "Plenka";
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
            Circle circle = obj as Circle;
            if (obj as Circle == null)
            {
                return false;
            }

            return radius == circle.radius && Square == circle.Square;
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 131 * radius + 27 * (int)Square + 200 * GetMaterial().Length;
        }

        /// <summary>
        /// Returns figure type
        /// </summary>
        /// <returns></returns>
        public string GetFigureType()
        {
            return "Circle";
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string text = "";
            text += GetFigureType() + " " + GetMaterial() + " " + radius;
            return text;
        }
    }
}
