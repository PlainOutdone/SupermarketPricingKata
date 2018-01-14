namespace SupermarketPricingKata.Domain.OfferHandler
{
    public interface ISpecialOfferHandler
    {
        decimal ApplyOffers(decimal price, string items);
    }

}
