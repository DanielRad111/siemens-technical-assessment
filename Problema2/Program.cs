using System;

namespace SieMarket
{
    internal class Program
    {
        static void Main()
        {
            SieMarket sieMarket = new SieMarket();
            
            Item item1 = new Item("Iphone 17 Pro Max", 1, 6599.99);
            Item item2 = new Item("Iphone 17", 1, 4499.99);
            Item item3 = new Item("Iphone 16", 1, 3899.99);

            Order order1 = new Order("Daniel");
            Order order2 = new Order("Andrei");
            Order order3 = new Order("Mihai");

            order1.Items.Add(item1);
            order2.Items.Add(item2);
            order2.Items.Add(item3);
            order3.Items.Add(item3);
            
            sieMarket.Orders.Add(order1);
            sieMarket.Orders.Add(order2);
            sieMarket.Orders.Add(order3);

            Console.WriteLine(sieMarket.GetTopCustomer());
            foreach (var item in sieMarket.GetPopularProduct())
            {
                Console.WriteLine($"-Nume: {item.Name}, Cantitate: {item.Quantity}");
            }
        }
    }
}