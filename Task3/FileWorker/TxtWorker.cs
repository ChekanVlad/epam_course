using FiguresFactoryMethod;
using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorker
{
    /// <summary>
    /// Work with TXT files
    /// </summary>
    public class TxtWorker
    {
        private static FiguresFactory factory = new FiguresFactory();

        /// <summary>
        /// Read from TXT files
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <returns></returns>
        public static List<IGFigures> ReadFromFile(string filePath)
        {
            List<IGFigures> figures = new List<IGFigures>();
            string strline = "";
            using (StreamReader SR = new StreamReader(filePath))
            {
                while ((strline = SR.ReadLine()) != null)
                {
                    int index;
                    string[] text = strline.Split(' ');
                    string figureType = text[0];
                    int[] values = new int[4];
                    if (text[1] == "Paper")
                    {
                        index = 3;
                        Color color = (Color)(int.Parse(text[2]));
                        for (int i = index; i < text.Length; i++)
                        {
                            values[i - index] = int.Parse(text[i]);
                        }
                        IGFigures figure = factory.CutFigureFromPaper(figureType, values);
                        ((PaperFigures)figure).Paint(color);
                        figures.Add(figure);
                    }
                    else
                    {
                        index = 2;
                        for (int i = index; i < text.Length; i++)
                        {
                            values[i - index] = int.Parse(text[i]);
                        }
                        IGFigures figure = factory.CutFigureFromPlenka(figureType, values);
                        figures.Add(figure);
                    }
                }
            }
            return figures;
        }

        /// <summary>
        /// Write to TXT file
        /// </summary>
        /// <param name="figures">Figures List</param>
        /// <param name="filePath">File Path</param>
        public static void WriteToFile(List<IGFigures> figures, string filePath)
        {
            using (StreamWriter SW = new StreamWriter(filePath))
            {
                foreach (IGFigures i in figures)
                {
                    SW.WriteLine(i.ToString());
                }
            }
        }
    }
