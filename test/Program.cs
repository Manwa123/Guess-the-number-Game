using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("topten.txt"))
            {
                StreamReader f2 = new StreamReader("topten.txt");
                Console.WriteLine("TOP TEN-TABLE");
                Console.WriteLine("------------------");
                for (int i = 1; i <= 10; i++)
                {
                    string name = f2.ReadLine();
                    int score = int.Parse(f2.ReadLine());
                    Console.WriteLine("{0}--------{1}", name, score);
                }
                f2.Close();
            }
            else
                Console.WriteLine("The Fille topten.txt does not Exist\n Cnees the F");

            string [] names = new string[10];
            int[] scores = new int[10];
            int playerCount = 0;

            bool continuePlaying = true;

            while (continuePlaying)
            {
                Random random = new Random();
                int rnd = random.Next(1, 101);
                int guess;
                int score = 1500;
                int win = 0;
                bool lose = true;
                char again;

                Console.WriteLine("Enter your name:");
                string playerName = Console.ReadLine();

                do
                {
                   

                    Console.WriteLine("Guess the number!");
                    guess = int.Parse(Console.ReadLine());
                    score = score - 100; 

                    if (guess > rnd)
                    {
                        Console.WriteLine("High!");
                        score++;
                    }

                    if (guess < rnd)
                    {
                        Console.WriteLine("Low!");
                        score++;
                    }

                    if (score >= 10)
                    {
                        Console.WriteLine("Be careful, you are almost out of lives!");
                    }

                    if (score == 15)
                    {
                        Console.WriteLine("Game over, never give up");
                        Console.WriteLine($"The number was {rnd}. Would you like to try again? Y/N");
                        again = char.Parse(Console.ReadLine());
                        if (again == 'y' || again == 'Y')
                        {
                            lose = true;
                        }
                        else
                        {
                            lose = false;
                        }
                    }

                    if (guess == rnd)
                    {
                        win++;
                        if (score == 1)
                        {
                            Console.WriteLine("Congratulations, you did it in the first try!");
                        }
                        else if (score > 1 && score <= 5)
                        {
                            Console.WriteLine($"Yeah!!! You did it in {score} tries!");
                        }
                        else if (score > 5 && score < 15)
                        {
                            Console.WriteLine($"Wow, you almost lost but you eventually got it in {score} tries!");
                        }

                        Console.WriteLine("Would you like to try again? Y/N");
                        again = char.Parse(Console.ReadLine());
                        if (again == 'y' || again == 'Y')
                        {
                            lose = true;
                        }
                        else
                        {
                            lose = false;
                        }
                    }

                } while (lose == true);

                if (playerCount < 10 || score < scores[9])
                {
                    if (playerCount < 10)
                    {
                        names[playerCount] = playerName;
                        scores[playerCount] = score;
                        playerCount++;
                    }
                    else
                    {
                        int position = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            if (score > scores[i])
                            {
                                position = i;
                                break;
                            }
                        }

                        for (int i = 9; i > position; i--)
                        {
                            scores[i] = scores[i - 1];
                            names[i] = names[i - 1];
                        }
                        scores[position] = score;
                        names[position] = playerName;
                    }
                }
                score = 1500;
                win = 0;
                Console.WriteLine("\nTop Ten Players:");
                for (int i = 0; i < playerCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {names[i]} - Score: {scores[i]}");
                }

                Console.WriteLine("\nWould you like to play again? Y/N");
                char playAgain = char.Parse(Console.ReadLine());
                continuePlaying = (playAgain == 'y' || playAgain == 'Y');
            }
        }
    }
}
    

