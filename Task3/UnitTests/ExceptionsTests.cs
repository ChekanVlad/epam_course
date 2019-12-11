using System;
using Box;
using FiguresFactoryMethod;
using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ExceptionsLib.Exceptions;

namespace UnitTests
{
    /// <summary>
    /// Exceptions Tests
    /// </summary>
    [TestClass]
    public class ExceptionsTests
    {
        FiguresFactory factory = new FiguresFactory();
        /// <summary>
        /// throw if you set invalid params in constructor or other methods
        /// </summary>
        [TestMethod]
        public void InvalidParamExceptionTest1()
        {
            void testFunction()
            {
                IGFigures figure = factory.CutFigureFromPaper("Circle", -2);
            }
            Assert.ThrowsException<InvalidParamException>(testFunction);
        }

        /// <summary>
        /// throw if figures have different materials
        /// </summary>
        [TestMethod]
        public void InvalidParamExceptionTest2()
        {
            void testFunction()
            {
                IGFigures figure1 = factory.CutFigureFromPaper("Circle", 3);
                IGFigures figure2 = factory.CutFromFigure(figure1, "Rectangle", -2, 3);
            }
            Assert.ThrowsException<InvalidParamException>(testFunction);
        }

        /// <summary>
        /// throw if cutting is impossible
        /// </summary>
        [TestMethod]
        public void CuttingExceptionTest()
        {
            void testFunction()
            {
                IGFigures figure1 = factory.CutFigureFromPaper("Circle", 3);
                IGFigures figure2 = factory.CutFromFigure(figure1, "Rectangle", 11, 3);
            }
            Assert.ThrowsException<CuttingException>(testFunction);
        }

        /// <summary>
        /// throw if figure is already painted
        /// </summary>
        [TestMethod]
        public void PaintExceptionTest()
        {
            void testFunction()
            {
                IGFigures figure1 = factory.CutFigureFromPaper("Circle", 3);
                ((PaperFigures)figure1).Paint(Color.Black);
                ((PaperFigures)figure1).Paint(Color.Green);
            }
            Assert.ThrowsException<PaintException>(testFunction);
        }

        /// <summary>
        /// throw if box is full and there is no place for figure
        /// </summary>
        [TestMethod]
        public void NoPlaceExceptionTest()
        {
            void testFunction()
            {
                FigureBox box = new FigureBox();
                for(int i = 1; i <= 21; i++)
                {
                    box.Add(factory.CutFigureFromPlenka("Circle", i + 1));                  
                }
            }
            Assert.ThrowsException<NoPlaceException>(testFunction);
        }

        /// <summary>
        /// throw if you try to do something with empty box (like FindFigure, Replace etc.)
        /// </summary>
        [TestMethod]
        public void EmptyBoxExceptionTest()
        {
            void testFunction()
            {
                FigureBox box = new FigureBox();
                IGFigures figure = factory.CutFigureFromPlenka("Triangle", 3, 4, 5);
                box.Replace(2, figure);
            }
            Assert.ThrowsException<EmptyBoxException>(testFunction);
        }

        /// <summary>
        /// throw if figure is already in the box
        /// </summary>
        [TestMethod]
        public void ExistFigureExceptionTest()
        {
            void testFunction()
            {
                FigureBox box = new FigureBox();
                box.Add(factory.CutFigureFromPaper("Rectangle", 2, 3));
                box.Add(factory.CutFigureFromPaper("Rectangle", 2, 3));
            }
            Assert.ThrowsException<ExistFigureException>(testFunction);
        }
    }
}
