using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketPricingKata.Domain.StandardPricer
{
    public class DefaultStandardPricer : IStandardPricer
    {
        private Dictionary<string, double> _itemPriceDictionary = new Dictionary<string, double>()
        {
            { "A", 0.50 },
            { "B" ,0.30 }
        };

        public double GetPrice(string item)
        {

            if (_itemPriceDictionary.ContainsKey(item))
            {
                return _itemPriceDictionary[item];
            }
            else
            {
                throw new NotImplementedException("$Couldn't location item {item} in the dictionary");
            }
        }
    }
}
