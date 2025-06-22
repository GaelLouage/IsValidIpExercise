using System.Net;
using System.Net.Http.Headers;

internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("True outputs:");
        Console.WriteLine(IsValidIp("1.2.3.4"));
        Console.WriteLine(IsValidIp("12.255.56.1"));
        Console.WriteLine(IsValidIp("123.45.67.89"));
        Console.WriteLine("False outputs:");
        Console.WriteLine(IsValidIp("123.45.a7.89"));
        Console.WriteLine(IsValidIp("1.2.3"));
        Console.WriteLine(IsValidIp("1.2.3.4.5"));
        Console.WriteLine(IsValidIp("123.456.78.90"));
        Console.WriteLine(IsValidIp("123.045.067.089"));
    }
    public static bool IsValidIp(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
            return false;

        var splitted = ipAddress.Split('.');

        if (splitted.Length != 4)
            return false;

        return SplittedValidationCheck(splitted);
    }

    private static bool SplittedValidationCheck(string[] splitted)
    {
        foreach (var part in splitted)
        {

            if (part != part.Trim())
                return false;

            if (!int.TryParse(part, out int value))
                return false;

            if (value < 0 || value > 255)
                return false;


            if (part.Length > 1 && part.StartsWith("0"))
                return false;
        }
        return true;
    }
}