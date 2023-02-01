using SalesTax;

ShoppingBasket basket = new();

do
{
    try
    {
        Console.WriteLine("Please enter the quantity, description, and price of your next item " +
                          "each seperated by a space. Example input: 1 Book 12.49\n" +
                          "If you are done entering items, please enter: end");
        var input = Console.ReadLine();
        if (input != null && input.Equals("End", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        if (input == null) throw new ArgumentException();
        var item = InputParser.GetInput(input);
        basket.AddItemToBasket(item);
    }
    catch (Exception)
    {
        // log exception
    }
} while (true);

// Calculate total and print receipt
var receipt = basket.CalculateTotal();
Console.Clear();
Console.WriteLine("****** RECEIPT ******");
Console.WriteLine(receipt.ToString());
