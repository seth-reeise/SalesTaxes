namespace SalesTax.Models;

public class StoreItem
{
    public int Quantity { get; set; }
    public string ItemDescription { get; set; }
    public decimal Price { get; set; }
    public bool IsExempt { get; set; }
    public bool IsImported { get; set; }

    public StoreItem(int quantity, string itemDescription, decimal price, bool isImported, bool isExempt)
    {
        Quantity = quantity;
        ItemDescription = itemDescription;
        Price = price;
        IsImported = isImported;
        IsExempt = isExempt;
    }
}
