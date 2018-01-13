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
            Assert.Equal(0.50, till.GetPrice("A"));
            Assert.Equal(0.80, till.GetPrice("AB"));
            Assert.Equal(1.15, till.GetPrice("CDBA"));

            Assert.Equal(1.00,till.GetPrice("AA"));
            Assert.Equal(1.30,till.GetPrice("AAA"));
            Assert.Equal(1.80,till.GetPrice("AAAA"));
            Assert.Equal(2.30,till.GetPrice("AAAAA"));
            Assert.Equal(2.60, till.GetPrice("AAAAAA"));

            Assert.Equal(1.60, till.GetPrice("AAAB"));
            Assert.Equal(1.75, till.GetPrice("AAABB"));
            Assert.Equal(1.90, till.GetPrice("AAABBD"));
            Assert.Equal(1.90, till.GetPrice("DABABA"));

        }
    }
}
