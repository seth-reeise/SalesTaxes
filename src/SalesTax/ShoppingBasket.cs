using System.Collections;
using SalesTax.Models;

namespace SalesTax;

public class ShoppingBasket : IEnumerable
{
    private readonly List<StoreItem> Basket;

    public ShoppingBasket()
    {
        Basket = new List<StoreItem>();
    }

    public void AddItemToBasket(StoreItem newItem)
    {
        if (Basket.Any(item => item.ItemDescription.Equals(newItem.ItemDescription)))
        {
            foreach (var item in Basket.Where(item => item.ItemDescription.Equals(newItem.ItemDescription)))
            {
                item.Quantity += newItem.Quantity;
            }
        }
        else
        {
            Basket.Add(newItem);
        }
    }

    public Receipt CalculateTotal()
    {
        return new Receipt(Basket, 0, 0);
        
    }

    public IEnumerator GetEnumerator()
    {
        return Basket.GetEnumerator();
    }
}