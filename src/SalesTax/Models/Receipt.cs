using System.Text;

namespace SalesTax.Models;

public class Receipt
{
    private List<StoreItem> StoreItems { get; }
    private decimal SalesTax { get; }
    private decimal Total { get; }
    
    public Receipt(List<StoreItem> storeItems, decimal salesTax, decimal total)
    {
        StoreItems = storeItems;
        SalesTax = salesTax;
        Total = total;
    }
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in StoreItems)
        {
            if (item.Quantity > 1)
            {
                sb.Append($"{item.ItemDescription}: {item.Price * item.Quantity} ({item.Quantity} @ {item.Price})\n");
            }
            else
            {
                sb.Append($"{item.ItemDescription}: {item.Price}\n");
            }
        }

        return sb.ToString();
    }
}