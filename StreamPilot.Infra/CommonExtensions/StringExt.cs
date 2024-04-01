using System.Text.RegularExpressions;

namespace StreamPilot.Infra.CommonExtensions;

public static partial class StringExt
{
    const string _pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

    [GeneratedRegex(_pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex GetRegexForEmail();

    public static bool IsValidEmail(this string email)
    {
        try
        {
            return !string.IsNullOrEmpty(email) && GetRegexForEmail().IsMatch(email);
        }
        catch
        {
            return false;
        }
    }

    // TODO: add password policy with Regex. the email will be example for that 


    public static bool EqualsWithSpanIgnoreCase(this string str1, string str2)
    {
        if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
        {
            return false;
        }

        return str1.AsSpan().Equals(str2.AsSpan(), StringComparison.OrdinalIgnoreCase);
    }

    public static bool ContainsOnlyLetters(this string input)
    {
        // Check if the input string is null
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        // Use Span<char> to efficiently check each character
        ReadOnlySpan<char> charSpan = input.AsSpan();

        foreach (var c in charSpan)
        {
            if (char.IsLetter(c))
            {
                continue;
            }

            return false;
        }

        return true;
    }

    public static bool ContainsOnlyDigits(this string input)
    {
        // Check if the input string is null
        ArgumentException.ThrowIfNullOrWhiteSpace(input);

        // Use Span<char> to efficiently check each character
        ReadOnlySpan<char> charSpan = input.AsSpan();

        foreach (var c in charSpan)
        {
            if (char.IsDigit(c))
            {
                continue;
            }

            return false;
        }

        return true;
    }
}
