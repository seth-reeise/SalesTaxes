using SalesTax;

ShoppingBasket basket = new();
InputParser parser = new();

do
{
    try
    {
        Console.WriteLine("Please enter the quantity, description, and price of your next item " +
                          "each seperated by a space. Example input: 1 Book 12.49\n" +
                          "If you are done entering items, please enter: end");
        var input = Console.ReadLine();
        if (input.Equals("End", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }
        var item = parser.getInput(input);
        basket.AddItemToBasket(item);
    }
    catch (Exception e)
    {
        // log exception
    }
} while (true);

// Calculate total and print receipt
var receipt = basket.CalculateTotal();
Console.Clear();
Console.WriteLine("****** RECEIPT ******");
Console.WriteLine(receipt.ToString());
