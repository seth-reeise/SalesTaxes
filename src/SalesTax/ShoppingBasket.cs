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
        // If same item exists, update quantity instead
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
        var salesTax = 0m;
        var total = 0m;

        var importedTaxRate = .05m;
        var regularSalesTaxRate = .10m;
        // Item is imported but not exempt
        var importedAndRegularRate = .15m;
        
        // item tax for each item is calculated by the tax rate and then rounded up to the nearest .05 with Math.Ceiling(rate*20) / 20
        foreach (var item in Basket)
        {
            var itemTax = 0m;
            
            // Imported and exempt item
            if (item.ImportedItem && item.ExemptItem)
            {
                itemTax = Math.Ceiling(item.Price * importedTaxRate * 20) / 20;
                item.Price += itemTax;
                salesTax += (itemTax * item.Quantity);

                total += (item.Price * item.Quantity);
                
            } 
            // Imported but not exempt item
            else if (item.ImportedItem && !item.ExemptItem)
            {
                itemTax = Math.Ceiling(item.Price * importedAndRegularRate * 20) / 20;
                item.Price += itemTax;
                salesTax += (itemTax * item.Quantity);

                total += (item.Price * item.Quantity);
            } 
            // Not exempt and not imported item
            else if (!item.ExemptItem && !item.ImportedItem)
            {
                itemTax = Math.Ceiling(item.Price * regularSalesTaxRate * 20 ) / 20;
                item.Price += itemTax;
                salesTax += (itemTax * item.Quantity);
                
                total += (item.Price * item.Quantity);
            }
            // No sales tax (exempt and not imported)
            else
            {
                total += item.Price;
            }
            
        }
        return new Receipt(Basket, salesTax, total);
        
    }

    public IEnumerator GetEnumerator()
    {
        return Basket.GetEnumerator();
    }
}