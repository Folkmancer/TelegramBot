using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyTinaBot.Models;

namespace TinyTinaBot.Test
{
    [TestClass]
    public class TextLayoutTranslatorTest
    {
        [TestMethod]
        public void TranslateIntoRUTestMethod1()
        {
            string text = "������";
            string message = "ghbdtn";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoRU(message));
        }

        [TestMethod]
        public void TranslateIntoRUTestMethod2()
        {
            string text = "������, �������!";
            string message = "Ghbdtn? njdfhbo!";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoRU(message));
        }

        [TestMethod]
        public void TranslateIntoRUTestMethod3()
        {
            string text = "13 ����";
            string message = "13 b.kz";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoRU(message));
        }

        [TestMethod]
        public void TranslateIntoENTestMethod1()
        {
            string text = "ghbdtn";
            string message = "������";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoEN(message));
        }

        [TestMethod]
        public void TranslateIntoENTestMethod2()
        {
            string text = "Ghbdtn? njdfhbo!";
            string message = "������, �������!";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoEN(message));
        }

        [TestMethod]
        public void TranslateIntoENTestMethod3()
        {
            string text = "13 b.kz";
            string message = "13 ����";
            Assert.AreEqual(text, TextLayoutTranslator.TranslateIntoEN(message));
        }
    }
}
