using SupermarketPricingKata.Domain.StandardPricer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketPricingKata.Domain.TillController
{
    public class DefaultTillController
    {
        private IStandardPricer _standardPricer;
        public DefaultTillController(IStandardPricer standardPricer)
        {
            _standardPricer = standardPricer;
        }

        
    }

    public interface ITillController
    {
       double GetPrice(string items);
    }
}
