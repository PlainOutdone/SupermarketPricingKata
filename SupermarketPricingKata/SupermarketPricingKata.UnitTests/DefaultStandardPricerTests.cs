using SupermarketPricingKata.Domain.StandardPricer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SupermarketPricingKata.UnitTests
{

    public class DefaultStandardPricerTests
    {

        [Fact]
        public static void WhenIGivenAnNullItemReturn0()
        {
            IStandardPricer pricer = new DefaultStandardPricer();
            var expected = 0;
            var actual = pricer.GetPrice(null);
            Assert.Equal(expected, actual);
        }



              [Fact]
        public static void WhenIGivenAnEmptyStringItemReturn0()
        {
            IStandardPricer pricer = new DefaultStandardPricer();
            var expected = 0;
            var actual = pricer.GetPrice("");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenIGiveAValidItemReturnTheValueOfTheItem()
        {
            IStandardPricer pricer = new DefaultStandardPricer();
            Assert.Equal(0.50M, pricer.GetPrice("A"));
            Assert.Equal(0.30M, pricer.GetPrice("B"));
        }

        [Fact]
        public static void WhenIGiveAnItemThatIsntWithinTheDictionaryExpectAKeyNotFoundException()
        {
            var input = "Z";
            IStandardPricer pricer = new DefaultStandardPricer();
            KeyNotFoundException ex = Assert.Throws<KeyNotFoundException>(() => pricer.GetPrice(input));
            Assert.Equal($"Couldn't find item {input} in the dictionary", ex.Message);
        }

        [Fact]
        public static void WhenIGiveSeveralItemsExpectTheTotal()
        {
            var input = "AAB";
            IStandardPricer pricer = new DefaultStandardPricer();
            var expected = 1.30M;
            var actual = pricer.GetPrice(input);

            Assert.Equal(expected, actual);
        }
    }
}
