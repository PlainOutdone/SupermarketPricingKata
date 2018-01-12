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

        public double GetPrice(string items)
        {
            double total = 0;
            if (String.IsNullOrEmpty(items)) { throw new ArgumentNullException("item"); }

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
