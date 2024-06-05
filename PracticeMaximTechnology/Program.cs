using PracticeMaximTechnology.Task1;

namespace PracticeMaximTechnology
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            if (Solution.IsValidString(input, out string invalidChars))
            {
                string result = Solution.ProcessString(input);
                Console.WriteLine("Обработанная строка:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"Ошибка: введены неподходящие символы: {invalidChars}");
            }
        }
    }
}