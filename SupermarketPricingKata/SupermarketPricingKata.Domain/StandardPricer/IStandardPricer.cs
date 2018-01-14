namespace SupermarketPricingKata.Domain.StandardPricer
{
    public interface IStandardPricer
    {
        decimal GetPrice(string item);
    }
}
