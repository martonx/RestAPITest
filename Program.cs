using Test20240430;

var fastFoodService = new FastFoodService();

Console.WriteLine("Kérem adja meg, hogy milyen devizában szeretné látni az árakat (eur/usd/gbp):");
var destintionCurrency = Console.ReadLine();
Console.WriteLine("Kérem adja meg, hány terméket szeretne egy oldalon látni:");
var pageSize = int.Parse(Console.ReadLine());

var currentPage = 0;
do
{
    Console.WriteLine("Le fel nyíllal lehet lapozni:");
    var direction = Console.ReadKey();

    if (direction.Key == ConsoleKey.UpArrow)
        currentPage++;
    else if (direction.Key == ConsoleKey.DownArrow)
        currentPage--;
    else if (direction.Key == ConsoleKey.Escape)
        break;
    else
        continue;

    Console.Clear();
    var fastFoodResponse = await fastFoodService.GetAllFastFoodAsync(destintionCurrency, currentPage, pageSize);

    foreach (var fastFood in fastFoodResponse.FastFoods)
        Console.WriteLine(fastFood);
} while (true);

Console.WriteLine("Kérem adja meg az új étel nevét");
var newFastFood = new FastFood();
newFastFood.id = 1111;
newFastFood.name = Console.ReadLine();

Console.WriteLine($"Kérem adja meg az új étel árát {destintionCurrency}-ben");
newFastFood.price = int.Parse(Console.ReadLine());

Console.WriteLine("Kérem adja meg az új étel kalória tartalmát");
newFastFood.kcal = int.Parse(Console.ReadLine());

Console.WriteLine("Kérem adja meg az új étel leírását");
newFastFood.description = Console.ReadLine();
newFastFood.components = ["valami1", "valami2"];

await fastFoodService.CreateFastFoodAsync(destintionCurrency, newFastFood);

Console.WriteLine("Új étel létrehozása sikerült");