namespace SalesTax.Models;

public class StoreItem
{
    public int Quantity { get; set; }
    public string ItemDescription { get; set; }
    public decimal Price { get; set; }
    public bool ExemptItem { get; set; }
    public bool ImportedItem { get; set; }

    public StoreItem(int quantity, string itemDescription, decimal price, bool importedItem, bool exemptItem)
    {
        Quantity = quantity;
        ItemDescription = itemDescription;
        Price = price;
        ImportedItem = importedItem;
        ExemptItem = exemptItem;
    }
}