using System.Net.Http.Headers;

namespace SieMarket;

//Am creeat clasa SieMarket ca sa avem un global view pentru a analiza toate comenzile simultan
public class SieMarket
{
    public List<Order> Orders { get; set; } = new List<Order>();

    //Functia GetTopCustomer o sa ne returneze numele clientului cu cei mai multi bani cheltuiti pe comenzi (Cerinta 2.3)
    public String GetTopCustomer()
    {
        //vom folosi un dictionar(hash map) pentru a stoca numele clientului si totalul de bani cheltuiti de acesta pe toate comenzile sale
        Dictionary<string, double> clientTotal = new Dictionary<string, double>();
        foreach (Order order in Orders)
        {
            string name = order.CustomerName; //numele clientului
            double orderTotal = order.GetFinalPrice();

            if (clientTotal.ContainsKey(name))
            {
                clientTotal[name] += orderTotal;
            }
            else
            {
                clientTotal.Add(name, orderTotal);
            }
        }

        string bestClient = "";
        double maxSum = 0.0;

        foreach (KeyValuePair<string,double> entry in clientTotal)
        {
            if (entry.Value > maxSum)
            {
                bestClient = entry.Key;
                maxSum = entry.Value;
            }
        }
        
        return bestClient;
    }

    //Aici am facut metoda pentru a returna cele mai populare produse (cerinta 2.4)
    public List<(string Name,int Quantity)> GetPopularProduct()
    {
        //tot asa cu dictionar pentru a pastra <numeProdus, nrAparitii>
        Dictionary<string, int> productAppearances = new Dictionary<string, int>();
        foreach (Order order in Orders)
        {
            foreach (Item item in order.Items)
            {
                //daca exista deja item-ul, adaugam cantitatea
                if (productAppearances.ContainsKey(item.Name))
                {
                    productAppearances[item.Name] += item.Quantity;
                }
                //daca nu exista, il adaugam in dictionar cu cantitatea sa
                else
                {
                    productAppearances.Add(item.Name, item.Quantity);
                }
            }
        }
        
        //luam o lista pentru cele mai populare produse
        List<(string Name, int Quantity)> popularProducts = new List<(string Name, int Quantity)>();
        int maxAppearances = 0;
        
        foreach (KeyValuePair<string, int> entry in productAppearances)
        {
            if (entry.Value > maxAppearances)
            {
                maxAppearances = entry.Value;
                popularProducts.Clear(); // dc nr de aparitii > maximul, golim lista si lasam cel mai popular item
                popularProducts.Add((entry.Key, entry.Value));
            }
            else if (entry.Value == maxAppearances) // daca nr de aparitii e egal cu maximul, il bagam in lista
            {
                popularProducts.Add((entry.Key, entry.Value));
            }
        }
        
        return popularProducts;
    }
}