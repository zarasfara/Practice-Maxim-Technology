using System.Text.RegularExpressions;

namespace PracticeMaximTechnology.Task1;

internal static class Solution
{
    public static string ProcessString(string input)
    {
        if (input.Length % 2 == 0)
        {
            int midIndex = input.Length / 2;
            string firstHalf = input.Substring(0, midIndex);
            string secondHalf = input.Substring(midIndex);

            firstHalf = ReverseString(firstHalf);
            secondHalf = ReverseString(secondHalf);

            return firstHalf + secondHalf;
        }
        else
        {
            string reversed = ReverseString(input);

            return reversed + input;
        }
    }

    public static bool IsValidString(string input, out string invalidChars)
    {
        Regex regex = new Regex("[^a-z]");
        MatchCollection matches = regex.Matches(input);

        invalidChars = new string(matches.Select(m => m.Value[0]).Distinct().ToArray());
        return matches.Count == 0;
    }

    private static string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}