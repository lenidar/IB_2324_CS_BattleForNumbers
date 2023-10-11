using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_2324_CS_BattleForNumbers
{
    internal class Program
    {
        // start 0740 end 0756 - 16 mins
        // assuming all users follow instructions, no error correcting required
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] nums = { };
            int[] tempNum = { };
            string uInput = "";
            int iInput = 0;
            int round = 0;
            int fight = 0;

            while (true)
            {
                Console.Write("Please enter how many contestants you would like to have (5-12) : ");
                uInput = Console.ReadLine();
                iInput = int.Parse(uInput);
                if (iInput >= 5 && iInput <= 12)
                    break;
            }

            nums = new int[iInput];

            // putting random numbers in the whole num array
            for (int x = 0; x < nums.Length; x++)
            {
                // i just added a 100 number limit to make it easier
                nums[x] = rnd.Next(100);
            }

            // Displaying all contestants
            Console.Write("\nYour contestants! ");
            for(int x = 0; x < nums.Length;x++)
            {
                Console.Write($"{nums[x]}\t");
            }

            Console.WriteLine("\n");

            while(nums.Length > 1)
            {
                // example, if the length of nums = 7, the length of tempNum must be 4
                if (nums.Length % 2 == 1)
                    tempNum = new int[(nums.Length / 2) + 1];
                else
                    tempNum = new int[(nums.Length / 2)];

                round++;

                for(int x = 0; x < tempNum.Length; x++)
                {
                    fight++;

                    if (x != nums.Length - 1 - x)
                    {
                        Console.Write($"Round {round} Fight {fight} - {nums[x]} vs {nums[nums.Length - 1 - x]} winner : ");
                        if (nums[x] > nums[nums.Length - 1 - x])
                        {
                            tempNum[x] = nums[x];
                            Console.WriteLine($"{nums[x]}!!!");
                        }
                        else
                        {
                            tempNum[x] = nums[nums.Length - 1 - x];
                            Console.WriteLine($"{nums[nums.Length - 1 - x]}!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Round {round} Fight {fight} - {nums[x]} has no opponents, it moves on to the next round.");
                        tempNum[x] = nums[x];
                    }
                }

                nums = tempNum;
                Console.WriteLine();
            }

            Console.WriteLine($"End of competition! The winner is {nums[0]}!!! Congratulations!");

            Console.ReadKey();
        }
    }
}
