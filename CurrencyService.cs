using System.Xml.Serialization;

namespace Test20240430;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient httpClient;
    public CurrencyService()
    {
        httpClient = new HttpClient();
    }

    public async Task<decimal> GetCurrencyAsync(string destinationCurrency)
    {
        var response = await httpClient.GetStreamAsync(
            $"http://api.napiarfolyam.hu?bank=mnb&valuta={destinationCurrency}");
        var serializer = new XmlSerializer(typeof(arfolyamok));
        var result = (arfolyamok)serializer.Deserialize(response);

        return result.deviza.item.kozep.FirstOrDefault();
    }
}
