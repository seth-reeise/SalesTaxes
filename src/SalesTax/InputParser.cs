using SalesTax.Models;

namespace SalesTax;

public class InputParser
{
    public static StoreItem GetInput(string input)
    {
        int itemQuantity;
        string itemDescription;
        decimal itemPrice;
        bool isImported = false;
        bool isExempt = false;

        try
        {
            // substring to first space to get quantity
            var inputSplit = input.Substring(0, input.IndexOf(" ", StringComparison.CurrentCultureIgnoreCase)).Trim();
            itemQuantity = Convert.ToInt32(inputSplit);

            // substring from first space to get description
            itemDescription = input.Substring(input.IndexOf(" ", StringComparison.CurrentCultureIgnoreCase), input.LastIndexOf(" ", StringComparison.CurrentCultureIgnoreCase)).Trim();
            isImported = itemDescription.Contains("Imported", StringComparison.OrdinalIgnoreCase);

            // substring to get input from last space to end of line
            var priceString = input.Substring(input.LastIndexOf(" ", StringComparison.CurrentCultureIgnoreCase), input.Length - input.LastIndexOf(" ", StringComparison.CurrentCultureIgnoreCase)).Trim();
            itemPrice = Convert.ToDecimal(priceString);

            if (itemDescription.Contains("Book", StringComparison.OrdinalIgnoreCase))
            {
                isExempt = true;
            }
            else
            {
                Console.WriteLine("Is your item a book, food, or medical product? Enter y for yes and n for no");
                var isExemptString = Console.ReadLine();
                if (isExemptString == null) throw new ArgumentException();
                isExempt = isExemptString.Equals("y", StringComparison.OrdinalIgnoreCase) || isExemptString.Equals("yes", StringComparison.OrdinalIgnoreCase);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("\n**Input not entered correctly, please try again!**\n");
            throw new ArgumentException();
        }

        return new StoreItem(itemQuantity, itemDescription, itemPrice, isImported, isExempt);
    }
}
