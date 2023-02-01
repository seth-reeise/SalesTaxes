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

        var receipt = basket.CalculateTotal();
        Assert.NotNull(receipt);
        Assert.Equal(7.65m, receipt.SalesTax);
        Assert.Equal(65.15m, receipt.Total);
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