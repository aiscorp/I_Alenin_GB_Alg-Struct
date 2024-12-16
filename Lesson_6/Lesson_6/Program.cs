using System;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson 6 - Ivan Alenin \nHash function.");
            Console.WriteLine("Type a string for hash calculation:");
            string input = Console.ReadLine();
            long hash = input.Length;

            //Увеличиваем строку до 32 символов, если меньше введено
            if (input.Length < 32)
            {
                int j = 32 - input.Length;
                int length_before = input.Length;
                int i = 0;
                do
                {
                    input += input[i];
                    i++;
                    if (i == length_before) i = 0;
                    j--;
                }
                while (j != 0);
            }
            else
            {
                input = input.Remove(32);
            }

            Console.WriteLine(input);
            Console.ReadKey();

            for (int i = input.Length; i > 0; i--)
            {
                //для нечетных символов суммируем коды символов уможив на 11, для четных на 7
                if (i % 2 == 0)
                {
                    hash += input[i - 1] * 7;
                }
                else
                {
                    hash += input[i - 1] * 11;
                }
                // вычитаем остаток деления на 32 от  предыдущего символа
                if (i != input.Length) hash -= input[i] % 32;
            }
            Console.WriteLine("Hash:{0:d}", hash);



            Console.ReadKey();
        }
    }
}
