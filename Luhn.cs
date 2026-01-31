using System;

static class Luhn
{
    // Validate a numeric string with the Luhn algorithm
    public static bool IsValid(string number)
    {
        if (string.IsNullOrWhiteSpace(number)) return false;
        int sum = 0;
        bool alternate = false;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            char c = number[i];
            if (!char.IsDigit(c)) return false;
            int n = c - '0';
            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }
            sum += n;
            alternate = !alternate;
        }
        return sum % 10 == 0;
    }

    // Calculate Luhn check digit for a numeric string without the check digit
    public static int CalculateCheckDigit(string partialNumber)
    {
        int sum = 0;
        bool alternate = true; // when computing check digit we start as if one more digit exists
        for (int i = partialNumber.Length - 1; i >= 0; i--)
        {
            char c = partialNumber[i];
            if (!char.IsDigit(c)) throw new ArgumentException("partialNumber must be numeric");
            int n = c - '0';
            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }
            sum += n;
            alternate = !alternate;
        }
        int mod = sum % 10;
        return (10 - mod) % 10;
    }
}
