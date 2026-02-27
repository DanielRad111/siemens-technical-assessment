namespace SieMarket;

public class Order
{
    public string CustomerName { get; set; }//aici puteam sa fac o clasa noua pentru customer, dar am decis sa las doar CustomerName pentru simplitate si pentru respectarea cerintelor problemei, unde se specifica doar creearea claselor Order si Item
    public List<Item> Items { get; set; }

    public Order(string customerName)
    {
        CustomerName = customerName;
        Items = new List<Item>();
    }

    //calcularea pretului total al unei comenzi + discount aplicat (Cerinta 2.2)
    public double GetFinalPrice()
    {
        double FinalPrice = 0.0;
        foreach (Item item in Items)
        {
            FinalPrice += item.Quantity * item.UnitPrice;
        }

        if (FinalPrice > 500.0)
        {
            FinalPrice -= 0.1 * FinalPrice;
        }
        return FinalPrice;
    }
}