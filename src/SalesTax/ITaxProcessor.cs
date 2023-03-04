namespace SalesTax;

public interface ITaxProcessor
{
    public ITaxProcessor Price(decimal price);

    public ITaxProcessor Rate(bool isImported, bool isExempt);

    public ITaxProcessor ComputeTax();

    public (decimal, decimal) Build();
}