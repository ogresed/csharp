using System;
using System.Collections.Generic;
using System.Globalization;

namespace guessing_game
{
    class Program
    {
        const int maxNumber = 250;
        static string nameOfGamer;
        const string messageToSayBye = "Bye.";
        const string messageAboutWrongNumber = "Enter a number from 0 to ";
        static int secretNumber;
        static List<int> history = new List<int>();
        static int counter = 0;
        static string[] frazes = {", patience.", ", do not give up.",
             ", you will succeed.", ", victory does not far away."};
        static Random rand = new Random();
        static DateTime start;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name.");
            nameOfGamer = Console.ReadLine();
            secretNumber = rand.Next(0, maxNumber + 1);
            Console.WriteLine($"Hello, {nameOfGamer}. Guess a number from 0 to {maxNumber}.");
            start = DateTime.Now;
            bool work = true;
            string value;

            while(work) {
                value = Console.ReadLine();
                if("q".Equals(value)) {
                    work = false;
                    Console.WriteLine(messageToSayBye);
                }
                else {
                    try {
                        int number = Int32.Parse(value, NumberStyles.Integer, new CultureInfo("ru-RU"));
                        if(!(number >= 0 && number <= maxNumber)) {
                            Console.WriteLine($"{messageAboutWrongNumber}{maxNumber}");
                        } else {
                            if(processing(number))
                                work = false;
                        }
                    } catch(Exception ex) {
                        if(ex is FormatException || ex is OverflowException) {
                            Console.WriteLine($"{messageAboutWrongNumber}{maxNumber}");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
        static bool processing(int number) {
            counter++;
            if(number > secretNumber) {
                history.Add(-number);
                Console.WriteLine("Lot");
                if(counter % 4 == 0 && counter != 0) {
                    writeFraze();
                }
                return false;
            }
            else if(number < secretNumber) {
                Console.WriteLine("Few");
                if (counter % 4 == 0 && counter != 0) {
                    writeFraze();
                }
                history.Add(number);
                return false;
            }
            else {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Congrats! Secret number is {secretNumber}. You win!");
                Console.ForegroundColor = ConsoleColor.White;
                showHistory();
                return true;
            }
        }
        static void showHistory() {
            if(counter == 0) {
                Console.WriteLine("On the first try!");
            } else {
                Console.WriteLine($"Аttempts {counter}");
                foreach (int item in history) {
                    Console.Write($"{Math.Abs(item)}   ");
                    if(item >= 0) {
                        Console.WriteLine("Few");
                    }
                    else {
                        Console.WriteLine("Lot");
                    }
                }
            }
            DateTime end = DateTime.Now;
            TimeSpan time = end - start;
            Console.WriteLine($"Spent time - {time.Hours}:{time.Minutes}:{time.Seconds}");
        }
        static void writeFraze () {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{nameOfGamer}{frazes[rand.Next() % frazes.Length]}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
