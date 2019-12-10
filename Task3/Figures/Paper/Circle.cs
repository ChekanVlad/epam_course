using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures.Paper
{
    /// <summary>
    /// Circle Class
    /// </summary>
    public class Circle : PaperFigures
    {
        private int radius;
        Color colorIndex;

        /// <summary>
        /// Constructor for creating
        /// </summary>
        /// <param name="radius"></param>
        public Circle(int radius)
        {
            if (radius <= 0)
            {
                throw new InvalidParamException();//неверные парамерты
            }
            this.radius = radius;
            colorIndex = 0;
        }

        /// <summary>
        /// Constructor for cutting
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="figure"></param>
        public Circle(int radius, IGFigures figure)
        {
            if (figure.GetMaterial() != "Paper")
            {
                throw new WrongMaterialException();//не совпадает материал
            }
            if (radius <= 0)
            {
                throw new InvalidParamException();//неверные параметры
            }
            this.radius = radius;
            if (figure.Square < Square)
            {
                throw new CuttingException();//невозможно вырезать
            }
            colorIndex = ((PaperFigures)figure).GetColor();
        }

        public double Square => radius * radius * Math.PI;

        public double Perimetr => 2 * radius * Math.PI;

        //public string Material => "Paper";

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
            return (GetColor() != Color.None);
        }

        /// <summary>
        /// Paint figure to concrect color
        /// </summary>
        /// <param name="color"></param>
        public void Paint(Color color)
        {
            if (!IsPainted())
            {
                colorIndex = color;
            }
            else
            {
                throw new PaintException();//Уже покрашено
            }
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
            if (circle == null)
            {
                return false;
            }

            return radius == circle.radius && colorIndex == circle.colorIndex && Square == circle.Square;
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
            text += GetFigureType() + " " + GetMaterial() + " " + (int)GetColor() + " " + radius;
            return text;
        }
    }

}
