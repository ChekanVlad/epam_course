using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle1 = Figures.Paper.Circle;
using Circle2 = Figures.Plenka.Circle;
using Rectangle1 = Figures.Paper.Rectangle;
using Rectangle2 = Figures.Plenka.Rectangle;
using Triangle1 = Figures.Paper.Triangle;
using Triangle2 = Figures.Plenka.Triangle;

namespace FiguresFactoryMethod
{
    /// <summary>
    /// Factory method for geometrical figures
    /// </summary>
    public class FiguresFactory
    {
        /// <summary>
        /// Returns figure from paper
        /// </summary>
        /// <param name="figure">Created figure</param>
        /// <param name="values">Values</param>
        /// <returns></returns>
        public IGFigures CutFigureFromPaper(string figure, params int[] values)
        {
            IGFigures createdFigure = null;
            switch (figure)
            {
                case "Circle":
                    createdFigure = new Circle1(values[0]);
                    break;
                case "Rectangle":
                    createdFigure = new Rectangle1(values[0], values[1]);
                    break;
                case "Triangle":
                    createdFigure = new Triangle1(values[0], values[1], values[2]);
                    break;
                default:
                    throw new Exception();//неверные параметры
            }
            return createdFigure;
        }

        /// <summary>
        /// Returns figure from plenka
        /// </summary>
        /// <param name="figure">Created figure</param>
        /// <param name="values">Values</param>
        /// <returns></returns>
        public IGFigures CutFigureFromPlenka(string figure, params int[] values)
        {

            IGFigures createdFigure = null;
            switch (figure)
            {
                case "Circle":
                    createdFigure = new Circle2(values[0]);
                    break;
                case "Rectangle":
                    createdFigure = new Rectangle2(values[0], values[1]);
                    break;
                case "Triangle":
                    createdFigure = new Triangle2(values[0], values[1], values[2]);
                    break;
                default:
                    throw new Exception();//неверные параметры
            }
            return createdFigure;
        }

        /// <summary>
        /// Returns figure, cutted from another figure
        /// </summary>
        /// <param name="sourceFigure">Source figure</param>
        /// <param name="cuttingFigure">Cutted figure</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public IGFigures CutFromFigure(IGFigures sourceFigure, string cuttingFigure, params int[] values)
        {
            IGFigures createdFigure = null;
            switch (cuttingFigure)
            {
                case "Circle":
                    if (sourceFigure.GetMaterial() == "Paper") createdFigure = new Circle1(values[0], sourceFigure);
                    else createdFigure = new Circle2(values[0], sourceFigure);
                    break;
                case "Rectangle":
                    if (sourceFigure.GetMaterial() == "Paper") createdFigure = new Rectangle1(values[0], values[1], sourceFigure);
                    else createdFigure = new Rectangle2(values[0], values[1], sourceFigure);
                    break;
                case "Triangle":
                    if (sourceFigure.GetMaterial() == "Paper") createdFigure = new Triangle1(values[0], values[1], values[2], sourceFigure);
                    else createdFigure = new Triangle2(values[0], values[1], values[2], sourceFigure);
                    break;
                default:
                    throw new Exception();//неверные параметры
            }
            return createdFigure;
        }

    }
}
