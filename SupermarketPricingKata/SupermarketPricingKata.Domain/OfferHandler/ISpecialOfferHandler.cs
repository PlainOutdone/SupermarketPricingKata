namespace SupermarketPricingKata.Domain.OfferHandler
{
    public interface ISpecialOfferHandler
    {
       double ApplyOffers(double price, string items);
    }

}
