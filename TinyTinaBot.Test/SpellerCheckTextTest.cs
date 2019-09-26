using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyTinaBot.Models;
using System.Threading.Tasks;

namespace TinyTinaBot.Test
{
    [TestClass]
    public class SpellerCheckTextTest
    {

        [TestMethod]
        public async Task TranslateIntoRuTestMethod()
        {
            string message = "ghbdtn";
            string expected = "привет";
            var words = await Speller.CheckText(message);
            string result = words[0].S[0];
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task TranslateIntoEnTestMethod()
        {
            string message = "руддщ";
            string expected = "hello";
            var words = await Speller.CheckText(message);
            string result = words[0].S[0];
            Assert.AreEqual(expected, result);
        }
    }
}
