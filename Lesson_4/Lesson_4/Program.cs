using System;

namespace Lesson_4
{
    public class Lesson4
    {
        static private int board_x_max = 5;
        static private int board_y_max = 5;
        static private int[,] board;

        static private int horse_x_current = 0;
        static private int horse_y_current = 0;
        static private int move_number = 0;

        static private int counter = 0;

        static private int[,] horse_moves = new int[8, 2] { { 2, 1 }, { 1, 2 }, { -2, 1 }, { -1, 2 }, { 2, -1 }, { 1, -2 }, { -2, -1 }, { -1, -2 } };

        static public void Main()
        {
            Console.WriteLine("Lesson 4 - Ivan Alenin - Horse task");

            for (int i = 3; i <= 8; ++i)
            {
                board_x_max = i;
                board_y_max = i;
                board = new int[board_x_max, board_y_max];
                BoardClean(ref board);

                horse_x_current = 0;
                horse_y_current = 0;
                move_number = 0;
                counter = 0;

                Console.WriteLine(DateTime.Now.ToLocalTime().ToString());
                SearchSolution();
                if (move_number == board_x_max * board_y_max)
                {
                    Console.WriteLine("Решение достигнуто при стороне :" + i);
                    BoardPrint(ref board);
                    Console.WriteLine("Кол-во ходов:{0} : Всего ходов конем:{1}", move_number, counter);
                    Console.WriteLine(DateTime.Now.ToLocalTime().ToString());
                }
                else
                {
                    Console.WriteLine("Решение не достигнуто при стороне :" + i);
                }
            }
            Console.ReadKey();
        }


        // Проверка всей доски
        static private int SearchSolution(int horse_move_counter = 0)
        {
            if (move_number == board_x_max * board_y_max)
            {
                return -2; // решение выполнено
            }
            else
            {
                horse_move_counter = HorseTryMove(horse_move_counter);
                if (horse_move_counter == -1)
                {
                    return -1;
                }
                if (SearchSolution(0) == -1 && move_number != board_x_max * board_y_max)
                {
                    HorseBackMove(horse_move_counter);
                    horse_move_counter++;
                    if (horse_move_counter < 8) SearchSolution(horse_move_counter);
                }
            }
            return -1;
        }

        static private int HorseTryMove(int horse_move_counter)
        {
            if (move_number == 0)
            {
                move_number++;
                board[horse_x_current, horse_y_current] = move_number;
            }
            int x2, y2;

            for (; horse_move_counter < 8; horse_move_counter++)
            {
                x2 = horse_x_current + horse_moves[horse_move_counter, 0];
                y2 = horse_y_current + horse_moves[horse_move_counter, 1];

                if (x2 >= 0 && x2 < board_x_max && y2 >= 0 && y2 < board_y_max && board[x2, y2] == 0)
                {
                    horse_x_current = x2;
                    horse_y_current = y2;
                    move_number++;
                    board[horse_x_current, horse_y_current] = move_number;
                    counter++;
                    return horse_move_counter;
                }
            }
            return -1;
        }

        static private void HorseBackMove(int horse_move_counter)
        {
            board[horse_x_current, horse_y_current] = 0;
            horse_x_current -= horse_moves[horse_move_counter, 0];
            horse_y_current -= horse_moves[horse_move_counter, 1];
            move_number--;
        }


        static private void BoardPrint(ref int[,] board)
        {
            for (int i = 0; i < board_y_max; i++)
            {
                for (int j = 0; j < board_x_max; j++)
                {
                    Console.Write("{0:d2}", board[j, i]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }


        static private void BoardClean(ref int[,] board)
        {
            for (int i = 0; i < board_x_max; i++)
                for (int j = 0; j < board_y_max; j++)
                    board[i, j] = 0;
        }

    }

}
