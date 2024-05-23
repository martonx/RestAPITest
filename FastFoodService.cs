using System.Net.Http.Json;
using System.Text.Json;

namespace Test20240430;

public class FastFoodService
{
    private readonly HttpClient httpClient;
    private readonly ICurrencyService currencyService;
    public FastFoodService()
    {
        httpClient = new HttpClient();
        currencyService = new CurrencyService();
    }

    public async Task<FastFoodResponse> GetAllFastFoodAsync(string destinationCurrency, int currentPage, int pageSize)
    {
        var fastFoods = await httpClient.GetFromJsonAsync<List<FastFood>>(
            "https://fastfoodvasvari.azurewebsites.net/list");
        currentPage = currentPage - 1;
        var pagedFoods = fastFoods.Skip(currentPage * pageSize)
            .Take(pageSize).ToList();

        var currency = await currencyService.GetCurrencyAsync(destinationCurrency);

        foreach (var fastFood in pagedFoods)
            fastFood.price = Math.Round(fastFood.price / currency, 2);

        return new FastFoodResponse
        {
            FastFoods = pagedFoods,
            TotalCount = fastFoods.Count()
        };
    }

    public async Task CreateFastFoodAsync(string destinationCurrency, FastFood fastFood)
    {
        var currency = await currencyService.GetCurrencyAsync(destinationCurrency);
        fastFood.price = Math.Round(fastFood.price * currency, 0);

        var response = await httpClient.PostAsJsonAsync(
            "https://fastfoodvasvari.azurewebsites.net/create", fastFood);

        return;
    }

    public async Task UpdateFastFoodAsync(string destinationCurrency, FastFood fastFood)
    {
        var currency = await currencyService.GetCurrencyAsync(destinationCurrency);
        fastFood.price = Math.Round(fastFood.price * currency, 0);

        var response = await httpClient.PutAsJsonAsync(
            "https://fastfoodvasvari.azurewebsites.net/update", fastFood);

        return;
    }

    public async Task DeleteFastFoodAsync(int id)
    {
        var response = await httpClient.DeleteAsync(
            $"https://fastfoodvasvari.azurewebsites.net/delete/{id}");

        return;
    }
}
