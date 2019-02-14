using System;
namespace colendar
{
    class Program 
    {
        static void Main(string[] args)
        {
            bool work = true;
            while(work) {
                ConsoleColor color = ConsoleColor.White;
                Console.ForegroundColor = color;
                Console.WriteLine("enter youre date:");
                string value = Console.ReadLine();
                DateTime date;
                if(DateTime.TryParse(value, out date)) {
                    EnterMonth(date);
                }
                else {
                    work = false;
                    Console.WriteLine("Wrong date");
                }
            }
        }
        private static void EnterMonth(DateTime date)
        {
            string twoSpace = "  ";
            string oneSpace = " ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Пн Вт Ср Чт Пт Сб Вс");
            Console.ForegroundColor = ConsoleColor.White;
            DateTime newDate = new DateTime(date.Year, date.Month, 1);
            DayOfWeek day = DayOfWeek.Monday;
            while (day != newDate.DayOfWeek)
            {
                day = (DayOfWeek)((int)(day + 1) % 7);
                Console.Write("   ");
            }
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            int dayOff = 0;
            for(int i = 1; i <= daysInMonth; i++) {
                string spaces = i / 10 > 0 ? oneSpace : twoSpace;
                if(day == DayOfWeek.Sunday || day == DayOfWeek.Saturday) {
                    dayOff++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{i}{spaces}");
                    if(day == DayOfWeek.Sunday) {
                        Console.Write("\n");
                    }
                } else {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{i}{spaces}");
                }
                day = (DayOfWeek)((int)(day+1) % 7);
            }
            Console.WriteLine($"\nNumber of days off is {dayOff}");
        }
    }
}
