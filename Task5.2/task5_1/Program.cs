using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_1
{
    class Program
    {
        static int GetDifference(int[] array)
        {
            int halfLength = (int)Math.Ceiling(array.Length / 2.0);

            int sumOdd = array
                .Take(halfLength)
                .Where(x => x % 2 != 0)
                .Sum();
            Console.WriteLine("Сумма нечетных чисел первой половины массива: " + sumOdd);

            int sumEven = array
                .Skip(halfLength - (array.Length % 2 == 0 ? 0 : 1))
                .Where(x => x % 2 == 0)
                .Sum();
            Console.WriteLine("Сумма четных чисел второй половины массива: " + sumEven);

            return sumOdd - sumEven;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа массива, разделяя их пробелом:");
            int[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

            int difference = GetDifference(numbers);

            Console.WriteLine("Разница: " + difference);
            Console.ReadKey();
        }
    }
}
