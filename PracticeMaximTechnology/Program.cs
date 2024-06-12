using PracticeMaximTechnology.Sort;
using PracticeMaximTechnology.Task1;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PracticeMaximTechnology;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine()!;

        if (Solution.IsValidString(input, out string invalidChars))
        {
            var (processedString, charOccurrences, longestString) = Solution.ProcessString(input);
            DisplayProcessedString(processedString, charOccurrences, longestString);

            string sortedString = ChooseAndSortString(input);
            Console.WriteLine(sortedString);
            
            int randomIndex = await GetRandomNumberAsync(processedString.Length - 1);
            string stringWithRemovedChar = processedString.Remove(randomIndex, 1);
            
            Console.WriteLine($"Строка после удаления символа на позиции {randomIndex}: {stringWithRemovedChar}");
        }
        else
        {
            Console.WriteLine($"Ошибка: введены неподходящие символы: {invalidChars}");
        }
    }

    private static async Task<int> GetRandomNumberAsync(int max)
    {
        HttpClient client = new();
        try
        {
            string url = $"https://www.randomnumberapi.com/api/v1.0/random?min=0&max={max}&count=1";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            int[] randomNumbers = JsonSerializer.Deserialize<int[]>(responseBody)!;

            return randomNumbers[0];
        }
        catch
        {
            var rnd = new Random();
            return rnd.Next(0, max);
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