namespace SalesTax;

public class TaxProcessor : ITaxProcessor
{
    private decimal ItemPrice;
    private decimal ItemRate;
    private decimal ItemTax;

    private const decimal ImportedTaxRate = 0.05m;
    private const decimal RegularSalesTaxRate = 0.10m;
    private const decimal ImportedAndRegularRate = 0.15m;

    private TaxProcessor() { }

    public ITaxProcessor ComputeTax()
    {
        // round up to the nearest .05
        ItemTax = Math.Ceiling(ItemPrice * ItemRate * 20) / 20;
        return this;
    }

    public ITaxProcessor Price(decimal price)
    {
        ItemPrice = price;
        return this;
    }

    public ITaxProcessor Rate(bool isImported, bool isExempt)
    {
        switch (isImported)
        {
            case true when isExempt:
                ItemRate = ImportedTaxRate;
                break;
            case true when !isExempt:
                ItemRate = ImportedAndRegularRate;
                break;
            default:
                {
                    if (!isExempt && !isImported)
                    {
                        ItemRate = RegularSalesTaxRate;
                    }
                    break;
                }
        }
        return this;
    }

    public (decimal, decimal) Build()
    {
        var itemTotal = ItemPrice + ItemTax;

        return (ItemTax, itemTotal);
    }

    public static ITaxProcessor Builder()
    {
        return new TaxProcessor();
    }

}