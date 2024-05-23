
namespace Test20240430
{
    public interface ICurrencyService
    {
        Task<decimal> GetCurrencyAsync(string destinationCurrency);
    }
}