using System;

namespace Lesson_3
{
    class Program
    {
        static public int swapnumber = 0;
        static public int cyclenumber = 0;
        
        static void NewRandomArray(int N, int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                array[i] = rnd.Next(0, 255);
            }
        }
        static void TypeArray(int[] array, bool clear)
        {
            if (clear)
            {
                int n = 0;
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(array[n] + " \t");
                        n++;
                    }
                    Console.Write('\n');
                }
            }
            Console.WriteLine("Number of swaps: {0}", swapnumber);
            Console.WriteLine("Number of cycles: {0}", cyclenumber);            
        }
        static void SwapElement(ref int ar_el1, ref int ar_el2)
        {
            int buf = ar_el1;
            ar_el1 = ar_el2;
            ar_el2 = buf;
            swapnumber++;
        }

        static void BubleSort(ref int[] array, int armax)
        {
            swapnumber = 0;
            cyclenumber = 0;
            for (int i = 0; i < armax; i++)
            {
                for (int j = 0; j < armax - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        SwapElement(ref array[j], ref array[j + 1]);
                        cyclenumber++;
                    }
                    cyclenumber++;
                }
            }
        }

        static void ShakerSort(ref int[] array, int armax)
        {
            swapnumber = 0;
            cyclenumber = 0;
            int left = 0, right = armax - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        SwapElement(ref array[i], ref array[i + 1]);
                        cyclenumber++;
                    }
                    cyclenumber++;
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        SwapElement(ref array[i], ref array[i - 1]);
                        cyclenumber++;
                    }
                    cyclenumber++;
                }
                left++;
            }
        }

        static void InsertionSort(ref int[] array, int armax)
        {
            swapnumber = 0;
            cyclenumber = 0;
            for (int i = 0; i < armax; i++)
            {
                int buf = array[i];
                int j = i;
                while ((j > 0) && (array[j - 1] > buf))
                {
                    SwapElement(ref array[j], ref array[j-1]);
                    j--;
                    cyclenumber++;
                }

                array[j] = buf;
                cyclenumber++;
            }
        }

        static void Main(string[] args)
        {
            int armax = 100000;
            Console.WriteLine("Ivan Alenin - Lesson 3 - Tasks 2 & 4");
            Console.WriteLine("... Array generation ...");
            int[] array = new int[armax];
            int[] arraybuff = new int[armax];
            NewRandomArray(armax, array);
            TypeArray(array, true);

            armax = 100;
            Console.WriteLine("Bubble sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Shaker sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Insertion sorting:");
            Array.Copy(array, arraybuff, armax);
            InsertionSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            armax = 1000;
            Console.WriteLine("Bubble sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Shaker sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Insertion sorting:");
            Array.Copy(array, arraybuff, armax);
            InsertionSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            armax = 10000;
            Console.WriteLine("Bubble sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Shaker sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Insertion sorting:");
            Array.Copy(array, arraybuff, armax);
            InsertionSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            armax = 10000;
            Console.WriteLine("Bubble sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Shaker sorting:");
            Array.Copy(array, arraybuff, armax);
            BubleSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.WriteLine("Insertion sorting:");
            Array.Copy(array, arraybuff, armax);
            InsertionSort(ref arraybuff, armax);
            TypeArray(arraybuff, false);

            Console.ReadKey();
        }
    }
}
