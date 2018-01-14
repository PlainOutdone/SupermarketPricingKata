using SupermarketPricingKata.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketPricingKata.Domain.OfferDataProvider
{
    public class DefaultOfferDataProvider : IOfferDataProvider
    {
        public List<SpecialOffer> GetOffers()
        {
            return new List<SpecialOffer>()
            {
                new SpecialOffer() {Item = "A", Quantity=3, Reduction=0.20M},
                new SpecialOffer() {Item = "B", Quantity=2, Reduction=0.15M}
            };
        }
    }
}
