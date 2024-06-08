using System.Text.RegularExpressions;

namespace PracticeMaximTechnology.Task1
{
    public static class Solution
    {
        public static (string ProcessedString, Dictionary<char, int> CharOccurrences) ProcessString(string input)
        {
            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            string processedString;

            if (input.Length % 2 == 0)
            {
                int midIndex = input.Length / 2;
                string firstHalf = input.Substring(0, midIndex);
                string secondHalf = input.Substring(midIndex);

                firstHalf = ReverseString(firstHalf);
                secondHalf = ReverseString(secondHalf);

                processedString = firstHalf + secondHalf;
            }
            else
            {
                string reversed = ReverseString(input);
                processedString = reversed + input;
            }

            foreach (char c in processedString)
            {
                if (!charOccurrences.TryAdd(c, 1))
                {
                    charOccurrences[c]++;
                }
            }

            return (processedString, charOccurrences);
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
}