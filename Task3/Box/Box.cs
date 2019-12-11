using FileWorker;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Box
{
    /// <summary>
    /// Box class
    /// </summary>
    public class FigureBox
    {
        private List<IGFigures> figures;

        /// <summary>
        /// Constructor
        /// </summary>
        public FigureBox()
        {
            figures = new List<IGFigures>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="figures"></param>
        public FigureBox(List<IGFigures> figures)
        {
            if(figures.Count > 20)
            {
                throw new NoPlaceException();//нет места
            }
            this.figures = new List<IGFigures>();
            for(int i = 0; i < figures.Count; i++)
            {
                this.figures.Add(figures[i]);
            }
        }

        /// <summary>
        /// ToString Method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < figures.Count; i++)
            {
                text += (i+1) + figures[i].ToString() + "\n";
            }
            return text;
        }

        /// <summary>
        /// Add figure into Box
        /// </summary>
        /// <param name="figure"></param>
        public void Add(IGFigures figure)
        {
            if(figures.Count == 20)
            {
                throw new NoPlaceException();//нет места
            }
            if (figures.Count == 0)
            {
                figures.Add(figure);
                return;
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (figure.GetHashCode() == figures[i].GetHashCode())
                {
                    if (figure.Equals(figures[i])) throw new ExistFigureException();//ужеесть такая фигура
                }
            }
            figures.Add(figure);
        }

        /// <summary>
        /// Get figure from Box
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IGFigures Get(int num)
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            if (num > figures.Count || num <= 0)
            {
                throw new InvalidParamException();//за пределами массива
            }
            return figures[num - 1];
        }

        /// <summary>
        /// Delete figure from Box
        /// </summary>
        /// <param name="num"></param>
        public void Extract(int num)
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            if (num > figures.Count || num <= 0)
            {
                throw new InvalidParamException();//за пределами массива
            }
            figures.RemoveAt(num - 1);
        }

        /// <summary>
        /// Replace figure
        /// </summary>
        /// <param name="num"></param>
        /// <param name="figure"></param>
        public void Replace(int num, IGFigures figure)
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            if (num > figures.Count || num <= 0)
            {
                throw new InvalidParamException();//за пределами массива
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (figure.GetHashCode() == figures[i].GetHashCode())
                {
                    if (figure.Equals(figures[i])) throw new ExistFigureException();//уже есть такая фигура
                }
            }
            figures[num - 1] = figure;
        }

        /// <summary>
        /// Get figures count in Box
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return figures.Count;
        }

        /// <summary>
        /// Find figure in Box
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public int FindFigure(IGFigures figure)
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }

            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].Equals(figure))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Calculate sum of figures square
        /// </summary>
        /// <returns></returns>
        public double SquareSum()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            double squareSum = 0;
            for (int i = 0; i < figures.Count; i++)
            {
                squareSum += figures[i].Square;
            }
            return squareSum;
        }

        /// <summary>
        /// Calculate sum of figures perimetr
        /// </summary>
        /// <returns></returns>
        public double PerimetrSum()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            double perimetrSum = 0;
            for (int i = 0; i < figures.Count; i++)
            {
                perimetrSum += figures[i].Perimetr;
            }
            return perimetrSum;
        }

        /// <summary>
        /// Get all circles from Box
        /// </summary>
        /// <returns></returns>
        public List<IGFigures> GetCircles()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            List<IGFigures> circles = new List<IGFigures>();
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].GetFigureType() == "Circle")
                {
                    circles.Add(figures[i]);
                }
            }
            return circles;
        }

        /// <summary>
        /// Get plenka figures from Box
        /// </summary>
        /// <returns></returns>
        public List<IGFigures> GetPlenkaFigures()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            List<IGFigures> fig = new List<IGFigures>();
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].GetMaterial() == "Plenka")
                {
                    fig.Add(figures[i]);
                }
            }
            return fig;
        }

        /// <summary>
        /// Get paper figures from Box
        /// </summary>
        /// <returns></returns>
        public List<IGFigures> GetPaperFigures()
        {
            if (figures.Count == 0)
            {
                throw new EmptyBoxException();//пустая коробка
            }
            List<IGFigures> fig = new List<IGFigures>();
            for (int i = 0; i < figures.Count; i++)
            {
                if (figures[i].GetMaterial() == "Paper")
                {
                    fig.Add(figures[i]);
                }
            }
            return fig;
        }

        /// <summary>
        /// Write to file
        /// </summary>
        /// <param name="m">Figures type (1 - All, 2 - Paper, 3 - Plenka)</param>
        /// <param name="filePath">File path</param>
        public void WriteToFile(int m, string filePath)
        {
            string fileFormat = filePath[filePath.Length - 3].ToString() + filePath[filePath.Length - 2].ToString() + filePath[filePath.Length - 1].ToString();
            if (fileFormat != "txt" && fileFormat != "xml")
            {
                throw new InvalidParamException();//неверные параметры
            }

            switch(m)
            {
                case 1:
                    if (fileFormat == "txt") TxtWorker.WriteToFile(figures, filePath);
                    else XmlWorker.WriteToXml(figures, filePath);
                    break;
                case 2:
                    if (fileFormat == "txt") TxtWorker.WriteToFile(GetPaperFigures(), filePath);
                    else XmlWorker.WriteToXml(GetPaperFigures(), filePath);
                    break;
                case 3:
                    if (fileFormat == "txt") TxtWorker.WriteToFile(GetPlenkaFigures(), filePath);
                    else XmlWorker.WriteToXml(GetPlenkaFigures(), filePath);
                    break;
                default:
                    throw new InvalidParamException();//неверные параметры
            }
        }
      
        /// <summary>
        /// Write to file
        /// </summary>
        /// <param name="filePath">File path</param>
        public void ReadFromFile(string filePath)
        {
            string fileFormat = filePath[filePath.Length - 3].ToString() + filePath[filePath.Length - 2].ToString() + filePath[filePath.Length - 1].ToString();
            switch (fileFormat)
            {
                case "txt":
                    figures = TxtWorker.ReadFromFile(filePath);
                    break;
                case "xml":
                    figures = XmlWorker.ReadFromXml(filePath);
                    break;
                default:
                    throw new InvalidParamException();//неверные параметры
            }
            if (figures.Count > 20)
                throw new NoPlaceException();//нет места 
        }
    }
}
   