using System;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите минимальное значение: ");
            int min = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите максимально значение: ");
            int max = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите необходимое кол-во чисел: ");
            int capacity = Convert.ToInt32(Console.ReadLine());

            int[] newArr = GenerateRandomRange(min, max, capacity);

            ReadArray(newArr, capacity);//Вывод массива
        }

        static int[] GenerateRandomRange(int min, int max, int capacity)//Метод для генерации массива чисел в деапозоне
        {
            Random rand = new Random();
            int[] arr = new int[capacity];
            int len = 0;

            for (int i = 0; i < capacity; i++)
            {
                int number;

                while (true)
                {
                    number = rand.Next(min, max + 1);//Случайное число от мин до макс включая макс

                    if (CheckRepeat(arr, capacity, number) == false)//Проверка на повторение в массиве
                        break;
                }

                arr[len++] = number;//Запись числа в массив
            }

            Sort(arr, capacity);//Простая сортировка

            return arr;
        }

        static bool CheckRepeat(int[] arr, int capacity, int value)
        {
            for (int i = 0; i < capacity; ++i)
            {
                if (arr[i] == value)
                    return true;
            }

            return false;
        }

        static void Sort(int[] arr, int capacity)
        {
            for (int i = 0; i < capacity - 1; ++i)
            {
                for (int j = i + 1; j < capacity; ++j)
                {
                    if (arr[i] > arr[j])
                    {
                        int value = arr[i];
                        arr[i] = arr[j];
                        arr[j] = value;
                    }
                }
            }
        }

        static void ReadArray(int[] arr, int capacity)
        {
            for (int i = 0; i < capacity; i++)
                Console.Write($"[{arr[i]}] ");
        }
    }
}
