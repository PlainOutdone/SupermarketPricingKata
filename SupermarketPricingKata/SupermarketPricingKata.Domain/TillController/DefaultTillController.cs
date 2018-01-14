using SupermarketPricingKata.Domain.OfferHandler;
using SupermarketPricingKata.Domain.StandardPricer;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace SupermarketPricingKata.Domain.TillController
{
    public class DefaultTillController : ITillController
    {
        private IStandardPricer _standardPricer;
        private ISpecialOfferHandler _offerHandler;
        public DefaultTillController(IStandardPricer standardPricer, ISpecialOfferHandler offerHandler)
        {
            _standardPricer = standardPricer;
            _offerHandler = offerHandler;
        }

        private string _items = "";

        public void Scan(string item)
        {
            _items = $"{_items}{item}";
        }

        public decimal Total()
        {
            decimal standardPrice = _standardPricer.GetPrice(_items);

            return _offerHandler.ApplyOffers(standardPrice, _items);
        }
    }
}
