using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace RomanNumerals.Tests
{
    [TestFixture]
    public class RomanTests
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        public void RomanNumeralsOneToTen(int arabic, string expectedRomanNumeral)
        {
            //Arrange
            var translator = new RomanNumeralTranslator();

            //Act
            string actual = translator.Translate(arabic);

            //Assert
            actual.Should().Be(expectedRomanNumeral);
        }
    }

    public class RomanNumeralTranslator
    {
        public string Translate(int arabic)
        {
            if (arabic == 9)
                return "IX";

            if (arabic == 10)
                return "X";

            var prefix = new StringBuilder();
            var suffix = new StringBuilder();
            if (arabic >= 4)
            {
                arabic -= 5;
                if (arabic < 0)
                    prefix.Append("I");
                suffix.Append('V');
            }

            for (int i = 0; i < arabic; i++)
            {
                suffix.Append("I");
            }

            return prefix + suffix.ToString();
        }
    }
}