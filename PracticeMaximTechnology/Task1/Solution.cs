namespace PracticeMaximTechnology.Task1;

public class Solution
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

    static string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}