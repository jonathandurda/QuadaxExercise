using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadaxMasterMind
{
    class Program
    {
        static Random digits = new Random();

        static void Main(string[] args)
        {
            int digitFirst = digits.Next(1, 6);
            int digitSecond = digits.Next(1, 6);
            int digitThird = digits.Next(1, 6);
            int digitFourth = digits.Next(1, 6);
            string correctCombination = digitFirst.ToString() + digitSecond.ToString() + digitThird.ToString() + digitFourth.ToString();
            int[] outputNumbers = new int[4];
            string[] outputSymbols = new string[4];
            Console.WriteLine("Enter a 4 digit number with each digit between 1 and 6: ");
            string userNumber = Console.ReadLine();
            int userChoice = int.Parse(userNumber);
            bool userWins = false;
            int userAttempts = 1;
            while (userWins == false && userAttempts < 10)
            {
                bool invalidDigit = false;
                for (int x = 0; x < userNumber.Length; x++)
                {
                    try
                    {
                        if (int.Parse(userNumber.Substring(x, 1)) > 6)
                        {
                            invalidDigit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        invalidDigit = true;
                    }
                }
                while (invalidDigit == true || userNumber.Length != 4)
                {
                    Console.WriteLine("You entered an invalid number.  Please enter a 4 digit number with each digit between 1 and 6: ");
                    userNumber = Console.ReadLine();
                    invalidDigit = false;
                    for (int x = 0; x < userNumber.Length; x++)
                    {
                        try
                        {
                            if (int.Parse(userNumber.Substring(x, 1)) > 6)
                            {
                                invalidDigit = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            invalidDigit = true;
                        }
                    }
                }
                if (userNumber.Equals(digitFirst.ToString() + digitSecond.ToString() + digitThird.ToString() + digitFourth.ToString()))
                {
                    userWins = true;
                    Console.WriteLine("Correct!  You win!  You are on your way to becoming a regular genius!");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    int position = 0;
                    string foundNumbers = "";
                    for (int y = 0; y < 4; y++)
                    {
                        if (userNumber.Substring(y, 1).Equals(correctCombination.Substring(y, 1)))
                        {
                            outputNumbers[position] = int.Parse(userNumber.Substring(y, 1));
                            outputSymbols[position] = "+";
                            position++;
                            foundNumbers += userNumber.Substring(y, 1);
                        }
                    }
                    for (int z = 0; z < 4; z++)
                    {
                        if (correctCombination.Contains(userNumber.Substring(z, 1)) && !(foundNumbers.Contains(userNumber.Substring(z, 1))))
                        {
                            outputNumbers[position] = int.Parse(userNumber.Substring(z, 1));
                            outputSymbols[position] = "-";
                            position++;
                            foundNumbers += userNumber.Substring(z, 1);
                        }
                    }
                    for (int a = 0; a < 4; a++)
                    {
                        if (!(correctCombination.Contains(userNumber.Substring(a, 1))))
                        {
                            outputNumbers[position] = int.Parse(userNumber.Substring(a, 1));
                            outputSymbols[position] = " ";
                            position++;
                        }
                    }
                    Console.WriteLine("Incorrect! Please try again. Your hint is: ");
                    for (int b = 0; b < 4; b++)
                    {
                        Console.Write(outputNumbers[b]);
                    }
                    Console.WriteLine();
                    for (int c = 0; c < 4; c++)
                    {
                        Console.Write(outputSymbols[c]);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Enter a 4 digit number with each digit between 1 and 6 for guess " + (userAttempts + 1).ToString()  +  ": ");
                    userNumber = Console.ReadLine();
                }
                userAttempts++;
            }
            Console.WriteLine("Sorry, you lose this game!  Try again!");
            Console.WriteLine("The Answer was: " + digitFirst.ToString() + digitSecond.ToString() + digitThird.ToString() + digitFourth.ToString());
            Console.ReadLine();
        }
    }
}
