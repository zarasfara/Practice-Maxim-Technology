using PracticeMaximTechnology.Sort;
using PracticeMaximTechnology.Task1;

namespace PracticeMaximTechnology;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine()!;

        if (Solution.IsValidString(input, out string invalidChars))
        {
            var (processedString, charOccurrences, longestString) = Solution.ProcessString(input);
            DisplayProcessedString(processedString, charOccurrences, longestString);

            string sortedString = ChooseAndSortString(input);
            Console.WriteLine(sortedString);
        }
        else
        {
            Console.WriteLine($"Ошибка: введены неподходящие символы: {invalidChars}");
        }
    }

    private static void DisplayProcessedString(string processedString, Dictionary<char, int> charOccurrences, string longestVowelSubstring)
    {
        Console.WriteLine($"Обработанная строка: {processedString}");

        Console.WriteLine("Сколько раз повторяются символы:");
        foreach (var pair in charOccurrences)
        {
            Console.WriteLine($"Символ '{pair.Key}' встречается {pair.Value} раз(а)");
        }
        
        Console.WriteLine($"Самая длинная подстрока начинающаяся и заканчивающаяся на гласную: {longestVowelSubstring}");
    }

    private static string ChooseAndSortString(string input)
    {
        Console.WriteLine("Выберите метод сортировки: 1 - Quick sort, 2 - Tree sort.");
        var choice = Console.ReadLine()!;

        return choice switch
        {
            "1" => QuickSort.Sort(input),
            "2" => TreeSort.Sort(input),
            _ => throw new ArgumentException("Неверный выбор.")
        };
    }
}