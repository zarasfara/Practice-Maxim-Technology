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
                (string processedString, Dictionary<char, int> charOccurrences) = Solution.ProcessString(input);
                Console.WriteLine($"Обработанная строка: {processedString}");

                Console.WriteLine("Сколько раз повторяются символы:");

                foreach (var pair in charOccurrences)
                {
                    Console.WriteLine($"Символ '{pair.Key}' встречается {pair.Value} раз(а)");
                }
            }
            else
            {
                Console.WriteLine($"Ошибка: введены неподходящие символы: {invalidChars}");
            }
        }
    }
}