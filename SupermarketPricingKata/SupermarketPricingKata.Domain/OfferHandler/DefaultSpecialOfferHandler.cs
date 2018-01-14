using SupermarketPricingKata.Domain.OfferDataProvider;
using SupermarketPricingKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketPricingKata.Domain.OfferHandler
{
    public class DefaultSpecialOfferHandler : ISpecialOfferHandler
    {
        private IOfferDataProvider _dataProvider;
        public DefaultSpecialOfferHandler(IOfferDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public decimal ApplyOffers(decimal price, string items)
        {

            decimal returnAmount = price;
            List<char> letters = items.ToCharArray().ToList();

            foreach (SpecialOffer offer in _dataProvider.GetOffers())
            {
                    List<char> offerSpecificLetters = letters.Where(l => l.ToString() == offer.Item).ToList();
                    decimal qulifyingAmount = offerSpecificLetters.Count / offer.Quantity;
                    returnAmount = returnAmount - (Math.Floor(qulifyingAmount) * offer.Reduction);
            }

            return returnAmount;
        }
    }

}
