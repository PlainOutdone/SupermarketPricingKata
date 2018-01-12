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
        public static void WhenIGiveNoItemExpectANullException()
        {
            IStandardPricer pricer = new DefaultStandardPricer();
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => pricer.GetPrice(null));
            Assert.Equal("item", ex.ParamName);
        }

        [Fact]
        public static void WhenIGiveAValidItemReturnTheValueOfTheItem()
        {
            IStandardPricer pricer = new DefaultStandardPricer();
           Assert.Equal(0.50, pricer.GetPrice("A"));
            Assert.Equal(0.30, pricer.GetPrice("B"));
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
            var expected = 1.30;
            var actual = pricer.GetPrice(input);

            Assert.Equal(expected, actual);
        }
    }
}
