using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Paper
{
    public class Circle : PaperFigures
    {
        private int radius;
        Color colorIndex;

        public Circle(int radius)
        {
            if (radius <= 0)
            {
                throw new Exception();//неверные парамерты
            }
            this.radius = radius;
            colorIndex = 0;
        }

        public Circle(int radius, IGFigures figure)
        {
            if (figure.GetMaterial() != "Paper")
            {
                throw new Exception();//не совпадает материал
            }
            if (radius <= 0)
            {
                throw new Exception();//неверные параметры
            }
            this.radius = radius;
            if (figure.Square < Square)
            {
                throw new Exception();//невозможно вырезать
            }
            colorIndex = ((PaperFigures)figure).GetColor();
        }

        public double Square => radius * radius * Math.PI;

        public double Perimetr => 2 * radius * Math.PI;

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
            return (GetColor() != Color.None);
        }

        public void Paint(Color color)
        {
            if (IsPainted())
            {
                colorIndex = color;
            }
            else
            {
                throw new Exception();//Уже покрашено
            }
        }

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
            text += GetFigureType() + " " + GetMaterial() + " " + (int)GetColor() + " " + radius;
            return text;
        }
    }

}
