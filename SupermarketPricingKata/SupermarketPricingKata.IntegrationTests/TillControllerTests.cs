using Microsoft.Extensions.DependencyInjection;
using SupermarketPricingKata.Domain;
using SupermarketPricingKata.Domain.TillController;
using System;
using Xunit;

namespace SupermarketPricingKata.IntegrationTests
{
    public class TillControllerTests
    {
        [Fact]
        public void WhenGivenDifferentListsOfItemsAddThemUpAndApplyOffersIndividually()
        {
            ITillController till = IoC.Container.GetService<ITillController>();

            Assert.Equal(0, till.GetPrice(""));
            Assert.Equal(0.50M, till.GetPrice("A"));
            Assert.Equal(0.80M, till.GetPrice("AB"));
            Assert.Equal(1.15M, till.GetPrice("CDBA"));

            Assert.Equal(1.00M,till.GetPrice("AA"));
            Assert.Equal(1.30M,till.GetPrice("AAA"));
            Assert.Equal(1.80M,till.GetPrice("AAAA"));
            Assert.Equal(2.30M,till.GetPrice("AAAAA"));
            Assert.Equal(2.60M, till.GetPrice("AAAAAA"));

            Assert.Equal(1.60M, till.GetPrice("AAAB"));
            Assert.Equal(1.75M, till.GetPrice("AAABB"));
            Assert.Equal(1.90M, till.GetPrice("AAABBD"));
            Assert.Equal(1.90M, till.GetPrice("DABABA"));

        }
    }
}
