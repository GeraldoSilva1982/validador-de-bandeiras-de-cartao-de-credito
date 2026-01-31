using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

static class CardGenerator
{
    // Generate `count` card numbers that match `regexPattern`, have `length` digits and pass Luhn.
    // If `prefix` is provided, generated numbers will start with it.
    public static IEnumerable<string> Generate(string regexPattern, int length, int count, string? prefix = null, int maxAttemptsPerCard = 200000)
    {
        if (length <= 0) throw new ArgumentException("length must be > 0");
        var regex = new Regex(regexPattern);
        var rng = RandomNumberGenerator.Create();
        var results = new List<string>(count);

        int generated = 0;
        while (generated < count)
        {
            int attempts = 0;
            bool found = false;
            while (attempts++ < maxAttemptsPerCard)
            {
                var candidate = BuildCandidate(rng, length, prefix);
                if (!regex.IsMatch(candidate)) continue;
                if (!Luhn.IsValid(candidate)) continue;
                results.Add(candidate);
                generated++;
                found = true;
                break;
            }

            if (!found)
            {
                throw new InvalidOperationException($"Could not generate a card after {maxAttemptsPerCard} attempts. Try a simpler regex or different length/prefix.");
            }
        }

        return results;
    }

    static string BuildCandidate(RandomNumberGenerator rng, int length, string? prefix)
    {
        prefix ??= string.Empty;
        if (prefix.Length > length) throw new ArgumentException("prefix longer than total length");
        int remaining = length - prefix.Length;
        Span<byte> buffer = stackalloc byte[remaining];
        rng.GetBytes(buffer);
        char[] digits = new char[length];
        for (int i = 0; i < prefix.Length; i++) digits[i] = prefix[i];
        for (int i = 0; i < remaining; i++)
        {
            digits[prefix.Length + i] = (char)('0' + (buffer[i] % 10));
        }
        return new string(digits);
    }
}
