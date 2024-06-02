using PracticeMaximTechnology.Task1;

namespace PracticeMaximTechnology
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            string result = Solution.ProcessString(input);

            Console.WriteLine("Обработанная строка:");
            Console.WriteLine(result);
        }
    }
}