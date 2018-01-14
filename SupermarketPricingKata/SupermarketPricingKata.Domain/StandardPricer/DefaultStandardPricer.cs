using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketPricingKata.Domain.StandardPricer
{
    public class DefaultStandardPricer : IStandardPricer
    {
        private Dictionary<string, decimal> _itemPriceDictionary = new Dictionary<string, decimal>()
        {
            { "A", 0.50M },
            { "B" ,0.30M },
            { "C" ,0.20M },
            { "D" ,0.15M }
        };

        public decimal GetPrice(string items)
        {
            decimal total = 0;
            if (String.IsNullOrEmpty(items)) { return 0; }

            foreach (char item in items.ToCharArray())
            {
                if (_itemPriceDictionary.ContainsKey(item.ToString()))
                {
                    total = total + _itemPriceDictionary[item.ToString()];
                }
                else
                {
                    throw new KeyNotFoundException($"Couldn't find item {item} in the dictionary");
                }
            }

            return total;

        }
    }
}
