using System;
using Box;
using FiguresFactoryMethod;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileWorker;
using Figures.Paper;
//using static ExceptionsLib.Exceptions;

namespace UnitTests
{
    /// <summary>
    /// Other Tests
    /// </summary>
    [TestClass]
    public class OtherTests
    {
        FiguresFactory factory = new FiguresFactory();
        string filePathTxt = "..\\..\\..\\files\\text.txt";
        string filePathXml = "..\\..\\..\\files\\text.xml";
        string filePathTxt2 = "..\\..\\..\\files\\text2.txt";
        string filePathXml2 = "..\\..\\..\\files\\text2.xml";
        string readTestTxt = "..\\..\\..\\files\\readtest.txt";
        string readTestXml = "..\\..\\..\\files\\readtest.xml";

        /// <summary>
        /// Test for *.txt reading
        /// </summary>
        [TestMethod]
        public void ReadTestTxt()
        {
            FigureBox box = new FigureBox();
            box.ReadFromFile(readTestTxt);
            IGFigures figure = factory.CutFigureFromPlenka("Circle", 4);
            Assert.IsTrue(figure.Equals(box.Get(1)));
        }

        /// <summary>
        /// test for *.xml reading
        /// </summary>
        [TestMethod]
        public void ReadTestXml()
        {
            FigureBox box = new FigureBox();
            box.ReadFromFile(readTestXml);
            IGFigures figure = factory.CutFigureFromPlenka("Circle", 4);
            Assert.IsTrue(figure.Equals(box.Get(1)));
        }

        /// <summary>
        /// test for correct writing to *.txt 
        /// writing only paper figures
        /// </summary>
        [TestMethod]
        public void WriteAndReadTxtTest()
        {
            FigureBox box = new FigureBox();
            box.ReadFromFile(filePathTxt);
            box.WriteToFile(2, filePathTxt2);

            FigureBox box2 = new FigureBox();
            box2.ReadFromFile(filePathTxt2);
            for (int i = 0; i < box2.GetCount(); i++)
            {
                Assert.IsTrue(box2.Get(i + 1).GetMaterial() == "Paper");
            }
        }

        /// <summary>
        /// test for correct writing to *.xml
        /// writing only plenka figures
        /// </summary>
        [TestMethod]
        public void WriteAndReadTmlTest()
        {
            FigureBox box = new FigureBox();
            box.ReadFromFile(filePathXml);
            box.WriteToFile(3, filePathXml2);

            FigureBox box2 = new FigureBox();
            box2.ReadFromFile(filePathXml2);
            for (int i = 0; i < box2.GetCount(); i++)
            {
                Assert.IsTrue(box2.Get(i + 1).GetMaterial() == "Plenka");
            }
        }

        /// <summary>
        /// test for add and extract figure into box
        /// check if figure is really extracted
        /// </summary>
        [TestMethod]
        public void AddAndExtractTest()
        {
            FigureBox box = new FigureBox();
            IGFigures figure = factory.CutFigureFromPlenka("Circle", 8);
            box.ReadFromFile(filePathTxt);
            box.Add(factory.CutFigureFromPlenka("Triangle", 12, 13, 15));
            box.Add(figure);
            box.Add(factory.CutFigureFromPlenka("Rectangle", 9, 5));
            box.Extract(box.GetCount() - 1);
            for (int i = 0; i < box.GetCount(); i++)
            {
                Assert.IsFalse(figure.Equals(box.Get(i + 1)));
            }
        }

        /// <summary>
        /// test for add and extract figure into box
        /// check if figure is really extracted
        /// </summary>
        [TestMethod]
        public void ReplaceAndFindTest()
        {
            FigureBox box = new FigureBox();
            bool find;
            IGFigures figure = factory.CutFigureFromPaper("Triangle", 8, 10, 12);
            box.ReadFromFile(filePathTxt);
            box.Add(factory.CutFigureFromPlenka("Triangle", 12, 13, 15));
            box.Add(factory.CutFigureFromPlenka("Circle", 8));
            box.Add(factory.CutFigureFromPlenka("Rectangle", 9, 5));
            box.Replace(box.GetCount() - 1, figure);
            find = box.FindFigure(figure) != -1;
            Assert.IsTrue(find);
        }

        /// <summary>
        /// test for square and perimetr sum
        /// 
        /// </summary>
        [TestMethod]
        public void SumTest()
        {
            double perimetrSum = 0;
            double squareSum = 0;
            FigureBox box = new FigureBox();
            box.Add(factory.CutFigureFromPaper("Circle", 1));
            box.Add(factory.CutFigureFromPaper("Rectangle", 2, 5));
            box.Add(factory.CutFigureFromPaper("Triangle", 12, 13, 15));
            box.Add(factory.CutFigureFromPlenka("Circle", 2));
            box.Add(factory.CutFigureFromPlenka("Rectangle", 10, 4));
            box.Add(factory.CutFigureFromPlenka("Triangle", 3, 4, 5));
            for (int i = 0; i < box.GetCount(); i++)
            {
                perimetrSum += box.Get(i + 1).Perimetr;
                squareSum += box.Get(i + 1).Square;
            }
            Assert.AreEqual(perimetrSum, box.PerimetrSum());
            Assert.AreEqual(squareSum, box.SquareSum());
        }

        /// <summary>
        /// test for methods GetPlenkaFigures(), GetPaperFigures(), GetCircles();
        /// </summary>
        [TestMethod]
        public void GetDifferentFiguresTest()
        {
            FigureBox box = new FigureBox();
            box.ReadFromFile(filePathTxt);
            FigureBox boxWithCircles = new FigureBox(box.GetCircles());
            FigureBox boxWithPaper = new FigureBox(box.GetPaperFigures());
            FigureBox boxWithPlenka = new FigureBox(box.GetPlenkaFigures());
            for(int i = 0; i < boxWithCircles.GetCount(); i++)
            {
                Assert.IsTrue(boxWithCircles.Get(i + 1).GetFigureType() == "Circle");
            }
            for (int i = 0; i < boxWithPaper.GetCount(); i++)
            {
                Assert.IsTrue(boxWithPaper.Get(i + 1).GetMaterial() == "Paper");
            }
            for (int i = 0; i < boxWithPlenka.GetCount(); i++)
            {
                Assert.IsTrue(boxWithPlenka.Get(i + 1).GetMaterial() == "Plenka");
            }
        }

        /// <summary>
        /// test for paint figure
        /// </summary>
        [TestMethod]
        public void PaintTest()
        {
            FigureBox box = new FigureBox();
            IGFigures figure1 = factory.CutFigureFromPaper("Circle", 6);
            IGFigures figure2 = factory.CutFigureFromPaper("Rectangle", 6, 8);
            IGFigures figure3 = factory.CutFigureFromPaper("Triangle", 6,7,8);
            ((PaperFigures)figure1).Paint(Color.Green);
            ((PaperFigures)figure2).Paint(Color.White);
            ((PaperFigures)figure3).Paint(Color.Red);
            box.Add(figure1);
            box.Add(figure2);
            box.Add(figure3);
            Assert.IsTrue(((PaperFigures)box.Get(1)).GetColor() == Color.Green);
            Assert.IsTrue(((PaperFigures)box.Get(2)).GetColor() == Color.White);
            Assert.IsTrue(((PaperFigures)box.Get(3)).GetColor() == Color.Red);
        }
}
