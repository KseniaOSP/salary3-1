using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Transfer;

namespace Transfer
{
    [TestClass]
    public class NumberToWordsTests
    {
        public void InvokeMethod(double number, string expected)
        {
            string actual = NumberToWords.ToWords(number);
            Assert.AreEqual(expected, actual);
        }

        public void InvokeMethod(ulong number, string expected)
        {
            string actual = NumberToWords.ToWords(number);
            Assert.AreEqual(expected, actual);
        }

        public void InvokeMethod(int number, string expected)
        {
            string actual = NumberToWords.ToWords(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToWords_53_63_ReturnsTrue()
        {
            var number = 53.63;
            InvokeMethod(number, "пятьдесят три, шестьдесят три");
        }

        [TestMethod]
        public void ToWords_0_ReturnsTrue()
        {
            var number = 0;
            InvokeMethod(number, "ноль");
        }

        [TestMethod]
        public void ToWords_19_ReturnsTrue()
        {
            var number = 19;
            InvokeMethod(number, "девятнадцать");
        }

        [TestMethod]
        public void ToWords_17_743_575__93_ReturnsTrue()
        {
            var number = 17_743_575.93;
            InvokeMethod(number, "семнадцать миллионов семьсот сорок три тысячи пятьсот семьдесят пять, девяносто три");
        }

        [TestMethod]
        public void ToWords_5000900834_ReturnsTrue()
        {
            //нужно переопределить ситуацию, так как без явного указания ulong компилятор подставляет double
            //и появляется дополнительная запись ", ноль"
            ulong number = 5000900834;
            InvokeMethod(number, "пять миллиардов девятьсот тысяч восемьсот тридцать четыре");
        }

        [TestMethod]
        public void ToWords_11_61_ReturnsTrue()
        {
            var number = 11.61;
            InvokeMethod(number, "одиннадцать, шестьдесят один");
        }
    }
}
