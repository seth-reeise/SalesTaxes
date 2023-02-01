using SalesTax;
using SalesTax.Models;

ShoppingBasket basket = new();

var itemCount = 0;
do
{
    Console.WriteLine("Please enter how many items you would like to buy. Example input: 3");
    try
    {
        itemCount = Convert.ToInt32(Console.ReadLine());
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine("Number of items not entered correctly, please try again!");
    }
} while (true);

for (var i = 0; i < itemCount; i++)
{
    int itemQuantity;
    string itemDescription;
    decimal itemPrice;
    bool isImported = false;
    bool isExempt = false;

    do
    {
        // Get quantity, description, and price
        Console.WriteLine("Please enter the quantity, description, and price of item number " + (i + 1) +
                          " each seperated by a space. Example input: 1 Book 12.49");
        try
        {
            var input = Console.ReadLine();

            // substring to first space to get quantity
            var inputSplit = input.Substring(0, input.IndexOf(" ")).Trim();
            itemQuantity = Convert.ToInt32(inputSplit);

            // substring from first space to get description
            itemDescription = input.Substring(input.IndexOf(" "), input.LastIndexOf(" ")).Trim();
            isImported = itemDescription.Contains("Imported", StringComparison.OrdinalIgnoreCase);

            // substring to get input from last space to end of line
            var priceString = input.Substring(input.LastIndexOf(" "), input.Length - input.LastIndexOf(" ")).Trim();
            itemPrice = Convert.ToDecimal(priceString);

            if (itemDescription.Contains("Book", StringComparison.OrdinalIgnoreCase))
            {
                isExempt = true;
            }
            else
            {
                Console.WriteLine("Is your item a book, food, or medical product? Enter y for yes and n for no");
                var isExemptString = Console.ReadLine();
                isExempt = isExemptString.Equals("y", StringComparison.OrdinalIgnoreCase) || isExemptString.Equals("yes", StringComparison.OrdinalIgnoreCase);
            }

            break;
        }
        catch (Exception e)
        {
            Console.WriteLine("\n Input not entered correctly, please try again!");
        }
    } while (true);

    basket.AddItemToBasket(new StoreItem(itemQuantity, itemDescription, itemPrice, isImported, isExempt));
}

// Calculate total and print receipt
var receipt = basket.CalculateTotal();
Console.Clear();
Console.WriteLine("****** RECEIPT ******");
Console.WriteLine(receipt.ToString());
