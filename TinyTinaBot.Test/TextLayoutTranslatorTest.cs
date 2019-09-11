using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyTinaBot.Models;
using System.Globalization;

namespace TinyTinaBot.Test
{
    [TestClass]
    public class TextLayoutTranslatorTest
    {

        [TestMethod]
        public void TranslateIntoRUTestMethod1()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            string text = "привет";
            string message = "ghbdtn";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoRU(message));
        }

        [TestMethod]
        public void TranslateIntoRUTestMethod2()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            string text = "Привет, товарищ!";
            string message = "Ghbdtn? njdfhbo!";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoRU(message));
        }

        [TestMethod]
        public void TranslateIntoRUTestMethod3()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            string text = "13 июля";
            string message = "13 b.kz";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoRU(message));
        }

        [TestMethod]
        public void TranslateIntoENTestMethod1()
        {
            string text = "ghbdtn";
            string message = "привет";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoEN(message));
        }

        [TestMethod]
        public void TranslateIntoENTestMethod2()
        {
            string text = "Ghbdtn? njdfhbo!";
            string message = "Привет, товарищ!";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoEN(message));
        }

        [TestMethod]
        public void TranslateIntoENTestMethod3()
        {
            string text = "13 b.kz";
            string message = "13 июля";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoEN(message));
        }
    }
}
