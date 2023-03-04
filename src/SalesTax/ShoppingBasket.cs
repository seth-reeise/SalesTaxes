using SalesTax.Models;

namespace SalesTax;

public class ShoppingBasket
{
    private readonly List<StoreItem> Basket;

    public ShoppingBasket()
    {
        Basket = new List<StoreItem>();
    }

    public void AddItemToBasket(StoreItem newItem)
    {
        // If same item exists, update quantity instead
        if (Basket.Any(item => item.ItemDescription.Equals(newItem.ItemDescription, StringComparison.OrdinalIgnoreCase) && item.Price.Equals(newItem.Price)))
        {
            foreach (var item in Basket.Where(item => item.ItemDescription.Equals(newItem.ItemDescription, StringComparison.OrdinalIgnoreCase)))
            {
                item.Quantity += newItem.Quantity;
            }
        }
        else
        {
            Basket.Add(newItem);
        }
    }

    /// <summary>
    /// Uses TaxProcessor Builder to calculate taxes for each item
    /// Updates total sales tax, total amount, and item price with tax added
    /// </summary>
    /// <returns>Receipt</returns>
    public Receipt Checkout()
    {
        var salesTax = 0m;
        var total = 0m;

        foreach (var item in Basket)
        {
            var (itemTax, itemTotal) = TaxProcessor.Builder()
                .Price(item.Price)
                .Rate(item.IsImported, item.IsExempt)
                .ComputeTax()
                .Build();

            salesTax += itemTax * item.Quantity;
            total += itemTotal * item.Quantity;

            // Update individual item price with tax added
            item.Price = itemTotal;
        }

        return new Receipt(Basket, salesTax, total);
    }
}