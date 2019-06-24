using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
{
    class Program
    {
        static int Int(string sentence, int minBorder = int.MinValue, int maxBorder = int.MaxValue)
        {
            int result = 0;
            bool ok = true;
            do
            {
                Console.Write(sentence);
                ok = int.TryParse(Console.ReadLine(), out result);
                if (result < minBorder || result > maxBorder)
                {
                    ok = false;
                }
            }
            while (!ok);
            return result;
        }
        static int[] ParseNumbers(string sentence, int len)
        {
            int[] result = new int[0];
            bool ok = true;
            do
            {
                try
                {
                    Console.Write(sentence);
                    string input = Console.ReadLine().Replace('.', ',');
                    result = input.Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                    if (result.Length != len) throw new IndexOutOfRangeException();
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат строки");
                    ok = false;

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Неверное количество чисел в строке");
                    ok = false;
                }

            }
            while (!ok);
            return result;
        }
        static void Main(string[] args)
        {
            int size = Int("Введите размер массива: ");

            int[] array = ParseNumbers("Введите элементы массива через пробел: ", size);
            Tree tree = new Tree(array);
            tree.Run();
        }
    }
}
