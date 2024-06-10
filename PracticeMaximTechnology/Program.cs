using PracticeMaximTechnology.Task1;

namespace PracticeMaximTechnology
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string? input = Console.ReadLine();

            if (Solution.IsValidString(input, out string invalidChars))
            {
                (string processedString, Dictionary<char, int> charOccurrences, string longestVowelSubstring) = Solution.ProcessString(input);
                Console.WriteLine($"Обработанная строка: {processedString}");

                Console.WriteLine("Сколько раз повторяются символы:");

                foreach (var pair in charOccurrences)
                {
                    Console.WriteLine($"Символ '{pair.Key}' встречается {pair.Value} раз(а)");
                }

                Console.WriteLine($"Самая длинная подстрока начинающаяся и заканчивающаяся на гласную: {longestVowelSubstring}");
            }
            else
            {
                Console.WriteLine($"Ошибка: введены неподходящие символы: {invalidChars}");
            }
        }
    }
}