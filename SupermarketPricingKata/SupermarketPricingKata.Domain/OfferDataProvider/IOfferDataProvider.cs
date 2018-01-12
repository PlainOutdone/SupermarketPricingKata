using SupermarketPricingKata.Models;
using System.Collections.Generic;

namespace SupermarketPricingKata.Domain.OfferDataProvider
{
    public interface IOfferDataProvider
    {
         List<SpecialOffer> GetOffers();
    }
}
