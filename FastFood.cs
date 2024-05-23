public class FastFood
{
    public string[] components { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public int kcal { get; set; }
    public string description { get; set; }

    public override string ToString()
    {
        return $"Food: {name}, price: {price}";
    }
}
