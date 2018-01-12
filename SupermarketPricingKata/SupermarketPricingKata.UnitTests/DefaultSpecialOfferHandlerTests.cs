using SupermarketPricingKata.Domain.OfferDataProvider;
using SupermarketPricingKata.Domain.OfferHandler;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SupermarketPricingKata.UnitTests
{
    public class DefaultSpecialOfferHandlerTests
    {
        [Fact]
        public static void WhenProvidedNoItemsReturnNoDeduction()
        {
            ISpecialOfferHandler handler = new DefaultOfferdataHandler(new DefaultOfferDataProvider());
            var expected = 1.00;
            var actual = handler.ApplyOffers(1.00, "");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedItemsThatDontAdhearToOffersReturnThePrice()
        {
            ISpecialOfferHandler handler = new DefaultOfferdataHandler(new DefaultOfferDataProvider());
            var expected = 1.00;
            var actual = handler.ApplyOffers(1.00, "TESTYWESTY");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedItemsThatMatchOffersReturnThePriceWithDeductionsMade()
        {
            ISpecialOfferHandler handler = new DefaultOfferdataHandler(new DefaultOfferDataProvider());
            var expected = 2.65;
            var actual = handler.ApplyOffers(3.00, "AAABB");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedSeveralItemsThatMatchOffersReturnThePriceWithDeductionsMade()
        {
            ISpecialOfferHandler handler = new DefaultOfferdataHandler(new DefaultOfferDataProvider());
            var expected = 2.45;
            var actual = handler.ApplyOffers(3.00, "AAAHGAIAJIAGBHBBNUD");
            Assert.Equal(expected, actual);
        }
    }
}
