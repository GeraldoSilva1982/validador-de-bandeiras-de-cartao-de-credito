using System;
using System.Text.RegularExpressions;

string number;

if (args.Length == 0)
{
    Console.Write("Numero do cartao (somente digitos): ");
    var line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line)) return;
    number = Regex.Replace(line, "\\s+", "");
    if (!Regex.IsMatch(number, "^\\d+$"))
    {
        Console.Error.WriteLine("Entrada invalida: use somente digitos.");
        return;
    }
}
else
{
    number = Regex.Replace(args[0], "\\s+", "");
    if (!Regex.IsMatch(number, "^\\d+$"))
    {
        Console.Error.WriteLine("Entrada invalida: primeiro argumento deve conter somente digitos.");
        return;
    }
}

var brand = CardBrandDetector.Detect(number);
Console.WriteLine($"Número: {number}");
Console.WriteLine($"Bandeira: {brand}");

// Note: helper functions removed in minimal mode.
