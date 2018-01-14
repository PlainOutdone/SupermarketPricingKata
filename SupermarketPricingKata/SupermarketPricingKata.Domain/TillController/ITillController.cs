namespace SupermarketPricingKata.Domain.TillController
{
    public interface ITillController
    {
        decimal GetPrice(string items);
    }
}
