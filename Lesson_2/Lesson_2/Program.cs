using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // =============================
            Console.WriteLine("Ivan Alenin - Lesson 2 \n1. Decimal to binary.");
            // =============================
            // Lesson 2, Task 1
            bool result; int dec_val;
            do
            {
                Console.WriteLine("Please type decimal value: ");
                result = int.TryParse(Console.ReadLine(), out dec_val);
            } while (result == false);
            DecToBin(dec_val);
            // =============================
            // Lesson 2, Task 2


            // =============================
            Console.ReadLine();
        }

        // Lesson 2, Task 1
        static void DecToBin(int decimal_val)
        {
            Console.Write("Decimal: {0}, Binary: 0b", decimal_val.ToString());
            byte nothing = DecToBin_Rec(decimal_val);
        }

        static byte DecToBin_Rec(int decimal_val)
        {
            if (decimal_val != 0)
            {
                DecToBin_Rec(decimal_val / 2);
            }
            else return 0;

            Console.Write((decimal_val % 2).ToString());
            return 0;
        }
    }
}
