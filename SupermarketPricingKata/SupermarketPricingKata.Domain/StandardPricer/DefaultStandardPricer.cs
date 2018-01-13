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
            { "B" ,0.30 },
            { "C" ,0.20 },
            { "D" ,0.15 }
        };

        public double GetPrice(string items)
        {
            double total = 0;
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
