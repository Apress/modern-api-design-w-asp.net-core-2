using System;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection()
        .AddDataProtection()
        .Services.BuildServiceProvider();
        var protecterProvider = services.GetService<IDataProtectionProvider>();
        var protector = protecterProvider.CreateProtector("AwesomePurpose").
        ToTimeLimitedDataProtector();
        DateTimeOffset expiryDate;
        Console.Write($"Type something sensitive: ");
        var input = Console.ReadLine();
        var protectedInput = protector.Protect(input, TimeSpan.FromSeconds(10));
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"Protected: {protectedInput}");
                var unprotectedInput = protector.Unprotect(protectedInput,

                out expiryDate);

                Console.WriteLine($"Unprotected: {unprotectedInput}");
                Console.WriteLine($"This message will self-destruct in { (expiryDate - DateTime.Now).Seconds} second(s).");
            
            }
            catch (CryptographicException ex)
            {               
            Console.WriteLine(ex.Message);
            }
            finally
            {
                Thread.Sleep(1000);
            }
        }
    }
}