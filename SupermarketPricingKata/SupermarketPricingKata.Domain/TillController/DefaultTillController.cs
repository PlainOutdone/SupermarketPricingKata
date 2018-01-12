using SupermarketPricingKata.Domain.StandardPricer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketPricingKata.Domain.TillController
{
    public class DefaultTillController : ITillController
    {
        private IStandardPricer _standardPricer;
        public DefaultTillController(IStandardPricer standardPricer)
        {
            _standardPricer = standardPricer;
        }

        public double GetPrice(string items)
        {
            double standardPrice = _standardPricer.GetPrice(items);
            
            return standardPrice;
        }
    }

    public interface ITillController
    {
       double GetPrice(string items);
    }
}
