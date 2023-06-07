using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public struct Range
    {
        private readonly int _a; // Левая граница диапазона
        private readonly int _b; // Правая граница диапазона

        public int A => _a;
        public int B => _b;
        public int Count => B - A; // Количество чисел в диапазоне

        public Range(int a, int b)
        {
            if (b <= a)
                throw new ArgumentException("Значение B должно быть больше A.");
            if (a >= b)
                throw new ArgumentException("Значение A должно быть меньше значения B.");

            _a = a;
            _b = b;
        }

        public bool IsContains(int number)
        {
            return number >= A && number < B; // Проверяем, лежит ли заданное число в диапазоне
        }

        public override string ToString()
        {
            return $"[{A}; {B})"; // Представление диапазона в виде строки
        }

        public override bool Equals(object obj) //проверяет, является ли текущий объект эквивалентным переданному объекту
        {
            if (obj is Range other)
            {
                return A == other.A && B == other.B;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (A.GetHashCode()) ^ B.GetHashCode();//возвращает уникальный хеш-код для структуры Range на основе значений ее полей
        }

        public static Range operator &(Range range1, Range range2)
        {
            int a = Math.Max(range1.A, range2.A); // Левая граница нового диапазона - максимум из левых границ двух диапазонов
            int b = Math.Min(range1.B, range2.B); // Правая граница нового диапазона - минимум из правых границ двух диапазонов

            if (a >= b)
                return new Range(0, 0);  // Возвращаем пустой диапазон, если пересечение не существует
            return new Range(a, b); // Возвращаем новый диапазон
        }

        public static Range operator |(Range range1, Range range2)
        {
            int a = Math.Min(range1.A, range2.A); // Левая граница нового диапазона - минимум из левых границ двух диапазонов
            int b = Math.Max(range1.B, range2.B); // Правая граница нового диапазона - максимум из правых границ двух диапазонов
            return new Range(a, b); // Возвращаем новый диапазон
        }
    }
}
