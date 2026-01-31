using System;

static class CardBrandDetector
{
    public static string Detect(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "Unknown";
        var digits = GetDigits(input);
        if (string.IsNullOrEmpty(digits)) return "Unknown";

        int len = digits.Length;

        // American Express: 15 digits, starts with 34 or 37
        if (len == 15 && (digits.StartsWith("34") || digits.StartsWith("37"))) return "American Express";

        // Visa: starts with 4, length 13,16,19
        if (digits.StartsWith("4") && (len == 13 || len == 16 || len == 19)) return "Visa";

        // Mastercard: length 16, prefix 51-55 or 2221-2720
        if (len == 16)
        {
            if (TryStartsWithRange(digits, 2, 51, 55)) return "Mastercard";
            if (TryStartsWithRange(digits, 4, 2221, 2720)) return "Mastercard";
        }

        // Discover: 16 or 19, prefixes: 6011, 65, 644-649, 622126-622925
        if ((len == 16 || len == 19))
        {
            if (digits.StartsWith("6011") || digits.StartsWith("65") || TryStartsWithRange(digits, 3, 644, 649) || TryStartsWithRange(digits, 6, 622126, 622925)) return "Discover";
        }

        // JCB: starts with 35, length 16-19
        if (digits.StartsWith("35") && (len >= 16 && len <= 19)) return "JCB";

        // Diners Club (a few common ranges): 14 digits, starts with 36, 38, 30
        if (len == 14 && (digits.StartsWith("36") || digits.StartsWith("38") || digits.StartsWith("30"))) return "Diners Club";

        return "Unknown";
    }

    static string GetDigits(string s)
    {
        var arr = new System.Text.StringBuilder(s.Length);
        foreach (var c in s)
        {
            if (char.IsDigit(c)) arr.Append(c);
        }
        return arr.ToString();
    }

    static bool TryStartsWithRange(string digits, int prefixLength, int min, int max)
    {
        if (digits.Length < prefixLength) return false;
        if (!int.TryParse(digits.Substring(0, prefixLength), out var value)) return false;
        return value >= min && value <= max;
    }
}
