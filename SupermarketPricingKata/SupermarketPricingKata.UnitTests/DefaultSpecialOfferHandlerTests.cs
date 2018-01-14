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
            ISpecialOfferHandler handler = new DefaultSpecialOfferHandler(new DefaultOfferDataProvider());
            var expected = 1.00M;
            var actual = handler.ApplyOffers(1.00M, "");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedItemsThatDontAdhearToOffersReturnThePrice()
        {
            ISpecialOfferHandler handler = new DefaultSpecialOfferHandler(new DefaultOfferDataProvider());
            var expected = 1.00M;
            var actual = handler.ApplyOffers(1.00M, "TESTYWESTY");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedItemsThatMatchOffersReturnThePriceWithDeductionsMade()
        {
            ISpecialOfferHandler handler = new DefaultSpecialOfferHandler(new DefaultOfferDataProvider());
            var expected = 2.65M;
            var actual = handler.ApplyOffers(3.00M, "AAABB");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedSeveralItemsThatMatchOffersReturnThePriceWithDeductionsMade()
        {
            ISpecialOfferHandler handler = new DefaultSpecialOfferHandler(new DefaultOfferDataProvider());
            var expected = 2.45M;
            var actual = handler.ApplyOffers(3.00M, "AAAHGAIAJIAGBHBBNUD");
            Assert.Equal(expected, actual);

      
        }
    }
}
