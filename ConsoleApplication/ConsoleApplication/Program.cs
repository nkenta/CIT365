using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        private static void Main()
        {
            //Handles users input and displays users keyed in informations//
            Console.WriteLine("Welcome! Press the Enter Key after you enter your Name and Location.");

            Console.WriteLine("Enter your Name:");

            var my_name = Console.ReadLine();

            Console.WriteLine("Enter your current Location:");

            var my_location = Console.ReadLine();

            Console.WriteLine($"My name is {my_name}, I am from {my_location}.");

            String current_date = GetTodayDate();

            Console.WriteLine($"Current Date: {current_date}");

            //Number of days until Christmas this year//
            var current = DateTime.Now; 
            int christmasSeason;
            if (current.Day > 24 && current.Month == 12)
            {
                christmasSeason = current.Year + 1;
            }
            else
            {
                christmasSeason = current.Year;
            }
            var christmas = new DateTime(christmasSeason, 25, 12);

            var untilChristmas = christmas.Date - current.Date;

            Console.WriteLine($"Hi, You have {untilChristmas} days before Christmas");

        }

        private static string GetTodayDate()
        {
            String dateNow = DateTime.Now.ToString("dd.mm.yy");
            return dateNow;

        }
    }
}
