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
            Assert.Equal(50, till.GetPrice("A"));
            Assert.Equal(80, till.GetPrice("AB"));
            Assert.Equal(115, till.GetPrice("CDBA"));

            Assert.Equal(100,till.GetPrice("AA"));
            Assert.Equal(130,till.GetPrice("AAA"));
            Assert.Equal(180,till.GetPrice("AAAA"));
            Assert.Equal(230,till.GetPrice("AAAAA"));
            Assert.Equal(260, till.GetPrice("AAAAAA"));

            Assert.Equal(160, till.GetPrice("AAAB"));
            Assert.Equal(175, till.GetPrice("AAABB"));
            Assert.Equal(190, till.GetPrice("AAABBD"));
            Assert.Equal(190, till.GetPrice("DABABA"));

        }
    }
}
