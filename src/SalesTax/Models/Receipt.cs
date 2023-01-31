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
                sb.Append(string.Format($"{item.ItemDescription}: {(item.Price * item.Quantity).ToString("F")} ({item.Quantity} @ {item.Price.ToString("F")})\n"));
            }
            else
            {
                sb.Append($"{item.ItemDescription}: {item.Price.ToString("F")}\n");
            }
        }

        sb.Append($"Sales Taxes: {SalesTax.ToString("F")}\n");
        sb.Append($"Total: {Total.ToString("F")}\n");

        return sb.ToString();
    }
}