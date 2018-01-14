namespace SupermarketPricingKata.Domain.TillController
{
    public interface ITillController
    {
        void Scan(string item);
        decimal Total();
    }
}
