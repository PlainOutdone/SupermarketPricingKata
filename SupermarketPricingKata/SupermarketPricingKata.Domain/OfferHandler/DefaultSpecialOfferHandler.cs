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

        public double ApplyOffers(double price, string items)
        {

            double returnAmount = price;
            List<char> letters = items.ToCharArray().ToList();

            foreach (SpecialOffer offer in _dataProvider.GetOffers())
            {
                    List<char> offerSpecificLetters = letters.Where(l => l.ToString() == offer.Item).ToList();
                    double qulifyingAmount = offerSpecificLetters.Count / offer.Quantity;
                    returnAmount = returnAmount - (Math.Floor(qulifyingAmount) * offer.Reduction);
            }

            return returnAmount;
        }
    }

}
