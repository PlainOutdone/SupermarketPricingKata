using Microsoft.Extensions.DependencyInjection;
using SupermarketPricingKata.Domain;
using SupermarketPricingKata.Domain.TillController;
using System;
using Xunit;

namespace SupermarketPricingKata.IntegrationTests
{
    public class TillControllerTests
    {
        private decimal ScanAllAndReturnTotal(string items)
        {
            ITillController till = IoC.Container.GetService<ITillController>();
            foreach (char item in items.ToCharArray())
            {
                till.Scan(item.ToString());
            }
            return till.Total();
        }

        [Fact]
        public void WhenGivenDifferentListsOfItemsAddThemUpAndApplyOffersIndividually()
        {

            Assert.Equal(0, ScanAllAndReturnTotal(""));
            Assert.Equal(0.50M, ScanAllAndReturnTotal("A"));
            Assert.Equal(0.80M, ScanAllAndReturnTotal("AB"));
            Assert.Equal(1.15M, ScanAllAndReturnTotal("CDBA"));

            Assert.Equal(1.00M, ScanAllAndReturnTotal("AA"));
            Assert.Equal(1.30M, ScanAllAndReturnTotal("AAA"));
            Assert.Equal(1.80M, ScanAllAndReturnTotal("AAAA"));
            Assert.Equal(2.30M, ScanAllAndReturnTotal("AAAAA"));
            Assert.Equal(2.60M, ScanAllAndReturnTotal("AAAAAA"));

            Assert.Equal(1.60M, ScanAllAndReturnTotal("AAAB"));
            Assert.Equal(1.75M, ScanAllAndReturnTotal("AAABB"));
            Assert.Equal(1.90M, ScanAllAndReturnTotal("AAABBD"));
            Assert.Equal(1.90M, ScanAllAndReturnTotal("DABABA"));

        }

        [Fact]
        public void WhenGivenIncrementalValuesEnsureTheValueIsCorrectThroughout()
        {
            ITillController till = IoC.Container.GetService<ITillController>();
            Assert.Equal(0, till.Total());
            till.Scan("A"); Assert.Equal(0.50M,  till.Total());
            till.Scan("B"); Assert.Equal(0.80M,  till.Total());
            till.Scan("A"); Assert.Equal(1.30M, till.Total());
            till.Scan("A"); Assert.Equal(1.60M, till.Total());
            till.Scan("B"); Assert.Equal(1.75M, till.Total());
        }
    }
}
