using System;
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
        var protector = protecterProvider.CreateProtector("AwesomePurpose");
        while (true)
        {
            Console.Write($"Type something sensitive: ");
            var input = Console.ReadLine();
            var protectedInput = protector.Protect(input);
            Console.WriteLine($"Protected: {protectedInput}");
            var unprotectedInput = protector.Unprotect(protectedInput);
            Console.WriteLine($"Unprotected: {unprotectedInput}");
            Console.WriteLine();
        }
    }
}