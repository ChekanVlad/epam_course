using FiguresFactoryMethod;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FileWorker
{
    /// <summary>
    /// Work with XML files
    /// </summary>
    public class XmlWorker
    {
        private static FiguresFactory factory = new FiguresFactory();

        /// <summary>
        /// Read from XML file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        public static List<IGFigures> ReadFromXml(string filePath)
        {
            List<IGFigures> figures = new List<IGFigures>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                IGFigures figure;
                int color = 0;
                string figureType = "";
                string material = "";
                int index = 0;
                int[] values = new int[3];

                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("type");
                    if (attr != null)
                        figureType = attr.Value;
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "material")
                    {
                        material = childnode.InnerText;
                    }
                    if (childnode.Name == "color")
                    {
                        color = int.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "param")
                    {
                        values[index] = int.Parse(childnode.InnerText);
                        index++;
                    }
                }

                if (material == "Paper")
                {
                    figure = factory.CutFigureFromPaper(figureType, values);
                    ((PaperFigures)figure).Paint((Color)color);
                }
                else
                {
                    figure = factory.CutFigureFromPlenka(figureType, values);
                }
                figures.Add(figure);
            }
            return figures;
        }

        /// <summary>
        /// Write to XML file
        /// </summary>
        /// <param name="figures">Figures List</param>
        /// <param name="filePath">File Path</param>
        public static void WriteToXml(List<IGFigures> figures, string filePath)
        {
            XDocument document = new XDocument();
            XElement elements = new XElement("figures");
            foreach (IGFigures i in figures)
            {
                int index;
                XElement figure = new XElement("figure");
                XAttribute type = new XAttribute("type", i.GetFigureType());
                figure.Add(type);
                XElement material = new XElement("material", i.GetMaterial());
                figure.Add(material);
                if (i.GetMaterial() == "Paper")
                {
                    XElement color = new XElement("color", (int)((PaperFigures)i).GetColor());
                    figure.Add(color);
                    index = 3;
                }
                else
                {
                    index = 2;
                }
                string[] text = i.ToString().Split(' ');
                int[] values = new int[3];
                for (int j = index; j < text.Length; j++)
                {
                    figure.Add(new XElement("param", int.Parse(text[j])));
                }
                elements.Add(figure);
            }
            document.Add(elements);
            document.Save(filePath);
        }
    }

}
