using System;
using static Classes.TextWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        delegate string Message(string text);
        static string testString = "привет22";
        /// <summary>
        /// test for reversing string method
        /// </summary>
        [TestMethod]
        public void ReverseRegisterTest()
        {
            Message operation = ReverseRegister;
            Assert.AreEqual("ПРИВЕТ22", operation(testString));
        }

        /// <summary>
        /// test for deleting all digits
        /// </summary>
        [TestMethod]
        public void DeleteDigitsTest()
        {
            Message operation = DeleteDigits;
            Assert.AreEqual("привет", operation(testString));
        }

        /// <summary>
        /// test for deleting all letters
        /// </summary>
        [TestMethod]
        public void DeleteLettersTest()
        {
            Message operation = DeleteLetters;
            Assert.AreEqual("22", operation(testString));
        }

        /// <summary>
        /// test for translit method
        /// </summary>
        [TestMethod]
        public void TranslitTest()
        {
            Message operation = Transliteration.Front;
            Assert.AreEqual("privet22", operation(testString));
        }
    }
}
