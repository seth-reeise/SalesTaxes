using System;
using SalesTax;
using SalesTax.Models;
using Xunit;

namespace SalesTaxUnitTests;

public class CalculateReceiptTests
{
    [Fact]
    public void IsReceiptCalculationCorrect()
    {
        ShoppingBasket basket = new();

        // 1 Imported box of chocolates at 10.00
        StoreItem item = new(1, "Imported box of chocolates", (decimal)10.00, true, true);
        basket.AddItemToBasket(item);

        // 1 Imported bottle of perfume at 47.50
        StoreItem item1 = new(1, "Imported bottle of perfume", (decimal)47.50, true, false);
        basket.AddItemToBasket(item1);

        var receipt = basket.Checkout();
        Assert.NotNull(receipt);
        Assert.Equal(7.65m, receipt.SalesTax);
        Assert.Equal(65.15m, receipt.Total);
    }
    
    [Fact]
    public void AreItemsBeingUpdated()
    {
        ShoppingBasket basket = new();

        // 1 Imported bottle of perfume at 47.50
        StoreItem item1 =
            new(1, "Imported bottle of perfume", (decimal)27.99, true, false);
        basket.AddItemToBasket(item1);

        // 1 Bottle of perfume at 18.99
        StoreItem item2 =
            new(1, "Bottle of perfume", (decimal)18.99, false, false);
        basket.AddItemToBasket(item2);

        // 1 Packet of headache pills at 9.75
        StoreItem item3 =
            new(1, "Packet of headache pills", (decimal)9.75, false, true);
        basket.AddItemToBasket(item3);

        // 1 Imported box of chocolates at 11.25 X 2
        StoreItem item4 =
            new(1, "Imported box of chocolates", (decimal)11.25, true, true);
        basket.AddItemToBasket(item4);
        
        // 1 Imported box of chocolates at 11.25 X 2
        StoreItem item5 =
            new(1, "Imported box of chocolates", (decimal)11.25, true, true);
        basket.AddItemToBasket(item5);

        var receipt = basket.Checkout();
        Assert.NotNull(receipt);

        // Verify item price is updated with tax added
        Assert.Equal(32.19m, item1.Price);
        Assert.Equal(20.89m, item2.Price);
        Assert.Equal(9.75m, item3.Price);
        Assert.Equal(11.85m, item4.Price);

        Assert.Equal(7.30m, receipt.SalesTax);
        Assert.Equal(86.53m, receipt.Total);
    }

    [Fact]
    public void ExceptionThrownOnBadInput()
    {
        const string input = "sdflk23";

        Assert.Throws<ArgumentException>(() => InputParser.GetInput(input));
    }

    [Fact]
    public void CanCreateStoreItem()
    {
        const string input = "1 Book 5.60";
        var item = InputParser.GetInput(input);

        Assert.NotNull(item);
        Assert.Equal(1, item.Quantity);
        Assert.Equal("Book", item.ItemDescription);
        Assert.Equal(5.60m, item.Price);
    }
}