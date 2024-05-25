using System.Net.Http.Headers;

namespace Containers;

public static class ProductController
{
    private static Dictionary<string, double> products { get; } = new Dictionary<string, double>
    {
        { "bananas", 13.3 },
        { "chocolate", 18 },
        { "fish", 2 },
        { "meat", -15 },
        { "icecream", -18 },
        { "frozenpizza", -30 },
        { "cheese", 7.2 },
        { "sausages", 5 },
        { "butter", 20.5 },
        { "eggs", 19 }
    };

    public static bool checkIfValidProduct(string productName)
    {
        productName = productName.Replace(" ", "").ToLower();

        if (products.ContainsKey(productName))
        {
            return true;
        }

        return false;
    }

    public static double getProductTemperature(string productName)
    {
        productName = productName.Replace(" ", "").ToLower();
        if (checkIfValidProduct(productName))
        {
            return products[productName];
        }
        else
        {
            throw new NotExistingProductException("Invalid product name");
        }
    }

    public static void addNewProduct(string productName, double productSafeTemperature)
    {
        productName = productName.Replace(" ", "").ToLower();
        products[productName] = productSafeTemperature;
    }
}